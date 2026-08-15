using DataTools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CreateDocumentPDF
{
    public class DaKPIReport2
    {
        SqlAccess sql = new SqlAccess();

        public DataSet ds_KPIReport()
        {
            DataSet ds = new DataSet();
            ds = sql.GetBySQL(SqlStoredProcedures2.KPIReport);
            return ds;
        }

        public DataSet ds_KPIReport(string consulta, int? idCategory, int? idSubCategory, int iYear)
        {

            DataSet ds = new DataSet();
            DmKPIReport2 dm = new DmKPIReport2();
            SqlParameters2 param = new SqlParameters2();
            dm.Consulta = consulta;
            dm.IDCategory = idCategory;
            dm.IDSubCategory = idSubCategory;

            ds = sql.GetBySQL(SqlStoredProcedures2.KPIReport, param.pKPIReport(dm, iYear));

            return ds;
        }

        public DataSet ds_KPIComment(string consulta, int? idCategory, int? idSubCategory, int iYear)
        {
            DataSet ds = new DataSet();
            DmKPIReport2 dm = new DmKPIReport2();
            SqlParameters2 param = new SqlParameters2();
            dm.Consulta = consulta;
            dm.IDCategory = idCategory;
            dm.IDSubCategory = idSubCategory;

            ds = sql.GetBySQL(SqlStoredProcedures2.KPIReport, param.pKPIReport(dm, iYear));

            return ds;
        }

        public DataSet ds_KPIReportDtl(string consulta, int? idCategory, int? idSubCategory, int iYear)
        {
            if (consulta == "Detalle")
            {
                if (idCategory == 2)
                {
                    if (idSubCategory == 1)
                    {

                        string set = "Atencion";
                    }


                }
            }
            DataSet ds = new DataSet();
            List<DmKPIReport2> lstItems = new List<DmKPIReport2>();
            List<DmKPIReport2> lstDtl = new List<DmKPIReport2>();
            lstItems = lst_KPIReportItems(consulta, idCategory, idSubCategory, iYear);
            lstDtl = lst_KPIReport(consulta, idCategory, idSubCategory, iYear);

            DataTable tabla = new DataTable();

            //Para agregar las columnas y darles un nombre haremos lo siguiente:

            tabla.Columns.Add("OrderColumn");
            tabla.Columns.Add("ID");
            tabla.Columns.Add("Name");
            tabla.Columns.Add("KPIUpdateMethod");
            tabla.Columns.Add("DataType");
            tabla.Columns.Add("Operator");
            tabla.Columns.Add(ICPLabels.lblRArea);
            tabla.Columns.Add("Category");
            tabla.Columns.Add("Subcategory");
            tabla.Columns.Add("PrevYearResult");
            tabla.Columns.Add("CurrentYearGoal");

            //Para los 12 Meses
            for (int i = 1; i <= 12; i++)
            {
                tabla.Columns.Add(ICPLabels.Planning + i.ToString());
                tabla.Columns.Add(ICPLabels.Actual + i.ToString());
                tabla.Columns.Add(ICPLabels.KPIRange + i.ToString());
                tabla.Columns.Add(ICPLabels.UpdMethod + i.ToString());
            }

            tabla.Columns.Add("PTgtYTD");
            tabla.Columns.Add("ToolTipPlan");
            tabla.Columns.Add("ATgtYTD");
            tabla.Columns.Add("ToolTipActual");

            foreach (DmKPIReport2 item in lstItems)
            {
                DataRow fila = tabla.NewRow();
                if (item.ID == 10)
                {
                    string at = "Atencion";

                }


                if (item.ID == 11)
                {
                    string atf = "aqui pasa algo raro";

                }
                try
                {
                    fila["OrderColumn"] = item.OrderColumn;
                    fila["ID"] = item.ID;
                    fila["Operator"] = item.Operator;
                    fila["Name"] = item.Name;
                    fila["KPIUpdateMethod"] = item.KPIUpdateMethod;
                    fila[ICPLabels.lblRArea] = item.ResponsibleArea;
                    fila["Category"] = item.Category;
                    fila["Subcategory"] = item.IDSubCategory;

                    string DataType = (from x in lstDtl where x.ID == item.ID && x.Period == 1 select x.DataType).FirstOrDefault();
                    fila["DataType"] = DataType == null ? "" : DataType.ToString();

                    double? PrevYearResult = (from x in lstDtl
                                              where x.ID == item.ID && x.Period == 1
                                              select x.PrevYearResult).FirstOrDefault();

                    fila["PrevYearResult"] = (from x in lstDtl
                                              where x.ID == item.ID && x.Period == 1
                                              select x.PrevYearResult).FirstOrDefault().ToString();

                    fila["CurrentYearGoal"] = (from x in lstDtl
                                               where x.ID == item.ID && x.Period == 1
                                               select x.CurrentYearGoal).FirstOrDefault().ToString();

                    for (int i = 1; i <= 12; i++)
                    {
                        if ((from x in lstDtl
                             where x.ID == item.ID && x.Period == i
                             select x).ToList().Count > 0)
                        {
                            string strFilaPlanning = ICPLabels.Planning + i.ToString();
                            string strFilaActual = ICPLabels.Actual + i.ToString();
                            string strFilaKPIRange = ICPLabels.KPIRange + i.ToString();
                            string strFilaUpdMethod = ICPLabels.UpdMethod + i.ToString();

                            fila[strFilaPlanning] = (from x in lstDtl
                                                     where x.ID == item.ID && x.Period == i
                                                     select x.Planning).FirstOrDefault().ToString();
                            fila[strFilaActual] = (from x in lstDtl
                                                   where x.ID == item.ID && x.Period == i
                                                   select x.Actual).FirstOrDefault().ToString();
                            fila[strFilaKPIRange] = (from x in lstDtl
                                                     where x.ID == item.ID && x.Period == i
                                                     select x.KPIRange).FirstOrDefault().ToString();
                            fila[strFilaUpdMethod] = (from x in lstDtl
                                                      where x.ID == item.ID && x.Period == i
                                                      select x.UpdateMethod).FirstOrDefault().ToString();

                        }
                    }

                    string PTgtYTD = (from x in lstDtl
                                      where x.ID == item.ID
                                      select x.YTDPlan).FirstOrDefault();
                    fila["PTgtYTD"] = PTgtYTD == null ? "" : PTgtYTD;

                    string ToolTipPlan = (from x in lstDtl
                                          where x.ID == item.ID
                                          select x.ToolTipPlan).FirstOrDefault();

                    fila["ToolTipPlan"] = ToolTipPlan == null ? "" : ToolTipPlan;

                    string ATgtYTD = (from x in lstDtl
                                      where x.ID == item.ID
                                      select x.YTDActual).FirstOrDefault();

                    fila["ATgtYTD"] = ATgtYTD == null ? "" : ATgtYTD;

                    string ToolTipActual = (from x in lstDtl
                                            where x.ID == item.ID
                                            select x.ToolTipActual).FirstOrDefault();

                    fila["ToolTipActual"] = ToolTipActual == null ? "" : ToolTipActual;

                    tabla.Rows.Add(fila);
                }
                catch
                {
                    ds.Tables.Add(tabla);
                    return ds;
                }

            }
            ds.Tables.Add(tabla);
            return ds;
        }

        public List<DmKPIReport2> lst_KPIReport(string consulta, int? idCategory, int? idSubCategory, int iYear)
        {
            DataSet ds = new DataSet();
            List<DmKPIReport2> lres = new List<DmKPIReport2>();
            DmKPIReport2 dmp = new DmKPIReport2();
            SqlParameters2 param = new SqlParameters2();
            dmp.Consulta = consulta;
            dmp.IDCategory = idCategory;
            dmp.IDSubCategory = idSubCategory;

            ds = sql.GetBySQL(SqlStoredProcedures2.KPIReport, param.pKPIReport(dmp, iYear));

            try
            {
                foreach (DataRow renglon in ds.Tables[1].Rows)
                {

                    dmp = new DmKPIReport2();
                    dmp.OrderColumn = Convert.ToInt32((renglon["OrderColumn"]));
                    dmp.ID = Convert.ToInt32((renglon["ID"]));
                    dmp.Operator = Convert.ToString(renglon["Operator"]);
                    dmp.Name = Convert.ToString(renglon["Name"]);
                    dmp.ResponsibleArea = Convert.ToString(renglon[ICPLabels.lblRArea]);
                    dmp.Category = Convert.ToString(renglon["Category"]);
                    dmp.DataType = Convert.ToString(renglon["DataType"]);
                    dmp.UpdateMethod = Convert.ToString(renglon[ICPLabels.UpdMethod]);

                    if (!(renglon["PrevYearResult"].Equals(DBNull.Value)))
                    {
                        dmp.PrevYearResult = double.Parse((renglon["PrevYearResult"].Equals(DBNull.Value)
                            ? null : renglon["PrevYearResult"].ToString()));
                    }

                    if (!(renglon["CurrentYearGoal"].Equals(DBNull.Value)))
                    {
                        dmp.CurrentYearGoal = double.Parse((renglon["CurrentYearGoal"].Equals(DBNull.Value)
                            ? null : renglon["CurrentYearGoal"].ToString()));
                    }
                    if (!(renglon["Planning"].Equals(DBNull.Value)))
                    {
                        dmp.Planning = double.Parse((renglon["Planning"].Equals(DBNull.Value)
                            ? null : renglon["Planning"].ToString()));
                    }
                    if (!(renglon["Actual"].Equals(DBNull.Value)))
                    {
                        dmp.Actual = double.Parse((renglon["Actual"].Equals(DBNull.Value)
                            ? null : renglon["Actual"].ToString()));
                    }

                    dmp.Period = Convert.ToDouble(renglon["Period"]);
                    dmp.KPIRange = Convert.ToString(renglon["KPIRange"]);

                    dmp.RangeRisk_PrevYearResult = Convert.ToString(renglon["RangeRisk_PrevYearResult"]);
                    dmp.RangeRisk_CurrentYearGoal = Convert.ToString(renglon["RangeRisk_CurrentYearGoal"]);
                    dmp.RangeRiskPeriodPlan = Convert.ToString(renglon["RangeRisk_CurrentYearGoal"]);
                    dmp.RangeRiskPeriodActual = Convert.ToString(renglon["RangeRiskPeriodActual"]);

                    dmp.YTDActual = Convert.ToString(renglon["YTDActual"]);
                    dmp.ToolTipActual = Convert.ToString(renglon["ToolTipActual"]);
                    dmp.YTDPlan = Convert.ToString(renglon["YTDPlan"]);
                    dmp.ToolTipPlan = Convert.ToString(renglon["ToolTipPlan"]);

                    lres.Add(dmp);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ICPLabels.lblErrorMsg + ex.Message, ex);
            }
            return lres;
        }

        public List<DmKPIReport2> lst_KPIReportItems(string consulta, int? idCategory, int? idSubCategory, int iYear)
        {
            DataSet ds = new DataSet();
            List<DmKPIReport2> lres = new List<DmKPIReport2>();
            DmKPIReport2 dmp = new DmKPIReport2();
            SqlParameters2 param = new SqlParameters2();

            dmp.Consulta = consulta;
            dmp.IDCategory = idCategory;
            dmp.IDSubCategory = idSubCategory;

            ds = sql.GetBySQL(SqlStoredProcedures2.KPIReport, param.pKPIReport(dmp, iYear));

            try
            {
                foreach (DataRow renglon in ds.Tables[0].Rows)
                {
                    dmp = new DmKPIReport2();
                    dmp.OrderColumn = Convert.ToInt32((renglon["OrderColumn"]));
                    dmp.ID = Convert.ToInt32((renglon["ID"]));
                    dmp.Operator = Convert.ToString(renglon["Operator"]);
                    dmp.Name = Convert.ToString(renglon["Name"]);
                    dmp.ResponsibleArea = Convert.ToString(renglon[ICPLabels.lblRArea]);
                    dmp.Category = Convert.ToString(renglon["Category"]);
                    dmp.IDSubCategory = idSubCategory;
                    dmp.KPIUpdateMethod = Convert.ToString(renglon["UpdateMethod"]);

                    lres.Add(dmp);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ICPLabels.lblErrorMsg + ex.Message, ex);
            }
            return lres;
        }

        public DataTable dt_dataSource(DataTable dt, int iPeriod)
        {
            DataTable dt1 = new DataTable();
            IEnumerable<DataRow> query = from x in dt.AsEnumerable() where x.Field<int>("Period") == iPeriod select x;
            if (query.Count() > 0)
            {
                dt1 = query.CopyToDataTable();
            }
            return dt1;

        }

        public DataTable dt_dataSourceDet(DataTable dt, int? IDCategory, int? IDSubCategory)
        {
            DataTable dt1 = new DataTable();
            IEnumerable<DataRow> query = from x in dt.AsEnumerable()
                                         where x.Field<int>("IDCategory") == IDCategory &&
             x.Field<int>("IDSubCategory") == IDSubCategory
                                         select x;
            if (query.Count() > 0)
            {
                dt1 = query.CopyToDataTable();
            }
            return dt1;

        }

    }
}
