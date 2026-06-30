using System;
using System.Windows.Forms;
using WindowsFormsApp1.bll;
using WindowsFormsApp1.entity;

namespace WindowsFormsApp1
{
    public partial class FrmModifyScore : Form
    {
        private ScoreBll scoreBll = new ScoreBll();
        private int stuId;
        private int courseId;

        public FrmModifyScore(int stuId, int courseId, string stuName, string courseName, int score, string remark)
        {
            InitializeComponent();
            this.stuId = stuId;
            this.courseId = courseId;
            txtStuName.Text = stuName;
            txtCourseName.Text = courseName;
            txtScore.Text = score + "";
            txtRemark.Text = remark;
        }

        private void FrmModifyScore_Load(object sender, EventArgs e)
        {
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                int scoreValue;
                if (!int.TryParse(txtScore.Text.Trim(), out scoreValue) || scoreValue < 0 || scoreValue > 100)
                {
                    MessageBox.Show("请输入0-100之间的成绩", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtScore.Focus();
                    return;
                }

                ScoreInfo score = new ScoreInfo();
                score.StuId = stuId;
                score.CourseId = courseId;
                score.Score = scoreValue;
                score.Remark = txtRemark.Text.Trim();

                bool success = scoreBll.Update(score);

                if (success)
                {
                    MessageBox.Show("修改成绩成功", "提示");
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("修改失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
