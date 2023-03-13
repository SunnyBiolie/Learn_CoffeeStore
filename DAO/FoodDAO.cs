﻿using CoffeeStore.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;
        public static FoodDAO Instance
        {
            get
            {
                if (instance == null) instance = new FoodDAO();
                return instance;
            }
            private set => instance = value;
        }
        private FoodDAO() { }

        public List<Food> GetListFoodByCategoryID(int id)
        {
            List<Food> list = new List<Food>();

            string query = $"select * from MonAn where idDM = {id}";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                Food food = new Food(row);
                list.Add(food);
            }

            return list;
        }

        public List<Food> GetListFoods()
        {
            List<Food> list = new List<Food>();

            string query = "select * from MonAn";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                Food food = new Food(row);
                list.Add(food);
            }

            return list;
        }

        public bool InsertFood(string foodName, int categoryID, float foodPrice)
        {
            string query = $"insert MonAn (TenMon, idDM, GiaMonAn) values ( @foodName , @categoryID , @foodPrice )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { foodName, categoryID, foodPrice });

            return result > 0;
        }

        public bool EditFoodInfo(string foodName, int categoryID, float foodPrice, int foodID)
        {
            string query = $"update MonAn set TenMon = @foodName , idDM = @categoryID , GiaMonAn = @foodPrice where ID = @foodID";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { foodName, categoryID, foodPrice, foodID });

            return result > 0;
        }

        public bool DeleteFood(int foodID)
        {
            BillInfoDAO.Instance.UpdateBillInfoToDeletedFoodByFoodID(foodID);

            string query = $"Delete MonAn where ID = @foodID";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { foodID });

            return result > 0;
        }
    }
}
