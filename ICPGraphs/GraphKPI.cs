using ICPDataAccess;
using ICPDataModel;
using DataTools;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ICPGraphs
{
    public class GraphKPI
    {
 
        const string quote = "\"";

        SqlAccess sql = new SqlAccess();
        SqlParameter[] parametersKPI;
        delegate bool DType(string input);
        DaKPIOEE da = new DaKPIOEE();

        //public bool asyncUpdateInfo(int idConsulta, DateTime dtStartDate, DateTime dtEndDate)
        //{
        //    bool data = false;
        //    DmProcess dm = new DmProcess();
        //    ICPDataAccess.SqlParameters sqlP = new ICPDataAccess.SqlParameters();
        //    dm.Process = "0001";
        //    dm.StartDate = dtStartDate;
        //    dm.EndDate = dtEndDate;
        //    dm.idConsulta = idConsulta;

        //    parametersKPI = sqlP.pKPIProdStatus(dm);
        //    data = sql.GetBySQL_bool_KPI(ICPDataAccess.SqlStoredProcedures.SW_SP_KPIProdStatusUPD);
          
        //    return data;

        //}

        public bool ready(int id, DateTime dtStartDate, DateTime dtEndDate)
        {
            DaKPIOEE da = new DaKPIOEE();
            return da.b_QueryReady(id, dtStartDate, dtEndDate);
        }

        public string strGraph()
        {

            DaKPIOEE da = new DaKPIOEE();
            StringBuilder sb = new StringBuilder();
            Dictionary<string, string> lstSerie1OEE = new Dictionary<string, string>();
            Dictionary<string, string> lstSerie2PT = new Dictionary<string, string>();

            DataSet ds = new DataSet();

            ds = da.ds_KPIOEE();
            da._ICPOEEData(out lstSerie1OEE, out lstSerie2PT);


            sb.Append(ScriptGraph.beginScript);
            sb.Append(ScriptGraph.beginFunction);
            sb.Append(strGraph_OEE(lstSerie1OEE, lstSerie2PT));
            sb.Append(ScriptGraph.CreateTable("example", ds.Tables[0]));
            sb.Append(ScriptGraph.endFunction);
            sb.Append(ScriptGraph.endScript);

            return sb.ToString();
        }

        private string strGraph_OEE(Dictionary<string, string> lstSerie1OEE, Dictionary<string, string> lstSerie2PT)
        {
            string serie1 = ScriptGraph.FormatData_Serie1(lstSerie1OEE, Color.azulBarra);
            string serie2 = ScriptGraph.FormatData_Serie2(lstSerie2PT);
            string categorias = ScriptGraph.FormatData_Categories(lstSerie1OEE);

            Serie Serie1 = new Serie()
            {
                name = "Overall Equipment Eficciency",
                dashStyle = "",
                serieType = SerieType.column,
                marker = true,
                colorSimbología = Color.azulBarra,
                data = serie1,
                yAxis = false,
            };
            Serie Serie2 = new Serie()
            {
                name = "Processed Tons",
                dashStyle = "",
                serieType = "",
                marker = true,
                colorSimbología = "#2C3E50",
                data = serie2,
                yAxis = true,
                UOM = ""
            };

            List<Serie> lst = new List<Serie>();
            lst.Add(Serie1);
            lst.Add(Serie2);

            StringBuilder sb = new StringBuilder();
            List<Graph> graphs = new List<Graph>();

            Graph graph = new Graph();
            graph.Title = "OEE";
            graph.SubTitle = "";
            graph.AxisY1 = "Processed Tons";
            graph.AxisY2 = "";
            graph.AxisX = "Week";
            graph.AxisY1_UOM = "Hrs";
            graph.Categories = categorias;
            graph.Div = "divOEE";
            graph.Series = lst;

            graphs.Add(graph);

            sb.Append(strGraph_Series(graphs));
            return sb.ToString();
        }

        private string strGraph_Series(List<Graph> graphs)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Graph graph in graphs)
            {
                sb.Append(ScriptGraph.beginChart(graph.Div));
                sb.Append(ScriptGraph.chart(true, true) + ",");
                sb.Append(ScriptGraph.credits(false) + ",");
                sb.Append(ScriptGraph.exporting(false) + ",");
                sb.Append(ScriptGraph.tooltip(true) + ",");
                sb.Append(ScriptGraph.titles(graph.Title, graph.SubTitle) + ",");
                sb.Append(ScriptGraph.xAxis(graph.Categories, true, graph.AxisX) + ",");
                sb.Append(ScriptGraph.yAxis(graph.AxisY1_UOM, Color.negro, graph.AxisY1,
                    Color.azulito2, graph.AxisY2) + ",");
                sb.Append(ScriptGraph.plotOptions() + ",");
                sb.Append(ScriptGraph.series2(graph.Series));
                sb.Append(ScriptGraph.endChart);

            }

            return sb.ToString();

        }

    }
}
