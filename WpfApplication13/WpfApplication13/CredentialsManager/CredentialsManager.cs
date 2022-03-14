using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Security;
namespace WpfApplication13
{
    public class CredentialsManager
    {
        SqlConnection conn;
        public CredentialsManager(SqlConnection conn)
        {
            this.conn = conn;
        }
        public void ApproveNewUser(string EmailID) {
            try
            {

                string cmndstring=
                    "SELECT * FROM dbo.PendingCredentials WHERE EmailID=@EmailID";
                SqlCommand cmnd = new SqlCommand(cmndstring, conn);
                cmnd.Parameters.AddWithValue("@EmailID", EmailID);
                SqlDataReader reader = cmnd.ExecuteReader();
                String[] result={"x","y","z","a"};
                while (reader.Read())
                {
                    
                    reader.GetValues(result);
                    string Password = result[1];
                    string Privilage = result[2];
                    string Name = result[3];
                    //MessageBox.Show(result[1]);

                    SqlConnection conn2 = new SqlConnection();
                    ConnectionManager manager2 = new ConnectionManager();
                    conn2=manager2.ConnectToDatabase(1);

                    cmndstring = "INSERT INTO dbo.Credentials VALUES(@emailID,@password,@privilage,@name)";
                    cmnd = new SqlCommand(cmndstring, conn2);
                    cmnd.Parameters.AddWithValue("@emailID", EmailID);
                    cmnd.Parameters.AddWithValue("@password", Password);
                    cmnd.Parameters.AddWithValue("@privilage", Privilage);
                    cmnd.Parameters.AddWithValue("@name", Name);
                    int n=cmnd.ExecuteNonQuery();
                    conn2.Close();
                    //MessageBox.Show(n.ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {   
                Logger tempLogger = new Logger(ex.ToString());
            }
        }
        public int deletePending(string EmailID)
        {
            int rows = -1;
            try
            {
                string cmndstring = "DELETE FROM dbo.PendingCredentials WHERE EmailID=@id";
                SqlCommand cmnd = new SqlCommand(cmndstring, conn);
                cmnd.Parameters.AddWithValue("@id", EmailID);
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
                    new SqlCommand("SELECT * from dbo.Credentials", conn);
                DataTable table = new DataTable();
                table.Load(updatecmnd.ExecuteReader());
                return table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
        public DataTable updateAnotherTable()
        {
            try
            {
                SqlCommand updatecmnd =
                    new SqlCommand("SELECT * from dbo.PendingCredentials", conn);
                DataTable table = new DataTable();
                table.Load(updatecmnd.ExecuteReader());
                return table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
        int checkForPrivilage(string str) {
            if (str == "Super User") return 1;
            else if (str == "HR Admin") return 2;
            else if (str == "Inventory Operator") return 3;
            else if (str == "Finance Manager") return 4;
            else if (str == "CRM Admin") return 5;
            else return -1;
        }
        public int checkForID(string ID,string Pass) {
            try
            {
                string cmndstring = "SELECT * FROM dbo.Credentials WHERE EmailID=@ID";
                SqlCommand cmnd = new SqlCommand(cmndstring, conn);
                cmnd.Parameters.AddWithValue("@ID", ID);
                SqlDataReader reader= cmnd.ExecuteReader(CommandBehavior.SingleRow);
                while (reader.Read()) {
                    String[] result = { "x", "y", "z", "a" };
                    reader.GetValues(result);
                    string EmailID = result[0];
                    string Password = result[1];
                    string Privilage = result[2];
                    int pr=checkForPrivilage(Privilage);
                    reader.Close();
                    if (ID == EmailID)
                    {
                        if (Pass == Password) return pr;
                        else return -1;
                    }
                    else return -1;
                }
                return -1;
            }
            catch (Exception ex) {
                Logger logger = new Logger(ex.ToString());
                return -1;
            }
        }
        public void RequestForSignup(string EmailID, string Password,
            string Privilage, string Name) {
               try {

                string cmndstring = "INSERT INTO dbo.PendingCredentials VALUES(@EmailID,@Password,@Privilage,@Name)";
                SqlCommand cmnd = new SqlCommand(cmndstring, conn);
                cmnd.Parameters.AddWithValue("@EmailID", EmailID);
                cmnd.Parameters.AddWithValue("@Password",Password );
                cmnd.Parameters.AddWithValue("@Privilage", Privilage);
                cmnd.Parameters.AddWithValue("@Name", Name);
                
                cmnd.ExecuteNonQuery();
            }
            catch (Exception ex) {
                Logger tempLogger = new Logger(ex.ToString());
            }
            
        }
        public int updatePrivilage(string EmailID, string Privilage) {
            int rows = -1;
            try
            {
                string type = "Privilage";
                string cmndstring =
                    "UPDATE dbo.Credentials SET " + type + "=@value WHERE EmailID=@EmailID";
                SqlCommand cmnd = new SqlCommand(cmndstring, conn);
                cmnd.Parameters.AddWithValue("@EmailID", EmailID);

                cmnd.Parameters.AddWithValue("@value", Privilage);
                rows = cmnd.ExecuteNonQuery();
                return rows;
            }
            catch (Exception ex)
            {
                Logger tempLogger = new Logger(ex.ToString());
                return rows;
            }
        }
        public int deleteUser(string EmailID) {
            int rows = -1;
            try
            {
                string cmndstring = "DELETE FROM dbo.Credentials WHERE EmailID=@id";
                SqlCommand cmnd = new SqlCommand(cmndstring, conn);
                cmnd.Parameters.AddWithValue("@id", EmailID);
                rows = cmnd.ExecuteNonQuery();
                return rows;
            }
            catch (Exception ex)
            {
                Logger tempLogger = new Logger(ex.ToString());
                return rows;
            }
        }

    }
}
