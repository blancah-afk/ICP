using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWMXPCI.Graficas
{
    public class GRProperties
    {
        public static string timerSwitchScreen(string min, string seg)
        {
            const string quote = "\"";
            string msg = string.Format("{0}The following screen will be displayed in: {0}" + " + min + " + "{0} Minutes,{0}" + " + sec + " + "{0} Seconds{0};", quote);

            return "var min = 0; var sec = 10; var f = new Date(); var ruta; var rutaOriginal;" +
                            "function f1(ruta) { rutaOriginal = ruta; f2(); }" +

                        "function f2() {" +
                            "if (parseInt(sec) > 0)" +
                            "{" +
                                "sec = parseInt(sec) - 1;" +
                                "document.getElementById(" + quote + "showtime" + quote + ").innerHTML =" +
                                    msg +
                                "tim = setTimeout(" + quote + "f2()" + quote + ", 1000);" +

                            "}" +
                            "else" +
                            "{" +
                                "if (parseInt(sec) == 0)" +
                                "{" +
                                    "min = parseInt(min) - 1;" +
                                    "if (parseInt(min) == -1)" +
                                   " {" +
                                   "clearTimeout(tim);" +
                                        "location.href = rutaOriginal;" +
                                    "}" +
                                    "else" +
                                    "{" +
                                        "sec = 60;" +
                                        "document.getElementById(" + quote + "showtime" + quote + ").innerHTML =" +
                                              msg +
                                         "tim = setTimeout(" + quote + "f2()" + quote + ", 1000);" +
                                   " }" +
                                "}" +

                            "}" +
                       "}";

        }
    }

    public class Color
    {
        public static string rojoSteel = "#C0504D";
        public static string azulito2 = "#4F81BD";
        public static string negro = "#000000";
        public static string azulBarra = "#6390C5";
        public static string verdecitoClarito = "#9BBB59";
        public static string naranjita = "#E46C0A";
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

        public static string xAxis(string categories, bool crosshair, string title)
        {
            return "xAxis:[{fffordinal: true, categories:" + categories +
                ",crosshair: " + crosshair.ToString().ToLower() +
                ",title:{text: '" + title + "'}}]";
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

        public static string series(string serie1, string serie2, string symbol)
        {
            return "series:" +
                "[{" +
                        "name: 'Overall Equipment Eficciency'," +
                        "type: 'column'," +
                        "yAxis:0," +
                        "color: '#6390C5'," +
                        "data:" + serie1 + "," +
                        "tooltip: { valueSuffix: ' " + symbol + "' }" +
                    "}," +
                    "{" +
                        "name: 'Processed Tons'," +
                        "type: ''," +
                        "yAxis: 1," +
                        "color: 'rgba(44, 62, 80,1.0)'," +
                        "data: " + serie2 + "," +
                        "tooltip: { valueSuffix: ' Tons' }" +
                    "}]";
        }

        public static string serieXDefine(string serieName, string serie1, string color,
            string symbol)
        {
            return "series:" +
                "[{" +
                        "name: '" + serieName + "'," +
                        "type: ''," +
                        "yAxis:0," +
                        "color: '" + color + "'," +
                        "dashStyle:'Dot'," +
                        "data:" + serie1 + "," +
                        "tooltip: { valueSuffix: ' " + symbol + "' }" +
                    "}]";

        }

        public static string serie(string serie1, string name, string color)
        {
            return "series:" +
             "[" +
               "{" +
                "name: '" + name + "'," +
                    "marker:" +
                "{" +
                    "enabled: true," +
                    "}," +
                    "color: '" + color + "'," +
                    "dashStyle: 'Dot'," +
                    "data: " + serie1 +
                "}]";
        }

        public static string legend = "legend: { enabled: false, layout: 'vertical', align: 'right', verticalAlign: 'top', y: 60, navigation: { activeColor: '#3E576F', animation: true, arrowSize: 10, inactiveColor: '#CCC', style: { fontWeight: 'bold', color: '#333', fontSize: '12px' } } }";

        public static string xyAxis(string xTitle, string yTitle, string sign)
        {
            return "xAxis: [{fffordinal: true,crosshair: false,title:{ text: '" + xTitle + "'}}], " +
               "yAxis:{title: { text: ' " + yTitle + "' }, " +
               "labels: { formatter: function() { return this.value + ' " + sign + "'; }} }, " +
               "plotOptions: {spline: {marker:{ radius: 6, lineWidth: 1 }}} ";

        }

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

        public static string FormatCategories(Dictionary<string, string> Data)
        {
            //string categorias = "['44','45','46','47','48','49','50','51']";
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

        public static string FormatDataSerie2(Dictionary<string, string> Data)
        {
            //string serie2 = "[1000, 1050, 2000, 2050, 3000, 3050, 4000, 4050]";
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

        public static string FormatDataSerie1(Dictionary<string, string> Data, string color)
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
