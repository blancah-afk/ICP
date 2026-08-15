using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICP
{
    public partial class KPIProductionOEE : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //refreshInfo(false);

            }


        }


        private void refreshInfo(bool isRefreshingInfo)
        {

            int iRefreshingInfo = Convert.ToInt32(isRefreshingInfo);
            const string quote = "\"";
            string javaScript = string.Format("RunGrahp({1}{0}{1}, {1}{2}{1}, {3});",
                "", quote, "", iRefreshingInfo);

            ScriptManager.RegisterStartupScript(this, GetType(), "script", javaScript, true);



        }
    }
}