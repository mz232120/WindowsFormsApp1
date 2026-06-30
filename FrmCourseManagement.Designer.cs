namespace WindowsFormsApp1
{
    partial class FrmCourseManagement
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
            this.dgCourse = new System.Windows.Forms.DataGridView();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgCourse)).BeginInit();
            this.SuspendLayout();
            //
            // lblSearch
            //
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(30, 25);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(67, 15);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "搜索内容";
            //
            // txtContent
            //
            this.txtContent.Location = new System.Drawing.Point(110, 22);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(250, 25);
            this.txtContent.TabIndex = 1;
            //
            // btnQuery
            //
            this.btnQuery.Location = new System.Drawing.Point(380, 20);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(80, 30);
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            //
            // btnRemove
            //
            this.btnRemove.Location = new System.Drawing.Point(480, 20);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(80, 30);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "删除";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            //
            // btnModify
            //
            this.btnModify.Location = new System.Drawing.Point(580, 20);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(80, 30);
            this.btnModify.TabIndex = 5;
            this.btnModify.Text = "修改";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            //
            // dgCourse
            //
            this.dgCourse.AllowUserToAddRows = false;
            this.dgCourse.AllowUserToDeleteRows = false;
            this.dgCourse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top
            | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgCourse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCourse.Location = new System.Drawing.Point(30, 70);
            this.dgCourse.MultiSelect = false;
            this.dgCourse.Name = "dgCourse";
            this.dgCourse.ReadOnly = true;
            this.dgCourse.RowHeadersWidth = 51;
            this.dgCourse.RowTemplate.Height = 27;
            this.dgCourse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCourse.Size = new System.Drawing.Size(630, 320);
            this.dgCourse.TabIndex = 4;
            //
            // FrmCourseManagement
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 410);
            this.Controls.Add(this.dgCourse);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.lblSearch);
            this.Name = "FrmCourseManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "学科管理";
            this.Load += new System.EventHandler(this.FrmCourseManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCourse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgCourse;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Label lblSearch;
    }
}
