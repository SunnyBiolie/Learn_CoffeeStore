using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.DTO
{
    public class InterfaceBillInfo
    {
        private string foodName;
        private int foodCount;
        private float foodPrice;
        private float totalPrice;

        public string FoodName { get => foodName; set => foodName = value; }
        public int FoodCount { get => foodCount; set => foodCount = value; }
        public float FoodPrice { get => foodPrice; set => foodPrice = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }

        public InterfaceBillInfo(string foodName, int foodCount, float foodPrice, float totalPrice = 0)
        {
            this.foodName = foodName;
            this.foodCount = foodCount;
            this.foodPrice = foodPrice;
        }
        public InterfaceBillInfo(DataRow row)
        {
            this.foodName = row["TenMon"].ToString();
            this.foodCount = (int)row["SoLuong"];
            this.foodPrice = Convert.ToSingle(row["GiaMonAn"].ToString());
            this.totalPrice = Convert.ToSingle(row["ThanhTien"].ToString()); ;
        }
    }

    public class InterfaceFoodInfo
    {
        private int id;
        private string foodName;
        private string categoryName;
        private float foodPrice;

        public int Id { get => id; set => id = value; }
        public string FoodName { get => foodName; set => foodName = value; }
        public string CategoryName { get => categoryName; set => categoryName = value; }
        public float FoodPrice { get => foodPrice; set => foodPrice = value; }

        public InterfaceFoodInfo(int id, string foodName, string categoryName, float foodPrice)
        {
            this.id = id;
            this.foodName= foodName;
            this.categoryName= categoryName;
            this.foodPrice = foodPrice;
        }

        public InterfaceFoodInfo(DataRow row)
        {
            this.id = (int)row["ID"];
            this.foodName = row["TenMon"].ToString();
            this.categoryName = row["TenDM"].ToString();
            this.foodPrice = Convert.ToSingle(row["GiaMonAn"]);
        }
    }
}
