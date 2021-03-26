using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyQuanCafe
{
    public partial class Danhmuc : Form
    {
        private string strConnectionSTR = @"Data Source=DESKTOP-3PF65DQ\SQLEXPRESS;Initial Catalog=QuanLyQuanCafe;Integrated Security = True";
        // Đối tượng kết nối
        SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào DataTable dtFoodCategory
        SqlDataAdapter daFoodCategory = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtFoodCategory = null;
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu
        bool Them;
        public Danhmuc()
        {
            InitializeComponent();
        }

        private void Danhmuc_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        void LoadData()
        {
            try
            {
                Enabled = true;
                // Khởi động connection
                conn = new SqlConnection(strConnectionSTR);

                // Vận chuyển dữ liệu vào DataTable dtFoodCategory
                daFoodCategory = new SqlDataAdapter("SELECT * FROM FoodCategory", conn);
                dtFoodCategory = new DataTable();
                dtFoodCategory.Clear();
                daFoodCategory.Fill(dtFoodCategory);
                // Đưa dữ liệu lên DataGridView
                dvgdm.DataSource = dtFoodCategory;
                // Xóa trống các đối tượng trong Panel
                this.txtCategoryID.ResetText();
                this.txtCategoryName.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy
                this.btnLuu.Enabled = false;
                this.btnHuy.Enabled = false;
                //this.panel1.Enabled = true;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
                this.btnAddCategory.Enabled = true;
                this.btnEditCategory.Enabled = true;
                this.btnDeleteCategory.Enabled = true;
                this.btnLuu.Enabled = true;
                this.btnHuy.Enabled = true;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table Category.Lỗi rồi!!!");
            }
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            // Mở kết nối
            conn.Open();
            DialogResult tl;
            tl = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tl == DialogResult.OK)
            {
                try
                {

                    // Thực hiện lệnh
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    // Lấy thứ tự record hiện hành
                    int r = dvgdm.CurrentCell.RowIndex;
                    // Lấy MaKH của record hiện hành
                    string strMAF = dvgdm.Rows[r].Cells[0].Value.ToString();
                    // Viết câu lệnh SQL
                    cmd.CommandText = System.String.Concat("Delete From FoodCategory Where idFC = '" + strMAF + "'");
                    cmd.CommandType = CommandType.Text;
                    // Thực hiện câu lệnh SQL
                    cmd.ExecuteNonQuery();
                    // Cập nhật lại DataGridView
                    LoadData();
                    // Thông báo
                    MessageBox.Show("Đã xóa xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không xóa được. Lỗi rồi!!!");
                }
            }
            
            // Đóng kết nối
            conn.Close();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them
            Them = true;
            // Xóa trống các đối tượng trong Panel
            this.txtCategoryID.Enabled = false;
            this.txtCategoryName.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;

            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnAddCategory.Enabled = false;
            this.btnEditCategory.Enabled = false;
            this.btnDeleteCategory.Enabled = false;
            // Đưa con trỏ đến TextField 
            this.txtCategoryName.Focus();
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;
            // Thứ tự dòng hiện hành
            int r = dvgdm.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtCategoryID.Text =
            dvgdm.Rows[r].Cells[0].Value.ToString();
            this.txtCategoryName.Text = dvgdm.Rows[r].Cells[1].Value.ToString();
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnAddCategory.Enabled = false;
            this.btnEditCategory.Enabled = false;
            this.btnDeleteCategory.Enabled = false;
            // Đưa con trỏ đến TextField txtMaKH
            this.txtCategoryName.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            this.txtCategoryName.ResetText();
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            this.btnAddCategory.Enabled = true;
            this.btnEditCategory.Enabled = true;
            this.btnDeleteCategory.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
        }
        private void Danhmuc_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Giải phóng tài nguyên
            dtFoodCategory.Dispose();
            dtFoodCategory = null;
            // Hủy kết nối
            conn = null;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Mở kết nối
            conn.Open();
            // Thêm dữ liệu
            if (Them)
            {
                try
                {
                    // Thực hiện lệnh
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    // Lệnh Insert InTo
                    // '"+ +"'
                    cmd.CommandText = System.String.Concat("Insert Into FoodCategory Values(" + "'" +
                    // this.txtFoodID.Text.ToString() + "','" +
                    this.txtCategoryName.Text.ToString() + "')");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    // Load lại dữ liệu trên DataGridView
                    LoadData();
                    // Thông báo
                    MessageBox.Show("Đã thêm xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }
            }
            if (!Them)
            {
                try
                {
                    // Thực hiện lệnh
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    // Thứ tự dòng hiện hành
                    int r =dvgdm.CurrentCell.RowIndex;
                    // MaKH hiện hành
                    string strMAF = dvgdm.Rows[r].Cells[0].Value.ToString();
                    // Câu lệnh SQL
                    cmd.CommandText = System.String.Concat("Update FoodCategory Set nameFC = '" +
                    this.txtCategoryName.Text.ToString()  + "' Where idFC = '" + strMAF + "'");
                    // Cập nhật
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    // Load lại dữ liệu trên DataGridView
                    LoadData();
                    // Thông báo
                    MessageBox.Show("Đã sửa xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không sửa được. Lỗi rồi!");
                }
            }
            // Đóng kết nối
            conn.Close();
        }
        private void dgvdm_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dvgdm.Rows[index];
            txtCategoryID.Text = selectedRow.Cells["idFC"].Value.ToString();
            txtCategoryName.Text = selectedRow.Cells["nameFC"].Value.ToString();
        }
    }
}
