using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventry_Management_System
{
    public partial class ExpenseDetail : Form
    {
        
        //int IndexRow;
        String ExpenseType, Costs;
        int ID;
        String oldtype, oldcost;
        DataTable dt1 = new DataTable();
        public ExpenseDetail()
        {
            InitializeComponent();
            comboBox1.Items.Add("Tea");
            comboBox1.Items.Add("Lunch");
            comboBox1.Items.Add("Snaks");
            comboBox1.Items.Add("Dinner");
            DatabaseConnector database = new DatabaseConnector();
            database.GetExpenseData(dataGridView1,dt1);

        }
        private void ExpenseDetail_Load(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
              DataGridViewRow data =   dataGridView1.Rows[e.RowIndex];

                textBox2.Text = data.Cells["Cost"].Value.ToString();
                comboBox1.Text = data.Cells["ExpenseType"].Value.ToString();

                Costs = data.Cells["Cost"].Value.ToString();
                ExpenseType = data.Cells["ExpenseType"].Value.ToString();

                oldcost = data.Cells["Cost"].Value.ToString();
                oldtype = data.Cells["ExpenseType"].Value.ToString();
            }
        }     
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            DatabaseConnector database = new DatabaseConnector();
            database.ConnectSql();
            database.InsertExpenseData(comboBox1.Text,textBox2.Text);
            database.GetExpenseData(dataGridView1, dt1);
        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            


        }
        private void button4_Click(object sender, EventArgs e)
        {
            DatabaseConnector database = new DatabaseConnector();
            database.ConnectSql();
            comboBox1.Text = "";
            textBox2.Text = "";
            database.RemoveExpenseData(ExpenseType, Costs);
            database.GetExpenseData(dataGridView1, dt1);
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            DataView dataview = new DataView(dt1);
            dataview.RowFilter = String.Format("ExpenseType LIKE '%{0}%'", textBox5.Text);
            dataGridView1.DataSource = dataview;
        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DatabaseConnector database = new DatabaseConnector();
            database.ConnectSql();
            Costs = textBox2.Text;
            ExpenseType = comboBox1.Text;
            database.UpdateExpenseData(ExpenseType, Costs,oldtype,oldcost);
            database.GetExpenseData(dataGridView1, dt1);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
