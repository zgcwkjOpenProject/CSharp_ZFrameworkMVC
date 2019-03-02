/*
代码生成器 V 1.9.0.3 zgcwkj
生成时间：2019年03月02日
在使用过程中应当保留原作者相关版权
*/
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

        private string strConnect = new Tools_Config().Inquire("DatabaseConnect");

        #endregion 连接字符串

        #region 查询数据表（DataTable）

        public DataTable QueryDataTable(string sql, SqlParameter[] param)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddRange(param);
                da.Fill(dt);
                conn.Close();
            }
            return dt;
        }

        #endregion 查询数据表（DataTable）

        #region 查询数据表（List）

        public List<Dictionary<string, object>> QueryList(string sql, SqlParameter[] param)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddRange(param);
                da.Fill(dt);
                conn.Close();
            }
            return DtToList(dt);
        }

        #endregion 查询数据表（List）

        #region 插入、更新、删除

        public int UpdateData(string sql, SqlParameter[] param)
        {
            int count = 0;
            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(param);
                count = cmd.ExecuteNonQuery();
                conn.Close();
            }
            return count;
        }

        #endregion 插入、更新、删除

        #region 二进制文件查询方法

        public byte[] QueryDataByte(string sql, SqlParameter[] param)
        {
            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                conn.Open();
                SqlDataReader dr = null;
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(param);
                dr = cmd.ExecuteReader();
                byte[] File = null;
                if (dr.Read())
                {
                    File = (byte[])dr[0];
                }
                dr.Close();
                conn.Close();
                return File;
            }
        }

        #endregion 二进制文件查询方法

        #region DataTable 转换成 List

        public List<Dictionary<string, object>> DtToList(DataTable dt)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            foreach (DataRow dataRow in dt.Rows)
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                foreach (DataColumn dataColumn in dt.Columns)
                {
                    dictionary.Add(dataColumn.ColumnName, dataRow[dataColumn.ColumnName]);
                }
                list.Add(dictionary);
            }
            return list;
        }

        #endregion DataTable 转换成 List

        #region List 转换成 DataTable

        public DataTable ToDataTable(List<Dictionary<string, object>> list)
        {
            DataTable tb = new DataTable();
            if (list.Count>0)
            {
                //==>创建 Table 表头
                foreach (KeyValuePair<string, object> keyValuePair in list[0])
                {
                    tb.Columns.Add(keyValuePair.Key, typeof(string));
                }
                //==>创建 Table 数据
                foreach (Dictionary<string, object> dictionary in list)
                {
                    DataRow dr = tb.NewRow();
                    foreach (KeyValuePair<string, object> keyValuePair in dictionary)
                    {
                        dr[keyValuePair.Key] = keyValuePair.Value;
                    }
                    tb.Rows.Add(dr);
                }
            }
            return tb;
        }

        #endregion List 转换成 DataTable
    }
}