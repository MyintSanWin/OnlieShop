using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class User_ItemDetail : System.Web.UI.Page
{
    MainDataSetTableAdapters.ItemTableAdapter ItemductTbl = new MainDataSetTableAdapters.ItemTableAdapter();
    DataTable Dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        Dt = ItemductTbl.Item_Select_By_ItemID(Convert.ToInt32(Session["ItemID"]));
            if(Dt.Rows.Count>0)
            {
                foreach(DataRow Dr in Dt.Rows)
                {
                    imgItem.ImageUrl=Dr["Image"].ToString();
                    lblCategoryName.Text=Dr["CatName"].ToString();
                    lblPrice.Text=Dr["Price"].ToString();
                    lblItemName.Text=Dr["ItemName"].ToString();
                }
            }
    }
    protected void btnContinue_Click(object sender, EventArgs e)
    {
        Response.Redirect("Item.aspx");
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        DataTable Tbl = new DataTable();
        DataRow TblDr;
        Tbl.Columns.Add("ItemID");
        Tbl.Columns.Add("Qty");
        Tbl.Rows.Clear();
        if (Session["TempTbl"] != null)
        {
            Tbl = (DataTable)Session["TempTbl"];
            DataRow[] DrArray = Tbl.Select("ItemID='" + Session["ItemID"] + "'");
            foreach (DataRow Dr in DrArray)
            {
                Dr[1] = Convert.ToInt32(Dr[1]) + 1;
                Tbl.AcceptChanges();
                Session["TempTbl"] = Tbl;
                Response.Redirect("ShoppingCard.aspx");
                return;
            }
        }
        TblDr = Tbl.NewRow();
        TblDr[0] = Session["ItemID"];
        TblDr[1] = 1;
        Tbl.Rows.Add(TblDr);
        Session["TempTbl"] = Tbl;
        Response.Redirect("ShoppingCard.aspx");
    }
}