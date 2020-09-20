using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventry_Management_System
{
    public partial class Cashier : Form
    {

        String CompanyName, ProductName, SellPrice;
        public Cashier()
        {
            InitializeComponent();
            DatabaseConnector database = new DatabaseConnector();
            database.ConnectSql();
            database.ComboValues(comboBox1);
            database.ComboProductValues(comboBox2,comboBox1.Text);
            database.GetCashierData(cashiergrid);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatabaseConnector database = new DatabaseConnector();
            database.ConnectSql();
            database.ComboValues(comboBox1);
            database.ComboProductValues(comboBox2, comboBox1.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatabaseConnector database = new DatabaseConnector();
            database.ConnectSql();
         
          
            database.GetSellPrice(textBox3, comboBox2.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DatabaseConnector database = new DatabaseConnector();
            database.ConnectSql();
            database.InsertCashierData(comboBox1.Text,comboBox2.Text,textBox3.Text);
            database.GetCashierData(cashiergrid);
            database.SumTotalPrice(paytxt);


        }

        private void button1_Click(object sender, EventArgs e)
        {

            DatabaseConnector database = new DatabaseConnector();
            database.ConnectSql();
            database.DeleteFullCashierTable();
            database.GetCashierData(cashiergrid);
            paytxt.Text = "";



        }

        private void cashierreportbtn_Click(object sender, EventArgs e)
        {
            myreport rep = new myreport();
            rep.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DatabaseConnector database = new DatabaseConnector();
            database.ConnectSql();
            database.RemoveCashierRow(CompanyName,ProductName);
            database.GetCashierData(cashiergrid);
            database.SumTotalPrice(paytxt);


        }

        private void cashiergrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow data = cashiergrid.Rows[e.RowIndex];
                CompanyName = data.Cells["CompanyName"].Value.ToString();
                ProductName = data.Cells["ProductName"].Value.ToString();
                SellPrice = data.Cells["SellPrice"].Value.ToString();
              }
        }
    }
}
