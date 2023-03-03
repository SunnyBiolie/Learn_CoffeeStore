using CoffeeStore.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.DAO
{
    // Lấy ra hóa đơn từ id của bàn
    public class BillDAO
    {
        private static BillDAO instance;
        public static BillDAO Instance
        {
            get
            {
                if (instance == null) instance = new BillDAO();
                return BillDAO.instance;
            }
            private set { BillDAO.instance = value; }
        }
        private BillDAO() { }

        /// <summary>
        /// Return billID nếu bàn có hóa đơn chưa thanh toán;
        /// Return -1 nếu bàn không có hóa đơn chưa thanh toán
        /// </summary>
        /// <param name="tableID"></param>
        /// <returns>billID || -1</returns>
        public int GetUncheckBillIDByTableID(int tableID)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery($"select * from HoaDon where idBan = {tableID} and TrangThai = 0");
            if (data.Rows.Count > 0)
            {
                //Bill bill = new Bill(data.Rows[0]);
                //return bill.BillID;

                return (int)data.Rows[0][0];
            }
            return -1;
        }

        public void InsertBill(int idTable)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_InsertBill @idBan", new object[] {idTable});
        }
        /// <summary>
        /// Được gọi: btnAddFood_Click / fHome.cs
        /// </summary>
        /// <returns>ID của HoaDon vừa được insert</returns>
        public int GetMaxIDBill()
        {
            return (int)DataProvider.Instance.ExecuteScalar("select max(ID) from HoaDon");
        }
        public void CheckOut(int idBill)
        {
            string query = $"update HoaDon set TrangThai = 1 where ID = {idBill}";
            DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}
