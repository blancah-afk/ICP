using DataTools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ICPDataAccess
{
    public class DaICPSalesCommissions
    {
        SqlAccess sql = new SqlAccess();

        private DataSet dsInfo(int FiscalYear, int FiscalPeriod, string strCompany)
        {
            DataSet ds = new DataSet();
            SqlParameters param = new SqlParameters();
            ds = sql.GetBySQL(SqlStoredProcedures.ICPSalesCommissions, param.pFiscalPeriod(FiscalYear, FiscalPeriod, strCompany));


            return ds;
        }

        private Acceso acceso(string strDomainUser)
        {
            Acceso lstFilter = new Acceso();
            DataSet ds = sql.GetBySQL("SW_SalesCommisionAccesos");
            

            lstFilter = (from DataRow dRow in ds.Tables[0].Rows
                         where dRow.Field<string>("DomainUser") == strDomainUser.ToLower()
                         select new Acceso
                                         {
                                             Name = dRow["Name"].ToString(),
                                             SalesRepCode = dRow["SalesRepCode"].ToString(),
                                             DomainUser = dRow["DomainUser"].ToString(),
                                             ViewAllTer = Convert.ToBoolean(dRow["ViewAllTer"].ToString()),

                         }).FirstOrDefault();

            return lstFilter;
        }

        private List<OutsideSalesRep> _lstOSR(DataSet ds, string strDomainUser)
        {
            Acceso accessUser = acceso(strDomainUser);

            List<OutsideSalesRep> lst = new List<OutsideSalesRep>();
            if (accessUser != null)
            {
                if (accessUser.ViewAllTer)
                {
                    lst = (from DataRow dRow in ds.Tables[0].Rows
                           orderby dRow.Field<string>("SalesRep") ascending
                           select new OutsideSalesRep
                           {
                               SalesRep = dRow["SalesRep"].ToString(),
                               SalesRepCode = dRow["SalesRepCode"].ToString()

                           }).ToList();
                }
                else
                {


                    lst = (from DataRow dRow in ds.Tables[0].Rows
                           where dRow.Field<string>("SalesRepCode") == accessUser.SalesRepCode
                           orderby dRow.Field<string>("SalesRep") ascending
                           select new OutsideSalesRep
                           {
                               SalesRep = dRow["SalesRep"].ToString(),
                               SalesRepCode = dRow["SalesRepCode"].ToString()

                           }).ToList();

                }


            }

            return lst;
         
        }

        private List<CorporateID_> _lstCorporate(DataSet ds)
        {
            return (from DataRow dRow in ds.Tables[0].Rows
                    select new CorporateID_
                    {
                        SalesRep = dRow["SalesRep"].ToString(),
                        SalesRepCode = dRow["SalesRepCode"].ToString(),
                        CorporateID = dRow["CorporateID"].ToString()
                    }).ToList();
        }

        private List<Customer> _lstCustomer(DataSet ds, string strSalesRepCode, string strCorporateID, bool corpotate)
        {
            List<Customer> lst = new List<Customer>();
            lst = (from DataRow dRow in ds.Tables[0].Rows
                   where dRow.Field<string>("SalesRepCode") == strSalesRepCode
                   select new Customer
                   {
                       TranType = dRow["TranType"].ToString(),
                       RowNumber = Convert.ToInt32(dRow["RowNumber"]),
                       StatusComision = dRow["StatusComision"].ToString(),
                       SalesRep = strSalesRepCode,
                       SalesRepCode = dRow["SalesRepCode"].ToString(),
                       CustomerName = dRow["Customer"].ToString(),
                       CustNum = Convert.ToInt32(dRow["CustNum"]),
                       CustomerType = dRow["CustomerType"].ToString(),
                       SaleType = dRow["SaleType"].ToString(),
                       CorporateID = dRow["CorporateID"].ToString(),
                       CurrenCyCode = dRow["CurrenCyCode"].ToString(),
                       DocPaymentAmount = Math.Round(Convert.ToDouble(dRow["DocPaymentAmount"]), 4),
                       PaymentAmountMXN = Math.Round(Convert.ToDouble(dRow["PaymentAmountMXN"]), 4),
                       PaymentAmountUSD = Math.Round(Convert.ToDouble(dRow["PaymentAmountUSD"]), 4),
                       InvoiceAmtMXN = Math.Round(Convert.ToDouble(dRow["InvoiceAmtMXN"]), 4),
                       InvoiceAmtUSD = Math.Round(Convert.ToDouble(dRow["InvoiceAmtUSD"]), 4),
                       SellingQtyKG = Math.Round(Convert.ToDouble(dRow["SellingQtyKG"]), 4),
                       SellingQtyKGPaid = Math.Round(Convert.ToDouble(dRow["SellingQtyKG_CashReceipt"]), 4),
                       PaidVolume = Math.Round(Convert.ToDouble(dRow["PaidVolume"]), 4),
                       TotalCostMXNLandedCost = Math.Round(Convert.ToDouble(dRow["TotalCostMXNLandedCost"]), 4),
                       TotalCostUSDLandedCost = Math.Round(Convert.ToDouble(dRow["TotalCostUSDLandedCost"]), 4),
                       TotalMarginMXN = Math.Round(Convert.ToDouble(dRow["TotalMarginMXN"]), 4),
                       TotalMarginUSD = Math.Round(Convert.ToDouble(dRow["TotalMarginUSD"]), 4),
                       MargenPerMXN = Math.Round(Convert.ToDouble(dRow["MarginMXNPer"]), 4),
                       MargenPerUSD = Math.Round(Convert.ToDouble(dRow["MarginUSDPer"]), 4),

                       FactorComision = Convert.ToDouble(dRow["FactorComision"]),

                       MontoBrutoComision = Math.Round(Convert.ToDouble(dRow["MontoBrutoComision"]), 4),
                       ForecastGoalMT = (Math.Round(Convert.ToDouble(dRow["ForecastGoalMT"]), 4)),
                       VolumenMT = Math.Round((Convert.ToDouble(dRow["SellingQtyKG"]) / 1000), 4),
                       VolumenMTPaid = Math.Round((Convert.ToDouble(dRow["SellingQtyKG_CashReceipt"]) / 1000), 4),

                       ForecastCumplimientoPer = _forecastCumplimientoPer(Convert.ToDouble(dRow["ForecastGoalMT"]), 
                                                     Math.Round((Convert.ToDouble(dRow["SellingQtyKG"]) / 1000), 4)),  

                    }).ToList();

            if (corpotate)
            {
                lst = (from c in lst
                       where c.CorporateID == strCorporateID
                       select c).ToList();
            }

            return lst;
        }

        private double _forecastCumplimientoPer(double ForecastGoalMT, double VolumenMT)
        {
            return   ForecastGoalMT == 0 ? 0 : Math.Round(VolumenMT / ForecastGoalMT, 4);
        }

        private bool valido(List<OutsideSalesRep> lstFilter, string osr)
        {
            bool result = false;
            var a = (from c in lstFilter where c.SalesRepCode == osr select c).FirstOrDefault();
                if (a == null)
                {
            result = true;
            }
            return result;
        }

        private bool valido(List<CorporateID_> lstFilter, string osr, string corporateID)
        {
            bool result = false;
            var corp = (from c in lstFilter
                        where c.SalesRepCode == osr
                        && c.CorporateID == corporateID
                        select c).FirstOrDefault();
            if (corp == null)
            {
                result = true;
            }
            return result;
        }

        private double _margenPer(double costoVenta, double LandedCost)
        {
            return (costoVenta - LandedCost) / costoVenta;

        }

        public List<OutsideSalesRep> lstOSR(int FiscalYear, int FiscalPeriod, string UserDomain, string strCompany)
        {
            //Inicializa Listas
            List<OutsideSalesRep> lstFilter = new List<OutsideSalesRep>();
            List<CorporateID_> lstCorporateIDFilter = new List<CorporateID_>();

            //Obtiene información
            DataSet ds = dsInfo(FiscalYear, FiscalPeriod, strCompany );
            List<OutsideSalesRep> lst = _lstOSR(ds, UserDomain);
            List<CorporateID_> lstCorporate = _lstCorporate(ds);

            //Acomoda la informacion
            foreach (OutsideSalesRep osr in lst)
            {
                if (valido(lstFilter, osr.SalesRepCode))
                {
                    List<CorporateID_> lstCorporateIDFilterByOSR = new List<CorporateID_>();
                    lstCorporateIDFilterByOSR = (from c in lstCorporate
                                                 where c.SalesRepCode == osr.SalesRepCode
                                                 select c).ToList();

                    lstCorporateIDFilter = new List<CorporateID_>();
                    foreach (CorporateID_ corporate in lstCorporateIDFilterByOSR)
                    {
                        if (valido(lstCorporateIDFilter, osr.SalesRepCode, corporate.CorporateID))
                        {
                            List<Customer> lstCustomer = _lstCustomer(ds, osr.SalesRepCode, corporate.CorporateID, true);
                          
                            corporate.PaymentAmountMXN = lstCustomer.Sum(item => item.PaymentAmountMXN);
                            corporate.PaymentAmountUSD = lstCustomer.Sum(item => item.PaymentAmountUSD);
                            corporate.VolumenMT = lstCustomer.Sum(item => item.VolumenMT);
                            corporate.VolumenMTPaid = lstCustomer.Sum(item => item.VolumenMTPaid);
                            corporate.MontoBrutoComision = lstCustomer.Sum(item => item.MontoBrutoComision);
                            corporate.ForecastGoalMT = lstCustomer.Sum(item => item.ForecastGoalMT);
                            corporate.ForecastCumplimientoPer = _forecastCumplimientoPer(lstCustomer.Sum(item => item.ForecastGoalMT), lstCustomer.Sum(item => item.VolumenMT));
                            corporate.ForecastComisionEarnedPer = osr.ForecastCumplimientoPer / .5;
                            corporate.TotalMarginMXN = lstCustomer.Sum(item => item.TotalMarginMXN);
                            corporate.TotalMarginUSD = lstCustomer.Sum(item => item.TotalMarginUSD);
                            corporate.MargenPerMXN = _margenPer(lstCustomer.Sum(item => item.InvoiceAmtMXN), 
                                                      lstCustomer.Sum(item => item.TotalCostMXNLandedCost)); 
                            corporate.MargenPerUSD = _margenPer(lstCustomer.Sum(item => item.InvoiceAmtUSD),
                                                      lstCustomer.Sum(item => item.TotalCostUSDLandedCost));
                            corporate.MargenComisionEarnedPer = margenEarnedPer(osr.MargenPerUSD);
                            corporate.InventarioComisionEarnedPer = 0;
                            corporate.FactorTotal = osr.ForecastComisionEarnedPer + osr.MargenComisionEarnedPer + osr.InventarioComisionEarnedPer;
                            corporate.ComisionAPagar = osr.MontoBrutoComision * osr.FactorTotal;
                            corporate.lstCustomer = lstCustomer;
                            lstCorporateIDFilter.Add(corporate);
                            
                        }
                    }

                    osr.lstCorporate = lstCorporateIDFilter;

                    List<Customer> lstCustomerO = _lstCustomer(ds, osr.SalesRepCode,"", false);

                    osr.PaymentAmountMXN = lstCustomerO.Sum(item => item.PaymentAmountMXN);
                    osr.PaymentAmountUSD = lstCustomerO.Sum(item => item.PaymentAmountUSD);
                    osr.VolumenMT =  lstCustomerO.Sum(item => item.VolumenMT) ;
                    osr.VolumenMTPaid = lstCustomerO.Sum(item => item.VolumenMTPaid);
                    osr.MontoBrutoComision = lstCustomerO.Sum(item => item.MontoBrutoComision);
                    osr.ForecastGoalMT = lstCustomerO.Sum(item => item.ForecastGoalMT);
                    osr.ForecastCumplimientoPer = _forecastCumplimientoPer(osr.ForecastGoalMT, osr.VolumenMT);  
                    osr.ForecastComisionEarnedPer = osr.ForecastCumplimientoPer * .5;
                    osr.TotalMarginMXN = lstCustomerO.Sum(item => item.TotalMarginMXN);
                    osr.TotalMarginUSD = lstCustomerO.Sum(item => item.TotalMarginUSD);
                    osr.MargenPerMXN = _margenPer(lstCustomerO.Sum(item => item.InvoiceAmtMXN),
                                       lstCustomerO.Sum(item => item.TotalCostMXNLandedCost));    
                    osr.MargenPerUSD = _margenPer(lstCustomerO.Sum(item => item.InvoiceAmtUSD),
                                       lstCustomerO.Sum(item => item.TotalCostUSDLandedCost));
                    osr.MargenComisionEarnedPer = margenEarnedPer(osr.MargenPerUSD);
                    osr.InventarioComisionEarnedPer = 0;
                    osr.FactorTotal = osr.ForecastComisionEarnedPer + osr.MargenComisionEarnedPer + osr.InventarioComisionEarnedPer;
                    osr.ComisionAPagar = osr.MontoBrutoComision * osr.FactorTotal;
                    osr.TotalPer = 1;

                    foreach (Customer c in lstCustomerO)
                    {
                        foreach (CorporateID_ corp in osr.lstCorporate)
                        {
                            Customer cust = (from customer in corp.lstCustomer
                                                  where customer.CustNum == c.CustNum
                                                  select customer).FirstOrDefault();
                            if (cust != null)
                            {
                                cust.TotalPer = Math.Round((Math.Round(c.VolumenMT, 2) / Math.Round(osr.VolumenMT, 2)), 4); ;
                                cust.ForecastCumplimientoPer = _forecastCumplimientoPer(c.ForecastGoalMT, c.VolumenMT);
                                //cust.ForecastCumplimientoPer = _forecastCumplimientoPer(cust.Sum(item => item.ForecastGoalMT), c.Sum(item => item.VolumenMT));
                            }
                        }

                        foreach (CorporateID_ corp in osr.lstCorporate)
                        {
                            corp.TotalPer = corp.lstCustomer.Sum(item => item.TotalPer); 
                        }
                    }

                    lstFilter.Add(osr);
                }
            }

            return lstFilter;

        }

        private double margenEarnedPer(double margin)
        {
            double earned = 0;
            //Margen Bruto              Factor a Aplicar
            //  mas del 20 %            100 %  
            //  entre el 17 % y 19.99 % 85 %  
            //  entre el 14 % y 16.99 % 55 %  
            //  entre el 11 % y 13.99 % 30 %  
            //  menos del 11 %          0 %
            if (margin > .20)
            {
                earned = 1;
            }

            if (margin > .17 && margin < .20)
            {
                earned = .85;
            }

            if (margin > .14 && margin < .17)
            {
                earned = .55;
            }

            if (margin > .11 && margin <  .14)
            {
                earned = .30;
            }

            if (margin < .11 )
            {
                earned = 0;
            }

            return earned *.5;

        }
    }

}



