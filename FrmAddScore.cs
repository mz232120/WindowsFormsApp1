using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsApp1.bll;
using WindowsFormsApp1.entity;

namespace WindowsFormsApp1
{
    public partial class FrmAddScore : Form
    {
        private ScoreBll scoreBll = new ScoreBll();

        public FrmAddScore()
        {
            InitializeComponent();
        }

        private void FrmAddScore_Load(object sender, EventArgs e)
        {
            // 加载学员列表
            List<StuInfo> students = scoreBll.FindAllStudents();
            cmbStudent.DataSource = students;
            cmbStudent.DisplayMember = "Name";
            cmbStudent.ValueMember = "Id";

            // 加载学科列表
            List<CourseInfo> courses = scoreBll.FindAllCourses();
            cmbCourse.DataSource = courses;
            cmbCourse.DisplayMember = "Name";
            cmbCourse.ValueMember = "Id";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbStudent.SelectedIndex < 0)
            {
                MessageBox.Show("请选择学员", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbCourse.SelectedIndex < 0)
            {
                MessageBox.Show("请选择学科", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int scoreValue;
            if (!int.TryParse(txtScore.Text.Trim(), out scoreValue) || scoreValue < 0 || scoreValue > 100)
            {
                MessageBox.Show("请输入0-100之间的成绩", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtScore.Focus();
                return;
            }

            try
            {
                ScoreInfo score = new ScoreInfo();
                score.StuId = (int)cmbStudent.SelectedValue;
                score.CourseId = (int)cmbCourse.SelectedValue;
                score.Score = scoreValue;
                score.Remark = txtRemark.Text.Trim();

                bool success = scoreBll.Add(score);

                if (success)
                {
                    MessageBox.Show("成绩添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("该学员此学科成绩已存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            txtScore.Text = "";
            txtRemark.Text = "";
            if (cmbStudent.Items.Count > 0)
                cmbStudent.SelectedIndex = 0;
            if (cmbCourse.Items.Count > 0)
                cmbCourse.SelectedIndex = 0;
        }
    }
}
