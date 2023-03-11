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

    public class InterfaceRevenueByDate
    {
        private int id;
        private string tableName;
        private DateTime dateCheckIn;
        private DateTime dateCheckOut;
        private float totalPrice;

        public int Id { get => id; set => id = value; }
        public string TableName { get => tableName; set => tableName = value; }
        public DateTime DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }

        public InterfaceRevenueByDate(int id, string tableName, DateTime dateCheckIn, DateTime dateCheckOut, float totalPrice)
        {
            this.id = id;
            this.tableName = tableName;
            this.dateCheckIn = dateCheckIn;
            this.dateCheckOut = dateCheckOut;
            this.totalPrice = totalPrice;
        }
        public InterfaceRevenueByDate(DataRow row)
        {
            this.id = (int)row["ID"];
            this.tableName = row["TenBan"].ToString();
            this.dateCheckIn = DateTime.Parse(row["ThoiGianVao"].ToString());
            this.dateCheckOut = DateTime.Parse(row["ThoiGianRa"].ToString());
            this.totalPrice = Convert.ToSingle(row["TongTien"]);
        }
    }

    public class InterfaceRevenue
    {
        private string foodName;
        private int foodCount;

        public string FoodName { get => foodName; set => foodName = value; }
        public int FoodCount { get => foodCount; set => foodCount = value; }

        public InterfaceRevenue(string foodName, int foodCount)
        {
            this.foodName = foodName;
            this .foodCount = foodCount;
        }

        public InterfaceRevenue(DataRow row)
        {
            this.foodName = row["TenMon"].ToString();
            this.foodCount = (int)row["SoLuong"];
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

    public class InterfaceAccInfo
    {
        private string userName;
        private string displayName;
        private int phanQuyen;
        private string phanLoai;
        public string UserName { get => userName; set => userName = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public int PhanQuyen { get => phanQuyen; set => phanQuyen = value; }
        public string PhanLoai { get => phanLoai; set => phanLoai = value; }


        public InterfaceAccInfo(string userName, string displayName, int phanQuyen, string phanLoai)
        {
            this.userName = userName;
            this.displayName = displayName;
            this.phanQuyen = phanQuyen;
            this.phanLoai = phanLoai;
        }

        public InterfaceAccInfo(DataRow row)
        {
            this.userName = row["TenDangNhap"].ToString();
            this.displayName = row["TenHienThi"].ToString();
            this.PhanQuyen = (int)row["PhanQuyen"];
            this.phanLoai = row["PhanLoai"].ToString();
        }
    }
}
