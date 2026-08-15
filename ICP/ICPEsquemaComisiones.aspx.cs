using ICPDataAccess;
using ICPGraphs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ClosedXML.Excel;

namespace ICP
{
    public partial class ICPEsquemaComisiones : System.Web.UI.Page
    {
        DaICPSalesCommissions da = new DaICPSalesCommissions();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblVersion.Text = "Version 1.3";
                LoadMonth();
                _YearsKPI(ddlYear);
                _LoadInfo();
               

            }
        }

        private void LoadMonth()
        {
            List<string> nombreMes = DateTimeFormatInfo.CurrentInfo.MonthNames.Take(12).ToList();
            var listaMesesSeleccionados = nombreMes.Select(m => new
            {
                Id = nombreMes.IndexOf(m) + 1,
                Name = m
            });

            foreach (var mes in listaMesesSeleccionados)
            {
                this.ddlMonth.Items.Add(new ListItem(mes.Name, mes.Id.ToString()));
            }

            if (DateTime.Now.Month == 1)
            {
                ddlMonth.SelectedValue = "12";
            }
            else {
                ddlMonth.SelectedValue = Convert.ToString((DateTime.Now.Month) - 1);
            }
        }

       
        private List<int> _lstFiscalYear()
        {
            return Enumerable.Range(2019, 10).ToList();
        }

        public void _YearsKPI(DropDownList ddlY)
        {
            //                      Cargar Lista de Años para seleccionar el Period anual de metas. 
            ddlY.DataSource = _lstFiscalYear();
            ddlY.Text = Convert.ToString(DateTime.Today.Year);
            ddlY.DataBind();
            if (DateTime.Now.Month == 1)
            {
                ddlY.SelectedValue = Convert.ToString((DateTime.Now.Year) - 1);
            }
        }

        private void getDataSet()
        {
            WindowsPrincipal User;
            User = new WindowsPrincipal(Request.LogonUserIdentity);

            //AllowUsr UserInfo = new AllowUsr();
            //Puesto = "Ingeniero en Sistemas";
            //lastConnection = "03 Octubre 2016";

            //UserInfo = AllowedUsers(User.Identity.Name.ToString());
            string DomainUser = User.Identity.Name.ToString();
            //UserName = Environment.UserDomainName;
            Session["UserName"] = DomainUser;

            string UserName = (string)Session["UserName"];
            string[] items = null;
            items = UserName.Split('\\');
            string strDomainUser = items[items.Length - 1];
            int iYear = Convert.ToInt32(ddlYear.SelectedValue);
            int iMonth = Convert.ToInt32(ddlMonth.SelectedValue);

            List<OutsideSalesRep> lst = new List<OutsideSalesRep>();
            
            lst = da.lstOSR(iYear, iMonth, strDomainUser, "SWMX");
            ViewState["SelectedPeriod"] = Convert.ToInt32(ddlMonth.SelectedValue);
            ViewState["info"] = lst;
        }

        private void _LoadInfo()
        {
            getDataSet();
            List<OutsideSalesRep> lst = new List<OutsideSalesRep>();
            lst = (List<OutsideSalesRep>)ViewState["info"];
            if (lst.Count > 0)
  
            {
                Table1.Visible = true;
                lblAccess.Visible = false;
                rptOSR.DataSource = lst;
                rptOSR.DataBind();
                ExportFile format = new ExportFile();

                lblTotalPaymentAmountMXN.Text = format.str_DataFormat("$", lst.Sum(item => item.PaymentAmountMXN), false);
                lblTotalPaymentAmountUSD.Text = format.str_DataFormat("$", lst.Sum(item => item.PaymentAmountUSD), false);
                lblTotalVolumenMT.Text = format.str_DataFormat("", lst.Sum(item => item.VolumenMT), false);
                lblTotalVolumenMTPaid.Text = format.str_DataFormat("", lst.Sum(item => item.VolumenMTPaid), false);

            }
            else {

                Table1.Visible = false;
                lblAccess.Visible = true;
            }



        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            _LoadInfo();
        }

        protected void btnExportXLS_Click(object sender, EventArgs e)
        {
            GenerateReport_XLS();
        }

        protected void btnExporPDF_Click(object sender, EventArgs e)
        {

        }

        protected void rptOSR_ItemDataBound(object sender, RepeaterItemEventArgs e)
        { 
            //                                             Encontrar los controles.
            Label lblSalesRepCode = (Label)e.Item.FindControl("lblSalesRepCode");
            Repeater rptCustomerGroup = (Repeater)e.Item.FindControl("rptCustomerGroup");

            Label lblPaymentAmountMXN = (Label)e.Item.FindControl("lblPaymentAmountMXN");
            Label lblPaymentAmountUSD = (Label)e.Item.FindControl("lblPaymentAmountUSD");
            Label lblVolumenMT = (Label)e.Item.FindControl("lblVolumenMT");
            Label lblVolumenMTPaid = (Label)e.Item.FindControl("lblVolumenMTPaid");
            Label lblTotalPer = (Label)e.Item.FindControl("lblTotalPer");
            Label lblFactorComision = (Label)e.Item.FindControl("lblFactorComision");
            Label lblForecastCumplimientoPer = (Label)e.Item.FindControl("lblForecastCumplimientoPer");
            Label lblForecastComisionEarnedPer = (Label)e.Item.FindControl("lblForecastComisionEarnedPer");
            Label lblTotalMarginMXN = (Label)e.Item.FindControl("lblTotalMarginMXN");
            Label lblTotalMarginUSD = (Label)e.Item.FindControl("lblTotalMarginUSD");
            Label lblMargenPerMXN = (Label)e.Item.FindControl("lblMargenPerMXN");
            Label lblMargenPerUSD = (Label)e.Item.FindControl("lblMargenPerUSD");
            Label lblMargenComisionEarnedPer = (Label)e.Item.FindControl("lblMargenComisionEarnedPer");
            Label lblInventarioComisionEarnedPer = (Label)e.Item.FindControl("lblInventarioComisionEarnedPer");
            Label lblFactorTotal = (Label)e.Item.FindControl("lblFactorTotal");

            Label lblForecastGoalMT = (Label)e.Item.FindControl("lblForecastGoalMT");
            Label lblMontoBrutoComision = (Label)e.Item.FindControl("lblMontoBrutoComision");
            Label lblComisionAPagar = (Label)e.Item.FindControl("lblComisionAPagar");

            //                                             Declarar variables
            DataSet ds = new DataSet();
            string salesRepCode = "";

            try
            {
                if (lblSalesRepCode != null)
                {
                    salesRepCode = lblSalesRepCode.Text;
                    List<OutsideSalesRep> lst = (List<OutsideSalesRep>)ViewState["info"];

                    //ds = da.ds_KPIReport("KPISubCategories", idCategory, null, Convert.ToInt32(ddlYear.SelectedValue));
                    //                                     Ligamos el Data Source con el control
                    OutsideSalesRep osr = (from c in lst where c.SalesRepCode == salesRepCode select c).FirstOrDefault();

                    rptCustomerGroup.DataSource = osr.lstCorporate;
                    rptCustomerGroup.DataBind();
                    ExportFile format = new ExportFile();

                    lblPaymentAmountMXN.Text = format.str_DataFormat("$", Convert.ToDouble(lblPaymentAmountMXN.Text), false);
                    lblPaymentAmountUSD.Text = format.str_DataFormat("$", Convert.ToDouble(lblPaymentAmountUSD.Text), false);
                    lblVolumenMT.Text = format.str_DataFormat("", Convert.ToDouble(lblVolumenMT.Text), false);
                    lblVolumenMTPaid.Text = format.str_DataFormat("", Convert.ToDouble(lblVolumenMTPaid.Text), false);
                    lblTotalPer.Text = format.str_DataFormat("%", Convert.ToDouble(lblTotalPer.Text), false);

                    lblTotalMarginMXN.Text = format.str_DataFormat("$", Convert.ToDouble(lblTotalMarginMXN.Text), false);
                    lblTotalMarginUSD.Text = format.str_DataFormat("$", Convert.ToDouble(lblTotalMarginUSD.Text), false);

                    lblMargenPerMXN.Text = format.str_DataFormat("%", Convert.ToDouble(lblMargenPerMXN.Text), false);
                    lblMargenPerUSD.Text = format.str_DataFormat("%", Convert.ToDouble(lblMargenPerUSD.Text), false);
                    lblMargenComisionEarnedPer.Text = format.str_DataFormat("%", Convert.ToDouble(lblMargenComisionEarnedPer.Text), false);
                    lblInventarioComisionEarnedPer.Text = format.str_DataFormat("%", Convert.ToDouble(lblInventarioComisionEarnedPer.Text), false);
                    lblFactorTotal.Text = format.str_DataFormat("%", Convert.ToDouble(lblFactorTotal.Text), false);
                    lblForecastCumplimientoPer.Text = format.str_DataFormat("%", Convert.ToDouble(lblForecastCumplimientoPer.Text), false);
                    lblForecastGoalMT.Text = format.str_DataFormat("", Convert.ToDouble(lblForecastGoalMT.Text), false);
                    lblForecastComisionEarnedPer.Text = format.str_DataFormat("%", Convert.ToDouble(lblForecastComisionEarnedPer.Text), false);
                    lblMontoBrutoComision.Text = format.str_DataFormat("$", Convert.ToDouble(lblMontoBrutoComision.Text), false);
                    lblComisionAPagar.Text = format.str_DataFormat("$", Convert.ToDouble(lblComisionAPagar.Text), false);
                }

            }
            catch (Exception ex)
            {
                //showMessage(ex.Message);
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        protected void rptCustomerGroup_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Label lblPaymentAmountMXN = (Label)e.Item.FindControl("lblPaymentAmountMXN");
            Label lblSalesRepCode = (Label)e.Item.FindControl("lblSalesRepCode");
            
            Label lblCorporateID = (Label)e.Item.FindControl("lblCorporateID");
            Label lblPaymentAmountUSD = (Label)e.Item.FindControl("lblPaymentAmountUSD");
            Label lblVolumenMT = (Label)e.Item.FindControl("lblVolumenMT");
            Label lblTotalPer = (Label)e.Item.FindControl("lblTotalPer");
            Label lblFactorComision = (Label)e.Item.FindControl("lblFactorComision");
            Label lblMontoBrutoComision = (Label)e.Item.FindControl("lblMontoBrutoComision");
            Label lblForecastGoalMT = (Label)e.Item.FindControl("lblForecastGoalMT");
            Label lblForecastCumplimientoPer = (Label)e.Item.FindControl("lblForecastCumplimientoPer");

            Label lblTotalMarginMXN = (Label)e.Item.FindControl("lblTotalMarginMXN");
            Label lblTotalMarginUSD = (Label)e.Item.FindControl("lblTotalMarginUSD");


            Label lblMargenPerMXN = (Label)e.Item.FindControl("lblMargenPerMXN");
            Label lblMargenPerUSD = (Label)e.Item.FindControl("lblMargenPerUSD");
            HtmlControl tt = (HtmlControl)e.Item.FindControl("rowGroup");
            Repeater rpt = (Repeater)e.Item.FindControl("rptCorporate");
            try
            {
                if (lblTotalPer != null)
                {

                    ExportFile format = new ExportFile();
                    if (lblCorporateID  != null)
                    {

                        List<OutsideSalesRep> lst = (List<OutsideSalesRep>)ViewState["info"];
                        OutsideSalesRep osr = (from c in lst where c.SalesRepCode == lblSalesRepCode.Text  select c).FirstOrDefault();
                        CorporateID_ CorporateID = (from c in osr.lstCorporate
                                                          where c.CorporateID == lblCorporateID.Text select c).FirstOrDefault();
                        rpt.DataSource = CorporateID.lstCustomer;
                        rpt.DataBind();
                        if (lblCorporateID.Text == "")
                        {
                            tt.Attributes["class"] = "hide";
                        }


                    }

                    lblPaymentAmountMXN.Text = format.str_DataFormat("$", Convert.ToDouble(lblPaymentAmountMXN.Text), false);
                    lblPaymentAmountUSD.Text = format.str_DataFormat("$", Convert.ToDouble(lblPaymentAmountUSD.Text), false);
                    lblVolumenMT.Text = format.str_DataFormat("", Convert.ToDouble(lblVolumenMT.Text), false);
                    lblTotalPer.Text = format.str_DataFormat("%", Convert.ToDouble(lblTotalPer.Text), false);
                    
                    lblMontoBrutoComision.Text = format.str_DataFormat("$", Convert.ToDouble(lblMontoBrutoComision.Text), false);
                    lblForecastGoalMT.Text = format.str_DataFormat("", Convert.ToDouble(lblForecastGoalMT.Text), false);
                    lblForecastCumplimientoPer.Text = format.str_DataFormat("%", Convert.ToDouble(lblForecastCumplimientoPer.Text), false);

                    lblTotalMarginMXN.Text = format.str_DataFormat("$", Convert.ToDouble(lblTotalMarginMXN.Text), false);
                    lblTotalMarginUSD.Text = format.str_DataFormat("$", Convert.ToDouble(lblTotalMarginUSD.Text), false);


                    lblMargenPerMXN.Text = format.str_DataFormat("%", Convert.ToDouble(lblMargenPerMXN.Text), false);
                    lblMargenPerUSD.Text = format.str_DataFormat("%", Convert.ToDouble(lblMargenPerUSD.Text), false);
                }
            }
            catch (Exception ex) { }

        }

        protected void rptCorporate_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Label lblPaymentAmountMXN = (Label)e.Item.FindControl("lblPaymentAmountMXN");
            Label lblSalesRepCode = (Label)e.Item.FindControl("lblSalesRepCode");
            Label lblCustomerName = (Label)e.Item.FindControl("lblSalesRepCode");

            Label lblCorporateID = (Label)e.Item.FindControl("lblCorporateID");
            Label lblPaymentAmountUSD = (Label)e.Item.FindControl("lblPaymentAmountUSD");
            Label lblVolumenMT = (Label)e.Item.FindControl("lblVolumenMT");
            Label lblVolumenMTPaid = (Label)e.Item.FindControl("lblVolumenMTPaid");
            Label lblTotalPer = (Label)e.Item.FindControl("lblTotalPer");
            Label lblFactorComision = (Label)e.Item.FindControl("lblFactorComision");
            Label lblMontoBrutoComision = (Label)e.Item.FindControl("lblMontoBrutoComision");
            Label lblForecastGoalMT = (Label)e.Item.FindControl("lblForecastGoalMT");
            Label lblForecastCumplimientoPer = (Label)e.Item.FindControl("lblForecastCumplimientoPer");

            Label lblTotalMarginMXN = (Label)e.Item.FindControl("lblTotalMarginMXN");
            Label lblTotalMarginUSD = (Label)e.Item.FindControl("lblTotalMarginUSD");


            Label lblMargenPerMXN = (Label)e.Item.FindControl("lblMargenPerMXN");
            Label lblMargenPerUSD = (Label)e.Item.FindControl("lblMargenPerUSD");
           
           
            try
            {
                if (lblTotalPer != null)
                {

                    ExportFile format = new ExportFile();
                    

                    lblPaymentAmountMXN.Text = format.str_DataFormat("$", Convert.ToDouble(lblPaymentAmountMXN.Text), false);
                    lblPaymentAmountUSD.Text = format.str_DataFormat("$", Convert.ToDouble(lblPaymentAmountUSD.Text), false);
                    lblVolumenMT.Text = format.str_DataFormat("", Convert.ToDouble(lblVolumenMT.Text), false);
                    lblVolumenMTPaid.Text = format.str_DataFormat("", Convert.ToDouble(lblVolumenMTPaid.Text), false);
                    lblTotalPer.Text = format.str_DataFormat("%", Convert.ToDouble(lblTotalPer.Text), false);
                    lblFactorComision.Text = format.str_DataFormat("%", Convert.ToDouble(lblFactorComision.Text), true);
                    lblMontoBrutoComision.Text = format.str_DataFormat("$", Convert.ToDouble(lblMontoBrutoComision.Text), false);
                    lblForecastGoalMT.Text = format.str_DataFormat("", Convert.ToDouble(lblForecastGoalMT.Text), false);
                    lblForecastCumplimientoPer.Text = format.str_DataFormat("%", Convert.ToDouble(lblForecastCumplimientoPer.Text), false);

                    lblTotalMarginMXN.Text = format.str_DataFormat("$", Convert.ToDouble(lblTotalMarginMXN.Text), false);
                    lblTotalMarginUSD.Text = format.str_DataFormat("$", Convert.ToDouble(lblTotalMarginUSD.Text), false);

                    lblMargenPerMXN.Text = format.str_DataFormat("%", Convert.ToDouble(lblMargenPerMXN.Text), false);
                    lblMargenPerUSD.Text = format.str_DataFormat("%", Convert.ToDouble(lblMargenPerUSD.Text), false);
                }
            }
            catch (Exception ex) { }
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #region ExportXLS
        private void GenerateReport_XLS()
        {
            ExportFile e = new ExportFile();
            System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
            string strMonthName = mfi.GetMonthName((int)ViewState["SelectedPeriod"]).ToString();
            string strYear = Convert.ToInt32(ddlYear.SelectedValue).ToString();
            string strSheetName = strMonthName + strYear;

            //Crear libro y agregar hoja
            XLWorkbook workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add(strSheetName);

            //Inicia carga de Info
            int iRow = 2;
            int iCell = 1;

            //addTitulo
            worksheet.Cell(iRow, iCell).Value = "Reporte de Cálculo de Comisiones de Ventas";
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

            //Add totales
            #region addtotales
            worksheet.Cell(iRow, 1).Value = "Total General:";
            worksheet.Range(worksheet.Cell(iRow, 1), worksheet.Cell(iRow,4)).Merge();
            worksheet.Cell(iRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

            worksheet.Cell(iRow, 5).Value = lblTotalPaymentAmountMXN.Text == "" ? 0 : Convert.ToDecimal(lblTotalPaymentAmountMXN.Text.Trim(new Char[] { '$', ','}));
            worksheet.Cell(iRow, 5).Style.NumberFormat.Format = "$ #,##0.00";

            worksheet.Cell(iRow, 6).Value = lblTotalPaymentAmountUSD.Text == "" ? 0 : Convert.ToDecimal(lblTotalPaymentAmountUSD.Text.Trim(new Char[] { '$', ',' }));
            worksheet.Cell(iRow, 6).Style.NumberFormat.Format = "$ #,##0.00";

            worksheet.Cell(iRow, 7).Value = lblTotalVolumenMT.Text == "" ? 0 : Convert.ToDecimal(lblTotalVolumenMT.Text.Trim(new Char[] { '$', ',' }));
            worksheet.Cell(iRow, 7).Style.NumberFormat.Format = "#,##0.00";

            worksheet.Cell(iRow, 8).Value = lblTotalVolumenMTPaid.Text == "" ? 0 : Convert.ToDecimal(lblTotalVolumenMTPaid.Text.Trim(new Char[] { '$', ',' }));
            worksheet.Cell(iRow, 8).Style.NumberFormat.Format = "#,##0.00";

            worksheet.Cell(iRow, 12).Value = "Forecast";
            worksheet.Cell(iRow, 12).Style.Font.SetBold();
            worksheet.Cell(iRow, 12).Style.Fill.BackgroundColor = XLColor.Orange;
            worksheet.Range(worksheet.Cell(iRow, 12), worksheet.Cell(iRow, 14)).Merge();

            worksheet.Cell(iRow, 15).Value = "Margen";
            worksheet.Cell(iRow, 15).Style.Font.SetBold();
            worksheet.Cell(iRow, 15).Style.Fill.BackgroundColor = XLColor.BabyBlueEyes;
            worksheet.Range(worksheet.Cell(iRow, 15), worksheet.Cell(iRow,19)).Merge();

            worksheet.Cell(iRow, 20).Value = "Inventario";
            worksheet.Cell(iRow, 20).Style.Font.SetBold();
            worksheet.Cell(iRow, 20).Style.Fill.BackgroundColor = XLColor.Yellow;

            worksheet.Cell(iRow, 21).Value = "";
            worksheet.Cell(iRow, 21).Style.Font.SetBold();
            worksheet.Cell(iRow, 21).Style.Fill.BackgroundColor = XLColor.Red;
            worksheet.Range(worksheet.Cell(iRow, 21), worksheet.Cell(iRow, 22)).Merge();
            #endregion
            iRow++;

            //Add Headers
            #region addheaders
            iCell = 1;
            List<string> lstHeader = e.lstHeadersCommision();

            foreach (string i in lstHeader)
            {
                if (i.ToString() != "")
                {
                    worksheet.Cell(iRow, iCell).Value = i.ToString();
                    addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "Header");
                    iCell++;
                }
            }

            #region FixWidth
            worksheet.Cell("G6").Style.Fill.BackgroundColor = XLColor.Yellow;
            worksheet.Column(1).Width = 4.14;
            worksheet.Column(2).Width = 21.14;
            worksheet.Column(3).Width = 8.57;
            worksheet.Column(4).Width = 7.57;
            worksheet.Column(5).Width = 16;
            worksheet.Column(6).Width = 14.57;
            worksheet.Column(7).Width = 11;
            worksheet.Column(8).Width = 10.14;
            worksheet.Column(9).Width = 7.43;
            worksheet.Column(10).Width = 7.57;
            worksheet.Column(11).Width = 11.57;
            worksheet.Column(12).Width = 10.14;
            worksheet.Column(13).Width = 9.14;
            worksheet.Column(14).Width = 7.43;
            worksheet.Column(15).Width = 14.57;
            worksheet.Column(16).Width = 12.71;
            worksheet.Column(17).Width = 6.29;
            worksheet.Column(18).Width = 6.29;
            worksheet.Column(19).Width = 6.29;
            worksheet.Column(20).Width = 8.43;
            worksheet.Column(21).Width = 9.43;
            worksheet.Column(22).Width = 13.29;
            #endregion


            #endregion

            //add sales rep info
            //GetInfo 
            List<OutsideSalesRep> lst = (List<OutsideSalesRep>)ViewState["info"];

            foreach (OutsideSalesRep osr in lst)
            {
                iRow++;
                iCell = 1;
                #region OutsideSalesRep
                worksheet.Cell(iRow, iCell).Value = osr.SalesRep;
                worksheet.Cell(iRow, iCell).Style.Font.SetBold();
                worksheet.Cell(iRow, iCell).Style.Font.SetBold().Font.FontSize = 14;
                worksheet.Cell(iRow, iCell).Style.Font.FontColor = XLColor.White;
                worksheet.Cell(iRow, iCell).Style.Fill.BackgroundColor = XLColor.Gray;
                worksheet.Range(worksheet.Cell(iRow, iCell), worksheet.Cell(iRow, iCell + 3)).Merge();
                worksheet.Range(worksheet.Cell(iRow, iCell), worksheet.Cell(iRow, iCell + 3)).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                //worksheet.Column(iCell).AdjustToContents();

                iCell =  5;
                worksheet.Cell(iRow, iCell).Value = osr.PaymentAmountMXN;
                addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "$", "SalesRep");

                iCell++;
                worksheet.Cell(iRow, iCell).Value = osr.PaymentAmountUSD;
                addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "$", "SalesRep");

                iCell++;
                worksheet.Cell(iRow, iCell).Value = osr.VolumenMT;
                addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), ",", "SalesRep");
                //worksheet.Column(iCell).AdjustToContents();

                iCell++;
                worksheet.Cell(iRow, iCell).Value = osr.VolumenMTPaid;
                addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), ",", "SalesRep");
                //worksheet.Column(iCell).AdjustToContents();

                iCell++;
                worksheet.Cell(iRow, iCell).Value = osr.TotalPer;
                addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "%", "SalesRep");
                //worksheet.Column(iCell).AdjustToContents();
 
                iCell++;
                worksheet.Cell(iRow, iCell).Value = "";
                addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "SalesRep");

                iCell++;
                worksheet.Cell(iRow, iCell).Value = osr.MontoBrutoComision;
                addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "$", "SalesRep");

                iCell++;
                worksheet.Cell(iRow, iCell).Value = osr.ForecastGoalMT;
                addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), ",", "SalesRep");
 
                iCell++;
                worksheet.Cell(iRow, iCell).Value = osr.ForecastCumplimientoPer;
                addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "%", "SalesRep");
   
                iCell++;
                worksheet.Cell(iRow, iCell).Value = osr.ForecastComisionEarnedPer;
                addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "%", "SalesRep");

                iCell++;
                worksheet.Cell(iRow, iCell).Value = osr.TotalMarginMXN;
                addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "$", "SalesRep");

                iCell++;
                worksheet.Cell(iRow, iCell).Value = osr.TotalMarginUSD;
                addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "$", "SalesRep");

                iCell++;
                worksheet.Cell(iRow, iCell).Value = osr.MargenPerMXN;
                addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "%", "SalesRep");

                iCell++;
                worksheet.Cell(iRow, iCell).Value = osr.MargenPerUSD;
                addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "%", "SalesRep");

                iCell++;
                worksheet.Cell(iRow, iCell).Value = osr.MargenComisionEarnedPer;
                addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "%", "SalesRep");

                iCell++;
                worksheet.Cell(iRow, iCell).Value = osr.InventarioComisionEarnedPer;
                addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "%", "SalesRep");

                iCell++;
                worksheet.Cell(iRow, iCell).Value = osr.FactorTotal;
                addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "%", "SalesRep");

                iCell++;
                worksheet.Cell(iRow, iCell).Value = osr.ComisionAPagar;
                addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "$", "SalesRep");

                #endregion
                //Corporate
                foreach (CorporateID_ corp in osr.lstCorporate)
                {
                    if (corp.CorporateID != "")
                    {
                        iRow++;
                        iCell = 1;
                        #region Corporate
                        worksheet.Cell(iRow, iCell).Value = corp.CorporateID;
                        worksheet.Cell(iRow, iCell).Style.Font.SetBold();
                        worksheet.Cell(iRow, iCell).Style.Font.SetBold().Font.FontSize = 12;
                        worksheet.Cell(iRow, iCell).Style.Font.FontColor = XLColor.Orange;
                        worksheet.Cell(iRow, iCell).Style.Fill.BackgroundColor = XLColor.LightGray;
                        worksheet.Cell(iRow, iCell).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Range(worksheet.Cell(iRow, iCell), worksheet.Cell(iRow, iCell + 3)).Merge();
                        //worksheet.Column(iCell).AdjustToContents();

                        iCell = 5;
                        worksheet.Cell(iRow, iCell).Value = corp.PaymentAmountMXN;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell),  "$", "Corporate");
                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = corp.PaymentAmountUSD;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "$", "Corporate");
                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = corp.VolumenMT;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), ",", "Corporate");
                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = corp.VolumenMTPaid;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), ",", "Corporate");
                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = corp.TotalPer;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "%", "Corporate");
                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = "";
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "Corporate");

                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = corp.MontoBrutoComision;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "$", "Corporate");
                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = corp.ForecastGoalMT;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), ",", "Corporate");
                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = corp.ForecastCumplimientoPer;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "%", "Corporate");
                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = "";
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "Corporate");
                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = corp.TotalMarginMXN;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "$", "Corporate");

                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = corp.TotalMarginUSD;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "$", "Corporate");

                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = corp.MargenPerMXN;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "$", "Corporate");
                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = corp.MargenPerUSD;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "%", "Corporate");
                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = corp.MargenComisionEarnedPer;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "%", "Corporate");
                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = corp.InventarioComisionEarnedPer;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "%", "Corporate");
                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = corp.FactorTotal;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "Corporate");
                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = corp.ComisionAPagar;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "$", "Corporate");
                        //iCell++;
                        //worksheet.Cell(iRow, iCell).Value = corp.ComisionAPagar;
                        //addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "Corporate");

                    }
                    
                    #endregion

                    foreach (Customer cust in corp.lstCustomer)
                    {
                        iRow++;
                        iCell = 1;
                        #region Customer
                        worksheet.Cell(iRow, iCell).Value = cust.RowNumber;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "Customer");

                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = cust.CustomerName;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "Customer");

                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = cust.StatusComision;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "Customer"); ;

                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = cust.CustomerType;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "Customer");

                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = cust.PaymentAmountMXN;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "$", "Customer");

                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = cust.PaymentAmountUSD;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "$", "Customer");

                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = cust.VolumenMT;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), ",", "Customer");
                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = cust.VolumenMTPaid;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), ",", "Customer");
                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = cust.TotalPer;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "%", "Customer");

                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = cust.FactorComision;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "%", "Customer");

                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = cust.MontoBrutoComision;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "$", "Customer");

                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = cust.ForecastGoalMT;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), ",", "Customer");

                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = cust.ForecastCumplimientoPer;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "%", "Customer");

                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = "";
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "%", "Customer");

                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = cust.TotalMarginMXN;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "$", "Customer");

                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = cust.TotalMarginUSD;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "$", "Customer");

                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = cust.MargenPerMXN;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "%", "Customer");

                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = cust.MargenPerUSD;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "%", "Customer");

                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = cust.MargenComisionEarnedPer;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "%", "Customer");

                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = cust.InventarioComisionEarnedPer;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "%", "Customer");

                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = cust.FactorTotal;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "Customer");

                        iCell++;
                        worksheet.Cell(iRow, iCell).Value = cust.ComisionAPagar;
                        addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "$", "Customer");
                        
                        #endregion 
                    }
                }
            }

            // Prepare the response
            HttpResponse httpResponse = Response;
            httpResponse.Clear();
            httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            httpResponse.AddHeader("content-disposition", "attachment;filename=\"" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx\"");

            // Flush the workbook to the Response.OutputStream
            using (MemoryStream memoryStream = new MemoryStream())
            {
                workbook.SaveAs(memoryStream);
                memoryStream.WriteTo(httpResponse.OutputStream);
                memoryStream.Close();
            }

            httpResponse.End();
        }


        private void addjustCell(IXLCell iXLCell, IXLColumn iXLColumn, string strFormat, string type)
        {
 
            if (strFormat == "%" || strFormat== "Percentage")
            {
                iXLCell.Style.NumberFormat.Format = "0.0%";
            }

            

            if (strFormat == "$")
            {
                iXLCell.Style.NumberFormat.Format = "$ #,##0.00";
            }

            if (strFormat == ",")
            {
                iXLCell.Style.NumberFormat.Format = "#,##0.00";
            }

            switch (type)
            {
                case "SalesRep":
                    iXLCell.Style.Font.SetBold();
                    iXLCell.Style.Font.SetBold().Font.FontSize = 14;
                    iXLCell.Style.Font.FontColor = XLColor.White;
                    iXLCell.Style.Fill.BackgroundColor = XLColor.Gray;
                    iXLCell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    

                    break;
                case "Corporate":
                    iXLCell.Style.Font.SetBold();
                    iXLCell.Style.Font.SetBold().Font.FontSize = 12;
                    iXLCell.Style.Font.FontColor = XLColor.Orange;
                    iXLCell.Style.Fill.BackgroundColor = XLColor.LightGray;
                    iXLCell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                     

                    break;
                case "Customer":
                    iXLCell.Style.Font.FontSize = 10;
                    iXLCell.Style.Font.FontColor = XLColor.Black;
                    iXLCell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                   
                    break;

                case "Header":
                    iXLCell.Style.Font.SetBold();
                    iXLCell.Style.Fill.BackgroundColor = XLColor.FromColor(System.Drawing.Color.FromArgb(217, 217, 217));
                    iXLCell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    iXLCell.Style.Alignment.WrapText = true;





                    break;
            }

        }



        #endregion
    }
}