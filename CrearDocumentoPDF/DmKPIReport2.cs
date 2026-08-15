using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrearDocumentoPDF
{
    public class ICPLabels2
    {
        public static string lblErrorMsg = "Error Msg: ";
        public static string lblRArea = "ResponsibleArea";
        public static string UpdMethod = "UpdateMethod";
        public static string KPIRange = "KPIRange";
        public static string Actual = "Actual";
        public static string Planning = "Planning";


    }
    public class DmProcess2
    {
        public static string Temper = "0001";

        public int idConsulta { get; set; }
        public string Process { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Consulta { get; set; }
    }

    public class DmKPIReport2
    {

        public string Consulta { get; set; }

        public string Company { get; set; }
        public string Category { get; set; }
        public int? IDCategory { get; set; }
        public int? IDSubCategory { get; set; }
        public string KPIUpdateMethod { get; set; }

        public int? OrderColumn { get; set; }
        public int? ID { get; set; }
        public string Operator { get; set; }
        public string Name { get; set; }
        public string ResponsibleArea { get; set; }
        public string DataType { get; set; }
        public double? PrevYearResult { get; set; }
        public double? CurrentYearGoal { get; set; }
        public double? Planning { get; set; }
        public double? Actual { get; set; }
        public double? Period { get; set; }
        public string KPIRange { get; set; }

        public string RangeRisk_PrevYearResult { get; set; }
        public string RangeRisk_CurrentYearGoal { get; set; }

        public string RangeRiskPeriodPlan { get; set; }
        public string RangeRiskPeriodActual { get; set; }
        public string UpdateMethod { get; set; }

        public string YTDPlan { get; set; }
        public string ToolTipPlan { get; set; }
        public string YTDActual { get; set; }
        public string ToolTipActual { get; set; }



        public static string lblConsulta = "Consulta";
        public static string lblCategory = "Category";
        public static string lblIDCategory = "IDCategory";

        //public static int? IDSubCategory { get; set; }

        //public static int? OrderColumn { get; set; }
        //public static int? ID { get; set; }
        //public static string Operator { get; set; }
        //public static string Name { get; set; }
        //public static string ResponsibleArea { get; set; }
        //public static string DataType { get; set; }
        //public static double? PrevYearResult { get; set; }
        //public static double? CurrentYearGoal { get; set; }
        //public static double? Planning { get; set; }
        //public static double? Actual { get; set; }
        //public static double? Period { get; set; }
        //public static string KPIRange { get; set; }

        //public static string RangeRisk_PrevYearResult { get; set; }
        //public static string RangeRisk_CurrentYearGoal { get; set; }

        //public static string RangeRiskPeriodPlan { get; set; }
        //public static string RangeRiskPeriodActual { get; set; }
    }
}