[Serializable]
public class OutsideSalesRep
{
    public string SalesRep { get; set; }
    public string SalesRepCode { get; set; }
    public double PaymentAmountMXN { get; set; }
    public double PaymentAmountUSD { get; set; }
    public double VolumenMT { get; set; }
    public double VolumenMTPaid { get; set; }
    public double TotalPer { get; set; }
    public double FactorComision { get; set; }
    public double MontoBrutoComision { get; set; }
    public double ForecastGoalMT { get; set; }
    public double ForecastCumplimientoPer { get; set; }
    public double ForecastComisionEarnedPer { get; set; }
    public double TotalMarginMXN { get; set; }
    public double TotalMarginUSD { get; set; }
    public double MargenPerMXN { get; set; }
    public double MargenPerUSD { get; set; }
    public double MargenComisionEarnedPer { get; set; }
    public double InventarioComisionEarnedPer { get; set; }
    public double FactorTotal { get; set; }
    public double ComisionAPagar { get; set; }

    public List<CorporateID_> lstCorporate { get; set;}
}

[Serializable]
public class Customer
{
   

    public string TranType { get; set; }
    public int RowNumber { get; set; }
    public string StatusComision { get; set; }
    public string SalesRepCode { get; set; }
    public string SalesRep { get; set; }
    public string CustomerName { get; set; }
    public int CustNum { get; set; }
    public string CustomerType { get; set; }
    public string SaleType { get; set; }
    public string CorporateID { get; set; }
    public string CurrenCyCode { get; set; }
    public double AVGExchangeRate { get; set; }
    public int FiscalYear { get; set; }
    public int FiscalPeriod { get; set; }
    public double AVGAging { get; set; }
    public double DocPaymentAmount { get; set; }
    public double PaymentAmountMXN { get; set; }
  
