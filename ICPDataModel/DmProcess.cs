using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICPDataModel
{
    public class DmProcess
    {
        public static string Temper = "0001";

        public int idConsulta { get; set; }
        public string Process { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Consulta { get; set; }
    }
}
