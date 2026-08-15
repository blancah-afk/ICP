
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using DataTools;

namespace ICPDataModel
{
    public class DmSales
    {
        public LoadByResourceGRP _LoadByResourceGRP { get; set; }

        public List<LoadByResourceGRP> LoadListByResourceGRP_ByProcess(List<LoadByResourceGRP> lst, string strProcess)
        {
            List<LoadByResourceGRP> LoadByResourceGRP_lst = new List<LoadByResourceGRP>();

            var ls = from recurso in lst
                     where recurso.Process == strProcess
                     select recurso;

            LoadByResourceGRP_lst = ls.ToList();
            LoadByResourceGRP_lst[0]._dictionarySerie1 = _dictionarySerie1(LoadByResourceGRP_lst);
            LoadByResourceGRP_lst[0]._dictionarySerie2 = _dictionarySerie1(LoadByResourceGRP_lst);

            return LoadByResourceGRP_lst;
        }

        public LoadByResourceGRP LoadByResourceGRP_ByProcess(List<LoadByResourceGRP> lst, string strProcess)
        {
            List<LoadByResourceGRP> LoadByResourceGRP_lst = new List<LoadByResourceGRP>();

            var ls = from recurso in lst
                     where recurso.Process == strProcess
                     select recurso;

            LoadByResourceGRP_lst = ls.ToList();
            LoadByResourceGRP_lst[0]._dictionarySerie1 = _dictionarySerie1(LoadByResourceGRP_lst);
            LoadByResourceGRP_lst[0]._dictionarySerie2 = _dictionarySerie2(LoadByResourceGRP_lst);

            return LoadByResourceGRP_lst.FirstOrDefault(); ;
        }

        public Dictionary<string, string> _dictionarySerie1(List<LoadByResourceGRP> lst)
        {

            Dictionary<string, string> lstSerie1 = new Dictionary<string, string>();


            foreach (var item in lst)
            {
                lstSerie1.Add(Convert.ToString(item.Week), item.CapacityHrs.ToString());
            }

            return lstSerie1;

        }

        public Dictionary<string, string> _dictionarySerie2(List<LoadByResourceGRP> lst)
        {

            Dictionary<string, string> lstSerie1 = new Dictionary<string, string>();


            foreach (var item in lst)
            {
                lstSerie1.Add(Convert.ToString(item.Week), item.ScheduledHrs.ToString());
            }

            return lstSerie1;

        }
    }

    [DataContract]
    public class LoadByResourceGRP
    {
        [DataMember]
        public string Process { get; set; }
        [DataMember]
        public string ResourceGroup { get; set; }
        [DataMember]
        public int MaxVersion { get; set; }
        [DataMember]
        public int Week { get; set; }
        [DataMember]
        public int CapacityHrs { get; set; }
        [DataMember]
        public int ScheduledHrs { get; set; }
        [DataMember]
        public DateTime? MaxCreateDate { get; set; }
        [DataMember]
        public Dictionary<string, string> _dictionarySerie1 { get; set; }
        [DataMember]
        public Dictionary<string, string> _dictionarySerie2 { get; set; }

        public static IEnumerable<LoadByResourceGRP> map(DataTable table)
        {
            //Step 1 - Get the Column Names
            var columnNames = table.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToList();

            //Step 2 - Get the Property Data Names
            var properties = (typeof(LoadByResourceGRP)).GetProperties()
                                                .ToList();

            //Step 3 - Map the data
            List<LoadByResourceGRP> entities = new List<LoadByResourceGRP>();
            foreach (DataRow row in table.Rows)
            {
                LoadByResourceGRP entity = new LoadByResourceGRP();
                foreach (var prop in properties)
                {

                    PropertyMapHelper.Map(typeof(LoadByResourceGRP), row, prop, entity);
                }
                entities.Add(entity);
            }

            return entities;
        }
    }
}
