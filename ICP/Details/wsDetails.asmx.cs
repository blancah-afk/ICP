using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using SWMXKPIdll.Detalle;
using SWMXKPIdll;
using Dynamitey;

namespace KPIDashboardV2.Details
{
    /// <summary>
    /// Summary description for wsDetails
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    [System.Web.Script.Services.ScriptService] // ¡Necesario!
    public class wsDetails : System.Web.Services.WebService
    {

        /// <summary>
        ///  KPI 01 - Customer GM
        /// </summary>
        /// <returns></returns>
        #region "WebMethods"
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getCustomerGM_Head(string Year, string Month)
        {
            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(12, true, 0));

            List<dynamic> lres = new List<dynamic>();
            CustomerGM dd = new CustomerGM(lista);
            lres = dd.getHeader(int.Parse(Year), int.Parse(Month));
            return GetStuff(lista, lres);
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getCustomerGM_Detail0(string Year, string Month)
        {
            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(12, false, 0));

            List<dynamic> lres = new List<dynamic>();
            CustomerGM dd = new CustomerGM(lista);

            lres = dd.getDetail0(int.Parse(Year), int.Parse(Month));
            return GetStuff(lista, lres);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getCustomerGM_Detail1(string Year, string Month)
        {
            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(12, false, 1));

            List<dynamic> lres = new List<dynamic>();
            CustomerGM dd = new CustomerGM(lista);
            lres = dd.getDetail1(int.Parse(Year), int.Parse(Month));
            return GetStuff(lista, lres);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getCustomerGM_Detail2(string Year, string Month)
        {
            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(12, false, 2));

            List<dynamic> lres = new List<dynamic>();
            CustomerGM dd = new CustomerGM(lista);
            lres = dd.getDetail2(int.Parse(Year), int.Parse(Month));
            return GetStuff(lista, lres);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getCustomerGM_Detail3(string Year, string Month)
        {
            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(12, false, 3));

            List<dynamic> lres = new List<dynamic>();
            CustomerGM dd = new CustomerGM(lista);
            lres = dd.getDetail3(int.Parse(Year), int.Parse(Month));
            return GetStuff(lista, lres);
        }

        /// <summary>
        /// KPI 02 - Gross Margin (GM)
        /// </summary>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getGM_Head(string Year, string Month)
        {
            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(2, true, 0));

            List<dynamic> lres = new List<dynamic>();
            GM dd = new GM(lista);
            lres = dd.getHeader(int.Parse(Year), int.Parse(Month));
            return GetStuff(lista, lres);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getGM_Detail0(string Year, string Month)
        {
            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(2, false, 0));

