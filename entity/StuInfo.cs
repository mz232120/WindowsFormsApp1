using System;

namespace WindowsFormsApp1.entity
{
    /// <summary>
    /// 学员实体类：和DB中的stuInfo表一一对应
    /// 作用：保存表中一条信息（一个学员-->一个对象）
    /// </summary>
    public class StuInfo
    {
        private int id;
        private string name;
        private string gender;
        private DateTime birth;
        private string photo;
        private string remark;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Gender { get => gender; set => gender = value; }
        public DateTime Birth { get => birth; set => birth = value; }
        public string Photo { get => photo; set => photo = value; }
        public string Remark { get => remark; set => remark = value; }
    }
}
