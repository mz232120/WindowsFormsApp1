using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmModifyUser : Form
    {
        public FrmModifyUser(int id, string name, string pwd, int status)
        {
            InitializeComponent();
            // 初始化界面数据
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
            string connStr = "Data Source=.;Initial Catalog=studentDB;User ID=sa;Password=123456";
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();

                int id = int.Parse(txtId.Text);
                string name = txtName.Text;
                string pwd = txtPwd.Text;
                int status = rdoEnbale.Checked ? 1 : 0;

                string sql = "UPDATE userInfo SET name=@name, pwd=@pwd, status=@status WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@pwd", pwd);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                MessageBox.Show("修改用户成功", "提示");
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            this.Dispose();
        }
    }
}
