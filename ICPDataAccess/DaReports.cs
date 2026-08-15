using ICPDataModel;
using DataTools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
namespace ICPDataAccess
{
    public class DaReports
    {
        SqlAccess sql = new SqlAccess();

        public DataSet dsSalesLotDetails(int FiscalYear, int FiscalPeriod)
        {
            DataSet ds = new DataSet();
            SqlParameters p = new SqlParameters();

            ds = sql.GetBySQL(SqlStoredProcedures.RepBOSalesLotDetails, p.ParamBO(FiscalYear, FiscalPeriod));
            return ds;
        }

        public DataSet dsSalesProfitDashboardMaterial(DateTime StartDate, DateTime EndDate)
        {
            DataSet ds = new DataSet();
           
            SqlParameters p = new SqlParameters();

            ds = sql.GetBySQL(SqlStoredProcedures.RepBOMaterialSales, p.ParamBO(StartDate, EndDate));
            return ds;
        }
    }

   
}
