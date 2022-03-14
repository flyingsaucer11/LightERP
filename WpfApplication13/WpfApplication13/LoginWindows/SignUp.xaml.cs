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
using System.Security;
using System.Data;
namespace WpfApplication13
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        ConnectionManager manager = new ConnectionManager();
        SqlConnection conn;
        public SignUp()
        {
            InitializeComponent();
            
        }

        private void input(object sender, TextCompositionEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string EmailID = box2.Text;
                string Password = box3.Password;
                string Privilage = box5.Text;
                string Name = box1.Text;

                if (box3.Password != box4.Password)
                {
                    Error er = new Error();
                    er.messageText.Content = "Password Mismatched!";
                    er.Show();
                }
                else
                {
                    
                    CredentialsManager crdn = new CredentialsManager(conn);
                    crdn.RequestForSignup(EmailID, Password, Privilage, Name);
                    Done dn = new Done();
                    dn.Show();
                    this.Close();
                    conn.Close();
                }
            }
            catch (Exception ex) {
                Logger logger = new Logger(ex.ToString());
            }
        }

        private void passChanged(object sender, RoutedEventArgs e)
        {
            if (box3.Password == box4.Password)
                passMatch.Content = "Matched!";
            else passMatch.Content = "Not Matched!";
                //box4.SelectionBrush.SetValue(PasswordBox.SelectionBrushProperty,
               //     PasswordBox.SelectionBrushProperty.DefaultMetadata.DefaultValue);
        }

        private void loaded(object sender, RoutedEventArgs e)
        {
            conn = manager.ConnectToDatabase(1);
        }
    }
}
