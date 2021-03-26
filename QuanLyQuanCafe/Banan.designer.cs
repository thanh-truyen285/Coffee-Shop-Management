namespace QuanLyQuanCafe
{
    partial class Banan
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
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel21 = new System.Windows.Forms.Panel();
            this.txtTrangthai = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.txtten = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.txtid = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvTable = new System.Windows.Forms.DataGridView();
            this.idTF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameTF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusTF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel20 = new System.Windows.Forms.Panel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnDeleteTable = new System.Windows.Forms.Button();
            this.btnEditTable = new System.Windows.Forms.Button();
            this.btnAddTable = new System.Windows.Forms.Button();
            this.panel12.SuspendLayout();
            this.panel21.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
            this.panel20.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.panel21);
            this.panel12.Controls.Add(this.panel13);
            this.panel12.Controls.Add(this.panel16);
            this.panel12.Location = new System.Drawing.Point(701, 66);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(473, 482);
            this.panel12.TabIndex = 8;
            // 
            // panel21
            // 
            this.panel21.Controls.Add(this.txtTrangthai);
            this.panel21.Controls.Add(this.label9);
            this.panel21.Location = new System.Drawing.Point(3, 111);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(467, 48);
            this.panel21.TabIndex = 4;
            // 
            // txtTrangthai
            // 
            this.txtTrangthai.Location = new System.Drawing.Point(124, 9);
            this.txtTrangthai.Multiline = true;
            this.txtTrangthai.Name = "txtTrangthai";
            this.txtTrangthai.Size = new System.Drawing.Size(328, 31);
            this.txtTrangthai.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 24);
            this.label9.TabIndex = 0;
            this.label9.Text = "Trạng thái:";
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.txtten);
            this.panel13.Controls.Add(this.label5);
            this.panel13.Location = new System.Drawing.Point(3, 57);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(467, 48);
            this.panel13.TabIndex = 3;
            // 
            // txtten
            // 
            this.txtten.Location = new System.Drawing.Point(124, 9);
            this.txtten.Multiline = true;
            this.txtten.Name = "txtten";
            this.txtten.Size = new System.Drawing.Size(328, 31);
            this.txtten.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tên bàn:";
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.txtid);
            this.panel16.Controls.Add(this.label6);
            this.panel16.Location = new System.Drawing.Point(3, 3);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(467, 48);
            this.panel16.TabIndex = 2;
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(124, 12);
            this.txtid.Multiline = true;
            this.txtid.Name = "txtid";
            this.txtid.ReadOnly = true;
            this.txtid.Size = new System.Drawing.Size(328, 30);
            this.txtid.TabIndex = 2;
            this.txtid.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "ID:";
            // 
            // dgvTable
            // 
            this.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idTF,
            this.nameTF,
            this.statusTF});
            this.dgvTable.Location = new System.Drawing.Point(12, 110);
            this.dgvTable.Name = "dgvTable";
            this.dgvTable.RowHeadersWidth = 51;
            this.dgvTable.RowTemplate.Height = 24;
            this.dgvTable.Size = new System.Drawing.Size(674, 438);
            this.dgvTable.TabIndex = 5;
            this.dgvTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTable_CellClick);
            // 
            // idTF
            // 
            this.idTF.DataPropertyName = "idTF";
            this.idTF.HeaderText = "Mã bàn";
            this.idTF.MinimumWidth = 6;
            this.idTF.Name = "idTF";
            this.idTF.Width = 125;
            // 
            // nameTF
            // 
            this.nameTF.DataPropertyName = "nameTF";
            this.nameTF.HeaderText = "Tên bàn";
            this.nameTF.MinimumWidth = 6;
            this.nameTF.Name = "nameTF";
            this.nameTF.Width = 125;
            // 
            // statusTF
            // 
            this.statusTF.DataPropertyName = "statusTF";
            this.statusTF.HeaderText = "Trạng thái";
            this.statusTF.MinimumWidth = 6;
            this.statusTF.Name = "statusTF";
            this.statusTF.Width = 125;
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.btnHuy);
            this.panel20.Controls.Add(this.btnLuu);
            this.panel20.Controls.Add(this.btnDeleteTable);
            this.panel20.Controls.Add(this.btnEditTable);
            this.panel20.Controls.Add(this.btnAddTable);
            this.panel20.Location = new System.Drawing.Point(12, 32);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(576, 52);
            this.panel20.TabIndex = 9;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(458, 3);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(109, 46);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "Huỷ";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(350, 3);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(102, 46);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnDeleteTable
            // 
            this.btnDeleteTable.Location = new System.Drawing.Point(230, 3);
            this.btnDeleteTable.Name = "btnDeleteTable";
            this.btnDeleteTable.Size = new System.Drawing.Size(114, 46);
            this.btnDeleteTable.TabIndex = 2;
            this.btnDeleteTable.Text = "Xóa";
            this.btnDeleteTable.UseVisualStyleBackColor = true;
            this.btnDeleteTable.Click += new System.EventHandler(this.btnDeleteTable_Click);
            // 
            // btnEditTable
            // 
            this.btnEditTable.Location = new System.Drawing.Point(119, 3);
            this.btnEditTable.Name = "btnEditTable";
            this.btnEditTable.Size = new System.Drawing.Size(105, 46);
            this.btnEditTable.TabIndex = 1;
            this.btnEditTable.Text = "Sửa";
            this.btnEditTable.UseVisualStyleBackColor = true;
            this.btnEditTable.Click += new System.EventHandler(this.btnEditTable_Click);
            // 
            // btnAddTable
            // 
            this.btnAddTable.Location = new System.Drawing.Point(3, 3);
            this.btnAddTable.Name = "btnAddTable";
            this.btnAddTable.Size = new System.Drawing.Size(110, 46);
            this.btnAddTable.TabIndex = 0;
            this.btnAddTable.Text = "Thêm";
            this.btnAddTable.UseVisualStyleBackColor = true;
            this.btnAddTable.Click += new System.EventHandler(this.btnAddTable_Click);
            // 
            // Banan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 560);
            this.Controls.Add(this.panel20);
            this.Controls.Add(this.dgvTable);
            this.Controls.Add(this.panel12);
            this.Name = "Banan";
            this.Text = "Banan";
            this.Load += new System.EventHandler(this.Banan_Load);
            this.panel12.ResumeLayout(false);
            this.panel21.ResumeLayout(false);
            this.panel21.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
            this.panel20.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel21;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTF;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameTF;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusTF;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnDeleteTable;
        private System.Windows.Forms.Button btnEditTable;
        private System.Windows.Forms.Button btnAddTable;
        private System.Windows.Forms.TextBox txtten;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.TextBox txtTrangthai;
    }
}