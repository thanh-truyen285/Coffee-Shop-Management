using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class BillInfo
    {
        private int id;
        public int Id { get => id; set => id = value; }

        private int billID;
        public int BillID { get => billID; set => billID = value; }

        private int foodID;
        public int FoodID { get => foodID; set => foodID = value; }

        private int countFood;
        public int CountFood { get => countFood; set => countFood = value; }
        public BillInfo(int id, int billID, int foodID, int countFood)
        {
            this.Id = id;
            this.BillID = billID;
            this.FoodID = foodID;
            this.CountFood = countFood;
        }
        public BillInfo(DataRow row)
        {
            this.Id = (int)row["idBI"];
            this.BillID = (int)row["idBill"];
            this.FoodID = (int)row["idFood"];
            this.CountFood = (int)row["countFood"];
        }
    }
}
