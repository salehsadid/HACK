using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminAchievements : Page
{
    private const string ContentType = "achievement";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindContent();
    }

    protected void AddContent_Click(object sender, EventArgs e)
    {
        Page.Validate("Content");
        if (!Page.IsValid) return;

        HACK.WebForms.HackRepository.InsertContent(new HACK.WebForms.ClubContentItem
        {
            ContentType  = ContentType,
            Title        = contentTitle.Text.Trim(),
            Subtitle     = contentSubtitle.Text.Trim(),
            Body         = contentBody.Text.Trim(),
            ImageUrl     = contentImage.Text.Trim(),
            Meta         = contentMeta.Text.Trim(),
            DisplayOrder = ToInt(contentOrder.Text, 0),
            IsActive     = true
        });

        SetStatus("Achievement added.", true);
        ClearForm();
        BindContent();
    }

    protected void ContentGrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        contentGrid.EditIndex = e.NewEditIndex;
        BindContent();
    }

    protected void ContentGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        contentGrid.EditIndex = -1;
        BindContent();
    }

    protected void ContentGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var id = (int)contentGrid.DataKeys[e.RowIndex].Value;
        HACK.WebForms.HackRepository.UpdateContent(id, new HACK.WebForms.ClubContentItem
        {
            ContentType  = ContentType,
            Title        = ReadValue(e.NewValues["Title"]),
            Subtitle     = ReadValue(e.NewValues["Subtitle"]),
            Body         = ReadValue(e.NewValues["Body"]),
            ImageUrl     = ReadValue(e.NewValues["ImageUrl"]),
            Meta         = ReadValue(e.NewValues["Meta"]),
            DisplayOrder = ToInt(ReadValue(e.NewValues["DisplayOrder"]), 0),
            IsActive     = ToBool(e.NewValues["IsActive"])
        });

        contentGrid.EditIndex = -1;
        SetStatus("Achievement updated.", true);
        BindContent();
    }

    protected void ContentGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        HACK.WebForms.HackRepository.DeleteContent((int)contentGrid.DataKeys[e.RowIndex].Value);
        SetStatus("Achievement deleted.", true);
        BindContent();
    }

    private void BindContent()
    {
        var dt = HACK.WebForms.HackRepository.GetContent();
        var view = new DataView(dt);
        view.RowFilter = "ContentType = '" + ContentType + "'";
        contentGrid.DataSource = view;
        contentGrid.DataBind();
    }

    private void ClearForm()
    {
        contentTitle.Text    = string.Empty;
        contentSubtitle.Text = string.Empty;
        contentMeta.Text     = string.Empty;
        contentImage.Text    = string.Empty;
        contentBody.Text     = string.Empty;
        contentOrder.Text    = "1";
    }

    private void SetStatus(string message, bool success)
    {
        pageStatus.Text     = message;
        pageStatus.CssClass = success ? "form-status success" : "form-status error";
    }

    private static string ReadValue(object value) => (value ?? string.Empty).ToString().Trim();

    private static int ToInt(string value, int fallback)
    {
        int parsed;
        return int.TryParse(value, out parsed) ? parsed : fallback;
    }

    private static bool ToBool(object value)
    {
        if (value is bool) return (bool)value;
        bool parsed;
        return bool.TryParse(ReadValue(value), out parsed) && parsed;
    }
}
