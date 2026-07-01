namespace WindowsFormsApp1
{
    partial class FrmScoreStatistics
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
            this.dgStats = new System.Windows.Forms.DataGridView();
            this.panelTop = new System.Windows.Forms.Panel();
            this.radOverall = new System.Windows.Forms.RadioButton();
            this.radByCourse = new System.Windows.Forms.RadioButton();
            this.radByStudent = new System.Windows.Forms.RadioButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblSummary = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgStats)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            //
            // panelTop
            //
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Controls.Add(this.radOverall);
            this.panelTop.Controls.Add(this.radByCourse);
            this.panelTop.Controls.Add(this.radByStudent);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(780, 70);
            this.panelTop.TabIndex = 0;
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(106, 27);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "成绩统计";
            //
            // radByStudent
            //
            this.radByStudent.AutoSize = true;
            this.radByStudent.Location = new System.Drawing.Point(160, 22);
            this.radByStudent.Name = "radByStudent";
            this.radByStudent.Size = new System.Drawing.Size(103, 22);
            this.radByStudent.TabIndex = 1;
            this.radByStudent.TabStop = true;
            this.radByStudent.Text = "按学员统计";
            this.radByStudent.UseVisualStyleBackColor = true;
            this.radByStudent.CheckedChanged += new System.EventHandler(this.rad_CheckedChanged);
            //
            // radByCourse
            //
            this.radByCourse.AutoSize = true;
            this.radByCourse.Location = new System.Drawing.Point(280, 22);
            this.radByCourse.Name = "radByCourse";
            this.radByCourse.Size = new System.Drawing.Size(103, 22);
            this.radByCourse.TabIndex = 2;
            this.radByCourse.Text = "按科目统计";
            this.radByCourse.UseVisualStyleBackColor = true;
            this.radByCourse.CheckedChanged += new System.EventHandler(this.rad_CheckedChanged);
            //
            // radOverall
            //
            this.radOverall.AutoSize = true;
            this.radOverall.Location = new System.Drawing.Point(400, 22);
            this.radOverall.Name = "radOverall";
            this.radOverall.Size = new System.Drawing.Size(88, 22);
            this.radOverall.TabIndex = 3;
            this.radOverall.Text = "总体统计";
            this.radOverall.UseVisualStyleBackColor = true;
            this.radOverall.CheckedChanged += new System.EventHandler(this.rad_CheckedChanged);
            //
            // btnRefresh
            //
            this.btnRefresh.Location = new System.Drawing.Point(520, 18);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 30);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            //
            // dgStats
            //
            this.dgStats.AllowUserToAddRows = false;
            this.dgStats.AllowUserToDeleteRows = false;
            this.dgStats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top
            | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStats.Location = new System.Drawing.Point(15, 80);
            this.dgStats.MultiSelect = false;
            this.dgStats.Name = "dgStats";
            this.dgStats.ReadOnly = true;
            this.dgStats.RowHeadersWidth = 51;
            this.dgStats.RowTemplate.Height = 27;
            this.dgStats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgStats.Size = new System.Drawing.Size(750, 340);
            this.dgStats.TabIndex = 1;
            //
            // lblSummary
            //
            this.lblSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSummary.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(47)))), ((int)(((byte)(167)))));
            this.lblSummary.Location = new System.Drawing.Point(15, 428);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(750, 25);
            this.lblSummary.TabIndex = 2;
            this.lblSummary.Text = "统计信息";
            //
            // FrmScoreStatistics
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 465);
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.dgStats);
            this.Controls.Add(this.panelTop);
            this.Name = "FrmScoreStatistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "成绩统计";
            this.Load += new System.EventHandler(this.FrmScoreStatistics_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgStats)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgStats;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.RadioButton radByStudent;
        private System.Windows.Forms.RadioButton radByCourse;
        private System.Windows.Forms.RadioButton radOverall;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblSummary;
    }
}
