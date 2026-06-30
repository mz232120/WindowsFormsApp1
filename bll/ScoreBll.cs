using System.Collections.Generic;
using WindowsFormsApp1.dal;
using WindowsFormsApp1.entity;

namespace WindowsFormsApp1.bll
{
    /// <summary>
    /// 成绩业务逻辑类：负责成绩的业务处理
    /// </summary>
    public class ScoreBll
    {
        private ScoreDao scoreDao = new ScoreDao();

        /// <summary>
        /// 查询所有成绩
        /// </summary>
        /// <returns>成绩列表</returns>
        public List<ScoreInfo> FindAll()
        {
            return scoreDao.FindAll();
        }

        /// <summary>
        /// 根据学员ID查询成绩
        /// </summary>
        /// <param name="stuId">学员ID</param>
        /// <returns>成绩列表</returns>
        public List<ScoreInfo> FindByStuId(int stuId)
        {
            return scoreDao.FindByStuId(stuId);
        }

        /// <summary>
        /// 添加成绩
        /// </summary>
        /// <param name="score">成绩对象</param>
        /// <returns>是否成功</returns>
        public bool Add(ScoreInfo score)
        {
            // 检查成绩是否已存在
            if (scoreDao.Exists(score.StuId, score.CourseId))
            {
                return false;
            }
            return scoreDao.Add(score) > 0;
        }

        /// <summary>
        /// 修改成绩
        /// </summary>
        /// <param name="score">成绩对象</param>
        /// <returns>是否成功</returns>
        public bool Update(ScoreInfo score)
        {
            return scoreDao.Update(score) > 0;
        }

        /// <summary>
        /// 删除成绩
        /// </summary>
        /// <param name="stuId">学员ID</param>
        /// <param name="courseId">学科ID</param>
        /// <returns>是否成功</returns>
        public bool Delete(int stuId, int courseId)
        {
            return scoreDao.Delete(stuId, courseId) > 0;
        }

        /// <summary>
        /// 查询所有学员（用于下拉框）
        /// </summary>
        /// <returns>学员列表</returns>
        public List<StuInfo> FindAllStudents()
        {
            return scoreDao.FindAllStudents();
        }

        /// <summary>
        /// 查询所有学科（用于下拉框）
        /// </summary>
        /// <returns>学科列表</returns>
        public List<CourseInfo> FindAllCourses()
        {
            return scoreDao.FindAllCourses();
        }
    }
}
