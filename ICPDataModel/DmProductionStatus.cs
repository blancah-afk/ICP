using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICPDataModel
{
    public class DmProductionStatus
    {
        public int ProdWeek { get; set; }
        public decimal Data1 { get; set; }
        public decimal Data2 { get; set; }
    }

    public class DMTemperFisrtPassYield
    {
        public int ProdMonth { get; set; }
        public int ProdWeek { get; set; }
        public decimal AvgEfficiency { get; set; }
        public decimal SumPT { get; set; }
        public decimal SumFG { get; set; }
        public decimal FirtsPassYield { get; set; }

    }

   
}
