using System;
using System.Web;
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

    protected string EncodeText(object value)
    {
        return HttpUtility.HtmlEncode(value == null ? string.Empty : value.ToString());
    }

    private void BindHomeContent()
    {
        var homeSettings = HACK.WebForms.HackRepository.GetHomePageSettings();

        heroEyebrow.Text = HttpUtility.HtmlEncode(homeSettings.HeroEyebrow);
        heroTitle.Text = HttpUtility.HtmlEncode(homeSettings.HeroTitle);
        heroCopy.Text = HttpUtility.HtmlEncode(homeSettings.HeroCopy);
        heroImage.ImageUrl = homeSettings.HeroImageUrl;
        heroImage.Visible = !string.IsNullOrWhiteSpace(homeSettings.HeroImageUrl);
        heroPrimaryLink.InnerText = homeSettings.HeroPrimaryText;
        heroPrimaryLink.HRef = homeSettings.HeroPrimaryUrl;
        heroSecondaryLink.InnerText = homeSettings.HeroSecondaryText;
        heroSecondaryLink.HRef = homeSettings.HeroSecondaryUrl;
        metricsRepeater.DataSource = homeSettings.Metrics;
        metricsRepeater.DataBind();
        whatEyebrow.Text = HttpUtility.HtmlEncode(homeSettings.WhatEyebrow);
        whatTitle.Text = HttpUtility.HtmlEncode(homeSettings.WhatTitle);
        featuresRepeater.DataSource = homeSettings.Features;
        featuresRepeater.DataBind();

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
