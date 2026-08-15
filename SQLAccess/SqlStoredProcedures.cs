using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLAccess
{
    public class SqlStoredProcedures
    {

        public static string spPCIGetMenuItems = "SW_SP_PCIGetMenuItems";
        public static string spProdStatus = "SW_SP_PCIProductionStatus";
        public static string spShipmentDetails = "sp_ShippedQtyGraph";
        public static string SW_SP_PCILoadByResourceGRP = "SW_SP_PCILoadByResourceGRP";
        public static string SW_SP_KPIProdStatusUPD = "SW_SP_KPIProdStatusUPD";
        public static string SW_SP_KPIOEE = "SW_SP_KPIOEE";
        public static string KPIOEEConsulta = "SW_SP_KPIOEEConsulta";
        public static string KPIReport = "SW_SP_KPIReport";
    }
}
