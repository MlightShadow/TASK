using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace TaskWeb.Utils
{
    /// <summary>
    /// 执行sql的参数及sql文组合传值到Dapper执行 参数执行顺序为实体类obj > dict obj为null, dict.count = 0 视为无参
    /// </summary>
    public class SQLExecuteParam
    {
        /// <summary>
        /// 实体参数
        /// </summary>
        public object obj = null;

        /// <summary>
        /// 参数
        /// </summary>
        public Dictionary<string, object> dict = new Dictionary<string, object>();

        /// <summary>
        /// sql文
        /// </summary>
        public string sql { get; set; }

        /// <summary>
        /// 批量插入事务执行对象list
        /// </summary>
        public List<object> tranList = new List<object>();

        /// <summary>
        /// 分页信息
        /// </summary>
        public PaginationInfo pagination = null;

        /// <summary>
        /// sql执行完成执行
        /// </summary>
        public string afterSql { get; set; }

        public Dictionary<string, object> afterParam = new Dictionary<string, object>();
    }

    /// <summary>
    /// 分页信息
    /// </summary>
    public class PaginationInfo
    {

        /// <summary>
        /// 每页条数
        /// </summary>
        public int limit { set; get; }

        /// <summary>
        /// 页数
        /// </summary>
        public int offset { set; get; }
    }

    /// <summary>
    /// 分页返回类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PaginationResult<T> : PaginationInfo
    {
        /// <summary>
        /// 总页数
        /// </summary>
        public int page { get { return (this.total / this.limit) + this.total % this.limit != 0 ? 1 : 0; } }

        /// <summary>
        /// 总条数
        /// </summary>
        public int total { set; get; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public List<T> rows = null;
    }

    /// <summary>
    /// dapper共通操作
    /// </summary>
    public class DapperCommDAL
    {
        /// <summary>
        /// 默认连接字符串
        /// </summary>
        private string connectString = ConfigurationManager.ConnectionStrings["mysqlconnectionString"].ConnectionString;

        /// <summary>
        /// 默认连接初始化
        /// </summary>
        //public DapperCommDAL()
        //{
        //    this.connectString = connString;
        //}

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
            MySqlConnection connection = new MySqlConnection(this.connectString);
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
            MySqlConnection connection = new MySqlConnection(this.connectString);
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
            DataTable dt = new DataTable();
            MySqlConnection connection = new MySqlConnection(this.connectString);

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
            MySqlConnection connection = new MySqlConnection(this.connectString);
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
        /// 执行分页返回List 该方法**不支持**实体类参数赋值给obj
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dto"></param>
        /// <returns></returns>
        public PaginationResult<T> SQLExecuteReturnPaginationList<T>(SQLExecuteParam dto) where T : new()
        {
            const int defaultLimit = 10;
            PaginationResult<T> pResult = new PaginationResult<T>();
            MySqlConnection connection = new MySqlConnection(this.connectString);
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

                if (dto.dict.Count > 0)
                {
                    pResult.total = connection.Query<int>(countSql, dto.dict).SingleOrDefault();
                }
                else
                {
                    pResult.total = connection.Query<int>(countSql, null).SingleOrDefault();
                }

                dto.sql = "SELECT * FROM (" + dto.sql + ") AS Pagination WHERE Pagination.rowNo > @offset AND Pagination.rowNo <= @limit + @offset";

                if (dto.dict.Count > 0)
                {
                    dto.dict.Add("limit", dto.pagination.limit);
                    dto.dict.Add("offset", dto.pagination.offset);
                    pResult.rows = connection.Query<T>(dto.sql, dto.dict).ToList();
                }
                else
                {
                    dto.dict.Add("limit", dto.pagination.limit);
                    dto.dict.Add("offset", dto.pagination.offset);
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
        /// 以dt作为参数执行sql
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool SQLExecuteWithTransaction(SQLExecuteParam dto)
        {
            bool flag = false;
            int count = 0;

            MySqlConnection connection = new MySqlConnection(this.connectString);
            connection.Open();
            IDbTransaction transaction = connection.BeginTransaction();
            try
            {
                foreach (object item in dto.tranList)
                {
                    if (connection.Execute(dto.sql, item, transaction) == 1)
                    {
                        count++;
                    }
                }
                if (count == dto.tranList.Count)
                {
                    if (dto.afterSql != null && dto.afterSql != "")
                    {
                        connection.Execute(dto.afterSql, dto.afterParam, transaction);
                    }
                    transaction.Commit();
                    flag = true;
                }
                else
                {
                    transaction.Rollback();
                    flag = false;
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
                Log.WriteLog(ex.Message);
                return flag;
            }
            return flag;
        }
    }
}