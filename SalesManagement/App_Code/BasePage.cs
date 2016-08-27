using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePage : System.Web.UI.Page
{
    public SalesContextDataContext dc = null;
    protected const string DateFormat = "dd-MM-yyyy";
    public BasePage()
    {
        dc = new SalesContextDataContext(ConfigurationManager.ConnectionStrings["SalesConnectionString"].ConnectionString);
        HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache, no-store, must-revalidate");
        HttpContext.Current.Response.AddHeader("Pragma", "no-cache");
        HttpContext.Current.Response.AddHeader("Expires", "0");
    }

    protected override void OnLoad(EventArgs e)
    {
        if (!AppSession.LoggedIn)
            Response.Redirect(Pages.Login, true);

        string page = this.GetType().Name.ToLower();
        string role = AppSession.UserInRole;
        List<string> roles = AppSession.UserRoles.ToList();
        bool isValid = false;
        switch (role)
        {
            case Role.Administrator:
                isValid = true;
                break;
            case Role.User:
                isValid = roles.Contains(PageToActivity(page));
                break;
            default:
                isValid = false;
                break;
        }
        if (!isValid)
            Response.Redirect(Pages.Login, true);

        base.OnLoad(e);
    }

    protected string PageToActivity(string page)
    {
        string role = string.Empty;
        switch (page)
        {
            case AllPages.Dashboard:
                role = PageAccess.Dashboard;
                break;
            case AllPages.Inventory:
                role = PageAccess.Inventory;
                break;
            case AllPages.PointOfSale:
                role = PageAccess.PointOfSale;
                break;
            case AllPages.Profile:
                role = PageAccess.Profile;
                break;
            case AllPages.DailySaleReport:
                role = PageAccess.Reports;
                break;
            case AllPages.WeeklySaleReport:
                role = PageAccess.Reports;
                break;
            case AllPages.MonthlySaleReport:
                role = PageAccess.Reports;
                break;
        }
        return role;
    }
    protected void ShowAlert(string id, string title, string message)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString("N"), "openModal('" + id + "','" + title + "','" + message + "');", true);
    }
}

public class Role
{
    public const string Administrator = "Administrator";
    public const string User = "User";
}

public static class AllPages
{
    public const string Dashboard = "sales_dashboard_aspx";
    public const string DailySaleReport = "sales_dailysalereport_aspx";
    public const string WeeklySaleReport = "sales_weeklysalereport_aspx";
    public const string MonthlySaleReport = "sales_monthlysalereport_aspx";
    public const string Inventory = "sales_inventory_aspx";
    public const string PointOfSale = "sales_pointofsale_aspx";
    public const string Profile = "sales_profile_aspx";
}

public class Pages
{
    public const string Login = "../Login.aspx";
    public const string Dashboard = "~/sales/Dashboard.aspx";
    public const string DailySaleReport = "~/sales/DailySaleReport.aspx";
    public const string WeeklySaleReport = "~/sales/WeeklySaleReport.aspx";
    public const string MonthlySaleReport = "~/sales/MonthlySaleReport.aspx";
    public const string PointOfSale = "~/sales/PointOfSale.aspx";
    public const string Profile = "~/sales/Profile.aspx";
    public const string Inventory = "~/sales/Inventory.aspx";
}

public static class PageAccess
{
    public const string Dashboard = "Dashboard";
    public const string Reports = "Reports";
    public const string PointOfSale = "POS";
    public const string Profile = "Profile";
    public const string Inventory = "Inventory";
}