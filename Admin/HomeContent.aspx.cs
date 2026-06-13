using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminHomeContent : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindSettings();
        }
    }

    protected void SaveHomeContent_Click(object sender, EventArgs e)
    {
        HACK.WebForms.HackRepository.SaveHomePageSettings(new HACK.WebForms.HomePageSettings
        {
            HeroEyebrow = heroEyebrowInput.Text.Trim(),
            HeroTitle = heroTitleInput.Text.Trim(),
            HeroCopy = heroCopyInput.Text.Trim(),
            HeroImageUrl = heroImageUrlInput.Text.Trim(),
            HeroPrimaryText = heroPrimaryTextInput.Text.Trim(),
            HeroPrimaryUrl = heroPrimaryUrlInput.Text.Trim(),
            HeroSecondaryText = heroSecondaryTextInput.Text.Trim(),
            HeroSecondaryUrl = heroSecondaryUrlInput.Text.Trim(),
            Metrics = new List<HACK.WebForms.HomeMetric>
            {
                ReadMetric(metric1Value, metric1Label),
                ReadMetric(metric2Value, metric2Label),
                ReadMetric(metric3Value, metric3Label),
                ReadMetric(metric4Value, metric4Label)
            },
            WhatEyebrow = whatEyebrowInput.Text.Trim(),
            WhatTitle = whatTitleInput.Text.Trim(),
            Features = new List<HACK.WebForms.HomeFeature>
            {
                ReadFeature(feature1Number, feature1Title, feature1Description),
                ReadFeature(feature2Number, feature2Title, feature2Description),
                ReadFeature(feature3Number, feature3Title, feature3Description),
                ReadFeature(feature4Number, feature4Title, feature4Description)
            }
        });

        SetStatus("Home page content saved.", true);
        BindSettings();
    }

    private void BindSettings()
    {
        var settings = HACK.WebForms.HackRepository.GetHomePageSettings();

        heroEyebrowInput.Text = settings.HeroEyebrow;
        heroTitleInput.Text = settings.HeroTitle;
        heroCopyInput.Text = settings.HeroCopy;
        heroImageUrlInput.Text = settings.HeroImageUrl;
        heroPrimaryTextInput.Text = settings.HeroPrimaryText;
        heroPrimaryUrlInput.Text = settings.HeroPrimaryUrl;
        heroSecondaryTextInput.Text = settings.HeroSecondaryText;
        heroSecondaryUrlInput.Text = settings.HeroSecondaryUrl;
        WriteMetric(settings.Metrics[0], metric1Value, metric1Label);
        WriteMetric(settings.Metrics[1], metric2Value, metric2Label);
        WriteMetric(settings.Metrics[2], metric3Value, metric3Label);
        WriteMetric(settings.Metrics[3], metric4Value, metric4Label);
        whatEyebrowInput.Text = settings.WhatEyebrow;
        whatTitleInput.Text = settings.WhatTitle;

        WriteFeature(settings.Features[0], feature1Number, feature1Title, feature1Description);
        WriteFeature(settings.Features[1], feature2Number, feature2Title, feature2Description);
        WriteFeature(settings.Features[2], feature3Number, feature3Title, feature3Description);
        WriteFeature(settings.Features[3], feature4Number, feature4Title, feature4Description);
    }

    private static HACK.WebForms.HomeFeature ReadFeature(TextBox number, TextBox title, TextBox description)
    {
        return new HACK.WebForms.HomeFeature
        {
            Number = number.Text.Trim(),
            Title = title.Text.Trim(),
            Description = description.Text.Trim()
        };
    }

    private static HACK.WebForms.HomeMetric ReadMetric(TextBox value, TextBox label)
    {
        return new HACK.WebForms.HomeMetric
        {
            Value = value.Text.Trim(),
            Label = label.Text.Trim()
        };
    }

    private static void WriteFeature(HACK.WebForms.HomeFeature feature, TextBox number, TextBox title, TextBox description)
    {
        number.Text = feature.Number;
        title.Text = feature.Title;
        description.Text = feature.Description;
    }

    private static void WriteMetric(HACK.WebForms.HomeMetric metric, TextBox value, TextBox label)
    {
        value.Text = metric.Value;
        label.Text = metric.Label;
    }

    private void SetStatus(string message, bool success)
    {
        pageStatus.Text = message;
        pageStatus.CssClass = success ? "form-status success" : "form-status error";
    }
}
