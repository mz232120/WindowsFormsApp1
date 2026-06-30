namespace WindowsFormsApp1.entity
{
    /// <summary>
    /// 成绩实体类：和DB中的scoreInfo表一一对应
    /// 作用：保存表中一条信息
    /// 当一个表有外键时，那么在类中需要建立外键对应的对象
    /// </summary>
    public class ScoreInfo
    {
        private int stuId;
        private int courseId;
        private int score;
        private string remark;
        // 外键
        private StuInfo stuInfo;
        private CourseInfo courseInfo;

        public int StuId { get => stuId; set => stuId = value; }
        public int CourseId { get => courseId; set => courseId = value; }
        public int Score { get => score; set => score = value; }
        public string Remark { get => remark; set => remark = value; }
        public StuInfo StuInfo { get => stuInfo; set => stuInfo = value; }
        public CourseInfo CourseInfo { get => courseInfo; set => courseInfo = value; }
    }
}
