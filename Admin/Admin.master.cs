using System;
using System.IO;
using System.Web.UI;

public partial class AdminMaster : MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.MaintainScrollPositionOnPostBack = true;

        if (Session["AdminUser"] == null)
        {
            Response.Redirect("~/Admin/Login.aspx");
        }
    }

    protected string GetSideNavClass(string pageName)
    {
        var current = Path.GetFileName(Page.AppRelativeVirtualPath ?? string.Empty);
        return current.Equals(pageName, StringComparison.OrdinalIgnoreCase)
            ? "sidebar-link active"
            : "sidebar-link";
    }

    protected void Logout_Click(object sender, EventArgs e)
    {
        Session.Remove("AdminUser");
        Response.Redirect("~/Admin/Login.aspx");
    }
}
