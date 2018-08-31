using System;
using WebReport.Entity.Sys;
using WebReport.Utils;

namespace WebReport.Models
{
    public class BaseManager
    {
        /// <summary>
        /// DB操作
        /// </summary>
        protected CommDAL DBAgent = new CommDAL();

        /// <summary>
        /// 初始化SQL 不分页 无参
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        protected SQLExecuteParam InitSQLParam(string sql)
        {
            return InitSQLParam(null, null, sql);
        }

        /// <summary>
        /// 初始化SQL 分页 无参
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        protected SQLExecuteParam InitSQLParam(PaginationInfo pagInfo, string sql)
        {
            return InitSQLParam(pagInfo, null, sql);
        }

        /// <summary>
        /// 初始化SQL 不分页 有参
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        protected SQLExecuteParam InitSQLParam(Object t, string sql)
        {
            return InitSQLParam(null, t, sql);
        }

        /// <summary>
        /// 初始化SQL参数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pagInfo"></param>
        /// <param name="t"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        protected SQLExecuteParam InitSQLParam(PaginationInfo pagInfo, Object t, string sql)
        {
            SQLExecuteParam param = new SQLExecuteParam();
            param.pagination = pagInfo;
            param.obj = t;
            param.sql = sql;
            return param;
        }

        /// <summary>
        /// 根据ID更新指定表指定字段到指定值
        /// </summary>
        /// <param name="tbName"></param>
        /// <param name="colName"></param>
        /// <param name="colValue"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        protected bool ModifyDataColumnById(string tbName, string colName, string colValue, int id)
        {
            SQLExecuteParam param = new SQLExecuteParam();
            param.sql = " UPDATE " + tbName + " SET " + colName + " = " + colValue + " WHERE id = @id ";
            param.dict.Add("id", id);
            if (1 == DBAgent.SQLExecuteReturnRows(param))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected T GetInfoById<T>(int id, string sql) where T : new()
        {
            return GetInfoById<T>(id, "id", sql);
        }

        /// <summary>
        /// 根据Id获取单条数据信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        protected T GetInfoById<T>(int id, string paramName, string sql) where T : new()
        {
            SQLExecuteParam param = new SQLExecuteParam();
            param.sql = sql;
            param.dict.Add(paramName, id);
            return DBAgent.SQLExecuteSingleData<T>(param);
        }
        
        /// <summary>
        /// 删除指定数据表中指定id的数据
        /// </summary>
        /// <param name="tbName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        protected bool DeleteDataById(string tbName, int id)
        {
            return ModifyDataColumnById(tbName, "isDeleted", "1", id);
        }

    }
}