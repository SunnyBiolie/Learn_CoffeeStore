using CoffeeStore.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.DAO
{
    public class TableDAO
    {
        public static int tableWidth = 90;
        public static int tableHeight = 90;
        private static TableDAO instance;
        public static TableDAO Instance
        {
            get
            {
                if (instance == null) instance = new TableDAO();
                return TableDAO.instance;
            }
            private set { TableDAO.instance = value; }
        }
        private TableDAO() { }

        public List<Table> LoadTableList()
        {
            List<Table> tables = new List<Table>();

            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetTableList");

            foreach (DataRow row in data.Rows)
            {
                Table table = new Table(row);
                tables.Add(table);
            }

            return tables;
        }
    }
}
