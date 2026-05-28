<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Admin.master" CodeFile="Applicants.aspx.cs" Inherits="AdminApplicants" Title="Applicants — HACK Admin" %>

<asp:Content ID="C1" ContentPlaceHolderID="AdminContent" runat="server">
    <div class="admin-section-head">
        <div>
            <p class="eyebrow">Applications</p>
            <h1>New Applicants</h1>
        </div>
    </div>

    <asp:Label ID="pageStatus" runat="server" CssClass="form-status" EnableViewState="false" />

    <section class="admin-card table-card">
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
</asp:Content>
