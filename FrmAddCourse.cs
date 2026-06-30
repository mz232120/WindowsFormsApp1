using System;
using System.Windows.Forms;
using WindowsFormsApp1.bll;
using WindowsFormsApp1.entity;

namespace WindowsFormsApp1
{
    public partial class FrmAddCourse : Form
    {
        private CourseBll courseBll = new CourseBll();

        public FrmAddCourse()
        {
            InitializeComponent();
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            // 1. 验证输入
            string courseName = txtCourseName.Text.Trim();
            string remark = txtRemark.Text.Trim();

            if (courseName.Length == 0)
            {
                MessageBox.Show("请输入学科名称", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCourseName.Focus();
                return;
            }

            try
            {
                // 2. 创建学科对象
                CourseInfo course = new CourseInfo();
                course.Name = courseName;
                course.Remark = remark;

                // 3. 调用业务逻辑层添加学科
                bool success = courseBll.Add(course);

                if (success)
                {
                    MessageBox.Show("学科添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("学科名称已存在，请更换名称", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCourseName.Focus();
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
            txtCourseName.Text = "";
            txtRemark.Text = "";
            txtCourseName.Focus();
        }
    }
}
