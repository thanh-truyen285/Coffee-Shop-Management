using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace QuanLyQuanCafe
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn muốn thoát?","Thông báo",MessageBoxButtons.OKCancel)!= DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = this.txtUserName.Text;
            string passWord = this.txtPassWord.Text;
            if (Login(userName ,passWord))
            {
                Account loginAcc = AccountDAO.Instance.GetAccountByUserName(userName);
                fTableManager f = new fTableManager(loginAcc);
                this.Hide();// ẩn form hiện tại (fLogin)
                f.ShowDialog(); // Hiển thi form ftableManager
                this.Show(); // Sau khi tắt fTableManager hiển thị fLogin lên
            }
            else
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng!");
            }

        }
        bool Login( string userName, string passWord)
        {
            return AccountDAO.Instance.Login(userName,passWord);
        }
        private void fLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
