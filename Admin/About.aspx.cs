using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminAbout : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            aboutText.Text = HACK.WebForms.HackRepository.GetAboutText();
            BindModerators();
            BindExecutives();
        }
    }

    protected string PersonImgSrc(object id)
    {
        return ResolveUrl("~/ImageHandler.ashx?src=person&id=" + id);
    }

    // ── About text ────────────────────────────────────────────

    protected void SaveAbout_Click(object sender, EventArgs e)
    {
        HACK.WebForms.HackRepository.SaveAboutText(aboutText.Text.Trim());
        SetStatus("Club description saved.", true);
    }

    // ── Moderators ────────────────────────────────────────────

    protected void AddModerator_Click(object sender, EventArgs e)
    {
        HACK.WebForms.HackRepository.InsertClubPerson(new HACK.WebForms.ClubPerson
        {
            PersonType      = "moderator",
            ClubDesignation = addModDesignation.Text.Trim(),
            Name            = addModName.Text.Trim(),
            ImageData       = addModImage.HasFile ? addModImage.FileBytes : null,
            ImageMimeType   = addModImage.HasFile ? addModImage.PostedFile.ContentType : null,
            Info            = addModInfo.Text.Trim(),
            DisplayOrder    = ToInt(addModOrder.Text, 1),
            IsActive        = true
        });
        SetStatus("Moderator added.", true);
        ClearModForm();
        BindModerators();
    }

    protected void ModGrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        modGrid.EditIndex = e.NewEditIndex;
        BindModerators();
    }

    protected void ModGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        modGrid.EditIndex = -1;
        BindModerators();
    }

    protected void ModGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var id = (int)modGrid.DataKeys[e.RowIndex].Value;
        var fu = (FileUpload)modGrid.Rows[e.RowIndex].FindControl("imgUpload");

        HACK.WebForms.HackRepository.UpdateClubPerson(id, new HACK.WebForms.ClubPerson
        {
            PersonType      = "moderator",
            ClubDesignation = ReadValue(e.NewValues["ClubDesignation"]),
            Name            = ReadValue(e.NewValues["Name"]),
            ImageData       = fu != null && fu.HasFile ? fu.FileBytes : null,
            ImageMimeType   = fu != null && fu.HasFile ? fu.PostedFile.ContentType : null,
            Info            = ReadValue(e.NewValues["Info"]),
            DisplayOrder    = ToInt(ReadValue(e.NewValues["DisplayOrder"]), 0),
            IsActive        = ToBool(e.NewValues["IsActive"])
        });
        modGrid.EditIndex = -1;
        SetStatus("Moderator updated.", true);
        BindModerators();
    }

    protected void ModGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        HACK.WebForms.HackRepository.DeleteClubPerson((int)modGrid.DataKeys[e.RowIndex].Value);
        SetStatus("Moderator deleted.", true);
        BindModerators();
    }

    // ── Executives ────────────────────────────────────────────

    protected void AddExecutive_Click(object sender, EventArgs e)
    {
        HACK.WebForms.HackRepository.InsertClubPerson(new HACK.WebForms.ClubPerson
        {
            PersonType      = "executive",
            ClubDesignation = addExDesignation.Text.Trim(),
            Name            = addExName.Text.Trim(),
            ImageData       = addExImage.HasFile ? addExImage.FileBytes : null,
            ImageMimeType   = addExImage.HasFile ? addExImage.PostedFile.ContentType : null,
            Info            = addExInfo.Text.Trim(),
            DisplayOrder    = ToInt(addExOrder.Text, 1),
            IsActive        = true
        });
        SetStatus("Executive member added.", true);
        ClearExForm();
        BindExecutives();
    }

    protected void ExGrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        exGrid.EditIndex = e.NewEditIndex;
        BindExecutives();
    }

    protected void ExGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        exGrid.EditIndex = -1;
        BindExecutives();
    }

    protected void ExGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var id = (int)exGrid.DataKeys[e.RowIndex].Value;
        var fu = (FileUpload)exGrid.Rows[e.RowIndex].FindControl("imgUpload");

        HACK.WebForms.HackRepository.UpdateClubPerson(id, new HACK.WebForms.ClubPerson
        {
            PersonType      = "executive",
            ClubDesignation = ReadValue(e.NewValues["ClubDesignation"]),
            Name            = ReadValue(e.NewValues["Name"]),
            ImageData       = fu != null && fu.HasFile ? fu.FileBytes : null,
            ImageMimeType   = fu != null && fu.HasFile ? fu.PostedFile.ContentType : null,
            Info            = ReadValue(e.NewValues["Info"]),
            DisplayOrder    = ToInt(ReadValue(e.NewValues["DisplayOrder"]), 0),
            IsActive        = ToBool(e.NewValues["IsActive"])
        });
        exGrid.EditIndex = -1;
        SetStatus("Executive member updated.", true);
        BindExecutives();
    }

    protected void ExGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        HACK.WebForms.HackRepository.DeleteClubPerson((int)exGrid.DataKeys[e.RowIndex].Value);
        SetStatus("Executive member deleted.", true);
        BindExecutives();
    }

    // ── Helpers ───────────────────────────────────────────────

    private void BindModerators()
    {
        var dt   = HACK.WebForms.HackRepository.GetClubPersons();
        var view = new DataView(dt);
        view.RowFilter     = "PersonType = 'moderator'";
        modGrid.DataSource = view;
        modGrid.DataBind();
    }

    private void BindExecutives()
    {
        var dt   = HACK.WebForms.HackRepository.GetClubPersons();
        var view = new DataView(dt);
        view.RowFilter    = "PersonType = 'executive'";
        exGrid.DataSource = view;
        exGrid.DataBind();
    }

    private void ClearModForm()
    {
        addModName.Text        = string.Empty;
        addModDesignation.Text = string.Empty;
        addModInfo.Text        = string.Empty;
        addModOrder.Text       = "1";
    }

    private void ClearExForm()
    {
        addExName.Text        = string.Empty;
        addExDesignation.Text = string.Empty;
        addExInfo.Text        = string.Empty;
        addExOrder.Text       = "1";
    }

    private void SetStatus(string message, bool success)
    {
        pageStatus.Text     = message;
        pageStatus.CssClass = success ? "form-status success" : "form-status error";
    }

    private static string ReadValue(object value)
    {
        return (value ?? string.Empty).ToString().Trim();
    }

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
