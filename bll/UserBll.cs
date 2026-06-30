using System.Collections.Generic;
using WindowsFormsApp1.dal;
using WindowsFormsApp1.entity;

namespace WindowsFormsApp1.bll
{
    /// <summary>
    /// 用户业务逻辑类：负责用户的业务处理
    /// </summary>
    public class UserBll
    {
        private UserDao userDao = new UserDao();

        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns>用户列表</returns>
        public List<UserInfo> FindAll()
        {
            return userDao.FindAll();
        }

        /// <summary>
        /// 根据关键字查询用户
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <returns>用户列表</returns>
        public List<UserInfo> FindByKeyword(string keyword)
        {
            return userDao.FindByKeyword(keyword);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <returns>是否成功</returns>
        public bool Add(UserInfo user)
        {
            // 检查用户名是否已存在
            if (userDao.Exists(user.Name))
            {
                return false;
            }
            return userDao.Add(user) > 0;
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <returns>是否成功</returns>
        public bool Update(UserInfo user)
        {
            // 检查用户名是否已存在（排除自身）
            if (userDao.Exists(user.Name, user.Id))
            {
                return false;
            }
            return userDao.Update(user) > 0;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="status">用户状态</param>
        /// <returns>是否成功</returns>
        public bool Delete(int id, int status)
        {
            // 正常用户不能删除
            if (status == 1)
            {
                return false;
            }
            return userDao.Delete(id) > 0;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns>用户对象，登录失败返回null</returns>
        public UserInfo Login(string name, string pwd)
        {
            return userDao.Login(name, pwd);
        }
    }
}
