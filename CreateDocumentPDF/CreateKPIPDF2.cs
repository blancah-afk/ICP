using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace CreateDocumentPDF
{
    public class CreateKPIPDF2
    {
        DaKPIReport2 da = new DaKPIReport2();

        public void CreateFileKPI(string dirFileName, int iYear, int iPeriod)
        {
            MemoryStream ms = _ms(iYear, iPeriod);
            byte[] newBuffer;
            newBuffer = ms.ToArray();

            File.WriteAllBytes(dirFileName, newBuffer);
        }


        private MemoryStream _ms(int iYear, int period)
        {

            MemoryStream memoryStream = new MemoryStream();

            Document document = new Document(PageSize.A9, 10f, 10f, 10f, 0f);
            document.SetPageSize(PageSize.A3.Rotate());

            DataSet dsCategories = da.ds_KPIReport("KPICategories", null, null, Convert.ToInt32(iYear));
            DataSet ds = new DataSet();
            ds = da.ds_KPIReport("KPIComment", null, null, Convert.ToInt32(iYear));

            DataTable dt = ds.Tables[0];
            DataTable dtComment = da.dt_dataSource(dt, period);



            ds = da.ds_KPIReport("TopFive", null, null, Convert.ToInt32(iYear));

            DataTable dtT5 = ds.Tables[0];
            DataTable dtl = ds.Tables[1];
            DataTable dtTopFive = da.dt_dataSource(dtl, period);


            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
            PdfPTable table = null;
            document.Open();

            //Header
            table = TB_Header(writer, document, iYear, period);
            document.Add(table);

            //Datos
            table = TB_KPI(dsCategories, iYear, period);
            document.Add(table);
            document.NewPage();
            table = TB_Header(writer, document, iYear, period);
            document.Add(table);
            table = TB_Comment(dtComment, iYear, period);
            document.Add(table);
            table = TB_TopFive(dtTopFive, iYear, period);
            document.Add(table);
            table = TB_Exp(dsCategories, iYear, period);
            document.Add(table);
            document.Close();

            return memoryStream;


        }


        private PdfPTable TB_KPI(DataSet dsCategories, int iYear, int period)
        {
            PdfPTable table = null;
            PdfPCell cell = null;
            ExportFile export = new ExportFile();

            table = new PdfPTable(19);
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            table.WidthPercentage = 95;
            table.SetWidths(new float[] { 50f, 200f, 200f, 120f, 120f, 100f, 100f, 100f, 100f, 100f, 100f, 100f, 100f, 100f,
                100f, 100f, 100f, 100f, 120f });
            table.SpacingBefore = 30f;

            //Headers
            List<string> lst = export.lstHeaders(iYear);
            foreach (string i in lst)
            {
                cell = DataCell(i.ToString(), Element.ALIGN_LEFT, "Header", 10);
                table.AddCell(cell);
            }

            //Datos
            foreach (DataRow dr in dsCategories.Tables[0].Rows)
            {
                //Category
                int idCategory = Convert.ToInt32(dr["IDCategory"].ToString());
                string strCategory = dr["Category"].ToString();
                DataSet ds = da.ds_KPIReport("KPISubCategories", idCategory, null, iYear);

                cell = DataCell(strCategory, Element.ALIGN_LEFT, "Header", 14);
                cell.Colspan = 19;
                table.AddCell(cell);

                //Subcategoria
                foreach (DataRow drSub in ds.Tables[0].Rows)
                {
                    int idSubCategory = Convert.ToInt32(drSub["IDSubCategory"].ToString());
                    DataSet dsKPIDeatil = da.ds_KPIReportDtl("Detalle", idCategory, idSubCategory, iYear);

                    cell = DataCell(drSub["SubCategory"].ToString(), Element.ALIGN_LEFT, "Header", 12);
                    cell.Colspan = 19;
                    table.AddCell(cell);

                    //Detalle
                    foreach (DataRow drDet in dsKPIDeatil.Tables[0].Rows)
                    {
                        string IDKpi = drDet["ID"].ToString();
                        string strDataType = drDet["DataType"].ToString();
                        string UpdMethod = drDet["KPIUpdateMethod"].ToString();
                        string Name = drDet["Name"].ToString();

                        cell = DataCell(drDet["OrderColumn"].ToString(), Element.ALIGN_CENTER, "", 10);
                        cell.Rowspan = 2;
                        table.AddCell(cell);

                        cell = DataCell(Name, Element.ALIGN_CENTER, "", 10);
                        cell.Rowspan = 2;
                        cell.Colspan = 2;
                        table.AddCell(cell);

                        cell = DataCell(export.str_DataFormat(strDataType, IDKpi, drDet["PrevYearResult"].ToString(), UpdMethod, 0), Element.ALIGN_CENTER, "", 10);// El valor del año pasado
                        cell.Rowspan = 2;
                        table.AddCell(cell);

                        cell = DataCell(export.str_DataFormat(strDataType, IDKpi, drDet["CurrentYearGoal"].ToString(), UpdMethod, 0), Element.ALIGN_CENTER, "", 10);//EL valor de la meta actual
                        cell.Rowspan = 2;
                        table.AddCell(cell);

                        //Plan

                        if (IDKpi == "1" || IDKpi == "2" || IDKpi == "3")
                        {
                            cell = DataCell("Prior", Element.ALIGN_CENTER, "", 10);
                            table.AddCell(cell);
                        }
                        else
                        {
                            cell = DataCell("Plan", Element.ALIGN_CENTER, "", 10);
                            table.AddCell(cell);
                        }


                        for (int i = 1; i <= 12; i++)
                        {
                            string ColName = "Planning" + i.ToString();
                            string ColNameUpdMethod = "UpdateMethod" + i.ToString();
                            string strValueFormat = "";
                            string strValue = drDet[ColName].ToString();

                            strValueFormat = export.str_DataFormat(strDataType, IDKpi, strValue, drDet[ColNameUpdMethod].ToString(), 0);

                            cell = DataCell(strValueFormat, Element.ALIGN_CENTER, "", 10);
                            table.AddCell(cell);
                        }


                        string PTgtYTD = export.str_DataFormat(strDataType, IDKpi, drDet["PTgtYTD"].ToString(), drDet["PTgtYTD"].ToString(), 0);
                        cell = DataCell(PTgtYTD, Element.ALIGN_CENTER, "", 10);
                        table.AddCell(cell);

                        //Actual
                        cell = DataCell("Actual", Element.ALIGN_CENTER, "", 10);
                        table.AddCell(cell);

                        for (int i = 1; i <= 12; i++)
                        {
                            string ColName = "Actual" + i.ToString();
                            string ColNameUpdMethod = "UpdateMethod" + i.ToString();
                            string colNameRange = "KPIRange" + i.ToString();
                            string strValueFormat = "";
                            string strRange = drDet[colNameRange].ToString();
                            string strValue = drDet[ColName].ToString();

                            strValueFormat = export.str_DataFormat(strDataType, IDKpi, strValue, drDet[ColNameUpdMethod].ToString(), 0);

                            cell = DataCell(strValueFormat, Element.ALIGN_CENTER, strRange, 10);
                            table.AddCell(cell);
                        }

                        string ATgtYTD = export.str_DataFormat(strDataType, IDKpi, drDet["ATgtYTD"].ToString(), drDet["ATgtYTD"].ToString(), 0);
                        cell = DataCell(ATgtYTD, Element.ALIGN_CENTER, "", 10);
                        table.AddCell(cell);

                    }
                }

            }

            return table;
        }

        private PdfPTable TB_Header(PdfWriter writer, Document document, int iYear, int period)
        {
            PdfPTable table = null;
            PdfPCell cell = null;
            ExportFile ex = new ExportFile();

            //Header Table
            table = new PdfPTable(2);
            table.WidthPercentage = 95;
            table.SetWidths(new float[] { 500f, 500f });

            System.Globalization.DateTimeFormatInfo mfi = new
            System.Globalization.DateTimeFormatInfo();
            string strMonthName = mfi.GetMonthName(period).ToString();
            string strYear = iYear.ToString();
            string strTitle = "Key Performance Indicator(KPI) Report\nLocation SWM México Report From: ";

            cell = ex.PhraseCell(new Phrase(strTitle + strMonthName + strYear, FontFactory.GetFont("Arial", 14,
            //cell = ex.PhraseCell(new Phrase(strTitle + strMonthName + "2023", FontFactory.GetFont("Arial", 14,
                iTextSharp.text.Font.BOLD, BaseColor.BLACK)), Element.ALIGN_LEFT);
            cell.Rowspan = 2;
            cell.VerticalAlignment = Element.ALIGN_TOP;

            table.AddCell(cell);

            cell = ex.PhraseCell(new Phrase(" 2024 " + strMonthName, FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK)), Element.ALIGN_RIGHT);
            cell.VerticalAlignment = Element.ALIGN_TOP;

            cell = ex.PhraseCell(new Phrase("Print Date/Time: " + DateTime.Now.ToString(),
              FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)), Element.ALIGN_RIGHT);
            cell.VerticalAlignment = Element.ALIGN_TOP;

            table.AddCell(cell);
            //Separater Line
            DrawLine(writer, 25f, document.Top - 40f, document.PageSize.Width - 25f, document.Top - 40f);

            return table;
        }

        private PdfPTable TB_Comment(DataTable dt, int iYear, int period)
        {
            PdfPTable table = null;
            PdfPCell cell = null;
            ExportFile export = new ExportFile();

            table = new PdfPTable(2);
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            table.WidthPercentage = 95;
            table.SetWidths(new float[] { 300f, 300f });
            table.SpacingBefore = 30f;

            foreach (DataRow dr in dt.Rows)
            {
                string strName = dr["Name"].ToString();
                string Good = dr["CommentaryGood"].ToString();
                string Bad = dr["CommentaryBad"].ToString();

                cell = DataCell(strName, Element.ALIGN_LEFT, "Header", 12);
                cell.Colspan = 2;
                table.AddCell(cell);

                cell = DataCell(Good, Element.ALIGN_LEFT, "", 10);
                table.AddCell(cell);

                cell = DataCell(Bad, Element.ALIGN_LEFT, "", 10);
                table.AddCell(cell);

            }

            return table;
        }

        private PdfPTable TB_TopFive(DataTable dt, int iYear, int period)
        {
            PdfPTable table = null;
            PdfPCell cell = null;
            ExportFile export = new ExportFile();

            table = new PdfPTable(4);
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            table.WidthPercentage = 95;
            table.SetWidths(new float[] { 300f, 300f, 300f, 300f });
            table.SpacingBefore = 30f;
            cell = DataCell("7. Top five lowest margin customers in the last quarter with significant volume"
                + " - discussion on plans moving forward", Element.ALIGN_LEFT, "Header", 14);
            cell.Colspan = 4;
            table.AddCell(cell);

            cell = DataCell("Customer", Element.ALIGN_LEFT, "Header", 12);
            table.AddCell(cell);

            cell = DataCell("CM %", Element.ALIGN_LEFT, "Header", 12);
            table.AddCell(cell);

            cell = DataCell("Tons", Element.ALIGN_LEFT, "Header", 12);
            table.AddCell(cell);

            cell = DataCell("Comments", Element.ALIGN_LEFT, "Header", 12);
            table.AddCell(cell);

            foreach (DataRow dr in dt.Rows)
            {
                cell = DataCell(dr["Customer"].ToString(), Element.ALIGN_LEFT, "", 10);
                table.AddCell(cell);

                cell = DataCell(dr["CMPercentage"].ToString(), Element.ALIGN_LEFT, "", 10);
                table.AddCell(cell);

                cell = DataCell(dr["Tons"].ToString(), Element.ALIGN_LEFT, "", 10);
                table.AddCell(cell);

                cell = DataCell(dr["Comments"].ToString(), Element.ALIGN_LEFT, "", 10);
                table.AddCell(cell);
            }

            return table;
        }

        private PdfPTable TB_Exp(DataSet dsCategories, int Iyear, int Period)
        {
            DataSet dsrptExpDet = new DataSet();
            dsrptExpDet = da.ds_KPIReport("rptExpDet", null, null, Convert.ToInt32(Iyear));
            DataTable dt = da.dt_dataSource(dsrptExpDet.Tables[0], Period);

            PdfPTable table = null;
            PdfPCell cell = null;

            table = new PdfPTable(2);
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            table.WidthPercentage = 95;
            table.SetWidths(new float[] { 300f, 300f });
            table.SpacingBefore = 30f;

            //Datos
            int idCategory = 0;
            foreach (DataRow dr in dsCategories.Tables[0].Rows)
            {
                idCategory = Convert.ToInt32(dr["IDCategory"].ToString());
                DataSet ds = da.ds_KPIReport("KPISubCategories", idCategory, null, Convert.ToInt32(Iyear));

                cell = DataCell(dr["Category"].ToString(), Element.ALIGN_LEFT, "Header", 14);
                cell.Colspan = 2;
                table.AddCell(cell);

                //Subcategoria
                foreach (DataRow drSub in ds.Tables[0].Rows)
                {

                    int idSubCategory = Convert.ToInt32(drSub["IDSubCategory"].ToString());
                    DataTable dtSource = da.dt_dataSourceDet(dt, idCategory, idSubCategory);

                    cell = DataCell(drSub["SubCategory"].ToString(), Element.ALIGN_LEFT, "Header", 12);
                    cell.Colspan = 2;
                    table.AddCell(cell);

                    //Detalle
                    if (dtSource.Rows.Count > 0)
                    {
                        cell = DataCell("Explanation of Performance Gaps", Element.ALIGN_LEFT, "Header", 12);
                        table.AddCell(cell);

                        cell = DataCell("Activities to Close Gaps", Element.ALIGN_LEFT, "Header", 12);
                        cell.Colspan = 2;
                        table.AddCell(cell);

                        foreach (DataRow drDet in dtSource.Rows)
                        {
                            cell = DataCell(drDet["Name"].ToString(), Element.ALIGN_LEFT, "", 10);
                            cell.Colspan = 2;
                            table.AddCell(cell);

                            cell = DataCell(drDet["ExplanationOfPerformanceGaps"].ToString(), Element.ALIGN_LEFT, "", 10);
                            table.AddCell(cell);

                            cell = DataCell(drDet["ActivitiesToCloseGaps"].ToString(), Element.ALIGN_LEFT, "", 10);
                            table.AddCell(cell);
                        }
                    }
                    else
                    {
                        cell = DataCell(" - ", Element.ALIGN_LEFT, "", 12);
                        cell.Colspan = 2;
                        table.AddCell(cell);
                    }

                }

            }

            return table;
        }

        private static void DrawLine(PdfWriter writer, float x1, float y1, float x2, float y2)
        {
            PdfContentByte contentByte = writer.DirectContent;
            BaseColor color = null;
            color = new BaseColor(166, 166, 166);
            contentByte.SetColorStroke(color);
            contentByte.MoveTo(x1, y1);
            contentByte.LineTo(x2, y2);
            contentByte.Stroke();
        }

        private static PdfPCell DataCell(string Texto, int align, string strRange, int iFontSize)
        {
            //Format DataCells
            PdfPCell cell = null;
            BaseColor color = null;

            if (strRange == "Header")
            {
                cell = new PdfPCell(new Phrase(Texto, FontFactory.GetFont("Arial", iFontSize, Font.BOLD, BaseColor.BLACK)));
            }
            else
            {
                cell = new PdfPCell(new Phrase(Texto, FontFactory.GetFont("Arial", iFontSize, Font.NORMAL, BaseColor.BLACK)));
            }

            color = new BaseColor(166, 166, 166);

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
                    cell.BackgroundColor = new BaseColor(0, 128, 0);
                    break;
                case "Below":
                    cell.BackgroundColor = BaseColor.RED;
                    break;
                case "Within":
                    cell.BackgroundColor = BaseColor.YELLOW;
                    break;
                case "Preview":
                    cell.BackgroundColor = new BaseColor(134, 195, 246);
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


public class ExportFile
{
    public string row = "<tr>";
    public string endrow = ("</tr>");
    public string col = "<td>";
    public string endcol = ("</td>");
    public string salto = "<tr><td></td></tr>";

    public string strCellStyle(string Texto)
    {
        return row + "<td colspan=\"18\" style=\"font-size:18px; background-color: #a6a6a6; color:white\">" + Texto + endcol + endrow;
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

                switch (i.ToString())
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
        strbn.Append(cellStyle + "Location SW Mexico 2020. Report From: " + strMonth + " " + strYear + endcol);
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
                else
                {
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
                        strNewValue = String.Format(strPerc, value);
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

    public string str_ValueRange(double value)
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
        list.Add("2023 Result");
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
    protected List<string> lstHeaders(int iYear)
    {

        List<string> list = new List<string>();

        list.Add("No.");
        list.Add("Measure");
        list.Add("");
        list.Add((iYear - 1).ToString() + " Result");
        list.Add(iYear + " GOAL");
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
        list.Add("VolumenMT Sold");
        list.Add("VolumenMT Paid");
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



    public PdfPCell PhraseCell(Phrase phrase, int align)
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
