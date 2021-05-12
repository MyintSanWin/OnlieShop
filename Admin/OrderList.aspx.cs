using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_OrderList : System.Web.UI.Page
{
    MainDataSetTableAdapters.Admin_OrderTableAdapter Admin_Order = new MainDataSetTableAdapters.Admin_OrderTableAdapter();
    MainDataSetTableAdapters.Admin_OrderDetailTableAdapter Admin_OrderDetail = new MainDataSetTableAdapters.Admin_OrderDetailTableAdapter();
    MainDataSetTableAdapters.Admin_Order_ReportTableAdapter Admin_OrderReport = new MainDataSetTableAdapters.Admin_Order_ReportTableAdapter();
    DataTable Dt = new DataTable();
    DataTable DtDisplay = new DataTable();
    DataRow Dr;
    int Count;
    protected void DisplayAdminOrder()
    {
        DtDisplay.Rows.Clear();
        DtDisplay.Columns.Clear();

        DtDisplay.Columns.Add("No");
        DtDisplay.Columns.Add("OrderID");
        DtDisplay.Columns.Add("OrderDate");
        DtDisplay.Columns.Add("CustName");
        DtDisplay.Columns.Add("ShippingAdd");
        DtDisplay.Columns.Add("Total");
        DtDisplay.Columns.Add("DeliverStatus");
        Dr = DtDisplay.NewRow();
        DtDisplay.Rows.Add(Dr);
        Count = Dt.Rows.Count;
        if (Count > 0)
        {
            DtDisplay.Rows.Clear();
            for (int i = 0; i < Count; i++)
            {
                Dr = DtDisplay.NewRow();
                Dr[0] = Dt.Rows[i][0];
                Dr[1] = Dt.Rows[i][1];
                Dr[2] = Dt.Rows[i][2];
                Dr[3] = Dt.Rows[i][4];
                Dr[4] = Dt.Rows[i][5];
                Dr[5] = Dt.Rows[i][6];
                Dr[6] = Dt.Rows[i][7];
                DtDisplay.Rows.Add(Dr);
            
            }
        }
        DataList1.DataSource = DtDisplay;
        DataList1.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Dt = Admin_Order.GetData();
        DisplayAdminOrder();
    }
   
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        if (ddlSearchType.SelectedIndex == 0)
        { 
            if (txtOrderDate.Text.Trim().ToString() == string.Empty)
                Dt = Admin_OrderReport.GetData();
            else
            {
                if (txtSearchType.Text.Trim().ToString() == string.Empty) Dt = Admin_OrderReport.GetData();
            }
            if (ddlSearchType.SelectedIndex == 0)
            {
                Dt = Admin_OrderReport.Admin_Order_Report_Select_By_OrderDate(txtOrderDate.Text);
            }
            else if (ddlSearchType.SelectedIndex == 1)
            {
                Dt = Admin_OrderReport.Admin_Order_Report_Select_By_CustomerName(txtSearchType.Text);
            }
            else if (ddlSearchType.SelectedIndex == 2)
            {
                Dt = Admin_OrderReport.Admin_Order_Report_Select_By_ShippingAdd(txtSearchType.Text);
            }
            else if (ddlSearchType.SelectedIndex == 3)
            {
                Dt = Admin_OrderReport.Admin_Order_Report_Select_By_Total(txtSearchType.Text);
            }
            else if (ddlSearchType.SelectedIndex == 4)
            {
                Dt = Admin_OrderReport.Admin_Order_Report_Select_By_DeliverStatus(txtSearchType.Text);
            }
            Session["ReportDt"] = Dt;Session["ReportName"] = "CryptOrderList.rpt";
            Response.Redirect("Report.aspx"); 
        
        }

    }
   
    protected void txtSearchType_TextChanged(object sender, EventArgs e)
    {
        if (ddlSearchType.SelectedIndex == 1)
        {
            Dt = Admin_Order.Admin_Order_Select_By_CustName(txtSearchType.Text);
        }
        else if (ddlSearchType.SelectedIndex == 2) 
        {
            Dt = Admin_Order.Admin_Order_Select_By_ShippingAdd(txtSearchType.Text); 
        }
        else if (ddlSearchType.SelectedIndex == 3)
        {
            Dt = Admin_Order.Admin_Order_Select_By_Total(txtSearchType.Text); 
        } 
        else if (ddlSearchType.SelectedIndex == 4)
        {
            Dt = Admin_Order.Admin_Order_Select_By_DeliverStatus(txtSearchType.Text);
        }
        DisplayAdminOrder();
    }
    
    protected void ddlSearchType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSearchType.SelectedIndex == 0)
        {
            txtOrderDate.Visible = true;
            txtOrderDate.Text = "";
            txtOrderDate.Focus();
            txtSearchType.Visible = false;
           // txtSearchData.Visible = false;
        }
        else
        {
            txtOrderDate.Visible = false;
            txtSearchType.Visible = true;
           // txtSe.Visible = true;
           // txtSearchData.Text = "";
            txtSearchType.Text = "";
            //txtSearchData.Focus();
            txtSearchType.Focus();
        }
    }
    protected void txtOrderDate_TextChanged(object sender, EventArgs e)
    {
        if (ddlSearchType.SelectedIndex == 0) 
        {
            if (txtOrderDate.Text.Trim().ToString() == string.Empty) 
            {
                Dt = Admin_Order.GetData();
            }
            else
            {
                Dt = Admin_Order.Admin_Order_Select_By_OrderDate(txtOrderDate.Text.Trim().ToString()); 
            } 
            DisplayAdminOrder(); 
        }
    }


     protected void DataList1_PreRender(object sender, EventArgs e)
    {
        for (int i = 0; i < Count; i++)
        {
            Dr = DtDisplay.Rows[i];
            DataListItem Row = DataList1.Items[i];
            GridView GV = (GridView)Row.FindControl("GridView1");
            Dt = Admin_OrderDetail.Admin_OrderDetail_Select_By_OrderID(Convert.ToInt32(Dr[1]));
            GV.DataSource = Dt;
            GV.DataBind();
        }
    }
}