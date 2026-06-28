using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            DialogResult result = MessageBox.Show("确认退出(y/n)?", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //2.关闭窗口:当前窗体的对象:this
                this.Dispose();//dispose：消失
                //this.Hide();//不可见:对象还在
            }
        }

        //登录三次
        int count = 0;
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

            //2.填写完成后，使用ADO.NET连接数据库验证
            //获取连接字符串
            String connStr = "Data Source=.;Initial Catalog=studentDB;User ID=sa;Password=123456";

            //获取连接对象并打开
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            //获取操作对象
            String sql = " select * from userInfo where name='" + name + "' and pwd='" + pwd + "' and status=1";
            Console.WriteLine(sql);
            SqlCommand cmd = new SqlCommand(sql, conn);
            //获取数据阅读器
            SqlDataReader reader = cmd.ExecuteReader();
            //开始阅读，获取数据
            if (reader.Read())
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
                MessageBox.Show("用户名或密码不存在,请重新输入");
                txtName.Text = "";
                txtPwd.Text = "";
                count++;
                if (count > 3)
                {
                    MessageBox.Show("三次登录失败，退出系统");
                    count = 0;
                    this.Dispose();
                }
            }

            //关闭阅读器和连接
            reader.Close();
            conn.Close();
        }
    }
}
