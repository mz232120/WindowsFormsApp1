using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmAddUser : Form
    {
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

            // 2. 状态：可用=1，禁用=0
            int status = rdoEnabled.Checked ? 1 : 0;

            // 3. 连接数据库，添加用户
            string connStr = "Data Source=.;Initial Catalog=studentDB;User ID=sa;Password=123456";
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();

                // 检查用户名是否已存在
                string checkSql = "SELECT COUNT(*) FROM userInfo WHERE name=@name";
                SqlCommand checkCmd = new SqlCommand(checkSql, conn);
                checkCmd.Parameters.AddWithValue("@name", userName);
                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("用户名已存在，请更换用户名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUserName.Focus();
                    return;
                }

                // 插入新用户
                string insertSql = "INSERT INTO userInfo (name, pwd, status) VALUES (@name, @pwd, @status)";
                SqlCommand insertCmd = new SqlCommand(insertSql, conn);
                insertCmd.Parameters.AddWithValue("@name", userName);
                insertCmd.Parameters.AddWithValue("@pwd", password);
                insertCmd.Parameters.AddWithValue("@status", status);

                int result = insertCmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("用户添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // 清空输入框
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("用户添加失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库连接失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
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
