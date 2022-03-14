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
    public partial class HR : Form
    {
        ConnectionManager manager = new ConnectionManager();
        SqlConnection conn;
        public HR()
        {
            Application.EnableVisualStyles() ;
            InitializeComponent();

        }

        private void HR_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lightERP_DBaseDataSet_SalaryPayment.SalaryPayment' table. You can move, or remove it, as needed.
            this.salaryPaymentTableAdapter.Fill(this.lightERP_DBaseDataSet_SalaryPayment.SalaryPayment);
            // TODO: This line of code loads data into the 'lightERP_DBaseDataSet_EmployeeDuty.EmployeeDuty' table. You can move, or remove it, as needed.
            this.employeeDutyTableAdapter.Fill(this.lightERP_DBaseDataSet_EmployeeDuty.EmployeeDuty);
            // TODO: This line of code loads data into the 'lightERP_DBaseDataSet_EmployeeDuty.EmployeeDuty' table. You can move, or remove it, as needed.
            this.employeeDutyTableAdapter.Fill(this.lightERP_DBaseDataSet_EmployeeDuty.EmployeeDuty);
            // TODO: This line of code loads data into the 'lightERP_DBaseDataSet_EmployeeInfo.EmployeeInfo' table. You can move, or remove it, as needed.
            this.employeeInfoTableAdapter.Fill(this.lightERP_DBaseDataSet_EmployeeInfo.EmployeeInfo);
            
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text;
                string emailID = textBox2.Text;
                string phone = textBox3.Text;
                string street = textBox4.Text;
                string city = textBox5.Text;

                EmployeeInfo emplinf = new EmployeeInfo(conn);
                emplinf.addEmployee(name, emailID, phone, street, city);

                DataTable table = emplinf.updateTable();
                employeeInfoBindingSource.DataSource = table;
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = employeeInfoBindingSource;
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
                int id = Int32.Parse(textBox6.Text);
                string value = textBox7.Text;
                string type = comboBox1.Text;

                EmployeeInfo emplinf = new EmployeeInfo(conn);
                int rows = emplinf.updateEmployeeInfo(id, type, value);
                if (rows == 0) MessageBox.Show("Not Updated");

                DataTable table = emplinf.updateTable();
                employeeInfoBindingSource.DataSource = table;
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = employeeInfoBindingSource;
                dataGridView1.Refresh();
            }
            catch (Exception ex) {
                Logger logger = new Logger(ex.ToString());
            }
        }

        private void closedevt(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int employeeID = Int32.Parse(textBox9.Text);
                string department = textBox10.Text;
                string position = textBox11.Text;
                int salary = Int32.Parse(textBox12.Text);
                DateTime joinDate = dateTimePicker1.Value;

                EmployeeDuty empdt = new EmployeeDuty(conn);
                empdt.addDuty(employeeID, department, position, salary, joinDate);

                DataTable table = empdt.updateTable();
                employeeDutyBindingSource.DataSource = table;
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = employeeDutyBindingSource;
                dataGridView1.Refresh();
            }
            catch (Exception ex) {
                Logger logger = new Logger(ex.ToString());
            }
        }

        private void HR_Shown(object sender, EventArgs e)
        {
            conn = manager.ConnectToDatabase();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int employeeID = Int32.Parse(textBox8.Text);
                string type = comboBox2.Text;
                string value = textBox13.Text;

                EmployeeDuty empdt = new EmployeeDuty(conn);
                int rows = empdt.updateInfo(employeeID, type, value);
                if (rows == 0) MessageBox.Show("Not Updated");
                DataTable table = empdt.updateTable();

                employeeDutyBindingSource.DataSource = table;
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = employeeDutyBindingSource;
                dataGridView1.Refresh();
            }
            catch (Exception ex) {
                Logger logger = new Logger(ex.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int employeeID = Int32.Parse(textBox14.Text);
                DateTime date = dateTimePicker3.Value;

                EmployeeDuty empdt = new EmployeeDuty(conn);
                int rows = empdt.deleteDuty(employeeID, date);
                if (rows == 0) MessageBox.Show("Not Updated");
                DataTable table = empdt.updateTable();

                employeeDutyBindingSource.DataSource = table;
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = employeeDutyBindingSource;
                dataGridView1.Refresh();
            }
            catch (Exception ex) {
                Logger logger = new Logger(ex.ToString());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int EmployeeID = Int32.Parse(textBox15.Text);
                float Amount = float.Parse(textBox16.Text);
                string FromMonthYear =
                    comboBox3.Text + "-" + comboBox4.Text;
                string ToMonthYear =
                    comboBox5.Text + "-" + comboBox6.Text;
                int BankTransactionID = Int32.Parse(textBox17.Text);
                DateTime PaymentDate = dateTimePicker3.Value;

                SalaryPayment slp = new SalaryPayment(conn);
                slp.updateSalaryPayment(EmployeeID, Amount, FromMonthYear, ToMonthYear,
                    BankTransactionID, PaymentDate);

                DataTable table = slp.updateTable();

                salaryPaymentBindingSource.DataSource = table;
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = salaryPaymentBindingSource;
                dataGridView1.Refresh();
            }
            catch (Exception ex) {
                Logger logger = new Logger(ex.ToString());
            }
        }
    }
}
