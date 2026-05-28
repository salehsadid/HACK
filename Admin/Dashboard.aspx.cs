using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Dashboard : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminUser"] == null)
        {
            Response.Redirect("Login.aspx");
            return;
        }

        if (!IsPostBack)
        {
            BindAll();
        }
    }

    protected void AddContent_Click(object sender, EventArgs e)
    {
        Page.Validate("Content");
        if (!Page.IsValid)
        {
            return;
        }

        HACK.WebForms.HackRepository.InsertContent(ReadContentForm());
        SetStatus("Content added.", true);
        ClearContentForm();
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
            ContentType = ReadValue(e.NewValues["ContentType"]),
            Title = ReadValue(e.NewValues["Title"]),
            Subtitle = ReadValue(e.NewValues["Subtitle"]),
            Body = ReadValue(e.NewValues["Body"]),
            ImageUrl = ReadValue(e.NewValues["ImageUrl"]),
            Meta = ReadValue(e.NewValues["Meta"]),
            DisplayOrder = ToInt(ReadValue(e.NewValues["DisplayOrder"]), 0),
            IsActive = ToBool(e.NewValues["IsActive"])
        });

        contentGrid.EditIndex = -1;
        SetStatus("Content updated.", true);
        BindContent();
    }

    protected void ContentGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        HACK.WebForms.HackRepository.DeleteContent((int)contentGrid.DataKeys[e.RowIndex].Value);
        SetStatus("Content deleted.", true);
        BindContent();
    }

    protected void ApplicantsGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName != "ApproveApplicant")
        {
            return;
        }

        var rowIndex = Convert.ToInt32(e.CommandArgument);
        var id = (int)applicantsGrid.DataKeys[rowIndex].Value;
        HACK.WebForms.HackRepository.ApproveApplicant(id);
        SetStatus("Applicant approved and moved to members.", true);
        BindApplicants();
        BindMembers();
    }

    protected void ApplicantsGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        HACK.WebForms.HackRepository.DeleteApplicant((int)applicantsGrid.DataKeys[e.RowIndex].Value);
        SetStatus("Applicant deleted permanently.", true);
        BindApplicants();
    }

    protected void AddMember_Click(object sender, EventArgs e)
    {
        HACK.WebForms.HackRepository.InsertMember(new HACK.WebForms.RegistrationEntry
        {
            FullName = addFullName.Text.Trim(),
            Email = addEmail.Text.Trim(),
            Phone = addPhone.Text.Trim(),
            Department = addDepartment.Text.Trim(),
            Batch = addBatch.Text.Trim(),
            InterestArea = addInterest.Text.Trim(),
            Motivation = addMotivation.Text.Trim(),
            SubmittedAt = DateTime.UtcNow
        });

        SetStatus("Member added.", true);
        ClearMemberForm();
        BindMembers();
    }

    protected void MembersGrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        membersGrid.EditIndex = e.NewEditIndex;
        BindMembers();
    }

    protected void MembersGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        membersGrid.EditIndex = -1;
        BindMembers();
    }

    protected void MembersGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var id = (int)membersGrid.DataKeys[e.RowIndex].Value;
        HACK.WebForms.HackRepository.UpdateMember(id, new HACK.WebForms.RegistrationEntry
        {
            FullName = ReadValue(e.NewValues["FullName"]),
            Email = ReadValue(e.NewValues["Email"]),
            Phone = ReadValue(e.NewValues["Phone"]),
            Department = ReadValue(e.NewValues["Department"]),
            Batch = ReadValue(e.NewValues["Batch"]),
            InterestArea = ReadValue(e.NewValues["InterestArea"]),
            Motivation = ReadValue(e.NewValues["Motivation"])
        });

        membersGrid.EditIndex = -1;
        SetStatus("Member updated.", true);
        BindMembers();
    }

    protected void MembersGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        HACK.WebForms.HackRepository.DeleteMember((int)membersGrid.DataKeys[e.RowIndex].Value);
        SetStatus("Member deleted.", true);
        BindMembers();
    }

    protected void Logout_Click(object sender, EventArgs e)
    {
        Session.Remove("AdminUser");
        Response.Redirect("Login.aspx");
    }

    private void BindAll()
    {
        BindContent();
        BindApplicants();
        BindMembers();
    }

    private void BindContent()
    {
        contentGrid.DataSource = HACK.WebForms.HackRepository.GetContent();
        contentGrid.DataBind();
    }

    private void BindApplicants()
    {
        applicantsGrid.DataSource = HACK.WebForms.HackRepository.GetApplicants();
        applicantsGrid.DataBind();
    }

    private void BindMembers()
    {
        membersGrid.DataSource = HACK.WebForms.HackRepository.GetMembers();
        membersGrid.DataBind();
    }

    private HACK.WebForms.ClubContentItem ReadContentForm()
    {
        return new HACK.WebForms.ClubContentItem
        {
            ContentType = contentKind.SelectedValue,
            Title = contentTitle.Text.Trim(),
            Subtitle = contentSubtitle.Text.Trim(),
            Body = contentBody.Text.Trim(),
            ImageUrl = contentImage.Text.Trim(),
            Meta = contentMeta.Text.Trim(),
            DisplayOrder = ToInt(contentOrder.Text, 0),
            IsActive = true
        };
    }

    private void ClearContentForm()
    {
        contentTitle.Text = string.Empty;
        contentSubtitle.Text = string.Empty;
        contentMeta.Text = string.Empty;
        contentImage.Text = string.Empty;
        contentBody.Text = string.Empty;
        contentOrder.Text = "1";
    }

    private void ClearMemberForm()
    {
        addFullName.Text = string.Empty;
        addEmail.Text = string.Empty;
        addPhone.Text = string.Empty;
        addDepartment.Text = string.Empty;
        addBatch.Text = string.Empty;
        addInterest.Text = string.Empty;
        addMotivation.Text = string.Empty;
    }

    private void SetStatus(string message, bool success)
    {
        adminStatus.Text = message;
        adminStatus.CssClass = success ? "form-status success" : "form-status error";
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
        if (value is bool)
        {
            return (bool)value;
        }

        bool parsed;
        return bool.TryParse(ReadValue(value), out parsed) && parsed;
    }
}
