using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Item : System.Web.UI.Page
{
    MainDataSetTableAdapters.ItemTableAdapter ItemTlb = new MainDataSetTableAdapters.ItemTableAdapter();

    MainDataSetTableAdapters.CategoryTableAdapter CategoryTlb = new MainDataSetTableAdapters.CategoryTableAdapter();
    DataTable Dt = new DataTable();
    DataTable DtDisplay = new DataTable();
    DataRow Dr;
    int Count;
    protected void DisplayItem()
    {
        DtDisplay.Columns.Clear();
        DtDisplay.Rows.Clear();
        DtDisplay.Columns.Add("No");
        DtDisplay.Columns.Add("ItemID");
        DtDisplay.Columns.Add("ItemName");
        DtDisplay.Columns.Add("CatID");
        DtDisplay.Columns.Add("CatName");
        DtDisplay.Columns.Add("Price");
        DtDisplay.Columns.Add("Quantity");
        DtDisplay.Columns.Add("Image");
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
                Dr[3] = Dt.Rows[i][3];
                Dr[4] = Dt.Rows[i][4];
                Dr[5] = Dt.Rows[i][5];
                Dr[6] = Dt.Rows[i][6];
                Dr[7] = Dt.Rows[i][7];
                DtDisplay.Rows.Add(Dr);
            }
        }
        GridView1.DataSource = DtDisplay;
        GridView1.DataBind();
        txtSearch.Focus();
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        Dt = ItemTlb.GetData();
        DisplayItem();
        MultiView1.ActiveViewIndex = 0;
    }
    protected void DisplayCategory()
    {
        ddlCategoryName.DataTextField = "CatName";
        ddlCategoryName.DataValueField = "CatID";
        ddlCategoryName.DataSource = CategoryTlb.GetData();
        ddlCategoryName.DataBind();
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        btnSave.Text = "Save";
        DisplayCategory();
        MultiView1.ActiveViewIndex = 1;
        ClearData();
        txtItemName.Focus();
    }
    protected void ClearData()
    {
        txtSearch.Text = "";
        txtItemID.Text = "";
        txtItemName.Text = "";
        ddlCategoryName.SelectedIndex = -1;
        txtPrice.Text = "";
        txtImage.Text = "";
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (txtItemID.Text.Trim().ToString() == string.Empty)
        {
            lblError1.Text = "Please Choose One Record For Update";
            MultiView1.ActiveViewIndex = 0;
        }
        else
        {
            lblError1.Text = "";
            DisplayCategory();
            MultiView1.ActiveViewIndex = 1;
            txtItemName.Focus();
            ddlCategoryName.SelectedValue = btnSave.Text;
            btnSave.Text = "Update";
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (txtItemID.Text.Trim().ToString() == string.Empty)
        {
            lblError1.Text = "Please Choose One Record For Delete";
        }
        else if (Convert.ToInt32(txtQuantity.Text.Trim().ToString()) > 0)
        {
            lblError1.Text = "This Item Have In Stock";
        }
        else
        {
            string ImagePath = Server.MapPath(txtImage.Text);
            if (txtImage.Text.Contains("Image1.jpg") == false)
            {
                if (System.IO.File.Exists(ImagePath))
                    System.IO.File.Delete(ImagePath);
            }
            ItemTlb.Item_Delete(Convert.ToInt32(txtItemID.Text));
          
            Response.Redirect("Item.aspx");

        }
    }
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        if (ddlSearchType.SelectedIndex == 0)
        {
            Dt = ItemTlb.Item_Select_By_SearchItemName(txtSearch.Text);
        }
        //  Dt = ItemTbl.Item_Select_By_SearchItemName(txtSearch.Text);
        else if (ddlSearchType.SelectedIndex == 1)
        {
            Dt = ItemTlb.Item_Select_By_SearchCatName(txtSearch.Text);
        }
        // Dt=ItemTlb.Item_Select_By_ItemNameCatName(txtSearch.Text);
        //  Dt = ItemTbl.Item_Select_By_SearchCatName(txtSearch.Text);
        else if (ddlSearchType.SelectedIndex == 2)
        {
            Dt = ItemTlb.Item_Select_By_SearchPrice(txtSearch.Text);
            // Dt = ItemTbl.Item_Select_By_SearchPrice(txtSearch.Text);
        }
        else if (ddlSearchType.SelectedIndex == 3)
        {
            Dt = ItemTlb.Item_Select_By_SearchQuantity(txtSearch.Text);
        }
            // Dt = ItemTbl.Item_Select_By_SearchQuantity(txtSearch.Text);
            DisplayItem();
        
    
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    
        {
 if (txtSearch.Text.Trim().ToString() != string.Empty)
 {
     if (ddlSearchType.SelectedIndex == 0)

         Dt = ItemTlb.Item_Select_By_SearchItemName(txtSearch.Text);
     // Dt = ItemTbl.Item_Select_By_SearchItemName(txtSearch.Text);
     else if (ddlSearchType.SelectedIndex == 1)
         Dt = ItemTlb.Item_Select_By_SearchCatName(txtSearch.Text);
     // Dt = ItemTbl.Item_Select_By_SearchCatName(txtSearch.Text);
     else if (ddlSearchType.SelectedIndex == 2)
         Dt = ItemTlb.Item_Select_By_SearchPrice(txtSearch.Text);
     //Dt = ItemTbl.Item_Select_By_SearchPrice(txtSearch.Text);
     else if (ddlSearchType.SelectedIndex == 3)
         Dt = ItemTlb.Item_Select_By_SearchQuantity(txtSearch.Text);
 //Dt = ItemTbl.Item_Select_By_SearchQuantity(txtSearch.Text);
 }
 else
 {
     Dt = ItemTlb.GetData();
 //Dt = ItemTbl.GetData();
 }
 Session["ReportDt"] = Dt;
 Session["ReportName"] = "crptItem.rpt";
 Response.Redirect("Report.aspx"); 
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int ok;
        if (txtItemName.Text.Trim().ToString() == string.Empty)
        {
            lblError2.Text = "Please Enter the Item Name";
            txtItemName.Focus();
            MultiView1.ActiveViewIndex = 1;
        }
        else if(txtPrice.Text.Trim().ToString()==string.Empty)
        {

            lblError2.Text = "Please Enter Price";
            txtPrice.Focus();
            MultiView1.ActiveViewIndex = 1;
        }
        else if(int.TryParse(txtPrice.Text,out ok)==false)
        {
            lblError2.Text = "Price should be number";
            txtPrice.Focus();
            MultiView1.ActiveViewIndex = 1;
        }
        else if (Convert.ToInt32(txtPrice.Text) < 8000 || Convert.ToInt32(txtPrice.Text) > 500000)
        {
            lblError2.Text = "Price should be between 8000 and 500000";
            txtPrice.Focus();
            MultiView1.ActiveViewIndex = 1;
        }
        else if (txtQuantity.Text.Trim().ToString() == string.Empty)
        {
            lblError2.Text = "Please enter quantity";
            txtQuantity.Focus();
            MultiView1.ActiveViewIndex = 1;
        }
        else if (int.TryParse(txtQuantity.Text, out ok) == false)
        {
            lblError2.Text = "Quantity should be number";
            txtQuantity.Focus();
            MultiView1.ActiveViewIndex = 1;
        }
        else if (Convert.ToInt32(txtQuantity.Text) < 0)
        {
            lblError2.Text = "Quantity should be zero and above";
            txtQuantity.Focus();
            MultiView1.ActiveViewIndex = 1;
        }
        else
        {
            Dt = ItemTlb.Item_Select_By_ItemNameCatName(txtItemName.Text, ddlCategoryName.SelectedItem.ToString());
            if (Dt.Rows.Count > 0)
            {
                if (Dt.Rows[0][1].ToString() != txtItemID.Text)
                {
                    lblError2.Text = "This Item is Already Exist";
                    MultiView1.ActiveViewIndex = 1;
                    return;
                }
            }
            if (btnSave.Text == "Save")
            {
                ItemTlb.Item_Insert(Convert.ToInt32(ddlCategoryName.SelectedValue), txtItemName.Text, Convert.ToInt32(txtPrice.Text.ToString()), Convert.ToInt32(txtQuantity.Text.ToString()));
                int ItemID = Convert.ToInt32(ItemTlb.Item_Select_By_MaxItemID().Rows[0][1]);
                ItemTlb.Item_Insert_Image(ItemID, ImageLocation(ItemID));
            }
            else if(btnSave.Text=="Update")
            {
                int ItemID = Convert.ToInt32(txtItemID.Text);
                string ImagePath = ImageLocation(ItemID);
                ItemTlb.Item_Update(Convert.ToInt32(txtItemID.Text), Convert.ToInt32(ddlCategoryName.SelectedValue), txtItemName.Text, Convert.ToInt32(txtPrice.Text), Convert.ToInt32(txtQuantity.Text), ImagePath.ToString());
                Response.Redirect("Item.aspx", true);
            }
            ClearData();
            Dt = ItemTlb.GetData();
            DisplayItem();
            MultiView1.ActiveViewIndex = 0;
        }
    }
    private string ImageLocation(int ItemID)
    {
        string filename = FileUploadImage.FileName;
        string FilePath = Server.MapPath("~/image/") + ItemID + ".jpg";
        if (System.IO.File.Exists(FilePath)) System.IO.File.Delete(FilePath);
        if (filename != string.Empty)
        {
            FileUploadImage.SaveAs(FilePath);
            return "~/image/" + ItemID + ".jpg";
        }
        else
        {
            return "~/image/c10.jpg";
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int RowIndex = GridView1.SelectedIndex;
       // DtDisplay = (DataTable)Session["SesstionDtDisplay"];
       
        txtItemID.Text = DtDisplay.Rows[RowIndex][1].ToString();
        txtItemName.Text = DtDisplay.Rows[RowIndex][2].ToString();
        btnSave.Text = DtDisplay.Rows[RowIndex][3].ToString();
        txtPrice.Text = DtDisplay.Rows[RowIndex][5].ToString();
        txtQuantity.Text = DtDisplay.Rows[RowIndex][6].ToString();
        txtImage.Text = DtDisplay.Rows[RowIndex][7].ToString();
        GridViewRow Row2 = GridView1.Rows[RowIndex];
        CheckBox chkSelect2 = (CheckBox)Row2.FindControl("chkSelect");
        chkSelect2.Checked = true;
       // DisplayItem();
    }
  
}