    public double PaymentAmountUSD { get; set; }
    public double InvoiceAmtMXN { get; set; }
    public double InvoiceAmtUSD { get; set; }
    public double SellingQtyKG { get; set; }
    public double SellingQtyKGPaid { get; set; }
    public double PaidVolume { get; set; }
    public double TotalCostMXNLandedCost { get; set; }
    public double TotalCostUSDLandedCost { get; set; }
    public double TotalMarginMXN { get; set; }
    public double TotalMarginUSD { get; set; }
 

    public double FactorComision { get; set; }
    public double MontoBrutoComision { get; set; }
    public double ForecastGoalMT { get; set; }
    public double VolumenMT { get; set; }
    public double VolumenMTPaid { get; set; }
    public double TotalPer { get; set; }
    public double ForecastCumplimientoPer { get; set; }
    public double ForecastComisionEarnedPer { get; set; }
    public double MargenPerMXN { get; set; }
    public double MargenPerUSD { get; set; }
    public double MargenComisionEarnedPer { get; set; }
    public double InventarioComisionEarnedPer { get; set; }
    public double FactorTotal { get; set; }
    public double ComisionAPagar { get; set ; }

}

[Serializable]
public class CorporateID_
{
    public string TranType { get; set; }
    public int RowNumber { get; set; }
    public string StatusComision { get; set; }
    public string SalesRepCode { get; set; }
    public string SalesRep { get; set; }
    public string CustomerName { get; set; }
    public int CustNum { get; set; }
    public string CustomerType { get; set; }
    public string SaleType { get; set; }
    public string CorporateID { get; set; }
    public string CurrenCyCode { get; set; }
    public double AVGExchangeRate { get; set; }
    public int FiscalYear { get; set; }
    public int FiscalPeriod { get; set; }
    public double AVGAging { get; set; }
    public double DocPaymentAmount { get; set; }
    public double PaymentAmountMXN { get; set; }
    public double PaymentAmountUSD { get; set; }
    public double InvoiceAmtMXN { get; set; }
    public double InvoiceAmtUSD { get; set; }
    public double SellingQtyKG { get; set; }
    public double PaidVolume { get; set; }
    public double TotalCostMXNLandedCost { get; set; }
    public double TotalCostUSDLandedCost { get; set; }
    public double TotalMarginMXN { get; set; }
    public double TotalMarginUSD { get; set; }


    public double FactorComision { get; set; }
    public double MontoBrutoComision { get; set; }
    public double ForecastGoalMT { get; set; }
    public double VolumenMT { get; set; }
    public double VolumenMTPaid { get; set; }
    public double TotalPer { get; set; }
    public double ForecastCumplimientoPer { get; set; }
    public double ForecastComisionEarnedPer { get; set; }
    public double MargenPerMXN { get; set; }
    public double MargenPerUSD { get; set; }
    public double MargenComisionEarnedPer { get; set; }
    public double InventarioComisionEarnedPer { get; set; }
    public double FactorTotal { get; set; }
    public double ComisionAPagar { get; set; }
    public List<Customer> lstCustomer { get; set; }

}

[Serializable]
public class Acceso
{
    
    public string SalesRepCode { get; set; }
    public string Name { get; set; }
    public string DomainUser { get; set; }
    public bool ViewAllTer { get; set; }

}
