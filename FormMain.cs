using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            // 初始化时间显示
            tsslTime.Text = "当前时间: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // 设置定时器每秒更新时间
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tsslTime.Text = "当前时间: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mniAddUser_Click(object sender, EventArgs e)
        {
            //如何在MDI容器中加入子窗体
            //1.创建子窗体对象
            FrmAddUser frmAddUser = new FrmAddUser();
            //2.设置子窗体的mdi父窗体为主窗体对象
            frmAddUser.MdiParent = this;
            //3.显示子窗体
            frmAddUser.Show();
        }

        private void mniMuser_Click(object sender, EventArgs e)
        {
            FrmUserManagment frmUserManagment = new FrmUserManagment();
            frmUserManagment.MdiParent = this;
            frmUserManagment.Show();
        }
    }
}
