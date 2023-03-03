using CoffeeStore.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;
        public static BillInfoDAO Instance
        {
            get
            {
                if (instance == null) { instance = new BillInfoDAO(); }
                return instance;
            }
            private set => BillInfoDAO.instance = value;
        }
        private BillInfoDAO() { }

        /// <summary>
        /// Return danh sách chi tiết hóa đơn từ ID của một hóa đơn
        /// </summary>
        /// <param name="billID"></param>
        /// <returns></returns>
        public List<BillInfo> GetListBillInfo(int billID)
        {
            List<BillInfo> billInfos = new List<BillInfo>();
            DataTable data = DataProvider.Instance.ExecuteQuery($"select * from ChiTietHoaDon where idHoaDon = {billID}");
            foreach (DataRow row in data.Rows)
            {
                BillInfo BillInfo = new BillInfo(row);
                billInfos.Add(BillInfo);
            }

            return billInfos;
        }

        public void InsertBillInfo(int idBill, int idFood, int foodCount)
        {
            string query = "USP_InsertBillInfo @idHoaDon , @idMonAn , @SoLuong";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { idBill, idFood, foodCount });
        }
    }
}
