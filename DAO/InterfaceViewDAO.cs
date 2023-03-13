using CoffeeStore.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.DAO
{
    public class InterfaceBillInfoDAO
    {
        private static InterfaceBillInfoDAO instance;
        public static InterfaceBillInfoDAO Instance
        {
            get
            {
                if (instance == null) instance = new InterfaceBillInfoDAO();
                return InterfaceBillInfoDAO.instance;
            }
            private set => InterfaceBillInfoDAO.instance = value;
        }
        private InterfaceBillInfoDAO() { }

        public List<InterfaceBillInfo> GetListInterfaceBillInfoByTableID(int tableID)
        {
            List<InterfaceBillInfo> listMenu = new List<InterfaceBillInfo>();

            string query = $"select fd.TenMon, ctb.SoLuong, fd.GiaMonAn, fd.GiaMonAn*ctb.SoLuong as ThanhTien from ChiTietHoaDon as ctb, HoaDon as b, MonAn as fd\r\nwhere ctb.idHoaDon = b.ID and ctb.idMonAn = fd.ID and b.idBan = {tableID} and b.TrangThai = 0";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                InterfaceBillInfo menu = new InterfaceBillInfo(row);
                listMenu.Add(menu);
            }

            return listMenu;
        }
    }
   
    public class InterfaceRevenueByDateDAO
    {
        private static InterfaceRevenueByDateDAO instance;
        public static InterfaceRevenueByDateDAO Instance
        {
            get
            {
                if (instance == null) instance = new InterfaceRevenueByDateDAO();
                return InterfaceRevenueByDateDAO.instance;
            }
            private set => InterfaceRevenueByDateDAO.instance = value;
        }
        private InterfaceRevenueByDateDAO() { }

        public List<InterfaceRevenueByDate> GetListBillByDate(DateTime dateCheckIn, DateTime dateCheckOut)
        {
            List<InterfaceRevenueByDate> list = new List<InterfaceRevenueByDate>();

            string query = $"exec USP_GetListBillByDate @NgayVao , @NgayRa";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { dateCheckIn, dateCheckOut });

            foreach (DataRow row in data.Rows)
            {
                InterfaceRevenueByDate bill = new InterfaceRevenueByDate(row);
                list.Add(bill);
            }

            return list;
        }
    }
    
    public class InterfaceRevenueDAO
    {
        private static InterfaceRevenueDAO instance;
        public static InterfaceRevenueDAO Instance
        {
            get
            {
                if (instance == null) instance = new InterfaceRevenueDAO();
                return InterfaceRevenueDAO.instance;
            }
            private set => InterfaceRevenueDAO.instance = value;
        }
        public InterfaceRevenueDAO() { }

        public List<InterfaceRevenue> GetListInterfaceRevenues(string billID)
        {
            List<InterfaceRevenue> list = new List<InterfaceRevenue>();

            string query = $"select TenMon, SoLuong from ChiTietHoaDon, HoaDon, MonAn where HoaDon.ID = @billID and HoaDon.ID = idHoaDon and idMonAn = MonAn.ID";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { billID });

            foreach (DataRow row in data.Rows)
            {
                InterfaceRevenue line = new InterfaceRevenue(row);
                list.Add(line);
            }

            return list;
        }
    }

    public class InterfaceFoodInfoDAO
    {
        private static InterfaceFoodInfoDAO instance;
        public static InterfaceFoodInfoDAO Instance
        {
            get
            {
                if (instance == null) instance= new InterfaceFoodInfoDAO();
                return InterfaceFoodInfoDAO.instance;
            }
            private set => instance = value;
        }

        private InterfaceFoodInfoDAO() { }

        public List<InterfaceFoodInfo> GetListInterfaceFoodInfo(string orderBy = "order by ID")
        {
            List<InterfaceFoodInfo> list = new List<InterfaceFoodInfo>();

            string query = $"select * from View_AdminFood {orderBy}";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach(DataRow row in data.Rows)
            {
                InterfaceFoodInfo line = new InterfaceFoodInfo(row);
                list.Add(line);
            }

            return list;
        }

        /// <summary>
        /// Hỗ trợ cấp dữ liệu cho FindFoodByName
        /// </summary>
        /// <param name="approName"></param>
        /// <returns></returns>
        public List<InterfaceFoodInfo> GetListFoodByName(string approName, string orderBy = "order by ID")
        {
            List<InterfaceFoodInfo> list = new List<InterfaceFoodInfo>();

            string query = $"select * from View_AdminFood where dbo.fuConvertToUnsign_STR(TenMon) like N'%' + dbo.fuConvertToUnsign_STR( @approName ) + '%' {orderBy}";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { approName });

            foreach (DataRow row in data.Rows)
            {
                InterfaceFoodInfo food = new InterfaceFoodInfo(row);
                list.Add(food);
            }

            return list;
        }
    }
    
    public class InterfaceAccInfoDAO
    {
        private static InterfaceAccInfoDAO instance;
        public static InterfaceAccInfoDAO Instance
        {
            get
            {
                if (instance == null) instance = new InterfaceAccInfoDAO();
                return InterfaceAccInfoDAO.instance;
            }
            private set => instance = value;
        }

        private InterfaceAccInfoDAO() { }

        public List<InterfaceAccInfo> GetAccountsList()
        {
            List<InterfaceAccInfo> list = new List<InterfaceAccInfo>();

            string query = $"select TenDangNhap, TenHienThi, PhanQuyen, PhanLoai from TaiKhoan, PhanQuyen where PhanQuyen = MaPhanLoai";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                InterfaceAccInfo acc = new InterfaceAccInfo(row);
                list.Add(acc);
            }

            return list;
        }
    }
}
