using ICPDataAccess;
using ICPDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICP
{
    public partial class PCIOEEDetails : System.Web.UI.Page
    {
        private int menuPCI;
        private string PageName;
        private string DisplayName;
        private string nextURL;
        DaICP da = new DaICP();

        protected void Page_Load(object sender, EventArgs e)
        {

            getNextDisplayInfo();
            tRefreshInfo.Interval = DmUOM.Segundos(30);
            if (!IsPostBack)
            {
                refreshInfo(false);


            }
        }

        private void getNextDisplayInfo()
        {

            try
            {
                menuPCI = Convert.ToInt32(Request.QueryString["menuPCI"]);
            }
            catch
            {
                menuPCI = 0;
            }

            string URL = HttpContext.Current.Request.Url.AbsoluteUri;
            string[] URL_ToArray = URL.Split('/', '?');
            PageName = URL_ToArray[URL_ToArray.Length - 2];

            nextURL = da.strICP_NextURL(menuPCI, PageName);
            DisplayName = da.strICP_NextDisplayName(menuPCI, PageName);
        }

        protected void tRefreshInfo_Tick(object sender, EventArgs e)
        {
            refreshInfo(true);
        }

        private void refreshInfo(bool isRefreshingInfo)
        {

            int iRefreshingInfo = Convert.ToInt32(isRefreshingInfo);
            const string quote = "\"";
            string javaScript = string.Format("RunGrahp({1}{0}{1}, {1}{2}{1}, {3});",
                nextURL, quote, DisplayName, iRefreshingInfo);

            ScriptManager.RegisterStartupScript(this, GetType(), "script", javaScript, true);

            updateDate();

        }

        private void updateDate()
        {
            string strLastUpd = da.strICP_LastUpd();
            if (strLastUpd != "")
            {
                lblLastUpdate.Text = "Data from last 7 weeks - Last Updated:  " + strLastUpd;
            }
        }
    }
}