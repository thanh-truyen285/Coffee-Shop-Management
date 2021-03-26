using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
   public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance 
        {
            get { if (instance == null) instance = new BillDAO(); return instance; }
            set { instance = value; } 
        }
        private BillDAO() { }

        //Thành công : bill ID
        //Thất bại:-1
        public int GetUnCheckBillIdByTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Bill WHERE idTF="+id+" and statusBill=0");
            if(data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }
            return -1;// nghia la id=-1, la khong co bill nao het
        }
        public void CheckOut(int id,float totalprice)
        {
            string query = "UPDATE dbo.Bill SET statusBill=1, dateCheckOut=GETDATE(),totalPrice="+totalprice+" WHERE idBill=" + id;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void InsertBill(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_InsertBill @idTable", new object[]{id});
        }
        public  int GetMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(idBill) FROM Bill");
            }
            catch
            {
                return 1;
            }
            
        }
        public DataTable GetListBillByDate(DateTime checkin, DateTime checkout)
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_GetListBillByDate @checkin , @chechkout", new object[] { checkin, checkout });
        }
    }
}
