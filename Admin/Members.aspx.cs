using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminMembers : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindMembers();
    }

    protected void AddMember_Click(object sender, EventArgs e)
    {
        HACK.WebForms.HackRepository.InsertMember(new HACK.WebForms.RegistrationEntry
        {
            FullName     = addFullName.Text.Trim(),
            Email        = addEmail.Text.Trim(),
            Phone        = addPhone.Text.Trim(),
            Department   = addDepartment.Text.Trim(),
            Batch        = addBatch.Text.Trim(),
            InterestArea = addInterest.Text.Trim(),
            Motivation   = addMotivation.Text.Trim(),
            SubmittedAt  = DateTime.UtcNow
        });

        SetStatus("Member added.", true);
        ClearForm();
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
            FullName     = ReadValue(e.NewValues["FullName"]),
            Email        = ReadValue(e.NewValues["Email"]),
            Phone        = ReadValue(e.NewValues["Phone"]),
            Department   = ReadValue(e.NewValues["Department"]),
            Batch        = ReadValue(e.NewValues["Batch"]),
            InterestArea = ReadValue(e.NewValues["InterestArea"]),
            Motivation   = ReadValue(e.NewValues["Motivation"])
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

    protected void Search_Click(object sender, EventArgs e)
    {
        BindMembers(searchBox.Text.Trim());
    }

    private void BindMembers(string query = "")
    {
        var dt = HACK.WebForms.HackRepository.GetMembers();
        if (query.Length > 0)
        {
            var view = new System.Data.DataView(dt);
            var safe = query.Replace("'", "''");
            view.RowFilter = "FullName LIKE '%" + safe + "%'"
                + " OR Email LIKE '%" + safe + "%'"
                + " OR Department LIKE '%" + safe + "%'"
                + " OR Batch LIKE '%" + safe + "%'";
            membersGrid.DataSource = view;
        }
        else
        {
            membersGrid.DataSource = dt;
        }
        membersGrid.DataBind();
    }

    private void ClearForm()
    {
        addFullName.Text    = string.Empty;
        addEmail.Text       = string.Empty;
        addPhone.Text       = string.Empty;
        addDepartment.Text  = string.Empty;
        addBatch.Text       = string.Empty;
        addInterest.Text    = string.Empty;
        addMotivation.Text  = string.Empty;
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
}
