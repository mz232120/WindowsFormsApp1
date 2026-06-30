using System;
using System.Windows.Forms;
using WindowsFormsApp1.bll;
using WindowsFormsApp1.entity;

namespace WindowsFormsApp1
{
    public partial class FrmModifyStudent : Form
    {
        private StudentBll studentBll = new StudentBll();
        private int studentId;

        public FrmModifyStudent(int id, string name, string gender, DateTime birth, string photo, string remark)
        {
            InitializeComponent();
            studentId = id;
            txtId.Text = id + "";
            txtName.Text = name;
            if (gender == "男")
            {
                rdoMale.Checked = true;
            }
            else
            {
                rdoFemale.Checked = true;
            }
            dtpBirth.Value = birth;
            txtPhoto.Text = photo;
            txtRemark.Text = remark;
        }

        private void FrmModifyStudent_Load(object sender, EventArgs e)
        {
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                string gender = rdoMale.Checked ? "男" : "女";
                DateTime birth = dtpBirth.Value;
                string photo = txtPhoto.Text.Trim();
                string remark = txtRemark.Text.Trim();

                if (name.Length == 0)
                {
                    MessageBox.Show("请输入姓名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                StuInfo stu = new StuInfo();
                stu.Id = studentId;
                stu.Name = name;
                stu.Gender = gender;
                stu.Birth = birth;
                stu.Photo = photo;
                stu.Remark = remark;

                bool success = studentBll.Update(stu);

                if (success)
                {
                    MessageBox.Show("修改学员成功", "提示");
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
