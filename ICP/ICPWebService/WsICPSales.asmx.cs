using ICPDataAccess;
using ICPDataModel;
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
    /// Summary description for WsICPSales
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WsICPSales : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]

        public string PCILoadByResourceGRP()
        {
            GrapICP gra = new GrapICP();
            DaSales da = new DaSales();

            List<LoadByResourceGRP> lst = da.LoadByResourceGRP();
            string s = gra.strGraph_LoadByResourceGrp(lst).ToString();
            return gra.strGraph_LoadByResourceGrp(lst);
        }
    }
}
