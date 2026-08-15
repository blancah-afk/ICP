using ICPDataModel;
using DataTools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ICPDataAccess
{
    public class DaProduction
    {
        DataSet InfoList = new DataSet();
        SqlParameters pSQL = new SqlParameters();
        SqlAccess da = new SqlAccess();

        #region Methods
        public void ICP_ProdStatusDtls(out Dictionary<string, string> lstProdStatusDtls, string strConsulta)
        {

            lstProdStatusDtls = new Dictionary<string, string>();

            List<DMTemperFisrtPassYield> lstTemperFPY = new List<DMTemperFisrtPassYield>();

            DaProduction da = new DaProduction();
            lstTemperFPY = da.lst_TemperFirstPassYield(strConsulta);

            foreach (var item in lstTemperFPY)
            {
                lstProdStatusDtls.Add(Convert.ToString(item.ProdWeek), item.FirtsPassYield.ToString());
            }

        }

        public void ICP_OEEData(out Dictionary<string, string> lstSerie1, out Dictionary<string, string> lstSerie2,
            string strConsulta)
        {

            lstSerie1 = new Dictionary<string, string>();
            lstSerie2 = new Dictionary<string, string>();

            List<DmProductionStatus> lstOEE = new List<DmProductionStatus>();

            DaProduction da = new DaProduction();
            lstOEE = da.lst_ProductionStatus(strConsulta);

            foreach (var item in lstOEE)
            {
                lstSerie1.Add(Convert.ToString(item.ProdWeek), item.Data1.ToString());
            }

            foreach (var item in lstOEE)
            {
                lstSerie2.Add(Convert.ToString(item.ProdWeek), item.Data2.ToString());
            }

        }
        #endregion

        public List<DMTemperFisrtPassYield> lst_TemperFirstPassYield(string strConsulta)
        {


            DMTemperFisrtPassYield res = new DMTemperFisrtPassYield();
            List<DMTemperFisrtPassYield> lres = new List<DMTemperFisrtPassYield>();

            InfoList = da.GetBySQL(SqlStoredProcedures.spProdStatus, pSQL.grdPCIProdStatus(strConsulta));

            try
            {
                foreach (DataRow renglon in InfoList.Tables[0].Rows)
                {
                    res = new DMTemperFisrtPassYield();
                    res.ProdWeek = Convert.ToInt32((renglon["ProdWeek"].Equals(DBNull.Value)
                        ? "0" : renglon["ProdWeek"].ToString()));
                    res.FirtsPassYield = decimal.Parse((renglon["Data"].Equals(DBNull.Value)
                        ? "0" : renglon["Data"].ToString()));
                    lres.Add(res);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ICPLabels.lblErrorMsg + ex.Message, ex);
            }
            return lres;
        }

        public List<DmProductionStatus> lst_ProductionStatus(string strConsulta)
        {
            DmProductionStatus res = new DmProductionStatus();
            List<DmProductionStatus> lres = new List<DmProductionStatus>();

            InfoList = da.GetBySQL(SqlStoredProcedures.spProdStatus, pSQL.grdPCIProdStatus(strConsulta));

            try
            {
                foreach (DataRow renglon in InfoList.Tables[0].Rows)
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
    }
}
