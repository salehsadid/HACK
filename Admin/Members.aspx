<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Admin.master" CodeFile="Members.aspx.cs" Inherits="AdminMembers" Title="Members — HACK Admin" %>

<asp:Content ID="C1" ContentPlaceHolderID="AdminContent" runat="server">
    <div class="admin-section-head">
        <div>
            <p class="eyebrow">Member Records</p>
            <h1>Members</h1>
        </div>
    </div>

    <asp:Label ID="pageStatus" runat="server" CssClass="form-status" EnableViewState="false" />

    <section class="admin-card">
        <header class="admin-section-head">
            <div><h2>Add Member Manually</h2></div>
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
        <div class="admin-section-head">
            <h2>Registered Members</h2>
            <div class="search-bar">
                <asp:TextBox ID="searchBox" runat="server" placeholder="Search name, email, dept, batch…" />
                <asp:Button ID="searchBtn" runat="server" Text="Search" CssClass="btn btn-ghost btn-sm" CausesValidation="false" OnClick="Search_Click" />
            </div>
        </div>
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
</asp:Content>
