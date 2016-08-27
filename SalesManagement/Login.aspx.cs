using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    public SalesContextDataContext dc = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        dc = new SalesContextDataContext(ConfigurationManager.ConnectionStrings["SalesConnectionString"].ConnectionString);
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (dc.Accounts.Where(s => s.UserName == txtUserName.Text.Trim() && s.Password == txtPassword.Text.Trim()).Any())
        {
            Account userInfo = dc.Accounts.Where(s => s.UserName == txtUserName.Text.Trim()).SingleOrDefault();
            AppSession.LoggedIn = true;
            AppSession.UserID = userInfo.Id;
            AppSession.Name = userInfo.FullName;
            AppSession.UserInRole = (userInfo.IsAdmin == true) ? Role.Administrator : Role.User;
            AppSession.UserRoles = dc.sp_UserInRoles(AppSession.UserID).Select(t => t.RoleName).ToList();
            if (AppSession.UserInRole != Role.User)
                Response.Redirect(Pages.Dashboard);
            else
                Response.Redirect(Pages.PointOfSale);
        }
        else
        {
            errorMessage.InnerHtml = "<div class='alert alert-danger' role='alert'>Invalid Account</div>";
        }
    }
}