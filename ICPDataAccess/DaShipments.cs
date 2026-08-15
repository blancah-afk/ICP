using DataTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICPDataModel;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace ICPDataAccess
{
    public class DaShipments
    {

        SqlAccess da = new SqlAccess();
        public void ShipDetails(string StartDate, string EndDate,
           out Dictionary<string, string> lShippedQtyMT,
           out Dictionary<string, string> lDemandQtyMT,
           out Dictionary<string, string> lAvg,
           out Dictionary<string, string> lGoal)
        {

            lShippedQtyMT = new Dictionary<string, string>();
            lDemandQtyMT = new Dictionary<string, string>();
            lAvg = new Dictionary<string, string>();
            lGoal = new Dictionary<string, string>();

            SqlParameters p = new SqlParameters();

            List<DmShipment> lship = new List<DmShipment>();

            lship = lst_Shipment(p.shipParam(StartDate, EndDate));

            foreach (var item in lship)
            {
                lShippedQtyMT.Add(item.strDate, item.ShippedQtyMT.ToString());
                lDemandQtyMT.Add(item.strDate, item.DemandQtyMT.ToString());
                lAvg.Add(item.strDate, item.Avg.ToString());
                lGoal.Add(item.strDate, item.Goal.ToString());
            }

        }

        public List<DmShipment> lst_Shipment(SqlParameter[] parameters)
        {
            DataSet InfoList = new DataSet();
            string NameSPString = string.Empty;

            List<DmShipment> lres = new List<DmShipment>();
            DmShipment res = new DmShipment();


            InfoList = da.GetBySQL(SqlStoredProcedures.spShipmentDetails, parameters);

            try
            {
                foreach (DataRow renglon in InfoList.Tables[0].Rows)
                {
                    res = new DmShipment();
                    res.ShippedQtyMT = decimal.Parse((renglon["ShippedQtyMT"].Equals(DBNull.Value)
                        ? "0" : renglon["ShippedQtyMT"].ToString()));
                    res.DemandQtyMT = decimal.Parse((renglon["DemandQtyMT"].Equals(DBNull.Value)
                        ? "0" : renglon["DemandQtyMT"].ToString()));
                    res.Avg = decimal.Parse((renglon["Avg"].Equals(DBNull.Value)
                        ? "0" : renglon["Avg"].ToString()));
                    res.Goal = decimal.Parse((renglon["Goal"].Equals(DBNull.Value)
                        ? "0" : renglon["Goal"].ToString()));

                    res.strDate = ((DateTime.ParseExact(renglon["ShipDate"].ToString(),
                        "dd/MM/yy", CultureInfo.InvariantCulture) - DateTime.Parse("01-01-1970")).TotalSeconds * 1000).ToString();
                    lres.Add(res);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ICPLabels.lblErrorMsg + ex.Message, ex);
            }
            return lres;



        }

        public DataSet ds_TruckTracker( string sp ,TruckTracker truck )
        {
            DataSet ds = new DataSet();
            SqlAccess da = new SqlAccess();
            SqlParameters pSQL = new SqlParameters();

            DateTime dt = DateTime.Now;
            DateTime wkStDt = DateTime.MinValue;
            double DayOfWeek = (Convert.ToDouble(dt.DayOfWeek));
            wkStDt = dt.AddDays(1 - Convert.ToDouble(dt.DayOfWeek));
            DateTime FechaInicioDeSemana = wkStDt.Date;
            DateTime FechaFinDeSemana = FechaInicioDeSemana.AddDays(6);

            return ds = da.GetBySQL("sp_PCITruckTracker", pSQL.grdParam(truck));



        }

    }
}
