using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsApp1.bll;
using WindowsFormsApp1.entity;

namespace WindowsFormsApp1
{
    public partial class FrmScoreManagement : Form
    {
        private ScoreBll scoreBll = new ScoreBll();

        public FrmScoreManagement()
        {
            InitializeComponent();
        }

        private void FrmScoreManagement_Load(object sender, EventArgs e)
        {
            bindData();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                // 可以按学员ID查询
                string keyword = txtContent.Text.Trim();
                List<ScoreInfo> list;

                if (int.TryParse(keyword, out int stuId))
                {
                    list = scoreBll.FindByStuId(stuId);
                }
                else
                {
                    list = scoreBll.FindAll();
                }

                BindGrid(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgScore.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选择需要删除的行", "提示");
                return;
            }

            DialogResult result = MessageBox.Show("确认删除(y/n)?", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            int stuId = (int)dgScore.SelectedRows[0].Cells[0].Value;
            int courseId = (int)dgScore.SelectedRows[0].Cells[1].Value;

            try
            {
                bool success = scoreBll.Delete(stuId, courseId);
                if (success)
                {
                    MessageBox.Show("删除成绩成功", "提示");
                    bindData();
                }
                else
                {
                    MessageBox.Show("删除失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bindData()
        {
            try
            {
                List<ScoreInfo> list = scoreBll.FindAll();
                BindGrid(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载数据失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindGrid(List<ScoreInfo> list)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("stuId", typeof(int));
            dt.Columns.Add("courseId", typeof(int));
            dt.Columns.Add("stuName", typeof(string));
            dt.Columns.Add("courseName", typeof(string));
            dt.Columns.Add("score", typeof(int));
            dt.Columns.Add("remark", typeof(string));

            foreach (ScoreInfo score in list)
            {
                dt.Rows.Add(score.StuId, score.CourseId, score.StuInfo.Name, score.CourseInfo.Name, score.Score, score.Remark);
            }

            dgScore.DataSource = dt;

            dgScore.Columns[0].HeaderText = "学员ID";
            dgScore.Columns[1].HeaderText = "学科ID";
            dgScore.Columns[2].HeaderText = "学员姓名";
            dgScore.Columns[3].HeaderText = "学科名称";
            dgScore.Columns[4].HeaderText = "成绩";
            dgScore.Columns[5].HeaderText = "备注";
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (dgScore.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择需要修改的成绩", "提示");
                return;
            }

            DialogResult result = MessageBox.Show("确认修改(y/n)?", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            int stuId = (int)dgScore.SelectedRows[0].Cells[0].Value;
            int courseId = (int)dgScore.SelectedRows[0].Cells[1].Value;
            string stuName = dgScore.SelectedRows[0].Cells[2].Value.ToString();
            string courseName = dgScore.SelectedRows[0].Cells[3].Value.ToString();
            int score = (int)dgScore.SelectedRows[0].Cells[4].Value;
            string remark = dgScore.SelectedRows[0].Cells[5].Value.ToString();

            FrmModifyScore frmModifyScore = new FrmModifyScore(stuId, courseId, stuName, courseName, score, remark);
            frmModifyScore.ShowDialog();

            bindData();
        }
    }
}
