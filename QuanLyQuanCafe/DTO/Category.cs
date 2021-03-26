using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Category
    {
        private int iD;

        public int ID { get => iD; set => iD = value; }

        private string name;
        public string Name { get => name; set => name = value; }
        public Category(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
        public Category(DataRow row)
        {
            this.ID = (int)row["idFC"];
            this.Name = row["nameFC"].ToString();
        }
    }
}
