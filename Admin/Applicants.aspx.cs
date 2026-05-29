using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminApplicants : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindApplicants();
    }

    protected void ApplicantsGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName != "ApproveApplicant") return;

        var rowIndex = Convert.ToInt32(e.CommandArgument);
        var id = (int)applicantsGrid.DataKeys[rowIndex].Value;
        HACK.WebForms.HackRepository.ApproveApplicant(id);
        SetStatus("Applicant approved and moved to members.", true);
        BindApplicants();
    }

    protected void ApplicantsGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        HACK.WebForms.HackRepository.DeleteApplicant((int)applicantsGrid.DataKeys[e.RowIndex].Value);
        SetStatus("Applicant deleted.", true);
        BindApplicants();
    }

    protected void Search_Click(object sender, EventArgs e)
    {
        BindApplicants(searchBox.Text.Trim());
    }

    private void BindApplicants(string query = "")
    {
        var dt = HACK.WebForms.HackRepository.GetApplicants();
        if (query.Length > 0)
        {
            var view = new System.Data.DataView(dt);
            var safe = query.Replace("'", "''");
            view.RowFilter = "FullName LIKE '%" + safe + "%'"
                + " OR Email LIKE '%" + safe + "%'"
                + " OR Department LIKE '%" + safe + "%'"
                + " OR Batch LIKE '%" + safe + "%'";
            applicantsGrid.DataSource = view;
        }
        else
        {
            applicantsGrid.DataSource = dt;
        }
        applicantsGrid.DataBind();
    }

    private void SetStatus(string message, bool success)
    {
        pageStatus.Text     = message;
        pageStatus.CssClass = success ? "form-status success" : "form-status error";
    }
}
