using CoffeeStore.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;
        public static AccountDAO Instance
        {
            get
            {
                if (instance == null) instance = new AccountDAO();
                return AccountDAO.instance;
            }
            private set => AccountDAO.instance = value;
        }
        private AccountDAO() { }

        public bool Login(string username, string password)
        {
            string query = "select * from dbo.TaiKhoan where TenDangNhap = @username and MatKhau = @password";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] {username, password});
            return result.Rows.Count > 0;
        }

        public Account GetAccByUserName(string userName)
        {
            string query = $"select * from TaiKhoan where TenDangNhap = @username";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] {userName});
            foreach (DataRow row in data.Rows)
            {
                return new Account(row);
            }

            return null;
        }

        //public int GetTypeByUserName(string userName)
        //{
        //    string query = $"select PhanQuyen from TaiKhoan where TenDangNhap = N'{userName}'";
        //    DataTable data = DataProvider.Instance.ExecuteQuery(query);
        //    return (int)data.Rows[0][0];
        //}

        public bool UpdateAccount(string displayName, string userName, string oldPass, string newPass)
        {
            string query = "exec USP_UpdateAccInfo @TenHienThi , @TenDangNhap , @MatKhau , @MatKhauMoi";
            int lineCount = DataProvider.Instance.ExecuteNonQuery(query, new object[] {displayName, userName, oldPass, newPass});

            return lineCount > 0;
        }
    }
}
