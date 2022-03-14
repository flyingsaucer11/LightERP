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
    public class EmployeeDuty
    {
        SqlConnection conn;
        public EmployeeDuty(SqlConnection conn)
        {
            this.conn = conn;
        }
        public void addDuty(int employeeID, string department, string position,
            int salary,DateTime joinDate)
        {
            
            try
            {
                string cmndstring = 
                    "INSERT INTO dbo.EmployeeDuty (EmployeeID,Department,Position,Salary,JoinDate)"
                    +" VALUES(@employeeID,@department,@position,@salary,@joinDate)";
                SqlCommand cmnd = new SqlCommand(cmndstring, conn);
                cmnd.Parameters.AddWithValue("@employeeID", employeeID);
                cmnd.Parameters.AddWithValue("@department", department);
                cmnd.Parameters.AddWithValue("@position", position);
                cmnd.Parameters.AddWithValue("@salary", salary);
                cmnd.Parameters.AddWithValue("@joinDate", joinDate.Date);
                cmnd.ExecuteNonQuery();  
                
            }
            catch (Exception ex)
            {
                Logger tempLogger = new Logger(ex.ToString());
                
            }
        }
        public int updateInfo(int employeeID,string type,string value) {
            int rows = -1;
            try
            {
                string cmndstring =
                    "UPDATE dbo.EmployeeDuty SET " + type + "=@value WHERE EmployeeID=@EmployeeID";
                SqlCommand cmnd = new SqlCommand(cmndstring, conn);
                cmnd.Parameters.AddWithValue("@EmployeeID", employeeID);

                cmnd.Parameters.AddWithValue("@value", value);
                rows = cmnd.ExecuteNonQuery();
                return rows;
            }
            catch (Exception ex){
                Logger tempLogger = new Logger(ex.ToString());
                return rows;
            }
        }
        public int deleteDuty(int employeeID, DateTime datetime) {
            int rows = -1;
            try
            {
                string cmndstring =
                    "UPDATE dbo.EmployeeDuty SET LeaveDate=@value WHERE EmployeeID=@EmployeeID";
                SqlCommand cmnd = new SqlCommand(cmndstring, conn);
                cmnd.Parameters.AddWithValue("@EmployeeID", employeeID);

                cmnd.Parameters.AddWithValue("@value", datetime.Date);
                rows = cmnd.ExecuteNonQuery();
                return rows;
            }
            catch (Exception ex) {
                Logger tempLogger = new Logger();
                tempLogger.write(ex.ToString());
                return rows;
            }
        }
        public DataTable updateTable()
        {
            try
            {
                SqlCommand updatecmnd =
                    new SqlCommand("SELECT * from dbo.EmployeeDuty", conn);
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