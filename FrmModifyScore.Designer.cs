namespace WindowsFormsApp1
{
    partial class FrmModifyScore
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblStuName = new System.Windows.Forms.Label();
            this.lblCourseName = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.txtStuName = new System.Windows.Forms.TextBox();
            this.txtCourseName = new System.Windows.Forms.TextBox();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.btnModify = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblStuName
            //
            this.lblStuName.AutoSize = true;
            this.lblStuName.Location = new System.Drawing.Point(60, 40);
            this.lblStuName.Name = "lblStuName";
            this.lblStuName.Size = new System.Drawing.Size(67, 15);
            this.lblStuName.TabIndex = 0;
            this.lblStuName.Text = "学员姓名";
            //
            // lblCourseName
            //
            this.lblCourseName.AutoSize = true;
            this.lblCourseName.Location = new System.Drawing.Point(60, 90);
            this.lblCourseName.Name = "lblCourseName";
            this.lblCourseName.Size = new System.Drawing.Size(67, 15);
            this.lblCourseName.TabIndex = 1;
            this.lblCourseName.Text = "学科名称";
            //
            // lblScore
            //
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(60, 140);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(37, 15);
            this.lblScore.TabIndex = 2;
            this.lblScore.Text = "成绩";
            //
            // lblRemark
            //
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(60, 190);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(37, 15);
            this.lblRemark.TabIndex = 3;
            this.lblRemark.Text = "备注";
            //
            // txtStuName
            //
            this.txtStuName.Location = new System.Drawing.Point(140, 37);
            this.txtStuName.Name = "txtStuName";
            this.txtStuName.ReadOnly = true;
            this.txtStuName.Size = new System.Drawing.Size(200, 25);
            this.txtStuName.TabIndex = 4;
            //
            // txtCourseName
            //
            this.txtCourseName.Location = new System.Drawing.Point(140, 87);
            this.txtCourseName.Name = "txtCourseName";
            this.txtCourseName.ReadOnly = true;
            this.txtCourseName.Size = new System.Drawing.Size(200, 25);
            this.txtCourseName.TabIndex = 5;
            //
            // txtScore
            //
            this.txtScore.Location = new System.Drawing.Point(140, 137);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(200, 25);
            this.txtScore.TabIndex = 6;
            //
            // txtRemark
            //
            this.txtRemark.Location = new System.Drawing.Point(140, 187);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(200, 25);
            this.txtRemark.TabIndex = 7;
            //
            // btnModify
            //
            this.btnModify.Location = new System.Drawing.Point(140, 240);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(120, 35);
            this.btnModify.TabIndex = 8;
            this.btnModify.Text = "修改";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            //
            // FrmModifyScore
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.txtCourseName);
            this.Controls.Add(this.txtStuName);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblCourseName);
            this.Controls.Add(this.lblStuName);
            this.Name = "FrmModifyScore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改成绩";
            this.Load += new System.EventHandler(this.FrmModifyScore_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblStuName;
        private System.Windows.Forms.Label lblCourseName;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.TextBox txtStuName;
        private System.Windows.Forms.TextBox txtCourseName;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Button btnModify;
    }
}
