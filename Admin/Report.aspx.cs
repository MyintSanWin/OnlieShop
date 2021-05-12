using System;

using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using CrystalDecisions.CrystalReports.Engine;




public partial class Admin_Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ReportDt"] != null && Session["ReportName"] != null)
        {
            ReportDocument report = new ReportDocument();
            report.Load(Server.MapPath(Session["ReportName"].ToString()));
            report.SetDataSource((DataTable)Session["ReportDt"]);

         //   CrystalReportViewer1.ReportSource = report;
           // CrystalReportViewer1.DataBind();
            CrystalReportViewer1.ReportSource = report;
            CrystalReportViewer1.DataBind();
            
        }
       // MultiView1.ActiveViewIndex = 0;
    }
}