using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
namespace WpfApplication13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ConnectionManager manager = new ConnectionManager();
        SqlConnection conn;
        int n=0;
        public MainWindow()
        {
            InitializeComponent();
            
        }
        public MainWindow(int n)
        {
            this.n = n;

            InitializeComponent();
            

        }

        private void exitMainEvt(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void aboutMainEvt(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void mainInventoryClickEvt(object sender, RoutedEventArgs e)
        {
            
            Inventory inventory = new Inventory();
            inventory.Show();
            
        }

        private void helpMainEvt(object sender, RoutedEventArgs e)
        {
            HelpViewer help = new HelpViewer();
            help.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            HR hr = new HR();
            hr.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CRM crm = new CRM();
            crm.Show();
        }

        private void opencredentialevt(object sender, RoutedEventArgs e)
        {
            Credentials crd = new Credentials();
            crd.Show();

        }

        private void loadedEvt(object sender, RoutedEventArgs e)
        {
           
        }

        private void gotFocusEvt(object sender, RoutedEventArgs e)
        {
            
        }

        private void focusmain(object sender, RoutedEventArgs e)
        {
            
        }

        private void mouseEnter(object sender, MouseEventArgs e)
        {
            
            
        }

        private void contentrendered(object sender, EventArgs e)
        {
            conn = manager.ConnectToDatabase(1);
            mainWindowsStatusText1.Text = "Status: Server Available";
            conn.Dispose();
        }

        private void afterinitialized(object sender, EventArgs e)
        {
            
        }

    }
}
