using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmCourseManagement : Form
    {
        public FrmCourseManagement()
        {
            InitializeComponent();
        }

        private void FrmCourseManagement_Load(object sender, EventArgs e)
        {
            bindData();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            // 按关键字查询学科
            string connStr = "Data Source=.;Initial Catalog=studentDB;User ID=sa;Password=123456";
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();

                string search = txtContent.Text;
                string sql = "SELECT * FROM courseInfo WHERE name LIKE @search OR remark LIKE @search";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);

                dgCourse.DataSource = dataSet.Tables[0];
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
            if (dgCourse.SelectedRows.Count < 1)
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

            int id = (int)dgCourse.SelectedRows[0].Cells[0].Value;

            // 3. 检查该科目是否被成绩表引用
            string connStr = "Data Source=.;Initial Catalog=studentDB;User ID=sa;Password=123456";
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();

                // 检查是否有成绩记录引用该科目
                string checkSql = "SELECT COUNT(*) FROM scoreInfo WHERE courseId=@id";
                SqlCommand checkCmd = new SqlCommand(checkSql, conn);
                checkCmd.Parameters.AddWithValue("@id", id);
                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("该科目下有成绩记录，不能删除", "提示");
                    return;
                }

                // 4. 执行删除
                string sql = "DELETE FROM courseInfo WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                MessageBox.Show("删除学科成功", "提示");

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
        /// 绑定学科数据到DataGridView
        /// </summary>
        private void bindData()
        {
            string connStr = "Data Source=.;Initial Catalog=studentDB;User ID=sa;Password=123456";
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();

                string sql = "SELECT * FROM courseInfo";
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);

                dgCourse.DataSource = dataSet.Tables[0];

                // 设置表头中文显示
                dgCourse.Columns[0].HeaderText = "编号";
                dgCourse.Columns[1].HeaderText = "学科名称";
                dgCourse.Columns[2].HeaderText = "备注";
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
            if (dgCourse.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择需要修改的学科", "提示");
                return;
            }

            // 2. 确认修改
            DialogResult result = MessageBox.Show("确认修改(y/n)?", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            // 3. 获取选中行的数据
            int id = (int)dgCourse.SelectedRows[0].Cells[0].Value;
            string name = dgCourse.SelectedRows[0].Cells[1].Value.ToString();
            string remark = dgCourse.SelectedRows[0].Cells[2].Value.ToString();

            // 4. 创建修改窗体并以对话框方式打开
            FrmModifyCourse frmModifyCourse = new FrmModifyCourse(id, name, remark);
            frmModifyCourse.ShowDialog();

            // 5. 重新绑定数据
            bindData();
        }
    }
}
