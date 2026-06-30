namespace WindowsFormsApp1.entity
{
    /// <summary>
    /// 学科实体类：和DB中的courseInfo表一一对应
    /// 作用：保存表中一条信息（一个科目-->一个对象）
    /// </summary>
    public class CourseInfo
    {
        private int id;
        private string name;
        private string remark;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Remark { get => remark; set => remark = value; }
    }
}
