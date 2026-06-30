using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsApp1.bll;
using WindowsFormsApp1.entity;

namespace WindowsFormsApp1
{
    public partial class FrmCourseManagement : Form
    {
        private CourseBll courseBll = new CourseBll();

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
            try
            {
                string search = txtContent.Text;
                List<CourseInfo> list = courseBll.FindByKeyword(search);
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

            try
            {
                // 3. 执行删除
                bool success = courseBll.Delete(id);
                if (success)
                {
                    MessageBox.Show("删除学科成功", "提示");
                    bindData();
                }
                else
                {
                    MessageBox.Show("删除失败：该科目下有成绩记录，不能删除", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 绑定学科数据到DataGridView
        /// </summary>
        private void bindData()
        {
            try
            {
                List<CourseInfo> list = courseBll.FindAll();
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
        private void BindGrid(List<CourseInfo> list)
        {
            // 创建DataTable并填充数据
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("remark", typeof(string));

            foreach (CourseInfo course in list)
            {
                dt.Rows.Add(course.Id, course.Name, course.Remark);
            }

            dgCourse.DataSource = dt;

            // 设置表头中文显示
            dgCourse.Columns[0].HeaderText = "编号";
            dgCourse.Columns[1].HeaderText = "学科名称";
            dgCourse.Columns[2].HeaderText = "备注";
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
