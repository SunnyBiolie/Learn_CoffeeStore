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
    public partial class fAdmin : Form
    {
        BindingSource listFoods = new BindingSource();

        public fAdmin()
        {
            InitializeComponent();

            CallLoad();
        }

        private void CallLoad()
        {
            dtGVFood.DataSource = listFoods;

            LoadDTPickerForStatistical();
            LoadListBillByDate(dtPickerFromDate.Value, dtPickerToDate.Value);
            dtGVAcc.DataSource = DataProvider.Instance.ExecuteQuery("select * from TaiKhoan where TenDangNhap = @username1 or TenDangNhap = @username2", new object[] { "admin", "thu123" });
            LoadListFoods();
            AddFoodBinding();
        }

        #region Methods
        private void LoadDTPickerForStatistical()
        {
            DateTime today = DateTime.Now;
            dtPickerFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtPickerToDate.Value = dtPickerFromDate.Value.AddMonths(1).AddDays(-1);
        }
        private void LoadListBillByDate(DateTime dateCheckIn, DateTime dateCheckOut)
        {
            dtGVBill.DataSource = BillDAO.Instance.GetListBillByDate(dateCheckIn, dateCheckOut);
        }

        private void LoadListFoods()
        {
            listFoods.DataSource = FoodDAO.Instance.GetListFoods();
        }

        private void AddFoodBinding()
        {
            tBoxFoodID.DataBindings.Add(new Binding("Text", dtGVFood.DataSource, "ID"));
            tBoxFoodName.DataBindings.Add(new Binding("Text", dtGVFood.DataSource, "Name"));
            LoadCategoryComboBox(cBoxFoodCategory);
            nudFoodPrice.DataBindings.Add(new Binding("value", dtGVFood.DataSource, "FoodPrice"));
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
        #endregion

        #region events
        private void csBtnStatistical_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtPickerFromDate.Value, dtPickerToDate.Value);
        }

        private void btnViewFood_Click(object sender, EventArgs e)
        {
            LoadListFoods();
        }

        private void tBoxFoodID_TextChanged(object sender, EventArgs e)
        {
            if (dtGVFood.SelectedCells.Count > 0)
            {
                int id = (int)dtGVFood.SelectedCells[0].OwningRow.Cells["IDCategory"].Value;

                Category category = CategoryDAO.Instance.GetCategoryByID(id);

                cBoxFoodCategory.SelectedItem = category;

                int index = -1;
                int i = 0;
                // duyệt qua item trong DanhMuc, nào trùng vs idDM đc select thì trả ra index
                foreach (Category item in cBoxFoodCategory.Items)
                {
                    if (item.Id == id)
                    {
                        index = i; break;
                    }
                    i++;
                }
                // đổi sang hiển thị item có index là id của DanhMuc
                cBoxFoodCategory.SelectedIndex = index;
            }
        }
        #endregion
    }
}
