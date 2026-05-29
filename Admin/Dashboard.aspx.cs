using System;
using System.Web.UI;

public partial class AdminDashboard : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblMembers.Text   = HACK.WebForms.HackRepository.GetMembers().Rows.Count.ToString();
            lblApplicants.Text = HACK.WebForms.HackRepository.GetApplicants().Rows.Count.ToString();
            lblNotices.Text   = HACK.WebForms.HackRepository.GetContent("notice").Rows.Count.ToString();
        }
    }
}
