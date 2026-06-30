using System;
using System.Windows.Forms;
using WindowsFormsApp1.bll;
using WindowsFormsApp1.entity;

namespace WindowsFormsApp1
{
    public partial class FrmModifyUser : Form
    {
        private UserBll userBll = new UserBll();
        private int userId;

        public FrmModifyUser(int id, string name, string pwd, int status)
        {
            InitializeComponent();
            // 初始化界面数据
            userId = id;
            txtId.Text = id + "";
            txtName.Text = name;
            txtPwd.Text = pwd;
            if (status == 1)
            {
                rdoEnbale.Checked = true;
            }
            else
            {
                rdoDisable.Checked = true;
            }
        }

        private void FrmModifyUser_Load(object sender, EventArgs e)
        {

        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. 获取输入数据
                string name = txtName.Text.Trim();
                string pwd = txtPwd.Text.Trim();
                int status = rdoEnbale.Checked ? 1 : 0;

                if (name.Length == 0)
                {
                    MessageBox.Show("请输入用户名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. 创建用户对象
                UserInfo user = new UserInfo();
                user.Id = userId;
                user.Name = name;
                user.Pwd = pwd;
                user.Status = status;

                // 3. 调用业务逻辑层修改用户
                bool success = userBll.Update(user);

                if (success)
                {
                    MessageBox.Show("修改用户成功", "提示");
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("用户名已存在，请更换用户名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
