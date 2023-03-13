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
using System.Xml.Serialization;

namespace CoffeeStore
{
    public partial class fHome : Form
    {
        private CultureInfo GE_Culture = new CultureInfo("de-DE");

        // Thông tin của Tài Khoản đang đăng nhập
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

            CallLoad();
        }

        private void CallLoad()
        {
            LoadTables();
            LoadCategory();
        }

        private void Decentralization(int accType)
        {
            if (accType == 1 ) tsmItemAdmin.Enabled = true;
            tsmItemInfo.Text += $" ({AccLogined.DisplayName})";
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
            if (cbBoxFood.SelectedItem == null)
            {
                cbBoxFood.Text = string.Empty;
                return;
            }
        }
        
        /// <summary>
        /// Render toàn bộ các button controller để thể hiện cho các bàn của quán
        /// </summary>
        private void LoadTables()
        {
            fLayoutTable.Controls.Clear();

            List<Table> tableList = TableDAO.Instance.GetTablesList();
            foreach (Table table in tableList)
            {
                if(table.Name == "Bàn Đã Xóa")
                {
                    continue;
                }

                csButton btn = new csButton()
                {
                    Width = TableDAO.tableWidth,
                    Height = TableDAO.tableHeight,
                    BorderSize = 1,
                    BorderRadius = 0,
                    Margin = new Padding(6),
                    TabStop = false,
                };
                btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btn.Text = table.Name + Environment.NewLine + $"({table.Status})";
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
        /// Render lại đúng 1 button controller thể hiện cho đúng bàn đã chọn
        /// </summary>
        private void ReloadTable()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery($"select TrangThai from Ban where ID = {(lViewBill.Tag as Table).Id}");
            (lblCurrentTable.Tag as csButton).Text = (lViewBill.Tag as Table).Name + Environment.NewLine + $"({data.Rows[0][0].ToString()})";
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

        /// <summary>
        /// Hiển thị hóa đơn chưa thanh toán của một bàn cụ thể
        /// </summary>
        /// <param name="tableID"></param>
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
            tBoxTotalPrice.Texts = totalBill.ToString("c", culture);
        }

        #region Events
        /// <summary>
        /// Lắng nghe sự kiện click vào các Button Controller thể hiện cho các bàn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Show dialog form Admin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin fAdmin = new fAdmin();

            // Theo dõi thông tin tài khoản đang đăng nhập
            fAdmin.loginedAccount = accLogined;

            fAdmin.InsertFood += fAdmin_InsertFood;
            fAdmin.EditFood += fAdmin_EditFood;
            fAdmin.DeleteFood += fAdmin_DeleteFood;

            fAdmin.InsertCategory += fAdmin_InsertCategory;
            fAdmin.EditCategory += fAdmin_EditCategory;
            fAdmin.DeleteCategory += fAdmin_DeleteCategory;

            fAdmin.InsertTable += fAdmin_InsertTable;
            fAdmin.EditTable += fAdmin_EditTable;
            fAdmin.DeleteTable += fAdmin_DeleteTable;

            fAdmin.ShowDialog();
        }

        #region fAdmin event
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
        
        private void fAdmin_InsertCategory(object sender, EventArgs e)
        {
            LoadCategory();
            LoadFoodListByCategoryID((cbCategory.SelectedItem as Category).Id);
        }
        private void fAdmin_EditCategory(object sender, EventArgs e)
        {
            LoadCategory();
            LoadFoodListByCategoryID((cbCategory.SelectedItem as Category).Id);
        }
        private void fAdmin_DeleteCategory(object sender, EventArgs e)
        {
            LoadCategory();
            LoadFoodListByCategoryID((cbCategory.SelectedItem as Category).Id);
        }
        
        private void fAdmin_InsertTable(object sender, EventArgs e)
        {
            LoadTables();
        }
        private void fAdmin_EditTable(object sender, EventArgs e)
        {
            LoadTables();
        }
        private void fAdmin_DeleteTable(object sender, EventArgs e)
        {
            LoadTables();
        }
        #endregion

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int categoryID = 0;
            ComboBox cbBox = sender as ComboBox;
            if (cbBox.SelectedItem == null) return;
            Category selected = cbBox.SelectedItem as Category;
            categoryID = selected.Id;
            LoadFoodListByCategoryID(categoryID);
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccInfo fAccInfo = new fAccInfo(AccLogined);
            fAccInfo.UpdateInfo += fAccInfo_UpdateInfo;
            fAccInfo.ShowDialog();
        }
        
        private void fAccInfo_UpdateInfo(object sender, AccountEvent e)
        {
            tsmItemInfo.Text = $"Thông tin ({e.Account.DisplayName})";
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPay_Click_1(object sender, EventArgs e)
        {
            if (lViewBill.Tag != null)
            {
                Table curTable = lViewBill.Tag as Table;
                int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(curTable.Id);

                float totalPrice = Convert.ToSingle(tBoxTotalPrice.Texts.Split(',')[0], GE_Culture);

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

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            Table table = lViewBill.Tag as Table;
            if (table == null)
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi thêm món", "Thông báo");
                return;
            }
            if (cbBoxFood.SelectedItem == null)
            {
                MessageBox.Show("Danh mục này chưa được thêm món ăn nào, xin vui lòng chọn món khác hoặc liên hệ với quản trị viên", "Thông báo");
                return;
            }
            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.Id);
            int idFood = (cbBoxFood.SelectedItem as Food).Id;
            int foodCount = (int)numUD_FoodCount.Value;

            // Bàn chưa tồn tại Hóa Đơn
            if (idBill == -1)
            {
                BillDAO.Instance.InsertBill(table.Id);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), idFood, foodCount);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, idFood, foodCount);
            }

            numUD_FoodCount.Value = 1;
            ShowBill(table.Id);
            ReloadTable();
        }

        #endregion
    }
}
