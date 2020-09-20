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
    public partial class Supplier : Form
    {
        DataTable dt1 = new DataTable();
        String suppliername, phone, address;
        String newsupplier, newphone, newaddress;
        public Supplier()
        {
            InitializeComponent();
            DatabaseConnector database = new DatabaseConnector();
            database.GetSupplierData(suppliergrid, dt1);
        }

        private void Supplier_Load(object sender, EventArgs e)
        {

        }

        private void suppliergrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow data = suppliergrid.Rows[e.RowIndex];

                companytxt.Text = data.Cells["SupplierName"].Value.ToString();
                phonetxt.Text = data.Cells["PhoneNo"].Value.ToString();
                addrestxt.Text = data.Cells["Address"].Value.ToString();

                suppliername = data.Cells["SupplierName"].Value.ToString();
                phone = data.Cells["PhoneNo"].Value.ToString();
                address = data.Cells["Address"].Value.ToString();


            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            DataView dataview = new DataView(dt1);
            dataview.RowFilter = String.Format("SupplierName LIKE '%{0}%'", textBox5.Text);
            suppliergrid.DataSource = dataview;
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            DatabaseConnector database = new DatabaseConnector();
            database.ConnectSql();
            newsupplier = companytxt.Text;
            newphone = phonetxt.Text;
            newaddress = addrestxt.Text;
            database.UpdateSupplierData(newsupplier,newphone,newaddress, suppliername,phone, address);
            database.GetSupplierData(suppliergrid, dt1);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DatabaseConnector database = new DatabaseConnector();
            database.ConnectSql();
            database.InsertSupplierData(companytxt.Text, phonetxt.Text, addrestxt.Text);
            database.GetSupplierData(suppliergrid, dt1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DatabaseConnector database = new DatabaseConnector();
            database.ConnectSql();
            companytxt.Text = "";
            phonetxt.Text = "";
            addrestxt.Text = " ";
            database.RemoveSupplierData(suppliername,phone,address);
            database.GetSupplierData(suppliergrid, dt1);
        }
    }
}
