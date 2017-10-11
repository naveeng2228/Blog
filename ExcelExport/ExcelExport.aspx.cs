using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Reflection;
using System.IO;
using OfficeOpenXml;
using System.Data.SqlClient;
using System.Configuration;
using ExcelExporter;

namespace ExcelExport
{
    public partial class ExcelExport : System.Web.UI.Page
    {
        DataTable Dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private DataTable GetData()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select top(10) * from IPADMISSION", new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ConnectionString));
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        private void GetRecoredForExcelfile()
        {
            Dt = GetData();
        }

        protected void btn_Excel_Click(object sender, EventArgs e)
        {
            GetRecoredForExcelfile();
            string FilePath = Server.MapPath("ExcelFile/ErrorList.xlsx");
            ExcelReporting report = new ExcelReporting(Dt, FilePath);
            report.Export();
            lblMessage.Text = "Exported on " + report.ExportEndTime.ToString("dd-MM-yyyy hh:mm:ss tt") + " Successfully";
            hfDownloadPath.NavigateUrl = "~/ExcelFile/ErrorList.xlsx";
            downloadpath.Visible = true;
        }
    }
}