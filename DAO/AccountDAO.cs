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
    }
}
