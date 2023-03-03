using CoffeeStore.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeStore
{
    public partial class fAdmin : Form
    {
        public fAdmin()
        {
            InitializeComponent();

            dtGVAcc.DataSource = DataProvider.Instance.ExecuteQuery("select * from TaiKhoan where TenDangNhap = @username1 or TenDangNhap = @username2", new object[] {"admin", "thu123"});
        }
    }
}
