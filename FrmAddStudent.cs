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

        /// <summary>
        /// 点击照片文本框，弹出文件选择对话框
        /// </summary>
        private void txtPhoto_MouseClick(object sender, MouseEventArgs e)
        {
            // 1. 设置文件对话框的过滤器,过滤图片文件
            openFileDialog1.Filter = "图片文件|*.jpg;*.jpeg;*.png;*.gif";
            // 2. openFileDialog1.ShowDialog():打开对话框 DialogResult.OK 表示确认
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // 获取选中的图片路径，赋值给文本框
                txtPhoto.Text = openFileDialog1.FileName;
                // 将图片显示器的图片路径设置成图片路径
                picPhoto.ImageLocation = txtPhoto.Text;
            }
        }

        private void ClearInputs()
        {
            txtName.Text = "";
            rdoMale.Checked = true;
            dtpBirth.Value = DateTime.Now;
            txtPhoto.Text = "";
            txtRemark.Text = "";
            picPhoto.ImageLocation = "";
            txtName.Focus();
        }
    }
}
