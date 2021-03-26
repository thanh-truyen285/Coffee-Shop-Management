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
    public partial class Banan : Form
    {
        private string strConnectionSTR = @"Data Source=DESKTOP-3PF65DQ\SQLEXPRESS;Initial Catalog=QuanLyQuanCafe;Integrated Security = True";
        SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào DataTable dtFoodCategory
        SqlDataAdapter daTableFood = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtTableFood = null;
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu
        //DataSet dsBanAn = new DataSet();
        bool Them;
        public Banan()
        {
            InitializeComponent();
        }

        private void Banan_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        void LoadData()
        {
            //string strBanAn;
            try
            {
                Enabled = true;
                // Khởi động connection
                conn = new SqlConnection(strConnectionSTR);

                // Vận chuyển dữ liệu vào DataTable dtFoodCategory
                daTableFood = new SqlDataAdapter("SELECT * FROM TableFood", conn);
                dtTableFood = new DataTable();
                dtTableFood.Clear();
                daTableFood.Fill(dtTableFood);


                //strBanAn = cbTrangthai.SelectedValue.ToString();

                //dsBanAn.Tables.Add("TableFood");
                //dsBanAn.Tables["TableFood"].Columns.Add("statusTF");
                //dsBanAn.Tables["TableFood"].Rows.Add("1");
                //dsBanAn.Tables["TableFood"].Rows.Add("0");
                //cbTrangthai.DataSource = dsBanAn;
                //cbTrangthai.DisplayMember = "TableFood.statusTF";
                // Đưa dữ liệu lên DataGridView
                dgvTable.DataSource = dtTableFood;
                // Xóa trống các đối tượng trong Panel
                this.txtid.ResetText();
                this.txtten.ResetText();
                this.txtTrangthai.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy
                this.btnLuu.Enabled = false;
                this.btnHuy.Enabled = false;
                //this.panel1.Enabled = true;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
                this.btnAddTable.Enabled = true;
                this.btnEditTable.Enabled = true;
                this.btnDeleteTable.Enabled = true;
                this.btnLuu.Enabled = true;
                this.btnHuy.Enabled = true;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table TableFood.Lỗi rồi!!!");
            }
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            // Khai báo biến traloi
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp
            traloi = MessageBox.Show("Bạn muôn xoá?", "Thông báo",MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không?
            if (traloi == DialogResult.OK)
            {
                // Mở kết nối
                conn.Open();
                try
                {

                    // Thực hiện lệnh
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    // Lấy thứ tự record hiện hành
                    int r = dgvTable.CurrentCell.RowIndex;
                    // Lấy MaKH của record hiện hành
                    string strMAF = dgvTable.Rows[r].Cells[0].Value.ToString();
                    // Viết câu lệnh SQL
                    cmd.CommandText = System.String.Concat("Delete From TableFood Where idTF = '" + strMAF + "'");
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
                // Đóng kết nối
                conn.Close();
            }
            else
            {
                LoadData();
            }
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them
            Them = true;
            // Xóa trống các đối tượng trong Panel
            this.txtid.ResetText();
            this.txtten.ResetText();
            this.txtTrangthai.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;

            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnAddTable.Enabled = false;
            this.btnEditTable.Enabled = false;
            this.btnDeleteTable.Enabled = false;
            // Đưa con trỏ đến TextField 
            this.txtten.Focus();
        }

        private void btnEditTable_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;
            // Thứ tự dòng hiện hành
            int r = dgvTable.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtid.Text =
            dgvTable.Rows[r].Cells[0].Value.ToString();
            this.txtten.Text = dgvTable.Rows[r].Cells[1].Value.ToString();
            //this.cbTrangthai.Text = dgvTable.Rows[r].Cells[2].Value.ToString();
            this.txtTrangthai.Text = dgvTable.Rows[r].Cells[2].Value.ToString();
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnAddTable.Enabled = false;
            this.btnEditTable.Enabled = false;
            this.btnHuy.Enabled = true;
            // Đưa con trỏ đến TextField txtMaKH
            this.txtten.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            this.txtid.ResetText();
            this.txtten.ResetText();
            //this.txtTrangthai.ResetText();
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            this.btnAddTable.Enabled = true;
            this.btnEditTable.Enabled = true;
            this.btnDeleteTable.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //string strBanAn;
            // Mở kết nối
            conn.Open();
            // Thêm dữ liệu
            if (Them)
            {
                try
                {
                   //cbTrangthai.ValueMember = "TableFood.statusTF";
                    // Thực hiện lệnh
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    // Lệnh Insert InTo
                    // '"+ +"'
                    cmd.CommandText = System.String.Concat("Insert Into TableFood Values(" + "'" +
                    this.txtten.Text.ToString() + "','" +
                    this.txtTrangthai.Text.ToString() + 
                    "')");
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
                    int r = dgvTable.CurrentCell.RowIndex;
                    // MaKH hiện hành
                    string strMAF = dgvTable.Rows[r].Cells[0].Value.ToString();
                    // Câu lệnh SQL
                    cmd.CommandText = System.String.Concat("Update TableFood Set nameTF = '" +
                    this.txtten.Text.ToString() + "', statusTF= '" +
                    this.txtTrangthai.Text.ToString() +
                    "' Where idTF = '" + strMAF + "'");
                    // Cập nhật
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    // Load lại dữ liệu trên DataGridView
                    LoadData();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không sửa được. Lỗi rồi!");
                }
            }
            // Đóng kết nối
            conn.Close();
        }

        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dgvTable.Rows[index];
            txtid.Text = selectedRow.Cells["idTF"].Value.ToString();
            txtten.Text = selectedRow.Cells["nameTF"].Value.ToString();
            txtTrangthai.Text = selectedRow.Cells["statusTF"].Value.ToString();
        }
    }
}
