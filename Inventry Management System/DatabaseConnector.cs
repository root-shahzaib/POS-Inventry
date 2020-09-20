using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;

namespace Inventry_Management_System
{
    class DatabaseConnector
    {
        SqlConnection sqlcon;
        String ConnectionString = @"Data Source=DESKTOP-TBGF61J\SQLEXPRESS;Initial Catalog=POSDB;Integrated Security=True";
        SqlDataAdapter sqlDataAdapter;
        public void ConnectSql()
        {
            sqlcon = new SqlConnection(ConnectionString);
            sqlcon.Open();
            if(sqlcon.State == ConnectionState.Open)
            {
                MessageBox.Show("Database Connected");
            }
            else
            {
                MessageBox.Show("Database Not Connected");
            }
        }
        // User Detail Functions
        public void UpdateUserData(String Username,String Password)
        {
            sqlcon = new SqlConnection(ConnectionString);

            sqlDataAdapter = new SqlDataAdapter();
            String Query = @"UPDATE ChangeUser SET UserName = '" + Username + "', Passwords = '" +  Password+ "';";
            try
            {
                sqlcon.Open();
                sqlDataAdapter.UpdateCommand = sqlcon.CreateCommand();
                sqlDataAdapter.UpdateCommand.CommandText = Query;
                sqlDataAdapter.UpdateCommand.ExecuteNonQuery();
                MessageBox.Show("Database Updated");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }



        }
        public void AddUserData()
        {
            sqlcon = new SqlConnection(ConnectionString);
            String Query = @"INSERT INTO ChangeUser (ID,UserName,Passwords) VALUES (1,'admin','123a');";
            sqlDataAdapter = new SqlDataAdapter();
            try
            {
                sqlcon.Open();
                sqlDataAdapter.InsertCommand = new SqlCommand(Query,sqlcon);
                sqlDataAdapter.InsertCommand.ExecuteNonQuery();


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
                String user = dataSet.Tables[0].Rows[0].ItemArray[2].ToString();
                String pass = dataSet.Tables[0].Rows[0].ItemArray[3].ToString();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        // Expense Details Functions
        public void InsertExpenseData(String ExpenseType,String Cost)
        {
            sqlcon = new SqlConnection(ConnectionString);
            String Query = @"INSERT INTO ExpenseDetails (ExpenseType,Cost) VALUES ('"+ExpenseType+"','"+Cost+"');";
            sqlDataAdapter = new SqlDataAdapter();
            try
            {
                sqlcon.Open();
                sqlDataAdapter.InsertCommand = new SqlCommand(Query, sqlcon);
                sqlDataAdapter.InsertCommand.ExecuteNonQuery();
                MessageBox.Show("Data Inserted Sucessfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void GetExpenseData(DataGridView dataGridView,DataTable dt1)
        {
            sqlcon = new SqlConnection(ConnectionString);
            sqlDataAdapter = new SqlDataAdapter();
            DataSet dataSet = new DataSet();
            String Query = "Select * FROM ExpenseDetails";
            try
            {
                sqlcon.Open();
                sqlDataAdapter.SelectCommand = new SqlCommand(Query, sqlcon);
                sqlDataAdapter.Fill(dt1);
                sqlDataAdapter.Fill(dataSet);
                dataGridView.DataSource = dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        public void RemoveExpenseData(String oldtype,String oldcost)
        {
            sqlcon = new SqlConnection(ConnectionString);

            sqlDataAdapter = new SqlDataAdapter();
            String Query = @"DELETE ExpenseDetails WHERE ExpenseType = '" + oldtype + "' AND Cost = '" + oldcost + "';";
            try
            {
                sqlcon.Open();
                sqlDataAdapter.DeleteCommand = sqlcon.CreateCommand();
                sqlDataAdapter.DeleteCommand.CommandText = Query;
                sqlDataAdapter.DeleteCommand.ExecuteNonQuery();
                MessageBox.Show("Data Deleted : " + oldtype + "" + oldcost + "");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        public void UpdateExpenseData(String type,String costs,String oldtype,String oldcost)
        {

            sqlcon = new SqlConnection(ConnectionString);

            sqlDataAdapter = new SqlDataAdapter();
            String Query = @"UPDATE ExpenseDetails SET ExpenseType = '" + type + "', Cost = '" + costs + "' WHERE ExpenseType = '"+oldtype+"' AND Cost = '"+oldcost+"';";
            try
            {
                sqlcon.Open();
                sqlDataAdapter.UpdateCommand = sqlcon.CreateCommand();
                sqlDataAdapter.UpdateCommand.CommandText = Query;
                sqlDataAdapter.UpdateCommand.ExecuteNonQuery();
                MessageBox.Show("Data Updated with : "+oldtype + "" +oldcost+" from  this to this  :"+type+""+costs+"");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }
        // Company / Supplier Details
        public void InsertSupplierData(String Suppliername, String phone,String address)
        {
            sqlcon = new SqlConnection(ConnectionString);
            String Query = @"INSERT INTO SupplierDetails (SupplierName,PhoneNo,Address) VALUES ('" + Suppliername + "','" + phone + "','"+address+"');";
            sqlDataAdapter = new SqlDataAdapter();
            try
            {
                sqlcon.Open();
                sqlDataAdapter.InsertCommand = new SqlCommand(Query, sqlcon);
                sqlDataAdapter.InsertCommand.ExecuteNonQuery();
                MessageBox.Show("Data Inserted Sucessfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void GetSupplierData(DataGridView dataGridView, DataTable dt1)
        {
            sqlcon = new SqlConnection(ConnectionString);
            sqlDataAdapter = new SqlDataAdapter();
            DataSet dataSet = new DataSet();
            String Query = "Select * FROM SupplierDetails";
            try
            {
                sqlcon.Open();
                sqlDataAdapter.SelectCommand = new SqlCommand(Query, sqlcon);
                sqlDataAdapter.Fill(dt1);
                sqlDataAdapter.Fill(dataSet);
                dataGridView.DataSource = dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        public void RemoveSupplierData(String suppliername, String phoneno,String address)
        {
            sqlcon = new SqlConnection(ConnectionString);

            sqlDataAdapter = new SqlDataAdapter();
            String Query = @"DELETE SupplierDetails WHERE SupplierName = '" + suppliername + "' AND PhoneNo = '" + phoneno + "' AND Address = '"+address+"';";
            try
            {
                sqlcon.Open();
                sqlDataAdapter.DeleteCommand = sqlcon.CreateCommand();
                sqlDataAdapter.DeleteCommand.CommandText = Query;
                sqlDataAdapter.DeleteCommand.ExecuteNonQuery();
                MessageBox.Show("Data Deleted : " + suppliername + "" + phoneno + "");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        public void UpdateSupplierData(String supplier, String phoneno,String address, String oldsupplier, String oldphone,String oldaddress)
        {

            sqlcon = new SqlConnection(ConnectionString);

            sqlDataAdapter = new SqlDataAdapter();
            String Query = @"UPDATE SupplierDetails SET SupplierName = '" + supplier + "', PhoneNo = '" + phoneno + "' ,Address = '"+address+ "' WHERE SupplierName = '" + oldsupplier + "' AND PhoneNo = '" + oldphone + "' AND Address = '"+oldaddress+"';";
            try
            {
                sqlcon.Open();
                sqlDataAdapter.UpdateCommand = sqlcon.CreateCommand();
                sqlDataAdapter.UpdateCommand.CommandText = Query;
                sqlDataAdapter.UpdateCommand.ExecuteNonQuery();
                MessageBox.Show("Data Updated with : " + oldsupplier + "" + oldphone + " from  this to this  :" + supplier + "" +phoneno+ "");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }
        // Product Details
        public void ComboValues(ComboBox combo)
        {
            sqlcon = new SqlConnection(ConnectionString);
        
            String Query = "Select * FROM SupplierDetails";
            SqlDataReader sqlDataReader;
            try
            {
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand(Query, sqlcon);
                sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    string temp = sqlDataReader["SupplierName"].ToString();
                    combo.Items.Add(temp);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        } // Supplier Combo
        public void ComboProductValues(ComboBox combo,String Companyname)
        {
            sqlcon = new SqlConnection(ConnectionString);

            String Query = "Select * FROM  ProductDetails WHERE CompanyName = '"+Companyname+"';";

            SqlDataReader sqlDataReader;
            try
            {
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand(Query, sqlcon);
                sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    string temp = sqlDataReader["ProductName"].ToString();
                    combo.Items.Add(temp);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        } // Supplier Combo
        public void InsertProductData(String Companyname,String Productname,
            String Productid,String Purchaseprice,String Sellprice)
        {
            sqlcon = new SqlConnection(ConnectionString);
            String Query = @"INSERT INTO ProductDetails (CompanyName,ProductName,ProductID,PurchasePrice,SellPrice) VALUES ('" + Companyname + "','" + Productname + "','"+Productid+"','"+Purchaseprice+"','"+Sellprice+"');";
            sqlDataAdapter = new SqlDataAdapter();
            try
            {
                sqlcon.Open();
                sqlDataAdapter.InsertCommand = new SqlCommand(Query, sqlcon);
                sqlDataAdapter.InsertCommand.ExecuteNonQuery();
                MessageBox.Show("Data Inserted Sucessfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void GetProductData(DataGridView dataGridView, DataTable dt1)
        {
            sqlcon = new SqlConnection(ConnectionString);
            sqlDataAdapter = new SqlDataAdapter();
            DataSet dataSet = new DataSet();
            String Query = "Select * FROM ProductDetails";
            try
            {
                sqlcon.Open();
                sqlDataAdapter.SelectCommand = new SqlCommand(Query, sqlcon);
                sqlDataAdapter.Fill(dt1);
                sqlDataAdapter.Fill(dataSet);
                dataGridView.DataSource = dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        public void RemoveProductData(String Companyname, String ProductId)
        {
            sqlcon = new SqlConnection(ConnectionString);

            sqlDataAdapter = new SqlDataAdapter();
            String Query = @"DELETE ProductDetails WHERE CompanyName = '" + Companyname + "' AND ProductID = '" + ProductId + "';";
            try
            {
                sqlcon.Open();
                sqlDataAdapter.DeleteCommand = sqlcon.CreateCommand();
                sqlDataAdapter.DeleteCommand.CommandText = Query;
                sqlDataAdapter.DeleteCommand.ExecuteNonQuery();
                MessageBox.Show("Data Deleted : " + Companyname + "" + ProductId + "");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        public void UpdateProductData(String newCompanyname, String newProductname, String newProductId, String newPurchaseprice,String newSellprice,
            String oldCompanyname, 
            String oldProductname, String oldProductId, 
            String oldPurchaseprice, String oldSellprice)
        {

            sqlcon = new SqlConnection(ConnectionString);
            sqlDataAdapter = new SqlDataAdapter();
            String Query = @"UPDATE ProductDetails SET CompanyName = '" + newCompanyname + "', ProductName = '" + newProductname + "', ProductID = '" + newProductId + "', PurchasePrice = '" + newPurchaseprice + "', SellPrice = '" + newSellprice + "' WHERE CompanyName = '" + oldCompanyname + "', ProductName = '" + oldProductname + "', ProductID = '" +oldProductId+ "', PurchasePrice = '" + oldPurchaseprice + "', SellPrice = '" + oldSellprice + "';";

            sqlcon.Open();
            sqlDataAdapter.UpdateCommand = sqlcon.CreateCommand();
            sqlDataAdapter.UpdateCommand.CommandText = Query;
            sqlDataAdapter.UpdateCommand.ExecuteNonQuery();
            MessageBox.Show("Data Updated with : " + newCompanyname + "" + newProductId + " from  this to this  :" + oldCompanyname + "" + oldProductId + "");
            
           


        }

        // Cahier Details
       public void GetSellPrice(TextBox textBox,String Productname)
        {
            sqlcon = new SqlConnection(ConnectionString);

            String Query = "Select * FROM  ProductDetails WHERE ProductName = '" + Productname + "';";

            SqlDataReader sqlDataReader;
            try
            {
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand(Query, sqlcon);
                sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    String temp = sqlDataReader["SellPrice"].ToString();
                    textBox.Text = temp;

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        public void GetCashierData(DataGridView dataGridView)
        {

            sqlcon = new SqlConnection(ConnectionString);
            sqlDataAdapter = new SqlDataAdapter();
            DataSet dataSet = new DataSet();
            String Query = "Select * FROM CashierDetail";
            try
            {
                sqlcon.Open();
                sqlDataAdapter.SelectCommand = new SqlCommand(Query, sqlcon);
                sqlDataAdapter.Fill(dataSet);
                dataGridView.DataSource = dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        public void InsertCashierData(String CompanyName,String ProductName,String SellPrice)
        {
            sqlcon = new SqlConnection(ConnectionString);
            String Query = @"INSERT INTO CashierDetail (CompanyName,ProductName,SellPrice) VALUES ('" + CompanyName + "','" + ProductName + "','"+SellPrice+"');";
            sqlDataAdapter = new SqlDataAdapter();
            try
            {
                sqlcon.Open();
                sqlDataAdapter.InsertCommand = new SqlCommand(Query, sqlcon);
                sqlDataAdapter.InsertCommand.ExecuteNonQuery();
                MessageBox.Show("Data Inserted Sucessfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        public void RemoveCashierRow(String Companyname,String Productname)
        {

            sqlcon = new SqlConnection(ConnectionString);

            sqlDataAdapter = new SqlDataAdapter();
            String Query = @"DELETE CashierDetail WHERE CompanyName = '" + Companyname + "' AND ProductName = '" + Productname + "';";
            try
            {
                sqlcon.Open();
                sqlDataAdapter.DeleteCommand = sqlcon.CreateCommand();
                sqlDataAdapter.DeleteCommand.CommandText = Query;
                sqlDataAdapter.DeleteCommand.ExecuteNonQuery();
                MessageBox.Show("Data Deleted : " + Companyname + "" + Productname + "");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        public void DeleteFullCashierTable()
        {
            sqlcon = new SqlConnection(ConnectionString);

            sqlDataAdapter = new SqlDataAdapter();
            String Query = @"DELETE FROM CashierDetail " ;
            try
            {
                sqlcon.Open();
                sqlDataAdapter.DeleteCommand = sqlcon.CreateCommand();
                sqlDataAdapter.DeleteCommand.CommandText = Query;
                sqlDataAdapter.DeleteCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void SumTotalPrice(TextBox textBox)
        {
            sqlcon = new SqlConnection(ConnectionString);

            String Query = "Select SUM(CAST(SellPrice as int)) FROM CashierDetail ;";

            SqlDataReader sqlDataReader;
            try
            {
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand(Query, sqlcon);
                sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    String temp = sqlDataReader[0].ToString();
                    textBox.Text = temp;

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

    }
}
