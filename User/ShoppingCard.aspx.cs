using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class User_ShoppingCard : System.Web.UI.Page
{

    MainDataSetTableAdapters.ItemTableAdapter ItemTbl = new MainDataSetTableAdapters.ItemTableAdapter();
    DataTable Dt1 = new DataTable();
    DataTable Dt2 = new DataTable();
    DataTable DtDisplay = new DataTable();
    DataRow Dr;
    int Count;

    protected void Page_Load(object sender, EventArgs e)
    {
        Dt1 = (DataTable)Session["TempTbl"];
        if (txtLoad.Text.Trim().ToString() == string.Empty)
        {
            if (Session["TempTbl"] == null)
            {
                Response.Redirect("Item.aspx");
            }
            else
            {
                if (Dt1.Rows.Count <= 0)
                    Response.Redirect("Item.aspx");
                else
                    SelectTempTbl();
            }
            txtLoad.Text = "Load";
        }
    }
    protected void SelectTempTbl()
    {

        DtDisplay.Columns.Clear();
        DtDisplay.Rows.Clear();
        DtDisplay.Columns.Add("No");
        DtDisplay.Columns.Add("ItemID");
        DtDisplay.Columns.Add("ItemName");
        DtDisplay.Columns.Add("CatName");
        DtDisplay.Columns.Add("Price");
        DtDisplay.Columns.Add("Qty");
        Count = Dt1.Rows.Count;
        for (int i = 0; i < Count; i++)
        {
            int ItemID = Convert.ToInt32(Dt1.Rows[i][0].ToString());
            Dt2 = ItemTbl.Item_Select_By_ItemID(ItemID);
            Dr = DtDisplay.NewRow();
            Dr[0] = Dt2.Rows[0][0];
            Dr[1] = Dt2.Rows[0][1];
            Dr[2] = Dt2.Rows[0][2];
            Dr[3] = Dt2.Rows[0][4];
            Dr[4] = Dt2.Rows[0][5];
            Dr[5] = Dt1.Rows[i][1];
            DtDisplay.Rows.Add(Dr);
            GridView1.DataSource = DtDisplay;
            GridView1.DataBind();

        }
    }
   
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnContinue_Click1(object sender, EventArgs e)
    {
        Response.Redirect("Item.aspx");
    }
    protected void btnCheckOut_Click1(object sender, EventArgs e)
    {
        int NewQty, ItemID;
        int Index = 0;
        foreach (GridViewRow Row in GridView1.Rows)
        {
            TextBox txtNewQty = (TextBox)Row.FindControl("txtNewQty");
            NewQty = Convert.ToInt32(txtNewQty.Text);
            ItemID = Convert.ToInt32(Dt1.Rows[Index][0].ToString());
            DataRow[] DrArray = Dt1.Select("ItemID='" + ItemID + "'");
            if (NewQty > 0)
            {
                foreach (DataRow Dr in DrArray)

                    Dr[1] = NewQty;
                Index = Index + 1;
            }
            else
            {
                foreach (DataRow Dr in DrArray)
                {
                    Dr.Delete();
                }
            }
            Dt1.AcceptChanges();
        }
        Session["TempTbl"] = Dt1;
        if (Dt1.Rows.Count != 0)
        {
            if (Session["LogInCustome"] == null)
            {
                Session["URl"] = "CheckOut.aspx";
                Response.Redirect("CustomerLogin.aspx");
            }
            else
            {
                Response.Redirect("CheckOut.aspx");
            }
        }
        else
        {
            Response.Redirect("Item.aspx");
        }
    }
    protected void btnCancleShopping_Click(object sender, EventArgs e)
    {
        DataTable Dt = (DataTable)Session["TempTbl"];
        Dt.Rows.Clear();
        Response.Redirect("Item.aspx");
    }
}

