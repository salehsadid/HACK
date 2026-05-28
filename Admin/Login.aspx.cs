using System;
using System.Web.UI;

public partial class Login : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminUser"] != null)
        {
            Response.Redirect("Dashboard.aspx");
        }
    }

    protected void Login_Click(object sender, EventArgs e)
    {
        Page.Validate("Login");

        if (!Page.IsValid)
        {
            return;
        }

        var isValid = HACK.WebForms.HackRepository.ValidateAdmin(username.Text.Trim(), password.Text);

        if (isValid)
        {
            Session["AdminUser"] = username.Text.Trim();
            Response.Redirect("Dashboard.aspx");
            return;
        }

        loginStatus.Text = "Invalid username or password.";
        loginStatus.CssClass = "form-status error";
    }
}
