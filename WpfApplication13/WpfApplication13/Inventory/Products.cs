using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
namespace WpfApplication13
{
    class Products
    {
        SqlConnection conn;
        public Products(SqlConnection conn)
        {
            this.conn = conn;
        }
        public void add(int id, string name,string company,
            string catagory,string note,float amount,string unit) {
            try
            {
                SqlCommand readcmnd = new SqlCommand(
                    "SELECT * FROM dbo.Products;", conn);
                SqlDataReader reader = readcmnd.ExecuteReader();
                id = 1;
                while (reader.Read())
                {
                    id++;
                }
                reader.Close();

                string cmndstring = "INSERT INTO dbo.Products VALUES(@id,@name,@company,@catagory,@note,@amount,@unit)";
                SqlCommand cmnd = new SqlCommand(cmndstring, conn);
                cmnd.Parameters.AddWithValue("@id", id);
                cmnd.Parameters.AddWithValue("@name", name);
                cmnd.Parameters.AddWithValue("@company", company);
                cmnd.Parameters.AddWithValue("@catagory", catagory);
                cmnd.Parameters.AddWithValue("@note", note);
                cmnd.Parameters.AddWithValue("@amount",amount);
                cmnd.Parameters.AddWithValue("@unit", unit);

                cmnd.ExecuteNonQuery();
            }
            catch (Exception ex) {
                Logger temp_logger = new Logger(ex.ToString());
            }
        }
        public int changeAmount(int id, float amount) {
            int rows = -1;
            try
            {
                string cmndstring = 
                    "UPDATE dbo.Products SET amount=amount+@amount WHERE id=@id";
                SqlCommand cmnd = new SqlCommand(cmndstring, conn);
                cmnd.Parameters.AddWithValue("@id", id);
                cmnd.Parameters.AddWithValue("@amount", amount);
                rows=cmnd.ExecuteNonQuery();
                return rows;
            }
            catch (Exception ex) {
                Logger temp_logger = new Logger(ex.ToString());
                return rows;
            }
        }
        public int delete(int id) {
            int rows = -1;
            try
            {
                string cmndstring = "DELETE FROM dbo.Products WHERE id=@id";
                SqlCommand cmnd = new SqlCommand(cmndstring, conn);
                cmnd.Parameters.AddWithValue("@id", id);
                rows = cmnd.ExecuteNonQuery();
                return rows;
            }
            catch (Exception ex)
            {
                Logger temp_logger = new Logger(ex.ToString());
                return rows;
            }
        }
        public DataTable updateTable()
        {
            try
            {
                SqlCommand updatecmnd =
                    new SqlCommand("SELECT * from dbo.Products", conn);
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
        public DataTable searchByCompanyAndCatagory(string company, string catagory) {
            try
            {
                SqlCommand updatecmnd =
                    new SqlCommand(
                        "SELECT * from dbo.Products WHERE company=@company OR catagory=@catagory",
                        conn);
                DataTable table = new DataTable();
                updatecmnd.Parameters.AddWithValue("@company", company);
                updatecmnd.Parameters.AddWithValue("@catagory", catagory);
                table.Load(updatecmnd.ExecuteReader());
                return table;
            }
            catch (Exception ex){
                Logger tempLogger = new Logger(ex.ToString());
                return null;
            }
        }
    }
}
