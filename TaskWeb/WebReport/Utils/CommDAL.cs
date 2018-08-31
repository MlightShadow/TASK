using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Configuration;
using System.Reflection;
using WebReport.Entity.Sys;

namespace WebReport.Utils
{
    /// <summary>
    /// dapper共通操作
    /// </summary>
    public class CommDAL
    {
        /// <summary>
        /// 类连接成员
        /// </summary>
        private string connectString = "";

        /// <summary>
        /// 默认连接字符串
        /// </summary>
        public static string connString = ConfigurationManager.ConnectionStrings["DALconnect2"].ConnectionString;

        /// <summary>
        /// obj转dict 分页用
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private Dictionary<string, object> ObjToDict(object o)
        {
            Dictionary<String, Object> map = new Dictionary<string, object>();
            Type t = o.GetType();
            PropertyInfo[] pi = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo p in pi)
            {
                MethodInfo mi = p.GetGetMethod();

                if (mi != null && mi.IsPublic)
                {
                    map.Add(p.Name, mi.Invoke(o, new Object[] { }));
                }
            }
            return map;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="connectString"></param>
        public CommDAL(string connectString)
        {
            this.connectString = connectString;
        }

        /// <summary>
        /// 默认连接初始化
        /// </summary>
        public CommDAL()
        {
            this.connectString = connString;
        }

        /* Dapper数据处理共通方法设计
         * 
         * 查询(有/无参数), 执行SQL(有/无参数)

         */

