using System.Collections.Generic;
using System.Web.Script.Serialization;
using WebReport.Entity.Sys;
using WebReport.Entity.User;

namespace WebReport.Models
{
    public class PowerManager : BaseManager
    {
        /// <summary>
        /// 根据角色ID获取权限列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<PageTreeDto> GetPowerList(int id)
        {
            List<PageTreeDto> paglist = new List<PageTreeDto>();

            SQLExecuteParam SQL = new SQLExecuteParam();
            SQL.dict.Add("id", id);
            SQL.sql = @"SELECT
	                        A.id,
	                        A.fId,
	                        A.name AS text,
	                        A.type,
	                        B.id AS powerId,
                            A.controller,
                            A.param,
                            A.url,
                            A.icon
                        FROM tbPage AS A
                        LEFT JOIN (SELECT
	                        ROW_NUMBER() OVER (PARTITION BY pageId ORDER BY id) AS No,
	                        *
                        FROM tbPower WHERE roleId = @id) AS B
	                        ON A.id = B.pageId AND B.No = 1
	                        
                        WHERE A.isDeleted = 0 ORDER BY A.sort ASC";

            List<PagePowerDto> powerlist = DBAgent.SQLExecuteReturnList<PagePowerDto>(SQL);

            foreach (PagePowerDto item in powerlist)
            {
                if (item.type == 0)
                {
                    PageTreeDto dto = new PageTreeDto();
                    dto.pageId = item.id;
                    dto.state.@checked = item.powerId > 0 ? true : false;
                    dto.text = item.text;
                    dto.faicon = item.icon;
                    dto.url = item.url;
                    dto.controller = item.controller;
                    dto.param = item.param;
                    List<PageTreeMdDto> subpaglist = new List<PageTreeMdDto>();
                    foreach (PagePowerDto subitem in powerlist)
                    {
                        if (subitem.type == 1 && subitem.fId == item.id)
                        {
                            PageTreeMdDto subDto = new PageTreeMdDto();
                            subDto.pageId = subitem.id;
                            subDto.state.@checked = subitem.powerId > 0 ? true : false;
                            subDto.text = subitem.text;
                            subDto.url = subitem.url;
                            subDto.controller = subitem.controller;
                            subDto.param = subitem.param;
                            List<PageTreeEndDto> thrdlist = new List<PageTreeEndDto>();
                            foreach (PagePowerDto thrditem in powerlist)
                            {
                                if (thrditem.type == 2 && thrditem.fId == subitem.id)
                                {
                                    PageTreeEndDto thrdDto = new PageTreeEndDto();
                                    thrdDto.pageId = thrditem.id;
                                    thrdDto.state.@checked = thrditem.powerId > 0 ? true : false;
                                    thrdDto.text = thrditem.text;
                                    thrdDto.url = thrditem.url;
                                    thrdDto.controller = thrditem.controller;
                                    thrdDto.param = thrditem.param;
                                    thrdlist.Add(thrdDto);
                                }
                            }
                            subDto.nodes = thrdlist;
                            subpaglist.Add(subDto);
                        }
                    }
                    dto.nodes = subpaglist;
                    paglist.Add(dto);
                }
            }

            return paglist;
        }

        public bool SavePower(int id, string list, int creator)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<PageTreeDto> ListDto = js.Deserialize<List<PageTreeDto>>(list);

            MultiSQLExecuteParam param = new MultiSQLExecuteParam();
            //删除权限数据
            param.beforeSql = @"DELETE FROM tbPower WHERE roleId = @id";
            param.beforeParam.Add("id", id);

            param.listSql = @"INSERT tbPower
                        (	roleId,
	                        pageId,
	                        createDate,
	                        creator)
                        VALUES
                        (	@roleId,
	                        @pageId,
	                        GETDATE(),
	                        @creator)";
            int opCount = 0;
            foreach (PageTreeDto item in ListDto)
            {
                //判断是否为checked 由于当前设计看不到上层即看不到下层页面 如果上层未选择则视为下层也不选中
                if (item.state.@checked == true)
                {
                    //保存该条
                    item.roleId = id;
                    item.creator = creator;
                    param.objList.Add(item);
                    opCount++;

                    //循环Nodes
                    foreach (var subitem in item.nodes)
                    {
                        if (subitem.state.@checked == true)
                        {
                            //保存该条
                            subitem.roleId = id;
                            subitem.creator = creator;
                            param.objList.Add(subitem);
                            opCount++;
                            //循环Nodes
                            foreach (var thrditem in subitem.nodes)
                            {
                                if (thrditem.state.@checked == true)
                                {
                                    //保存该条
                                    thrditem.roleId = id;
                                    thrditem.creator = creator;
                                    param.objList.Add(thrditem);
                                    opCount++;

                                }
                            }
                        }
                    }
                }
            }

            if (opCount == DBAgent.MultipleSQLExecuteReturnRows(param))
            {
                return true;
            }

            return false;
        }
    }
}