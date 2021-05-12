using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class User_NewCustomer : System.Web.UI.Page
{
    MainDataSetTableAdapters.CustomerTableAdapter CustomerTbl = new MainDataSetTableAdapters.CustomerTableAdapter();
   // MainDataSetTableAdapters.CustomerTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ClearData()
    {
        txtAddress.Text = "";
        txtCustomerName.Text = "";
        txtEmail.Text = "";
        txtPassword.Text = "";
        txtComfirmPassword.Text = "";
        txtPhone.Text = "";
        txtAcc.Text = "";
        ddlCType.SelectedIndex = 0;
        txtCustomerName.Focus();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtCustomerName.Text.Trim().ToString() == string.Empty)
        {
            lblError.Text = "Please enter Customer Name";
            txtCustomerName.Focus();
        }
        else if (txtAddress.Text.Trim().ToString() == string.Empty)
        {
            lblError.Text = "Please Enter Your Address";
            txtAddress.Focus();
        }
        else if (txtPhone.Text.Trim().ToString() == string.Empty)
        {
            lblError.Text = "Please Enter Your Phone Number";
            txtPhone.Focus();
        }
        else if (txtEmail.Text.Trim().ToString() == string.Empty)
        {
            lblError.Text = "Please Enter Email";
            txtEmail.Focus();
        }
        else if (txtEmail.Text.Contains(".") == false || txtEmail.Text.Contains("@") == false)
        {
            lblError.Text = "Please Type Correct Email Format";
            txtEmail.Focus();
        }
        else if (txtPassword.Text.Trim().ToString() == string.Empty)
        {
            lblError.Text = "Please Enter Password";
            txtPassword.Focus();
        }
        else if (txtComfirmPassword.Text.Trim().ToString() == string.Empty)
        {
            lblError.Text = "Please Enter ComfirmPassword";
            txtComfirmPassword.Focus();
        }
        else if (txtPassword.Text != txtComfirmPassword.Text)
        {
            lblError.Text = "Password And ComfirmPassword Shouold Be Match";
            txtPassword.Focus();
        }
        else if (txtAcc.Text.Trim().ToString() == string.Empty)
        {
            lblError.Text = "Please Enter Account No";
            txtAcc.Focus();
        }
        else if (CustomerTbl.Customer_Select_By_EMail(txtEmail.Text).Rows.Count > 0)
        {
            lblError.Text = "This Customer Email is already exist";
            txtEmail.Focus();
        }
        else
        {
            CustomerTbl.Customer_Insert(txtCustomerName.Text, txtAddress.Text,txtPhone.Text,txtEmail.Text, txtPassword.Text,ddlCType.SelectedItem.ToString(),txtAcc.Text);

            lblError.Text = "Save Successfully one record";
            ClearData();
        }
    }
}