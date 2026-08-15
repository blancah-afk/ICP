using ClosedXML.Excel;
using ICPDataAccess;
using ICPGraphs;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
 
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICP
{
 
    public partial class ReportSalesProfitMaterials : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             
            if (!IsPostBack)
            {
                
            }
        }

        protected void btnExportXLS_Click(object sender, EventArgs e)
        {
            string dtStartDate = Request["dtStartDate"];
            string dtEndDate = Request["dtEndDate"];
            if (dtStartDate != "" && dtEndDate != "")
            {
                ExportToExcel(Convert.ToDateTime(dtStartDate), Convert.ToDateTime(dtEndDate));
            }
         
        }
 
 
        public  void ExportToExcel(DateTime StartDate, DateTime EndDate) 
        {
            string stDate = StartDate.ToString();
            string strReportName = "Sales Profit Materials";
            ExportFile e = new ExportFile();
            //string strSheetName = Convert.ToString(DateTime.Now.Month) + "-" +  Convert.ToString(DateTime.Now.Year);

            //Crear libro y agregar hoja
            XLWorkbook workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add(strReportName);

            //Inicia carga de Info
            int iRow = 2;
            int iCell = 1;

            //addTitulo
            worksheet.Cell(iRow, iCell).Value = strReportName;
            worksheet.Cell(iRow, iCell).Style.Font.FontColor = XLColor.Black;
            worksheet.Cell(iRow, iCell).Style.Font.SetBold().Font.FontSize = 16;
            worksheet.Range(worksheet.Cell(iRow, iCell), worksheet.Cell(iRow, 12)).Merge();
            iRow++;
            worksheet.Cell(iRow, iCell).Value = "Report From: " + StartDate.ToString("dd MMMM yyyy") + " to " + EndDate.ToString("dd MMMM yyyy");
            worksheet.Cell(iRow, iCell).Style.Font.FontColor = XLColor.Black;
            worksheet.Cell(iRow, iCell).Style.Font.SetBold().Font.FontSize = 16;
            worksheet.Range(worksheet.Cell(iRow, iCell), worksheet.Cell(iRow, 12)).Merge();
            iRow++;
            iRow++;

            //Get Data
            DataSet ds = new DataSet();
            DaReports da = new DaReports();

            ds = da.dsSalesProfitDashboardMaterial(StartDate, EndDate);


            //Add Headers
            #region addheaders
            iCell = 1;
 
            foreach (DataColumn i in ds.Tables[0].Columns)
            {
                if (i.ColumnName.ToString() != "")
                {
                    worksheet.Cell(iRow, iCell).Value = i.ColumnName.ToString();
                    addjustCell(worksheet.Cell(iRow, iCell), worksheet.Column(iCell), "", "Header");
                    iCell++;
                }
            }

            #endregion

            //AddInfo
            iRow++;
            iCell = 1;
            foreach (DataRow dr in ds.Tables[0].Rows)
            { 
                worksheet.Cell(iRow, 1).Value = dr["FiscalYear"].ToString();
                worksheet.Cell(iRow, 2).Value = dr["FiscalPeriod"].ToString();
                worksheet.Cell(iRow, 3).Value = dr["CreditMemo"].ToString();
                worksheet.Cell(iRow, 4).Value = dr["InvoiceNum"].ToString();
                worksheet.Cell(iRow, 5).Value = dr["InvoiceDate"].ToString();
                worksheet.Cell(iRow, 6).Value = dr["InvoiceLine"].ToString();
                worksheet.Cell(iRow, 7).Value = dr["CurrencyCode"].ToString();
                worksheet.Cell(iRow, 8).Value = dr["CustID"].ToString();
                worksheet.Cell(iRow, 9).Value = dr["Customer"].ToString();
                worksheet.Cell(iRow, 10).Value = dr["OrderNum"].ToString();
                worksheet.Cell(iRow, 11).Value = dr["PONumCustomer"].ToString();
                worksheet.Cell(iRow, 12).Value = dr["PartNumCustomer"].ToString();
                worksheet.Cell(iRow, 13).Value = dr["InvoiceRef"].ToString();
                worksheet.Cell(iRow, 14).Value = dr["InvoiceLineRef"].ToString();
                worksheet.Cell(iRow, 15).Value = dr["GroupDesc"].ToString();
                worksheet.Cell(iRow, 16).Value = dr["IndustryClassType"].ToString();
                worksheet.Cell(iRow, 17).Value = dr["IndustryClass"].ToString();
                worksheet.Cell(iRow, 18).Value = dr["ICCode"].ToString();
                worksheet.Cell(iRow, 19).Value = dr["SalesRep"].ToString();
                worksheet.Cell(iRow, 20).Value = dr["PartNum"].ToString();
                worksheet.Cell(iRow, 21).Value = dr["LineDesc"].ToString();
                worksheet.Cell(iRow, 22).Value = dr["LotNum"].ToString();
                worksheet.Cell(iRow, 23).Value = dr["LotFirstRefDate"].ToString();
                worksheet.Cell(iRow, 24).Value = dr["MtlPOInfo"].ToString();
                worksheet.Cell(iRow, 25).Value = dr["ConsolidatedLot"].ToString();
                worksheet.Cell(iRow, 26).Value = dr["ConvFactor"].ToString();
                worksheet.Cell(iRow, 27).Value = dr["ProdCode"].ToString();
                worksheet.Cell(iRow, 28).Value = dr["ProdGroup"].ToString();
                worksheet.Cell(iRow, 29).Value = dr["SellingShipQty"].ToString();
                worksheet.Cell(iRow, 30).Value = dr["SalesUM"].ToString();
                worksheet.Cell(iRow, 31).Value = dr["OurShipQty"].ToString();
                worksheet.Cell(iRow, 32).Value = dr["IUM"].ToString();
                worksheet.Cell(iRow, 33).Value = dr["SellingQtyKG"].ToString();
                worksheet.Cell(iRow, 34).Value = dr["Shape"].ToString();
                worksheet.Cell(iRow, 35).Value = dr["ExchangeRateMaterial"].ToString();
                worksheet.Cell(iRow, 36).Value = dr["ExchangeRateProd"].ToString();
                worksheet.Cell(iRow, 37).Value = dr["ExchangeRateSale"].ToString();
                worksheet.Cell(iRow, 38).Value = dr["LaborMXN"].ToString();
                worksheet.Cell(iRow, 39).Value = dr["BurdenMXN"].ToString();
                worksheet.Cell(iRow, 40).Value = dr["MaterialMXN"].ToString();
                worksheet.Cell(iRow, 41).Value = dr["SubContractMXN"].ToString();
                worksheet.Cell(iRow, 42).Value = dr["MtlBurdenMXN"].ToString();
                worksheet.Cell(iRow, 43).Value = dr["LbrUnitCostMXN"].ToString();
                worksheet.Cell(iRow, 44).Value = dr["BurUnitCostMXN"].ToString();
                worksheet.Cell(iRow, 45).Value = dr["MtlUnitCostMXN"].ToString();
                worksheet.Cell(iRow, 46).Value = dr["SubUnitCostMXN"].ToString();
                worksheet.Cell(iRow, 47).Value = dr["MtlBurUnitCostMXN"].ToString();
                worksheet.Cell(iRow, 48).Value = dr["LaborUSD"].ToString();
                worksheet.Cell(iRow, 49).Value = dr["BurdenUSD"].ToString();
                worksheet.Cell(iRow, 50).Value = dr["MaterialUSD"].ToString();
                worksheet.Cell(iRow, 51).Value = dr["SubContractUSD"].ToString();
                worksheet.Cell(iRow, 52).Value = dr["MtlBurdenUSD"].ToString();
                worksheet.Cell(iRow, 53).Value = dr["LbrUnitCostUSD"].ToString();
                worksheet.Cell(iRow, 54).Value = dr["BurUnitCostUSD"].ToString();
                worksheet.Cell(iRow, 55).Value = dr["MtlUnitCostUSD"].ToString();
                worksheet.Cell(iRow, 56).Value = dr["SubUnitCostUSD"].ToString();
                worksheet.Cell(iRow, 57).Value = dr["MtlBurUnitCostUSD"].ToString();
                worksheet.Cell(iRow, 58).Value = dr["TotalPriceMXN"].ToString();
                worksheet.Cell(iRow, 59).Value = dr["SaleUnitPriceMXN"].ToString();
                worksheet.Cell(iRow, 60).Value = dr["TotalPriceUSD"].ToString();
                worksheet.Cell(iRow, 61).Value = dr["SaleUnitPriceUSD"].ToString();
                worksheet.Cell(iRow, 62).Value = dr["QtyMT"].ToString();
                worksheet.Cell(iRow, 63).Value = dr["CalcUnitPriceMXN"].ToString();
                worksheet.Cell(iRow, 64).Value = dr["TotalCostMXN"].ToString();
                worksheet.Cell(iRow, 65).Value = dr["TotalCostMXNLandedCost"].ToString();
                worksheet.Cell(iRow, 66).Value = dr["UnitCostMXN"].ToString();
                worksheet.Cell(iRow, 67).Value = dr["MarginPercentMXN"].ToString();
                worksheet.Cell(iRow, 68).Value = dr["MarginMXN"].ToString();
                worksheet.Cell(iRow, 69).Value = dr["MarginMXNLandedCost"].ToString();
                worksheet.Cell(iRow, 70).Value = dr["CalcUnitPriceUSD"].ToString();
                worksheet.Cell(iRow, 71).Value = dr["TotalCostUSD"].ToString();
                worksheet.Cell(iRow, 72).Value = dr["TotalCostUSDLandedCost"].ToString();
                worksheet.Cell(iRow, 73).Value = dr["UnitCostUSD"].ToString();
                worksheet.Cell(iRow, 74).Value = dr["MarginPercentUSD"].ToString();
                worksheet.Cell(iRow, 75).Value = dr["MarginUSD"].ToString();
                worksheet.Cell(iRow, 76).Value = dr["MarginUSDLandedCost"].ToString();
                worksheet.Cell(iRow, 77).Value = dr["SourcePartNum"].ToString();
                worksheet.Cell(iRow, 78).Value = dr["SourceLotNum"].ToString();
                worksheet.Cell(iRow, 79).Value = dr["SourceLotFirstTranDate"].ToString();
                worksheet.Cell(iRow, 80).Value = dr["MtlExchangeRate"].ToString();
                worksheet.Cell(iRow, 81).Value = dr["CostInfoObtainedFrom"].ToString();
                worksheet.Cell(iRow, 82).Value = dr["StandardMtlUnitCostMXN"].ToString();
                worksheet.Cell(iRow, 83).Value = dr["StandardMtlBurUnitCostMXN"].ToString();
                worksheet.Cell(iRow, 84).Value = dr["StandardMtlUnitCostUSD"].ToString();
                worksheet.Cell(iRow, 85).Value = dr["StandardMtlBurUnitCostUSD"].ToString();
                worksheet.Cell(iRow, 86).Value = dr["StandardTotalMXNLandedCost"].ToString();
                worksheet.Cell(iRow, 87).Value = dr["StandardTotalUSDLandedCost"].ToString();
                worksheet.Cell(iRow, 88).Value = dr["StandardMarginMXNLandedCost"].ToString();
                worksheet.Cell(iRow, 89).Value = dr["StandardMarginUSDLandedCost"].ToString();
                worksheet.Cell(iRow, 90).Value = dr["CostPer"].ToString();


                iRow++;
 
            }

            HttpResponse httpResponse = Response;
            httpResponse.Clear();
            httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            httpResponse.AddHeader("content-disposition", "attachment;filename=\"" + strReportName + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx\"");

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

            if (strFormat == "%" || strFormat == "Percentage")
            {
                iXLCell.Style.NumberFormat.Format = "0.0%";
            }



            if (strFormat == "$")
            {
                iXLCell.Style.NumberFormat.Format = "$ #,##0.00";
            }

            switch (type)
            {
                case "SalesRep":
                    iXLCell.Style.Font.SetBold();
                    iXLCell.Style.Font.SetBold().Font.FontSize = 14;
                    iXLCell.Style.Font.FontColor = XLColor.White;
                    iXLCell.Style.Fill.BackgroundColor = XLColor.Gray;
                    iXLCell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    iXLColumn.AdjustToContents();

                    break;
                case "Corporate":
                    iXLCell.Style.Font.SetBold();
                    iXLCell.Style.Font.SetBold().Font.FontSize = 12;
                    iXLCell.Style.Font.FontColor = XLColor.Orange;
                    iXLCell.Style.Fill.BackgroundColor = XLColor.LightGray;
                    iXLCell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    iXLColumn.AdjustToContents();

                    break;
                case "Customer":
                    iXLCell.Style.Font.FontSize = 10;
                    iXLCell.Style.Font.FontColor = XLColor.Black;
                    iXLCell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    iXLColumn.AdjustToContents();
                    break;

                case "Header":
                    iXLCell.Style.Font.SetBold();
                    iXLCell.Style.Fill.BackgroundColor = XLColor.Gray;
                    iXLCell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    iXLColumn.AdjustToContents();
                    break;
            }

        }

        

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}