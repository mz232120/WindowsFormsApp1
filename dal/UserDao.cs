using System.Collections.Generic;
using System.Data.SqlClient;
using WindowsFormsApp1.entity;
using WindowsFormsApp1.util;

namespace WindowsFormsApp1.dal
{
    /// <summary>
    /// 用户数据访问类：负责用户的数据库操作
    /// </summary>
    public class UserDao
    {
        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns>用户列表</returns>
        public List<UserInfo> FindAll()
        {
            List<UserInfo> list = new List<UserInfo>();
            string sql = "SELECT * FROM userInfo";
            SqlDataReader reader = DBUtil.ExecuteReader(sql);
            while (reader.Read())
            {
                UserInfo user = new UserInfo();
                user.Id = (int)reader["id"];
                user.Name = reader["name"].ToString();
                user.Pwd = reader["pwd"].ToString();
                user.Status = (int)reader["status"];
                list.Add(user);
            }
            reader.Close();
            return list;
        }

        /// <summary>
        /// 根据关键字查询用户
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <returns>用户列表</returns>
        public List<UserInfo> FindByKeyword(string keyword)
        {
            List<UserInfo> list = new List<UserInfo>();
            string sql = "SELECT * FROM userInfo WHERE name LIKE @keyword OR pwd LIKE @keyword";
            SqlDataReader reader = DBUtil.ExecuteReader(sql, new SqlParameter("@keyword", "%" + keyword + "%"));
            while (reader.Read())
            {
                UserInfo user = new UserInfo();
                user.Id = (int)reader["id"];
                user.Name = reader["name"].ToString();
                user.Pwd = reader["pwd"].ToString();
                user.Status = (int)reader["status"];
                list.Add(user);
            }
            reader.Close();
            return list;
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <returns>受影响的行数</returns>
        public int Add(UserInfo user)
        {
            string sql = "INSERT INTO userInfo (name, pwd, status) VALUES (@name, @pwd, @status)";
            return DBUtil.ExecuteNonQuery(sql,
                new SqlParameter("@name", user.Name),
                new SqlParameter("@pwd", user.Pwd),
                new SqlParameter("@status", user.Status));
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <returns>受影响的行数</returns>
        public int Update(UserInfo user)
        {
            string sql = "UPDATE userInfo SET name=@name, pwd=@pwd, status=@status WHERE id=@id";
            return DBUtil.ExecuteNonQuery(sql,
                new SqlParameter("@name", user.Name),
                new SqlParameter("@pwd", user.Pwd),
                new SqlParameter("@status", user.Status),
                new SqlParameter("@id", user.Id));
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns>受影响的行数</returns>
        public int Delete(int id)
        {
            string sql = "DELETE FROM userInfo WHERE id=@id";
            return DBUtil.ExecuteNonQuery(sql, new SqlParameter("@id", id));
        }

        /// <summary>
        /// 检查用户名是否已存在
        /// </summary>
        /// <param name="name">用户名</param>
        /// <returns>是否存在</returns>
        public bool Exists(string name)
        {
            string sql = "SELECT COUNT(*) FROM userInfo WHERE name=@name";
            int count = (int)DBUtil.ExecuteScalar(sql, new SqlParameter("@name", name));
            return count > 0;
        }

        /// <summary>
        /// 检查用户名是否已存在（排除指定ID）
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="id">排除的ID</param>
        /// <returns>是否存在</returns>
        public bool Exists(string name, int id)
        {
            string sql = "SELECT COUNT(*) FROM userInfo WHERE name=@name AND id<>@id";
            int count = (int)DBUtil.ExecuteScalar(sql,
                new SqlParameter("@name", name),
                new SqlParameter("@id", id));
            return count > 0;
        }

        /// <summary>
        /// 用户登录验证
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns>用户对象，登录失败返回null</returns>
        public UserInfo Login(string name, string pwd)
        {
            string sql = "SELECT * FROM userInfo WHERE name=@name AND pwd=@pwd AND status=1";
            SqlDataReader reader = DBUtil.ExecuteReader(sql,
                new SqlParameter("@name", name),
                new SqlParameter("@pwd", pwd));
            UserInfo user = null;
            if (reader.Read())
            {
                user = new UserInfo();
                user.Id = (int)reader["id"];
                user.Name = reader["name"].ToString();
                user.Pwd = reader["pwd"].ToString();
                user.Status = (int)reader["status"];
            }
            reader.Close();
            return user;
        }
    }
}
