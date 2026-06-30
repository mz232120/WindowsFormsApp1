using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmModifyCourse : Form
    {
        public FrmModifyCourse(int id, string name, string remark)
        {
            InitializeComponent();
            // 初始化界面数据
            txtId.Text = id + "";
            txtName.Text = name;
            txtRemark.Text = remark;
        }

        private void FrmModifyCourse_Load(object sender, EventArgs e)
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
                string remark = txtRemark.Text;

                // 检查学科名称是否已存在（排除自身）
                string checkSql = "SELECT COUNT(*) FROM courseInfo WHERE name=@name AND id<>@id";
                SqlCommand checkCmd = new SqlCommand(checkSql, conn);
                checkCmd.Parameters.AddWithValue("@name", name);
                checkCmd.Parameters.AddWithValue("@id", id);
                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("学科名称已存在，请更换名称", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sql = "UPDATE courseInfo SET name=@name, remark=@remark WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@remark", remark);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                MessageBox.Show("修改学科成功", "提示");
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
