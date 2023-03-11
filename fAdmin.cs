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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CoffeeStore
{
    public partial class fAdmin : Form
    {
        BindingSource revenueListInfo = new BindingSource();
        BindingSource listFoods = new BindingSource();
        BindingSource categoriesList = new BindingSource();
        BindingSource accountsList = new BindingSource();

        public Account loginedAccount;

        public fAdmin()
        {
            InitializeComponent();

            CallLoad();
        }

        #region Methods
        private void CallLoad()
        {
            dtGVBill.DataSource = revenueListInfo;
            dtGVFood.DataSource = listFoods;
            dtGVCategory.DataSource = categoriesList;
            dtGVAcc.DataSource = accountsList;


            LoadDTPickerForStatistical();
            LoadListBillByDate(dtPickerFromDate.Value, dtPickerToDate.Value);
            LoadListFoods();
            LoadCategoriesList();
            LoadAccountsList();
            AddRevenueBinding();
            AddFoodBinding();
            AddCategoryBinding();
            AddAccountBinding();
        }

        #region Doanh thu
        private void LoadDTPickerForStatistical()
        {
            DateTime today = DateTime.Now;
            dtPickerFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtPickerToDate.Value = dtPickerFromDate.Value.AddMonths(1).AddDays(-1);
        }
        private void LoadListBillByDate(DateTime dateCheckIn, DateTime dateCheckOut)
        {
            List<InterfaceRevenueByDate> list = InterfaceRevenueByDateDAO.Instance.GetListBillByDate(dateCheckIn, dateCheckOut);
            revenueListInfo.DataSource = list;

            float totalRevenue = 0;
            foreach (InterfaceRevenueByDate item in list)
            {
                totalRevenue += item.TotalPrice;
            }
            tBoxTotalRevenue.Text = totalRevenue.ToString("c", new CultureInfo("vi-VN"));
        }

        private void AddRevenueBinding()
        {
            tBoxBillID.DataBindings.Add(new Binding("Text", dtGVBill.DataSource, "Id", true, DataSourceUpdateMode.Never));
            csBtnTableName.DataBindings.Add(new Binding("Text", dtGVBill.DataSource, "TableName", true, DataSourceUpdateMode.Never));
            //// Lưu vào tag rồi chuyển từ object conctrol sang string "c" trong text ở hàm ShowRevenueInfo()
            tBoxTotalPrice.DataBindings.Add(new Binding("Tag", dtGVBill.DataSource, "TotalPrice", true, DataSourceUpdateMode.Never));
        }
        private void ShowRevenueDetails()
        {
            lViewDetail.Items.Clear();

            List<InterfaceRevenue> list = InterfaceRevenueDAO.Instance.GetListInterfaceRevenues(tBoxBillID.Text);

            foreach (InterfaceRevenue item in list)
            {
                ListViewItem listViewItem = new ListViewItem(item.FoodName.ToString());
                listViewItem.SubItems.Add(item.FoodCount.ToString());
                lViewDetail.Items.Add(listViewItem);
            }

            tBoxTotalPrice.Text = Convert.ToSingle(tBoxTotalPrice.Tag).ToString("c", new CultureInfo("vi-VN"));
        }
        #region account methods
        private void ResetPass()
        {
            string userName = tBoxUserName.Text;
            if (AccountDAO.Instance.ResetPass(userName))
            {
                MessageBox.Show($"Đặt lại mật khẩu thành mật khẩu mặc định thành công");
            }
            else
                MessageBox.Show($"Đặt lại mật khẩu thất bại");
        }
        #endregion

        #endregion


        private void LoadListFoods()
        {
            listFoods.DataSource = InterfaceFoodInfoDAO.Instance.GetListInterfaceFoodInfo();
        }

        private void AddFoodBinding()
        {
            tBoxFoodID.DataBindings.Add(new Binding("Text", dtGVFood.DataSource, "ID", true, DataSourceUpdateMode.Never));
            tBoxFoodName.DataBindings.Add(new Binding("Text", dtGVFood.DataSource, "FoodName", true, DataSourceUpdateMode.Never));
            LoadCategoryComboBox(cBoxFoodCategory);
            nudFoodPrice.DataBindings.Add(new Binding("Value", dtGVFood.DataSource, "FoodPrice", true, DataSourceUpdateMode.Never));
        }

        /// <summary>
        /// Load list of categorys for ComboBox's source ans set DisplayMember of this cbBox
        /// </summary>
        /// <param name="cb"></param>
        private void LoadCategoryComboBox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";
        }

        private List<InterfaceFoodInfo> FindFoodByName(string approName)
        {
            List<InterfaceFoodInfo> list = InterfaceFoodInfoDAO.Instance.GetListFoodByName(approName);

            return list;
        }

        #region CategoryView
        private void LoadCategoriesList()
        {
            categoriesList.DataSource = CategoryDAO.Instance.GetListCategory();
        }
        private void AddCategoryBinding()
        {
            tBoxCategoryID.DataBindings.Add("Text", dtGVCategory.DataSource, "Id", true, DataSourceUpdateMode.Never);
            tBoxCategoryName.DataBindings.Add("Text", dtGVCategory.DataSource, "Name", true, DataSourceUpdateMode.Never);
        }
        #endregion

        #region AccountView
        private void LoadAccountsList()
        {
            accountsList.DataSource = InterfaceAccInfoDAO.Instance.GetAccountsList();
        }
        private void AddAccountBinding()
        {
            tBoxUserName.DataBindings.Add(new Binding("Text", dtGVAcc.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            tBoxDisplayName.DataBindings.Add(new Binding("Text", dtGVAcc.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            LoadTypeAccComboBox(cBoxTypeAcc);
        }
        private void LoadTypeAccComboBox(ComboBox cb)
        {
            cb.DataSource = TypeAccDAO.Instance.GetListTypeAcc();
            cb.DisplayMember= "TypeName";
        }
        #endregion
        #endregion

        #region events
        
        #region Doanh Thu
        private void csBtnStatistical_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtPickerFromDate.Value, dtPickerToDate.Value);
        }
        private void tBoxBillID_TextChanged(object sender, EventArgs e)
        {
            ShowRevenueDetails();
        }
        #endregion

        
        #region FoodView
        private void btnViewFood_Click(object sender, EventArgs e)
        {
            LoadListFoods();
        }

        // TextChanged đồng nghĩa người dùng select sang món có id khác
        private void tBoxFoodID_TextChanged(object sender, EventArgs e)
        {
            if (dtGVFood.SelectedCells.Count > 0)
            {
                string categoryName = (string)dtGVFood.SelectedCells[0].OwningRow.Cells["CategoryName"].Value;

                // int id = (int)dtGVFood.SelectedCells[0].OwningRow.Cells["Id"].Value;
                //Category category = CategoryDAO.Instance.GetCategoryByID(id);
                //cBoxFoodCategory.SelectedItem = category;

                int index = -1;
                int i = 0;
                // duyệt qua item trong DanhMuc, nào trùng vs idDM đc select thì trả ra index
                foreach (Category item in cBoxFoodCategory.Items)
                {
                    if (item.Name == categoryName)
                    {
                        index = i; break;
                    }
                    i++;
                }
                // đổi sang hiển thị item có index là id của DanhMuc
                cBoxFoodCategory.SelectedIndex = index;
            }
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string foodName = tBoxFoodName.Text;
            int categoryID = (cBoxFoodCategory.SelectedItem as Category).Id;
            float foodPrice = Convert.ToSingle(nudFoodPrice.Value);
            
            List<InterfaceFoodInfo> list = InterfaceFoodInfoDAO.Instance.GetListInterfaceFoodInfo();
            foreach (InterfaceFoodInfo item in list)
            {
                if (item.FoodName == foodName && item.CategoryName == (cBoxFoodCategory.SelectedItem as Category).Name)
                {
                    MessageBox.Show($"{foodName} đã tồn tại trong danh mục {item.CategoryName}");
                    return;
                }
            }

            if (FoodDAO.Instance.InsertFood(foodName, categoryID, foodPrice))
            {
                MessageBox.Show($"Thêm thành công {foodName} vào danh mục {(cBoxFoodCategory.SelectedItem as Category).Name}");

                LoadListFoods();
                if (insertFood != null)
                    insertFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show($"Đã xảy ra lỗi khi thêm món");
            }
        }

        private void btnEditFood_Click(object sender, EventArgs e)
        {
            string foodName = tBoxFoodName.Text;
            int categoryID = (cBoxFoodCategory.SelectedItem as Category).Id;
            float foodPrice = Convert.ToSingle(nudFoodPrice.Value);
            int foodID = Convert.ToInt32(tBoxFoodID.Text);

            if (FoodDAO.Instance.EditFoodInfo(foodName, categoryID, foodPrice, foodID))
            {
                MessageBox.Show($"Thay đổi thông tin {foodName} thành công");

                LoadListFoods();
                if (editFood != null)
                    editFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show($"Đã xảy ra lỗi khi thay đổi thông tin món");
            }
        }

        private void btnRemoveFood_Click(object sender, EventArgs e)
        {
            int foodID = Convert.ToInt32(tBoxFoodID.Text);

            if (MessageBox.Show($"Xóa món {tBoxFoodName.Text} khỏi danh mục {(cBoxFoodCategory.SelectedItem as Category).Name}?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (FoodDAO.Instance.DeleteFood(foodID))
                {
                    MessageBox.Show($"Xóa món thành công");

                    LoadListFoods();
                    if (deleteFood != null)
                        deleteFood(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show($"Đã xảy ra lỗi khi xóa món");
                }
            }
        }

        private event EventHandler insertFood;
        private event EventHandler editFood;
        private event EventHandler deleteFood;

        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }
        public event EventHandler EditFood
        {
            add { editFood += value; }
            remove { editFood -= value; }
        }
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        private void btnFindFood_Click(object sender, EventArgs e)
        {
            listFoods.DataSource = FindFoodByName(tBoxFindFood.Text);
        }
        private void tBoxFindFood_TextChanged(object sender, EventArgs e)
        {
            listFoods.DataSource = FindFoodByName(tBoxFindFood.Text);
        }
        #endregion


        #region CategoryView
        private void btnViewCategory_Click(object sender, EventArgs e)
        {
            LoadCategoriesList();
        }
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string categoryName = tBoxCategoryName.Text;

            List<Category> list = CategoryDAO.Instance.GetListCategory();
            foreach (Category item in list)
            {
                if (item.Name == categoryName)
                {
                    MessageBox.Show($"Đã tồn tại danh mục {categoryName}");
                    return;
                }
            }

            if (CategoryDAO.Instance.InsertCategory(categoryName))
            {
                MessageBox.Show($"Thêm thành công danh mục {categoryName}");
                LoadCategoriesList();

                if (insertCategory != null)
                    insertCategory(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi khi thêm danh mục món ăn");
            }
        }
        private void btnAdjustCategory_Click(object sender, EventArgs e)
        {
            string categoryName = tBoxCategoryName.Text;
            int categoryId = Convert.ToInt32(tBoxCategoryID.Text);
            if (CategoryDAO.Instance.EditCategory(categoryName, categoryId))
            {
                MessageBox.Show($"Thay đổi thành công danh mục {categoryName}");
                LoadCategoriesList();

                if (editCategory != null)
                    editCategory(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi khi thay đổi thông tin danh mục món ăn");
            }
        }
        private void btnRemoveCategory_Click(object sender, EventArgs e)
        {
            int categoryId = Convert.ToInt32(tBoxCategoryID.Text);
            if (CategoryDAO.Instance.DeleteCategory(categoryId))
            {
                MessageBox.Show($"Xóa danh mục \"{tBoxCategoryName.Text}\" thành công");
                LoadCategoriesList();

                if (deleteCategory != null)
                    deleteCategory(this,new EventArgs());
            }
            else
            {
                MessageBox.Show($"Vui lòng xóa các món ăn đang thuộc trong danh mục \"{tBoxCategoryName.Text}\" trước");
            }
        }

        private event EventHandler insertCategory;
        private event EventHandler editCategory;
        private event EventHandler deleteCategory;

        public event EventHandler InsertCategory
        {
            add { insertCategory += value; }
            remove { insertCategory -= value; }
        }
        public event EventHandler EditCategory
        {
            add { editCategory += value; }
            remove { editCategory -= value; }
        }
        public event EventHandler DeleteCategory
        {
            add { deleteCategory += value; }
            remove { deleteCategory -= value; }
        }
        #endregion


        #region AccountView
        private void btnViewAcc_Click(object sender, EventArgs e)
        {
            LoadAccountsList();
        }

        private void tBoxUserName_TextChanged(object sender, EventArgs e)
        {
            if (dtGVAcc.SelectedCells.Count > 0)
            {
                string typeName = (string)dtGVAcc.SelectedCells[0].OwningRow.Cells["PhanLoai"].Value;

                // int id = (int)dtGVFood.SelectedCells[0].OwningRow.Cells["Id"].Value;
                //Category category = CategoryDAO.Instance.GetCategoryByID(id);
                //cBoxFoodCategory.SelectedItem = category;

                int index = -1;
                int i = 0;
                foreach (TypeAcc item in cBoxTypeAcc.Items)
                {
                    if (item.TypeName == typeName)
                    {
                        index = i; break;
                    }
                    i++;
                }
                cBoxTypeAcc.SelectedIndex = index;
            }
        }

        private void btnAddAcc_Click(object sender, EventArgs e)
        {
            string userName = tBoxUserName.Text;
            string displayName = tBoxDisplayName.Text;
            int type = (cBoxTypeAcc.SelectedItem as TypeAcc).IdType;

            if (AccountDAO.Instance.InsertAccount(userName, displayName, type))
            {
                MessageBox.Show($"Thêm tài khoản thành công");
                LoadAccountsList();
            }
            else
            {
                MessageBox.Show($"Đã xảy ra lỗi trong lúc thêm tài khoản");
            }
        }

        private void btnRemoveAcc_Click(object sender, EventArgs e)
        {
            string userName = tBoxUserName.Text;
            if (loginedAccount.UserName.Equals(userName))
            {
                MessageBox.Show("Không thể xóa tài khoản đang đăng nhập");
                return;
            }
            if (MessageBox.Show($"Bạn có chắc muốn xóa tài khoản {userName}", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (AccountDAO.Instance.DeleteAccount(userName))
                {
                    MessageBox.Show($"Xóa tài khoản thành công");
                    LoadAccountsList();
                }
                else
                {
                    MessageBox.Show($"Đã xảy ra lỗi trong lúc xóa tài khoản");
                }
            }
        }

        private void btnAdjustAcc_Click(object sender, EventArgs e)
        {
            string userName = tBoxUserName.Text;
            string displayName = tBoxDisplayName.Text;
            int type = (cBoxTypeAcc.SelectedItem as TypeAcc).IdType;

            if (AccountDAO.Instance.EditAccInfo(userName, displayName, type))
            {
                MessageBox.Show($"Sửa thông tin tài khoản thành công");
                LoadAccountsList();
            }
            else
            {
                MessageBox.Show($"Đã xảy ra lỗi trong lúc sửa thông tin tài khoản");
            }
        }
        private void btnResetPass_Click(object sender, EventArgs e)
        {
            ResetPass();
        }
        #endregion

        #endregion

 
    }
}
