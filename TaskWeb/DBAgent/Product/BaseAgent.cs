using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;

using Dapper;

using DBAgent.Entity;
using DBAgent.Adapter;

namespace DBAgent.Product
{
    internal class BaseAgent
    {
        protected UtilFactory utils = new UtilFactory();
        protected IDbConnection connection = null;
        protected string connStr = null;

        protected void InitAgent(string connStr)
        {
            this.connStr = connStr;
        }

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

        public bool TestConnect()
        {
            try
            {
                connection.Open();
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                utils.GetLogUtil().WriteLog(ex.Message);
                return false;
            }
            return true;
        }


        public T SQLExecuteSingleData<T>(SQLExecuteParam dto) where T : new()
        {
            T t = default(T);
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
                utils.GetLogUtil().WriteLog(ex.Message);
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
                utils.GetLogUtil().WriteLog(ex.Message);
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
                utils.GetLogUtil().WriteLog(ex.Message);
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
                utils.GetLogUtil().WriteLog(ex.Message);
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
                utils.GetLogUtil().WriteLog(ex.Message);
                return null;
            }
            return pResult;
        }
    }
}
