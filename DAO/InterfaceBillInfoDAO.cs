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
}
