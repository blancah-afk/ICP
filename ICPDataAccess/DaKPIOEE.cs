using ICPDataModel;
using DataTools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ICPDataAccess
{
    public class DaKPIOEE
    {
        SqlAccess sql = new SqlAccess();

        //public bool AsyncUpdProductionStatus(string stStartDate, string stEndDate)
        //{
        //    DmProcess dm = new DmProcess();
        //    SqlParameters param = new SqlParameters();

        //    dm.Process = "0001";
        //    dm.StartDate = Convert.ToDateTime(stStartDate);
        //    dm.StartDate = Convert.ToDateTime(stStartDate);

        //    return sql.AsynUpdProductionStatus_KPI(SqlStoredProcedures.SW_SP_KPIProdStatusUPD,
        //        param.pKPIProdStatus(dm));

        //}

        public DataSet ds_KPIOEE()
        {
            DataSet ds = new DataSet();
            ds = sql.GetBySQL(SqlStoredProcedures.SW_SP_KPIOEE);
            return ds;
        }

        public List<DmProductionStatus> lst_ProductionStatus(string strConsulta)
        {
            DataSet InfoList = new DataSet();
            DmProductionStatus res = new DmProductionStatus();
            List<DmProductionStatus> lres = new List<DmProductionStatus>();

            InfoList = sql.GetBySQL(SqlStoredProcedures.SW_SP_KPIOEE);

            try
            {
                foreach (DataRow renglon in InfoList.Tables[1].Rows)
                {
                    res = new DmProductionStatus();
                    res.ProdWeek = Convert.ToInt32((renglon["ProdWeek"].Equals(DBNull.Value)
                        ? "0" : renglon["ProdWeek"].ToString()));
                    res.Data1 = decimal.Parse((renglon["OEE"].Equals(DBNull.Value)
                        ? "0" : renglon["OEE"].ToString()));
                    res.Data2 = decimal.Parse((renglon["ProcessedTons"].Equals(DBNull.Value)
                      ? "0" : renglon["ProcessedTons"].ToString()));
                    lres.Add(res);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ICPLabels.lblErrorMsg + ex.Message, ex);
            }
            return lres;
        }

        public void _ICPOEEData(out Dictionary<string, string> lstSerie1, out Dictionary<string, string> lstSerie2)
        {

            lstSerie1 = new Dictionary<string, string>();
            lstSerie2 = new Dictionary<string, string>();

            List<DmProductionStatus> lstOEE = new List<DmProductionStatus>();

            lstOEE = lst_ProductionStatus("");

            foreach (var item in lstOEE)
            {
                lstSerie1.Add(Convert.ToString(item.ProdWeek), item.Data1.ToString());
            }

            foreach (var item in lstOEE)
            {
                lstSerie2.Add(Convert.ToString(item.ProdWeek), item.Data2.ToString());
            }

        }


        #region consultaOEE

        public int i_CreateReport(DateTime stStartDate, DateTime stEndDate)
        {
            DataSet ds = new DataSet();
            DmProcess dm = new DmProcess();
            SqlParameters param = new SqlParameters();
            int idReport = 0;

            dm.Process = "0001";
            dm.StartDate = stStartDate;
            dm.EndDate = stEndDate;
            dm.Consulta = SqlParameters.Insert;

            ds = sql.GetBySQL(SqlStoredProcedures.KPIOEEConsulta, param.pKPIConsulta(dm));
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    idReport = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                }
            }
            return idReport;
        }

        public DataSet ds_UpdQuery(int idConsulta, DateTime stStartDate, DateTime stEndDate)
        {
            DataSet ds = new DataSet();
            DmProcess dm = new DmProcess();
            SqlParameters param = new SqlParameters();

            dm.Process = "0001";
            dm.StartDate = stStartDate;
            dm.EndDate = stEndDate;
            dm.Consulta = SqlParameters.Update;
            dm.idConsulta = idConsulta;

            ds = sql.GetBySQL(SqlStoredProcedures.KPIOEEConsulta, param.pKPIConsulta(dm));
            return ds;
        }

        public bool b_QueryReady(int idConsulta, DateTime stStartDate, DateTime stEndDate)
        {
            bool ready = false;
            DataSet ds = new DataSet();
            DmProcess dm = new DmProcess();
            SqlParameters param = new SqlParameters();

            dm.Process = "0001";
            dm.StartDate = stStartDate;
            dm.EndDate = stEndDate;
            dm.Consulta = SqlParameters.Select;
            dm.idConsulta = idConsulta;

            ds = sql.GetBySQL(SqlStoredProcedures.KPIOEEConsulta, param.pKPIConsulta(dm));
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ready = Convert.ToBoolean(ds.Tables[0].Rows[0][0]);
                }

            }
            return ready;
        }

        #endregion

    }
}
