using ICP.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICP.Control
{
    public partial class DateTimePickers : System.Web.UI.UserControl
    {
        public string DateTime
        {
            get { return txtDateTime.Text; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            DateTimePickers picker = this;
           // ScriptManager.RegisterClientScriptBlock(picker, picker.GetType(), "message", "<script type=\"text/javascript\" language=\"javascript\">getDateTimePicker();</script>", false);
        }

    }
}