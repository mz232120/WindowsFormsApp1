using System.Collections.Generic;
using System.Data.SqlClient;
using WindowsFormsApp1.entity;
using WindowsFormsApp1.util;

namespace WindowsFormsApp1.dal
{
    /// <summary>
    /// 成绩数据访问类：负责成绩的数据库操作
    /// </summary>
    public class ScoreDao
    {
        /// <summary>
        /// 查询所有成绩（带学生和学科信息）
        /// </summary>
        /// <returns>成绩列表</returns>
        public List<ScoreInfo> FindAll()
        {
            List<ScoreInfo> list = new List<ScoreInfo>();
            string sql = @"SELECT s.*, stu.name as stuName, c.name as courseName
                          FROM scoreInfo s
                          LEFT JOIN stuInfo stu ON s.stuId = stu.id
                          LEFT JOIN courseInfo c ON s.courseId = c.id";
            SqlDataReader reader = DBUtil.ExecuteReader(sql);
            while (reader.Read())
            {
                ScoreInfo score = new ScoreInfo();
                score.StuId = (int)reader["stuId"];
                score.CourseId = (int)reader["courseId"];
                score.Score = (int)reader["score"];
                score.Remark = reader["remark"].ToString();

                // 创建关联对象
                score.StuInfo = new StuInfo();
                score.StuInfo.Id = score.StuId;
                score.StuInfo.Name = reader["stuName"].ToString();

                score.CourseInfo = new CourseInfo();
                score.CourseInfo.Id = score.CourseId;
                score.CourseInfo.Name = reader["courseName"].ToString();

                list.Add(score);
            }
            reader.Close();
            return list;
        }

        /// <summary>
        /// 根据学员ID查询成绩
        /// </summary>
        /// <param name="stuId">学员ID</param>
        /// <returns>成绩列表</returns>
        public List<ScoreInfo> FindByStuId(int stuId)
        {
            List<ScoreInfo> list = new List<ScoreInfo>();
            string sql = @"SELECT s.*, stu.name as stuName, c.name as courseName
                          FROM scoreInfo s
                          LEFT JOIN stuInfo stu ON s.stuId = stu.id
                          LEFT JOIN courseInfo c ON s.courseId = c.id
                          WHERE s.stuId=@stuId";
            SqlDataReader reader = DBUtil.ExecuteReader(sql, new SqlParameter("@stuId", stuId));
            while (reader.Read())
            {
                ScoreInfo score = new ScoreInfo();
                score.StuId = (int)reader["stuId"];
                score.CourseId = (int)reader["courseId"];
                score.Score = (int)reader["score"];
                score.Remark = reader["remark"].ToString();

                score.StuInfo = new StuInfo();
                score.StuInfo.Id = score.StuId;
                score.StuInfo.Name = reader["stuName"].ToString();

                score.CourseInfo = new CourseInfo();
                score.CourseInfo.Id = score.CourseId;
                score.CourseInfo.Name = reader["courseName"].ToString();

                list.Add(score);
            }
            reader.Close();
            return list;
        }

        /// <summary>
        /// 添加成绩
        /// </summary>
        /// <param name="score">成绩对象</param>
        /// <returns>受影响的行数</returns>
        public int Add(ScoreInfo score)
        {
            string sql = "INSERT INTO scoreInfo (stuId, courseId, score, remark) VALUES (@stuId, @courseId, @score, @remark)";
            return DBUtil.ExecuteNonQuery(sql,
                new SqlParameter("@stuId", score.StuId),
                new SqlParameter("@courseId", score.CourseId),
                new SqlParameter("@score", score.Score),
                new SqlParameter("@remark", score.Remark));
        }

        /// <summary>
        /// 修改成绩
        /// </summary>
        /// <param name="score">成绩对象</param>
        /// <returns>受影响的行数</returns>
        public int Update(ScoreInfo score)
        {
            string sql = "UPDATE scoreInfo SET score=@score, remark=@remark WHERE stuId=@stuId AND courseId=@courseId";
            return DBUtil.ExecuteNonQuery(sql,
                new SqlParameter("@score", score.Score),
                new SqlParameter("@remark", score.Remark),
                new SqlParameter("@stuId", score.StuId),
                new SqlParameter("@courseId", score.CourseId));
        }

        /// <summary>
        /// 删除成绩
        /// </summary>
        /// <param name="stuId">学员ID</param>
        /// <param name="courseId">学科ID</param>
        /// <returns>受影响的行数</returns>
        public int Delete(int stuId, int courseId)
        {
            string sql = "DELETE FROM scoreInfo WHERE stuId=@stuId AND courseId=@courseId";
            return DBUtil.ExecuteNonQuery(sql,
                new SqlParameter("@stuId", stuId),
                new SqlParameter("@courseId", courseId));
        }

        /// <summary>
        /// 检查成绩是否存在
        /// </summary>
        /// <param name="stuId">学员ID</param>
        /// <param name="courseId">学科ID</param>
        /// <returns>是否存在</returns>
        public bool Exists(int stuId, int courseId)
        {
            string sql = "SELECT COUNT(*) FROM scoreInfo WHERE stuId=@stuId AND courseId=@courseId";
            int count = (int)DBUtil.ExecuteScalar(sql,
                new SqlParameter("@stuId", stuId),
                new SqlParameter("@courseId", courseId));
            return count > 0;
        }

        /// <summary>
        /// 查询所有学员
        /// </summary>
        /// <returns>学员列表</returns>
        public List<StuInfo> FindAllStudents()
        {
            List<StuInfo> list = new List<StuInfo>();
            string sql = "SELECT id, name FROM stuInfo";
            SqlDataReader reader = DBUtil.ExecuteReader(sql);
            while (reader.Read())
            {
                StuInfo stu = new StuInfo();
                stu.Id = (int)reader["id"];
                stu.Name = reader["name"].ToString();
                list.Add(stu);
            }
            reader.Close();
            return list;
        }

        /// <summary>
        /// 查询所有学科
        /// </summary>
        /// <returns>学科列表</returns>
        public List<CourseInfo> FindAllCourses()
        {
            List<CourseInfo> list = new List<CourseInfo>();
            string sql = "SELECT id, name FROM courseInfo";
            SqlDataReader reader = DBUtil.ExecuteReader(sql);
            while (reader.Read())
            {
                CourseInfo course = new CourseInfo();
                course.Id = (int)reader["id"];
                course.Name = reader["name"].ToString();
                list.Add(course);
            }
            reader.Close();
            return list;
        }
    }
}
