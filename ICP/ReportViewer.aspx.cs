using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Net;
using System.IO;
using System.Web;

namespace ICP
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        ReportDocument cryRpt;
        ReportDocument crystalReport;
        //protected void Export(object sender, EventArgs e)
        //{
        //    ExportFormatType formatType = ExportFormatType.NoFormat;
        //    switch (rbFormat.SelectedItem.Value)
        //    {
        //        case "Word":
        //            formatType = ExportFormatType.WordForWindows;
        //            break;
        //        case "PDF":
        //            formatType = ExportFormatType.PortableDocFormat;
        //            break;
        //        case "Excel":
        //            formatType = ExportFormatType.Excel;
        //            break;
        //        case "CSV":
        //            formatType = ExportFormatType.CharacterSeparatedValues;
        //            break;
        //    }

        //    cryRpt.ExportToHttpResponse(formatType, Response, true, "Crystal");
        //    Response.End();
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int Report = 0;
                cryRpt = new ReportDocument();
                bool Run = true;

                try
                {
                    Report = int.Parse(Request.QueryString["report"]);
 
                }
                catch (Exception)
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
                    Run = false;
                }
 
                if (Run)
                {
                    createReport(Report);
                   
                }
            }
            else
            {
                ReportDocument doc = (ReportDocument)Session["ReportDocument"];
                CRVReporte.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
                
                CRVReporte.ReportSource = doc;
                CRVReporte.DataBind();

                CRVReporte.PageZoomFactor = 100;
                CRVReporte.HasToggleGroupTreeButton = false;
                CRVReporte.HasCrystalLogo = true;
                string texto = CRVReporte.PrintMode.ToString();
            }

        }

        #region Acciones

        private List<InfoReport> GetListaReport()
        {
            List<InfoReport> lr = new List<InfoReport>();
            InfoReport ir = new InfoReport();
            List<string> Pram = new List<string>();
            NameValueCollection section = (NameValueCollection)ConfigurationManager.GetSection("ListaParam");
            string[] Contenido = null;

            var items = section.AllKeys.SelectMany(section.GetValues, (k, v) => new { key = k, value = v });
            foreach (var item in items)
            {
                ir = new InfoReport();
                Pram = new List<string>();
                Contenido = item.value.ToString().Split('|');
                ir.Id = int.Parse(Contenido[0]);
                ir.Reporte = Contenido[1];
                foreach (string pm in Contenido[2].Split(';'))
                {
                    Pram.Add(pm);
                }
                ir.Parametros = Pram;
                lr.Add(ir);
            }
            return lr;
        }
        #endregion

        private void createReport(int iReport)
        {
            List<InfoReport> rInf = new List<InfoReport>();
            InfoReport ir = new InfoReport();
            rInf = GetListaReport();
            ir = (from H in rInf where H.Id == iReport select H).First();
            CrystalReport cr;
            cr = new CrystalReport(CRVReporte);
            string strFilePath = ConfigurationManager.AppSettings["BusinessObjects"];
            cr.GenerateReport("KPIs", iReport, ir, ref CRVReporte, ref cryRpt, strFilePath);

            /*Session Documento*/
            Session["ReportDocument"] = cryRpt;
            Session["CrystalReport"] = cr;
        }

        private void _generatePDF_ToSend()
        {
            ReportDocument crRpt;
            //CrystalReport cr;
            DiskFileDestinationOptions cr_OutputToFile;
            //string reportPath;

            //reportPath = strCrystalPath + strFileName;
            string fileName = "NetSales_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
            //string s_FileSavePath = Server.MapPath("~/Files/" + fileName);

           
                crRpt = (ReportDocument)Session["ReportDocument"];
                cr_OutputToFile = new DiskFileDestinationOptions();
                ExportOptions crExportOptions;
                DiskFileDestinationOptions crDiskDestinationOptions = new DiskFileDestinationOptions();
                PdfRtfWordFormatOptions crFormatTypeOptions = new PdfRtfWordFormatOptions();
                //crDiskDestinationOptions.DiskFileName = s_FileSavePath;
                crExportOptions = crRpt.ExportOptions;
                {
                    crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    crExportOptions.DestinationOptions = crDiskDestinationOptions;
                    crExportOptions.FormatOptions = crFormatTypeOptions;
                }
               Stream s = crRpt.ExportToStream(ExportFormatType.PortableDocFormat);
 
                byte[] bytes;

            try
            {
                using (BinaryReader br = new BinaryReader(s))
                {
                    bytes = br.ReadBytes((int)s.Length);

                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
                    Response.ContentType = "application/pdf";
                    Response.Buffer = true;
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite(bytes);
                    Response.End();
                    Response.Close();
                }
            }
            catch (Exception ex)
            {


                // MessageBox.Show("Error: " + ex.Message, "SteelWareHouse");
            }


            //crRpt.Close();
            //downloadPDF(s_FileSavePath, fileName);

            //File.Delete(s_FileSavePath);
  
           

            //File.Delete(s_FileSavePath);
        }

        private void downloadPDF(string filePath, string FileName)
        { 
            Response.ContentType = "Application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=" +FileName);

            Response.Buffer = true;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.TransmitFile(filePath);
            Response.End();
        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            _generatePDF_ToSend();
        }
    }
}