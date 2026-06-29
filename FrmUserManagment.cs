using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmUserManagment : Form
    {
        public FrmUserManagment()
        {
            InitializeComponent();
        }

        private void FrmUserManagment_Load(object sender, EventArgs e)
        {
            bindData();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            // 按关键字查询用户
            string connStr = "Data Source=.;Initial Catalog=studentDB;User ID=sa;Password=123456";
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();

                string search = txtContent.Text;
                string sql = "SELECT * FROM userInfo WHERE name LIKE @search OR pwd LIKE @search";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);

                dgUser.DataSource = dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // 1. 判断是否选中行
            if (dgUser.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选择需要删除的行", "提示");
                return;
            }

            // 2. 确认删除
            DialogResult result = MessageBox.Show("确认删除(y/n)?", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            int id = (int)dgUser.SelectedRows[0].Cells[0].Value;
            int status = (int)dgUser.SelectedRows[0].Cells[3].Value;

            // 3. 状态为1（正常）的用户不能删除
            if (status == 1)
            {
                MessageBox.Show("用户正常中，不能删除");
                return;
            }

            // 4. 连接数据库，执行删除
            string connStr = "Data Source=.;Initial Catalog=studentDB;User ID=sa;Password=123456";
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();

                string sql = "DELETE FROM userInfo WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                MessageBox.Show("删除用户成功", "提示");

                // 5. 重新绑定数据
                bindData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 绑定用户数据到DataGridView
        /// </summary>
        private void bindData()
        {
            string connStr = "Data Source=.;Initial Catalog=studentDB;User ID=sa;Password=123456";
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();

                string sql = "SELECT * FROM userInfo";
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);

                dgUser.DataSource = dataSet.Tables[0];

                // 设置表头中文显示
                dgUser.Columns[0].HeaderText = "编号";
                dgUser.Columns[1].HeaderText = "用户名";
                dgUser.Columns[2].HeaderText = "密码";
                dgUser.Columns[3].HeaderText = "状态";
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载数据失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            // 1. 判断是否选中行
            if (dgUser.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择需要修改用户", "提示");
                return;
            }

            // 2. 确认修改
            DialogResult result = MessageBox.Show("确认修改(y/n)?", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            // 3. 获取选中行的数据
            int id = (int)dgUser.SelectedRows[0].Cells[0].Value;
            string name = dgUser.SelectedRows[0].Cells[1].Value.ToString();
            string pwd = dgUser.SelectedRows[0].Cells[2].Value.ToString();
            int status = (int)dgUser.SelectedRows[0].Cells[3].Value;

            // 4. 创建修改窗体并以对话框方式打开
            FrmModifyUser frmModifyUser = new FrmModifyUser(id, name, pwd, status);
            frmModifyUser.ShowDialog();

            // 5. 重新绑定数据
            bindData();
        }
    }
}
