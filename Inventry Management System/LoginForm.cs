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

namespace Inventry_Management_System
{
    public partial class LoginForm : Form
    {
        SqlConnection sqlcon;
        String ConnectionString = @"Data Source=DESKTOP-TBGF61J\SQLEXPRESS;Initial Catalog=POSDB;Integrated Security=True";
        SqlDataAdapter sqlDataAdapter;
        String User, Pass;
        


        public LoginForm()
        {
            InitializeComponent();
        }
        private void loginbutton_Click(object sender, EventArgs e)
        {
            GetUserDataForLogin();
            if(User == usernamelogintext.Text && Pass == passlogintext.Text)
            {
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Hide();
            }
           else
            {
                MessageBox.Show("Please Enter Correct Information");
            }
           


        }
      
        private void usernamelogintext_TextChanged(object sender, EventArgs e)
        {

        }
        private void exitbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void GetUserDataForLogin()
        {
            sqlcon = new SqlConnection(ConnectionString);
            sqlDataAdapter = new SqlDataAdapter();
            DataSet dataSet = new DataSet();
            String Query = "Select * FROM ChangeUser";
            try
            {
                sqlcon.Open();
                sqlDataAdapter.SelectCommand = new SqlCommand(Query, sqlcon);
                sqlDataAdapter.Fill(dataSet);
                User = dataSet.Tables[0].Rows[0].ItemArray[1].ToString();
                Pass = dataSet.Tables[0].Rows[0].ItemArray[2].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
