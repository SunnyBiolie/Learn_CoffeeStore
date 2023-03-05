using CoffeeStore.DAO;
using CoffeeStore.DTO;
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
    public partial class fAccInfo : Form
    {
        private Account accLogined;

        public Account AccLogined
        {
            get => accLogined;
            set
            {
                accLogined = value;
            }
        }

        public fAccInfo(Account accLogined)
        {
            InitializeComponent();

            AccLogined = accLogined;
            ChangeAccount(accLogined);
        }

        private void ChangeAccount(Account accLogined)
        {
            tBoxUserName.Text = accLogined.UserName;
            tBoxDisplayName.Text = accLogined.DisplayName;
        }

        private void UpdateAccInfo()
        {
            string displayName = tBoxDisplayName.Text;
            string userName = tBoxUserName.Text;
            string oldPass = tBoxOldPass.Text;
            string newPass = tBoxNewPass.Text;
            string reEnterPass = tBoxReNewPass.Text;

            if (!newPass.Equals(reEnterPass))
            {
                MessageBox.Show("Nhập lại mật khẩu không chính xác, xin vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (AccountDAO.Instance.UpdateAccount(displayName, userName, oldPass, newPass))
                {
                    if (MessageBox.Show("Cập nhật thông tin thành công") == DialogResult.OK)
                    {
                        btnOut_Click(new object[] { }, new EventArgs());
                    }
                    if (updateInfo != null)
                        updateInfo(this, new AccountEvent(AccountDAO.Instance.GetAccByUserName(userName)));
                }
                else
                {
                    MessageBox.Show("Xác thực mật khẩu không thành công, vui lòng kiểm tra lại mật khẩu đã nhập");
                }
            }
        }

        #region events
        private event EventHandler<AccountEvent> updateInfo;
        public event EventHandler<AccountEvent> UpdateInfo
        {
            add { updateInfo += value; }
            remove { updateInfo -= value; }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccInfo();
        }
        #endregion

        private void btnEdit_Click(object sender, EventArgs e)
        {
            tBoxDisplayName.Enabled = true;
            tBoxOldPass.Enabled = true;
            tBoxNewPass.Enabled = true;
            tBoxReNewPass.Enabled = true;
            btnUpdate.Enabled = true;
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class AccountEvent : EventArgs
    {
        private Account account;

        public Account Account { get => account; set => account = value; }

        public AccountEvent(Account acc)
        {
            this.account = acc;
        }
    }
}
