using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsApp1.bll;
using WindowsFormsApp1.entity;

namespace WindowsFormsApp1
{
    public partial class FrmStudentManagement : Form
    {
        private StudentBll studentBll = new StudentBll();

        public FrmStudentManagement()
        {
            InitializeComponent();
        }

        private void FrmStudentManagement_Load(object sender, EventArgs e)
        {
            bindData();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string search = txtContent.Text;
                List<StuInfo> list = studentBll.FindByKeyword(search);
                BindGrid(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgStudent.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选择需要删除的行", "提示");
                return;
            }

            DialogResult result = MessageBox.Show("确认删除(y/n)?", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            int id = (int)dgStudent.SelectedRows[0].Cells[0].Value;

            try
            {
                bool success = studentBll.Delete(id);
                if (success)
                {
                    MessageBox.Show("删除学员成功", "提示");
                    bindData();
                }
                else
                {
                    MessageBox.Show("删除失败：该学员下有成绩记录，不能删除", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bindData()
        {
            try
            {
                List<StuInfo> list = studentBll.FindAll();
                BindGrid(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载数据失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindGrid(List<StuInfo> list)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("gender", typeof(string));
            dt.Columns.Add("birth", typeof(DateTime));
            dt.Columns.Add("photo", typeof(string));
            dt.Columns.Add("remark", typeof(string));

            foreach (StuInfo stu in list)
            {
                dt.Rows.Add(stu.Id, stu.Name, stu.Gender, stu.Birth, stu.Photo, stu.Remark);
            }

            dgStudent.DataSource = dt;

            dgStudent.Columns[0].HeaderText = "编号";
            dgStudent.Columns[1].HeaderText = "姓名";
            dgStudent.Columns[2].HeaderText = "性别";
            dgStudent.Columns[3].HeaderText = "出生日期";
            dgStudent.Columns[4].HeaderText = "照片";
            dgStudent.Columns[5].HeaderText = "备注";
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (dgStudent.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择需要修改的学员", "提示");
                return;
            }

            DialogResult result = MessageBox.Show("确认修改(y/n)?", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            int id = (int)dgStudent.SelectedRows[0].Cells[0].Value;
            string name = dgStudent.SelectedRows[0].Cells[1].Value.ToString();
            string gender = dgStudent.SelectedRows[0].Cells[2].Value.ToString();
            DateTime birth = (DateTime)dgStudent.SelectedRows[0].Cells[3].Value;
            string photo = dgStudent.SelectedRows[0].Cells[4].Value.ToString();
            string remark = dgStudent.SelectedRows[0].Cells[5].Value.ToString();

            FrmModifyStudent frmModifyStudent = new FrmModifyStudent(id, name, gender, birth, photo, remark);
            frmModifyStudent.ShowDialog();

            bindData();
        }
    }
}
