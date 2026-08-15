using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICP
{
    public partial class Test2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (this.Culture == null)
            //    this.Culture = System.Globalization.CultureInfo.CurrentCulture;

             // dateMaskedEditExtender.CultureName = this.Culture.
             //cexCalendarExtender.Format = this.Culture.DateTimeFormat.ShortDatePattern;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblMessage.Text = DateTimePicker.DateTime;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            TextBox txtDateTime = (TextBox)DateTimePicker.FindControl("txtDateTime");
            txtDateTime.Text = string.Empty;
            lblMessage.Text = string.Empty;
        }
    }
}