            List<dynamic> lres = new List<dynamic>();
            GM dd = new GM(lista);
            lres = dd.getDetail0(int.Parse(Year), int.Parse(Month));
            return GetStuff(lista, lres);
        }

        /// <summary>
        /// KPI 03 - Forecast Compleanse
        /// </summary>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getForeComp_Head(string Year, string Month)
        {
            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(13, true, 0));

            List<dynamic> lres = new List<dynamic>();
            ForeComp dd = new ForeComp(lista);
            lres = dd.getHeader(int.Parse(Year), int.Parse(Month));
            return GetStuff(lista, lres);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getForeComp_Detail0(string Year, string Month)
        {
            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(13, false, 0));

            List<dynamic> lres = new List<dynamic>();
            ForeComp dd = new ForeComp(lista);
            lres = dd.getDetail0(int.Parse(Year), int.Parse(Month));
            return GetStuff(lista, lres);
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getDeliveryEv_Head(string Year, string Month)
        {
            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(4, true, 0));

            List<dynamic> lres = new List<dynamic>();
            DeliveryEv dd = new DeliveryEv(lista);
            lres = dd.getHeader(int.Parse(Year), int.Parse(Month));
            return GetStuff(lista, lres);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getDeliveryEv_Detail0(string Year, string Month)
        {
            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(4, false, 0));

            List<dynamic> lres = new List<dynamic>();
            DeliveryEv dd = new DeliveryEv(lista);
            lres = dd.getDetail0(int.Parse(Year), int.Parse(Month));
            return GetStuff(lista, lres);
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getOrganicGrow_Head(string Year, string Month)
        {
            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(14, true, 0));

            List<dynamic> lres = new List<dynamic>();
            OrganicGrow dd = new OrganicGrow(lista);
            lres = dd.getHeader(int.Parse(Year), int.Parse(Month));
            return GetStuff(lista, lres);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getOrganicGrow_Detail0(string Year, string Month)
        {
            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(14, false, 0));

            List<dynamic> lres = new List<dynamic>();

            OrganicGrow dd = new OrganicGrow(lista);
            lres = dd.getDetail0(int.Parse(Year), int.Parse(Month));
            return GetStuff(lista, lres);
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getOurAVGPirce_Head(string Year, string Month)
        {
            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(15, true, 0));

            List<dynamic> lres = new List<dynamic>();
            Generic dd = new Generic(lista);
            lres = dd.getData(15, int.Parse(Year), int.Parse(Month), "SPKPIds_OurAVGPirce_dHead", "Repo", true);
            return GetStuff(lista, lres);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getOurAVGPirce_Detail0(string Year, string Month)
        {
            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(15, false, 0));

            List<dynamic> lres = new List<dynamic>();
            Generic dd = new Generic(lista);
            lres = dd.getData(15, int.Parse(Year), int.Parse(Month), "SPKPIds_OurAVGPirce_dHead", "Repo", false, 0, 1);
            return GetStuff(lista, lres);
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getSupplierPPM_Head(string Year, string Month)
        {
            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(1, true, 0));

            List<dynamic> lres = new List<dynamic>();
            Generic dd = new Generic(lista);
            lres = dd.getData(1, int.Parse(Year), int.Parse(Month), "SPKPIds_SupplierPPM_dHead", "Epicor", true);
            return GetStuff(lista, lres);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getSupplierPPM_Detail0(string Year, string Month)
        {
            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(1, false, 0));

            List<dynamic> lres = new List<dynamic>();
            Generic dd = new Generic(lista);
            lres = dd.getData(1, int.Parse(Year), int.Parse(Month), "SPKPIds_SupplierPPM_dHead", "Epicor", false, 0, 1);
            return GetStuff(lista, lres);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getSupplierPPM_Detail1(string Year, string Month)
        {
            int Id = 1;
            int IndexRep = 1;
            int IndexDB = 2;

            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(Id, false, IndexRep));

            List<dynamic> lres = new List<dynamic>();
            Generic dd = new Generic(lista);
            lres = dd.getData(Id, int.Parse(Year), int.Parse(Month), "SPKPIds_SupplierPPM_dHead", "Epicor", false, IndexRep, IndexDB);
            return GetStuff(lista, lres);
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getInvtLevel_Head(string Year, string Month)
        {
            int Id = 11;
            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(Id, true, 0));

            List<dynamic> lres = new List<dynamic>();
            Generic dd = new Generic(lista);
            lres = dd.getData(Id, int.Parse(Year), int.Parse(Month), "SPKPIds_InventoryLevel_dHead", "Repo", true);
            return GetStuff(lista, lres);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getInvtLevel_Detail0(string Year, string Month)
        {
            int Id = 11;
            int IndexRep = 0;
            int IndexDB = 0;

            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(Id, false, IndexRep));

            List<dynamic> lres = new List<dynamic>();
            Generic dd = new Generic(lista);
            lres = dd.getData(Id, int.Parse(Year), int.Parse(Month), "SPKPIds_InventoryLevelBin_dDetail", "Repo", false, IndexRep, IndexDB);
            return GetStuff(lista, lres);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getInvtLevel_Detail1(string Year, string Month)
        {
            int Id = 11;
            int IndexRep = 1;
            int IndexDB = 0;

            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(Id, false, IndexRep));

            List<dynamic> lres = new List<dynamic>();
            Generic dd = new Generic(lista);
            lres = dd.getData(Id, int.Parse(Year), int.Parse(Month), "SPKPIds_InventoryLevel_dDetail", "Repo", false, IndexRep, IndexDB);
            return GetStuff(lista, lres);
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getProdSchComp_Head(string Year, string Month)
        {
            int Id = 8;
            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(Id, true, 0));

            List<dynamic> lres = new List<dynamic>();
            Generic dd = new Generic(lista);
            lres = dd.getData(Id, int.Parse(Year), int.Parse(Month), "SPKPIds_ProdSchComp_dHead", "Repo", true);
            return GetStuff(lista, lres);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getProdSchComp_Detail0(string Year, string Month)
        {
            int Id = 8;
            int IndexRep = 0;
            int IndexDB = 1;

            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(Id, false, IndexRep));

            List<dynamic> lres = new List<dynamic>();
            Generic dd = new Generic(lista);
            lres = dd.getData(Id, int.Parse(Year), int.Parse(Month), "SPKPIds_ProdSchComp_dHead", "Repo", false, IndexRep, IndexDB);
            return GetStuff(lista, lres);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getCostOfWood_Head(string Year, string Month)
        {
            int Id = 3;
            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(Id, true, 0));

            List<dynamic> lres = new List<dynamic>();
            Generic dd = new Generic(lista);
            lres = dd.getData(Id, int.Parse(Year), int.Parse(Month), "SPKPIds_CostOfWood_dHead", "Repo", true);
            return GetStuff(lista, lres);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getCostOfWood_Detail0(string Year, string Month)
        {
            int Id = 3;
            int IndexRep = 0;
            int IndexDB = 0;

            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(Id, false, IndexRep));

            List<dynamic> lres = new List<dynamic>();
            Generic dd = new Generic(lista);
            lres = dd.getData(Id, int.Parse(Year), int.Parse(Month), "SPKPIds_CostOfWood_dDetail", "Repo", false, IndexRep, IndexDB);
            return GetStuff(lista, lres);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getCostOfWood_Detail1(string Year, string Month)
        {
            int Id = 3;
            int IndexRep = 1;
            int IndexDB = 1;

            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(Id, false, IndexRep));

            List<dynamic> lres = new List<dynamic>();
            Generic dd = new Generic(lista);
            lres = dd.getData(Id, int.Parse(Year), int.Parse(Month), "SPKPIds_CostOfWood_dDetail", "Repo", false, IndexRep, IndexDB);
            return GetStuff(lista, lres);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="Month"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getExtCOPQ_Head(string Year, string Month)
        {
            int Id = 6;
            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(Id, true, 0));

            List<dynamic> lres = new List<dynamic>();
            Generic dd = new Generic(lista);
            lres = dd.getData(Id, int.Parse(Year), int.Parse(Month), "SPKPIds_ExtCOPQ_dHead", "Epicor", true);
            return GetStuff(lista, lres);
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getExtCOPQ_Detail0(string Year, string Month)
        {
            int Id = 6;
            int IndexRep = 0;
            int IndexDB = 0;

            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(Id, false, IndexRep));

            List<dynamic> lres = new List<dynamic>();
            Generic dd = new Generic(lista);
            lres = dd.getData(Id, int.Parse(Year), int.Parse(Month), "SPKPIds_ExtCOPQ_dDetail", "Epicor", false, IndexRep, IndexDB);
            return GetStuff(lista, lres);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getExtCOPQ_Detail1(string Year, string Month)
        {
            int Id = 6;
            int IndexRep = 1;
            int IndexDB = 1;

            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(Id, false, IndexRep));

            List<dynamic> lres = new List<dynamic>();
            Generic dd = new Generic(lista);
            lres = dd.getData(Id, int.Parse(Year), int.Parse(Month), "SPKPIds_ExtCOPQ_dDetail", "Epicor", false, IndexRep, IndexDB);
            return GetStuff(lista, lres);
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getDMRStat_Head(string Year, string Month)
        {
            int Id = 10;
            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(Id, true, 0));

            List<dynamic> lres = new List<dynamic>();
            Generic dd = new Generic(lista);
            lres = dd.getData(Id, int.Parse(Year), int.Parse(Month), "SPKPIds_DMRStat_dHead", "Epicor", true);
            return GetStuff(lista, lres);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getDMRStat_Detail0(string Year, string Month)
        {
            int Id = 10;
            int IndexRep = 0;
            int IndexDB = 1;

            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(Id, false, IndexRep));

            List<dynamic> lres = new List<dynamic>();
            Generic dd = new Generic(lista);
            lres = dd.getData(Id, int.Parse(Year), int.Parse(Month), "SPKPIds_DMRStat_dHead", "Epicor", false, IndexRep, IndexDB);
            return GetStuff(lista, lres);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getEffectCla_Head(string Year, string Month)
        {
            int Id = 9;
            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(Id, true, 0));

            List<dynamic> lres = new List<dynamic>();
            Generic dd = new Generic(lista);
            lres = dd.getData(Id, int.Parse(Year), int.Parse(Month), "SPKPIds_EffectCla_dHead", "Epicor", true);
            return GetStuff(lista, lres);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getEffectCla_Detail0(string Year, string Month)
        {
            int Id = 9;
            int IndexRep = 0;
            int IndexDB = 1;

            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(Id, false, IndexRep));

            List<dynamic> lres = new List<dynamic>();
            Generic dd = new Generic(lista);
            lres = dd.getData(Id, int.Parse(Year), int.Parse(Month), "SPKPIds_EffectCla_dHead", "Epicor", false, IndexRep, IndexDB);
            return GetStuff(lista, lres);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getEffectRM_Head(string Year, string Month)
        {
            int Id = 5;
            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(Id, true, 0));

            List<dynamic> lres = new List<dynamic>();
            Generic dd = new Generic(lista);
            lres = dd.getData(Id, int.Parse(Year), int.Parse(Month), "SPKPIds_EffectRM_dHead", "Epicor", true);
            return GetStuff(lista, lres);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getEffectRM_Detail0(string Year, string Month)
        {
            int Id = 5;
            int IndexRep = 0;
            int IndexDB = 1;

            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(Id, false, IndexRep));

            List<dynamic> lres = new List<dynamic>();
            Generic dd = new Generic(lista);
            lres = dd.getData(Id, int.Parse(Year), int.Parse(Month), "SPKPIds_EffectRM_dHead", "Epicor", false, IndexRep, IndexDB);
            return GetStuff(lista, lres);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getAQPVer_Head(string Year, string Month)
        {
            int Id = 7;
            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(Id, true, 0));

            List<dynamic> lres = new List<dynamic>();
            Generic dd = new Generic(lista);
            lres = dd.getData(Id, int.Parse(Year), int.Parse(Month), "SPKPIdsAQPVer_H", "Epicor", true);
            return GetStuff(lista, lres);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getAQPVer_Detail0(string Year, string Month)
        {
            int Id = 7;
            int IndexRep = 0;
            int IndexDB = 1;

            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(Id, false, IndexRep));

            List<dynamic> lres = new List<dynamic>();
            Generic dd = new Generic(lista);
            lres = dd.getData(Id, int.Parse(Year), int.Parse(Month), "SPKPIdsAQPVer_H", "Epicor", false, IndexRep, IndexDB);
            return GetStuff(lista, lres);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]

        public string getIntCOPQ_Head(string Year, string Month)
        {
            int Id = 16;
            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(Id, true, 0));

            List<dynamic> lres = new List<dynamic>();
            Generic dd = new Generic(lista);
            lres = dd.getData(Id, int.Parse(Year), int.Parse(Month), "SPKPIds_IntCOPQ_dHead", "Epicor", true);
            return GetStuff(lista, lres);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getIntCOPQ_Detail0(string Year, string Month)
        {
            int Id = 16;
            int IndexRep = 0;
            int IndexDB = 0;

            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(Id, false, IndexRep));
            
            List<dynamic> lres = new List<dynamic>();
            Generic dd = new Generic(lista);
            lres = dd.getData(Id, int.Parse(Year), int.Parse(Month), "SPKPIds_IntCOPQ_dDetail", "Epicor", false, IndexRep, IndexDB);
            return GetStuff(lista, lres);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string getIntCOPQ_Detail1(string Year, string Month)
        {
            int Id = 16;
            int IndexRep = 1;
            int IndexDB = 1;

            Dictionary<string, string> lista = new Dictionary<string, string>();
            SWMXKPIdll.Detalle.Orchestrator nor = new SWMXKPIdll.Detalle.Orchestrator();
            lista = ArmaMatrix(nor.GetArchitecture(Id, false, IndexRep));

            List<dynamic> lres = new List<dynamic>();
            Generic dd = new Generic(lista);
            lres = dd.getData(Id, int.Parse(Year), int.Parse(Month), "SPKPIds_IntCOPQ_dDetail", "Epicor", false, IndexRep, IndexDB);
            return GetStuff(lista, lres);
        }

        #endregion

        #region "Clasesinhas"

        private string GetStuff(Dictionary<string, string> lista, List<dynamic> lres)
        {

            bool hasMoreRecords = false;
            string Cadena = string.Empty;
            bool Vale = false;

            var sb = new StringBuilder();
            sb.Append(@"{" + "\"sEcho\": 1,");
            sb.Append("\"recordsTotal\": " + lres.Count() + ",");
            sb.Append("\"recordsFiltered\": " + lres.Count() + ",");
            sb.Append("\"iTotalRecords\": " + lres.Count() + ",");
            sb.Append("\"iTotalDisplayRecords\": 10,");
            sb.Append("\"aaData\": [");
            foreach (var item in lres)
            {
                if (hasMoreRecords)
                {
                    sb.Append(",");
                }
                sb.Append("[");
                Vale = false;
                foreach (var elemento in lista)
                {
                    if (elemento.Value == "System.Decimal")
                    {
                        Cadena = Dynamic.InvokeGet(item, elemento.Key).ToString("##,##0.00");
                    }
                    else if (elemento.Value == "System.DateTime")
                    {
                        Cadena = Dynamic.InvokeGet(item, elemento.Key).ToString().Replace("\"", "''");
                        if (Cadena == "01/01/0001 12:00:00 a. m.") { Cadena = ""; }
                    }
                    else
                    {
                        string replaceWith = " ";
                        Cadena = Dynamic.InvokeGet(item, elemento.Key).ToString();
                        //Cadena = Cadena.Replace("\r\n", replaceWith);
                        //Configuraciones de Cambio de Linea
                        Cadena = Cadena.Replace("\n", "\\n");
                        Cadena = Cadena.Replace("\r", "\\r");
                        Cadena = Cadena.Replace("\t", "\\t");
                        Cadena = Cadena.Replace("\"", "''");
                    }
                    Cadena = string.Format("{0}\"{1} \"", (Vale == false ? "" : ","), Cadena);
                    sb.Append(Cadena);
                    Vale = true;
                }
                sb.Append("]");
                hasMoreRecords = true;
            }
            sb.Append("]}");

            return sb.ToString();
        }

        private Dictionary<string, string> ArmaMatrix(List<Architecture> Arch)
        {
            Dictionary<string, string> Res = new Dictionary<string, string>();

            foreach (var D in (from H in Arch select H))
            {
                Res.Add(D.DBName, D.DataType);
            }

            return Res;
        }

        #endregion
    }
}
