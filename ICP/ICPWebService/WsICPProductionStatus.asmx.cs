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
    /// Summary description for WsICPProductionStatus
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WsICPProductionStatus : System.Web.Services.WebService
    {

        private static string spFPY = "FirstPassYield";
        private static string spJPM = "JobPerformance";
        private static string spEQA = "EquipmentAvailability";
        private static string spTTH = "Thruput";
        private static string spOEE = "OEE";


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string Temper_PCIProducionStatus()
        {

            DaProduction da = new DaProduction();
            Dictionary<string, string> FirstPassYield = new Dictionary<string, string>();
            Dictionary<string, string> JobPerformance = new Dictionary<string, string>();
            Dictionary<string, string> EquipmentAvailability = new Dictionary<string, string>();
            Dictionary<string, string> Thruput = new Dictionary<string, string>();

            da.ICP_ProdStatusDtls(out FirstPassYield, spFPY);
            da.ICP_ProdStatusDtls(out JobPerformance, spJPM);
            da.ICP_ProdStatusDtls(out EquipmentAvailability, spEQA);
            da.ICP_ProdStatusDtls(out Thruput, spTTH);


            GrapICP gra = new GrapICP();
            return gra.strGraph_OEEDtl(FirstPassYield, JobPerformance, EquipmentAvailability, Thruput);
        }
    }
}
