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
    public partial class fAccountProfile : Form
    {
        private Account loginAcc;

        public Account LoginAcc
        {
            get => loginAcc;
            set { loginAcc = value; ChangeAcc(loginAcc); }
        }
        public fAccountProfile(Account acc)
        {
            InitializeComponent();
            LoginAcc = acc;
        }
        void ChangeAcc(Account acc)
        {
            this.txtUserName.Text = LoginAcc.UserName;
            this.txtDisplayName.Text = LoginAcc.DisplayName;

        }
        void UpdateAcc()
        {
            string displayName = this.txtDisplayName.Text;
            string pass = this.txtPassWord.Text;
            string newpass = this.txtNewPass.Text;
            string repass = this.txtReEnterPass.Text;
            string username = this.txtUserName.Text;

            if (!newpass.Equals(repass))
            {
                MessageBox.Show("Vui lòng nhập đúng với mật khẩu mới!");
            }
            else
            {
                if (AccountDAO.Instance.UpdateAcc(username, displayName, pass, newpass))
                {
                    MessageBox.Show("Cập nhật thành công!");
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đúng mật khẩu!");
                }
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAcc();
        }
    }
}
