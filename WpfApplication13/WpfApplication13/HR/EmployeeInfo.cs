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
    public class EmployeeInfo
    {
        SqlConnection conn;
        public EmployeeInfo(SqlConnection conn)
        { 
            this.conn = conn;
        }
        public void addEmployee(string name,string emailID,string phone,string street,string city) {
            try
            {
                SqlCommand readcmnd = new SqlCommand(
                    "SELECT * FROM dbo.EmployeeInfo;", conn);
                SqlDataReader reader = readcmnd.ExecuteReader();
                int employeeID = 1;
                while (reader.Read())
                {
                    employeeID++;
                }
                reader.Close();

                string cmndstring = "INSERT INTO dbo.EmployeeInfo VALUES(@employeeID,@name,@emailID,@phone,@street,@city)";
                SqlCommand cmnd = new SqlCommand(cmndstring, conn);
                cmnd.Parameters.AddWithValue("@employeeID", employeeID);
                cmnd.Parameters.AddWithValue("@name", name);
                cmnd.Parameters.AddWithValue("@emailID", emailID);
                cmnd.Parameters.AddWithValue("@phone", phone);
                cmnd.Parameters.AddWithValue("@street", street);
                cmnd.Parameters.AddWithValue("@city", city);
                cmnd.ExecuteNonQuery();
            }
            catch (Exception ex) {
                Logger tempLogger = new Logger(ex.ToString());
            }
        }
        public int updateEmployeeInfo(int id, string type, string value) {
            int row = -1;
            try
            {
                string cmndstring =
                    "UPDATE dbo.EmployeeInfo SET "+type+"=@value WHERE EmployeeID=@EmployeeID";
                SqlCommand cmnd = new SqlCommand(cmndstring, conn);
                cmnd.Parameters.AddWithValue("@EmployeeID",id);
                
                cmnd.Parameters.AddWithValue("@value", value);
                row = cmnd.ExecuteNonQuery();
                
                return row;
            }
            catch (Exception ex) {
                Logger templogger = new Logger(ex.ToString());
                return row;
            }
        }
        public DataTable updateTable()
        {
            try
            {
                SqlCommand updatecmnd =
                    new SqlCommand("SELECT * from dbo.EmployeeInfo", conn);
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