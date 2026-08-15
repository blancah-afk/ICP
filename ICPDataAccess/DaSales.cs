using ICPDataModel;
using DataTools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace ICPDataAccess
{
    public class DaSales
    {
        SqlAccess da = new SqlAccess();

        public bool validDS(DataSet ds)
        {
            bool valid = false;
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    valid = true;
                }
            }

            return valid;
        }

        public List<LoadByResourceGRP> LoadByResourceGRP()
        {
         
            DataSet ds = da.GetBySQL(SqlStoredProcedures.SW_SP_PCILoadByResourceGRP);
            List<LoadByResourceGRP> lst = new List<LoadByResourceGRP>();
            if (validDS(ds))
            {
                lst = ICPDataModel.LoadByResourceGRP.map(ds.Tables[0]).ToList();

                //lst = (from rw in ds.Tables[0].AsEnumerable()
                //       select new LoadByResourceGRP()
                //       {
                //           Process = Convert.ToString(rw["Process"]),
                //           ResourceGroup = Convert.ToString(rw["ResourceGroup"]),
                //           MaxVersion = Convert.ToInt32(rw["MaxVersion"]),
                //           Week = Convert.ToInt32(rw["Week"]),
                //           CapacityHrs = Convert.ToInt32(rw["CapacityHrs"]),
                //           ScheduledHrs = Convert.ToInt32(rw["ScheduledHrs"]),
                //           MaxCreateDate = Convert.ToDateTime(rw["MaxCreateDate"])
                //       }).ToList();
            }

            return lst;
        }


        private void _ICPOEEData(out Dictionary<string, string> lstSerie1, out Dictionary<string, string> lstSerie2,
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
    }
}
