using System;
using System.Windows.Forms;
using WindowsFormsApp1.bll;
using WindowsFormsApp1.entity;

namespace WindowsFormsApp1
{
    public partial class FrmModifyCourse : Form
    {
        private CourseBll courseBll = new CourseBll();
        private int courseId;

        public FrmModifyCourse(int id, string name, string remark)
        {
            InitializeComponent();
            // 初始化界面数据
            courseId = id;
            txtId.Text = id + "";
            txtName.Text = name;
            txtRemark.Text = remark;
        }

        private void FrmModifyCourse_Load(object sender, EventArgs e)
        {

        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. 获取输入数据
                string name = txtName.Text.Trim();
                string remark = txtRemark.Text.Trim();

                if (name.Length == 0)
                {
                    MessageBox.Show("请输入学科名称", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. 创建学科对象
                CourseInfo course = new CourseInfo();
                course.Id = courseId;
                course.Name = name;
                course.Remark = remark;

                // 3. 调用业务逻辑层修改学科
                bool success = courseBll.Update(course);

                if (success)
                {
                    MessageBox.Show("修改学科成功", "提示");
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("学科名称已存在，请更换名称", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
