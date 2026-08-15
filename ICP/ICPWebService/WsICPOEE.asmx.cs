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
    /// Summary description for WsICPOEE
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WsICPOEE : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string getGraph_OEE()
        {
            GrapICP graph = new GrapICP();
            Dictionary<string, string> lstSerie1OEE = new Dictionary<string, string>();
            Dictionary<string, string> lstSerie2PT = new Dictionary<string, string>();
            DaProduction da = new DaProduction();

            da.ICP_OEEData(out lstSerie1OEE, out lstSerie2PT, "OEE");
            return graph.strGraph_OEE(lstSerie1OEE, lstSerie2PT);
        }
    }
}
