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
    public class Purchase
    {
        SqlConnection conn;
        public Purchase(SqlConnection conn) {
            this.conn = conn;
        }
        public void add(int purchaseID, int productID, float amount, DateTime dateOfPurchase) {
            try
            {
                SqlCommand readcmnd = new SqlCommand(
                    "SELECT * FROM dbo.Purchase;", conn);
                SqlDataReader reader = readcmnd.ExecuteReader();
                purchaseID = 1;
                while (reader.Read())
                {
                    purchaseID++;
                }
                reader.Close();
                //UPDATE inventory table
                string cmndstring = "INSERT INTO dbo.Purchase VALUES(@purchaseID,@productID,@amount,@date)";
                SqlCommand cmnd = new SqlCommand(cmndstring, conn);
                cmnd.Parameters.AddWithValue("@purchaseID", purchaseID);
                cmnd.Parameters.AddWithValue("@productID", productID);
                cmnd.Parameters.AddWithValue("@amount", amount);
                cmnd.Parameters.AddWithValue("@date", dateOfPurchase);
                cmnd.ExecuteNonQuery();
                //UPDATE purchase table
                Products products = new Products(conn);
                int rows=products.changeAmount(productID, amount);
                if (rows == 0) MessageBox.Show("amount not updated");
            }
            catch (Exception ex) {
                Logger tempLogger = new Logger(ex.ToString());
                
            }
        }
        public DataTable updateTable()
        {
            try
            {
                SqlCommand updatecmnd =
                    new SqlCommand("SELECT * from dbo.Purchase", conn);
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