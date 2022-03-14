using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Forms;

namespace WpfApplication13
{
    
    public class ConnectionManager
    {
        SqlConnection conn { get; set; }
        String connectionString { get; set; }
        public dBaseConnection msg { get; set; }

        public SqlConnection ConnectToDatabase(){
            msg = new dBaseConnection();
            msg.Show();
            try
            {
                
                connectionString =
                "Data Source=(LocalDB)\\v11.0;AttachDbFilename=\"C:\\Users\\Abdur Raafee\\documents\\visual studio 2012\\Projects\\WpfApplication13\\WpfApplication13\\LightERP_DBase.mdf\";Integrated Security=True;Connect Timeout=30";
                conn = new SqlConnection(connectionString);
                conn.Open();
                msg.textBlock1.Text = "Connected";

                System.Windows.Forms.NotifyIcon ntf = new NotifyIcon();
                //ntf.Visible = true;
                //ntf.ShowBalloonTip(10000, "Light ERP", "Connected", ToolTipIcon.Info);
                //ntf.Visible = true;

                return conn;
            }
            catch (Exception ex)
            {
                Logger tempLogger = new Logger(ex.ToString());
                return null;
            }
        }
        public SqlConnection ConnectToDatabase(int n)
        {
            try
            {
                if (n == 1)
                {
                    connectionString =
                    "Data Source=(LocalDB)\\v11.0;AttachDbFilename=\"C:\\Users\\Abdur Raafee\\documents\\visual studio 2012\\Projects\\WpfApplication13\\WpfApplication13\\LightERP_DBase.mdf\";Integrated Security=True;Connect Timeout=30";
                    conn = new SqlConnection(connectionString);
                    conn.Open();
                }
                return conn;
            }
            catch (Exception ex)
            {
                Logger tempLogger = new Logger(ex.ToString());
                return null;
            }
        }
        public void DisconnectFromDatabase() {
            dBaseConnection msg = new dBaseConnection();
            msg.textBlock1.Text = "Disconnecting...";
            msg.Show();
            try
            {
                conn.Close();
                msg.textBlock1.Text = "Disconnected";
            }
            catch (Exception ex)
            {
                Logger tempLogger = new Logger(ex.ToString());
            }
        }
    }
}
