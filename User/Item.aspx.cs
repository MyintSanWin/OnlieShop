using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class User_Item : System.Web.UI.Page
{
    MainDataSetTableAdapters.CategoryTableAdapter CategoryTbl = new MainDataSetTableAdapters.CategoryTableAdapter();
    MainDataSetTableAdapters.ItemTableAdapter ItemTbl = new MainDataSetTableAdapters.ItemTableAdapter();
    DataTable Dt = new DataTable();
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (txtLoad.Text.ToString() == string.Empty)
        {
            Dt = CategoryTbl.Category_Select_By_Item();
            CatNameList.DataSource = Dt;
            CatNameList.DataBind();
            if (Dt.Rows.Count > 0)
            {
                ItemList.DataSource = ItemTbl.Item_Select_By_CatID(Convert.ToInt32(Dt.Rows[0][1].ToString()));
                ItemList.DataBind();
            }
            txtLoad.Text = "Load";
        }
    }
    protected void CatNameList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ItemList.DataSource = ItemTbl.Item_Select_By_CatID(Convert.ToInt32(CatNameList.SelectedValue.ToString()));
        ItemList.DataBind();
    }
    protected void ItemList_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["ItemID"] = ItemList.SelectedValue.ToString();
        Response.Redirect("ItemDetail.aspx");
    }
}