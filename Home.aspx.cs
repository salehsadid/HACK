using System;
using System.Web.UI;

public partial class Home : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindHomeContent();
    }

    protected string ContentImgSrc(object id)
    {
        return ResolveUrl("~/ImageHandler.ashx?src=content&id=" + id);
    }

    protected bool NoticeHasImage(object val)
    {
        if (val == null || val == DBNull.Value) return false;
        return Convert.ToBoolean(val);
    }

    private void BindHomeContent()
    {
        noticesRepeater.DataSource = HACK.WebForms.HackRepository.GetContent("notice");
        noticesRepeater.DataBind();

        achievementsRepeater.DataSource = HACK.WebForms.HackRepository.GetContent("achievement");
        achievementsRepeater.DataBind();

        projectsRepeater.DataSource = HACK.WebForms.HackRepository.GetContent("project");
        projectsRepeater.DataBind();

        galleryRepeater.DataSource = HACK.WebForms.HackRepository.GetContent("gallery");
        galleryRepeater.DataBind();
    }
}
