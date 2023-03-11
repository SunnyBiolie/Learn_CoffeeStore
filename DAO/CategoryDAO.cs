﻿using CoffeeStore.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;
        public static CategoryDAO Instance
        {
            get
            {
                if (instance == null) instance = new CategoryDAO();
                return instance;
            }
            private set => instance = value;
        }
        private CategoryDAO() { }

        public List<Category> GetListCategory()
        {
            List<Category> list = new List<Category>();

            string query = "select * from DanhMuc";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                Category danhmuc = new Category(row);
                list.Add(danhmuc);
            }

            return list;
        }

        public Category GetCategoryByID(int id)
        {
            Category category = null;

            string query = $"select * from DanhMuc where ID = {id}";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                category = new Category(row);
            }

            return category;
        }

        public bool InsertCategory(string categoryName)
        {
            string query = $"insert DanhMuc (TenDM) values ( @categoryName )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { categoryName });

            return result > 0;
        }
        public bool EditCategory(string categoryName, int categoryId)
        {
            string query = $"update DanhMuc set TenDM = @categoryName where ID = @categoryId";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { categoryName, categoryId });

            return result > 0;
        }
        public bool DeleteCategory(int categoryId)
        {
            string query1 = $"select ma.TenMon from DanhMuc as dm, MonAn as ma where ma.idDM = dm.ID and dm.ID = {categoryId}";

            DataTable data = DataProvider.Instance.ExecuteQuery(query1);

            if (data.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                string query2 = $"delete DanhMuc where ID = @categoryId";
                DataProvider.Instance.ExecuteNonQuery(query2, new object[] { categoryId });
                return true;
            }
        }
    }
}
