using ICPDataAccess;
using ICPDataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ICP
{
    public partial class Principal : System.Web.UI.MasterPage
    {

        public string UserName;
        public string Puesto;
        public string lastConnection;



        DaICP da = new DaICP();
        DaKPIReport dak = new DaKPIReport();

        protected void Page_Load(object sender, EventArgs e)
        {
            setParametes();
            if (!IsPostBack)
            {
                
                _DisplayPCI();
                _HideMenu();
                // _redirectMainPagePCI();
                _SetDivStyle(HttpContext.Current.Request.Url.AbsoluteUri);
                _GetDisplayName();
                
                DataSet ds = new DataSet();
                ds = dak.ds_KPIReportEmailAddressGroup();
                DataTable dt = ds.Tables[0];
                string[] EmailTo = dt.Rows[0]["AddressTo"].ToString().Split(',');
                string[] EmailCc = dt.Rows[0]["AddressCc"].ToString().Split(',');
                string strEmails =string.Empty;
                foreach (string str in EmailTo)
                {
                    strEmails += str + "\\n";
                }
                foreach (string str in EmailCc)
                {
                    strEmails += str + "\\n";
                }
                string script = "<script>var emails = '" + strEmails + "';</script>";
            }
        }

        private void _GetDisplayName()
        {
            string URL = HttpContext.Current.Request.Url.AbsoluteUri;
            string[] URL_ToArray = URL.Split('/', '?');
            string PageName = URL_ToArray[URL_ToArray.Length - 2];
            DmMenuItems menu = new DmMenuItems();
            menu = da.getItemsICP_ByPageName(PageName);

            if (menu != null)
            {
                lblDisplayName.Text = menu.DisplayName;
            }
        }
        private void _redirectMainPagePCI()
        {
            string URL = HttpContext.Current.Request.Url.AbsoluteUri;
            if (!URL.Contains("PCI"))
            {
                Response.Redirect(@".\PCIShipments.aspx?menuPCI=1");
            }
            else
            {
                Response.Redirect(@".\KPIReport.aspx?menuPCI=1");

            }

        }

        private void _HideMenu()
        {
            liDashboard.Visible = false;
            liDetails.Visible = false;
            liMatrix.Visible = false;
            liReports.Visible = false;
            //liShipping.Visible = false;
            liProduction.Visible = false;
            //divUser.Visible = false;
        }

        private void _SetDivStyle(string strPage)
        {
            string PageName = "";
            string[] URL_ToArray = strPage.Split('/', '?');
            for (int i = 0; i < URL_ToArray.Length; i++)
            {
                if (URL_ToArray[i].Contains(".aspx"))
                {
                    PageName = URL_ToArray[i];
                }
                 
            }
            
            
            switch (PageName)
            {
                case "KPIExtendedGraphs.aspx":
                    liShipping.Attributes["class"] = "active treeview";
                    break;

                case "KPIProductionOEE.aspx":
                    liProduction.Attributes["class"] = "active treeview";
                    break;

                case "ReportViewer.aspx":
                    liReports.Attributes["class"] = "active treeview";
                    break;

                case "PCIShipments.aspx":
                    liDisplay.Attributes["class"] = "active treeview";
                    break;

                case "PCITruckTracker.aspx":
                    liDisplay.Attributes["class"] = "active treeview";
                    break;

                case "PCIProductionStatus.aspx":
                    liDisplay.Attributes["class"] = "active treeview";
                    break;

                case "PCIOEEDetails.aspx":
                    liDisplay.Attributes["class"] = "active treeview";
                    break;

                case "PCIOEE.aspx":
                    liDisplay.Attributes["class"] = "active treeview";
                    break;

                case "PCISalesLoadByResourceGrp.aspx":
                    liDisplay.Attributes["class"] = "active treeview";
                    break;

                case "KPIReport.aspx":
                    liKpiReport.Attributes["class"] = "active treeview";
                    break;

                case "ReportSalesLotDetails.aspx":
                    liBo.Attributes["class"] = "active treeview";
                    break;

                /*case "ReportViewer.aspx":
                    liBo.Attributes["class"] = "active treeview";
                    break;*/

                case "ReportSalesProfitMaterials.aspx":
                    liBo.Attributes["class"] = "active treeview";
                    break;

                //case "ICPSalesComission.aspx":
                //        liSalesCommission.Attributes["class"] = "active treeview";
                //    break;
            }
            
        }

        private void _DisplayPCI()
        {
            string pageName = "";
            string URL = "";
            string[] items = null;
            int indexParam = -1;
            List<string> itemsPCI;
            string result = "";

            itemsPCI = da.lst_ItemsICP();
            URL = HttpContext.Current.Request.Url.AbsoluteUri;

            items = URL.Split('/');
            pageName = items[items.Length - 1];

            indexParam = pageName.IndexOf("?");

            if (indexParam > 0)
            {
                pageName = pageName.Substring(0, indexParam);
            }
            //Console.WriteLine(title);
            result = itemsPCI.FirstOrDefault(s => s == pageName);

            if (result != null)
            {
                DisplayPCI.Visible = true;
            }
            else
            {
                DisplayPCI.Visible = false;

            }
        }

        private void setParametes()
        {

            WindowsPrincipal User;
            User = new WindowsPrincipal(Request.LogonUserIdentity);

            //AllowUsr UserInfo = new AllowUsr();
            //Puesto = "Ingeniero en Sistemas";
            //lastConnection = "03 Octubre 2016";

            //UserInfo = AllowedUsers(User.Identity.Name.ToString());
            UserName = User.Identity.Name.ToString();
            //UserName = Environment.UserDomainName;
            Session["UserName"] = UserName;

        }

        //private AllowUsr AllowedUsers(string User)
        //{
        //    AllowUsr res = new AllowUsr();UserName

        //    string[] DataUser = User.Split('\\');
        //    string Dominio = DataUser[0];
        //    string Usuario = DataUser[1];

        //    Orchestrator orch = new Orchestrator();
        //    res = orch.ValidateUser(Dominio, Usuario);

        //    return res;

        //}

    }
}