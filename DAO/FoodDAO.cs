using CoffeeStore.DTO;
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
    }
}
