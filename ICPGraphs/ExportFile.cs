using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace ICPGraphs
{

    public class ExportFile
    {
        public  string row = "<tr>";
        public  string endrow = ("</tr>");
        public  string col = "<td>";
        public  string endcol = ("</td>");
        public  string salto = "<tr><td></td></tr>";

        public string strCellStyle(string Texto)
        {
            return  row + "<td colspan=\"18\" style=\"font-size:18px; background-color: #a6a6a6; color:white\">" + Texto + endcol + endrow;
        }

        public string strAddHeaders()
        {
            StringBuilder strbn = new StringBuilder();
            string cellStyle = "<th style=\"background-color: #a6a6a6; border-style:solid; border-color:white; border-width: thin;\">";
            strbn.Append(row);

            List<string> lst = lstHeaders();

            foreach (string i in lst)
            {
                if (i.ToString() != "")
                { strbn.Append(cellStyle + i.ToString() + endcol); }
               

            }

            strbn.Append(endrow);

            return strbn.ToString();

        }

        public string strAddHeadersComision()
        { 

            StringBuilder strbn = new StringBuilder();
            string cellStyle = "<th style=\"background-color: #a6a6a6; border-style:solid; border-color:black; border-width: thin;\">";
            string cellStyleMargen = "<th style=\"background-color: #bdd7ee; border-style:solid; border-color:black; border-width: thin;\">";
            string cellStyleForecast = "<th style=\"background-color: #f8cbad; border-style:solid; border-color:black; border-width: thin;\">";
            string cellStyleInventario = "<th style=\"background-color: #ffd966; border-style:solid; border-color:black; border-width: thin;\">";
            string cellStyleTotal = "<th style=\"background-color: #ff0000; color: white; border-style:solid; border-color:black; border-width: thin;\">";
            strbn.Append(row);

            List<string> lst = lstHeadersCommision();

            foreach (string i in lst)
            {
                if (i.ToString() != "")
                {

                    switch(i.ToString())
                    {
                        case "Goal MT":
                            strbn.Append(cellStyleForecast + i.ToString() + endcol);
                            break;
                        case "% Cumplimiento":
                            strbn.Append(cellStyleForecast + i.ToString() + endcol);
                            break;
                        case "50%":
                            strbn.Append(cellStyleForecast + i.ToString() + endcol);
                            break;
                        case "En MXP":
                            strbn.Append(cellStyleMargen + i.ToString() + endcol);
                            break;
                        case "EN USD":
                            strbn.Append(cellStyleMargen + i.ToString() + endcol);
                            break;
                        case "50% ":
                            strbn.Append(cellStyleMargen + i.ToString() + endcol);
                            break;
                        case "10%":
                            strbn.Append(cellStyleInventario + i.ToString() + endcol);
                            break;
                        case "Factor Total":
                            strbn.Append(cellStyleTotal + i.ToString() + endcol);
                            break;
                        case "Comision a Pagar":
                            strbn.Append(cellStyleTotal + i.ToString() + endcol);
                            break;
                        default:
                            strbn.Append(cellStyle + i.ToString() + endcol);
                            break;

                    }
                }

            
               

            }

            strbn.Append(endrow);

            return strbn.ToString();

        }

        public string strAddHeaders(List<string> lstHeaders)
        {
            StringBuilder strbn = new StringBuilder();
            
            string cellStyle = "<th style=\"background-color: #a6a6a6; border-style:solid; border-color:white; border-width: thin;\">";
            strbn.Append(row);

            List<string> lst = lstHeaders;

            foreach (string i in lst)
            {
                if (i.ToString() != "")
                { strbn.Append(cellStyle + i.ToString() + endcol); }


            }

            strbn.Append(endrow);

            return strbn.ToString();

        }

        public string strAddTitle(string strYear, string strMonth)
        {
            StringBuilder strbn = new StringBuilder();
            string cellStyle = "<td colspan=\"4\" style=\"color: blue; font-weight: 600; font-size:18px\">";

            strbn.Append(row);
            strbn.Append("<td></td>");
            strbn.Append(cellStyle + "Key Performance Indicator (KPI) Report" + endcol);
            strbn.Append(endrow);
            strbn.Append(row);
            strbn.Append("<td></td>");
            strbn.Append(cellStyle + "Location SW Mexico 2020. Report From: " + strMonth + " " + strYear  + endcol);
            strbn.Append(endrow);


            return strbn.ToString();
        }

        public string strAddTitleComisiones(string strYear, string strMonth)
        {
            StringBuilder strbn = new StringBuilder();
            string cellStyle = "<td colspan=\"4\" style=\"color: blue; font-weight: 600; font-size:18px\">";

            strbn.Append(row);
            strbn.Append("<td></td>");
            strbn.Append(cellStyle + "Reporte de Calculo de Comisiones de Ventas" + endcol);
            strbn.Append(endrow);
            strbn.Append(row);
            strbn.Append("<td></td>");
            strbn.Append(cellStyle + "Location SW Mexico 2020. Report From: " + strMonth + " " + strYear + endcol);
            strbn.Append(endrow);


            return strbn.ToString();
        }

        public string strAddDetailKPI(DataSet ds)
        {
            StringBuilder strbn = new StringBuilder();
            string styleCell = "<td style=\"border: solid; border-width: thin; width: 5%; \">";
            string styleCellth = "<th rowspan =\"2\" style=\"border: solid; border-width: thin; \">";
            string styleCellth0 = "<th style=\"border: solid; border-width: thin; \">";

            foreach (DataRow drDet in ds.Tables[0].Rows)
            {
                string DataType = drDet["DataType"].ToString();
                string IDKpi = drDet["ID"].ToString();
                string UpdMethod = drDet["KPIUpdateMethod"].ToString();
                //string Name = drDet["Name"].ToString() + (drDet["KPIUpdateMethod"].ToString() == "Automatic" ? " **" : "");
                string Name = drDet["Name"].ToString();

                strbn.Append(row);
                strbn.Append(styleCellth + drDet["OrderColumn"].ToString() + "</th>");
                strbn.Append("<th rowspan = \"2\" style=\"font-size:14px; border: solid; border-width: thin;\">" + Name + "</th>");
                strbn.Append(styleCellth + drDet["PrevYearResult"].ToString() + "</th>");
                strbn.Append(styleCellth + drDet["CurrentYearGoal"].ToString() + "</th>");


                if (IDKpi == "1" || IDKpi == "2" || IDKpi == "3")
                {
                    strbn.Append(styleCellth0 + "Prior" + "</th>");
                }
                else
                {
                    strbn.Append(styleCellth0 + "Plan" + "</th>");
                }
                

                //INFO
               

                for (int i = 1; i <= 12; i++)
                {
                    string ColName = "Planning" + i.ToString();
                    string ColNameUpdM = "UpdateMethod" + i.ToString();
                    string strUpdM = drDet[ColNameUpdM].ToString();

                    string strValue = drDet[ColName].ToString();
                    strbn.Append(styleCell + str_DataFormat(DataType, IDKpi, strValue, strUpdM, 0) + endcol);
                }


                strbn.Append(styleCell + str_DataFormat(DataType, IDKpi, drDet["PTgtYTD"].ToString(), "", 0) + "</th>");
                strbn.Append(endrow);

                strbn.Append(row);
                strbn.Append(styleCellth0 + "Actual" + "</th>");
                //Actual

                for (int i = 1; i <= 12; i++)
                {
                    string ColName = "Actual" + i.ToString();
                    string ColNameUpdM = "UpdateMethod" + i.ToString();
                    string ColNameRange = "KPIRange" + i.ToString();

                    string strValue = drDet[ColName].ToString();
                    string strUpdM = drDet[ColNameUpdM].ToString();
                    string strRange = drDet[ColNameRange].ToString();

                    strbn.Append(str_DataRangeFormat(DataType, IDKpi, strValue, strUpdM, strRange));
                }


                strbn.Append(styleCell + str_DataFormat(DataType, IDKpi, drDet["ATgtYTD"].ToString(), "", 0) + "</th>");
                strbn.Append(endrow);

            }

            return strbn.ToString();
        }

        private string str_DataRangeFormat(string DataType, string idKPI, string strValue, string UpdateMethod, string strRange)
        {
            StringBuilder strbn = new StringBuilder();


            switch (strRange)
            {
                case "AtOrAbove":
                    strbn.Append("<td style = \" background-color:green;\" >" + str_DataFormat(DataType, idKPI, strValue, UpdateMethod, 0) + endcol);
                    break;

                case "Below":
                    strbn.Append("<td style = \" background-color:red;\">" + str_DataFormat(DataType, idKPI, strValue, UpdateMethod, 0) + endcol);
                    break;

                case "Within":
                    strbn.Append("<td style = \" background-color:yellow;\" >" + str_DataFormat(DataType, idKPI, strValue, UpdateMethod, 0) + endcol);
                    break;

                case "Preview":
                    strbn.Append("<td style = \" background-color:#86C3F6;\" >" + str_DataFormat(DataType, idKPI, strValue, UpdateMethod, 0) + endcol);

                    break;
                default:
                    strbn.Append("<td style = \" background-color:white;\" >" + str_DataFormat(DataType, idKPI, strValue, UpdateMethod, 0) + endcol);
                    break;

            }
            return strbn.ToString();

        }

        public string str_DataFormat(string type, double? value, bool factorComision)
        {
            string strPerc = "{0:0.0%}";
            string str = "";
           
            switch (type)
            {
                case "%":
                    if (factorComision)
                    {
                        str = String.Format("{0:0.00%}", value);
                    }
                    else {
                        str = String.Format(strPerc, value);
                    }
                    
                    break;
                case "":
                   str = String.Format("{0:#,#}", value);
                    
                    break;

                case "$":
                    str = String.Format("{0:C0}", value);
                    break;

            }

            return str;
           
        }

        public string str_DataFormat(string DataType, string idKPI, string strValue, string UpdateMethod, int iMonth)
        {
            //                      Formatear los valores, decimales, porcentajes o rangos de valor, deacuerdo con el
            //                          tipo de dato.
            string strNewValue = "";
            string strPerc = "{0:0.00%}";

            //if(iMonth == 7)
            //{
            //    if (idKPI == "4")
            //    {
            //        if (strValue == "0.026")
            //        {
            //            string s = "";
            //        }

            //    }
            //}
           
            if (strValue != "")
            {
                double value = Convert.ToDouble(strValue);
                switch (DataType)
                {

                    case "Percentage":
                        if (idKPI == "15")
                        {
                            strNewValue = str_ValueRange(value) + "(" + String.Format(strPerc, value) + ")";
                        }
                        if (idKPI == "16")
                        {
                            strPerc = "{0:0.000%}";
                            strNewValue =  String.Format(strPerc, value);
                        }
                        else
                        {
                            strNewValue = string.Format(strPerc, value);
                        }
                        break;

                    case "Fixed Value":

                        strNewValue = string.Format("{0:###,###,##0.00}", value);

                        break;

                    case "RangeValue":
                        if (idKPI == "15")
                        {
                            strNewValue = str_ValueRange(value) + " (" + String.Format(strPerc, value) + ")";
                        }
                        else
                        {
                            strNewValue = String.Format(strPerc, value);
                        }

                        break;
                }
            }

            //if (UpdateMethod == "Automatic")
            //{

            //    strNewValue = strNewValue + " **";
            //}
            return strNewValue;
        }

        public   string str_ValueRange(double value)
        {
            //                    Idicador Inventory Risk, ademas del porcentaje, se categoriza con letras de a la A, a la F
            //                          De acuerdo con el porcetaje. 
            string strValueRange = "";
            //CASE WHEN KPIP.PrevYearResult <= 0 AND KPIP.PrevYearResult >= -10   THEN 'A'
            //                    WHEN KPIP.PrevYearResult < -10 AND KPIP.PrevYearResult >= -20 THEN 'B'
            //                    WHEN KPIP.PrevYearResult < -20 AND KPIP.PrevYearResult >= -30 THEN 'C'
            //                    WHEN KPIP.PrevYearResult < -30 AND KPIP.PrevYearResult >= -45 THEN 'D'
            //                    WHEN KPIP.PrevYearResult < -45 THEN 'F' END end as RangeRisk_PrevYearResult,
            if (value >= 0 && value <= .10)
            {
                strValueRange = "A";
            }
            if (value > .10 && value <= .20)
            {
                strValueRange = "B";
            }
            if (value > .20 && value <= .30)
            {
                strValueRange = "C";
            }
            if (value > .30 && value <= .45)
            {
                strValueRange = "D";
            }
            if (value > .45)
            {
                strValueRange = "F";
            }


            return strValueRange;

        }

        public List<string> lstHeaders()
        {

            List<string> list = new List<string>();

            list.Add("No.");
            list.Add("Measure");
            list.Add("");
            list.Add("2023 A");
            list.Add("2024 GOAL");
            list.Add("P/A");
            list.Add("Jan");
            list.Add("Feb");
            list.Add("Mar");
            list.Add("Apr");
            list.Add("May");
            list.Add("June");
            list.Add("July");
            list.Add("Aug");
            list.Add("Sep");
            list.Add("Oct");
            list.Add("Nov");
            list.Add("Dec");
            list.Add("Tgt/YTD");


            return list;
        }

        public List<string> lstHeaders(string year,string lastYear)
        {

            List<string> list = new List<string>();

            list.Add("No.");
            list.Add("Measure");
            list.Add("");
            list.Add(lastYear + " A");
            list.Add(year + " GOAL");
            list.Add("P/A");
            list.Add("Jan");
            list.Add("Feb");
            list.Add("Mar");
            list.Add("Apr");
            list.Add("May");
            list.Add("June");
            list.Add("July");
            list.Add("Aug");
            list.Add("Sep");
            list.Add("Oct");
            list.Add("Nov");
            list.Add("Dec");
            list.Add("Tgt/YTD");


            return list;
        }
        public List<string> lstHeadersCommision()
        {
            List<string> list = new List<string>();
            list.Add("Num");
            list.Add("Vendedor/Detalle de Clientes");
            list.Add("Pagado Pendiente ");
            list.Add("Tipo");
            list.Add("Pagos en MXP");
            list.Add("Pagos en USD");
            list.Add("Volumen MT Sold");
            list.Add("Volumen MT Paid");
            list.Add("% del Total");
            list.Add("Factor Comision");
            list.Add("Monto Bruto Comision Generada");
            list.Add("Goal MT");
            list.Add("% Cumplimiento");
            list.Add("50%");
            list.Add("Margen MXP");
            list.Add("Margen USD");
            list.Add("En MXP");
            list.Add("EN USD");
            list.Add("50% ");
            list.Add("10%");
            list.Add("Factor Total");
            list.Add("Comision a Pagar");
            return list;
        }

        //Export Simple xls file
        public string strAddDetail(DataSet ds)
        {
            string cellStyle = "<td class=\"tdDet\" style=\"border:solid; border-width: .5px;\">";
            StringBuilder strbn = new StringBuilder();
            List<string> lst = PrintColumnNames(ds);
            strbn.Append(strAddHeaders(lst));

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                strbn.Append("<tr>");
                string CustPart = dr[3].ToString();
                CustPart = dr[3].ToString().Replace("\"", "\\\"");

                foreach (DataColumn dc in ds.Tables[0].Columns)
                {
                    strbn.Append(cellStyle + dr[dc].ToString().Replace("\"", "\\\"") + "</td>");
                }



                strbn.Append("</tr>");
            }

            return strbn.ToString();
        }

        #region PDF

        private static PdfPCell ImageCell(string path, float scale, int align)
        {
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));
            image.ScalePercent(scale);
            PdfPCell cell = new PdfPCell(image);
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = Element.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 5f;
            cell.PaddingTop = 5f;
            return cell;
        }

        public  PdfPCell PhraseCell(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = Element.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 2f;
            cell.PaddingTop = 0f;
            return cell;
        }


        #endregion

        //Nombre de columnas
        public List<string> PrintColumnNames(DataSet dataSet)
        {
            List<string> columnNames = new List<string>();
            // For each DataTable, print the ColumnName.
            foreach (DataTable table in dataSet.Tables)
            {
                foreach (DataColumn column in table.Columns)
                {
                    columnNames.Add(column.ColumnName);
                }
            }

            return columnNames;
        }

        
    }
}
