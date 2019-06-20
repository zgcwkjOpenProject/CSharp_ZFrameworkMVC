using System;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace ZFramework.Common
{
    public class Tools_DAL
    {
        #region 连接字符串

        //private readonly string strConnect = @"Data Source=(local);Initial Catalog=ZFramework;User ID=sa;Password=123;";
        //
        //Trusted_Connection=yes;可信连接(Windows身份登录)
        //把连接字符串放到 Web.config 中
        //在<appSettings></appSettings>标签内添加
        //<add key="DatabaseConnect" value="Data Source=(local);Initial Catalog=ZFramework;User ID=sa;Password=123" />
        //把上面的 strConnect 注释掉，取消下面的注释即可
        private readonly string strConnect = new Tools_Config().Inquire("DatabaseConnect");

        #endregion 连接字符串

        #region 查询数据表（DataTable）

        /// <summary>
        /// 查询数据表（存储过程）
        /// </summary>
        /// <param name="storedProcedureName">存储过程名称</param>
        /// <param name="sqlParameter">SQL参数</param>
        /// <returns>DataTable</returns>
        public DataTable QueryDataTable(string storedProcedureName, params SqlParameter[] sqlParameter)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(strConnect))
            {
                try
                {
                    sqlConnection.Open();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(storedProcedureName, sqlConnection);
                    sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sqlDataAdapter.SelectCommand.Parameters.AddRange(sqlParameter);
                    sqlDataAdapter.Fill(dataTable);
                }
                catch (Exception e)
                {
                    string message = e.Message;
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            return dataTable;
        }

        #endregion 查询数据表（DataTable）

        #region 查询数据表（List）

        /// <summary>
        /// 查询数据表（存储过程）
        /// </summary>
        /// <param name="storedProcedureName">存储过程名称</param>
        /// <param name="sqlParameter">SQL参数</param>
        /// <returns>List</returns>
        public List<Dictionary<string, object>> QueryList(string storedProcedureName, params SqlParameter[] sqlParameter)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(strConnect))
            {
                try
                {
                    sqlConnection.Open();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(storedProcedureName, sqlConnection);
                    sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sqlDataAdapter.SelectCommand.Parameters.AddRange(sqlParameter);
                    sqlDataAdapter.Fill(dataTable);
                }
                catch (Exception e)
                {
                    string message = e.Message;
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            return ToList(dataTable);
        }

        #endregion 查询数据表（List）

        #region 插入、更新、删除

        /// <summary>
        /// 插入、更新、删除（存储过程）
        /// </summary>
        /// <param name="storedProcedureName">存储过程名称</param>
        /// <param name="sqlParameter">SQL参数</param>
        /// <returns>变化的条数</returns>
        public int UpdateData(string storedProcedureName, params SqlParameter[] sqlParameter)
        {
            int count = 0;
            using (SqlConnection sqlConnection = new SqlConnection(strConnect))
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand(storedProcedureName, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddRange(sqlParameter);
                    count = sqlCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    string message = e.Message;
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            return count;
        }

        #endregion 插入、更新、删除

        #region 执行SQL语句数据表（DataTable）

        /// <summary>
        /// 查询数据表（存储语句）
        /// </summary>
        /// <param name="sqlStatement">SQL语句</param>
        /// <param name="sqlParameter">SQL参数</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteSqlStatementToDataTable(string sqlStatement, params SqlParameter[] sqlParameter)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(strConnect))
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand(sqlStatement, sqlConnection);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlCommand.Parameters.AddRange(sqlParameter);
                    sqlDataAdapter.Fill(dataTable);
                }
                catch (Exception e)
                {
                    string message = e.Message;
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            return dataTable;
        }

        #endregion 执行SQL语句数据表（DataTable）

        #region 执行SQL语句数据表（List）

        /// <summary>
        /// 查询数据表（存储语句）
        /// </summary>
        /// <param name="sqlStatement">SQL语句</param>
        /// <param name="sqlParameter">SQL参数</param>
        /// <returns>List</returns>
        public List<Dictionary<string, object>> ExecuteSqlStatementToList(string sqlStatement, params SqlParameter[] sqlParameter)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(strConnect))
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand(sqlStatement, sqlConnection);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlCommand.Parameters.AddRange(sqlParameter);
                    sqlDataAdapter.Fill(dataTable);
                }
                catch (Exception e)
                {
                    string message = e.Message;
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            return ToList(dataTable);
        }

        #endregion 执行SQL语句数据表（List）

        #region 插入、更新、删除

        /// <summary>
        /// 插入、更新、删除（存储语句）
        /// </summary>
        /// <param name="sqlStatement">SQL语句</param>
        /// <param name="sqlParameter">SQL参数</param>
        /// <returns>变化的条数</returns>
        public int ExecuteSqlStatementUpdateData(string sqlStatement, params SqlParameter[] sqlParameter)
        {
            int count = 0;
            using (SqlConnection sqlConnection = new SqlConnection(strConnect))
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand(sqlStatement, sqlConnection);
                    sqlCommand.Parameters.AddRange(sqlParameter);
                    count = sqlCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    string message = e.Message;
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            return count;
        }

        #endregion 插入、更新、删除

        #region 二进制文件查询方法

        /// <summary>
        /// 二进制文件查询方法
        /// </summary>
        /// <param name="storedProcedureName">存储过程名称</param>
        /// <param name="sqlParameter">SQL参数</param>
        /// <returns>二进制</returns>
        public byte[] QueryDataByte(string storedProcedureName, params SqlParameter[] sqlParameter)
        {
            byte[] File = null;
            using (SqlConnection sqlConnection = new SqlConnection(strConnect))
            {
                try
                {
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = null;
                    SqlCommand sqlCommand = new SqlCommand(storedProcedureName, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddRange(sqlParameter);
                    sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        File = (byte[])sqlDataReader[0];
                    }
                    sqlDataReader.Close();
                }
                catch (Exception e)
                {
                    string message = e.Message;
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
                return File;
            }
        }

        #endregion 二进制文件查询方法

        #region DataTable 转换成 List

        /// <summary>
        /// DataTable 转换成 List
        /// </summary>
        /// <param name="dataTable">需要转换的 DataTable</param>
        /// <returns>转换后的 List</returns>
        public List<Dictionary<string, object>> ToList(DataTable dataTable)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                foreach (DataColumn dataColumn in dataTable.Columns)
                {
                    dictionary.Add(dataColumn.ColumnName, dataRow[dataColumn.ColumnName]);
                }
                list.Add(dictionary);
            }
            return list;
        }

        #endregion DataTable 转换成 List

        #region List 转换成 DataTable

        /// <summary>
        /// List 转换成 DataTable
        /// </summary>
        /// <param name="list">需要转换的 List</param>
        /// <returns>转换后的 DataTable</returns>
        public DataTable ToDataTable(List<Dictionary<string, object>> list)
        {
            DataTable dataTable = new DataTable();
            if (list.Count > 0)
            {
                //==>创建 Table 表头
                foreach (KeyValuePair<string, object> keyValuePair in list[0])
                {
                    dataTable.Columns.Add(keyValuePair.Key, typeof(string));
                }
                //==>创建 Table 数据
                foreach (Dictionary<string, object> dictionary in list)
                {
                    DataRow dr = dataTable.NewRow();
                    foreach (KeyValuePair<string, object> keyValuePair in dictionary)
                    {
                        dr[keyValuePair.Key] = keyValuePair.Value;
                    }
                    dataTable.Rows.Add(dr);
                }
            }
            return dataTable;
        }

        #endregion List 转换成 DataTable
    }
}