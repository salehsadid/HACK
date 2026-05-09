using System;
using System.Web.UI;

namespace HACK.WebForms
{
    public partial class SiteMaster : MasterPage
    {
        protected string GetNavClass(string pageName)
        {
            return Page.AppRelativeVirtualPath.EndsWith(pageName, StringComparison.OrdinalIgnoreCase)
                ? "nav-link active"
                : "nav-link";
        }
    }
}