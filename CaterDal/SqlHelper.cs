using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CaterDal
{
   public static  class SqlHelper
    {
        public static readonly string GetsqlTextConnectionString =
           ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;

        /// <summary>
        /// 返回受影响的行数
        /// </summary>
        /// <param name="sqlText"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sqlText, params SqlParameter[] paras)
        {
            using (SqlConnection conn = new SqlConnection(GetsqlTextConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlText, conn);
                cmd.Parameters.AddRange(paras);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 获取首行首列值的方法
        /// </summary>
        public static T ExecuteScalar<T>(string sqlText, params SqlParameter[] paras)
        {
            using (SqlConnection conn = new SqlConnection(GetsqlTextConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlText, conn);
                cmd.Parameters.AddRange(paras);
                conn.Open();
                return (T)cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// //获取结果集
        /// </summary>
        public static DataTable GetDataTable(string sqlText, params SqlParameter[] paras)
        {
            using (SqlConnection conn = new SqlConnection(GetsqlTextConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sqlText, conn);
                DataTable table = new DataTable();
                adapter.SelectCommand.Parameters.AddRange(paras);
                adapter.Fill(table);
                return table;
            }
        }
    }
}
