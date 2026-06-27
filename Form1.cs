using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //退出按钮的功能
            //1.确认退出
            MessageBox.Show("确认退出(y/n)?", "提示", MessageBoxButtons.YesNo);
            //2.关闭窗口:当前窗体的对象:this
            this.Dispose();//dispose：消失  
            //this.Hide();//不可见:对象还在
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //1.判断用户名和密码是否填写
            string name = txtName.Text.Trim();
            string pwd = txtPwd.Text.Trim();

            if (name.Length == 0 || pwd.Length == 0)
            {
                MessageBox.Show("请输入用户和密码");
                return;//程序段结束
            }

            //2.填写完成后，判断用户名是否为"admin",密码"123"  
            if (name.Equals("admin") && pwd.Equals("123"))
            {
                //2.1 是:提示登录成功,跳转到主界面
                MessageBox.Show("亲爱的 [" + name + "]用户,欢迎使用甲骨文学员信息管理系统v1.0...");
                //2.2 跳转到主窗体
                FormMain formMain = new FormMain();
                formMain.Show();
                //2.3 自己隐藏
                this.Hide();

            }
            else
            {
                //2.1 否:提示登录失败,清空用户名和密码
                MessageBox.Show("用户名或密码不存在,请重新输入");
                txtName.Text = "";
                txtPwd.Text = "";
            }

        }
    }
}
