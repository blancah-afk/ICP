using ICPDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICPGraphs
{
    public class GrapICP
    {
        private static string xName = "Week";

        private static string FPY = "First Pass Yield";
        private static string JPM = "Job Performance";
        private static string EQA = "Equipment Availability";
        private static string TTH = "Throughput in Tons Per Hour";
        private static string OEE = "Temper Cut to Length Main Data";

        private static string dFPY = "divShip";
        private static string dJPM = "divJobPerformance";
        private static string dEQA = "divEquipmentAvailability";
        private static string dTTH = "divThruput";
        private static string dOEE = "divOEE";
        private static string spOEE = "OEE";


        private static string symbol = "%";

        public string strGraph_OEEDtl(Dictionary<string, string> dct_Graph1, Dictionary<string, string> dct_Graph2,
            Dictionary<string, string> dct_Graph3, Dictionary<string, string> dct_Graph4)
        {
            StringBuilder sb = new StringBuilder();
            List<Graph> graphs = new List<Graph>();


            Serie Serie1 = new Serie()
            {
                name = "",
                dashStyle = DashStyle.Dot,
                sign = symbol,
                marker = true,
                colorSimbología = Color.azulBarra,
                data = ScriptGraph.FormatData_Serie1(dct_Graph1, Color.azulBarra),
            };
            List<Serie> lst1 = new List<Serie>();
            lst1.Add(Serie1);

            Graph graph = new Graph()
            {
                Title = FPY,
                SubTitle = "",
                AxisY1 = FPY,
                AxisY2 = "",
                AxisX = xName,
                AxisY1_UOM = symbol,
                Categories = ScriptGraph.FormatData_Categories(dct_Graph1),
                Div = dFPY,
                Series = lst1,

            };

            Serie Serie2 = new Serie()
            {
                name = "",
                dashStyle = DashStyle.Dot,
                sign = symbol,
                marker = true,
                colorSimbología = Color.verdecitoClarito,
                data = ScriptGraph.FormatData_Serie1(dct_Graph2, Color.verdecitoClarito),
            };
            List<Serie> lst2 = new List<Serie>();
            lst2.Add(Serie2);

            Graph graph2 = new Graph()
            {
                Title = JPM,
                SubTitle = "",
                AxisY1 = JPM,
                AxisY2 = "",
                AxisX = xName,
                AxisY1_UOM = symbol,
                Categories = ScriptGraph.FormatData_Categories(dct_Graph2),
                Div = dJPM,
                Series = lst2,
            };

            Serie Serie3 = new Serie()
            {
                name = "",
                dashStyle = DashStyle.Dot,
                sign = symbol,
                marker = true,
                colorSimbología = Color.naranjita,
                data = ScriptGraph.FormatData_Serie1(dct_Graph3, Color.naranjita),
            };
            List<Serie> lst3 = new List<Serie>();
            lst3.Add(Serie3);

            Graph graph3 = new Graph()
            {
                Title = EQA,
                SubTitle = "",
                AxisY1 = EQA,
                AxisY2 = "",
                AxisX = xName,
                AxisY1_UOM = symbol,
                Categories = ScriptGraph.FormatData_Categories(dct_Graph3),
                Div = dEQA,
                Series = lst3,
            };


            Serie Serie4 = new Serie()
            {
                name = "",
                dashStyle = DashStyle.Dot,
                sign = symbol,
                marker = true,
                colorSimbología = Color.azulBarra,
                data = ScriptGraph.FormatData_Serie1(dct_Graph4, Color.azulBarra),
            };
            List<Serie> lst4 = new List<Serie>();
            lst4.Add(Serie4);

            Graph graph4 = new Graph()
            {
                Title = TTH,
                SubTitle = "",
                AxisY1 = TTH,
                AxisY2 = "",
                AxisX = xName,
                AxisY1_UOM = "",
                Categories = ScriptGraph.FormatData_Categories(dct_Graph4),
                Div = dTTH,
                Series = lst4,
            };



            graphs.Add(graph);
            graphs.Add(graph2);
            graphs.Add(graph3);
            graphs.Add(graph4);


            sb.Append(strGraph_CreateScript(graphs));
            return sb.ToString();

        }

        public string strGraph_OEE(Dictionary<string, string> lstSerie1OEE, Dictionary<string, string> lstSerie2PT)
        {
            string serie1 = ScriptGraph.FormatData_Serie1(lstSerie1OEE, Color.azulBarra);
            string serie2 = ScriptGraph.FormatData_Serie2(lstSerie2PT);
            string Categories = ScriptGraph.FormatData_Categories(lstSerie1OEE);


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
                colorSimbología = Color.azulBarra,
                data = serie2,
                yAxis = true,
                UOM = ""
            };

            List<Serie> lst = new List<Serie>();
            lst.Add(Serie1);
            lst.Add(Serie2);

            StringBuilder sb = new StringBuilder();

            sb.Append(ScriptGraph.beginScript);
            sb.Append(ScriptGraph.beginFunction);

            List<Graph> graphs = new List<Graph>();

            Graph graph = new Graph();
            graph.Title = OEE;
            graph.SubTitle = "";
            graph.AxisY1 = "Processed Tons";
            graph.AxisY2 = "";
            graph.AxisX = xName;
            graph.AxisY1_UOM = "Hrs";
            graph.Categories = Categories;
            graph.Div = dOEE;
            graph.Series = lst;

            graphs.Add(graph);

            sb.Append(strGraph_CreateGraph_Series(graphs));

            sb.Append(ScriptGraph.endFunction);
            sb.Append(ScriptGraph.endScript);

            return sb.ToString();

        }

        public string strGraph_LoadByResourceGrp(List<LoadByResourceGRP> lst)
        {
            StringBuilder sb = new StringBuilder();
            List<Graph> graphs = new List<Graph>();


            //string EjeY = "Hours";
            string nSerie1 = "Capacity";
            string nSerie2 = "Scheduled Hrs";

            DmSales dm = new DmSales();


            foreach (LoadByResourceGRP ResourceGRP in lst)
            {
                LoadByResourceGRP corteHoja = new LoadByResourceGRP();
                corteHoja = dm.LoadByResourceGRP_ByProcess(lst, ResourceGRP.Process);
                string test1 = ScriptGraph.FormatData_Serie1(corteHoja._dictionarySerie1, Color.azulBarra);
                string test2 = ScriptGraph.FormatData_Serie2(corteHoja._dictionarySerie2);

                List<Serie> lstCorteHoja = new List<Serie>();
                Serie s1 = new Serie()
                {
                    name = nSerie1,
                    dashStyle = "",
                    serieType = SerieType.column,
                    marker = true,
                    colorSimbología = Color.azulBarra,
                    data = test1,
                    yAxis = false,
                };

                Serie s2 = new Serie()
                {
                    name = nSerie2,
                    dashStyle = "",
                    serieType = SerieType.column,
                    marker = true,
                    colorSimbología = "#2C3E50",
                    data = test2,
                    yAxis = false,
                    UOM = ""
                };

                lstCorteHoja.Add(s1);
                lstCorteHoja.Add(s2);
                string d = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
                Graph graph = new Graph()
                {
                    Title = corteHoja.ResourceGroup,



                    SubTitle = String.Format("{0:yyyy-MM-dd hh:mm tt}", corteHoja.MaxCreateDate),
                    AxisY1 = "Hours",
                    AxisY2 = "",
                    AxisX = xName,
                    AxisY1_UOM = "Hrs",
                    Categories = ScriptGraph.FormatData_Categories(corteHoja._dictionarySerie1),
                    Div = "div" + ResourceGRP.Process,
                    Series = lstCorteHoja,
                };

                graphs.Add(graph);
            }

            sb.Append(strGraph_CreateScript(graphs));
            return sb.ToString();

        }

        public string strGraph_Shipments(Dictionary<string, string> lShippedQtyMT, Dictionary<string, string> lDemandQtyMT, Dictionary<string, string> lAvg,
       Dictionary<string, string> lGoal)
        {

            StringBuilder sb = new StringBuilder();

            Serie Serie1 = new Serie() {
                name = "Avg",
                dashStyle = DashStyle.Dot,
                marker = true,
                colorSimbología = "#2980b9",
                data = ScriptGraph.FormatData_SingleSerie(lAvg)
            };

            Serie Serie2 = new Serie() {
                name = "Goal",
                dashStyle = DashStyle.Dot,
                marker = true,
                colorSimbología = "#c0392b",
                data = ScriptGraph.FormatData_SingleSerie(lGoal)
            };
            Serie Serie3 = new Serie() {
                name = "ShipedQtyMT",
                dashStyle = DashStyle.Dot,
                marker = true,
                colorSimbología = "#2ecc71",
                data = ScriptGraph.FormatData_SingleSerie(lShippedQtyMT)
            };

            Serie Serie4 = new Serie() {
                name = "DemandQtyMT",
                dashStyle = DashStyle.Dot,
                marker = true,
                colorSimbología = "#f39c12",
                data = ScriptGraph.FormatData_SingleSerie(lDemandQtyMT)
            };


            List<Serie> lst = new List<Serie>();
            lst.Add(Serie1);
            lst.Add(Serie2);
            lst.Add(Serie3);
            lst.Add(Serie4);

            sb.Append(ScriptGraph.beginScript);
            sb.Append("var avgCom = new Array();");
            sb.Append(ScriptGraph.beginFunction);
            sb.Append(ScriptGraph.shipGraph());

            //Series
            sb.Append(ScriptGraph.series(lst, false));

            //END SERIE
            sb.Append("});");
            sb.Append(ScriptGraph.endFunction);
            sb.Append(ScriptGraph.endScript);
            return sb.ToString();
        }


        #region BuildGraphs
        public string strGraph_CreateScript(List<Graph> graphs)
        {
            ////aqui pruebas con graficas 

            StringBuilder sb = new StringBuilder();
            sb.Append(ScriptGraph.beginScript);
            sb.Append(ScriptGraph.beginFunction);
            sb.Append(strGraph_CreateGraph_Series(graphs));
            sb.Append(ScriptGraph.endFunction);
            sb.Append(ScriptGraph.endScript);
            return sb.ToString();

        }

        public string strGraph_CreateGraph_Series(List<Graph> graphs)
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

        #endregion
    }
}
