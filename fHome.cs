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
        public fHome()
        {
            InitializeComponent();

            LoadTables();
            LoadCategory();
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
                        btn.TextColor = Color.FromArgb(0, 0, 0);
                        btn.BackgroundColor = Color.FromArgb(45, 204, 255);
                        break;
                }

                fLayoutTable.Controls.Add(btn);
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
                listViewItem.SubItems.Add(item.FoodPrice.ToString("#,#"));
                listViewItem.SubItems.Add(item.TotalPrice.ToString("#,#"));

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
            // Dùng lblCurrentTable.Tag lưu trữ bàn đang được select 
            lblCurrentTable.Tag = (sender as Button).Tag;

            ShowBill(tableID);
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccInfo fAccInfo = new fAccInfo();
            fAccInfo.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin fAdmin = new fAdmin();
            fAdmin.ShowDialog();
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
            Table table = lblCurrentTable.Tag as Table;
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
            LoadTables();
        }
        #endregion

        private void btnPay_Click(object sender, EventArgs e)
        {
            Table curTable = lblCurrentTable.Tag as Table;
            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(curTable.Id);
            if (idBill != -1)
            {
                if (MessageBox.Show($"Bạn có chắc muốn thanh toán hóa đơn của bàn {curTable.Name}", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill);
                    ShowBill(idBill);
                }
            }

            LoadTables();
        }
    }
}
