using System;
using System.Web;
using System.Web.UI;

public partial class About : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var aboutText = HACK.WebForms.HackRepository.GetAboutText();
            lblAbout.Text = aboutText.Length > 0
                ? HttpUtility.HtmlEncode(aboutText)
                : "HACK is the Hardware Acceleration Club of KUET, dedicated to embedded systems, robotics, FPGA, IoT, automation, and student-built hardware products.";

            moderatorsRepeater.DataSource = HACK.WebForms.HackRepository.GetClubPersons("moderator");
            moderatorsRepeater.DataBind();

            executivesRepeater.DataSource = HACK.WebForms.HackRepository.GetClubPersons("executive");
            executivesRepeater.DataBind();
        }
    }

    protected string PersonImgSrc(object id)
    {
        return ResolveUrl("~/ImageHandler.ashx?src=person&id=" + id);
    }
}
