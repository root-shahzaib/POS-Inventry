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
    public partial class Dashboard : Form
    {

        public Dashboard()
        {
            InitializeComponent();
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Cashier cashier = new Cashier();
            cashier.Show();
        }

        private void dashboardbutton_Click(object sender, EventArgs e)
        {

        }

        private void suppliersbutton_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier();
            supplier.Show();
        }

        private void productentry_Click(object sender, EventArgs e)
        {
            Products productentry = new Products();
            productentry.Show();
        }

       

        private void expensedetail_Click(object sender, EventArgs e)
        {
            ExpenseDetail detail = new ExpenseDetail();
            detail.Show();
        }

        private void userbutton_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm one = new LoginForm();
            one.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lableclock.Text = DateTime.Now.ToString("HH:mm:ss");
            DateTime dt =  DateTime.Now;

            datelable.Text = dt.ToString();

        }
    }
}
