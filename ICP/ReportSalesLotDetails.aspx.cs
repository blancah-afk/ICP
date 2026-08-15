using ICPDataAccess;
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

using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Drawing;
using ICPGraphs;
using System.Globalization;

namespace ICP
{
    public partial class ReportSalesLotDetails : System.Web.UI.Page
    {
        readonly PagedDataSource _pgsource = new PagedDataSource();
        //int _firstIndex, _lastIndex;
        private int _pageSize = 50;
      

        DaReports da = new DaReports();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _YearsKPI(ddlYear);
                _PeriodKPI(ddlPeriod);
                load();


            }
        }

        public void _YearsKPI(DropDownList ddlY)
        {
            //                      Cargar Lista de Años para seleccionar el Period anual de metas. 
            ddlY.DataSource = _lstFiscalYear();
            ddlY.Text = Convert.ToString(DateTime.Today.Year);
            ddlY.DataBind();
        }

        public void _PeriodKPI(DropDownList ddlY)
        {
            //                      Cargar Lista de meses para seleccionar el Period mensual de metas. 
            System.Globalization.DateTimeFormatInfo mfi = new
            System.Globalization.DateTimeFormatInfo();
            var months = Enumerable.Range(1, 12).Select(i => new { I = i, M = mfi.GetMonthName(i) });
            ddlY.DataSource = months;
            ddlY.DataTextField = "M";
            ddlY.DataValueField = "I";
            ddlY.SelectedValue = DateTime.Today.Month.ToString();
            ddlY.DataBind();
        }


        private List<int> _lstFiscalYear()
        {
            return Enumerable.Range(2019, 10).ToList();
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnExportXLS_Click(object sender, EventArgs e)
        {
            GenerateReport_XLS();
        }

        protected void btnExporPDF_Click(object sender, EventArgs e)
        {
            GenerateReport_PDF();
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            load();
        }

        protected void ddPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void load()
        {

            string javaScript = string.Format("RunGrahp({0}, {1});", ddlYear.SelectedValue, ddlPeriod.SelectedValue);
            ScriptManager.RegisterStartupScript(this, GetType(), "script", javaScript, true);

        }

        private void GenerateReport_XLS()
        {
            StringBuilder strbn = new StringBuilder();
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;   filename=SalesLotDetails_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-Excel";
            strbn.Append(Data());
            Response.Output.Write(strbn);
            Response.Flush();
            Response.Close();
        }

        protected void ddlPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private string Data()
        {
            ExportFile ex = new ExportFile();
            StringBuilder strbn = new StringBuilder();
            StringWriter stringWrite = new StringWriter();

            DaReports da = new DaReports();
            DataSet ds = da.dsSalesLotDetails(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlPeriod.SelectedValue));
            //Inicia

            string createTable = "<table style = \"width: 100%;\" >";
            string iRow = "<tr>";

            strbn.Append(createTable + iRow);

            strbn.Append(iRow);
            strbn.Append("<td colspan=\"5\" style=\"color: black; font-weight: 600; font-size: 18px\">Sales Lot Details</td>");
            strbn.Append("</tr>");

            strbn.Append(iRow);
            strbn.Append("<td colspan=\"5\" style=\"color: black; font-weight: 600; font-size: 16px\">DateTime Printed: " + DateTime.Now.ToString() + "</td>");
            strbn.Append("</tr>");

            strbn.Append(iRow);
            strbn.Append("<td colspan=\"5\" style=\"color: black; font-weight: 600; font-size: 16px\">FiscalYear: " + ddlYear.SelectedValue + ", FiscalPeriod: " + ddlPeriod.SelectedValue + " </td>");
            strbn.Append("</tr>");

            strbn.Append("<tr></tr>");

            strbn.Append(ex.strAddDetail(ds));
            strbn.Append("</tr></table>");
            string se = strbn.ToString();
            strbn.Append(stringWrite.ToString());
            return strbn.ToString();

        }

        protected void GenerateReport_PDF()
        {
            Document document = new Document(PageSize.A9, 10f, 10f, 10f, 0f);
            document.SetPageSize(PageSize.A3.Rotate());
            iTextSharp.text.Font NormalFont = FontFactory.GetFont("Arial", 1);
          

            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                PdfPTable table = null;
                document.Open();

                //Header
                table = TB_Header(writer, document);
                document.Add(table);

                //Datos
                table = info();
                document.Add(table);
           
                document.Close();

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
            }
        }

        private PdfPTable TB_Header(PdfWriter writer, Document document)
        {
            PdfPTable table = null;
            PdfPCell cell = null;
            ExportFile ex = new ExportFile();

            //Header Table
            table = new PdfPTable(2);
            table.WidthPercentage = 95;
            table.SetWidths(new float[] { 1000f, 1000f });

            System.Globalization.DateTimeFormatInfo mfi = new
            System.Globalization.DateTimeFormatInfo();
            string strMonthName = mfi.GetMonthName((int)Convert.ToUInt32(ddlPeriod.SelectedValue)).ToString();
            string strYear = Convert.ToInt32(ddlYear.SelectedValue).ToString();
            string strTitle = "Sales Lot Details: ";

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

        private PdfPTable info()
        {
            DataSet ds = new DataSet();
            DaReports rep = new DaReports();
            ds = rep.dsSalesLotDetails(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlPeriod.SelectedValue));
            PdfPTable table = null;
            PdfPCell cell = null;
            ExportFile export = new ExportFile();

            table = new PdfPTable(26);
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            table.WidthPercentage = 100;
            table.SetWidths(new float[] {
                500f, 300f, 300f, 300f, 300f, 300f,
                300f, 300f, 300f, 300f, 300f, 300f,
                300f, 300f, 300f, 300f, 300f, 300f,
                300f, 300f, 300f, 300f,500f,
                300f, 300f, 300f, });
            table.SpacingBefore = 30f;

            //Headers
            List<string> lst = export.PrintColumnNames(ds);
            foreach (string i in lst)
            {
                cell = DataCell(i.ToString(), Element.ALIGN_LEFT, "Header", 8);
                table.AddCell(cell);
            }

            //Datos
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                foreach (DataColumn dc in ds.Tables[0].Columns)
                {
                    cell = DataCell(dr[dc].ToString(), Element.ALIGN_CENTER, "", 7);
                    table.AddCell(cell);
                }
            }

            return table;
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

            switch (strRange)
            {
                case "AtOrAbove":
                    cell.BackgroundColor = BaseColor.GREEN;
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
    }
}