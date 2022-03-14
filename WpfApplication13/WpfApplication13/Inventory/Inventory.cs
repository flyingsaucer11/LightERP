using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace WpfApplication13
{
    public partial class Inventory : Form
    {
        ConnectionManager manager = new ConnectionManager();
        SqlConnection conn;
        public Inventory()
        {
            Application.EnableVisualStyles();
            InitializeComponent();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lightERP_DBaseDataSet_Sales.Sales' table. You can move, or remove it, as needed.
            this.salesTableAdapter.Fill(this.lightERP_DBaseDataSet_Sales.Sales);
            // TODO: This line of code loads data into the 'lightERP_DBaseDataSet_Purchase.Purchase' table. You can move, or remove it, as needed.
            this.purchaseTableAdapter.Fill(this.lightERP_DBaseDataSet_Purchase.Purchase);
            // TODO: This line of code loads data into the 'lightERP_DBaseDataSet_Products.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.lightERP_DBaseDataSet_Products.Products);
            conn = manager.ConnectToDatabase();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Int32.Parse(textBox1.Text);
                string name = textBox2.Text;
                string company = textBox3.Text;
                string catagory = textBox9.Text;
                string note = textBox10.Text;
                float amount = float.Parse(textBox11.Text);
                string unit = textBox12.Text;

                Products products = new Products(conn);
                products.add(id, name, company, catagory, note, amount, unit);

                DataTable table = products.updateTable();
                productsBindingSource.DataSource = table;
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = productsBindingSource;
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
                int id = Int32.Parse(textBox4.Text);
                Products products = new Products(conn);
                int rows = products.delete(id);
                if (rows == 0) MessageBox.Show("id not found");

                DataTable table = products.updateTable();
                productsBindingSource.DataSource = table;
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = productsBindingSource;
                dataGridView1.Refresh();
            }
            catch (Exception ex) {
                Logger logger = new Logger(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Int32.Parse(textBox5.Text);
                float amount = float.Parse(textBox6.Text);
                DateTime date = dateTimePicker1.Value;

                Products products = new Products(conn);
                Purchase purchase = new Purchase(conn);
                purchase.add(0, id, amount, date);

                DataTable table = products.updateTable();
                productsBindingSource.DataSource = table;
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = productsBindingSource;
                dataGridView1.Refresh();

                table = purchase.updateTable();
                purchaseBindingSource.DataSource = table;
                dataGridView2.ReadOnly = true;
                dataGridView2.DataSource = purchaseBindingSource;
                dataGridView2.Refresh();
            }
            catch (Exception ex) {
                Logger logger = new Logger(ex.ToString());
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Int32.Parse(textBox7.Text);
                float amount = float.Parse(textBox8.Text);
                DateTime date = dateTimePicker2.Value;

                Products products = new Products(conn);
                Sales sales = new Sales(conn);
                sales.add(0, id, amount, date);

                DataTable table = products.updateTable();
                productsBindingSource.DataSource = table;
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = productsBindingSource;
                dataGridView1.Refresh();

                table = sales.updateTable();
                salesBindingSource.DataSource = table;
                dataGridView3.ReadOnly = true;
                dataGridView3.DataSource = salesBindingSource;
                dataGridView3.Refresh();
            }
            catch (Exception ex) {
                Logger logger = new Logger(ex.ToString());
            }
        }

        private void formClosedEvt(object sender, FormClosedEventArgs e)
        {
            conn.Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader reader = new StreamReader("serialDevice.txt");
                while (true)
                {
                    string str1 = reader.ReadLine().ToString();
                    if (str1 == "exit") break;
                    string str2 = reader.ReadLine().ToString();
                    //+MessageBox.Show(str1);

                    int id = Int32.Parse(str1);
                    float amount = float.Parse(str2);
                    DateTime date = DateTime.Today;

                    Products products = new Products(conn);
                    Sales sales = new Sales(conn);
                    sales.add(0, id, amount, date);

                    DataTable table = products.updateTable();
                    productsBindingSource.DataSource = table;
                    dataGridView1.ReadOnly = true;
                    dataGridView1.DataSource = productsBindingSource;
                    dataGridView1.Refresh();

                    table = sales.updateTable();
                    salesBindingSource.DataSource = table;
                    dataGridView2.ReadOnly = true;
                    dataGridView2.DataSource = salesBindingSource;
                    dataGridView2.Refresh();
                }
                reader.Close();
            }
            catch (Exception ex) {
                Logger logger = new Logger(ex.ToString());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader reader = new StreamReader("serialDevice.txt");
                while (true)
                {
                    string str1 = reader.ReadLine().ToString();
                    string str2 = reader.ReadLine().ToString();
                    MessageBox.Show(str1);
                    if (str1 == "exit") break;
                    int id = Int32.Parse(str1);
                    float amount = float.Parse(str2);
                    DateTime date = DateTime.Today;

                    Products products = new Products(conn);
                    Sales sales = new Sales(conn);
                    sales.add(0, id, amount, date);

                    DataTable table = products.updateTable();
                    productsBindingSource.DataSource = table;
                    dataGridView1.ReadOnly = true;
                    dataGridView1.DataSource = productsBindingSource;
                    dataGridView1.Refresh();

                    table = sales.updateTable();
                    salesBindingSource.DataSource = table;
                    dataGridView3.ReadOnly = true;
                    dataGridView3.DataSource = salesBindingSource;
                    dataGridView3.Refresh();
                }
                reader.Close();
            }
            catch (Exception ex) {
                Logger logger = new Logger(ex.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string company;
                string catagory;
                if (textBox13.Text != null)
                    company = textBox13.Text;
                else company = "";
                if (textBox14.Text != null)
                    catagory = textBox14.Text;
                else catagory = "";
                Products pr = new Products(conn);
                DataTable table = pr.searchByCompanyAndCatagory(company, catagory);
                productsBindingSource.DataSource = table;
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = productsBindingSource;
                dataGridView1.Refresh();
            }
            catch (Exception ex) {
                Logger logger = new Logger(ex.ToString());
            }
        }
    }
}