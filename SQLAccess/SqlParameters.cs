using ICPDataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SQLAccess
{
    public class SqlParameters
    {

        #region constantes
        public static string Update = "UPD";
        public static string Insert = "INS";
        public static string Select = "SEL";
        #endregion

        #region PCI
        public SqlParameter[] grdParam(TruckTracker t)
        {

            List<SqlParameter> parameters = new List<SqlParameter>
            {

                new SqlParameter("@PackNum", SqlDbType.VarChar, 50) { Value = t.PackNum},
                new SqlParameter("@TruckID", SqlDbType.VarChar, 50) { Value = t.TruckID},
                new SqlParameter("@FreightInvoice", SqlDbType.VarChar, 50) { Value = t.FreightInvoice},

             };

            return parameters.ToArray();
        }

        public SqlParameter[] grdParamTemper()
        {

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@RscGrpId", SqlDbType.VarChar, 50) { Value = "0001"},
                new SqlParameter("@StartDate", SqlDbType.VarChar, 50) { Value = ""},
                new SqlParameter("@EndDate", SqlDbType.VarChar, 50) { Value = ""},
                new SqlParameter("@Status", SqlDbType.VarChar, 50) { Value = ""},

             };

            return parameters.ToArray();
        }

        public SqlParameter[] grdPCIProdStatus(string strConsulta)
        {

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Consulta", SqlDbType.VarChar, 50) { Value = strConsulta},


             };

            return parameters.ToArray();
        }

        public SqlParameter[] paramPCIGetMenuItems(int menuID, string pageName, string consulta)
        {

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@MenuId", SqlDbType.VarChar, 50) { Value = menuID},
                new SqlParameter("@PageName", SqlDbType.VarChar, 50) { Value = pageName},
                new SqlParameter("@Consulta", SqlDbType.VarChar, 50) { Value = consulta},

             };

            return parameters.ToArray();
        }

        public SqlParameter[] shipParam(string StartDate, string EndDate)
        {

            List<SqlParameter> parameters = new List<SqlParameter>
            {

                new SqlParameter("@StartDate", SqlDbType.VarChar, 50) { Value = StartDate},
                new SqlParameter("@EndDate", SqlDbType.VarChar, 50) { Value = EndDate},
                new SqlParameter("@Average", SqlDbType.VarChar, 50) { Value = "0.0"},
                new SqlParameter("@SumMT", SqlDbType.VarChar, 50) { Value = "0.0"},
                new SqlParameter("@SumDemand", SqlDbType.VarChar, 50) { Value = "0.0"},


        };

            return parameters.ToArray();
        }

        #endregion

        #region KPI
        public SqlParameter[] pKPIProdStatus(DmProcess dm)
        {

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@IdConsulta", SqlDbType.VarChar, 50) { Value = dm.idConsulta},
                new SqlParameter("@Process", SqlDbType.VarChar, 50) { Value = dm.Process},
                new SqlParameter("@StartDate", SqlDbType.Date, 50) { Value = dm.StartDate},
                new SqlParameter("@EndDate", SqlDbType.Date, 50) { Value = dm.EndDate},

             };

            return parameters.ToArray();
        }

        public SqlParameter[] pKPIConsulta(DmProcess dm)
        {

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@IdConsulta", SqlDbType.Int, 50) { Value = dm.idConsulta},
                new SqlParameter("@Process", SqlDbType.VarChar, 50) { Value = dm.Process},
                new SqlParameter("@StartDate", SqlDbType.Date, 50) { Value = dm.StartDate},
                new SqlParameter("@EndDate", SqlDbType.Date, 50) { Value = dm.EndDate},
                new SqlParameter("@Consulta", SqlDbType.VarChar, 50) { Value = dm.Consulta},

             };

            return parameters.ToArray();
        }

        public SqlParameter[] pKPIReport(DmKPIReport dm)
        {

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Consulta", SqlDbType.VarChar, 50) { Value = dm.Consulta},
                new SqlParameter("@IDCategory", SqlDbType.Int, 50) { Value = dm.IDCategory},
                 new SqlParameter("@IDSubCategory", SqlDbType.Int, 50) { Value = dm.IDSubCategory},


             };

            return parameters.ToArray();
        }

        public SqlParameter[] pKPIReport(DmKPIReport dm, int iYear)
        {

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Consulta", SqlDbType.VarChar, 50) { Value = dm.Consulta},
                new SqlParameter("@IDCategory", SqlDbType.Int, 50) { Value = dm.IDCategory},
                new SqlParameter("@IDSubCategory", SqlDbType.Int, 50) { Value = dm.IDSubCategory},
                new SqlParameter("@Year", SqlDbType.Int, 50) { Value = iYear},


             };

            return parameters.ToArray();
        }
    }
    #endregion

}