        /// <summary>
        /// 测试连接是否可用
        /// </summary>
        /// <returns></returns>
        public bool TestConnect()
        {
            SqlConnection connection = new SqlConnection(this.connectString);
            try
            {
                connection.Open();
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                Log.WriteLog(ex.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// SQL执行方法返回单一数据对象
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public T SQLExecuteSingleData<T>(SQLExecuteParam dto) where T : new()
        {
            T t = default(T);
            SqlConnection connection = new SqlConnection(this.connectString);
            try
            {
                connection.Open();
                if (dto.obj != null)
                {
                    t = connection.Query<T>(dto.sql, dto.obj).SingleOrDefault();
                }
                else if (dto.dict.Count > 0)
                {
                    t = connection.Query<T>(dto.sql, dto.dict).SingleOrDefault();
                }
                else
                {
                    t = connection.Query<T>(dto.sql, null).SingleOrDefault();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                Log.WriteLog(ex.Message);
                return default(T);
            }
            return t;
        }

        /// <summary>
        /// SQL执行方法返回DataTable
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public DataTable SQLExecuteReturnTable(SQLExecuteParam dto)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(this.connectString);
            try
            {
                IEnumerable<dynamic> rows = null;
                connection.Open();
                if (dto.obj != null)
                {
                    rows = connection.Query(dto.sql, dto.obj);
                }
                else if (dto.dict.Count > 0)
                {
                    rows = connection.Query(dto.sql, dto.dict);
                }
                else
                {
                    rows = connection.Query(dto.sql, null);
                }
                int flag = 0;
                foreach (IDictionary<string, object> row in rows)
                {
                    ICollection<string> arrStr = row.Keys;

                    if (flag == 0)
                    {
                        foreach (string str in arrStr)
                        {
                            dt.Columns.Add(str);
                        }
                        flag = 1;
                    }
                    DataRow dtrow = dt.NewRow();
                    foreach (string str in arrStr)
                    {
                        dtrow[str] = (object)row[str];
                    }
                    dt.Rows.Add(dtrow);
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                Log.WriteLog(ex.Message);
                return null;
            }
            return dt;
        }

        /// <summary>
        /// SQL执行方法返回影响行数
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public int SQLExecuteReturnRows(SQLExecuteParam dto)
        {
            SqlConnection connection = new SqlConnection(this.connectString);

            var rows = -1;
            try
            {
                connection.Open();
                if (dto.obj != null)
                {
                    rows = connection.Execute(dto.sql, dto.obj);
                }
                else if (dto.dict.Count > 0)
                {
                    rows = connection.Execute(dto.sql, dto.dict);
                }
                else
                {
                    rows = connection.Execute(dto.sql, null);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                Log.WriteLog(ex.Message);
                return -1;
            }
            return rows;
        }

        /// <summary>
        /// SQL执行方法返回List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dto"></param>
        /// <returns></returns>
        public List<T> SQLExecuteReturnList<T>(SQLExecuteParam dto) where T : new()
        {
            SqlConnection connection = new SqlConnection(this.connectString);
            List<T> list = new List<T>();
            try
            {
                connection.Open();
                if (dto.obj != null)
                {
                    list = connection.Query<T>(dto.sql, dto.obj).ToList();
                }
                else if (dto.dict.Count > 0)
                {
                    list = connection.Query<T>(dto.sql, dto.dict).ToList();
                }
                else
                {
                    list = connection.Query<T>(dto.sql, null).ToList();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                Log.WriteLog(ex.Message);
                return null;
            }
            return list;
        }

        /// <summary>
        /// 执行分页返回List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dto"></param>
        /// <returns></returns>
        public PaginationResult<T> SQLExecuteReturnPaginationList<T>(SQLExecuteParam dto) where T : new()
        {
            const int defaultLimit = 10;
            PaginationResult<T> pResult = new PaginationResult<T>();
            SqlConnection connection = new SqlConnection(this.connectString);
            try
            {
                if (dto.pagination == null)
                {
                    throw new Exception("未初始化分页条件");
                }
                pResult.limit = dto.pagination.limit == 0 ? defaultLimit : dto.pagination.limit;
                pResult.offset = dto.pagination.offset;
                connection.Open();
                string countSql = "SELECT COUNT(*) FROM (" + dto.sql + ") AS countTable";

                if (dto.obj != null)
                {
                    pResult.total = connection.Query<int>(countSql, dto.obj).SingleOrDefault();
                }
                else if (dto.dict.Count > 0)
                {
                    pResult.total = connection.Query<int>(countSql, dto.dict).SingleOrDefault();
                }
                else
                {
                    pResult.total = connection.Query<int>(countSql, null).SingleOrDefault();
                }

                dto.sql = "SELECT * FROM (" + dto.sql + ") AS Pagination WHERE Pagination.rowNo > @offset AND Pagination.rowNo <= @limit + @offset";
                if (dto.obj != null)
                {
                    Dictionary<string, object> objDict = ObjToDict(dto.obj);
                    objDict.Add("limit", dto.pagination.limit);
                    objDict.Add("offset", dto.pagination.offset);
                    pResult.rows = connection.Query<T>(dto.sql, objDict).ToList();
                }
                else if (dto.dict.Count > 0)
                {
                    dto.dict.Add("limit", dto.pagination.limit);
                    dto.dict.Add("offset", dto.pagination.offset);
                    pResult.rows = connection.Query<T>(dto.sql, dto.dict).ToList();
                }
                else
                {
                    pResult.rows = connection.Query<T>(dto.sql, new { limit = dto.pagination.limit, offset = dto.pagination.offset }).ToList();
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                Log.WriteLog(ex.Message);
                return null;
            }
            return pResult;
        }

        /// <summary>
        /// 多条sql执行 无事务
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>主体部分执行成功条数</returns>
        public int MultipleSQLExecuteReturnRows(MultiSQLExecuteParam dto)
        {
            SqlConnection connection = new SqlConnection(this.connectString);

            var beforeRows = -1;
            var afterRows = -1;
            int count = 0;
            try
            {
                connection.Open();
                if (!string.IsNullOrEmpty(dto.beforeSql))
                {
                    //执行before
                    if (dto.beforeObj != null)
                    {
                        beforeRows = connection.Execute(dto.beforeSql, dto.beforeObj);
                    }
                    else if (dto.beforeParam.Count > 0)
                    {
                        beforeRows = connection.Execute(dto.beforeSql, dto.beforeParam);
                    }
                    else
                    {
                        beforeRows = connection.Execute(dto.beforeSql, null);
                    }
                }
                //执行的是存储过程
                //执行主体
                if (!string.IsNullOrEmpty(dto.listSql))
                {
                    if (dto.listSql.IndexOf("EXECUTE") != -1)
                    {
                        foreach (object item in dto.objList)
                        {
                            JRes res = connection.Query<JRes>(dto.listSql, item).SingleOrDefault();
                            if (res.res == 1)
                            {
                                count++;
                            }
                        }
                    }
                    else
                    {
                        foreach (object item in dto.objList)
                        {
                            connection.Execute(dto.listSql, item);
                            count++;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(dto.afterSql))
                {
                    //执行after
                    if (dto.afterObj != null)
                    {
                        afterRows = connection.Execute(dto.afterSql, dto.afterObj);
                    }
                    else if (dto.afterParam.Count > 0)
                    {
                        afterRows = connection.Execute(dto.afterSql, dto.afterParam);
                    }
                    else
                    {
                        afterRows = connection.Execute(dto.afterSql, null);
                    }
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                Log.WriteLog(ex.Message);
                return count;
            }
            return count;

        }

        /// <summary>
        /// 存储过程执行
        /// </summary>
        /// <param name="dto"></param>
        public void SQLExecuteProcedure(SQLExecuteParam dto)
        {
            SqlConnection connection = new SqlConnection(this.connectString);
            connection.Open();

            connection.Execute(dto.sql, dto.procedureParam, null, null, CommandType.StoredProcedure);
            connection.Close();
        }
    }
}