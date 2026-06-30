namespace WindowsFormsApp1
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.用户管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mniAddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mniMuser = new System.Windows.Forms.ToolStripMenuItem();
            this.学员基本信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mniAddstu = new System.Windows.Forms.ToolStripMenuItem();
            this.mniupdate = new System.Windows.Forms.ToolStripMenuItem();
            this.管理学员ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.科目管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加科目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.管理科目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.成绩管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加成绩1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.管理成绩ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.成绩统计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于我们ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslWelcome = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.用户管理ToolStripMenuItem,
            this.学员基本信息ToolStripMenuItem,
            this.科目管理ToolStripMenuItem,
            this.成绩管理ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(902, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // 用户管理ToolStripMenuItem
            // 
            this.用户管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniAddUser,
            this.mniMuser});
            this.用户管理ToolStripMenuItem.Name = "用户管理ToolStripMenuItem";
            this.用户管理ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.用户管理ToolStripMenuItem.Text = "用户管理";
            // 
            // mniAddUser
            // 
            this.mniAddUser.Name = "mniAddUser";
            this.mniAddUser.Size = new System.Drawing.Size(182, 34);
            this.mniAddUser.Text = "添加用户";
            this.mniAddUser.Click += new System.EventHandler(this.mniAddUser_Click);
            // 
            // mniMuser
            // 
            this.mniMuser.Name = "mniMuser";
            this.mniMuser.Size = new System.Drawing.Size(182, 34);
            this.mniMuser.Text = "管理用户";
            this.mniMuser.Click += new System.EventHandler(this.mniMuser_Click);
            //
            // 学员基本信息ToolStripMenuItem
            // 
            this.学员基本信息ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniAddstu,
            this.mniupdate,
            this.管理学员ToolStripMenuItem});
            this.学员基本信息ToolStripMenuItem.Name = "学员基本信息ToolStripMenuItem";
            this.学员基本信息ToolStripMenuItem.Size = new System.Drawing.Size(170, 28);
            this.学员基本信息ToolStripMenuItem.Text = "学员基本信息管理";
            // 
            // mniAddstu
            // 
            this.mniAddstu.Name = "mniAddstu";
            this.mniAddstu.Size = new System.Drawing.Size(182, 34);
            this.mniAddstu.Text = "添加学员";
            // 
            // mniupdate
            // 
            this.mniupdate.Name = "mniupdate";
            this.mniupdate.Size = new System.Drawing.Size(182, 34);
            this.mniupdate.Text = "修改学员";
            // 
            // 管理学员ToolStripMenuItem
            // 
            this.管理学员ToolStripMenuItem.Name = "管理学员ToolStripMenuItem";
            this.管理学员ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.管理学员ToolStripMenuItem.Text = "管理学员";
            // 
            // 科目管理ToolStripMenuItem
            // 
            this.科目管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加科目ToolStripMenuItem,
            this.管理科目ToolStripMenuItem});
            this.科目管理ToolStripMenuItem.Name = "科目管理ToolStripMenuItem";
            this.科目管理ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.科目管理ToolStripMenuItem.Text = "科目管理";
            // 
            // 添加科目ToolStripMenuItem
            // 
            this.添加科目ToolStripMenuItem.Name = "添加科目ToolStripMenuItem";
            this.添加科目ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.添加科目ToolStripMenuItem.Text = "添加科目";
            this.添加科目ToolStripMenuItem.Click += new System.EventHandler(this.mniAddCourse_Click);
            // 
            // 管理科目ToolStripMenuItem
            // 
            this.管理科目ToolStripMenuItem.Name = "管理科目ToolStripMenuItem";
            this.管理科目ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.管理科目ToolStripMenuItem.Text = "管理科目";
            this.管理科目ToolStripMenuItem.Click += new System.EventHandler(this.mniCourseManagement_Click);
            // 
            // 成绩管理ToolStripMenuItem
            // 
            this.成绩管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加成绩1ToolStripMenuItem,
            this.管理成绩ToolStripMenuItem,
            this.成绩统计ToolStripMenuItem});
            this.成绩管理ToolStripMenuItem.Name = "成绩管理ToolStripMenuItem";
            this.成绩管理ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.成绩管理ToolStripMenuItem.Text = "成绩管理";
            // 
            // 添加成绩1ToolStripMenuItem
            // 
            this.添加成绩1ToolStripMenuItem.Name = "添加成绩1ToolStripMenuItem";
            this.添加成绩1ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.添加成绩1ToolStripMenuItem.Text = "添加成绩";
            // 
            // 管理成绩ToolStripMenuItem
            // 
            this.管理成绩ToolStripMenuItem.Name = "管理成绩ToolStripMenuItem";
            this.管理成绩ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.管理成绩ToolStripMenuItem.Text = "管理成绩";
            // 
            // 成绩统计ToolStripMenuItem
            // 
            this.成绩统计ToolStripMenuItem.Name = "成绩统计ToolStripMenuItem";
            this.成绩统计ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.成绩统计ToolStripMenuItem.Text = "成绩统计";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于我们ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(62, 28);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于我们ToolStripMenuItem
            // 
            this.关于我们ToolStripMenuItem.Name = "关于我们ToolStripMenuItem";
            this.关于我们ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.关于我们ToolStripMenuItem.Text = "关于我们";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 32);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(902, 33);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(34, 28);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(34, 28);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(34, 28);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(34, 28);
            this.toolStripButton4.Text = "toolStripButton4";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslUser,
            this.tsslTime,
            this.tsslWelcome});
            this.statusStrip1.Location = new System.Drawing.Point(0, 470);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(902, 31);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslUser
            // 
            this.tsslUser.Name = "tsslUser";
            this.tsslUser.Size = new System.Drawing.Size(141, 24);
            this.tsslUser.Text = "当前用户:admin";
            // 
            // tsslTime
            // 
            this.tsslTime.AutoSize = false;
            this.tsslTime.Name = "tsslTime";
            this.tsslTime.Size = new System.Drawing.Size(521, 24);
            this.tsslTime.Spring = true;
            this.tsslTime.Text = "当前时间:";
            // 
            // tsslWelcome
            // 
            this.tsslWelcome.Name = "tsslWelcome";
            this.tsslWelcome.Size = new System.Drawing.Size(225, 24);
            this.tsslWelcome.Text = "欢迎使用学员管理系统v1.0";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 501);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 用户管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mniAddUser;
        private System.Windows.Forms.ToolStripMenuItem mniMuser;
        private System.Windows.Forms.ToolStripMenuItem 学员基本信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 科目管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 成绩管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mniAddstu;
        private System.Windows.Forms.ToolStripMenuItem mniupdate;
        private System.Windows.Forms.ToolStripMenuItem 管理学员ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加科目ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 管理科目ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加成绩1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 管理成绩ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 成绩统计ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于我们ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslUser;
        private System.Windows.Forms.ToolStripStatusLabel tsslTime;
        private System.Windows.Forms.ToolStripStatusLabel tsslWelcome;
    }
}