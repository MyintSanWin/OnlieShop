using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class User_OrderList : System.Web.UI.Page
{
   // MainDatasetTableAdapters.OrderTableAdapter OrderTbl = new MainDatasetTableAdapters.OrderTableAdapter(); 
    MainDataSetTableAdapters.OrderTableAdapter OrderTbl = new MainDataSetTableAdapters.OrderTableAdapter();
   // MainDatasetTableAdapters.Admin_OrderTableAdapter Admin_Order = new MainDatasetTableAdapters.Admin_OrderTableAdapter();
    MainDataSetTableAdapters.Admin_OrderTableAdapter Admin_Order = new MainDataSetTableAdapters.Admin_OrderTableAdapter();
    MainDataSetTableAdapters.Admin_OrderDetailTableAdapter Admin_OrderDetail = new MainDataSetTableAdapters.Admin_OrderDetailTableAdapter();
    DataTable Dt = new DataTable(); 
    DataTable DtDisplay = new DataTable();
    DataRow Dr;
    int Count;

    protected void DisplayOrder()
    {
        DtDisplay.Columns.Clear();
        DtDisplay.Rows.Clear();
        DtDisplay.Columns.Add("OrderID");
        DtDisplay.Columns.Add("OrderDate");
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
                Dr[0] = Dt.Rows[i][1];
                Dr[1] = Dt.Rows[i][2];
                Dr[2] = Dt.Rows[i][5];
                Dr[3] = Dt.Rows[i][6];
                Dr[4] = Dt.Rows[i][7];
                DtDisplay.Rows.Add(Dr);
            }
    }
        DataList1.DataSource = DtDisplay; 
        DataList1.DataBind();
    } 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LogInCustomer"] == null) 
        {
            Session["URL"] = "OrderList.aspx";
            Response.Redirect("CustomerLogIn.aspx");
        }
        if (Session["NotiStatus"].ToString() == "-") 
        {
            Dt = Admin_Order.Admin_Order_Select_By_CustID(Convert.ToInt32(Session["LogInCustomer"])); 
            DisplayOrder(); 
        }
        else
        {
            Dt = Admin_Order.Admin_Order_Select_By_NotiStatus(Convert.ToInt32(Session["LogInCustomer"]));
            DisplayOrder();
            }
    }
    protected void btnAll_Click(object sender, EventArgs e)
    {
        Session["NotiStatus"] = "-"; 
       // OrderTbl.Order_Cust_NotiStatus_Update(Convert.ToInt32(Session["LogInCustomer"])); 
        OrderTbl.Order_Cust_NotiStatus_Update(Convert.ToInt32(Session["LogInCustomer"]));
        Response.Redirect("OrderList.aspx");
    }
    protected void DataList1_PreRender(object sender, EventArgs e)
    {
        for (int i = 0; i < Count; i++)
        {
            Dr = DtDisplay.Rows[i]; 
            DataListItem Row = DataList1.Items[i];
            GridView GV = (GridView)Row.FindControl("GridView1"); 
            Dt = Admin_OrderDetail.Admin_OrderDetail_Select_By_OrderID(Convert.ToInt32(Dr[0])); 
            GV.DataSource = Dt; 
            GV.DataBind();
        }
    }
   
}