using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WindowsFormsApp1.entity;
using WindowsFormsApp1.util;

namespace WindowsFormsApp1.dal
{
    /// <summary>
    /// 学员数据访问类：负责学员的数据库操作
    /// </summary>
    public class StudentDao
    {
        /// <summary>
        /// 查询所有学员
        /// </summary>
        /// <returns>学员列表</returns>
        public List<StuInfo> FindAll()
        {
            List<StuInfo> list = new List<StuInfo>();
            string sql = "SELECT * FROM stuInfo";
            SqlDataReader reader = DBUtil.ExecuteReader(sql);
            while (reader.Read())
            {
                StuInfo stu = new StuInfo();
                stu.Id = (int)reader["id"];
                stu.Name = reader["name"].ToString();
                stu.Gender = reader["gender"].ToString();
                stu.Birth = (DateTime)reader["birth"];
                stu.Photo = reader["photo"].ToString();
                stu.Remark = reader["remark"].ToString();
                list.Add(stu);
            }
            reader.Close();
            return list;
        }

        /// <summary>
        /// 根据关键字查询学员
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <returns>学员列表</returns>
        public List<StuInfo> FindByKeyword(string keyword)
        {
            List<StuInfo> list = new List<StuInfo>();
            string sql = "SELECT * FROM stuInfo WHERE name LIKE @keyword OR remark LIKE @keyword";
            SqlDataReader reader = DBUtil.ExecuteReader(sql, new SqlParameter("@keyword", "%" + keyword + "%"));
            while (reader.Read())
            {
                StuInfo stu = new StuInfo();
                stu.Id = (int)reader["id"];
                stu.Name = reader["name"].ToString();
                stu.Gender = reader["gender"].ToString();
                stu.Birth = (DateTime)reader["birth"];
                stu.Photo = reader["photo"].ToString();
                stu.Remark = reader["remark"].ToString();
                list.Add(stu);
            }
            reader.Close();
            return list;
        }

        /// <summary>
        /// 根据ID查询学员
        /// </summary>
        /// <param name="id">学员ID</param>
        /// <returns>学员对象</returns>
        public StuInfo FindById(int id)
        {
            string sql = "SELECT * FROM stuInfo WHERE id=@id";
            SqlDataReader reader = DBUtil.ExecuteReader(sql, new SqlParameter("@id", id));
            StuInfo stu = null;
            if (reader.Read())
            {
                stu = new StuInfo();
                stu.Id = (int)reader["id"];
                stu.Name = reader["name"].ToString();
                stu.Gender = reader["gender"].ToString();
                stu.Birth = (DateTime)reader["birth"];
                stu.Photo = reader["photo"].ToString();
                stu.Remark = reader["remark"].ToString();
            }
            reader.Close();
            return stu;
        }

        /// <summary>
        /// 添加学员
        /// </summary>
        /// <param name="stu">学员对象</param>
        /// <returns>受影响的行数</returns>
        public int Add(StuInfo stu)
        {
            string sql = "INSERT INTO stuInfo (name, gender, birth, photo, remark) VALUES (@name, @gender, @birth, @photo, @remark)";
            return DBUtil.ExecuteNonQuery(sql,
                new SqlParameter("@name", stu.Name),
                new SqlParameter("@gender", stu.Gender),
                new SqlParameter("@birth", stu.Birth),
                new SqlParameter("@photo", stu.Photo),
                new SqlParameter("@remark", stu.Remark));
        }

        /// <summary>
        /// 修改学员
        /// </summary>
        /// <param name="stu">学员对象</param>
        /// <returns>受影响的行数</returns>
        public int Update(StuInfo stu)
        {
            string sql = "UPDATE stuInfo SET name=@name, gender=@gender, birth=@birth, photo=@photo, remark=@remark WHERE id=@id";
            return DBUtil.ExecuteNonQuery(sql,
                new SqlParameter("@name", stu.Name),
                new SqlParameter("@gender", stu.Gender),
                new SqlParameter("@birth", stu.Birth),
                new SqlParameter("@photo", stu.Photo),
                new SqlParameter("@remark", stu.Remark),
                new SqlParameter("@id", stu.Id));
        }

        /// <summary>
        /// 删除学员
        /// </summary>
        /// <param name="id">学员ID</param>
        /// <returns>受影响的行数</returns>
        public int Delete(int id)
        {
            string sql = "DELETE FROM stuInfo WHERE id=@id";
            return DBUtil.ExecuteNonQuery(sql, new SqlParameter("@id", id));
        }

        /// <summary>
        /// 检查学员是否被成绩表引用
        /// </summary>
        /// <param name="id">学员ID</param>
        /// <returns>是否被引用</returns>
        public bool IsReferenced(int id)
        {
            string sql = "SELECT COUNT(*) FROM scoreInfo WHERE stuId=@id";
            int count = (int)DBUtil.ExecuteScalar(sql, new SqlParameter("@id", id));
            return count > 0;
        }
    }
}
