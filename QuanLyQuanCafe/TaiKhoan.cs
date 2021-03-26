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
    public partial class TaiKhoan : Form
    {
        private string strConnectionSTR = @"Data Source=DESKTOP-3PF65DQ\SQLEXPRESS;Initial Catalog=QuanLyQuanCafe;Integrated Security = True";
        // Đối tượng kết nối
        SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào DataTable dtFoodCategory
        SqlDataAdapter daAccount = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtAccount = null;
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu
        bool Them;
        public TaiKhoan()
        {
            InitializeComponent();
        }

        private void TaiKhoan_Load(object sender, EventArgs e)
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
                daAccount = new SqlDataAdapter("SELECT * FROM Account", conn);
                dtAccount = new DataTable();
                dtAccount.Clear();
                daAccount.Fill(dtAccount);
                // Đưa dữ liệu lên DataGridView
                dgvAccount.DataSource = dtAccount;
                // Xóa trống các đối tượng trong Panel
                this.txtttk.ResetText();
                this.txtht.ResetText();
                this.txtLtk.ResetText();
                this.txtMK.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy
                this.btnLuu.Enabled = false;
                this.btnHuy.Enabled = false;
                //this.panel1.Enabled = true;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
                this.btnAddAccount.Enabled = true;
                this.btnEditAccount.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnLuu.Enabled = true;
                this.btnHuy.Enabled = true;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table Category.Lỗi rồi!!!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
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
                    int r = dgvAccount.CurrentCell.RowIndex;
                    // Lấy MaKH của record hiện hành
                    string strMAF = dgvAccount.Rows[r].Cells[0].Value.ToString();
                    // Viết câu lệnh SQL
                    cmd.CommandText = System.String.Concat("Delete From Account Where UserName = '" + strMAF + "'");
                    cmd.CommandType = CommandType.Text;
                    // Thực hiện câu lệnh SQL
                    cmd.ExecuteNonQuery();
                    // Cập nhật lại DataGridView
                    LoadData();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không xóa được. Lỗi rồi!!!");
                }
            }
            // Đóng kết nối
            conn.Close();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them
            Them = true;
            // Xóa trống các đối tượng trong Panel
            this.txtttk.ResetText();
            this.txtht.ResetText();
            this.txtLtk.ResetText();
            this.txtMK.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;

            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnAddAccount.Enabled = false;
            this.btnEditAccount.Enabled = false;
            this.btnXoa.Enabled = false;
            // Đưa con trỏ đến TextField 
            this.txtttk.Focus();
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;
            // Thứ tự dòng hiện hành
            int r = dgvAccount.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtttk.Text =
            dgvAccount.Rows[r].Cells[0].Value.ToString();
            this.txtht.Text = dgvAccount.Rows[r].Cells[1].Value.ToString();
            this.txtMK.Text = dgvAccount.Rows[r].Cells[2].Value.ToString();
            this.txtLtk.Text = dgvAccount.Rows[r].Cells[3].Value.ToString();
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnAddAccount.Enabled = false;
            this.btnEditAccount.Enabled = false;
            this.btnHuy.Enabled = true;
            // Đưa con trỏ đến TextField txtMaKH
            this.txtttk.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            this.txtttk.ResetText();
            this.txtht.ResetText();
            this.txtMK.ResetText();
            this.txtLtk.ResetText();
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            this.btnAddAccount.Enabled = true;
            this.btnAddAccount.Enabled = true;
            this.btnXoa.Enabled = true;
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
                    cmd.CommandText = System.String.Concat("Insert Into Account Values(" + "'" +
                    this.txtttk.Text.ToString() + "','" +
                    this.txtht.Text.ToString() + "','" +
                    this.txtMK.Text.ToString() + "','" +
                    this.txtLtk.Text.ToString() + "')");
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
                    int r = dgvAccount.CurrentCell.RowIndex;
                    // MaKH hiện hành
                    string strMAF = dgvAccount.Rows[r].Cells[0].Value.ToString();
                    // Câu lệnh SQL
                    cmd.CommandText = System.String.Concat("Update Account Set UserName = '" +
                    this.txtttk.Text.ToString() + "', DisplayName= '" +
                    this.txtht.Text.ToString() + "', PassWord= '" +
                    this.txtMK.Text.ToString() + "', TypeAcc= '" +
                    this.txtLtk.Text.ToString() + "' Where UserName = '" + strMAF + "'");
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

        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dgvAccount.Rows[index];
            txtttk.Text = selectedRow.Cells["UserName"].Value.ToString();
            txtht.Text = selectedRow.Cells["DisplayName"].Value.ToString();
            txtMK.Text = selectedRow.Cells["PassWord"].Value.ToString();
            txtLtk.Text = selectedRow.Cells["TypeAcc"].Value.ToString();
        }
    }
}
