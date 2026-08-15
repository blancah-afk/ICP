using SWMXKPIdll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace KPIDashboardV2.Details
{
    /// <summary>
    /// Summary description for wsGauge
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    [ScriptService] // ¡Necesario!
    public class wsGauge : System.Web.Services.WebService
    {


        #region WebMethods

        #region Veolz
        /// <summary>
        /// GetsupplierPPM
        /// Funcion General Para Supplier PPM que obtiene los datos y lo despliega en la grafica.
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="Month"></param>
        /// <param name="id"></param>
        /// <param name="Objetivo"></param>
        /// <param name="IsSub"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetsupplierPPM(int Year, int Month, string id, string Objetivo, string IsSub)
        {

            //Variables
            string Titulo = string.Empty;
            string UOM = string.Empty;
            string Valor = string.Empty;
            ChartRegiones cr = new ChartRegiones();
            Orchestrator dll = new Orchestrator();
            Graficas Grap = new Graficas();
            //llenamos variables
            dll.supplierPPM(Year, Month, Objetivo, "", out Titulo, out UOM, out Valor, out cr);
            //llena Grafica
            return Grap.ArmaStringGraficaInv(id, Titulo, UOM, Valor, cr, (IsSub == "0" ? false : true));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetCostOfWood(int Year, int Month, string id, string Objetivo, string Base, string IsSub)
        {

            //Variables
            string Titulo = string.Empty;
            string UOM = string.Empty;
            string Valor = string.Empty;
            ChartRegiones cr = new ChartRegiones();
            Orchestrator dll = new Orchestrator();
            Graficas Grap = new Graficas();
            //llenamos variables
            dll.CostOfWood(Year, Month, Objetivo, Base, out Titulo, out UOM, out Valor, out cr);
            //llena Grafica
            return Grap.ArmaStringGraficaInv(id, Titulo, UOM, Valor, cr, (IsSub == "0" ? false : true), 3);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetGMPerSegment(int Year, int Month, string id, string Objetivo, string Base, string IsSub)
        {

            //Variables
            string Titulo = string.Empty;
            string UOM = string.Empty;
            string Valor = string.Empty;
            ChartRegiones cr = new ChartRegiones();
            Orchestrator dll = new Orchestrator();
            Graficas Grap = new Graficas();
            //llenamos variables
            dll.GMPerSegment(Year, Month, Objetivo, Base, out Titulo, out UOM, out Valor, out cr);
            //llena Grafica
            return Grap.ArmaStringGrafica(id, Titulo, UOM, Valor, cr, (IsSub == "0" ? false : true), 2);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetDeliveryEvScore(int Year, int Month, string id, string Objetivo, string Base, string IsSub)
        {

            //Variables
            string Titulo = string.Empty;
            string UOM = string.Empty;
            string Valor = string.Empty;
            ChartRegiones cr = new ChartRegiones();
            Orchestrator dll = new Orchestrator();
            Graficas Grap = new Graficas();
            //llenamos variables
            dll.DeliveryEvScore(Year, Month, Objetivo, Base, out Titulo, out UOM, out Valor, out cr);
            //llena Grafica
            return Grap.ArmaStringGrafica(id, Titulo, UOM, Valor, cr, (IsSub == "0" ? false : true), 2);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetEffectRM(int Year, int Month, string id, string Objetivo, string Base, string IsSub)
        {

            //Variables
            string Titulo = string.Empty;
            string UOM = string.Empty;
            string Valor = string.Empty;
            ChartRegiones cr = new ChartRegiones();
            Orchestrator dll = new Orchestrator();
            Graficas Grap = new Graficas();
            //llenamos variables
            dll.EffectRM(Year, Month, Objetivo, Base, out Titulo, out UOM, out Valor, out cr);
            //llena Grafica
            return Grap.ArmaStringGrafica(id, Titulo, UOM, Valor, cr, (IsSub == "0" ? false : true), 2);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetExtCOPQ(int Year, int Month, string id, string Objetivo, string Base, string IsSub)
        {

            //Variables
            string Titulo = string.Empty;
            string UOM = string.Empty;
            string Valor = string.Empty;
            ChartRegiones cr = new ChartRegiones();
            Orchestrator dll = new Orchestrator();
            Graficas Grap = new Graficas();
            //llenamos variables
            dll.ExtCOPQ(Year, Month, Objetivo, Base, out Titulo, out UOM, out Valor, out cr);
            //llena Grafica
            return Grap.ArmaStringGraficaInv(id, Titulo, UOM, Valor, cr, (IsSub == "0" ? false : true), 2);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetAQPVer(int Year, int Month, string id, string Objetivo, string Base, string IsSub)
        {
            //Variables

            string Titulo = string.Empty;
            string UOM = string.Empty;
            string Valor = string.Empty;
            ChartRegiones cr = new ChartRegiones();
            Orchestrator dll = new Orchestrator();
            Graficas Grap = new Graficas();
            //llenamos variables
            dll.AQPVer(Year, Month, Objetivo, Base, out Titulo, out UOM, out Valor, out cr);
            //llena Grafica
            return Grap.ArmaStringGraficaEqual(id, Titulo, UOM, Valor, cr, (IsSub == "0" ? false : true), 2);
            //return Grap.ArmaStringGrafica(id, Titulo, UOM, Valor, cr, (IsSub == "0" ? false : true), 2);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetProdSchComp(int Year, int Month, string id, string Objetivo, string Base, string IsSub)
        {
            //Variables
            string Titulo = string.Empty;
            string UOM = string.Empty;
            string Valor = string.Empty;
            ChartRegiones cr = new ChartRegiones();
            Orchestrator dll = new Orchestrator();
            Graficas Grap = new Graficas();
            //llenamos variables
            dll.ProdSchComp(Year, Month, Objetivo, Base, out Titulo, out UOM, out Valor, out cr);
            //llena Grafica
            return Grap.ArmaStringGrafica(id, Titulo, UOM, Valor, cr, (IsSub == "0" ? false : true), 2);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetECS(int Year, int Month, string id, string Objetivo, string Base, string IsSub)
        {
            //Variables
            string Titulo = string.Empty;
            string UOM = string.Empty;
            string Valor = string.Empty;
            ChartRegiones cr = new ChartRegiones();
            Orchestrator dll = new Orchestrator();
            Graficas Grap = new Graficas();
            //llenamos variables
            dll.ECS(Year, Month, Objetivo, Base, out Titulo, out UOM, out Valor, out cr);
            //llena Grafica
            return Grap.ArmaStringGraficaInv(id, Titulo, UOM, Valor, cr, (IsSub == "0" ? false : true), 2);
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetDRMStatus(int Year, int Month, string id, string Objetivo, string Base, string IsSub)
        {
            //Variables
            string Titulo = string.Empty;
            string UOM = string.Empty;
            string Valor = string.Empty;
            ChartRegiones cr = new ChartRegiones();
            Orchestrator dll = new Orchestrator();
            Graficas Grap = new Graficas();
            //llenamos variables
            dll.DRMStatus(Year, Month, Objetivo, Base, out Titulo, out UOM, out Valor, out cr);
            //llena Grafica
            return Grap.ArmaStringGrafica(id, Titulo, UOM, Valor, cr, (IsSub == "0" ? false : true), 2);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetInvLevel(int Year, int Month, string id, string Objetivo, string Base, string IsSub)
        {

            //Variables
            string Titulo = string.Empty;
            string UOM = string.Empty;
            string Valor = string.Empty;
            ChartRegiones cr = new ChartRegiones();
            Orchestrator dll = new Orchestrator();
            Graficas Grap = new Graficas();
            //llenamos variables
            dll.InvLevel(Year, Month, Objetivo, Base, out Titulo, out UOM, out Valor, out cr);
            //llena Grafica
            if (Convert.ToDouble(Valor) == 0 && Objetivo.Equals("Inv_>_180_Days"))
            {
                Titulo = "Sales ForeCast Not Found.";
            }
            return Grap.ArmaStringGraficaInv(id, Titulo, UOM, Valor, cr, (IsSub == "0" ? false : true), 2);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetCustomerGM(int Year, int Month, string id, string Objetivo, string Base, string IsSub)
        {

            //Variables
            string Titulo = string.Empty;
            string UOM = string.Empty;
            string Valor = string.Empty;
            ChartRegiones cr = new ChartRegiones();
            Orchestrator dll = new Orchestrator();
            Graficas Grap = new Graficas();
            //llenamos variables
            dll.CustomerGM(Year, Month, Objetivo, Base, out Titulo, out UOM, out Valor, out cr);
            //llena Grafica
            return Grap.ArmaStringGrafica(id, Titulo, UOM, Valor, cr, (IsSub == "0" ? false : true), 2);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetSalesForecast(int Year, int Month, string id, string Objetivo, string Base, string IsSub)
        {

            //Variables
            string Titulo = string.Empty;
            string UOM = string.Empty;
            string Valor = string.Empty;
            ChartRegiones cr = new ChartRegiones();
            Orchestrator dll = new Orchestrator();
            Graficas Grap = new Graficas();
            //llenamos variables
            dll.SalesForecast(Year, Month, Objetivo, Base, out Titulo, out UOM, out Valor, out cr);
            //llena Grafica
            return Grap.ArmaStringGrafica(id, Titulo, UOM, Valor, cr, (IsSub == "0" ? false : true), 2);
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetOrganicGrowth(int Year, int Month, string id, string Objetivo, string Base, string IsSub)
        {

            //Variables
            string Titulo = string.Empty;
            string UOM = string.Empty;
            string Valor = string.Empty;
            ChartRegiones cr = new ChartRegiones();
            Orchestrator dll = new Orchestrator();
            Graficas Grap = new Graficas();
            //llenamos variables
            dll.OrganicGrowth(Year, Month, Objetivo, Base, out Titulo, out UOM, out Valor, out cr);
            //llena Grafica
            return Grap.ArmaStringGrafica(id, Titulo, UOM, Valor, cr, (IsSub == "0" ? false : true), 0);
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetAVGPrice(int Year, int Month, string id, string Objetivo, string Base, string IsSub)
        {

            //Variables
            string Titulo = string.Empty;
            string UOM = string.Empty;
            string Valor = string.Empty;
            ChartRegiones cr = new ChartRegiones();
            Orchestrator dll = new Orchestrator();
            Graficas Grap = new Graficas();
            //llenamos variables
            dll.AVGPrice(Year, Month, Objetivo, Base, out Titulo, out UOM, out Valor, out cr);
            //llena Grafica
            return Grap.ArmaStringGraficaInv(id, Titulo, UOM, Valor, cr, (IsSub == "0" ? false : true), 3);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetIntCOPQ(int Year, int Month, string id, string Objetivo, string Base, string IsSub)
        {

            //Variables
            string Titulo = string.Empty;
            string UOM = string.Empty;
            string Valor = string.Empty;
            ChartRegiones cr = new ChartRegiones();
            Orchestrator dll = new Orchestrator();
            Graficas Grap = new Graficas();
            //llenamos variables
            dll.IntCOPQ(Year, Month, Objetivo, Base, out Titulo, out UOM, out Valor, out cr);
            //llena Grafica
            return Grap.ArmaStringGraficaInv(id, Titulo, UOM, Valor, cr, (IsSub == "0" ? false : true), 2);
        }

        #endregion Veloz


        #region Historial
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string Historial(int Year, int Month, string sp, string id, string Objetivo, string Condicion, string Operador, string Decimals, bool base100 = false)
        {

            //Variables
            string Titulo = string.Empty;
            string Limite = string.Empty;
            string Valor = string.Empty;
            string Resultado = string.Empty;
            string UOM = string.Empty;

            KPIHist kh = new KPIHist();
            KPIHist lm = new KPIHist();
            Orchestrator dll = new Orchestrator();
            Graficas Grap = new Graficas();

            //llenamos variables
            dll.Historial(Year, Month, sp, Condicion, Objetivo, out UOM, out Titulo, out Limite, out kh, out lm);
            //llena Grafica
            if (lm == null)
            {
                lm = HardCodeLimit(Limite, Month);
            }
            //return kh;
            Resultado = Grap.ArmaStringBar(id, Month, Titulo, UOM, lm, kh, Operador, int.Parse(Decimals), base100);
            return Resultado;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string HistorialMulti(int Year, int Month, string sp, string id, string Objetivo, string Condicion, string Operador, string Decimals, bool base100 = false)
        {

            //Variables
            string Titulo = string.Empty;
            string Limite = string.Empty;
            string Valor = string.Empty;
            string Resultado = string.Empty;
            string UOM = string.Empty;

            List<KPIHist> kh = new List<KPIHist>();
            KPIHist lm = new KPIHist();
            Orchestrator dll = new Orchestrator();
            Graficas Grap = new Graficas();

            //llenamos variables
            dll.Historial(Year, Month, sp, Condicion, Objetivo, out UOM, out Titulo, out Limite, out kh, out lm);
            //llena Grafica
            if (lm == null)
            {
                lm = HardCodeLimit(Limite, Month);
            }
            //return kh;
            Resultado = Grap.ArmaStringBar(id, Month, Titulo, UOM, lm, kh, Operador, int.Parse(Decimals), base100);
            return Resultado;
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string HistorialMultiFuture(int Year, int Month, string sp, string id, string Objetivo, string Condicion, string Operador, string Decimals, bool base100 = false)
        {

            //Variables
            string Titulo = string.Empty;
            string Limite = string.Empty;
            string Valor = string.Empty;
            string Resultado = string.Empty;
            string UOM = string.Empty;

            List<KPIHist> kh = new List<KPIHist>();
            KPIHist lm = new KPIHist();
            Orchestrator dll = new Orchestrator();
            Graficas Grap = new Graficas();

            //llenamos variables
            dll.Historial(Year, Month, sp, Condicion, Objetivo, out UOM, out Titulo, out Limite, out kh, out lm);
            //llena Grafica
            if (lm == null)
            {
                lm = HardCodeLimit(Limite, Month);
            }
            //return kh;
            Resultado = Grap.ArmaStringBar(id, Month, Titulo, UOM, lm, kh, Operador, int.Parse(Decimals), base100);
            return Resultado;
        }

        #endregion Historial
        //public void MakeCristal(int Report, string FiscalYear, string FiscalPeriod)
        //{
        //    Crystals cr = new Crystals(CRVReport, FiscalYear, FiscalPeriod);
        //    //cr.GenerarReporte("KPIs", Report);
        //    ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { OpCrisModOff(); });", true);
        //}
        #endregion WebMethods

        #region Funciones
        static KPIHist HardCodeLimit(string Limite, int Month)
        {
            KPIHist lm = new KPIHist();
            for (int ii = 1; ii <= Month; ii++)
            {
                switch (ii)
                {
                    case 1:
                        lm.Enero = Limite;
                        break;
                    case 2:
                        lm.Febrero = Limite;
                        break;
                    case 3:
                        lm.Marzo = Limite;
                        break;
                    case 4:
                        lm.Abril = Limite;
                        break;
                    case 5:
                        lm.Mayo = Limite;
                        break;
                    case 6:
                        lm.Junio = Limite;
                        break;
                    case 7:
                        lm.Julio = Limite;
                        break;
                    case 8:
                        lm.Agosto = Limite;
                        break;
                    case 9:
                        lm.Septiembre = Limite;
                        break;
                    case 10:
                        lm.Octubre = Limite;
                        break;
                    case 11:
                        lm.Noviembre = Limite;
                        break;
                    case 12:
                        lm.Diciembre = Limite;
                        break;
                }
            }

            return lm;
        }
        #endregion
    }
}
