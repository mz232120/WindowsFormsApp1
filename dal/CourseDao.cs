using System.Collections.Generic;
using System.Data.SqlClient;
using WindowsFormsApp1.entity;
using WindowsFormsApp1.util;

namespace WindowsFormsApp1.dal
{
    /// <summary>
    /// 学科数据访问类：负责学科的数据库操作
    /// </summary>
    public class CourseDao
    {
        /// <summary>
        /// 查询所有学科
        /// </summary>
        /// <returns>学科列表</returns>
        public List<CourseInfo> FindAll()
        {
            List<CourseInfo> list = new List<CourseInfo>();
            string sql = "SELECT * FROM courseInfo";
            SqlDataReader reader = DBUtil.ExecuteReader(sql);
            while (reader.Read())
            {
                CourseInfo course = new CourseInfo();
                course.Id = (int)reader["id"];
                course.Name = reader["name"].ToString();
                course.Remark = reader["remark"].ToString();
                list.Add(course);
            }
            reader.Close();
            return list;
        }

        /// <summary>
        /// 根据关键字查询学科
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <returns>学科列表</returns>
        public List<CourseInfo> FindByKeyword(string keyword)
        {
            List<CourseInfo> list = new List<CourseInfo>();
            string sql = "SELECT * FROM courseInfo WHERE name LIKE @keyword OR remark LIKE @keyword";
            SqlDataReader reader = DBUtil.ExecuteReader(sql, new SqlParameter("@keyword", "%" + keyword + "%"));
            while (reader.Read())
            {
                CourseInfo course = new CourseInfo();
                course.Id = (int)reader["id"];
                course.Name = reader["name"].ToString();
                course.Remark = reader["remark"].ToString();
                list.Add(course);
            }
            reader.Close();
            return list;
        }

        /// <summary>
        /// 添加学科
        /// </summary>
        /// <param name="course">学科对象</param>
        /// <returns>受影响的行数</returns>
        public int Add(CourseInfo course)
        {
            string sql = "INSERT INTO courseInfo (name, remark) VALUES (@name, @remark)";
            return DBUtil.ExecuteNonQuery(sql,
                new SqlParameter("@name", course.Name),
                new SqlParameter("@remark", course.Remark));
        }

        /// <summary>
        /// 修改学科
        /// </summary>
        /// <param name="course">学科对象</param>
        /// <returns>受影响的行数</returns>
        public int Update(CourseInfo course)
        {
            string sql = "UPDATE courseInfo SET name=@name, remark=@remark WHERE id=@id";
            return DBUtil.ExecuteNonQuery(sql,
                new SqlParameter("@name", course.Name),
                new SqlParameter("@remark", course.Remark),
                new SqlParameter("@id", course.Id));
        }

        /// <summary>
        /// 删除学科
        /// </summary>
        /// <param name="id">学科ID</param>
        /// <returns>受影响的行数</returns>
        public int Delete(int id)
        {
            string sql = "DELETE FROM courseInfo WHERE id=@id";
            return DBUtil.ExecuteNonQuery(sql, new SqlParameter("@id", id));
        }

        /// <summary>
        /// 检查学科名称是否已存在
        /// </summary>
        /// <param name="name">学科名称</param>
        /// <returns>是否存在</returns>
        public bool Exists(string name)
        {
            string sql = "SELECT COUNT(*) FROM courseInfo WHERE name=@name";
            int count = (int)DBUtil.ExecuteScalar(sql, new SqlParameter("@name", name));
            return count > 0;
        }

        /// <summary>
        /// 检查学科名称是否已存在（排除指定ID）
        /// </summary>
        /// <param name="name">学科名称</param>
        /// <param name="id">排除的ID</param>
        /// <returns>是否存在</returns>
        public bool Exists(string name, int id)
        {
            string sql = "SELECT COUNT(*) FROM courseInfo WHERE name=@name AND id<>@id";
            int count = (int)DBUtil.ExecuteScalar(sql,
                new SqlParameter("@name", name),
                new SqlParameter("@id", id));
            return count > 0;
        }

        /// <summary>
        /// 检查学科是否被成绩表引用
        /// </summary>
        /// <param name="id">学科ID</param>
        /// <returns>是否被引用</returns>
        public bool IsReferenced(int id)
        {
            string sql = "SELECT COUNT(*) FROM scoreInfo WHERE courseId=@id";
            int count = (int)DBUtil.ExecuteScalar(sql, new SqlParameter("@id", id));
            return count > 0;
        }
    }
}
