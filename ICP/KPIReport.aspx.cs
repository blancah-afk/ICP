using ICPDataAccess;
using ICPDataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ICPGraphs;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using ClosedXML.Excel;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Bibliography;
using System.Web.Services;
using BusinessObjects.Enterprise.Infostore;
using DocumentFormat.OpenXml.Drawing.Charts;
using CrearDocumentoPDF;
using BusinessObjects.Enterprise.Ras21.Messages;
using System.Web.Script.Services;
using iTextSharp.text.pdf.codec.wmf;
using System.Web.Services.Protocols;


namespace ICP
{
    public partial class KPIReport : System.Web.UI.Page
    {
        ICPDataAccess.DaKPIReport da = new ICPDataAccess.DaKPIReport();
        DaKPIReport2 da2 = new DaKPIReport2();
        public static string strCompany = "SWMX";   

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["TopFiveDtl"] = null;
                _YearsKPI(ddlYear);
                _MonthsKPI(ddlMonth);
                //_AddAlertButton(btnSendEmail, _SelectCurrentMonth());
                _LoadInfo();
                _LoadAdditionalComment(_SelectCurrentMonth());
                _LoadComment(_SelectCurrentMonth());
                _LoadTopFive(_SelectCurrentMonth());
                _LoadExpPerformanceGaps(_SelectCurrentMonth());
                _SelectView(_SelectCurrentMonth());
                correos.Value = ObtenerCorreos();
            }
        }

        #region Repeaters Events

        #region KPI
        protected void rptKPICategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //                                             Encontrar los controles.
            Label lblIDCategory = (Label)e.Item.FindControl("lblIDCategory");
            Repeater rptSubCategory = (Repeater)e.Item.FindControl("rptSubCategory");

            //                                             Declarar variables
            DataSet ds = new DataSet();
            int idCategory = 0;

            try
            {
                if (lblIDCategory != null)
                {
                    idCategory = Convert.ToInt32(lblIDCategory.Text);
                    ds = da.ds_KPIReport("KPISubCategories", idCategory, null, Convert.ToInt32(ddlYear.SelectedValue), strCompany);

                    //                                     Ligamos el Data Source con el control
                    rptSubCategory.DataSource = ds.Tables[0];
                    rptSubCategory.DataBind();

                }
            }
            catch (Exception ex)
            {
                //showMessage(ex.Message);
            }
        }

        protected void rptSubCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //                                             Encontrar los controles.
            Label lblIDCategory = (Label)e.Item.FindControl("IDCategory");
            Label lblIDSubCategory = (Label)e.Item.FindControl("lblIDSubCategory");
            Label lblPastYear = (Label)e.Item.FindControl("lblPastYear");
            Label lblCurrentYear = (Label)e.Item.FindControl("lblCurrentYear");
            Repeater rptKPIDet = (Repeater)e.Item.FindControl("rptKPIDet");
            DataSet dsKPIDeatil = new DataSet();
            //                                             Declarar variables
            int? idCategory;
            int? idSubCategory;



            try
            {
                if (lblIDCategory != null)
                {
                    lblCurrentYear.Text = ddlYear.SelectedValue;
                    lblPastYear.Text = Convert.ToString(Convert.ToInt32(ddlYear.SelectedValue) - 1);

                    idCategory = Convert.ToInt32(lblIDCategory.Text);
                    idSubCategory = Convert.ToInt32(lblIDSubCategory.Text);

                    dsKPIDeatil = da.ds_KPIReportDtl("Detalle", idCategory, idSubCategory, Convert.ToInt32(ddlYear.SelectedValue), strCompany);
                    //                                     Ligamos el Data Source con el control
                    rptKPIDet.DataSource = dsKPIDeatil.Tables[0];
                    rptKPIDet.DataBind();
                }

            }
            catch (Exception ex)
            {
                //showMessage(ex.Message);
            }

        }

        //Formato de Indicadores, color, decilames, porcentajes.
        protected void rptKPIDet_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            string strDataType = "";
            ExportFile format = new ExportFile();
            Label lblDataType = (Label)e.Item.FindControl("lblDataType");
            Label lblOperator = (Label)e.Item.FindControl("lblOperator");
            Label lblPrevYearResult = (Label)e.Item.FindControl("lblPrevYearResult");
            Label lblCurrentYearGoal = (Label)e.Item.FindControl("lblCurrentYearGoal");
            Label PJaan = (Label)e.Item.FindControl("PJan");
            Label lblSubCategory = (Label)e.Item.FindControl("lblSubCategory");
            Label lblID = (Label)e.Item.FindControl("lblID");

            #region GetItems

            Label PJan = (Label)e.Item.FindControl("lblPlanning1");
            Label AJan = (Label)e.Item.FindControl("lblActual1");
            Label KPIRangeJan = (Label)e.Item.FindControl("lblKPIRange1");
            Label lblUpdMethod1 = (Label)e.Item.FindControl("lblUpdMethod1");

            Label PFeb = (Label)e.Item.FindControl("lblPlanning2");
            Label AFeb = (Label)e.Item.FindControl("lblActual2");
            Label KPIRangeFeb = (Label)e.Item.FindControl("lblKPIRange2");
            Label lblUpdMethod2 = (Label)e.Item.FindControl("lblUpdMethod2");

            Label PMar = (Label)e.Item.FindControl("lblPlanning3");
            Label AMar = (Label)e.Item.FindControl("lblActual3");
            Label KPIRangeMar = (Label)e.Item.FindControl("lblKPIRange3");
            Label lblUpdMethod3 = (Label)e.Item.FindControl("lblUpdMethod3");

            Label PApr = (Label)e.Item.FindControl("lblPlanning4");
            Label AApr = (Label)e.Item.FindControl("lblActual4");
            Label KPIRangeApr = (Label)e.Item.FindControl("lblKPIRange4");
            Label lblUpdMethod4 = (Label)e.Item.FindControl("lblUpdMethod4");

            Label PMay = (Label)e.Item.FindControl("lblPlanning5");
            Label AMay = (Label)e.Item.FindControl("lblActual5");
            Label KPIRangeMay = (Label)e.Item.FindControl("lblKPIRange5");
            Label lblUpdMethod5 = (Label)e.Item.FindControl("lblUpdMethod5");

            Label PJune = (Label)e.Item.FindControl("lblPlanning6");
            Label AJune = (Label)e.Item.FindControl("lblActual6");
            Label KPIRangeJune = (Label)e.Item.FindControl("lblKPIRange6");
            Label lblUpdMethod6 = (Label)e.Item.FindControl("lblUpdMethod6");

            Label PJuly = (Label)e.Item.FindControl("lblPlanning7");
            Label AJuly = (Label)e.Item.FindControl("lblActual7");
            Label KPIRangeJuly = (Label)e.Item.FindControl("lblKPIRange7");
            Label lblUpdMethod7 = (Label)e.Item.FindControl("lblUpdMethod7");

            Label PAug = (Label)e.Item.FindControl("lblPlanning8");
            Label AAug = (Label)e.Item.FindControl("lblActual8");
            Label KPIRangeAug = (Label)e.Item.FindControl("lblKPIRange8");
            Label lblUpdMethod8 = (Label)e.Item.FindControl("lblUpdMethod8");

            Label PSep = (Label)e.Item.FindControl("lblPlanning9");
            Label ASep = (Label)e.Item.FindControl("lblActual9");
            Label KPIRangeSep = (Label)e.Item.FindControl("lblKPIRange9");
            Label lblUpdMethod9 = (Label)e.Item.FindControl("lblUpdMethod9");

            Label POct = (Label)e.Item.FindControl("lblPlanning10");
            Label AOct = (Label)e.Item.FindControl("lblActual10");
            Label KPIRangeOct = (Label)e.Item.FindControl("lblKPIRange10");
            Label lblUpdMethod10 = (Label)e.Item.FindControl("lblUpdMethod10");

            Label PNov = (Label)e.Item.FindControl("lblPlanning11");
            Label ANov = (Label)e.Item.FindControl("lblActual11");
            Label KPIRangeNov = (Label)e.Item.FindControl("lblKPIRange11");
            Label lblUpdMethod11 = (Label)e.Item.FindControl("lblUpdMethod11");

            Label PDec = (Label)e.Item.FindControl("lblPlanning12");
            Label ADec = (Label)e.Item.FindControl("lblActual12");
            Label KPIRangeDec = (Label)e.Item.FindControl("lblKPIRange12");
            Label lblUpdMethod12 = (Label)e.Item.FindControl("lblUpdMethod12");

            Label YTDPlan = (Label)e.Item.FindControl("PTgtYTD");
            Label YTDActual = (Label)e.Item.FindControl("ATgtYTD");
            #endregion

            #region Label Text
            if (lblSubCategory != null)
            {
                Label lblPrior = (Label)e.Item.FindControl("lblPrior");

                if (lblSubCategory.Text == "3")
                {
                    if (lblPrior != null)
                    {
                        lblPrior.Text = "Prior";
                    }
                }
                else
                {
                    if (lblPrior != null)
                    {
                        lblPrior.Text = "Plan";
                    }
                }
            }

            #endregion

            #region Format Data and Color

            try
            {
                if ((lblDataType != null)
                    && (lblPrevYearResult != null)
                    && (lblCurrentYearGoal != null))
                {
                    strDataType = lblDataType.Text;

                    #region setColorStyle

                    string NoInfo = "NoInfoAvailabe";
                    ((HtmlControl)e.Item.FindControl("tdAJan")).Attributes.Add("class", KPIRangeJan.Text == "" ? NoInfo : KPIRangeJan.Text);
                    ((HtmlControl)e.Item.FindControl("tdAFeb")).Attributes.Add("class", KPIRangeFeb.Text == "" ? NoInfo : KPIRangeFeb.Text);
                    ((HtmlControl)e.Item.FindControl("tdAMar")).Attributes.Add("class", KPIRangeMar.Text == "" ? NoInfo : KPIRangeMar.Text);
                    ((HtmlControl)e.Item.FindControl("tdAApr")).Attributes.Add("class", KPIRangeApr.Text == "" ? NoInfo : KPIRangeApr.Text);
                    ((HtmlControl)e.Item.FindControl("tdAMay")).Attributes.Add("class", KPIRangeMay.Text == "" ? NoInfo : KPIRangeMay.Text);
                    ((HtmlControl)e.Item.FindControl("tdAJune")).Attributes.Add("class", KPIRangeJune.Text == "" ? NoInfo : KPIRangeJune.Text);
                    ((HtmlControl)e.Item.FindControl("tdAJuly")).Attributes.Add("class", KPIRangeJuly.Text == "" ? NoInfo : KPIRangeJuly.Text);
                    ((HtmlControl)e.Item.FindControl("tdAAug")).Attributes.Add("class", KPIRangeAug.Text == "" ? NoInfo : KPIRangeAug.Text);
                    ((HtmlControl)e.Item.FindControl("tdASep")).Attributes.Add("class", KPIRangeSep.Text == "" ? NoInfo : KPIRangeSep.Text);
                    ((HtmlControl)e.Item.FindControl("tdAOct")).Attributes.Add("class", KPIRangeOct.Text == "" ? NoInfo : KPIRangeOct.Text);
                    ((HtmlControl)e.Item.FindControl("tdANov")).Attributes.Add("class", KPIRangeNov.Text == "" ? NoInfo : KPIRangeNov.Text);
                    ((HtmlControl)e.Item.FindControl("tdADec")).Attributes.Add("class", KPIRangeDec.Text == "" ? NoInfo : KPIRangeDec.Text);
                    string setee = KPIRangeMay.Text == "" ? NoInfo : KPIRangeMay.Text;

                    #endregion

                    #region DataFormta
                    ////Deacuerdo con el valor formatear con % o , segun corresponda
                    string idKPI = "";
                    if (lblID != null)
                    {
                        idKPI = lblID.Text;
                    }
                    if (idKPI == "16")
                    {
                        idKPI = lblID.Text;
                    }
                    lblPrevYearResult.Text = format.str_DataFormat(strDataType, idKPI, lblPrevYearResult.Text, "", 0);
                    lblCurrentYearGoal.Text = format.str_DataFormat(strDataType, idKPI, lblCurrentYearGoal.Text, "", 0);

                    _setLabels(PJan, AJan, lblUpdMethod1, idKPI, strDataType, 1);
                    _setLabels(PFeb, AFeb, lblUpdMethod2, idKPI, strDataType, 2);
                    _setLabels(PMar, AMar, lblUpdMethod3, idKPI, strDataType, 3);
                    _setLabels(PApr, AApr, lblUpdMethod4, idKPI, strDataType, 4);
                    _setLabels(PMay, AMay, lblUpdMethod5, idKPI, strDataType, 5);
                    _setLabels(PJune, AJune, lblUpdMethod6, idKPI, strDataType, 6);
                    _setLabels(PJuly, AJuly, lblUpdMethod7, idKPI, strDataType, 7);
                    _setLabels(PAug, AAug, lblUpdMethod8, idKPI, strDataType, 8);
                    _setLabels(PSep, ASep, lblUpdMethod9, idKPI, strDataType, 9);
                    _setLabels(POct, AOct, lblUpdMethod10, idKPI, strDataType, 10);
                    _setLabels(PNov, ANov, lblUpdMethod11, idKPI, strDataType, 11);
                    _setLabels(PDec, ADec, lblUpdMethod12, idKPI, strDataType, 12);
                    _setLabels(YTDPlan, YTDActual, lblUpdMethod12, idKPI, strDataType, 12);
                     

                    #endregion
                }

            }
            catch (Exception ex)
            {
                string var = ex.Message;
            }

            #endregion
        }

        private void _setLabels(Label lblPlanning, Label lblActual, Label lblUpdMethod, string idKPI,  string strDataType, int Mes)
        {
            ExportFile format = new ExportFile();
            lblPlanning.Text = format.str_DataFormat(strDataType, idKPI, lblPlanning.Text, "", Mes);
            lblActual.Text = format.str_DataFormat(strDataType, idKPI, lblActual.Text, lblUpdMethod.Text, Mes);
        }

    #endregion
        
        #region Exp
        protected void rptExp_PerformanceGaps_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void rptExpSubCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Label lblIDCategory = (Label)e.Item.FindControl("IDCategory");
            Label lblIDSubCategory = (Label)e.Item.FindControl("lblIDSubCategory");
            Label lblHead1 = (Label)e.Item.FindControl("lblHead1");
            Label lblHead2 = (Label)e.Item.FindControl("lblHead2");
            Repeater rptKPIDet = (Repeater)e.Item.FindControl("rptExpDet");

            DataSet dsKPIDeatil = new DataSet();
            int? idCategory;
            int? idSubCategory;

            try
            {
                if (lblIDCategory != null)
                {
                    idCategory = Convert.ToInt32(lblIDCategory.Text);
                    idSubCategory = Convert.ToInt32(lblIDSubCategory.Text);
                    System.Data.DataTable dt = (System.Data.DataTable)ViewState["ExpPerformanceGaps"];
                    System.Data.DataTable dtSource = da.dt_dataSourceDet(dt, idCategory, idSubCategory);

                    if (dtSource.Rows.Count > 0)
                    {
                        rptKPIDet.Visible = true;
                        lblHead1.Visible = true;
                        lblHead2.Visible = true;
                        rptKPIDet.DataSource = dtSource;
                        rptKPIDet.DataBind();
                    }
                    else
                    {
                        rptKPIDet.Visible = false;
                        lblHead1.Visible = false;
                        lblHead2.Visible = false;
                    }

                }

            }
            catch (Exception ex)
            {
               
            }
        }

        protected void rptExpDet_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void rptExpCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //                                             Encontrar los controles.
            Label lblIDCategory = (Label)e.Item.FindControl("lblIDCategory");
            Repeater rptSubCategory = (Repeater)e.Item.FindControl("rptExpSubCategory");

            //                                             Declarar variables
            DataSet ds = new DataSet();
            int idCategory = 0;

            try
            {
                if (lblIDCategory != null)
                {
                    idCategory = Convert.ToInt32(lblIDCategory.Text);
                    ds = da.ds_KPIReport("KPISubCategories", idCategory, null, Convert.ToInt32(ddlYear.SelectedValue), strCompany);

                    //                                     Ligamos el Data Source con el control
                    rptSubCategory.DataSource = ds.Tables[0];
                    rptSubCategory.DataBind();

                }

            }
            catch (Exception ex)
            {
                //showMessage(ex.Message);
            }
        }
        #endregion

        #region TopFive
        protected void rptTopFive_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater rptTopFiveDtl = (Repeater)e.Item.FindControl("rptTopFiveDtl");
            if (rptTopFiveDtl != null)
            {
                System.Data.DataTable dt = (System.Data.DataTable)ViewState["TopFiveDtl"];
                rptTopFiveDtl.DataSource = dt;
                rptTopFiveDtl.DataBind();
            }
        }

        #endregion
        #endregion

        #region Control Events
        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            _LoadExpPerformanceGaps(_SelectCurrentMonth());
           // _AddAlertButton(btnSendEmail, _SelectCurrentMonth());
            _SelectView(_SelectCurrentMonth());
        }

        #region Buttons

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            _LoadInfo();
            _LoadExpPerformanceGaps(_SelectCurrentMonth());
        }

        protected void lnkCategory_Click(object sender, EventArgs e)
        {

        }

        protected void lnkColapse_Click(object sender, EventArgs e)
        {
            var lnkCategory = (LinkButton)sender;
            var rpt = (RepeaterItem)lnkCategory.NamingContainer;
            Repeater rptSubCategory = (Repeater)rpt.FindControl("rptSubCategory");

            if (rptSubCategory.Visible)
            {
                rptSubCategory.Visible = false;
                lnkCategory.Text = "+";
            }
            else
            {
                rptSubCategory.Visible = true;
                lnkCategory.Text = "-";
            }

        }

        protected void btnExportXLS_Click(object sender, EventArgs e)
        {
            //Se mandan parametros vacios porque no hay descarga
            GenerateReport_XLS(false, 0, 0);
        }

        protected void btnExporPDF_Click(object sender, EventArgs e)
        {
            GenerateReport_PDF();
        }
        protected void btnSendEmail_Click(object sender, EventArgs e)
        {

            //ScriptManager.RegisterStartupScript(this, GetType(), "alerta", "alert('The email has been sent successfully');", true);
            int iYear = int.Parse(ddlYear.SelectedValue.ToString());
            int iMonth = int.Parse(ddlMonth.SelectedValue.ToString());
            SendEmailReport_PDF(iYear, iMonth);
        }
        #endregion

        #endregion

        #region Events

        private void _LoadInfo()
        {
            //                  Cargar información de los indicadores
            DataSet ds = new DataSet();
            ds = da.ds_KPIReport("KPICategories", null, null, Convert.ToInt32(ddlYear.SelectedValue), strCompany);
            ViewState["Categories"] = ds;
            rptKPICategory.DataSource = ds.Tables[0];
            rptKPICategory.DataBind();
            _SelectView(_SelectCurrentMonth());

        }

        private void _LoadInfoExp()
        {
            //                  Cargar información de los indicadores
            DataSet ds = new DataSet();
            ds = da.ds_KPIReport("KPICategories", null, null, Convert.ToInt32(ddlYear.SelectedValue), strCompany);

            rptExpCategory.DataSource = ds.Tables[0];
            rptExpCategory.DataBind();
        }

        private void _LoadAdditionalComment(int period)
        {

            DataSet ds = new DataSet();
            ds = da.ds_KPIReport("KPIAditionalComment", null, null, Convert.ToInt32(ddlYear.SelectedValue), strCompany);

            System.Data.DataTable dt = ds.Tables[0];
            rptAdditionalComment.DataSource = da.dt_dataSource(dt, period);
            rptAdditionalComment.DataBind();

            ViewState["KPIAdditionalComment"] = da.dt_dataSource(dt, period);
            ViewState["SelectedPeriod"] = period;

        }

        private void _LoadComment(int period)
        {

            DataSet ds = new DataSet();
            ds = da.ds_KPIReport("KPIComment", null, null, Convert.ToInt32(ddlYear.SelectedValue), strCompany);

            System.Data.DataTable dt = ds.Tables[0];


            System.Data.DataTable dt1 = new System.Data.DataTable();
            IEnumerable<DataRow> query = 
                (from x in dt.AsEnumerable() where x.Field<int>("Period") == period
                 orderby x.Field<string>("Name") ascending select x);
            if (query.Count() > 0)
            {
                dt1 = query.CopyToDataTable();
            }
            

            rptComment1.DataSource = dt1;
            rptComment1.DataBind();

            ViewState["KPIComment"] = dt1;
            ViewState["SelectedPeriod"] = period;

        }

        private void _LoadTopFive(int iPeriod)
        {
            DataSet ds = new DataSet();
            ds = da.ds_KPIReport("TopFive", null, null, Convert.ToInt32(ddlYear.SelectedValue), strCompany);

            System.Data.DataTable dt = ds.Tables[0];
            System.Data.DataTable dtl = ds.Tables[1];

            ViewState["TopFiveDtl"] = da.dt_dataSource(dtl, iPeriod);

            rptTopFive.DataSource = dt;
            rptTopFive.DataBind();

        }

        private void _LoadExpPerformanceGaps(int iPeriod)
        {
            DataSet ds = new DataSet();
            ds = da.ds_KPIReport("rptExpDet", null, null, Convert.ToInt32(ddlYear.SelectedValue), strCompany);
            System.Data.DataTable dt = ds.Tables[0];
            ViewState["ExpPerformanceGaps"] = da.dt_dataSource(dt, iPeriod);

        }

        public void _YearsKPI(DropDownList ddlY)
        {
            //                      Cargar Lista de Años para seleccionar el Period anual de metas. 
            ddlY.DataSource = _lstFiscalYear();
            ddlY.Text = Convert.ToString(DateTime.Today.Year);
            ddlY.DataBind();
        }

        public void _MonthsKPI(DropDownList ddlM)
        {
            //                      Cargar Lista de Años para seleccionar el Period anual de metas. 
            ddlM.DataSource = _lstFiscalPeriod();
            ddlM.Text = Convert.ToString(DateTime.Today.Month);
            ddlM.DataBind();
        }
        public void _AddAlertButton(Button btnEmail,int iMonth) 
        {
            
            var ds = da.ds_KPIReportEmailAddressGroup();
            System.Data.DataTable dt = ds.Tables[0];
            string[] EmailTo = dt.Rows[0]["AddressTo"].ToString().Split(',');
            string[] EmailCc = dt.Rows[0]["AddressCc"].ToString().Split(',');
            System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
            string MonthName = mfi.GetMonthName(iMonth).ToString();
            string stryear = ddlYear.SelectedValue.ToString();

            string message = "return confirm('Are you sure to send the report for the " + MonthName + " "+ stryear + " period to the following emails?\\n";
            foreach (string str in EmailTo)
            {
                message += str+"\\n";
            }
            foreach (string str in EmailCc)
            {
                message += str + "\\n";
            }
            message += "');";
            btnEmail.OnClientClick = message;//"return confirm('Estas seguro de enviar el reporte por correo electronico');";
        }
        private List<int> _lstFiscalYear()
        {
            return Enumerable.Range(2019, 10).ToList();
        }
        private List<int> _lstFiscalPeriod()
        {
            return Enumerable.Range(1, 12).ToList();
        }

        private int _SelectCurrentMonth()
        {
            int iMonth = int.Parse(ddlMonth.SelectedValue.ToString());//DateTime.Now.Month;
            return iMonth;
        }

        private string clicked(bool i)
        {
            string str = "";
            if (i)
            {
                str = "Clicked";
            }
            else
            {
                str = "Initial";
            }

            return str;
        }

        private void _SelectView(int iMonth)
        {
            int index = iMonth - 1;

            switch (iMonth)
            {
                case 1:

                    Ene.CssClass = clicked(true);
                    February.CssClass = clicked(false);
                    March.CssClass = clicked(false);
                    April.CssClass = clicked(false);
                    May.CssClass = clicked(false);
                    June.CssClass = clicked(false);
                    July.CssClass = clicked(false);
                    August.CssClass = clicked(false);
                    September.CssClass = clicked(false);
                    October.CssClass = clicked(false);
                    November.CssClass = clicked(false);
                    December.CssClass = clicked(false);
                    _LoadAdditionalComment(1);
                    _LoadComment(1);
                    _LoadTopFive(1);
                    _LoadExpPerformanceGaps(1);
                    _LoadInfoExp();
                    MainView.ActiveViewIndex = 0;


                    break;
                case 2:

                    Ene.CssClass = clicked(false);
                    February.CssClass = clicked(true);
                    March.CssClass = clicked(false);
                    April.CssClass = clicked(false);
                    May.CssClass = clicked(false);
                    June.CssClass = clicked(false);
                    July.CssClass = clicked(false);
                    August.CssClass = clicked(false);
                    September.CssClass = clicked(false);
                    October.CssClass = clicked(false);
                    November.CssClass = clicked(false);
                    December.CssClass = clicked(false); 
                    _LoadAdditionalComment(2);
                    _LoadComment(2);
                    _LoadTopFive(2);
                    _LoadExpPerformanceGaps(2);
                    _LoadInfoExp();
                    MainView.ActiveViewIndex = 0;

                    break;
                case 3:

                    Ene.CssClass = clicked(false);
                    February.CssClass = clicked(false);
                    March.CssClass = clicked(true);
                    April.CssClass = clicked(false);
                    May.CssClass = clicked(false);
                    June.CssClass = clicked(false);
                    July.CssClass = clicked(false);
                    August.CssClass = clicked(false);
                    September.CssClass = clicked(false);
                    October.CssClass = clicked(false);
                    November.CssClass = clicked(false);
                    December.CssClass = clicked(false);
                    _LoadAdditionalComment(3);
                    _LoadComment(3);
                    _LoadTopFive(3);
                    _LoadExpPerformanceGaps(3);
                    _LoadInfoExp();
                    MainView.ActiveViewIndex = 0;

                    break;
                case 4:

                    Ene.CssClass = "Initial";
                    February.CssClass = "Initial";
                    March.CssClass = "Initial";
                    April.CssClass = "Clicked";
                    May.CssClass = "Initial";
                    June.CssClass = "Initial";
                    July.CssClass = "Initial";
                    August.CssClass = "Initial";
                    September.CssClass = "Initial";
                    October.CssClass = "Initial";
                    November.CssClass = "Initial";
                    December.CssClass = "Initial";
                    _LoadAdditionalComment(4);
                    _LoadComment(4);
                    _LoadTopFive(4);
                    _LoadExpPerformanceGaps(4);
                    _LoadInfoExp();
                    MainView.ActiveViewIndex = 0;

                    break;
                case 5:


                    Ene.CssClass = "Initial";
                    February.CssClass = "Initial";
                    March.CssClass = "Initial";
                    April.CssClass = "Initial";
                    May.CssClass = "Clicked";
                    June.CssClass = "Initial";
                    July.CssClass = "Initial";
                    August.CssClass = "Initial";
                    September.CssClass = "Initial";
                    October.CssClass = "Initial";
                    November.CssClass = "Initial";
                    December.CssClass = "Initial";
                    _LoadAdditionalComment(5);
                    _LoadComment(5);
                    _LoadTopFive(5);
                    _LoadExpPerformanceGaps(5);
                    _LoadInfoExp();
                    MainView.ActiveViewIndex = 0;

                    break;
                case 6:

                    Ene.CssClass = "Initial";
                    February.CssClass = "Initial";
                    March.CssClass = "Initial";
                    April.CssClass = "Initial";
                    May.CssClass = "Initial";
                    June.CssClass = "Clicked";
                    July.CssClass = "Initial";
                    August.CssClass = "Initial";
                    September.CssClass = "Initial";
                    October.CssClass = "Initial";
                    November.CssClass = "Initial";
                    December.CssClass = "Initial";
                    _LoadAdditionalComment(6);
                    _LoadComment(6);
                    _LoadTopFive(6);
                    _LoadExpPerformanceGaps(6);
                    _LoadInfoExp();
                    MainView.ActiveViewIndex = 0;


                    break;
                case 7:

                    Ene.CssClass = "Initial";
                    February.CssClass = "Initial";
                    March.CssClass = "Initial";
                    April.CssClass = "Initial";
                    May.CssClass = "Initial";
                    June.CssClass = "Initial";
                    July.CssClass = "Clicked";
                    August.CssClass = "Initial";
                    September.CssClass = "Initial";
                    October.CssClass = "Initial";
                    November.CssClass = "Initial";
                    December.CssClass = "Initial";
                    MainView.ActiveViewIndex = 0;
                    _LoadAdditionalComment(7);
                    _LoadComment(7);
                    _LoadTopFive(7);
                    _LoadExpPerformanceGaps(7);
                    _LoadInfoExp();

                    break;
                case 8:

                    Ene.CssClass = "Initial";
                    February.CssClass = "Initial";
                    March.CssClass = "Initial";
                    April.CssClass = "Initial";
                    May.CssClass = "Initial";
                    June.CssClass = "Initial";
                    July.CssClass = "Initial";
                    August.CssClass = "Clicked";
                    September.CssClass = "Initial";
                    October.CssClass = "Initial";
                    November.CssClass = "Initial";
                    December.CssClass = "Initial";
                    _LoadAdditionalComment(8);
                    _LoadComment(8);
                    _LoadTopFive(8);
                    _LoadExpPerformanceGaps(8);
                    _LoadInfoExp();
                    MainView.ActiveViewIndex = 0;

                    break;
                case 9:

                    Ene.CssClass = "Initial";
                    February.CssClass = "Initial";
                    March.CssClass = "Initial";
                    April.CssClass = "Initial";
                    May.CssClass = "Initial";
                    June.CssClass = "Initial";
                    July.CssClass = "Initial";
                    August.CssClass = "Initial";
                    September.CssClass = "Clicked";
                    October.CssClass = "Initial";
                    November.CssClass = "Initial";
                    December.CssClass = "Initial";
                    _LoadAdditionalComment(9);
                    _LoadComment(9);
                    _LoadTopFive(9);
                    _LoadExpPerformanceGaps(9);
                    _LoadInfoExp();
                    MainView.ActiveViewIndex = 0;

                    break;

                case 10:
                    Ene.CssClass = "Initial";
                    February.CssClass = "Initial";
                    March.CssClass = "Initial";
                    April.CssClass = "Initial";
                    May.CssClass = "Initial";
                    June.CssClass = "Initial";
                    July.CssClass = "Initial";
                    August.CssClass = "Initial";
                    September.CssClass = "Initial";
                    October.CssClass = "Clicked";
                    November.CssClass = "Initial";
                    December.CssClass = "Initial";
                    _LoadAdditionalComment(10);
                    _LoadComment(10);
                    _LoadTopFive(10);
                    _LoadExpPerformanceGaps(10);
                    _LoadInfoExp();
                    MainView.ActiveViewIndex = 0;


                    break;
                case 11:

                    Ene.CssClass = "Initial";
                    February.CssClass = "Initial";
                    March.CssClass = "Initial";
                    April.CssClass = "Initial";
                    May.CssClass = "Initial";
                    June.CssClass = "Initial";
                    July.CssClass = "Initial";
                    August.CssClass = "Initial";
                    September.CssClass = "Initial";
                    October.CssClass = "Initial";
                    November.CssClass = "Clicked";
                    December.CssClass = "Initial";
                    _LoadAdditionalComment(11);
                    _LoadComment(11);
                    _LoadTopFive(11);
                    _LoadExpPerformanceGaps(11);
                    _LoadInfoExp();

                    MainView.ActiveViewIndex = 0;

                    break;
                case 12:

                    Ene.CssClass = "Initial";
                    February.CssClass = "Initial";
                    March.CssClass = "Initial";
                    April.CssClass = "Initial";
                    May.CssClass = "Initial";
                    June.CssClass = "Initial";
                    July.CssClass = "Initial";
                    August.CssClass = "Initial";
                    September.CssClass = "Initial";
                    October.CssClass = "Initial";
                    November.CssClass = "Initial";
                    December.CssClass = "Clicked";
                    MainView.ActiveViewIndex = 0;
                    _LoadAdditionalComment(12);
                    _LoadComment(12);
                    _LoadTopFive(12);
                    _LoadExpPerformanceGaps(12);
                    _LoadInfoExp();
                    break;
            }


        }
        #endregion

        #region TabCommentEvents
        protected void Ene_Click(object sender, EventArgs e)
        {
            _SelectView(1);
        }

        protected void February_Click(object sender, EventArgs e)
        {
            _SelectView(2);
        }

        protected void March_Click(object sender, EventArgs e)
        {
            _SelectView(3);
        }

        protected void April_Click(object sender, EventArgs e)
        {
            _SelectView(4);
        }

        protected void May_Click(object sender, EventArgs e)
        {
            _SelectView(5);
        }

        protected void June_Click(object sender, EventArgs e)
        {
            _SelectView(6);
        }

        protected void July_Click(object sender, EventArgs e)
        {
            _SelectView(7);
        }

        protected void August_Click(object sender, EventArgs e)
        {
            _SelectView(8);
        }

        protected void September_Click(object sender, EventArgs e)
        {
            _SelectView(9);
        }

        protected void October_Click(object sender, EventArgs e)
        {
            _SelectView(10);
        }

        protected void November_Click(object sender, EventArgs e)
        {
            _SelectView(11);
        }

        protected void December_Click(object sender, EventArgs e)
        {
            _SelectView(12);
        }

        #endregion

        #region ExportXLS
        public MemoryStream GenerateReport_XLS(bool sendMail, int iYear, int iMonth)
        {
            ExportFile e = new ExportFile();
            System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
            string strMonthName = "";
            string strYear = "";
            string strYearAnt = "";
            string strSheetName = "";
            if (sendMail)
            {
                strMonthName = mfi.GetMonthName(iMonth).ToString();
                strYear = iYear.ToString();
                strYearAnt = (iYear - 1).ToString();
                strSheetName = strMonthName + strYear;
            }
            else
            {
                strMonthName = mfi.GetMonthName((int)ViewState["SelectedPeriod"]).ToString();
                strYear = Convert.ToInt32(ddlYear.SelectedValue).ToString();
                strYearAnt = (Convert.ToInt32(ddlYear.SelectedValue) - 1).ToString();
                strSheetName = strMonthName + strYear;
            }


            //Crear libro y agregar hoja
            XLWorkbook workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add(strSheetName);

            //Inicia carga de Info
            int iRow = 2;
            int iCell = 1;

            //addTitulo
            worksheet.Cell(iRow, iCell).Value = "Key Performance Indicator (KPI) Report";
            worksheet.Cell(iRow, iCell).Style.Font.FontColor = XLColor.Blue;
            worksheet.Cell(iRow, iCell).Style.Font.SetBold().Font.FontSize = 16;
            worksheet.Range(worksheet.Cell(iRow, iCell), worksheet.Cell(iRow, 8)).Merge();
            iRow++;
            worksheet.Cell(iRow, iCell).Value = "Location SW Mexico " + strYear + ". Report From: " + strMonthName + " " + strYear;
            worksheet.Cell(iRow, iCell).Style.Font.FontColor = XLColor.Blue;
            worksheet.Cell(iRow, iCell).Style.Font.SetBold().Font.FontSize = 16;
            worksheet.Range(worksheet.Cell(iRow, iCell), worksheet.Cell(iRow, 8)).Merge();
            iRow++;
            iRow++;

            //Add Headers
            #region addheaders
            iCell = 1;
            List<string> lstHeader = e.lstHeaders(strYear, strYearAnt);

            foreach (string i in lstHeader)
            {
                if (i.ToString() != "")
                {
                    worksheet.Cell(iRow, iCell).Value = i.ToString();
                    addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "Header", "", 10, XLColor.Black, null, true);
                    iCell++;
                }
            }

            #endregion

            //AddInfo
            //DataSet dsCategories = (DataSet)ViewState["Categories"];
            DataSet dsCategories;
            if (sendMail)
            {
                dsCategories = da2.ds_KPIReport2("KPICategories", null, null, Convert.ToInt32(iYear), "SWMX");
            }
            else
            {
                dsCategories = (DataSet)ViewState["Categories"];
            }


            int iSelectedYear = 0;
            if (sendMail)
            {
                iSelectedYear = iYear;
            }
            else
            {
                iSelectedYear = Convert.ToInt32(ddlYear.SelectedValue);
            }
            string strBusquedaSub = "KPISubCategories";
            string strBusquedaDet = "Detalle";
            iCell = 1;

            #region TBKPI
            foreach (DataRow dr in dsCategories.Tables[0].Rows)
            {
                iRow++;
                iCell = 1;
                //Category
                int idCategory = Convert.ToInt32(dr["IDCategory"].ToString());
                string strCategory = dr["Category"].ToString();

                DataSet ds = da.ds_KPIReport(strBusquedaSub, idCategory, null, iSelectedYear, strCompany);

                worksheet.Cell(iRow, iCell).Value = strCategory;
                addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "Category", "", 14, XLColor.White,
                    worksheet.Range(worksheet.Cell(iRow, iCell), worksheet.Cell(iRow, 18)), true);


                //Subcategoria
                foreach (DataRow drSub in ds.Tables[0].Rows)
                {
                    iRow++;
                    iCell = 1;
                    int idSubCategory = Convert.ToInt32(drSub["IDSubCategory"].ToString());
                    string strSubCateory = drSub["SubCategory"].ToString();

                    DataSet dsKPIDeatil = da.ds_KPIReportDtl(strBusquedaDet, idCategory, idSubCategory, iSelectedYear, strCompany);
                    worksheet.Cell(iRow, iCell).Value = strSubCateory;
                    addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "SubCategory", "", 12, XLColor.White,
                        worksheet.Range(worksheet.Cell(iRow, iCell), worksheet.Cell(iRow, 18)), true);

                    //Detalle  
                    #region Detalle
                    foreach (DataRow drDet in dsKPIDeatil.Tables[0].Rows)
                    {
                        iRow++;
                        iCell = 1;
                        string DataType = drDet["DataType"].ToString();
                        string IDKpi = drDet["ID"].ToString();
                        string UpdMethod = drDet["KPIUpdateMethod"].ToString();
                        string Name = drDet["Name"].ToString();

                        worksheet.Cell(iRow, iCell).Value = drDet["OrderColumn"].ToString();
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "Detail", "", 10, XLColor.Black,
                            worksheet.Range(worksheet.Cell(iRow, iCell), worksheet.Cell((iRow + 1), iCell)), true);
                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = Name;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "Detail", "", 10, XLColor.Black,
                            worksheet.Range(worksheet.Cell(iRow, iCell), worksheet.Cell((iRow + 1), iCell)), true);
                        iCell++;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), IDKpi, DataType, drDet["PrevYearResult"].ToString(), "");
                        iCell++;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), IDKpi, DataType, drDet["CurrentYearGoal"].ToString(), "");
                        iCell++;
                        if (IDKpi == "1" || IDKpi == "2" || IDKpi == "3")
                        {
                            worksheet.Cell(iRow, iCell).Value = "Prior";
                            addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "Detail", "", 10, XLColor.Black, null, true);
                        }
                        else
                        {
                            worksheet.Cell(iRow, iCell).Value = "Plan";
                            addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "Detail", "", 10, XLColor.Black, null, true);
                        }
                        //INFO
                        for (int i = 1; i <= 12; i++)
                        {
                            iCell++;
                            string ColName = "Planning" + i.ToString();
                            string ColNameUpdM = "UpdateMethod" + i.ToString();
                            string strUpdM = drDet[ColNameUpdM].ToString();

                            string strValue = drDet[ColName].ToString();
                            addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), IDKpi, DataType, strValue, "");
                        }
                        iCell++;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), IDKpi, DataType, drDet["PTgtYTD"].ToString(), "");
                        iRow++;
                        iCell = 5;
                        worksheet.Cell(iRow, iCell).Value = "Actual";
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "Detail", "", 10, XLColor.Black, null, true);
                        //Actual

                        for (int i = 1; i <= 12; i++)
                        {
                            iCell++;
                            string ColName = "Actual" + i.ToString();
                            string ColNameUpdM = "UpdateMethod" + i.ToString();
                            string ColNameRange = "KPIRange" + i.ToString();

                            string strValue = drDet[ColName].ToString();
                            string strUpdM = drDet[ColNameUpdM].ToString();
                            string strRange = drDet[ColNameRange].ToString();

                            addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), IDKpi, DataType, strValue, strRange);
                        }
                        iCell++;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), IDKpi, DataType, drDet["ATgtYTD"].ToString(), "");
                    }
                    #endregion
                }
            }
            #endregion

            iRow++;
            iRow++;

            TB_AdditionalComment(ref worksheet, ref iRow, sendMail, iYear, iMonth);
            iRow++;
            iRow++;

            TB_Comment(ref worksheet, ref iRow, sendMail, iYear, iMonth);
            iRow++;
            iRow++;

            TB_TopFive(ref worksheet, ref iRow, sendMail, iYear, iMonth);
            iRow++;
            iRow++;
            TB_Exp(ref worksheet, ref iRow, sendMail, iYear, iMonth);

            worksheet.Column(1).AdjustToContents();
            worksheet.Column(2).Width = 35;
            for (int i = 3; i <= 18; i++)
            {
                worksheet.Column(i).Width = i <= 5 ? 10 : 8.6;
            }
 
            if (sendMail)
            {
                // Flush the workbook to the Response.OutputStream
                MemoryStream memoryStream = new MemoryStream();
                
                workbook.SaveAs(memoryStream);
                memoryStream.Position = 0;
                return memoryStream;
            }
            else
            {
                HttpResponse httpResponse = Response;
                httpResponse.Clear();
                httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                httpResponse.AddHeader("content-disposition", "attachment;filename=\"" + "KPI_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx\"");

                // Flush the workbook to the Response.OutputStream
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    workbook.SaveAs(memoryStream);
                    memoryStream.WriteTo(httpResponse.OutputStream);
                    memoryStream.Close();
                }

                httpResponse.End();
            }
            return null;
        }

        private void TB_AdditionalComment(ref IXLWorksheet worksheet, ref int iRow, bool sendMail, int iYear, int iMonth)
        {
            System.Data.DataTable dtComment;
            if (sendMail)
            {
                DataSet ds = new DataSet();
                ds = da.ds_KPIReport("KPIAditionalComment", null, null, Convert.ToInt32(iYear), strCompany);

                dtComment = ds.Tables[0];
                dtComment = da.dt_dataSource(dtComment, iMonth);
            }
            else
            {
                dtComment = (System.Data.DataTable)ViewState["KPIAdditionalComment"];
            }
             
            ExportFile ex = new ExportFile();
            int iCell = 1;
            foreach (DataRow drComment in dtComment.Rows)
            {
                iRow++;
                iCell = 1;
                string strName = drComment["Description"].ToString();
                string good = drComment["Comments"].ToString();
                worksheet.Row(iRow).AdjustToContents();


                worksheet.Cell(iRow, iCell).Value = strName;
                addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "TBComment", "", 14, XLColor.White,
                worksheet.Range(worksheet.Cell(iRow, iCell), worksheet.Cell(iRow, 18)), true);
              
                iRow++;
                iCell = 1;
                addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), good, worksheet.Range(worksheet.Cell(iRow, iCell), worksheet.Cell(iRow, 18)), false);

                worksheet.Row(iRow).AdjustToContents();
            }
        }

        private void TB_Comment(ref IXLWorksheet worksheet, ref int iRow, bool sendMail, int iYear, int iMonth)
        {
            //System.Data.DataTable dtComment = (System.Data.DataTable)ViewState["KPIComment"];
            System.Data.DataTable dtComment;
            if (sendMail)
            {
                DataSet ds = new DataSet();
                ds = da.ds_KPIReport("KPIComment", null, null, Convert.ToInt32(iYear), strCompany);

                System.Data.DataTable dt = ds.Tables[0];


                System.Data.DataTable dt1 = new System.Data.DataTable();
                IEnumerable<DataRow> query =
                    (from x in dt.AsEnumerable()
                     where x.Field<int>("Period") == iMonth
                     orderby x.Field<string>("Name") ascending
                     select x);
                if (query.Count() > 0)
                {
                    dt1 = query.CopyToDataTable();
                }


                dtComment = dt1;
            }
            else
            {
                dtComment = (System.Data.DataTable)ViewState["KPIComment"];
            }

            ExportFile ex = new ExportFile();
            int iCell = 1;
            foreach (DataRow drComment in dtComment.Rows)
            {
                iRow++;
                iCell = 1;
                string strName = drComment["Name"].ToString();
                string good = drComment["CommentaryGood"].ToString();
                string bad = drComment["CommentaryBad"].ToString();
                worksheet.Row(iRow).AdjustToContents();

                worksheet.Cell(iRow, iCell).Value = strName;
                addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "TBComment", "", 14, XLColor.White,
                    worksheet.Range(worksheet.Cell(iRow, iCell), worksheet.Cell(iRow, 18)), false);
                iRow++;
                worksheet.Cell(iRow, iCell).Value = "Good";
                addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "TBComment", "", 12, XLColor.Black,
                     worksheet.Range(worksheet.Cell(iRow, iCell), worksheet.Cell(iRow, 8)), false);
              

                iCell = 9;
                worksheet.Cell(iRow, iCell).Value = "Bad";
                addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "TBComment", "", 12, XLColor.Black,
                     worksheet.Range(worksheet.Cell(iRow, iCell), worksheet.Cell(iRow, 18)), true);
                iRow++;
                iCell = 1;
                addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), good, worksheet.Range(worksheet.Cell(iRow, iCell), worksheet.Cell(iRow, 8)), false);

                iCell = 9;
                addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), bad, worksheet.Range(worksheet.Cell(iRow, iCell), worksheet.Cell(iRow, 18)), false);
                worksheet.Row(iRow).AdjustToContents();
            }
        }

        private void TB_Exp(ref IXLWorksheet worksheet, ref int iRow, bool sendMail, int iYear, int iMonth)
        {
            int iCell = 1;
            System.Data.DataTable dt;
            if (sendMail)
            {
                DataSet ds = new DataSet();
                ds = da.ds_KPIReport("rptExpDet", null, null, Convert.ToInt32(iYear), strCompany);
                dt = ds.Tables[0];
                dt = da.dt_dataSource(dt, iMonth);
            }
            else
            {
                dt = (System.Data.DataTable)ViewState["ExpPerformanceGaps"];
            }

            //GetInfo
            DataSet dsCategories;
            if (sendMail)
            {
                dsCategories = da2.ds_KPIReport2("KPICategories", null, null, Convert.ToInt32(iYear), "SWMX");
            }
            else
            {
                dsCategories = (DataSet)ViewState["Categories"];
            }
            ExportFile exc = new ExportFile();

            //GetInfo
            //DataSet dsCategories = (DataSet)ViewState["Categories"];

            foreach (DataRow dr in dsCategories.Tables[0].Rows)
            {
                //Category
                iRow++;
                iCell = 1;
                int idCategory = Convert.ToInt32(dr["IDCategory"].ToString());
                string strCategory = dr["Category"].ToString();
                DataSet ds;
                if (sendMail)
                {
                    ds = da.ds_KPIReport("KPISubCategories", idCategory, null, Convert.ToInt32(iYear), strCompany);
                }
                else
                {
                    ds = da.ds_KPIReport("KPISubCategories", idCategory, null, Convert.ToInt32(ddlYear.SelectedValue), strCompany);
                }
                worksheet.Cell(iRow, iCell).Value = strCategory;
                addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "TBComment", "", 16, XLColor.White, null, true);
                worksheet.Range(worksheet.Cell(iRow, iCell), worksheet.Cell(iRow, 18)).Merge();

                //Subcategoria
                foreach (DataRow drSub in ds.Tables[0].Rows)
                {
                    iRow++;
                    iCell = 1;
                    int idSubCategory = Convert.ToInt32(drSub["IDSubCategory"].ToString());
                    System.Data.DataTable dtSource = da.dt_dataSourceDet(dt, idCategory, idSubCategory);
                    string SubCategory = "  " + drSub["SubCategory"].ToString();
                    worksheet.Row(iRow).AdjustToContents();

                    worksheet.Cell(iRow, iCell).Value = SubCategory;
                    addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "TBComment", "", 14, XLColor.White, worksheet.Range(worksheet.Cell(iRow, iCell), worksheet.Cell(iRow, 18)), true);

                    iRow++;
                    worksheet.Cell(iRow, iCell).Value = "Explanation of Performance Gaps";
                    addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "TBComment", "", 14, XLColor.White, worksheet.Range(worksheet.Cell(iRow, iCell), worksheet.Cell(iRow, 8)), true);

                    iCell = 9;
                    worksheet.Cell(iRow, iCell).Value = "Activities to Close Gaps";
                    addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "TBComment", "", 14, XLColor.White, worksheet.Range(worksheet.Cell(iRow, iCell), worksheet.Cell(iRow, 18)), true);
              
                    if (dtSource.Rows.Count > 0)
                    {
                        foreach (DataRow drDet in dtSource.Rows)
                        {
                            iCell = 1;
                            iRow++;
                            string strName = drDet["Name"].ToString();
                            string Explan = drDet["ExplanationOfPerformanceGaps"].ToString();
                            string Act = drDet["ActivitiesToCloseGaps"].ToString();
                       

                            worksheet.Cell(iRow, iCell).Value = strName;
                            addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "TBCommentDtlHeader", "", 12, XLColor.Black, null, true);
                            worksheet.Range(worksheet.Cell(iRow, iCell), worksheet.Cell(iRow, 18)).Merge();

                            iRow++;
                            worksheet.Cell(iRow, iCell).Value = Explan;
                            addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "Detail", "", 10, XLColor.Black,
                                worksheet.Range(worksheet.Cell(iRow, iCell), worksheet.Cell(iRow, 8)), false);

                            iCell = 9;
                            worksheet.Cell(iRow, iCell).Value = Act;
                            addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "Detail", "", 10, XLColor.Black,
                                worksheet.Range(worksheet.Cell(iRow, iCell), worksheet.Cell(iRow, 18)), false);
                         
                            string strTextoAjustar = Explan.Length >= Act.Length ? Explan : Act;
                            int caracteresPorLinea = 100;
                            int lineasEstimadas = (int)Math.Ceiling((double)strTextoAjustar.Length / caracteresPorLinea);
                            double alturaPorLinea = 15; // Excel suele usar ~15 por línea
                            double alturaLinea = lineasEstimadas * alturaPorLinea;
                            worksheet.Row(iRow).Height = alturaLinea +10;
                        }
                    }
                    else
                    {
                        iRow++;
                    }
                }
            }
        }

        private void TB_TopFive(ref IXLWorksheet worksheet, ref int iRow, bool sendMail, int iYear, int iMonth)
        {
            int iCell = 1;
            //System.Data.DataTable dtTopFive = (System.Data.DataTable)ViewState["TopFiveDtl"];
            System.Data.DataTable dtTopFive;
            if (sendMail)
            {
                DataSet ds = new DataSet();
                ds = da.ds_KPIReport("TopFive", null, null, Convert.ToInt32(iYear), strCompany);

                System.Data.DataTable dt = ds.Tables[0];
                System.Data.DataTable dtl = ds.Tables[1];

                dtTopFive = da.dt_dataSource(dtl, iMonth);

            }
            else
            {
                dtTopFive = (System.Data.DataTable)ViewState["TopFiveDtl"];
            }
            ExportFile exc = new ExportFile();

            //Subcategoria
            worksheet.Cell(iRow, iCell).Value = "7.Top five lowest margin customers in the last quarter with significant volume - discussion on plans moving forward";
            addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "TBComment", "", 14, XLColor.White, null, true);
            worksheet.Range(worksheet.Cell(iRow, iCell), worksheet.Cell(iRow, 18)).Merge();
            iRow++;
            worksheet.Cell(iRow, iCell).Value = "Customer";
            addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "TBComment", "", 12, XLColor.Black,
                worksheet.Range(worksheet.Cell(iRow, iCell), worksheet.Cell(iRow, 2)), true);
            iCell = 3;
            worksheet.Cell(iRow, iCell).Value = "CM % ";
            addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "TBComment", "", 12, XLColor.Black, null, true);
            iCell++;
            worksheet.Cell(iRow, iCell).Value = "Tons";
            addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "TBComment", "", 12, XLColor.Black, null, true);
            iCell++;
            worksheet.Cell(iRow, iCell).Value = "Comments";
            addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "TBComment", "", 12, XLColor.Black,
            worksheet.Range(worksheet.Cell(iRow, iCell), worksheet.Cell(iRow, (18))), true);

            foreach (DataRow drSub in dtTopFive.Rows)
            {
                string customer = drSub["Customer"].ToString();
                string CM = drSub["CMPercentage"].ToString();
                string Tons = drSub["Tons"].ToString();
                string Comments = drSub["Comments"].ToString();
                iRow++;
                iCell = 1;
                addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", null, true);
                iCell++;
                addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), customer, null, true);
                iCell++;
                addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), CM, null, true);
                iCell++;
                addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), Tons, null, true);
                iCell++;
                addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), Comments, null, true);
                worksheet.Range(worksheet.Cell(iRow, iCell), worksheet.Cell(iRow, (iCell + 13))).Merge();
            }

        }

        #region adjustcell
        private void addjustCell(IXLCell iXLCell, IXLColumn iXLColumn, string iDKpi, string dataType, string v, string strRange)
        {
            ExportFile e = new ExportFile();
            if (iDKpi == "15")
            {
                if (dataType == "RangeValue" || dataType == "Percentage")
                {
                    string strPerc = "{0:0.00%}";
                    if (v != "")
                    {
                        double value = Convert.ToDouble(v);
                        string valor = e.str_ValueRange(value) + " (" + String.Format(strPerc, value) + ")";
                        iXLCell.Value = valor;
                        addjustCell(iXLCell, iXLColumn, "", "Detail", strRange, 10, XLColor.Black, null, true );
                    }
                }
            }
            else
            {
                iXLCell.Value = v;
                addjustCell(iXLCell, iXLColumn, dataType, "Detail", strRange, 10, XLColor.Black, null, true);

            }
        }

        private void addjustCell(IXLCell iXLCell, IXLColumn iXLColumn, string v, IXLRange range, bool adjustToContent)
        {
            iXLCell.Value = v;
            addjustCell(iXLCell, iXLColumn, "", "Detail", "", 10, XLColor.Black, range, adjustToContent);
        }

        private void addjustCell(IXLCell iXLCell, IXLColumn iXLColumn, string strFormat, string type, string strRange, int iFontZise, XLColor color, IXLRange range, bool AdjustToContents)
        {
            var XMLlightGreen = XLColor.FromArgb(144, 238, 144);

            if (strFormat == "%" || strFormat == "Percentage")
            {
                iXLCell.Style.NumberFormat.Format = "0.0%";
            }

            if (strFormat == "$")
            {
                iXLCell.Style.NumberFormat.Format = "$ #,##0.00";
            }

            if (strFormat == "Fixed Value")
            {
                iXLCell.Style.NumberFormat.Format = "#,##0.00";
            }
            if (AdjustToContents)
            {
                iXLColumn.AdjustToContents();

            }
            switch (type)
            {
                case "Header":
                    iXLCell.Style.Font.SetBold();
                    iXLCell.Style.Font.FontSize = iFontZise;
                    iXLCell.Style.Font.FontColor = color;
                    iXLCell.Style.Fill.BackgroundColor = XLColor.Gray;
                    iXLCell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    
                    break;

                case "Category":
                    iXLCell.Style.Font.SetBold();
                    iXLCell.Style.Font.SetBold().Font.FontSize = iFontZise;
                    iXLCell.Style.Font.FontColor = color;
                    iXLCell.Style.Fill.BackgroundColor = XLColor.Gray;
                    iXLCell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                 
                    if (range != null)
                    {
                        range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        range.Merge();
                    }
                    break;
                case "SubCategory":
                    iXLCell.Style.Font.SetBold();
                    iXLCell.Style.Font.SetBold().Font.FontSize = iFontZise;
                    iXLCell.Style.Font.FontColor = color;
                    iXLCell.Style.Fill.BackgroundColor = XLColor.LightGray;
                    iXLCell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    
                    if (range != null)
                    {
                        range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        range.Merge();
                    }
                    break;
                case "Detail":
                    iXLCell.Style.Font.FontSize = iFontZise;
                    iXLCell.Style.Font.FontColor = color;
                    iXLCell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                  
                    if (range != null)
                    {
                        range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        range.Merge();
                    }
                    switch (strRange)
                    {

                        case "AtOrAbove":
                            iXLCell.Style.Fill.BackgroundColor = XMLlightGreen;
                            break;

                        case "Below":
                            iXLCell.Style.Fill.BackgroundColor = XLColor.Red;
                            break;

                        case "Within":
                            iXLCell.Style.Fill.BackgroundColor = XLColor.Yellow;
                            break;

                        case "Preview":
                            //strbn.Append("<td style = \" background-color:#86C3F6;\" >" + str_DataFormat(DataType, idKPI, strValue, UpdateMethod, 0) + endcol);
                            iXLCell.Style.Fill.BackgroundColor = XLColor.LightCornflowerBlue;
                            break;
                        default:
                            iXLCell.Style.Fill.BackgroundColor = XLColor.White;
                            break;

                    }
                    iXLCell.Style.Alignment.WrapText = true;
                    iXLCell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Top;
                    break;
                case "TBComment":
                    iXLCell.Style.Font.FontSize = iFontZise;
                    iXLCell.Style.Font.FontColor = color;
                    iXLCell.Style.Fill.BackgroundColor = XLColor.Gray;
                    iXLCell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                
                    if (range != null)
                    {
                        range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        range.Merge();
                    }

                    // Habilitar el ajuste de texto (Wrap Text)
                    iXLCell.Style.Alignment.WrapText = true;

                    // Ajustar automáticamente la altura de la fila
                   
                    break;

                case "TBCommentDtl":
                    iXLCell.Style.Font.FontSize = iFontZise;
                    iXLCell.Style.Font.FontColor = color;
                    iXLCell.Style.Fill.BackgroundColor = XLColor.White;
                    iXLCell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                
                    if (range != null)
                    {
                        range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        range.Merge();
                        range.Style.Alignment.WrapText = true;
                    }
                    break;

                case "TBCommentDtlHeader":
                    iXLCell.Style.Font.SetBold();
                    iXLCell.Style.Font.FontSize = iFontZise;
                    iXLCell.Style.Font.FontColor = color;
                    iXLCell.Style.Fill.BackgroundColor = XLColor.White;
                    iXLCell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    if (range != null)
                    {
                        range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        range.Merge();
                        range.Style.Alignment.WrapText = true;
                    }
                    break;
            }
        }
        #endregion

        #endregion

        #region ExportPDF


        protected void GenerateReport_PDF()
        {
            MemoryStream memoryStream = _ms();
            byte[] bytes = memoryStream.ToArray();
            memoryStream.Close();
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=KPI_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf");
            Response.ContentType = "application/pdf";
            Response.Buffer = true;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(bytes);
            Response.End();
            Response.Close();
            memoryStream.Close();
        }

        private MemoryStream _msExcel()
        {
           
            ExportFile e = new ExportFile();
            System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
            string strMonthName = mfi.GetMonthName((int)ViewState["SelectedPeriod"]).ToString();
            string strYear = Convert.ToInt32(ddlYear.SelectedValue).ToString();
            string strYearAnt = (Convert.ToInt32(ddlYear.SelectedValue) - 1).ToString();
            string strSheetName = strMonthName + strYear;

            //Crear libro y agregar hoja
            XLWorkbook workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add(strSheetName);

            //Inicia carga de Info
            int iRow = 2;
            int iCell = 1;

            //addTitulo
            worksheet.Cell(iRow, iCell).Value = "Key Performance Indicator (KPI) Report";
            worksheet.Cell(iRow, iCell).Style.Font.FontColor = XLColor.Blue;
            worksheet.Cell(iRow, iCell).Style.Font.SetBold().Font.FontSize = 16;
            worksheet.Range(worksheet.Cell(iRow, iCell), worksheet.Cell(iRow, 8)).Merge();
            iRow++;
            worksheet.Cell(iRow, iCell).Value = "Location SW Mexico " + strYear + ". Report From: " + strMonthName + " " + strYear;
            worksheet.Cell(iRow, iCell).Style.Font.FontColor = XLColor.Blue;
            worksheet.Cell(iRow, iCell).Style.Font.SetBold().Font.FontSize = 16;
            worksheet.Range(worksheet.Cell(iRow, iCell), worksheet.Cell(iRow, 8)).Merge();
            iRow++;
            iRow++;

            //Add Headers
            #region addheaders
            iCell = 1;
            List<string> lstHeader = e.lstHeaders(strYear, strYearAnt);

            foreach (string i in lstHeader)
            {
                if (i.ToString() != "")
                {
                    worksheet.Cell(iRow, iCell).Value = i.ToString();
                    addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "Header", "", 10, XLColor.Black, null, true);
                    iCell++;
                }
            }

            #endregion

            //AddInfo
            DataSet dsCategories = (DataSet)ViewState["Categories"];
            int iSelectedYear = Convert.ToInt32(ddlYear.SelectedValue);
            string strBusquedaSub = "KPISubCategories";
            string strBusquedaDet = "Detalle";
            iCell = 1;

            #region TBKPI
            foreach (DataRow dr in dsCategories.Tables[0].Rows)
            {
                iRow++;
                iCell = 1;
                //Category
                int idCategory = Convert.ToInt32(dr["IDCategory"].ToString());
                string strCategory = dr["Category"].ToString();

                DataSet ds = da.ds_KPIReport(strBusquedaSub, idCategory, null, iSelectedYear, strCompany);

                worksheet.Cell(iRow, iCell).Value = strCategory;
                addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "Category", "", 14, XLColor.White,
                    worksheet.Range(worksheet.Cell(iRow, iCell), worksheet.Cell(iRow, 18)), true);


                //Subcategoria
                foreach (DataRow drSub in ds.Tables[0].Rows)
                {
                    iRow++;
                    iCell = 1;
                    int idSubCategory = Convert.ToInt32(drSub["IDSubCategory"].ToString());
                    string strSubCateory = drSub["SubCategory"].ToString();

                    DataSet dsKPIDeatil = da.ds_KPIReportDtl(strBusquedaDet, idCategory, idSubCategory, iSelectedYear, strCompany);
                    worksheet.Cell(iRow, iCell).Value = strSubCateory;
                    addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "SubCategory", "", 12, XLColor.White,
                        worksheet.Range(worksheet.Cell(iRow, iCell), worksheet.Cell(iRow, 18)), true);

                    //Detalle  
                    #region Detalle
                    foreach (DataRow drDet in dsKPIDeatil.Tables[0].Rows)
                    {
                        iRow++;
                        iCell = 1;
                        string DataType = drDet["DataType"].ToString();
                        string IDKpi = drDet["ID"].ToString();
                        string UpdMethod = drDet["KPIUpdateMethod"].ToString();
                        string Name = drDet["Name"].ToString();

                        worksheet.Cell(iRow, iCell).Value = drDet["OrderColumn"].ToString();
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "Detail", "", 10, XLColor.Black,
                            worksheet.Range(worksheet.Cell(iRow, iCell), worksheet.Cell((iRow + 1), iCell)), true);
                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = Name;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "Detail", "", 10, XLColor.Black,
                            worksheet.Range(worksheet.Cell(iRow, iCell), worksheet.Cell((iRow + 1), iCell)), true);
                        iCell++;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), IDKpi, DataType, drDet["PrevYearResult"].ToString(), "");
                        iCell++;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), IDKpi, DataType, drDet["CurrentYearGoal"].ToString(), "");
                        iCell++;
                        if (IDKpi == "1" || IDKpi == "2" || IDKpi == "3")
                        {
                            worksheet.Cell(iRow, iCell).Value = "Prior";
                            addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "Detail", "", 10, XLColor.Black, null, true);
                        }
                        else
                        {
                            worksheet.Cell(iRow, iCell).Value = "Plan";
                            addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "Detail", "", 10, XLColor.Black, null, true);
                        }
                        //INFO
                        for (int i = 1; i <= 12; i++)
                        {
                            iCell++;
                            string ColName = "Planning" + i.ToString();
                            string ColNameUpdM = "UpdateMethod" + i.ToString();
                            string strUpdM = drDet[ColNameUpdM].ToString();

                            string strValue = drDet[ColName].ToString();
                            addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), IDKpi, DataType, strValue, "");
                        }
                        iCell++;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), IDKpi, DataType, drDet["PTgtYTD"].ToString(), "");
                        iRow++;
                        iCell = 5;
                        worksheet.Cell(iRow, iCell).Value = "Actual";
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "Detail", "", 10, XLColor.Black, null, true);
                        //Actual

                        for (int i = 1; i <= 12; i++)
                        {
                            iCell++;
                            string ColName = "Actual" + i.ToString();
                            string ColNameUpdM = "UpdateMethod" + i.ToString();
                            string ColNameRange = "KPIRange" + i.ToString();

                            string strValue = drDet[ColName].ToString();
                            string strUpdM = drDet[ColNameUpdM].ToString();
                            string strRange = drDet[ColNameRange].ToString();

                            addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), IDKpi, DataType, strValue, strRange);
                        }
                        iCell++;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), IDKpi, DataType, drDet["ATgtYTD"].ToString(), "");
                    }
                    #endregion
                }
            }
            #endregion

            iRow++;
            iRow++;

            TB_AdditionalComment(ref worksheet, ref iRow, false, 0, 0);
            iRow++;
            iRow++;

            TB_Comment(ref worksheet, ref iRow, false, 0, 0);
            iRow++;
            iRow++;

            TB_TopFive(ref worksheet, ref iRow, false, 0, 0);
            iRow++;
            iRow++;
            TB_Exp(ref worksheet, ref iRow, false, 0, 0);

            worksheet.Column(1).AdjustToContents();
            worksheet.Column(2).Width = 35;
            for (int i = 3; i <= 18; i++)
            {
                worksheet.Column(i).Width = i <= 5 ? 10 : 8.6;
            }
            
          

            var stream = new MemoryStream();

            // Guardar el libro en el stream
            workbook.SaveAs(stream);

            // Regresar el stream al principio para que se pueda leer
            stream.Position = 0;

            return stream;
        }

        public MemoryStream _ms()
        {
            MemoryStream memoryStream = new MemoryStream();

            Document document = new Document(PageSize.A9, 10f, 10f, 10f, 0f);
            document.SetPageSize(PageSize.A3.Rotate());
            
            DataSet dsCategories = (DataSet)ViewState["Categories"];
            System.Data.DataTable dtAdditionalComment = (System.Data.DataTable)ViewState["KPIAdditionalComment"];
            System.Data.DataTable dtComment = (System.Data.DataTable)ViewState["KPIComment"];
            System.Data.DataTable dtTopFive = (System.Data.DataTable)ViewState["TopFiveDtl"];

            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
            PdfPTable table = null;
            document.Open();

            //Header
            table = TB_Header(writer, document);
            document.Add(table);

            //Datos
            table = TB_KPI(dsCategories);
            document.Add(table);
            document.NewPage();
            table = TB_Header(writer, document);
            document.Add(table);
            table = TB_Comment(dtComment);

            document.Add(table);
            table = TB_AdditionalComment(dtAdditionalComment);
           
            document.Add(table);
            table = TB_TopFive(dtTopFive);
            document.Add(table);
            table = TB_Exp(dsCategories);
            document.Add(table);
            document.Close();

            return memoryStream;
        }
 
        private PdfPTable TB_KPI(DataSet dsCategories)
        {
            PdfPTable table = null;
            PdfPCell cell = null;
            ExportFile export = new ExportFile();

            string strYear = Convert.ToInt32(ddlYear.SelectedValue).ToString();
            string strYearAnt = (Convert.ToInt32(ddlYear.SelectedValue) - 1).ToString();

            table = new PdfPTable(19);
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            table.WidthPercentage = 95;
            table.SetWidths(new float[] { 50f, 200f, 200f, 120f, 120f, 100f, 100f, 100f, 100f, 100f, 100f, 100f, 100f, 100f, 
                100f, 100f, 100f, 100f, 120f });
            table.SpacingBefore = 30f;

            //Headers
            List<string> lst = export.lstHeaders(strYear, strYearAnt);
            foreach (string i in lst)
            {
                cell = DataCell(i.ToString(), Element.ALIGN_LEFT, "Header", 10);
                table.AddCell(cell);
            }

            //Datos
            foreach (DataRow dr in dsCategories.Tables[0].Rows)
            {
                //Category
                int idCategory = Convert.ToInt32(dr["IDCategory"].ToString());
                string strCategory = dr["Category"].ToString();
                DataSet ds = da.ds_KPIReport("KPISubCategories", idCategory, null, Convert.ToInt32(ddlYear.SelectedValue), strCompany);

                cell = DataCell(strCategory, Element.ALIGN_LEFT, "Header", 14);
                cell.Colspan = 19;
                table.AddCell(cell);

                //Subcategoria
                foreach (DataRow drSub in ds.Tables[0].Rows)
                {
                    int idSubCategory = Convert.ToInt32(drSub["IDSubCategory"].ToString());
                    DataSet dsKPIDeatil = da.ds_KPIReportDtl("Detalle", idCategory, idSubCategory, Convert.ToInt32(ddlYear.SelectedValue), strCompany);

                    cell = DataCell(drSub["SubCategory"].ToString(), Element.ALIGN_LEFT, "Header", 12);
                    cell.Colspan = 19;
                    table.AddCell(cell);

                    //Detalle
                    foreach (DataRow drDet in dsKPIDeatil.Tables[0].Rows)
                    {
                        string IDKpi = drDet["ID"].ToString();
                        string strDataType = drDet["DataType"].ToString();
                        string UpdMethod = drDet["KPIUpdateMethod"].ToString();
                        string Name = drDet["Name"].ToString();

                        cell = DataCell(drDet["OrderColumn"].ToString(), Element.ALIGN_CENTER, "", 10);
                        cell.Rowspan = 2;
                        table.AddCell(cell);

                        cell = DataCell(Name, Element.ALIGN_CENTER, "", 10);
                        cell.Rowspan = 2;
                        cell.Colspan = 2;
                        table.AddCell(cell);

                        cell = DataCell(drDet["PrevYearResult"].ToString(), Element.ALIGN_CENTER, "", 10);
                        cell.Rowspan = 2;
                        table.AddCell(cell);

                        cell = DataCell(drDet["CurrentYearGoal"].ToString(), Element.ALIGN_CENTER, "", 10);
                        cell.Rowspan = 2;
                        table.AddCell(cell);

                        //Plan

                        if (IDKpi == "1" || IDKpi == "2" || IDKpi == "3")
                        {
                            cell = DataCell("Prior", Element.ALIGN_CENTER, "", 10);
                            table.AddCell(cell);
                        }
                        else
                        {
                            cell = DataCell("Plan", Element.ALIGN_CENTER, "", 10);
                            table.AddCell(cell);
                        }


                        for (int i = 1; i <= 12; i++)
                        {
                            string ColName = "Planning" + i.ToString();
                            string ColNameUpdMethod = "UpdateMethod" + i.ToString();
                            string strValueFormat = "";
                            string strValue = drDet[ColName].ToString();

                            strValueFormat = export.str_DataFormat(strDataType, IDKpi, strValue, drDet[ColNameUpdMethod].ToString(), 0);

                            cell = DataCell(strValueFormat, Element.ALIGN_CENTER, "", 10);
                            table.AddCell(cell);
                        }


                        string PTgtYTD = export.str_DataFormat(strDataType, IDKpi, drDet["PTgtYTD"].ToString(), drDet["PTgtYTD"].ToString(), 0);
                        cell = DataCell(PTgtYTD, Element.ALIGN_CENTER, "", 10);
                        table.AddCell(cell);

                        //Actual
                        cell = DataCell("Actual", Element.ALIGN_CENTER, "", 10);
                        table.AddCell(cell);

                        for (int i = 1; i <= 12; i++)
                        {
                            string ColName = "Actual" + i.ToString();
                            string ColNameUpdMethod = "UpdateMethod" + i.ToString();
                            string colNameRange = "KPIRange" + i.ToString();
                            string strValueFormat = "";
                            string strRange = drDet[colNameRange].ToString();
                            string strValue = drDet[ColName].ToString();

                            strValueFormat = export.str_DataFormat(strDataType, IDKpi, strValue, drDet[ColNameUpdMethod].ToString(), 0);

                            cell = DataCell(strValueFormat, Element.ALIGN_CENTER, strRange, 10);
                            table.AddCell(cell);
                        }

                        string ATgtYTD = export.str_DataFormat(strDataType, IDKpi, drDet["ATgtYTD"].ToString(), drDet["ATgtYTD"].ToString(), 0);
                        cell = DataCell(ATgtYTD, Element.ALIGN_CENTER, "", 10);
                        table.AddCell(cell);

                    }
                }

            }

            return table;
        }

        private PdfPTable TB_Header(PdfWriter writer, Document document)
        {
            PdfPTable table = null;
            PdfPCell cell = null;
            ExportFile ex = new ExportFile();

            //Header Table
            table = new PdfPTable(2);
            table.WidthPercentage = 95;
            table.SetWidths(new float[] { 500f, 500f });

            System.Globalization.DateTimeFormatInfo mfi = new
            System.Globalization.DateTimeFormatInfo();
            string strMonthName = mfi.GetMonthName((int)ViewState["SelectedPeriod"]).ToString();
            string strYear = Convert.ToInt32(ddlYear.SelectedValue).ToString();
            string strTitle= "Key Performance Indicator(KPI) Report\nLocation SWM México Report From: ";

            cell = ex.PhraseCell(new Phrase(strTitle + strMonthName + strYear, FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK)), Element.ALIGN_LEFT);
            cell.Rowspan = 2;
            cell.VerticalAlignment = Element.ALIGN_TOP;

            table.AddCell(cell);

            cell = ex.PhraseCell(new Phrase(" 2020 " + strMonthName, FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK)), Element.ALIGN_RIGHT);
            cell.VerticalAlignment = Element.ALIGN_TOP;

            cell = ex.PhraseCell(new Phrase("Print Date/Time: " + DateTime.Now.ToString(),
              FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)), Element.ALIGN_RIGHT);
            cell.VerticalAlignment = Element.ALIGN_TOP;

            table.AddCell(cell);
            //Separater Line
            DrawLine(writer, 25f, document.Top - 40f, document.PageSize.Width - 25f, document.Top - 40f);

            return table;
        }

        private PdfPTable TB_AdditionalComment(System.Data.DataTable dt)
        {
            PdfPTable table = null;
            PdfPCell cell = null;
            ExportFile export = new ExportFile();

            table = new PdfPTable(1);
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            table.WidthPercentage = 95;
            table.SetWidths(new float[] { 300f });
            table.SpacingBefore = 30f;

            foreach (DataRow dr in dt.Rows)
            {
                string strName = dr["Description"].ToString();
                string strComments = dr["Comments"].ToString();
                

                cell = DataCell(strName, Element.ALIGN_LEFT, "Header", 12);
               // cell.Colspan = 2;
                table.AddCell(cell);

                cell = DataCell(strComments, Element.ALIGN_LEFT, "", 10);
                table.AddCell(cell);

                

            }

            return table;
        }

        private PdfPTable TB_Comment(System.Data.DataTable dt)
        {
            PdfPTable table = null;
            PdfPCell cell = null;
            ExportFile export = new ExportFile();

            table = new PdfPTable(2);
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            table.WidthPercentage = 95;
            table.SetWidths(new float[] { 300f, 300f });
            table.SpacingBefore = 30f;

            foreach (DataRow dr in dt.Rows)
            {
                string strName = dr["Name"].ToString();
                string Good = dr["CommentaryGood"].ToString();
                string Bad = dr["CommentaryBad"].ToString();

                cell = DataCell(strName, Element.ALIGN_LEFT, "Header", 12);
                cell.Colspan = 2;
                table.AddCell(cell);

                cell = DataCell(Good, Element.ALIGN_LEFT, "", 10);
                table.AddCell(cell);

                cell = DataCell(Bad, Element.ALIGN_LEFT, "", 10);
                table.AddCell(cell);

            }

            return table;
        }

        private PdfPTable TB_TopFive(System.Data.DataTable dt)
        {
            PdfPTable table = null;
            PdfPCell cell = null;
            ExportFile export = new ExportFile();

            table = new PdfPTable(4);
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            table.WidthPercentage = 95;
            table.SetWidths(new float[] { 300f, 300f, 300f, 300f });
            table.SpacingBefore = 30f;
            cell = DataCell("E. Top five lowest margin customers in the last quarter with significant volume" 
                +" - discussion on plans moving forward", Element.ALIGN_LEFT, "Header", 14);
            cell.Colspan = 4;
            table.AddCell(cell);

            cell = DataCell("Customer", Element.ALIGN_LEFT, "Header", 12);
            table.AddCell(cell);

            cell = DataCell("CM %", Element.ALIGN_LEFT, "Header", 12);
            table.AddCell(cell);

            cell = DataCell("Tons", Element.ALIGN_LEFT, "Header", 12);
            table.AddCell(cell);

            cell = DataCell("Comments", Element.ALIGN_LEFT, "Header", 12);
            table.AddCell(cell);

            foreach (DataRow dr in dt.Rows)
            {
                cell = DataCell(dr["Customer"].ToString(), Element.ALIGN_LEFT,"", 10);
                table.AddCell(cell);

                cell = DataCell(dr["CMPercentage"].ToString(), Element.ALIGN_LEFT, "",10);
                table.AddCell(cell);

                cell = DataCell(dr["Tons"].ToString(), Element.ALIGN_LEFT, "",10);
                table.AddCell(cell);

                cell = DataCell(dr["Comments"].ToString(), Element.ALIGN_LEFT, "", 10);
                table.AddCell(cell);
            }

            return table;
        }

        private PdfPTable TB_Exp(DataSet dsCategories)
        {
            System.Data.DataTable dt = (System.Data.DataTable)ViewState["ExpPerformanceGaps"];
            PdfPTable table = null;
            PdfPCell cell = null;

            table = new PdfPTable(2);
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            table.WidthPercentage = 95;
            table.SetWidths(new float[] { 300f, 300f});
            table.SpacingBefore = 30f;

            //Datos
            int idCategory = 0;
            foreach (DataRow dr in dsCategories.Tables[0].Rows)
            {
                idCategory = Convert.ToInt32(dr["IDCategory"].ToString());
                DataSet ds = da.ds_KPIReport("KPISubCategories", idCategory, null, Convert.ToInt32(ddlYear.SelectedValue), strCompany);

                cell = DataCell(dr["Category"].ToString(), Element.ALIGN_LEFT, "Header", 14);
                cell.Colspan = 2;
                table.AddCell(cell);

                //Subcategoria
                foreach (DataRow drSub in ds.Tables[0].Rows)
                {

                    int idSubCategory = Convert.ToInt32(drSub["IDSubCategory"].ToString());
                    System.Data.DataTable dtSource = da.dt_dataSourceDet(dt, idCategory, idSubCategory);

                    cell = DataCell(drSub["SubCategory"].ToString(), Element.ALIGN_LEFT, "Header", 12);
                    cell.Colspan = 2;
                    table.AddCell(cell);

                    //Detalle
                    if (dtSource.Rows.Count > 0)
                    {
                        cell = DataCell("Explanation of Performance Gaps", Element.ALIGN_LEFT, "Header", 12);
                        table.AddCell(cell);

                        cell = DataCell("Activities to Close Gaps", Element.ALIGN_LEFT, "Header", 12);
                        cell.Colspan = 2;
                        table.AddCell(cell);

                        foreach (DataRow drDet in dtSource.Rows)
                        {
                            cell = DataCell(drDet["Name"].ToString(), Element.ALIGN_LEFT, "", 10);
                            cell.Colspan = 2;
                            table.AddCell(cell);

                            cell = DataCell(drDet["ExplanationOfPerformanceGaps"].ToString(), Element.ALIGN_LEFT, "", 10);
                            table.AddCell(cell);

                            cell = DataCell(drDet["ActivitiesToCloseGaps"].ToString(), Element.ALIGN_LEFT, "", 10);
                            table.AddCell(cell);
                        }
                    }
                    else
                    {
                        cell = DataCell(" - ", Element.ALIGN_LEFT, "", 12);
                        cell.Colspan = 2;
                        table.AddCell(cell);
                    }
                    
                }

            }

            return table;
        }

        private static void DrawLine(PdfWriter writer, float x1, float y1, float x2, float y2)
        {
            PdfContentByte contentByte = writer.DirectContent;
            BaseColor color = null;
            color = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#a6a6a6"));
            contentByte.SetColorStroke(color);
            contentByte.MoveTo(x1, y1);
            contentByte.LineTo(x2, y2);
            contentByte.Stroke();
        }

        private static PdfPCell DataCell(string Texto, int align, string strRange, int iFontSize)
        {
            //Format DataCells
            PdfPCell cell = null;
            BaseColor color = null;

            if (strRange == "Header")
            {
                cell = new PdfPCell(new Phrase(Texto, FontFactory.GetFont("Arial", iFontSize, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
            }
            else
            {
                cell = new PdfPCell(new Phrase(Texto, FontFactory.GetFont("Arial", iFontSize, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
            }

            color = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#a6a6a6"));

            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = Element.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 2f;
            cell.PaddingTop = 0f;
            cell.Border = 14;
            cell.BorderColor = color;
            BaseColor lightGreen = new BaseColor(144, 238, 144);
            switch (strRange)
            {
                case "AtOrAbove":
                    cell.BackgroundColor = lightGreen;
                    break;
                case "Below":
                    cell.BackgroundColor = BaseColor.RED;
                    break;
                case "Within":
                    cell.BackgroundColor = BaseColor.YELLOW;
                    break;
                case "Preview":
                    cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#86C3F6"));
                    break;
                case "Header":
                    cell.BackgroundColor = color;
                    cell.BorderColor = BaseColor.BLACK;
                    break;
                default:
                    cell.BackgroundColor = BaseColor.WHITE;
                    break;
            }
            return cell;
        }
        #endregion

        #region SendEmail
        protected void SendEmailReport_PDF(int iYear, int iMonth)
        {
            DataSet ds = new DataSet();
            ds = da2.ds_KPIReportEmailAddressGroup();
            System.Data.DataTable dt = ds.Tables[0];
            System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
            string[] EmailSettings = ConfigurationManager.AppSettings["EmailSettings"].Split(';');
            string[] EmailTo = dt.Rows[0]["AddressTo"].ToString().Split(',');
            string[] EmailCc = dt.Rows[0]["AddressCc"].ToString().Split(',');
            string dir = GetDirectoryBackUp("SeniorKPI");
            string fileName = "KPI_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
            string dirFileName = dir + fileName;
            string strfile = GenerateReport_PDFToMail(dirFileName);
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(EmailSettings[0]);
                foreach (string str in EmailTo)
                {
                    mail.To.Add(str);
                }
                foreach (string str in EmailCc)
                {
                    mail.CC.Add(str);
                }

                string MonthName = mfi.GetMonthName(iMonth).ToString();
                mail.Subject = "KPI’s – MEXICO – " + MonthName + " " + iYear.ToString();
                string strBody = "Please find attached KPI Report for MEXICO - " + MonthName + " " + iYear.ToString();
                mail.Body = strBody;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;

                SmtpClient client = new SmtpClient(EmailSettings[2], int.Parse(EmailSettings[3]));
                client.Port = int.Parse(EmailSettings[3]);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                NetworkCredential cred = new NetworkCredential(EmailSettings[0], EmailSettings[4]);
                client.Credentials = cred;
                System.Net.ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                mail.Attachments.Add(new Attachment(strfile));
                client.Send(mail);
                client.Dispose();
            }
            catch (Exception ex)
            {

                //showMessage("No se pudo complatar el envio del reportes");

            }

        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static string ObtenerCorreos()
        {
            DaKPIReport report = new DaKPIReport();
            return report.ObtenerCorreos();
        }
       

        #endregion
        #region Directorios
        private string GetBaseDir(string NotifType)
        {
            return @"C:\NotificationService\" + NotifType + @"\";
        }

        private string GetDirectory(string NotifType)
        {
            string directory = GetBaseDir(NotifType) + @"\Enviados";
            createDirectory(directory);
            directory = directory + @"\" + DateTime.Now.ToString("yyyy");
            createDirectory(directory);
            directory = directory + @"\" + DateTime.Now.ToString("MMMM");
            createDirectory(directory);
            directory = directory + @"\" + DateTime.Now.ToString("dd-MM-yyyy");
            directory = directory + @"\";
            createDirectory(directory);

            return directory;
        }

        private void createDirectory(string pdirectory)
        {
            if (!Directory.Exists(pdirectory))
            {
                Directory.CreateDirectory(pdirectory);
            }

        }

        public string GetDirectoryBackUp(string NotifType)
        {
            string directory = GetBaseDir(NotifType);
            createDirectory(directory);
            directory = directory + @"\";
            createDirectory(directory);

            return directory;
        }

        protected string GenerateReport_PDFToMail(string dir)
        {
            string path = string.Empty;
            path = dir;
            MemoryStream memoryStream = _ms();
            byte[] bytes = memoryStream.ToArray();
            bytes = memoryStream.ToArray();
            File.WriteAllBytes(path, bytes);

            return path;
        }

        protected string GenerateReport_XMLToMail(string dir)
        {
            string path = string.Empty;
            path = dir;
            MemoryStream memoryStream = _msExcel();
            byte[] bytes = memoryStream.ToArray();
            bytes = memoryStream.ToArray();
            File.WriteAllBytes(path, bytes);

            return path;
        }
        #endregion

        [WebMethod]
        
        public static string SendToEmail (string param)
        {
            try
            {
                string[] strParam = param.Split(',');
                string res = string.Empty;
                int iYear = int.Parse(strParam[0]);
                int iMonth = int.Parse(strParam[1]);
                bool confirm = false;
                confirm = strParam[2] == "true" ? true : false;
                if (confirm)
                {

                    EnvioCorreo envioCorreo = new EnvioCorreo();
                    envioCorreo.SendEmailReport_PDF(iYear, iMonth);
                    res = "1";
                    return res;
                }
                else {
                    res = "2";
                    return res;
                }
            }
            catch (Exception e) {
                throw e;
            }

        }

    }

    public class EnvioCorreo
    {

        //Eliminar este bloque de codigo
        public DataSet getMailsTesting()
        {
            // Crear un nuevo DataSet
            DataSet ds = new DataSet();

            // Crear una nueva DataTable con el nombre que desees, por ejemplo "MailInfo"
            System.Data.DataTable dt = new System.Data.DataTable("SW_ReportEmailAddresGroup");

            // Agregar las columnas requeridas
            dt.Columns.Add("ReportEmailAddresGroupID", typeof(string));
            dt.Columns.Add("Company", typeof(string));
            dt.Columns.Add("AddressTo", typeof(string));
            dt.Columns.Add("AddressCc", typeof(string));
            dt.Columns.Add("Report", typeof(string));

            // Crear una nueva fila
            DataRow row = dt.NewRow();
            row["ReportEmailAddresGroupID"] = "1";
            row["Company"] = "SWMX";
            row["AddressTo"] = "Christian.baez@xtatera.com";
            row["AddressCc"] = "blanca.hernandez@xtatera.com";
            row["Report"] = "KPIReport";

            // Agregar la fila a la tabla
            dt.Rows.Add(row);

            // Agregar la tabla al DataSet
            ds.Tables.Add(dt);

            // Retornar el DataSet
            return ds;
        }

        public void SendEmailReport_PDF(int iYear, int iMonth)
        {
            KPIReport kpi = new KPIReport();
            DaKPIReport2 da = new DaKPIReport2();
            DataSet ds = new DataSet();
            ds = da.ds_KPIReportEmailAddressGroup();
            //ds = getMailsTesting();
            System.Data.DataTable dt = ds.Tables[0];
            System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
            string[] EmailSettings = ConfigurationManager.AppSettings["EmailSettings"].Split(';');
            string[] EmailTo = dt.Rows[0]["AddressTo"].ToString().Split(',');
            string[] EmailCc = dt.Rows[0]["AddressCc"].ToString().Split(',');
            string dir = GetDirectoryBackUp("SeniorKPI");
            string fileName = "KPI_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
            string dirFileName = dir + fileName;
            string strfile = GenerateReport_PDFToMail(dirFileName, iYear, iMonth);
            string strfileXML = GenerateReport_PDFToMail(dirFileName, iYear, iMonth);
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(EmailSettings[0]);
                foreach (string str in EmailTo)
                {
                    mail.To.Add(str);
                }
                foreach (string str in EmailCc)
                {
                    mail.CC.Add(str);
                }

                string MonthName = mfi.GetMonthName(iMonth).ToString();
                mail.Subject = "KPI’s – MEXICO – " + MonthName + " " + iYear.ToString();
                string strBody = "Please find attached KPI Report for MEXICO - " + MonthName + " " + iYear.ToString();
                mail.Body = strBody;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;

                SmtpClient client = new SmtpClient(EmailSettings[2], int.Parse(EmailSettings[3]));
                client.Port = int.Parse(EmailSettings[3]);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                NetworkCredential cred = new NetworkCredential(EmailSettings[0], EmailSettings[4]);
                client.Credentials = cred;
                System.Net.ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;


                // Crear y agregar el Attachment desde el MemoryStream
                var attachment = new Attachment(kpi.GenerateReport_XLS(true, iYear, iMonth), "KPI’s – MEXICO – " + MonthName + " " + iYear.ToString() + ".xlsx");
                mail.Attachments.Add(attachment);

                mail.Attachments.Add(new Attachment(strfile));
                client.Send(mail);
                client.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;

            }

        }
        #region Directorios
        private string GetBaseDir(string NotifType)
        {
            return @"C:\NotificationService\" + NotifType + @"\";
        }

        private string GetDirectory(string NotifType)
        {
            string directory = GetBaseDir(NotifType) + @"\Enviados";
            createDirectory(directory);
            directory = directory + @"\" + DateTime.Now.ToString("yyyy");
            createDirectory(directory);
            directory = directory + @"\" + DateTime.Now.ToString("MMMM");
            createDirectory(directory);
            directory = directory + @"\" + DateTime.Now.ToString("dd-MM-yyyy");
            directory = directory + @"\";
            createDirectory(directory);

            return directory;
        }

        private void createDirectory(string pdirectory)
        {
            if (!Directory.Exists(pdirectory))
            {
                Directory.CreateDirectory(pdirectory);
            }

        }

        public string GetDirectoryBackUp(string NotifType)
        {
            string directory = GetBaseDir(NotifType);
            createDirectory(directory);
            directory = directory + @"\";
            createDirectory(directory);

            return directory;
        }

        protected string GenerateReport_PDFToMail(string dir,int iYear, int iMonth)
        {
            string path = string.Empty;
            path = dir;
            CreateKPIPDF2 report = new CreateKPIPDF2();
            MemoryStream memoryStream = report._ms2(iYear, iMonth, "SWMX");
            byte[] bytes = memoryStream.ToArray();
            bytes = memoryStream.ToArray();
            File.WriteAllBytes(path, bytes);

            return path;
        }
        protected string GenerateReport_XMLToMail(string dir, int iYear, int iMonth)
        {
            string path = string.Empty;
            path = dir;
            CreateKPIPDF2 report = new CreateKPIPDF2();
            MemoryStream memoryStream = report._ms2(iYear, iMonth, "SWMX");
            byte[] bytes = memoryStream.ToArray();
            bytes = memoryStream.ToArray();
            File.WriteAllBytes(path, bytes);

            return path;
        }
        #endregion

    }

}
