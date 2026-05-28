using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HACK.WebForms
{
    public partial class Register : Page
    {
        protected void SubmitApplication_Click(object sender, EventArgs e)
        {
            Page.Validate("Register");

            if (!Page.IsValid)
            {
                FormStatus.Text = "Please correct the highlighted fields and try again.";
                FormStatus.CssClass = "form-status error";
                return;
            }

            try
            {
                HackRepository.InsertApplicant(new RegistrationEntry
                {
                    FullName = FullNameBox.Text.Trim(),
                    Email = EmailBox.Text.Trim(),
                    Phone = PhoneBox.Text.Trim(),
                    Department = DepartmentBox.Text.Trim(),
                    Batch = BatchBox.Text.Trim(),
                    InterestArea = InterestBox.SelectedValue,
                    Motivation = MessageBox.Text.Trim(),
                    SubmittedAt = DateTime.UtcNow
                });

                FormStatus.Text = "Application submitted successfully. An admin will review it before adding you as a member.";
                FormStatus.CssClass = "form-status success";

                ClearForm();
            }
            catch
            {
                FormStatus.Text = "Registration failed. Please try again later.";
                FormStatus.CssClass = "form-status error";
            }
        }

        private void ClearForm()
        {
            FullNameBox.Text = string.Empty;
            EmailBox.Text = string.Empty;
            PhoneBox.Text = string.Empty;
            DepartmentBox.Text = string.Empty;
            BatchBox.Text = string.Empty;
            InterestBox.ClearSelection();
            MessageBox.Text = string.Empty;
        }

        private T GetMainContentControl<T>(string id) where T : Control
        {
            var contentPlaceHolder = Master.FindControl("MainContent") as ContentPlaceHolder;
            return contentPlaceHolder == null ? null : contentPlaceHolder.FindControl(id) as T;
        }

        private TextBox FullNameBox
        {
            get { return GetMainContentControl<TextBox>("fullName"); }
        }

        private TextBox EmailBox
        {
            get { return GetMainContentControl<TextBox>("email"); }
        }

        private TextBox PhoneBox
        {
            get { return GetMainContentControl<TextBox>("phone"); }
        }

        private TextBox DepartmentBox
        {
            get { return GetMainContentControl<TextBox>("department"); }
        }

        private TextBox BatchBox
        {
            get { return GetMainContentControl<TextBox>("batch"); }
        }

        private DropDownList InterestBox
        {
            get { return GetMainContentControl<DropDownList>("interest"); }
        }

        private TextBox MessageBox
        {
            get { return GetMainContentControl<TextBox>("message"); }
        }

        private Label FormStatus
        {
            get { return GetMainContentControl<Label>("formStatus"); }
        }
    }
}
