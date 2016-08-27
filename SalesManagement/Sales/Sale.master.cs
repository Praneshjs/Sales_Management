using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sales_Sale : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
            
        if (AppSession.UserInRole == Role.User)
        {
            if(AppSession.UserRoles.Contains(PageAccess.Dashboard))
                liDashboard.Visible = true;
            else
                liDashboard.Visible = false;

            if (AppSession.UserRoles.Contains(PageAccess.Reports))
                liReports.Visible = true;
            else
                liReports.Visible = false;

            if (AppSession.UserRoles.Contains(PageAccess.Profile))
                liProfile.Visible = true;
            else
                liProfile.Visible = false;

            if (AppSession.UserRoles.Contains(PageAccess.Inventory))
                liInventory.Visible = true;
            else
                liInventory.Visible = false;
        }
    }
}
