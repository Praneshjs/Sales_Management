using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AppSession
/// </summary>
public class AppSession
{
    public AppSession()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static int UserID
    {
        set
        {
            HttpContext.Current.Session["UserID"] = value;
        }
        get
        {
            if (HttpContext.Current.Session["UserID"] != null)
                return Convert.ToInt32(HttpContext.Current.Session["UserID"]);
            else
                return 0;
        }
    }

    public static string Name
    {
        set
        {
            HttpContext.Current.Session["Name"] = value;
        }
        get
        {
            if (HttpContext.Current.Session["Name"] != null)
                return HttpContext.Current.Session["Name"].ToString();
            else
                return null;
        }
    }

    public static string UserName
    {
        set
        {
            HttpContext.Current.Session["UserName"] = value;
        }
        get
        {
            if (HttpContext.Current.Session["UserName"] != null)
                return HttpContext.Current.Session["UserName"].ToString();
            else
                return null;
        }
    }

    public static string Email
    {
        set
        {
            HttpContext.Current.Session["Email"] = value;
        }
        get
        {
            if (HttpContext.Current.Session["Email"] != null)
                return HttpContext.Current.Session["Email"].ToString();
            else
                return null;
        }
    }

    public static string UserInRole
    {
        set
        {
            HttpContext.Current.Session["UserInRole"] = value;
        }
        get
        {
            if (HttpContext.Current.Session["UserInRole"] != null)
                return HttpContext.Current.Session["UserInRole"].ToString();
            else
                return null;
        }
    }

    public static List<string> UserRoles
    {
        set
        {
            HttpContext.Current.Session["UserRoles"] = value;
        }
        get
        {
            if (HttpContext.Current.Session["UserRoles"] != null)
                return HttpContext.Current.Session["UserRoles"] as List<string>;
            else
                return null;
        }
    }

    public static bool LoggedIn
    {
        set
        {
            HttpContext.Current.Session["LoggedIn"] = value;
        }
        get
        {
            if (HttpContext.Current.Session["LoggedIn"] != null)
                return true;
            else
                return false;
        }
    }

}