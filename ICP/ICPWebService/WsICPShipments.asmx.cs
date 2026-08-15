using ICPDataAccess;
using ICPGraphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace ICP.IPCWebService
{
    /// <summary>
    /// Summary description for WsICPShipments
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WsICPShipments : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string getShippmentsCurrentMonth()
        {
            //string llego = NextURL;

            DateTime dtCurrent = DateTime.Now;
            DateTime dtStartCurrentMonth = new DateTime(dtCurrent.Year, dtCurrent.Month, 1);


            DateTime dtEndCurrentMonth = dtStartCurrentMonth.AddMonths(1).AddDays(-1);

            string StartDate = dtStartCurrentMonth.ToString("yyyy-MM-dd");
            string EndDate = dtEndCurrentMonth.ToString("yyyy-MM-dd");


            //string EndDate = "2019-12-30";

            GrapICP gra = new GrapICP();
            DaShipments da = new DaShipments();
            Dictionary<string, string> lShippedQtyMT = new Dictionary<string, string>();
            Dictionary<string, string> lDemandQtyMT = new Dictionary<string, string>();
            Dictionary<string, string> lAvg = new Dictionary<string, string>();
            Dictionary<string, string> lGoal = new Dictionary<string, string>();

            da.ShipDetails(StartDate, EndDate, out lShippedQtyMT, out lDemandQtyMT, out lAvg, out lGoal);

            return gra.strGraph_Shipments(lShippedQtyMT, lDemandQtyMT, lAvg, lGoal);
        }
    }
}
