using CoffeeStore.csControls;
using CoffeeStore.DAO;
using CoffeeStore.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeStore
{
    public partial class fHome : Form
    {
        private CultureInfo GE_Culture = new CultureInfo("de-DE");

        private Account accLogined;

        public Account AccLogined
        {
            get => accLogined;
            set
            {
                accLogined = value;
                Decentralization(accLogined.Type);
            }
        }

        public fHome(Account accLogined)
        {
            InitializeComponent();

            AccLogined = accLogined;

            LoadTables();
            LoadCategory();
        }

        private void Decentralization(int accType)
        {
            if (accType == 1 ) adminToolStripMenuItem.Enabled = true;
            thôngTinToolStripMenuItem.Text += $" ({AccLogined.DisplayName})";
        }

        private void LoadCategory()
        {
            List<Category> categories = CategoryDAO.Instance.GetListCategory();
            cbCategory.DataSource = categories;
            // Hiển thị trường Name của lớp Category trên comboBox
            cbCategory.DisplayMember = "Name";
        }
        private void LoadFoodListByCategoryID(int categoryID)
        {
            List<Food> foods = FoodDAO.Instance.GetListFoodByCategoryID(categoryID);
            cbBoxFood.DataSource = foods;
            cbBoxFood.DisplayMember = "Name";
        }
        private void LoadTables()
        {
            fLayoutTable.Controls.Clear();

            List<Table> tableList = TableDAO.Instance.LoadTableList();
            foreach (Table table in tableList)
            {
                csButton btn = new csButton()
                {
                    Width = TableDAO.tableWidth,
                    Height = TableDAO.tableHeight,
                    BorderSize = 1,
                    BorderRadius = 0,
                    Margin = new Padding(6),
                };
                btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btn.Text = table.Name + Environment.NewLine + table.Status;
                // Tag của button thể hiện bàn = chính bàn được chọn
                btn.Tag = table;
                btn.Click += Btn_Click;

                switch (table.Status)
                {
                    case "Trống":
                        btn.BackgroundColor = Color.FromArgb(164, 171, 182);
                        break;
                    case "Có khách":
                        btn.TextColor = Color.White;
                        btn.BackgroundColor = Color.MediumSlateBlue;
                        break;
                }

                fLayoutTable.Controls.Add(btn);
            }
        }

        /// <summary>
        /// Load lại đúng button thể hiện bàn đã chọn
        /// </summary>
        private void ReloadTable()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery($"select TrangThai from Ban where ID = {(lViewBill.Tag as Table).Id}");
            (lblCurrentTable.Tag as csButton).Text = (lViewBill.Tag as Table).Name + Environment.NewLine + data.Rows[0][0].ToString();
            switch (data.Rows[0][0].ToString())
            {
                case "Trống":
                    (lblCurrentTable.Tag as csButton).BackgroundColor = Color.FromArgb(164, 171, 182);
                    break;
                case "Có khách":
                    (lblCurrentTable.Tag as csButton).TextColor = Color.White;
                    (lblCurrentTable.Tag as csButton).BackgroundColor = Color.MediumSlateBlue;
                    break;
            }
        }
        private void ShowBill(int tableID)
        {
            lViewBill.Items.Clear();
            float totalBill = 0;

            lViewBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            columnHeader1.Width = 288;
            columnHeader2.Width = 100;
            columnHeader3.Width = 100;
            columnHeader4.Width = 100;

            List<InterfaceBillInfo> BillInfos = InterfaceBillInfoDAO.Instance.GetListInterfaceBillInfoByTableID(tableID);

            foreach (InterfaceBillInfo item in BillInfos)
            {
                ListViewItem listViewItem = new ListViewItem(item.FoodName.ToString());
                listViewItem.SubItems.Add(item.FoodCount.ToString());
                listViewItem.SubItems.Add(item.FoodPrice.ToString("#,#", GE_Culture));
                listViewItem.SubItems.Add(item.TotalPrice.ToString("#,#", GE_Culture));

                totalBill += item.TotalPrice;

                lViewBill.Items.Add(listViewItem);
            }

            CultureInfo culture = new CultureInfo("vi-VN");
            tBoxTotalPrice.Text = totalBill.ToString("c", culture);
        }

        #region Events
        private void Btn_Click(object sender, EventArgs e)
        {
            //Button btntemp = sender as Button;
            //Table tbltemp = btntemp.Tag as Table;
            //int tableID = tbltemp.Id;
            int tableID = ((sender as Button).Tag as Table).Id;
            lblCurrentTable.Text = ((sender as Button).Tag as Table).Name;
            // Dùng lViewBill.Tag lưu trữ bàn đang được select 
            lblCurrentTable.Tag = (sender as csButton);
            lViewBill.Tag = (sender as csButton).Tag;

            ShowBill(tableID);
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin fAdmin = new fAdmin();
            fAdmin.InsertFood += fAdmin_InsertFood;
            fAdmin.EditFood += fAdmin_EditFood;
            fAdmin.DeleteFood += fAdmin_DeleteFood;
            fAdmin.ShowDialog();
        }
        /// <summary>
        /// Sự kiện được gọi sau khi thêm món thành công ở fAdmin
        /// Hàm được thực hiện khi sự kiện được gọi, đồng bộ giao diện hiển thị vs dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fAdmin_InsertFood(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbCategory.SelectedItem as Category).Id);
            if (lViewBill.Tag != null)
                ShowBill((lViewBill.Tag as Table).Id);
        }
        private void fAdmin_EditFood(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbCategory.SelectedItem as Category).Id);
            if (lViewBill.Tag != null)
                ShowBill((lViewBill.Tag as Table).Id);
            LoadTables();
        }
        private void fAdmin_DeleteFood(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbCategory.SelectedItem as Category).Id);
            if (lViewBill.Tag != null)
                ShowBill((lViewBill.Tag as Table).Id);
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int categoryID = 0;
            ComboBox cbBox = sender as ComboBox;
            if (cbBox.SelectedItem == null) return;
            Category selected = cbBox.SelectedItem as Category;
            categoryID = selected.Id;
            LoadFoodListByCategoryID(categoryID);
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            Table table = lViewBill.Tag as Table;
            if (table == null)
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi thêm món", "Thông báo");
                return;
            }
            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.Id);
            int idFood = (cbBoxFood.SelectedItem as Food).Id;
            int foodCount = (int)numUD_FoodCount.Value;

            // Bàn chhưa tồn tại Hóa Đơn
            if (idBill == -1)
            {
                BillDAO.Instance.InsertBill(table.Id);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), idFood, foodCount);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, idFood, foodCount);
            }

            ShowBill(table.Id);
            ReloadTable();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (lViewBill.Tag != null)
            {
                Table curTable = lViewBill.Tag as Table;
                int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(curTable.Id);

                float totalPrice = Convert.ToSingle(tBoxTotalPrice.Text.Split(',')[0], GE_Culture);

                if (idBill != -1)
                {
                    if (MessageBox.Show($"Bạn có chắc muốn thanh toán hóa đơn của {curTable.Name}\nTổng hóa đơn là {totalPrice.ToString("#,#", GE_Culture)} VNĐ", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        BillDAO.Instance.CheckOut(idBill, totalPrice);
                        ShowBill(idBill);
                    }
                }

                ReloadTable();
            }
            else return;
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccInfo fAccInfo = new fAccInfo(AccLogined);
            fAccInfo.UpdateInfo += fAccInfo_UpdateInfo;
            fAccInfo.ShowDialog();
        }
        private void fAccInfo_UpdateInfo(object sender, AccountEvent e)
        {
            thôngTinToolStripMenuItem.Text = $"Thông tin ({e.Account.DisplayName})";
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
