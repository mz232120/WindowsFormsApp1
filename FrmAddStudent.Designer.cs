namespace WindowsFormsApp1
{
    partial class FrmAddStudent
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblBirth = new System.Windows.Forms.Label();
            this.lblPhoto = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPhoto = new System.Windows.Forms.TextBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.rdoMale = new System.Windows.Forms.RadioButton();
            this.rdoFemale = new System.Windows.Forms.RadioButton();
            this.dtpBirth = new System.Windows.Forms.DateTimePicker();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.picPhoto = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).BeginInit();
            this.SuspendLayout();
            //
            // lblName
            //
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(60, 40);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(37, 15);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "姓名";
            //
            // lblGender
            //
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(60, 85);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(37, 15);
            this.lblGender.TabIndex = 1;
            this.lblGender.Text = "性别";
            //
            // lblBirth
            //
            this.lblBirth.AutoSize = true;
            this.lblBirth.Location = new System.Drawing.Point(60, 130);
            this.lblBirth.Name = "lblBirth";
            this.lblBirth.Size = new System.Drawing.Size(67, 15);
            this.lblBirth.TabIndex = 2;
            this.lblBirth.Text = "出生日期";
            //
            // lblPhoto
            //
            this.lblPhoto.AutoSize = true;
            this.lblPhoto.Location = new System.Drawing.Point(60, 175);
            this.lblPhoto.Name = "lblPhoto";
            this.lblPhoto.Size = new System.Drawing.Size(67, 15);
            this.lblPhoto.TabIndex = 3;
            this.lblPhoto.Text = "照片路径";
            //
            // lblRemark
            //
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(60, 220);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(37, 15);
            this.lblRemark.TabIndex = 4;
            this.lblRemark.Text = "备注";
            //
            // txtName
            //
            this.txtName.Location = new System.Drawing.Point(140, 37);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 25);
            this.txtName.TabIndex = 5;
            //
            // txtPhoto
            //
            this.txtPhoto.Location = new System.Drawing.Point(140, 172);
            this.txtPhoto.Name = "txtPhoto";
            this.txtPhoto.Size = new System.Drawing.Size(200, 25);
            this.txtPhoto.TabIndex = 8;
            this.txtPhoto.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPhoto_MouseClick);
            //
            // txtRemark
            //
            this.txtRemark.Location = new System.Drawing.Point(140, 217);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(200, 60);
            this.txtRemark.TabIndex = 9;
            //
            // rdoMale
            //
            this.rdoMale.AutoSize = true;
            this.rdoMale.Checked = true;
            this.rdoMale.Location = new System.Drawing.Point(140, 83);
            this.rdoMale.Name = "rdoMale";
            this.rdoMale.Size = new System.Drawing.Size(43, 19);
            this.rdoMale.TabIndex = 6;
            this.rdoMale.TabStop = true;
            this.rdoMale.Text = "男";
            this.rdoMale.UseVisualStyleBackColor = true;
            //
            // rdoFemale
            //
            this.rdoFemale.AutoSize = true;
            this.rdoFemale.Location = new System.Drawing.Point(200, 83);
            this.rdoFemale.Name = "rdoFemale";
            this.rdoFemale.Size = new System.Drawing.Size(43, 19);
            this.rdoFemale.TabIndex = 7;
            this.rdoFemale.Text = "女";
            this.rdoFemale.UseVisualStyleBackColor = true;
            //
            // dtpBirth
            //
            this.dtpBirth.Location = new System.Drawing.Point(140, 127);
            this.dtpBirth.Name = "dtpBirth";
            this.dtpBirth.Size = new System.Drawing.Size(200, 25);
            this.dtpBirth.TabIndex = 10;
            //
            // btnClear
            //
            this.btnClear.Location = new System.Drawing.Point(100, 300);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 32);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            //
            // btnAdd
            //
            this.btnAdd.Location = new System.Drawing.Point(230, 300);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 32);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            //
            // picPhoto
            //
            this.picPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPhoto.Location = new System.Drawing.Point(400, 37);
            this.picPhoto.Name = "picPhoto";
            this.picPhoto.Size = new System.Drawing.Size(160, 180);
            this.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPhoto.TabIndex = 13;
            this.picPhoto.TabStop = false;
            //
            // FrmAddStudent
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 360);
            this.Controls.Add(this.picPhoto);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dtpBirth);
            this.Controls.Add(this.rdoFemale);
            this.Controls.Add(this.rdoMale);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.txtPhoto);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.lblPhoto);
            this.Controls.Add(this.lblBirth);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.lblName);
            this.Name = "FrmAddStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加学生";
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblBirth;
        private System.Windows.Forms.Label lblPhoto;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPhoto;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.RadioButton rdoMale;
        private System.Windows.Forms.RadioButton rdoFemale;
        private System.Windows.Forms.DateTimePicker dtpBirth;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.PictureBox picPhoto;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
