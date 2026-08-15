using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using ICPDataAccess;
using System.Text;

namespace ICP.ICPWebService
{
    /// <summary>
    /// Summary description for WsReportBO
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WsReportBO : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string getSalesLotDetails(int FiscalYear, int FiscalPeriod)
        {
            DataSet ds = new DataSet();
         
 
            DaReports da = new DaReports();

            ds = da.dsSalesLotDetails(FiscalYear, FiscalPeriod);

            bool hasMoreRecords = false;

            var sb = new StringBuilder();
            sb.Append(@"{" + "\"sEcho\": 0,");
            sb.Append("\"recordsTotal\": " + ds.Tables[0].Rows.Count + ",");
            sb.Append("\"recordsFiltered\": " + ds.Tables[0].Rows.Count + ",");
            sb.Append("\"iTotalRecords\": " + ds.Tables[0].Rows.Count + ",");
            sb.Append("\"iTotalDisplayRecords\": 10,");
            sb.Append("\"aaData\": [");

        
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string CustPart = dr[3].ToString();
                CustPart = CustPart.Replace("\"", "\\\"");
                if (hasMoreRecords)
                {
                    sb.Append(",");
                }
                sb.Append("[");

                sb.Append("\"" + dr[0].ToString().Replace("\"", "\\\"") + "\",");
                sb.Append("\"" + dr[1].ToString().Replace("\"", "\\\"") + "\",");
                sb.Append("\"" + dr[2].ToString().Replace("\"", "\\\"") + "\",");
                sb.Append("\"" + CustPart + "\",");
                sb.Append("\"" + dr[4].ToString().Replace("\"", "\\\"") + "\",");
                sb.Append("\"" + dr[5].ToString().Replace("\"", "\\\"") + "\",");
                sb.Append("\"" + dr[6].ToString().Replace("\"", "\\\"") + "\",");
                sb.Append("\"" + dr[7].ToString().Replace("\"", "\\\"") + "\",");
                sb.Append("\"" + dr[8].ToString().Replace("\"", "\\\"") + "\",");
                sb.Append("\"" + dr[9].ToString().Replace("\"", "\\\"") + "\",");
                sb.Append("\"" + dr[10].ToString().Replace("\"", "\\\"") + "\",");
                sb.Append("\"" + dr[11].ToString().Replace("\"", "\\\"") + "\",");
                sb.Append("\"" + dr[12].ToString().Replace("\"", "\\\"") + "\",");
                sb.Append("\"" + dr[13].ToString().Replace("\"", "\\\"") + "\",");
                sb.Append("\"" + dr[14].ToString().Replace("\"", "\\\"") + "\",");
                sb.Append("\"" + dr[15].ToString().Replace("\"", "\\\"") + "\",");
                sb.Append("\"" + dr[16].ToString().Replace("\"", "\\\"") + "\",");
                sb.Append("\"" + dr[17].ToString().Replace("\"", "\\\"") + "\",");
                sb.Append("\"" + dr[18].ToString().Replace("\"", "\\\"") + "\",");
                sb.Append("\"" + dr[19].ToString().Replace("\"", "\\\"") + "\",");
                sb.Append("\"" + dr[20].ToString().Replace("\"", "\\\"") + "\",");
                sb.Append("\"" + dr[21].ToString().Replace("\"", "\\\"") + "\",");
                sb.Append("\"" + dr[22].ToString().Replace("\"", "\\\"") + "\",");
                sb.Append("\"" + dr[23].ToString().Replace("\"", "\\\"") + "\",");
                sb.Append("\"" + dr[24].ToString().Replace("\"", "\\\"") + "\",");
                sb.Append("\"" + dr[25].ToString().Replace("\"", "\\\"") + "\"");


 
                sb.Append("]");
                hasMoreRecords = true;
            }
            sb.Append("]}");

            string syt = sb.ToString();

            return sb.ToString();
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string getSalesProfitDashboardMaterial(DateTime StartDate, DateTime EndDate)
        {
            DataSet ds = new DataSet();


            DaReports da = new DaReports();

            ds = da.dsSalesProfitDashboardMaterial(StartDate, EndDate);

            bool hasMoreRecords = false;

            var sb = new StringBuilder();
            sb.Append(@"{" + "\"sEcho\": 0,");
            sb.Append("\"recordsTotal\": " + ds.Tables[0].Rows.Count + ",");
            sb.Append("\"recordsFiltered\": " + ds.Tables[0].Rows.Count + ",");
            sb.Append("\"iTotalRecords\": " + ds.Tables[0].Rows.Count + ",");
            sb.Append("\"iTotalDisplayRecords\": 10,");
            sb.Append("\"aaData\": [");


            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string CustPart = dr[3].ToString();
                CustPart = CustPart.Replace("\"", "\\\"");
                if (hasMoreRecords)
                {
                    sb.Append(",");
                }
                sb.Append("[");

                int iColumns = ds.Tables[0].Columns.Count-1;

                for (int i = 0; i <= iColumns; i++)
                {

                    if (i == iColumns)
                    {
                        sb.Append("\"" + dr[i].ToString().Replace("\"", "\\\"") + "\"");
                    }
                    else
                    {
                        sb.Append("\"" + dr[i].ToString().Replace("\"", "\\\"") + "\",");
                    }
                }

                sb.Append("]");
                hasMoreRecords = true;
            }
            sb.Append("]}");

            string syt = sb.ToString();

            return sb.ToString();
        }

       
    }
}
