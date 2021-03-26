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
    public partial class Monan : Form
    {
        private string strConnectionSTR = @"Data Source=DESKTOP-3PF65DQ\SQLEXPRESS;Initial Catalog=QuanLyQuanCafe;Integrated Security = True";
        // Đối tượng kết nối
        SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào DataTable dtFood
        SqlDataAdapter daFood = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtFood = null;
        // Đối tượng đưa dữ liệu vào DataTable dtFoodCategory
        SqlDataAdapter daFoodCategory = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtFoodCategory = null;
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu
        bool Them;
        public Monan()
        {
            InitializeComponent();
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {

        }

        private void Monan_Load(object sender, EventArgs e)
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
                // Đưa dữ liệu lên ComboBox trong DataGridView
                (dgvFood.Columns["idFC"] as DataGridViewComboBoxColumn).DataSource = dtFoodCategory;
                (dgvFood.Columns["idFC"] as DataGridViewComboBoxColumn).DisplayMember = "nameFC";
                (dgvFood.Columns["idFC"] as DataGridViewComboBoxColumn).ValueMember = "idFC";
                // Vận chuyển dữ liệu vào DataTable dtKhachHang
                daFood = new SqlDataAdapter("SELECT * FROM Food", conn);
                dtFood = new DataTable();
                dtFood.Clear();
                daFood.Fill(dtFood);
                // Đưa dữ liệu lên DataGridView
                dgvFood.DataSource = dtFood;
                // Xóa trống các đối tượng trong Panel
                this.txtFoodID.ResetText();
                this.txtFoodName.ResetText();
                this.cbFoodCategory.ResetText();
                this.txtGia.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy
                this.btnLuu.Enabled = false;
                this.btnHuy.Enabled = false;
                //this.panel1.Enabled = true;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
                this.btnAddFood.Enabled = true;
                this.btnEditFood.Enabled = true;
                this.btnDeleteFood.Enabled = true;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table Food.Lỗi rồi!!!");
            }
        }

        private void btnDeleteFood_Click_1(object sender, EventArgs e)
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
                    int r = dgvFood.CurrentCell.RowIndex;
                    // Lấy MaKH của record hiện hành
                    string strMAF = dgvFood.Rows[r].Cells[0].Value.ToString();
                    // Viết câu lệnh SQL
                    cmd.CommandText = System.String.Concat("Delete From Food Where idFood = '" + strMAF + "'");
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

        private void Monan_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Giải phóng tài nguyên
            dtFood.Dispose();
            dtFood = null;
            // Hủy kết nối
            conn = null;
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them
            Them = true;
            // Xóa trống các đối tượng trong Panel
            this.txtFoodID.Enabled = false;
            this.txtFoodName.ResetText();
            this.txtGia.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;

            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnAddFood.Enabled = false;
            this.btnEditFood.Enabled = false;
            this.btnDeleteFood.Enabled = false;
            // Đưa dữ liệu lên ComboBox
            this.cbFoodCategory.DataSource = dtFood;
            this.cbFoodCategory.DisplayMember = "nameFC";
            this.cbFoodCategory.ValueMember = "idFC";
            // Đưa con trỏ đến TextField txtMaKH
            this.txtFoodID.Focus();
        }

        private void btnEditFood_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;
            // Đưa dữ liệu lên ComboBox
            this.cbFoodCategory.DataSource = dtFood;
            this.cbFoodCategory.DisplayMember = "nameFC";
            this.cbFoodCategory.ValueMember = "idFC";
            // Cho phép thao tác trên Panel
            // Thứ tự dòng hiện hành
            int r = dgvFood.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtFoodID.Text =
            dgvFood.Rows[r].Cells[0].Value.ToString();
            this.txtFoodName.Text = dgvFood.Rows[r].Cells[1].Value.ToString();
            this.cbFoodCategory.SelectedValue =
            dgvFood.Rows[r].Cells[2].Value.ToString();
            this.txtGia.Text =
            dgvFood.Rows[r].Cells[3].Value.ToString();
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnAddFood.Enabled = false;
            this.btnEditFood.Enabled = false;
            this.btnDeleteFood.Enabled = false;
            // Đưa con trỏ đến TextField txtMaKH
            this.txtFoodID.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            this.txtFoodID.ResetText();
            this.txtFoodName.ResetText();
            this.cbFoodCategory.ResetText();
            this.txtGia.ResetText();
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            this.btnAddFood.Enabled = true;
            this.btnEditFood.Enabled = true;
            this.btnDeleteFood.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
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
                    cmd.CommandText = System.String.Concat("Insert Into Food Values(" + "'" +
                    // this.txtFoodID.Text.ToString() + "','" +
                    this.txtFoodName.Text.ToString() + "','" +
                    this.cbFoodCategory.SelectedValue.ToString() + "','" +
                    this.txtGia.Text.ToString() + "')");
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
                    int r = dgvFood.CurrentCell.RowIndex;
                    // MaKH hiện hành
                    string strMAF = dgvFood.Rows[r].Cells[0].Value.ToString();
                    // Câu lệnh SQL
                    cmd.CommandText = System.String.Concat("Update Food Set nameFood = '" +
                    this.txtFoodName.Text.ToString() + "', idFC= '" +
                    this.cbFoodCategory.SelectedValue.ToString() + "', price = '" +
                    this.txtGia.Text.ToString() + "' Where idFood = '" + strMAF + "'");
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

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void dgvFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dgvFood.Rows[index];
            txtFoodID.Text = selectedRow.Cells["idFood"].Value.ToString();
            txtFoodName.Text = selectedRow.Cells["nameFood"].Value.ToString();
            cbFoodCategory.Text = selectedRow.Cells["idFC"].Value.ToString();
            txtGia.Text = selectedRow.Cells["price"].Value.ToString();
        }

        private void btnSearchFood_Click(object sender, EventArgs e)
        {
            try {
                conn.Open();
                string KeyWord = txtSearchFoodName.Text.Trim();
                string query = "select * from Food where nameFood LIKE '%" + KeyWord + "%' ";
                SqlCommand cmd = new SqlCommand(query,conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                
                DataSet ds = new DataSet();
                da.Fill(ds);
                dgvFood.DataSource = ds.Tables[0];
                conn.Close();
               
            }
           
            catch (SqlException)
            {
                MessageBox.Show("Không tim thay");
            }
        }
    }
}

