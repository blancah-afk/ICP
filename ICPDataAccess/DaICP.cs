using DataTools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ICPDataModel;
namespace ICPDataAccess
{
    public class DaICP
    {
        DataSet ds = new DataSet();
        SqlParameters pSQL = new SqlParameters();
        SqlAccess sql = new SqlAccess();

        public string strICP_NextURL(int menuPCI, string pageName)
        {
            //Obtiene Fecha de Ultima Actualizacion de la tabla.
            string dt = "";

            ds = sql.GetBySQL(SqlStoredProcedures.spPCIGetMenuItems, pSQL.paramPCIGetMenuItems(menuPCI, pageName, "NextURL"));
            if (ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0].Rows[0]["URL"].ToString();
            }

            return dt;

        }

        public string strICP_NextDisplayName(int menuPCI, string pageName)
        {
            //Obtiene Fecha de Ultima Actualizacion de la tabla.
            string dt = "";

            ds = sql.GetBySQL(SqlStoredProcedures.spPCIGetMenuItems, pSQL.paramPCIGetMenuItems(menuPCI, pageName, "NextURL"));
            if (ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0].Rows[0]["DisplayName"].ToString();
            }

            return dt;

        }

        public List<string> lst_ItemsICP()
        {
            List<string> itemsPCI;

            DataSet InfoList = new DataSet();
            InfoList = sql.GetBySQL(SqlStoredProcedures.spPCIGetMenuItems, pSQL.paramPCIGetMenuItems(1, "", "ItemsList"));
            itemsPCI = InfoList.Tables[0].AsEnumerable()
                            .Select(n => n.Field<string>("pagename"))
                            .ToList();
            return itemsPCI;
        }

        public DmMenuItems getItemsICP_ByPageName(string strPageName)
        {
            List<DmMenuItems> lst = new List<DmMenuItems>();
            DataSet ds = sql.GetBySQL(SqlStoredProcedures.spPCIGetMenuItems, pSQL.paramPCIGetMenuItems(1, strPageName, 
                "getByPageName"));

            if (ds.Tables[0].Rows.Count > 0)
            {

                lst = (from rw in ds.Tables[0].AsEnumerable()
                       select new DmMenuItems()
                       {
                           id = Convert.ToInt32(rw["id"]),
                           pageName = Convert.ToString(rw["pageName"]),
                           URL = Convert.ToString(rw["URL"]),
                           MenuIDPadre = Convert.ToString(rw["MenuIDPadre"]),
                           userIns = Convert.ToString(rw["userIns"]),
                           userMod = Convert.ToString(rw["userMod"]),
                           dateIns = Convert.ToDateTime(rw["dateIns"]),
                           dateMod = Convert.ToDateTime(rw["dateMod"]),
                           DisplayName = Convert.ToString(rw["DisplayName"])
                       }).ToList();
            }

            return lst.FirstOrDefault(); ;
        }

        public string strICP_LastUpd()
        {
            //Obtiene Fecha de Ultima Actualizacion de la tabla.
            string dt = "";

            ds = sql.GetBySQL(SqlStoredProcedures.spProdStatus, pSQL.grdPCIProdStatus("LastUpd"));
            if (ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0].Rows[0]["LastUpdDate"].ToString();
            }

            return dt;

        }
    }
}
