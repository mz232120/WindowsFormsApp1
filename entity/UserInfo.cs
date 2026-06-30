namespace WindowsFormsApp1.entity
{
    /// <summary>
    /// 用户实体类：和DB中的userInfo表一一对应
    /// 作用：保存表中一条信息
    /// </summary>
    public class UserInfo
    {
        private int id;
        private string name;
        private string pwd;
        private int status;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Pwd { get => pwd; set => pwd = value; }
        public int Status { get => status; set => status = value; }
    }
}
