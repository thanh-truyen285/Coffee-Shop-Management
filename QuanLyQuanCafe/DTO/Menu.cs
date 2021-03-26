﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Menu
    {
        private string foodName;

        public string FoodName { get => foodName; set => foodName = value; }

        private int countFood;
        public int CountFood { get => countFood; set => countFood = value; }

        private float price;
        public float Price { get => price; set => price = value; }

        private float totalPrice;
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
        public Menu(string foodName, int count, float price, float totalPrice=0)
        {
            this.FoodName = foodName;
            this.CountFood = count;
            this.Price = price;
            this.TotalPrice = totalPrice;
        }
        public Menu(DataRow  row)
        {
            this.FoodName = row["nameFood"].ToString();
            this.CountFood = (int)row["countFood"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
            this.TotalPrice = (float)Convert.ToDouble(row["totalPrice"].ToString());
        }
    }
}
