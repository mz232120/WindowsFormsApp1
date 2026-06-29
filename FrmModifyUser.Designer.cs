namespace WindowsFormsApp1
{
    partial class FrmModifyUser
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
            this.lblId = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPwd = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.rdoEnbale = new System.Windows.Forms.RadioButton();
            this.rdoDisable = new System.Windows.Forms.RadioButton();
            this.btnModify = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblId
            //
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(60, 40);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(52, 15);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "编号";
            //
            // lblName
            //
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(60, 90);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(52, 15);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "用户名";
            //
            // lblPwd
            //
            this.lblPwd.AutoSize = true;
            this.lblPwd.Location = new System.Drawing.Point(60, 140);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(37, 15);
            this.lblPwd.TabIndex = 2;
            this.lblPwd.Text = "密码";
            //
            // lblStatus
            //
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(60, 190);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 15);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "状态";
            //
            // txtId
            //
            this.txtId.Location = new System.Drawing.Point(130, 37);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(200, 25);
            this.txtId.TabIndex = 4;
            //
            // txtName
            //
            this.txtName.Location = new System.Drawing.Point(130, 87);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 25);
            this.txtName.TabIndex = 5;
            //
            // txtPwd
            //
            this.txtPwd.Location = new System.Drawing.Point(130, 137);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(200, 25);
            this.txtPwd.TabIndex = 6;
            //
            // rdoEnbale
            //
            this.rdoEnbale.AutoSize = true;
            this.rdoEnbale.Checked = true;
            this.rdoEnbale.Location = new System.Drawing.Point(130, 188);
            this.rdoEnbale.Name = "rdoEnbale";
            this.rdoEnbale.Size = new System.Drawing.Size(58, 19);
            this.rdoEnbale.TabIndex = 7;
            this.rdoEnbale.TabStop = true;
            this.rdoEnbale.Text = "可用";
            this.rdoEnbale.UseVisualStyleBackColor = true;
            //
            // rdoDisable
            //
            this.rdoDisable.AutoSize = true;
            this.rdoDisable.Location = new System.Drawing.Point(210, 188);
            this.rdoDisable.Name = "rdoDisable";
            this.rdoDisable.Size = new System.Drawing.Size(58, 19);
            this.rdoDisable.TabIndex = 8;
            this.rdoDisable.Text = "禁用";
            this.rdoDisable.UseVisualStyleBackColor = true;
            //
            // btnModify
            //
            this.btnModify.Location = new System.Drawing.Point(130, 240);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(120, 35);
            this.btnModify.TabIndex = 9;
            this.btnModify.Text = "修改";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            //
            // FrmModifyUser
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.rdoDisable);
            this.Controls.Add(this.rdoEnbale);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblPwd);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblId);
            this.Name = "FrmModifyUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改用户";
            this.Load += new System.EventHandler(this.FrmModifyUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.RadioButton rdoEnbale;
        private System.Windows.Forms.RadioButton rdoDisable;
        private System.Windows.Forms.Button btnModify;
    }
}
