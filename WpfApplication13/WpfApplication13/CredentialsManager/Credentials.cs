using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WpfApplication13
{
    public partial class Credentials : Form
    {
        ConnectionManager manager = new ConnectionManager();
        SqlConnection conn;
        public Credentials()
        {
           
            Application.EnableVisualStyles();
            InitializeComponent();
            conn = manager.ConnectToDatabase();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string EmailID = textBox1.Text;

                CredentialsManager manager = new CredentialsManager(conn);
                manager.ApproveNewUser(EmailID);
                int rows = manager.deletePending(EmailID);
                if (rows == -1) MessageBox.Show("Cannot not add User!");

                DataTable table = manager.updateTable();
                credentialsBindingSource.DataSource = table;
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = credentialsBindingSource;
                dataGridView1.Refresh();

                DataTable table2 = manager.updateAnotherTable();
                pendingCredentialsBindingSource.DataSource = table2;
                dataGridView2.ReadOnly = true;
                dataGridView2.DataSource = pendingCredentialsBindingSource;
                dataGridView2.Refresh();
            }
            catch (Exception ex) {
                Logger logger = new Logger(ex.ToString());
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conn.Close();
            this.Close();
        }

        private void Credentials_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lightERP_DBaseDataSet_Credentials.Credentials' table. You can move, or remove it, as needed.
            this.credentialsTableAdapter1.Fill(this.lightERP_DBaseDataSet_Credentials.Credentials);
            // TODO: This line of code loads data into the 'lightERP_DBaseDataSetCredentials.Credentials' table. You can move, or remove it, as needed.
            this.credentialsTableAdapter.Fill(this.lightERP_DBaseDataSetCredentials.Credentials);
            // TODO: This line of code loads data into the 'lightERP_DBaseDataSet_PendingCredentials.PendingCredentials' table. You can move, or remove it, as needed.
            this.pendingCredentialsTableAdapter.Fill(this.lightERP_DBaseDataSet_PendingCredentials.PendingCredentials);
            // TODO: This line of code loads data into the 'lightERP_DBaseDataSet_Credentials.Credentials' table. You can move, or remove it, as needed.
            //this.credentialsTableAdapter.Fill(this.lightERP_DBaseDataSet_Credentials.Credentials);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string EmailID = textBox7.Text;
                string Privilage = comboBox1.Text;
                CredentialsManager mngr = new CredentialsManager(conn);
                int rows = mngr.updatePrivilage(EmailID, Privilage);
                if (rows == -1) MessageBox.Show("Update Failed");
                DataTable table = mngr.updateTable();
                credentialsBindingSource.DataSource = table;
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = credentialsBindingSource;
                dataGridView1.Refresh();
            }
            catch (Exception ex) {
                Logger logger = new Logger(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string EmailID = textBox5.Text;
                CredentialsManager mngr = new CredentialsManager(conn);
                int rows = mngr.deleteUser(EmailID);
                if (rows == -1) MessageBox.Show("Update Failed");
                DataTable table = mngr.updateTable();
                credentialsBindingSource.DataSource = table;
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = credentialsBindingSource;
                dataGridView1.Refresh();
            }
            catch (Exception ex) {
                Logger logger = new Logger(ex.ToString());
            }
        }
    }
}
