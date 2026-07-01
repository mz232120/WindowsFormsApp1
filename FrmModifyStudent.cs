using System;
using System.Windows.Forms;
using WindowsFormsApp1.bll;
using WindowsFormsApp1.entity;
using WindowsFormsApp1.util;

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
            // 初始化时显示照片预览，将相对路径转为绝对路径
            picPhoto.ImageLocation = FileHelper.GetFullPath(photo);
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
    }
}
