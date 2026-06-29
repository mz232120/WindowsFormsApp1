namespace WindowsFormsApp1
{
    partial class FrmAddUser
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
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.rdoEnabled = new System.Windows.Forms.RadioButton();
            this.rdoDisabled = new System.Windows.Forms.RadioButton();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblUserName
            //
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(60, 50);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(52, 15);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "用户名";
            //
            // lblPassword
            //
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(60, 100);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(37, 15);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "密码";
            //
            // lblStatus
            //
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(60, 150);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 15);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "状态";
            //
            // txtUserName
            //
            this.txtUserName.Location = new System.Drawing.Point(130, 47);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(200, 25);
            this.txtUserName.TabIndex = 3;
            //
            // txtPassword
            //
            this.txtPassword.Location = new System.Drawing.Point(130, 97);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(200, 25);
            this.txtPassword.TabIndex = 4;
            //
            // rdoEnabled
            //
            this.rdoEnabled.AutoSize = true;
            this.rdoEnabled.Checked = true;
            this.rdoEnabled.Location = new System.Drawing.Point(130, 148);
            this.rdoEnabled.Name = "rdoEnabled";
            this.rdoEnabled.Size = new System.Drawing.Size(58, 19);
            this.rdoEnabled.TabIndex = 5;
            this.rdoEnabled.TabStop = true;
            this.rdoEnabled.Text = "可用";
            this.rdoEnabled.UseVisualStyleBackColor = true;
            //
            // rdoDisabled
            //
            this.rdoDisabled.AutoSize = true;
            this.rdoDisabled.Location = new System.Drawing.Point(210, 148);
            this.rdoDisabled.Name = "rdoDisabled";
            this.rdoDisabled.Size = new System.Drawing.Size(58, 19);
            this.rdoDisabled.TabIndex = 6;
            this.rdoDisabled.Text = "禁用";
            this.rdoDisabled.UseVisualStyleBackColor = true;
            //
            // btnClear
            //
            this.btnClear.Location = new System.Drawing.Point(100, 200);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 32);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            //
            // btnAddUser
            //
            this.btnAddUser.Location = new System.Drawing.Point(230, 200);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(90, 32);
            this.btnAddUser.TabIndex = 8;
            this.btnAddUser.Text = "添加用户";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            //
            // FrmAddUser
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 260);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.rdoDisabled);
            this.Controls.Add(this.rdoEnabled);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Name = "FrmAddUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加用户";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.RadioButton rdoEnabled;
        private System.Windows.Forms.RadioButton rdoDisabled;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAddUser;
    }
}
