namespace WindowsFormsApp1
{
    partial class FrmAddCourse
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
            this.lblCourseName = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.txtCourseName = new System.Windows.Forms.TextBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAddCourse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblCourseName
            //
            this.lblCourseName.AutoSize = true;
            this.lblCourseName.Location = new System.Drawing.Point(60, 50);
            this.lblCourseName.Name = "lblCourseName";
            this.lblCourseName.Size = new System.Drawing.Size(67, 15);
            this.lblCourseName.TabIndex = 0;
            this.lblCourseName.Text = "学科名称";
            //
            // lblRemark
            //
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(60, 100);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(37, 15);
            this.lblRemark.TabIndex = 1;
            this.lblRemark.Text = "备注";
            //
            // txtCourseName
            //
            this.txtCourseName.Location = new System.Drawing.Point(140, 47);
            this.txtCourseName.Name = "txtCourseName";
            this.txtCourseName.Size = new System.Drawing.Size(200, 25);
            this.txtCourseName.TabIndex = 2;
            //
            // txtRemark
            //
            this.txtRemark.Location = new System.Drawing.Point(140, 97);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(200, 25);
            this.txtRemark.TabIndex = 3;
            //
            // btnClear
            //
            this.btnClear.Location = new System.Drawing.Point(100, 160);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 32);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            //
            // btnAddCourse
            //
            this.btnAddCourse.Location = new System.Drawing.Point(230, 160);
            this.btnAddCourse.Name = "btnAddCourse";
            this.btnAddCourse.Size = new System.Drawing.Size(90, 32);
            this.btnAddCourse.TabIndex = 5;
            this.btnAddCourse.Text = "添加学科";
            this.btnAddCourse.UseVisualStyleBackColor = true;
            this.btnAddCourse.Click += new System.EventHandler(this.btnAddCourse_Click);
            //
            // FrmAddCourse
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 220);
            this.Controls.Add(this.btnAddCourse);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.txtCourseName);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.lblCourseName);
            this.Name = "FrmAddCourse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加学科";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCourseName;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.TextBox txtCourseName;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAddCourse;
    }
}
