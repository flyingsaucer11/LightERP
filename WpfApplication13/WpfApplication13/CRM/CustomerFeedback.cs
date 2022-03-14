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
    public class CustomerFeedback
    {
        SqlConnection conn;
        public CustomerFeedback(SqlConnection conn) { 
            this.conn = conn;
        }
        public void addFeedback(int id, string name, string emailID, DateTime date, string feedback, string note)
        {
            try
            {
                SqlCommand readcmnd = new SqlCommand(
                    "SELECT * FROM dbo.CustomerFeedback;", conn);
                SqlDataReader reader = readcmnd.ExecuteReader();
                id = 99999;
                while (reader.Read()) {
                    id++;
                }
                reader.Close();
                string cmndstring="INSERT INTO dbo.CustomerFeedback VALUES(@id,@name,@emailID,@date,@feedback,@note)";
                SqlCommand cmnd = new SqlCommand(cmndstring,conn);
                cmnd.Parameters.AddWithValue("@id", id);
                cmnd.Parameters.AddWithValue("@name", name);
                cmnd.Parameters.AddWithValue("@emailID", emailID);
                cmnd.Parameters.AddWithValue("@date", date);
                cmnd.Parameters.AddWithValue("@feedback", feedback);
                cmnd.Parameters.AddWithValue("@note", note);
                 
                cmnd.ExecuteNonQuery();
            }
            catch (Exception ex) {
               
                Logger tempLogger = new Logger(ex.ToString());
            }
        }
        public int updateFeedback(int id, string note) {
            try
            {
                string str2 = "UPDATE dbo.CustomerFeedback SET Note= @note WHERE Id=@id";
                SqlCommand cmnd = new SqlCommand(str2, conn);
                cmnd.Parameters.AddWithValue("@id", id);
                cmnd.Parameters.AddWithValue("@note", note);
                int rows=cmnd.ExecuteNonQuery();
                return rows;
            }
            catch (Exception ex) {
                Logger tempLogger = new Logger(ex.ToString());
                return -1;
            }
        }
        public DataTable updateTable() {
            try
            {
                SqlCommand updatecmnd =
                    new SqlCommand("SELECT * from dbo.CustomerFeedback", conn);
                DataTable table = new DataTable();
                table.Load(updatecmnd.ExecuteReader());
                return table;
            }
            catch (Exception ex) {
                Logger tempLogger = new Logger(ex.ToString());
                return null;
            }
        }
    }
}
