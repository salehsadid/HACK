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

    private void BindApplicants()
    {
        applicantsGrid.DataSource = HACK.WebForms.HackRepository.GetApplicants();
        applicantsGrid.DataBind();
    }

    private void SetStatus(string message, bool success)
    {
        pageStatus.Text     = message;
        pageStatus.CssClass = success ? "form-status success" : "form-status error";
    }
}
