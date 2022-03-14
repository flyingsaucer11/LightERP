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
    public partial class CRM : Form
    {
        ConnectionManager manager = new ConnectionManager();
        SqlConnection conn;
        public CRM()
        {
            Application.EnableVisualStyles();
            InitializeComponent();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void CRM_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lightERP_DBaseDataSet_CustomerFedback.CustomerFeedback' table. You can move, or remove it, as needed.
            this.customerFeedbackTableAdapter.Fill(this.lightERP_DBaseDataSet_CustomerFedback.CustomerFeedback);
            conn=manager.ConnectToDatabase();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Int32.Parse(textBox1.Text);
                string name = textBox2.Text;
                string email = textBox3.Text;
                DateTime date = dateTimePicker1.Value;
                string feedback = textBox5.Text;
                string note = textBox6.Text;
                CustomerFeedback cmfdb = new CustomerFeedback(conn);
                cmfdb.addFeedback(id, name, email, date, feedback, note);

                DataTable table = cmfdb.updateTable();
                customerFeedbackBindingSource.DataSource = table;
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = customerFeedbackBindingSource;
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
                int id = Int32.Parse(textBox7.Text);
                string note = textBox8.Text;
                CustomerFeedback cmfdb = new CustomerFeedback(conn);
                int effectedeRows = cmfdb.updateFeedback(id, note);
                if (effectedeRows == 0) MessageBox.Show("No customer assigned with that id");

                DataTable table = cmfdb.updateTable();
                customerFeedbackBindingSource.DataSource = table;
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = customerFeedbackBindingSource;
                dataGridView1.Refresh();
            }
            catch (Exception ex) {
                Logger logger = new Logger(ex.ToString());
            }
        }

        private void closingevt(object sender, FormClosingEventArgs e)
        {
            manager.DisconnectFromDatabase();
        }
    }
}
