using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography; // thu vien ma hoa mat khau
namespace QuanLyQuanCafe.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance 
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set => instance = value; 
        }
        private AccountDAO() { }

        public bool Login(string userName, string passWord)
        {
            string query = "USP_Login @userName , @passWord";
            DataTable result = DataProvider.Instance.ExecuteQuery(query,new object[] { userName,passWord});
            return result.Rows.Count > 0;
        }
        public bool UpdateAcc(string username, string displayname, string pass, string newpass)
        {
            int result= DataProvider.Instance.ExecuteNonQuery(" EXEC UpdateAcc @username , @displayname , @pass , @newpass ",new object[] { username,displayname,pass,newpass});

            return result>0;
        }
        public Account GetAccountByUserName(string userName)
        {
            DataTable data =DataProvider.Instance.ExecuteQuery("Select * From Account WHERE UserName='" + userName+"'");
            foreach(DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }
    }
}
