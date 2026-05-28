<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" Title="Admin Dashboard" %>

<asp:Content ID="DashboardHead" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="<%: ResolveUrl("~/admin.css?v=20260517-1") %>" />
</asp:Content>

<asp:Content ID="DashboardContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="admin-page">
        <section class="admin-hero">
            <div>
                <p class="eyebrow">Admin Dashboard</p>
                <h1>Control HACK club content, applicants, and members.</h1>
            </div>
            <asp:Button ID="logoutButton" runat="server" CssClass="btn btn-ghost" Text="Logout" CausesValidation="false" OnClick="Logout_Click" />
        </section>

        <asp:Label ID="adminStatus" runat="server" CssClass="form-status" EnableViewState="false" />

        <section class="admin-card">
            <header class="admin-section-head">
                <div>
                    <p class="eyebrow">Home Page CMS</p>
                    <h2>Add Notice, Gallery, Achievement, or Project</h2>
                </div>
            </header>

            <div class="form-grid admin-form">
                <div class="form-field">
                    <label for="contentKind">Content Type</label>
                    <asp:DropDownList ID="contentKind" runat="server" ClientIDMode="Static">
                        <asp:ListItem Text="Notice" Value="notice" />
                        <asp:ListItem Text="Gallery" Value="gallery" />
                        <asp:ListItem Text="Achievement" Value="achievement" />
                        <asp:ListItem Text="Project" Value="project" />
                    </asp:DropDownList>
                </div>
                <div class="form-field">
                    <label for="contentTitle">Title</label>
                    <asp:TextBox ID="contentTitle" runat="server" ClientIDMode="Static" />
                    <asp:RequiredFieldValidator ID="rfvContentTitle" runat="server" ControlToValidate="contentTitle" ValidationGroup="Content" ErrorMessage="Title is required." CssClass="field-error" Display="Dynamic" />
                </div>
                <div class="form-field">
                    <label for="contentSubtitle">Subtitle</label>
                    <asp:TextBox ID="contentSubtitle" runat="server" ClientIDMode="Static" />
                </div>
                <div class="form-field">
                    <label for="contentMeta">Meta / Date / Status</label>
                    <asp:TextBox ID="contentMeta" runat="server" ClientIDMode="Static" />
                </div>
                <div class="form-field">
                    <label for="contentImage">Image URL</label>
                    <asp:TextBox ID="contentImage" runat="server" ClientIDMode="Static" placeholder="https://images.unsplash.com/photo-1518770660439-4636190af475?auto=format&amp;fit=crop&amp;w=1200&amp;q=85" />
                </div>
                <div class="form-field">
                    <label for="contentOrder">Display Order</label>
                    <asp:TextBox ID="contentOrder" runat="server" ClientIDMode="Static" TextMode="Number" Text="1" />
                </div>
                <div class="form-field full">
                    <label for="contentBody">Body</label>
                    <asp:TextBox ID="contentBody" runat="server" ClientIDMode="Static" TextMode="MultiLine" MaxLength="900" />
                </div>
            </div>
            <div class="admin-actions">
                <asp:Button ID="addContentButton" runat="server" CssClass="btn btn-primary" Text="Add Content" ValidationGroup="Content" OnClick="AddContent_Click" />
            </div>
        </section>

        <section class="admin-card table-card">
            <h2>Home Page Content</h2>
            <asp:GridView ID="contentGrid" runat="server" CssClass="admin-table" AutoGenerateColumns="false"
                DataKeyNames="Id"
                OnRowEditing="ContentGrid_RowEditing"
                OnRowCancelingEdit="ContentGrid_RowCancelingEdit"
                OnRowUpdating="ContentGrid_RowUpdating"
                OnRowDeleting="ContentGrid_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="ContentType" HeaderText="Type" />
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="Subtitle" HeaderText="Subtitle" />
                    <asp:BoundField DataField="Body" HeaderText="Body" />
                    <asp:BoundField DataField="ImageUrl" HeaderText="Image" />
                    <asp:BoundField DataField="Meta" HeaderText="Meta" />
                    <asp:BoundField DataField="DisplayOrder" HeaderText="Order" />
                    <asp:CheckBoxField DataField="IsActive" HeaderText="Active" />
                    <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
                </Columns>
            </asp:GridView>
        </section>

        <section class="admin-card table-card">
            <h2>New Applicants</h2>
            <asp:GridView ID="applicantsGrid" runat="server" CssClass="admin-table" AutoGenerateColumns="false"
                DataKeyNames="Id"
                OnRowCommand="ApplicantsGrid_RowCommand"
                OnRowDeleting="ApplicantsGrid_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Phone" HeaderText="Phone" />
                    <asp:BoundField DataField="Department" HeaderText="Department" />
                    <asp:BoundField DataField="Batch" HeaderText="Batch" />
                    <asp:BoundField DataField="InterestArea" HeaderText="Interest" />
                    <asp:BoundField DataField="Motivation" HeaderText="Motivation" />
                    <asp:ButtonField ButtonType="Button" CommandName="ApproveApplicant" Text="Approve" ControlStyle-CssClass="mini-button primary" />
                    <asp:CommandField ShowDeleteButton="true" DeleteText="Delete" ControlStyle-CssClass="mini-button danger" />
                </Columns>
            </asp:GridView>
        </section>

        <section class="admin-card">
            <header class="admin-section-head">
                <div>
                    <p class="eyebrow">Members</p>
                    <h2>Insert Member Manually</h2>
                </div>
            </header>
            <div class="form-grid admin-form">
                <div class="form-field"><label for="addFullName">Full Name</label><asp:TextBox ID="addFullName" runat="server" ClientIDMode="Static" /></div>
                <div class="form-field"><label for="addEmail">Email</label><asp:TextBox ID="addEmail" runat="server" ClientIDMode="Static" TextMode="Email" /></div>
                <div class="form-field"><label for="addPhone">Phone</label><asp:TextBox ID="addPhone" runat="server" ClientIDMode="Static" /></div>
                <div class="form-field"><label for="addDepartment">Department</label><asp:TextBox ID="addDepartment" runat="server" ClientIDMode="Static" /></div>
                <div class="form-field"><label for="addBatch">Batch</label><asp:TextBox ID="addBatch" runat="server" ClientIDMode="Static" /></div>
                <div class="form-field"><label for="addInterest">Interest Area</label><asp:TextBox ID="addInterest" runat="server" ClientIDMode="Static" /></div>
                <div class="form-field full"><label for="addMotivation">Motivation</label><asp:TextBox ID="addMotivation" runat="server" ClientIDMode="Static" TextMode="MultiLine" MaxLength="600" /></div>
            </div>
            <div class="admin-actions">
                <asp:Button ID="addMemberButton" runat="server" CssClass="btn btn-primary" Text="Add Member" CausesValidation="false" OnClick="AddMember_Click" />
            </div>
        </section>

        <section class="admin-card table-card">
            <h2>Registered Members</h2>
            <asp:GridView ID="membersGrid" runat="server" CssClass="admin-table" AutoGenerateColumns="false"
                DataKeyNames="Id"
                OnRowEditing="MembersGrid_RowEditing"
                OnRowCancelingEdit="MembersGrid_RowCancelingEdit"
                OnRowUpdating="MembersGrid_RowUpdating"
                OnRowDeleting="MembersGrid_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Phone" HeaderText="Phone" />
                    <asp:BoundField DataField="Department" HeaderText="Department" />
                    <asp:BoundField DataField="Batch" HeaderText="Batch" />
                    <asp:BoundField DataField="InterestArea" HeaderText="Interest Area" />
                    <asp:BoundField DataField="Motivation" HeaderText="Motivation" />
                    <asp:BoundField DataField="SubmittedAt" HeaderText="Submitted (UTC)" DataFormatString="{0:yyyy-MM-dd HH:mm}" ReadOnly="true" />
                    <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
                </Columns>
            </asp:GridView>
        </section>
    </main>
</asp:Content>
