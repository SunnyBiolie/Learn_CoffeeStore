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
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = tBoxUserName.Text;
            string pass = tBoxPass.Text;
            if (isMember(userName, pass))
            {
                this.Hide();
                fHome fHome = new fHome();
                fHome.ShowDialog();
                this.Close();
            }
            else MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
        }

        bool isMember(string userName, string pass)
        {
            return AccountDAO.Instance.Login(userName, pass);

        }
    }
}
