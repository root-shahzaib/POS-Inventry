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
    public partial class Products : Form
    {
        DataTable dt1 = new DataTable();
        String oldCompanyname, oldProductname, oldProductid, oldPurchaseprice, oldSellprice;
        String newCompanyname, newProductname, newProductid, newPurchaseprice, newSellprice;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void updatebutton_Click(object sender, EventArgs e)
        {
            DatabaseConnector database = new DatabaseConnector();
            database.ConnectSql();
            newCompanyname = comboBox1.Text;
            newProductname = producttxt.Text;
            newProductid = productidtxt.Text;
            newPurchaseprice = purchasepricetxt.Text;
            newSellprice = sellpricetxt.Text;
            database.UpdateProductData(newCompanyname, newProductname, newProductid, newPurchaseprice,newSellprice,
                oldCompanyname, oldProductname, oldProductid, oldPurchaseprice, oldSellprice);
            database.GetProductData(productgridview,dt1);

        }

        public Products()
        {
            InitializeComponent();
            DatabaseConnector database = new DatabaseConnector();
            database.ConnectSql();
            database.ComboValues(comboBox1);
            database.GetProductData(productgridview, dt1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatabaseConnector database = new DatabaseConnector();
            database.ConnectSql();
            database.InsertProductData(comboBox1.Text,producttxt.Text,productidtxt.Text,purchasepricetxt.Text,sellpricetxt.Text);
            database.GetProductData(productgridview, dt1);
        }

        private void searchtxtbox_TextChanged(object sender, EventArgs e)
        {
            DataView dataview = new DataView(dt1);
            dataview.RowFilter = String.Format("CompanyName LIKE '%{0}%'", searchtxtbox.Text);
            productgridview.DataSource = dataview;
        }

        private void removebutton_Click(object sender, EventArgs e)
        {
            DatabaseConnector database = new DatabaseConnector();
            database.ConnectSql();
            comboBox1.Text = "";
            producttxt.Text = "";
            productidtxt.Text = "";
            purchasepricetxt.Text = "";
            sellpricetxt.Text = "";
            database.RemoveProductData(oldCompanyname,oldProductid);
            database.GetProductData(productgridview, dt1);
        }

        private void productgridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow data = productgridview.Rows[e.RowIndex];

                comboBox1.Text = data.Cells["CompanyName"].Value.ToString();
                producttxt.Text = data.Cells["ProductName"].Value.ToString();
                productidtxt.Text = data.Cells["ProductID"].Value.ToString();
                purchasepricetxt.Text = data.Cells["PurchasePrice"].Value.ToString();
                sellpricetxt.Text = data.Cells["SellPrice"].Value.ToString();

                oldCompanyname = data.Cells["CompanyName"].Value.ToString();
                oldProductname = data.Cells["ProductName"].Value.ToString();
                oldProductid = data.Cells["ProductID"].Value.ToString();
                oldPurchaseprice = data.Cells["PurchasePrice"].Value.ToString();
                oldSellprice = data.Cells["SellPrice"].Value.ToString();


            }
        }
    }
}
