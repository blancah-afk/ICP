using ICPDataModel;
using ICPDataAccess;
using System;
using System.Data;
using System.Text;
using System.Web.Script.Services;
using System.Web.Services;

namespace ICP.IPCWebService
{
    /// <summary>
    /// Summary description for WsICPTruckTracker
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WsICPTruckTracker : System.Web.Services.WebService
    {


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string getTruckTracker()
        {
            DataSet ds = new DataSet();
            DateTime dt = DateTime.Now;
            DateTime wkStDt = DateTime.MinValue;
            double DayOfWeek = (Convert.ToDouble(dt.DayOfWeek));
            wkStDt = dt.AddDays(1 - Convert.ToDouble(dt.DayOfWeek));
            DateTime FechaInicioDeSemana = wkStDt.Date;
            DateTime FechaFinDeSemana = FechaInicioDeSemana.AddDays(6);

            DaShipments da = new DaShipments();
            TruckTracker truck = new TruckTracker();
            truck.StartDate = FechaInicioDeSemana;
            truck.EndDate = FechaFinDeSemana;
            truck.PackNum = "";
            truck.TruckID = "";
            truck.FreightInvoice = "";




            ds = da.ds_TruckTracker("sp_PCITruckTracker", truck);

            bool hasMoreRecords = false;

            var sb = new StringBuilder();
            sb.Append(@"{" + "\"sEcho\": 1,");
            sb.Append("\"recordsTotal\": " + ds.Tables[0].Rows.Count + ",");
            sb.Append("\"recordsFiltered\": " + ds.Tables[0].Rows.Count + ",");
            sb.Append("\"iTotalRecords\": " + ds.Tables[0].Rows.Count + ",");
            sb.Append("\"iTotalDisplayRecords\": 10,");
            sb.Append("\"aaData\": [");

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (hasMoreRecords)
                {
                    sb.Append(",");
                }
                sb.Append("[");
                sb.Append("\"" + dr[0].ToString() + "\",");
                sb.Append("\"" + dr[1].ToString() + "\",");
                sb.Append("\"" + dr[2].ToString() + "\",");
                sb.Append("\"" + dr[3].ToString() + "\",");
                sb.Append("\"" + dr[4].ToString() + "\",");
                sb.Append("\"" + dr[5].ToString() + "\",");
                sb.Append("\"" + dr[6].ToString() + "\",");
                sb.Append("\"" + dr[10].ToString() + "\",");
                sb.Append("\"" + dr[7].ToString() + "\",");
                sb.Append("\"" + dr[8].ToString() + "\",");
                sb.Append("\"" + dr[9].ToString() + "\",");

                sb.Append("\"" + dr[11].ToString() + "\",");
                sb.Append("\"" + dr[12].ToString() + "\",");
                sb.Append("\"" + dr[13].ToString() + "\",");
                sb.Append("\"" + dr[14].ToString() + "\",");
                sb.Append("\"" + dr[15].ToString() + "\"");


                sb.Append("]");
                hasMoreRecords = true;
            }
            sb.Append("]}");



            return sb.ToString();
        }
    }
}
