using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp1.util
{
    /// <summary>
    /// 数据库工具类：提供数据库连接和通用操作方法
    /// </summary>
    public class DBUtil
    {
        // 数据库连接字符串
        public static string connStr = "Data Source=.;Initial Catalog=studentDB;User ID=sa;Password=123456";

        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <returns>SqlConnection对象</returns>
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connStr);
        }

        /// <summary>
        /// 执行增删改操作（INSERT/UPDATE/DELETE）
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            SqlConnection conn = null;
            try
            {
                conn = GetConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (parameters != null && parameters.Length > 0)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                return cmd.ExecuteNonQuery();
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 执行查询，返回SqlDataReader
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>SqlDataReader对象</returns>
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] parameters)
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (parameters != null && parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters);
            }
            // 注意：SqlDataReader需要保持连接打开，调用方负责关闭
            conn.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// 执行查询，返回第一行第一列的值
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>查询结果</returns>
        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            SqlConnection conn = null;
            try
            {
                conn = GetConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (parameters != null && parameters.Length > 0)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                return cmd.ExecuteScalar();
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 执行查询，填充DataTable
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>DataTable对象</returns>
        public static DataTable ExecuteQuery(string sql, params SqlParameter[] parameters)
        {
            SqlConnection conn = null;
            try
            {
                conn = GetConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (parameters != null && parameters.Length > 0)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}
