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
    public class SalaryPayment
    {
        SqlConnection conn;
        public SalaryPayment(SqlConnection conn) { 
            this.conn = conn;
        }
        public void updateSalaryPayment(
            int EmployeeID,float Amount,string FromMonthYear,string ToMonthYear,
            int BankTransactionID,DateTime PaymentDate) 
        {

            try
            {
                SqlCommand readcmnd = new SqlCommand(
                    "SELECT * FROM dbo.SalaryPayment;", conn);
                SqlDataReader reader = readcmnd.ExecuteReader();
                int PaymentID = 1;
                while (reader.Read())
                {
                    PaymentID++;
                }
                reader.Close();

                string cmndstring = "INSERT INTO dbo.SalaryPayment VALUES(@PaymentID,@EmployeeID,@Amount,@FromMonthYear,@ToMonthYear,@BankTransactionID,@PaymentDate)";
                SqlCommand cmnd = new SqlCommand(cmndstring, conn);
                cmnd.Parameters.AddWithValue("@PaymentID", PaymentID);
                cmnd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                cmnd.Parameters.AddWithValue("@Amount", Amount);
                cmnd.Parameters.AddWithValue("@FromMonthYear", FromMonthYear);
                cmnd.Parameters.AddWithValue("@ToMonthYear", ToMonthYear);
                cmnd.Parameters.AddWithValue("@BankTransactionID", BankTransactionID);
                cmnd.Parameters.AddWithValue("@PaymentDate", PaymentDate.Date);
                cmnd.ExecuteNonQuery();
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
                    new SqlCommand("SELECT * from dbo.SalaryPayment", conn);
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
