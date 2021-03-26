namespace QuanLyQuanCafe
{
    partial class Danhmuc
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
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.txtCategoryID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dvgdm = new System.Windows.Forms.DataGridView();
            this.idFC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameFC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel18 = new System.Windows.Forms.Panel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnDeleteCategory = new System.Windows.Forms.Button();
            this.btnEditCategory = new System.Windows.Forms.Button();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.panel11.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgdm)).BeginInit();
            this.panel18.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.panel14);
            this.panel11.Controls.Add(this.panel15);
            this.panel11.Location = new System.Drawing.Point(573, 101);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(473, 328);
            this.panel11.TabIndex = 4;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.txtCategoryName);
            this.panel14.Controls.Add(this.label7);
            this.panel14.Location = new System.Drawing.Point(3, 57);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(467, 48);
            this.panel14.TabIndex = 3;
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Location = new System.Drawing.Point(161, 12);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(303, 22);
            this.txtCategoryName.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 24);
            this.label7.TabIndex = 0;
            this.label7.Text = "Tên danh mục:";
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.txtCategoryID);
            this.panel15.Controls.Add(this.label8);
            this.panel15.Location = new System.Drawing.Point(3, 3);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(467, 48);
            this.panel15.TabIndex = 2;
            // 
            // txtCategoryID
            // 
            this.txtCategoryID.Location = new System.Drawing.Point(161, 9);
            this.txtCategoryID.Name = "txtCategoryID";
            this.txtCategoryID.Size = new System.Drawing.Size(303, 22);
            this.txtCategoryID.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 24);
            this.label8.TabIndex = 0;
            this.label8.Text = "ID:";
            // 
            // dvgdm
            // 
            this.dvgdm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgdm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idFC,
            this.nameFC});
            this.dvgdm.Location = new System.Drawing.Point(23, 101);
            this.dvgdm.Name = "dvgdm";
            this.dvgdm.RowHeadersWidth = 51;
            this.dvgdm.RowTemplate.Height = 24;
            this.dvgdm.Size = new System.Drawing.Size(535, 343);
            this.dvgdm.TabIndex = 5;
            this.dvgdm.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdm_CellClick);
            // 
            // idFC
            // 
            this.idFC.DataPropertyName = "idFC";
            this.idFC.HeaderText = "Mã loại ";
            this.idFC.MinimumWidth = 6;
            this.idFC.Name = "idFC";
            this.idFC.Width = 125;
            // 
            // nameFC
            // 
            this.nameFC.DataPropertyName = "nameFC";
            this.nameFC.HeaderText = "Tên loại";
            this.nameFC.MinimumWidth = 6;
            this.nameFC.Name = "nameFC";
            this.nameFC.Width = 125;
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.btnHuy);
            this.panel18.Controls.Add(this.btnLuu);
            this.panel18.Controls.Add(this.btnDeleteCategory);
            this.panel18.Controls.Add(this.btnEditCategory);
            this.panel18.Controls.Add(this.btnAddCategory);
            this.panel18.Location = new System.Drawing.Point(23, 30);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(535, 52);
            this.panel18.TabIndex = 6;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(426, 3);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(101, 46);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "Huỷ";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(319, 3);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(101, 46);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.Location = new System.Drawing.Point(212, 3);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(101, 46);
            this.btnDeleteCategory.TabIndex = 2;
            this.btnDeleteCategory.Text = "Xóa";
            this.btnDeleteCategory.UseVisualStyleBackColor = true;
            this.btnDeleteCategory.Click += new System.EventHandler(this.btnDeleteCategory_Click);
            // 
            // btnEditCategory
            // 
            this.btnEditCategory.Location = new System.Drawing.Point(110, 3);
            this.btnEditCategory.Name = "btnEditCategory";
            this.btnEditCategory.Size = new System.Drawing.Size(96, 46);
            this.btnEditCategory.TabIndex = 1;
            this.btnEditCategory.Text = "Sửa";
            this.btnEditCategory.UseVisualStyleBackColor = true;
            this.btnEditCategory.Click += new System.EventHandler(this.btnEditCategory_Click);
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Location = new System.Drawing.Point(3, 3);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(101, 46);
            this.btnAddCategory.TabIndex = 0;
            this.btnAddCategory.Text = "Thêm";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // Danhmuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 453);
            this.Controls.Add(this.panel18);
            this.Controls.Add(this.dvgdm);
            this.Controls.Add(this.panel11);
            this.Name = "Danhmuc";
            this.Text = "Danhmuc";
            this.Load += new System.EventHandler(this.Danhmuc_Load);
            this.panel11.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgdm)).EndInit();
            this.panel18.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dvgdm;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.Button btnEditCategory;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFC;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameFC;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.TextBox txtCategoryID;
    }
}