using System;
using System.Web.UI;

public partial class Global : System.Web.HttpApplication
{
    protected void Application_Start(object sender, EventArgs e)
    {
        ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
    }
}
