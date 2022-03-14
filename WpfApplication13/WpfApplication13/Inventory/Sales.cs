using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;
using System.Data.SqlClient;
namespace WpfApplication13
{
    public class Sales
    {
        SqlConnection conn;
        public Sales(SqlConnection conn)
        {
            this.conn = conn;
        }
        public void add(int salesID, int productID, float amount, DateTime dateOfPurchase)
        {
            try
            {
                SqlCommand readcmnd = new SqlCommand(
                    "SELECT * FROM dbo.Sales;", conn);
                SqlDataReader reader = readcmnd.ExecuteReader();
                salesID = 1;
                while (reader.Read())
                {
                    salesID++;
                }
                reader.Close();
                //UPDATE sales table
                string cmndstring = "INSERT INTO dbo.Sales VALUES(@salesID,@productID,@amount,@date)";
                SqlCommand cmnd = new SqlCommand(cmndstring, conn);
                cmnd.Parameters.AddWithValue("@salesID", salesID);
                cmnd.Parameters.AddWithValue("@productID", productID);
                cmnd.Parameters.AddWithValue("@amount", amount);
                cmnd.Parameters.AddWithValue("@date", dateOfPurchase);
                cmnd.ExecuteNonQuery();
                //UPDATE peroducts table
                Products products = new Products(conn);
                int rows = products.changeAmount(productID, -amount);
                if (rows == 0) MessageBox.Show("amount not updated");
            }
            catch (Exception ex)
            {
                Logger tempLogger = new Logger(ex.ToString());

            }
        }
        public DataTable updateTable()
        {
            try
            {
                SqlCommand updatecmnd =
                    new SqlCommand("SELECT * from dbo.Sales", conn);
                DataTable table = new DataTable();
                table.Load(updatecmnd.ExecuteReader());
                return table;
            }
            catch (Exception ex)
            {
                Logger tempLogger = new Logger(ex.ToString());
                return null;
            }
        }
    }
}