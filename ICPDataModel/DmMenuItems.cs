using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICPDataModel
{
    public class DmMenuItems
    {
        public int id { get; set; }
        public string pageName { get; set; }
        public string URL { get; set; }
        public string MenuIDPadre { get; set; }
        public string userIns { get; set; }
        public string userMod { get; set; }
        public DateTime dateIns { get; set; }
        public DateTime dateMod { get; set; }
        public string DisplayName { get; set; }
    }
}
