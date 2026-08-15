using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ICP
{
    public class InfoReport
    {
        public int Id { get; set; }
        public string Reporte { get; set; }
        public List<string> Parametros { get; set; }
    }

    public class CrystalReport
    {
        //Variables globales
        private string StartDate;
        private string EndDate;
        //private CrystalReportViewer CRVReport;

        //Override de Clase
        public CrystalReport(CrystalReportViewer _CRVReport)
        {

            StartDate = string.Empty;
            EndDate = string.Empty;

        }

        public void GenerateReport(string Type, int numReport, InfoReport infRpt,
            ref CrystalReportViewer CRVReport, ref ReportDocument cryRpt, string strReportFilePath)
        {
            try
            {

                var DB = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
                cryRpt = new ReportDocument();
                DataSet DSReporte = new DataSet();
                TableLogOnInfo logonInfo = new TableLogOnInfo();
                string _strReportFilePath = strReportFilePath + infRpt.Reporte;

                cryRpt.Load(_strReportFilePath);

                foreach (Table table in cryRpt.Database.Tables)
                {
                    // Establecer la información de conexión de la tabla en el informe.
                    logonInfo.ConnectionInfo.ServerName = DB.DataSource;
                    logonInfo.ConnectionInfo.DatabaseName = DB.InitialCatalog;
                    logonInfo.ConnectionInfo.UserID = DB.UserID;
                    logonInfo.ConnectionInfo.Password = DB.Password;
                    table.ApplyLogOnInfo(logonInfo);
                }

                int algo = cryRpt.ParameterFields.Count;

                cryRpt.ParameterFields[0].PromptText = "Start Date";
                cryRpt.ParameterFields[1].PromptText = "End Date";

                CRVReport.ToolPanelView = ToolPanelViewType.None;
                CRVReport.ReportSource = cryRpt;
                CRVReport.DataBind();

                CRVReport.PageZoomFactor = 85;
                CRVReport.HasToggleGroupTreeButton = false;
                CRVReport.HasCrystalLogo = false;
                CRVReport.EnableParameterPrompt = true;
                //CRVReport.ParameterFieldInfo = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error GenerarReporte :" + ex.Message, ex);
            }
        }

        public void ValuesKPIs(string Year, string Month)
        {
            //DataSet InfoList = new DataSet();
            ////string connetionString = string.Empty;
            //string NameSPString = string.Empty;

            ////connetionString = "Data Source=<<db-server>>; Initial Catalog=Epicor905; User ID=<<db-user>>; Password=<<db-password>>;Connection Timeout=0";
            //string connetionString = ConfigurationManager.ConnectionStrings["E10"].ToString();
            //using (SqlConnection connection = new SqlConnection(connetionString))
            //{
            //    //Consulta el Nombre del SP a Consultar
            //    NameSPString = "SPQ_ValuesKPIs";

            //    SqlCommand comandoSql = new SqlCommand(NameSPString, connection);
            //    comandoSql.CommandType = CommandType.StoredProcedure;
            //    comandoSql.Parameters.Add(new SqlParameter("YearP", Year));
            //    comandoSql.Parameters.Add(new SqlParameter("MonthP", Month));
            //    try
            //    {
            //        if (connection.State == ConnectionState.Closed)
            //            connection.Open();
            //        SqlDataAdapter da = new SqlDataAdapter(comandoSql);
            //        da.Fill(InfoList);

            //        foreach (DataRow renglon in InfoList.Tables[0].Rows)
            //        {
            //            Currency = renglon["Currency"].ToString();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        throw new Exception("Error GetReport :" + ex.Message, ex);
            //    }
            //    finally
            //    {
            //        if (connection != null)
            //            connection.Close();
            //    }
            //}

        }

        public void DomPric(int Year, int Month)
        {
            //DataSet InfoList = new DataSet();
            ////string connetionString = string.Empty;
            //string NameSPString = string.Empty;

            ////connetionString = "Data Source=<<db-server>>; Initial Catalog=Epicor905; User ID=<<db-user>>; Password=<<db-password>>;Connection Timeout=0";
            //string connetionString = ConfigurationManager.ConnectionStrings["E10"].ToString();

            //List<ParamSQL> lparm = new List<ParamSQL>();
            ////Definimos los parametros
            //lparm.Add(new ParamSQL { NomParam = "@FiscalYear", Valor = Year.ToString() });
            //lparm.Add(new ParamSQL { NomParam = "@FiscalPeriod", Valor = Month.ToString() });

            //using (SqlConnection connection = new SqlConnection(connetionString))
            //{
            //    //Consulta el Nombre del SP a Consultar
            //    NameSPString = "SPkpiSELDomPrice";

            //    SqlCommand comandoSql = new SqlCommand(NameSPString, connection);
            //    comandoSql.CommandType = CommandType.StoredProcedure;

            //    foreach (ParamSQL pp in lparm)
            //    {
            //        comandoSql.Parameters.Add(new SqlParameter(pp.NomParam, pp.Valor));
            //    }
            //    try
            //    {
            //        if (connection.State == ConnectionState.Closed)
            //            connection.Open();
            //        SqlDataAdapter da = new SqlDataAdapter(comandoSql);
            //        da.Fill(InfoList);

            //        foreach (DataRow renglon in InfoList.Tables[0].Rows)
            //        {
            //            DomPrice = decimal.Parse((renglon["PriceUSD"].Equals(DBNull.Value) ? "0" : renglon["PriceUSD"].ToString())).ToString();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        throw new Exception("Error GetReport :" + ex.Message, ex);
            //    }
            //    finally
            //    {
            //        if (connection != null)
            //            connection.Close();
            //    }
            //}

        }
    }
}