<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Admin.master" CodeFile="Dashboard.aspx.cs" Inherits="AdminDashboard" Title="Dashboard — HACK Admin" %>

<asp:Content ID="C1" ContentPlaceHolderID="AdminContent" runat="server">
    <div class="admin-section-head">
        <div>
            <p class="eyebrow">Overview</p>
            <h1>Dashboard</h1>
        </div>
    </div>

    <div class="dash-stats">
        <a href="Members.aspx" class="dash-stat-card">
            <span class="dash-stat-label">Total Members</span>
            <asp:Label ID="lblMembers" runat="server" CssClass="dash-stat-count" Text="0" />
        </a>
        <a href="Applicants.aspx" class="dash-stat-card">
            <span class="dash-stat-label">New Applicants</span>
            <asp:Label ID="lblApplicants" runat="server" CssClass="dash-stat-count" Text="0" />
        </a>
        <a href="Notices.aspx" class="dash-stat-card">
            <span class="dash-stat-label">Active Notices</span>
            <asp:Label ID="lblNotices" runat="server" CssClass="dash-stat-count" Text="0" />
        </a>
        <a href="#" class="dash-stat-card">
            <span class="dash-stat-label">Total Admins</span>
            <asp:Label ID="lblAdmins" runat="server" CssClass="dash-stat-count" Text="0" />
        </a>
    </div>
</asp:Content>
