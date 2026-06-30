using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmAddCourse : Form
    {
        public FrmAddCourse()
        {
            InitializeComponent();
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            // 1. 验证输入
            string courseName = txtCourseName.Text.Trim();
            string remark = txtRemark.Text.Trim();

            if (courseName.Length == 0)
            {
                MessageBox.Show("请输入学科名称", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCourseName.Focus();
                return;
            }

            // 2. 连接数据库，添加学科
            string connStr = "Data Source=.;Initial Catalog=studentDB;User ID=sa;Password=123456";
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();

                // 检查学科名称是否已存在
                string checkSql = "SELECT COUNT(*) FROM courseInfo WHERE name=@name";
                SqlCommand checkCmd = new SqlCommand(checkSql, conn);
                checkCmd.Parameters.AddWithValue("@name", courseName);
                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("学科名称已存在，请更换名称", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCourseName.Focus();
                    return;
                }

                // 插入新学科
                string insertSql = "INSERT INTO courseInfo (name, remark) VALUES (@name, @remark)";
                SqlCommand insertCmd = new SqlCommand(insertSql, conn);
                insertCmd.Parameters.AddWithValue("@name", courseName);
                insertCmd.Parameters.AddWithValue("@remark", remark);

                int result = insertCmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("学科添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // 清空输入框
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("学科添加失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtCourseName.Text = "";
            txtRemark.Text = "";
            txtCourseName.Focus();
        }
    }
}
