using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICPDataModel
{
    public class DmShipment
    {
        public decimal ShippedQtyMT { get; set; }
        public decimal DemandQtyMT { get; set; }
        public DateTime ShipDate { get; set; }
        public decimal Avg { get; set; }
        public decimal Goal { get; set; }
        public string strDate { get; set; }
    }

    public class TruckTracker
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PackNum { get; set; }
        public string TruckID { get; set; }
        public string FreightInvoice { get; set; }

    }
}
