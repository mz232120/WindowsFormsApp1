using System;
using System.Windows.Forms;
using WindowsFormsApp1.bll;
using WindowsFormsApp1.entity;

namespace WindowsFormsApp1
{
    public partial class FrmAddStudent : Form
    {
        private StudentBll studentBll = new StudentBll();

        public FrmAddStudent()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string gender = rdoMale.Checked ? "男" : "女";
            DateTime birth = dtpBirth.Value;
            string photo = txtPhoto.Text.Trim();
            string remark = txtRemark.Text.Trim();

            if (name.Length == 0)
            {
                MessageBox.Show("请输入姓名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (photo.Length == 0)
            {
                photo = "imgs/default.jpg";
            }

            try
            {
                StuInfo stu = new StuInfo();
                stu.Name = name;
                stu.Gender = gender;
                stu.Birth = birth;
                stu.Photo = photo;
                stu.Remark = remark;

                bool success = studentBll.Add(stu);

                if (success)
                {
                    MessageBox.Show("学员添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("学员添加失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtName.Text = "";
            rdoMale.Checked = true;
            dtpBirth.Value = DateTime.Now;
            txtPhoto.Text = "";
            txtRemark.Text = "";
            txtName.Focus();
        }
    }
}
