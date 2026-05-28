using System;
using System.Web.UI;

public partial class Members : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Redirect("Dashboard.aspx");
    }
}
