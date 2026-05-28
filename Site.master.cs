using System;
using System.Web.UI;

public partial class SiteMaster : global::System.Web.UI.MasterPage
{
    protected string GetNavClass(string pageName)
    {
        return Page.AppRelativeVirtualPath.EndsWith(pageName, StringComparison.OrdinalIgnoreCase)
            ? "nav-link active"
            : "nav-link";
    }
}
