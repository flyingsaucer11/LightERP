using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace WpfApplication13
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        ConnectionManager connectionmanager = new ConnectionManager();
        SqlConnection conn;
        public Login()
        {
            InitializeComponent();
           
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                conn = connectionmanager.ConnectToDatabase(1);

                string ID = IDTextBox.Text;
                string pass = PassPasswordBox.Password;

                CredentialsManager manager = new CredentialsManager(conn);
                int IDCheck = manager.checkForID(ID, pass);
                conn.Close();
                if (IDCheck == -1)
                {
                    Error er = new Error();
                    er.messageText.Content = "Wrong ID or Password";
                    er.Show();
                }
                else
                {
                    //MessageBox.Show(IDCheck.ToString());
                    MainWindow mn = new MainWindow(IDCheck);
                    int n = IDCheck;
                    if (n == 1)
                    {

                    }
                    else if (n == 2)
                    {
                        mn.cred.IsEnabled = false;
                        mn.inv.IsEnabled = false;
                        mn.hr.IsEnabled = true;
                        mn.crm.IsEnabled = false;
                        mn.fin.IsEnabled = false;
                        //InitializeComponent();
                    }
                    else if (n == 3)
                    {
                        mn.cred.IsEnabled = false;
                        mn.inv.IsEnabled = true;
                        mn.hr.IsEnabled = false;
                        mn.crm.IsEnabled = false;
                        mn.fin.IsEnabled = false;
                        //InitializeComponent();
                    }
                    else if (n == 4)
                    {
                        mn.cred.IsEnabled = false;
                        mn.inv.IsEnabled = false;
                        mn.hr.IsEnabled = false;
                        mn.crm.IsEnabled = false;
                        mn.fin.IsEnabled = true;
                        //InitializeComponent();
                    }
                    else if (n == 5)
                    {
                        mn.cred.IsEnabled = false;
                        mn.inv.IsEnabled = false;
                        mn.hr.IsEnabled = false;
                        mn.crm.IsEnabled = true;
                        mn.fin.IsEnabled = false;
                        //InitializeComponent();
                    }

                    mn.Show();
                    this.Close();
                }
            }
            catch (Exception ex) {
                Logger lg = new Logger(ex.ToString());
            }
            
        }

        private void closed(object sender, EventArgs e)
        {
           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SignUp sn = new SignUp();
            sn.Show();
            this.Close();
        }

        private void debug(object sender, RoutedEventArgs e)
        {
            MainWindow mn = new MainWindow();
            mn.Show();
            this.Close();
        }
    }
}
