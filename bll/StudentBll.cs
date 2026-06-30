using System.Collections.Generic;
using WindowsFormsApp1.dal;
using WindowsFormsApp1.entity;

namespace WindowsFormsApp1.bll
{
    /// <summary>
    /// 学员业务逻辑类：负责学员的业务处理
    /// </summary>
    public class StudentBll
    {
        private StudentDao studentDao = new StudentDao();

        /// <summary>
        /// 查询所有学员
        /// </summary>
        /// <returns>学员列表</returns>
        public List<StuInfo> FindAll()
        {
            return studentDao.FindAll();
        }

        /// <summary>
        /// 根据关键字查询学员
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <returns>学员列表</returns>
        public List<StuInfo> FindByKeyword(string keyword)
        {
            return studentDao.FindByKeyword(keyword);
        }

        /// <summary>
        /// 根据ID查询学员
        /// </summary>
        /// <param name="id">学员ID</param>
        /// <returns>学员对象</returns>
        public StuInfo FindById(int id)
        {
            return studentDao.FindById(id);
        }

        /// <summary>
        /// 添加学员
        /// </summary>
        /// <param name="stu">学员对象</param>
        /// <returns>是否成功</returns>
        public bool Add(StuInfo stu)
        {
            return studentDao.Add(stu) > 0;
        }

        /// <summary>
        /// 修改学员
        /// </summary>
        /// <param name="stu">学员对象</param>
        /// <returns>是否成功</returns>
        public bool Update(StuInfo stu)
        {
            return studentDao.Update(stu) > 0;
        }

        /// <summary>
        /// 删除学员
        /// </summary>
        /// <param name="id">学员ID</param>
        /// <returns>是否成功</returns>
        public bool Delete(int id)
        {
            // 检查是否被成绩表引用
            if (studentDao.IsReferenced(id))
            {
                return false;
            }
            return studentDao.Delete(id) > 0;
        }
    }
}
