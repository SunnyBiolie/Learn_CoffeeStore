using CoffeeStore.DAO;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeStore
{
    public partial class fReport : Form
    {
        public fReport()
        {
            InitializeComponent();

            loadchart();
        }

        public void loadchart()
        {
            string connectionSTR = @"Data Source=KHOAPHAM;Initial Catalog=tester;Integrated Security=True";
            DataTable data = new DataTable();
            // Giải phóng bộ nhớ sau khi block code hoàn thành
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                string query = "select TenDM, tt.total\r\nfrom DanhMuc as dm, (select dm.id, sum(SoLuong) as total from chitiethoadon as cthd, DanhMuc as dm, MonAn as ma where idDM = dm.id group by dm.id) as tt\r\nwhere tt.ID = dm.ID order by total";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                connection.Close();
            }

            string[] x = new string[data.Rows.Count];
            int[] y = new int[data.Rows.Count];

            for (int i = 0; i < data.Rows.Count; i++)
            {
                x[i] = data.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(data.Rows[i][1]);
            }

            chart1.Series[0].Points.DataBindXY(x, y);
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
        }
    }
}
