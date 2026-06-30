using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsApp1.bll;
using WindowsFormsApp1.entity;

namespace WindowsFormsApp1
{
    public partial class FrmUserManagment : Form
    {
        private UserBll userBll = new UserBll();

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
            try
            {
                string search = txtContent.Text;
                List<UserInfo> list = userBll.FindByKeyword(search);
                BindGrid(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            try
            {
                // 3. 执行删除
                bool success = userBll.Delete(id, status);
                if (success)
                {
                    MessageBox.Show("删除用户成功", "提示");
                    bindData();
                }
                else
                {
                    MessageBox.Show("用户正常中，不能删除", "提示");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 绑定用户数据到DataGridView
        /// </summary>
        private void bindData()
        {
            try
            {
                List<UserInfo> list = userBll.FindAll();
                BindGrid(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载数据失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 绑定数据到DataGridView
        /// </summary>
        private void BindGrid(List<UserInfo> list)
        {
            // 创建DataTable并填充数据
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("pwd", typeof(string));
            dt.Columns.Add("status", typeof(int));

            foreach (UserInfo user in list)
            {
                dt.Rows.Add(user.Id, user.Name, user.Pwd, user.Status);
            }

            dgUser.DataSource = dt;

            // 设置表头中文显示
            dgUser.Columns[0].HeaderText = "编号";
            dgUser.Columns[1].HeaderText = "用户名";
            dgUser.Columns[2].HeaderText = "密码";
            dgUser.Columns[3].HeaderText = "状态";
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
