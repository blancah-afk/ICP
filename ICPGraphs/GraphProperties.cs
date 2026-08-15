using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ICPGraphs
{
    public class GraphProperties
    {
        public string AxisX { get; set; }
        public string AxisY { get; set; }
        public string AxisY2 { get; set; }
        public string NameSerie1 { get; set; }
        public string NameSerie2 { get; set; }
        public string ToolTipDataSerie1 { get; set; }
        public string GraphName { get; set; }
        public List<Serie> Series { get; set; }
    }

    public class Graph
    {

        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Div { get; set; }
        public List<Serie> Series { get; set; }
        public Dictionary<string, string> singleSerie { get; set; }
        public string AxisY1 { get; set; }
        public string AxisY1_UOM { get; set; }
        public string AxisY2 { get; set; }
        public string AxisX { get; set; }
        public string Categories { get; set; }
    }

    public class Serie
    {

        public string name { get; set; }
        public bool marker { get; set; }
        public string colorSimbología { get; set; }
        public string dashStyle { get; set; }
        public string data { get; set; }
        public string sign { get; set; }
        public string serieType { get; set; }
        public string UOM { get; set; }
        public bool yAxis { get; set; }
        public DashStyle _dashStyle { get; set;}


    }

    public class DashStyle
    {
        public static string Dot = "Dot";

    }

    public class Color
    {
        public static string rojoSteel = "#C0504D";
        public static string azulito2 = "#4F81BD";
        public static string negro = "#000000";
        public static string azulBarra = "#6390C5";
        public static string verdecitoClarito = "#9BBB59";
        public static string naranjita = "#E46C0A";
        public static string verdeLLoron = "#6EFF33";
    }

    public class SerieType
    {

        public static string column = "column";
        public static string line = "spline";
    }

    public class ScriptGraph
    {

        public static string beginScript = "<script>";
        public static string endScript = "</script>";
        public static string beginFunction = "$(function() {";
        public static string endFunction = "});";

        public static string beginChart(string div)
        {
            return ("$('#" + div + "').highcharts({");

        }

        public static string endChart = "});";

        public static string Title(string strTitle)
        {
            return "title: { text: '" + strTitle + "'}";
        }

        public static string chart(bool zoomType, bool alignTicks)
        {
            return "chart: {" +
                "zoomType: " + zoomType.ToString().ToLower() + "," +
            "events:" +
                "{" +
                    "load: function(event)" +
                    "{" +
            "var chartOb = this; }}}";

        }

        public static string credits(bool enabled)
        {
            return "credits: { enabled: " + enabled.ToString().ToLower() + "}";
        }

        public static string exporting(bool enabled)
        {
            return "exporting: { enabled: " + enabled.ToString().ToLower() + "}";
        }

        public static string tooltip(bool shared)
        {
            return "tooltip: { enabled: " + shared.ToString().ToLower() + "}";
        }

        public static string titles(string strTitle, string strSubtitle)
        {
            return " title:{text: '" + strTitle + "',style: { fontFamily: 'Verdana, sans-serif' }}," +
                "subtitle: {text: '" + strSubtitle + "',style: { fontFamily: 'Verdana, sans-serif' }}";

        }

        #region Ejes
        public static string xAxis(string categories, bool crosshair, string title)
        {
            return "xAxis:[{fffordinal: true, categories:" + categories +
                ",crosshair: " + crosshair.ToString().ToLower() +
                ",title:{text: '" + title + "'}}]";
        }

        public static string xyAxis(string xTitle, string yTitle, string sign)
        {
            return "xAxis: [{fffordinal: true,crosshair: false,title:{ text: '" + xTitle + "'}}], " +
               "yAxis:{title: { text: ' " + yTitle + "' }, " +
               "labels: { formatter: function() { return this.value + ' " + sign + "'; }} }, " +
               "plotOptions: {spline: {marker:{ radius: 6, lineWidth: 1 }}} ";

        }

        public static string yAxis(string signSerie1, string colorS1, string titleS1,
            string colorS2, string labelS2)
        {
            return "yAxis:[{ labels: { format: '{value} " + signSerie1 +
                 "',style: { color: '" + colorS1 + "' } },title: { text: '" + titleS1 +
                 "',style: { color:'" + colorS1 + "'} } }," +
                 "{ labels: { format: '{value} ',style: { color: '" + colorS2 + "' } },title: { text: '" +
                labelS2 + "',style: { color: '" + colorS1 + "'} }, " +
                "labels: { format: '{value}',style: { color: '" + colorS1 + "'},enabled: true},opposite: true}]";

        }
        #endregion

        public static string plotOptions()
        {
            return "plotOptions: {" +
                "column:" +
                "{" +
                    "dataLabels:" +
                    "{" +
                        "enabled: true," +
                              "color: '#34495e'," +
                              "align: 'center'," +
                              "format: '{point.y:.2f}'," +
                              "style:" +
                        "{" +
                            "fontSize: '9px'," +
                                  "fontFamily: 'Verdana, sans-serif'" +
                              "}" +
                    "}," +
                        "marker: { enabled: true }," +
                        "enableMouseTracking: true" +
                    "}," +
                "spline:" +
                "{" +
                    "dataLabels:" +
                    "{" +
                        "enabled: true," +
                             "color: '#34495e'," +
                             "align: 'center'," +
                             "format: '{point.y:.0f}'," +
                             "style:" +
                        "{" +
                            "fontSize: '9px'," +
                                 "fontFamily: 'Verdana, sans-serif', " + "dashStyle: 'line'" +
                             "}" +
                    "}," +
                    "marker: { enabled: false }" +
                "}" +
            "}";
        }

        public static string series2(List<Serie> lst)
        {
            string serie = " series: [";
            int len = lst.Count();
            int i = 0;

            foreach (Serie s in lst)
            {

                serie += " {" +
                    "name: '" + s.name + "'," +
                    "type: '" + s.serieType + "'," +
                    "yAxis:" + Convert.ToInt32(s.yAxis).ToString() + "," +
                    "marker:" + "{" + " enabled: " + Convert.ToInt32(s.marker).ToString() + ",}," +
                    "color: '" + s.colorSimbología + "'," +
                    "dashStyle: '" + s.dashStyle + "'," +
                    "tooltip: { valueSuffix: ' " + s.sign + "' }," +
                    "data: " + s.data + "}";
                i++;

                if (i == len)
                {
                    serie += "]";
                }

                if (i < len)
                {
                    serie += ",";
                }
            }

            return serie;

        }

        public static string series(List<Serie> lst, bool xDefined)
        {
            string serie = " series: [";
            int len = lst.Count();
            int i = 0;


            if (xDefined)
            {
                foreach (Serie s in lst)
                {

                    serie += " {" +
                        "name: '" + s.name + "'," +
                        "type: ''," +
                        "yAxis:0," +
                        "marker:" + "{" + " enabled: " + Convert.ToInt32(s.marker).ToString() + ",}," +
                        "color: '" + s.colorSimbología + "'," +
                        "dashStyle: '" + s.dashStyle + "'," +
                        "tooltip: { valueSuffix: ' " + s.sign + "' }," +
                        "data: " + s.data + "}";
                    i++;

                    if (i == len)
                    {
                        serie += "]";
                    }

                    if (i < len)
                    {
                        serie += ",";
                    }
                }
            }

            if (!xDefined)
            {
                foreach (Serie s in lst)
                {

                    serie += " {" +
                        "name: '" + s.name + "'," +
                        "marker:" + "{" + " enabled: " + Convert.ToInt32(s.marker).ToString() + ",}," +
                        "color: '" + s.colorSimbología + "'," +
                        "dashStyle: '" + s.dashStyle + "'," +
                        "data: " + s.data + "}";
                    i++;

                    if (i == len)
                    {
                        serie += "]";
                    }

                    if (i < len)
                    {
                        serie += ",";
                    }
                }
            }
            return serie;

        }

        public static string legend = "legend: { enabled: false, layout: 'vertical', align: 'right', verticalAlign: 'top', y: 60, navigation: { activeColor: '#3E576F', animation: true, arrowSize: 10, inactiveColor: '#CCC', style: { fontWeight: 'bold', color: '#333', fontSize: '12px' } } }";

        #region FormatData
        public static string FormatData_SingleSerie(Dictionary<string, string> Data)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            bool First = true;
            foreach (var item in Data)
            {
                if (First)
                {
                    sb.Append(string.Format("[{0},{1}]", item.Key, item.Value));
                    First = false;
                }
                else
                {
                    sb.Append(string.Format(",[{0},{1}]", item.Key, item.Value));
                }
            }
            sb.Append("]");
            return sb.ToString();
        }

        public static string FormatData_Categories(Dictionary<string, string> Data)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            bool First = true;
            foreach (var item in Data)
            {
                if (First)
                {
                    sb.Append(string.Format("'{0}'", item.Key));
                    First = false;
                }
                else
                {
                    sb.Append(string.Format(",'{0}'", item.Key));
                }
            }
            sb.Append("]");
            return sb.ToString();

        }

        public static string FormatData_Serie2(Dictionary<string, string> Data)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            bool First = true;
            foreach (var item in Data)
            {
                if (First)
                {
                    sb.Append(string.Format("{0}", item.Value));
                    First = false;
                }
                else
                {
                    sb.Append(string.Format(",{0}", item.Value));
                }
            }
            sb.Append("]");
            return sb.ToString();

        }

        public static string FormatData_Serie1(Dictionary<string, string> Data, string color)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            bool First = true;
            foreach (var item in Data)
            {
                if (First)
                {
                    sb.Append("{ y: " + item.Value + ", color: '" + color + "' }");
                    First = false;
                }
                else
                {
                    sb.Append(",{ y: " + item.Value + ", color: '" + color + "' }");
                }
            }
            sb.Append("]");
            return sb.ToString();
        }

        public static string FormatData_DataTable(DataTable dt)
        {
            int rows = dt.Rows.Count;
            int colums = dt.Columns.Count;
            int i = 0;
            int c = 0;
            StringBuilder sb = new StringBuilder();
            string data = "[";
            sb.Append(data);

            foreach (DataRow r in dt.Rows)
            {
                c = 0;
                sb.Append("[");
                const string quote = "\"";
                foreach (DataColumn dc in dt.Columns)
                {
                    sb.Append(quote + r[dc] + quote);
                    c++;
                    if (c < colums) { sb.Append(","); }
                }
                sb.Append("]");
                i++;
                if (i < rows) { sb.Append(","); }
            }
            sb.Append("],");

            return sb.ToString();

        }

        public static string FormatData_DataColumnNames(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            const string quote = "\"";
            int colums = dt.Columns.Count;
            int c = 0;

            sb.Append("columns: [");

            foreach (DataColumn column in dt.Columns)
            {

                sb.Append("{ title: " + quote + column.ColumnName + quote + " }");
                c++;
                if (c < colums) { sb.Append(","); }
            }
            sb.Append("]");

            return sb.ToString();
        }

        #endregion

        public static string CreateTable(string strTableName, DataTable dt)
        {
            const string quote = "\"";
            string tabla = " $('#" + strTableName + "').DataTable({" + "destroy: true," +
               quote + "order" + quote + ": [[ 0, " + quote + "asc" + quote + "]]," +

               quote + "columnDefs" + quote + ": [{" +
               quote + "targets" + quote + ": [ 0 ]," +
               quote + "visible" + quote + ": false," +
               quote + "searchable" + quote + ": false}]," +

              "data: " + FormatData_DataTable(dt) +
              FormatData_DataColumnNames(dt) +
              "});";

            return tabla;

        }

        public static string shipGraph()
        {
            return "$('#divShip').highcharts('StockChart', {" +
                "chart:" +
                "{" +
                    "type: 'spline', events:" +
                    "{" +
                        "load: function(event) {" +
            "var sumMT = 0," +
                "sumDem = 0," +
                "countMT = 0," +
                "chartOb = this;" +
            "for (var i = 0, len = this.series[2].yData.length; i < len; i++)" +
            "{" +
                "sumMT += this.series[2].yData[i]; " +
                "countMT += 1; " +
            "}" +
            "for (var i = 0, len = this.series[3].yData.length; i < len; i++)" +
            "{" +
                "sumDem += this.series[3].yData[i]; avgCom.push([this.series[3].xData[i], 500]);" +
        "}" +
                    "$('#SumMT').html(parseFloat(sumMT).toFixed(2));" +
                    "$('#AvgMT').html(parseFloat(sumMT / countMT).toFixed(2));" +
                    "$('#SumDemand').html(parseFloat(sumDem).toFixed(2));" +
        "}" +
    "}" +
"}," +
        "credits: {" +
            "enabled: false" +
        "}," +
        "exporting: {" +
            "enabled: false" +
        "}," +
        "legend: {" +
            "enabled: true," +
            "layout: 'vertical', align: 'right', verticalAlign: 'top', y: 120," +
            "navigation: {" +
                "activeColor: '#3E576F'," +
                "animation: true," +
                "arrowSize: 12," +
                "inactiveColor: '#CCC'," +
                "style: {" +
                    "fontWeight: 'bold'," +
                    "color: '#333'," +
                    "fontSize: '12px'" +
                "}" +
            "}" +
        "}," +
        "rangeSelector: {" +
            "allButtonsEnabled: true, selected: 1" +
        "}," +
        "title: {" +
            "text: 'Shipment Tracking'" +
        "}," +
        "subtitle: {" +
            "text: 'History of Shiping Vs Demand'" +
        "}," +
        "tooltip: {" +
            "valueSuffix: ' MT'" +
        "}," +
        "xAxis: {" +
            "ordinal: false, events: {" +
                "afterSetExtremes: function(e)" +
"{" +
    "var chartOb = this," +
        "sumMT = 0," +
        "sumDem = 0," +
        "countMT = 0;" +
                    "$.each(chartOb.series[2].data, function(i, point) {" +
        "if (point.x >= chartOb.min && point.x <= chartOb.max) " +
        "{" +
            "sumMT += point.y; " +
            "countMT += 1; " +
        "}; " +
    "});" +
                    "$.each(chartOb.series[3].data, function(i, point) {" +
        "if (point.x >= chartOb.min && point.x <= chartOb.max) sumDem += point.y; " +
    "}); for (var i = 0, len = chartOb.series[0].yData.length; i < len; i++)" +
    "{" +
        "avgCom[i][1] = Number(parseFloat(sumMT / countMT).toFixed(2));" +
    "}" +
    "chartOb.series[0].setData(avgCom, false);" +
                    "$('#SumMT').html(parseFloat(sumMT).toFixed(2));" +
                    "$('#AvgMT').html(parseFloat(sumMT / countMT).toFixed(2));" +
                    "$('#SumDemand').html(parseFloat(sumDem).toFixed(2));" +
"}" +
            "}" +
        "}," +
        "yAxis: {" +
            "title: {" +
                "text: 'Metric Tons'" +
            "}, labels: {" +
                "formatter: function() { return this.value + ' MT'; }" +
            "}" +
        "}," +
        "plotOptions: {" +
            "spline: {" +
                "marker: {" +
                    "radius: 4, lineWidth: 1" +
                "}" +
            "}" +
        "},";

        }
    }
}
