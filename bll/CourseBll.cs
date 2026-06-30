using System.Collections.Generic;
using WindowsFormsApp1.dal;
using WindowsFormsApp1.entity;

namespace WindowsFormsApp1.bll
{
    /// <summary>
    /// 学科业务逻辑类：负责学科的业务处理
    /// </summary>
    public class CourseBll
    {
        private CourseDao courseDao = new CourseDao();

        /// <summary>
        /// 查询所有学科
        /// </summary>
        /// <returns>学科列表</returns>
        public List<CourseInfo> FindAll()
        {
            return courseDao.FindAll();
        }

        /// <summary>
        /// 根据关键字查询学科
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <returns>学科列表</returns>
        public List<CourseInfo> FindByKeyword(string keyword)
        {
            return courseDao.FindByKeyword(keyword);
        }

        /// <summary>
        /// 添加学科
        /// </summary>
        /// <param name="course">学科对象</param>
        /// <returns>是否成功</returns>
        public bool Add(CourseInfo course)
        {
            // 检查学科名称是否已存在
            if (courseDao.Exists(course.Name))
            {
                return false;
            }
            return courseDao.Add(course) > 0;
        }

        /// <summary>
        /// 修改学科
        /// </summary>
        /// <param name="course">学科对象</param>
        /// <returns>是否成功</returns>
        public bool Update(CourseInfo course)
        {
            // 检查学科名称是否已存在（排除自身）
            if (courseDao.Exists(course.Name, course.Id))
            {
                return false;
            }
            return courseDao.Update(course) > 0;
        }

        /// <summary>
        /// 删除学科
        /// </summary>
        /// <param name="id">学科ID</param>
        /// <returns>是否成功</returns>
        public bool Delete(int id)
        {
            // 检查是否被成绩表引用
            if (courseDao.IsReferenced(id))
            {
                return false;
            }
            return courseDao.Delete(id) > 0;
        }
    }
}
