using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
//using System.CrystalDecisions.CrystalReports.Engine;

public partial class Admin_Category : System.Web.UI.Page
{
    MainDataSetTableAdapters.CategoryTableAdapter CategoryTbl = new MainDataSetTableAdapters.CategoryTableAdapter();
    MainDataSetTableAdapters.ItemTableAdapter ItemTbl = new MainDataSetTableAdapters.ItemTableAdapter();
    DataTable Dt = new DataTable();
    DataTable DtDisplay = new DataTable();
    DataRow Dr;
    int Count;
    protected void DisplayCategory()
    {
        DtDisplay.Columns.Clear();
        DtDisplay.Rows.Clear();
        DtDisplay.Columns.Add("No");
        DtDisplay.Columns.Add("CatID");
        DtDisplay.Columns.Add("CatName");
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
                DtDisplay.Rows.Add(Dr);
            }
        }
        GridView1.DataSource = DtDisplay;
        GridView1.DataBind();
        txtSearch.Focus();
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        Dt = CategoryTbl.GetData();
        DisplayCategory();
        MultiView1.ActiveViewIndex = 0;
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        btnSave.Text = "Save";
        txtCategoryName.Text = "";
        txtCategoryName.Focus();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (txtCatID.Text.Trim().ToString() == string.Empty)
        {
            lblError1.Text = "Please Choose One Record For Update";
            MultiView1.ActiveViewIndex = 0;
        }
        else
        {
            lblError1.Text = "";
            MultiView1.ActiveViewIndex = 1;
            txtCategoryName.Focus();
            btnSave.Text = "Update";
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (txtCatID.Text.Trim().ToString() == string.Empty)
        {
            lblError1.Text = "Please Choose One Record For Delete";
            MultiView1.ActiveViewIndex = 0;
        }
        else if (ItemTbl.Item_Select_By_CatID(Convert.ToInt32(txtCatID.Text)).Rows.Count > 0)
        {
            lblError1.Text = "This Category Is Already Use In Item Table";
        }
        else
        {
            CategoryTbl.Category_Delete(Convert.ToInt32(txtCatID.Text));
            Response.Redirect("Category.aspx");
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        if (txtSearch.Text.Trim().ToString() == string.Empty) Dt = CategoryTbl.GetData();
        else
            Dt = CategoryTbl.Category_Select_By_Search_CatName(txtSearch.Text);
        Session["ReportDt"] = Dt;
        Session["ReportName"] = "cryptCategory.rpt";
        Response.Redirect("Report.aspx");
    }
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        Dt = CategoryTbl.Category_Select_By_Search_CatName(txtSearch.Text.Trim().ToString());
        DisplayCategory();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        lblError2.Text = "";
        Dt.Rows.Clear();
        if (txtCategoryName.Text.Trim().ToString() == string.Empty)
        {
            lblError2.Text = "Please Enter Category Name";
            txtCategoryName.Focus();
            MultiView1.ActiveViewIndex = 1;
        }
        else
        {
            Dt = CategoryTbl.Category_Select_By_CatName(txtCategoryName.Text);
            if (Dt.Rows.Count > 0)
            {
                if (Dt.Rows[0][1].ToString() != txtCatID.Text)
                {
                    lblError2.Text = "This Category Is Already Exist";
                    txtCategoryName.Focus();
                    MultiView1.ActiveViewIndex = 1; 
                    return;
                }
            }
            if (btnSave.Text == "Save")
            {
                CategoryTbl.Category_Inset(txtCategoryName.Text);
            }
            else
            {
                CategoryTbl.Category_Update(Convert.ToInt32(txtCatID.Text), txtCategoryName.Text);
            }
            txtCatID.Text = "";
            Response.Redirect("Category.aspx");
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int RowIndex = GridView1.SelectedIndex;
        txtCatID.Text = DtDisplay.Rows[RowIndex][1].ToString();
        txtCategoryName.Text = DtDisplay.Rows[RowIndex][2].ToString();
        GridViewRow Row = GridView1.Rows[RowIndex];
        CheckBox chkSelect = (CheckBox)Row.FindControl("chkSelect");
        chkSelect.Checked = true;
    }
}
