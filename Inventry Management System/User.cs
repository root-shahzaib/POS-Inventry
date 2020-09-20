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
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
           // DatabaseConnector conec = new DatabaseConnector();
            //conec.AddUserData();
            // This above 2 line was execute only first time to Insert Data in database
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DatabaseConnector connector = new DatabaseConnector();
            connector.ConnectSql();
            connector.UpdateUserData(textBox2.Text,textBox3.Text);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
