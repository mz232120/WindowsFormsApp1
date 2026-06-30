using System;
using System.Windows.Forms;
using WindowsFormsApp1.bll;
using WindowsFormsApp1.entity;

namespace WindowsFormsApp1
{
    public partial class FrmAddUser : Form
    {
        private UserBll userBll = new UserBll();

        public FrmAddUser()
        {
            InitializeComponent();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            // 1. 验证输入
            string userName = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (userName.Length == 0)
            {
                MessageBox.Show("请输入用户名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return;
            }

            if (password.Length == 0)
            {
                MessageBox.Show("请输入密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            try
            {
                // 2. 创建用户对象
                UserInfo user = new UserInfo();
                user.Name = userName;
                user.Pwd = password;
                user.Status = rdoEnabled.Checked ? 1 : 0;

                // 3. 调用业务逻辑层添加用户
                bool success = userBll.Add(user);

                if (success)
                {
                    MessageBox.Show("用户添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("用户名已存在，请更换用户名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUserName.Focus();
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
            txtUserName.Text = "";
            txtPassword.Text = "";
            rdoEnabled.Checked = true;
            txtUserName.Focus();
        }
    }
}
