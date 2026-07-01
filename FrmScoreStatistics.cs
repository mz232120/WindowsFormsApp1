using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.bll;
using WindowsFormsApp1.entity;

namespace WindowsFormsApp1
{
    /// <summary>
    /// 成绩统计窗体：按学员统计、按科目统计、总体统计
    /// </summary>
    public partial class FrmScoreStatistics : Form
    {
        private ScoreBll scoreBll = new ScoreBll();
        private List<ScoreInfo> allScores = new List<ScoreInfo>();

        public FrmScoreStatistics()
        {
            InitializeComponent();
        }

        private void FrmScoreStatistics_Load(object sender, EventArgs e)
        {
            try
            {
                allScores = scoreBll.FindAll();
                // 默认选中"按学员统计"
                radByStudent.Checked = true;
                BindStudentStats();
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载数据失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 单选按钮切换事件
        /// </summary>
        private void rad_CheckedChanged(object sender, EventArgs e)
        {
            if (!((RadioButton)sender).Checked) return;

            if (radByStudent.Checked)
            {
                BindStudentStats();
            }
            else if (radByCourse.Checked)
            {
                BindCourseStats();
            }
            else if (radOverall.Checked)
            {
                BindOverallStats();
            }
        }

        /// <summary>
        /// 按学员统计：每个学员的平均分、最高分、最低分、科目数、总分
        /// </summary>
        private void BindStudentStats()
        {
            if (allScores.Count == 0)
            {
                dgStats.DataSource = null;
                lblSummary.Text = "暂无成绩数据";
                return;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("学员ID", typeof(int));
            dt.Columns.Add("学员姓名", typeof(string));
            dt.Columns.Add("科目数", typeof(int));
            dt.Columns.Add("总分", typeof(int));
            dt.Columns.Add("平均分", typeof(double));
            dt.Columns.Add("最高分", typeof(int));
            dt.Columns.Add("最低分", typeof(int));

            var groups = allScores.GroupBy(s => s.StuId);
            foreach (var g in groups)
            {
                string stuName = g.First().StuInfo?.Name ?? g.Key.ToString();
                int count = g.Count();
                int total = g.Sum(s => s.Score);
                double avg = Math.Round((double)total / count, 1);
                int max = g.Max(s => s.Score);
                int min = g.Min(s => s.Score);
                dt.Rows.Add(g.Key, stuName, count, total, avg, max, min);
            }

            dgStats.DataSource = dt;
            SetColumnWidths();

            int stuCount = groups.Count();
            double overallAvg = Math.Round(allScores.Average(s => s.Score), 1);
            int passCount = allScores.Count(s => s.Score >= 60);
            double passRate = Math.Round((double)passCount / allScores.Count * 100, 1);
            lblSummary.Text = $"共 {stuCount} 名学员 · {allScores.Count} 条成绩记录 · 总平均分 {overallAvg} · 及格率 {passRate}%";
        }

        /// <summary>
        /// 按科目统计：每个科目的平均分、最高分、最低分、学员数
        /// </summary>
        private void BindCourseStats()
        {
            if (allScores.Count == 0)
            {
                dgStats.DataSource = null;
                lblSummary.Text = "暂无成绩数据";
                return;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("科目ID", typeof(int));
            dt.Columns.Add("科目名称", typeof(string));
            dt.Columns.Add("学员数", typeof(int));
            dt.Columns.Add("总分", typeof(int));
            dt.Columns.Add("平均分", typeof(double));
            dt.Columns.Add("最高分", typeof(int));
            dt.Columns.Add("最低分", typeof(int));
            dt.Columns.Add("及格人数", typeof(int));
            dt.Columns.Add("及格率", typeof(string));

            var groups = allScores.GroupBy(s => s.CourseId);
            foreach (var g in groups)
            {
                string courseName = g.First().CourseInfo?.Name ?? g.Key.ToString();
                int count = g.Count();
                int total = g.Sum(s => s.Score);
                double avg = Math.Round((double)total / count, 1);
                int max = g.Max(s => s.Score);
                int min = g.Min(s => s.Score);
                int passCount = g.Count(s => s.Score >= 60);
                string passRate = Math.Round((double)passCount / count * 100, 1) + "%";
                dt.Rows.Add(g.Key, courseName, count, total, avg, max, min, passCount, passRate);
            }

            dgStats.DataSource = dt;
            SetColumnWidths();

            int courseCount = groups.Count();
            double overallAvg = Math.Round(allScores.Average(s => s.Score), 1);
            lblSummary.Text = $"共 {courseCount} 个科目 · {allScores.Count} 条成绩记录 · 总平均分 {overallAvg}";
        }

        /// <summary>
        /// 总体统计：汇总数据展示
        /// </summary>
        private void BindOverallStats()
        {
            if (allScores.Count == 0)
            {
                dgStats.DataSource = null;
                lblSummary.Text = "暂无成绩数据";
                return;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("统计项", typeof(string));
            dt.Columns.Add("数值", typeof(string));

            int stuCount = allScores.Select(s => s.StuId).Distinct().Count();
            int courseCount = allScores.Select(s => s.CourseId).Distinct().Count();
            int totalRecords = allScores.Count;
            double avgScore = Math.Round(allScores.Average(s => s.Score), 1);
            int maxScore = allScores.Max(s => s.Score);
            int minScore = allScores.Min(s => s.Score);
            int passCount = allScores.Count(s => s.Score >= 60);
            double passRate = Math.Round((double)passCount / totalRecords * 100, 1);
            int excellentCount = allScores.Count(s => s.Score >= 90);
            double excellentRate = Math.Round((double)excellentCount / totalRecords * 100, 1);
            int failCount = totalRecords - passCount;

            // 各分数段分布
            int seg90 = allScores.Count(s => s.Score >= 90);
            int seg80 = allScores.Count(s => s.Score >= 80 && s.Score < 90);
            int seg70 = allScores.Count(s => s.Score >= 70 && s.Score < 80);
            int seg60 = allScores.Count(s => s.Score >= 60 && s.Score < 70);
            int segBelow = allScores.Count(s => s.Score < 60);

            dt.Rows.Add("学员总数", stuCount + " 人");
            dt.Rows.Add("科目总数", courseCount + " 个");
            dt.Rows.Add("成绩记录总数", totalRecords + " 条");
            dt.Rows.Add("─────────", "─────────");
            dt.Rows.Add("总平均分", avgScore.ToString());
            dt.Rows.Add("最高分", maxScore.ToString());
            dt.Rows.Add("最低分", minScore.ToString());
            dt.Rows.Add("─────────", "─────────");
            dt.Rows.Add("及格人数（≥60）", passCount + " 人");
            dt.Rows.Add("及格率", passRate + "%");
            dt.Rows.Add("优秀人数（≥90）", excellentCount + " 人");
            dt.Rows.Add("优秀率", excellentRate + "%");
            dt.Rows.Add("不及格人数", failCount + " 人");
            dt.Rows.Add("─────────", "─────────");
            dt.Rows.Add("90-100 分", seg90 + " 条");
            dt.Rows.Add("80-89 分", seg80 + " 条");
            dt.Rows.Add("70-79 分", seg70 + " 条");
            dt.Rows.Add("60-69 分", seg60 + " 条");
            dt.Rows.Add("60 分以下", segBelow + " 条");

            dgStats.DataSource = dt;
            dgStats.Columns[0].Width = 200;
            dgStats.Columns[1].Width = 150;

            lblSummary.Text = $"总体统计 · {stuCount} 名学员 · {courseCount} 个科目 · {totalRecords} 条记录";
        }

        /// <summary>
        /// 设置列宽自适应
        /// </summary>
        private void SetColumnWidths()
        {
            if (dgStats.Columns.Count > 0)
            {
                dgStats.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        /// <summary>
        /// 刷新按钮
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                allScores = scoreBll.FindAll();
                if (radByStudent.Checked) BindStudentStats();
                else if (radByCourse.Checked) BindCourseStats();
                else if (radOverall.Checked) BindOverallStats();
            }
            catch (Exception ex)
            {
                MessageBox.Show("刷新失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
