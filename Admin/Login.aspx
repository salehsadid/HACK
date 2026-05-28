<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="Login.aspx.cs" Inherits="Login" Title="Admin Login" %>

<asp:Content ID="LoginHead" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="<%: ResolveUrl("~/admin.css?v=20260517-1") %>" />
</asp:Content>

<asp:Content ID="LoginContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="subpage">
        <section class="registration-shell">
            <div class="registration-intro">
                <p class="eyebrow">Admin Access</p>
                <h1>Manage the club site.</h1>
                <p>Admins can publish home page content, review applicants, approve members, and maintain member records.</p>
            </div>

            <section class="form-panel">
                <div class="form-grid">
                    <div class="form-field full">
                        <label for="username">Username</label>
                        <asp:TextBox ID="username" runat="server" ClientIDMode="Static" />
                        <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="username" ValidationGroup="Login" ErrorMessage="Username is required." CssClass="field-error" Display="Dynamic" />
                    </div>
                    <div class="form-field full">
                        <label for="password">Password</label>
                        <asp:TextBox ID="password" runat="server" ClientIDMode="Static" TextMode="Password" />
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="password" ValidationGroup="Login" ErrorMessage="Password is required." CssClass="field-error" Display="Dynamic" />
                    </div>
                </div>
                <div class="form-actions">
                    <asp:Button ID="loginButton" runat="server" CssClass="btn btn-primary" Text="Login" ValidationGroup="Login" OnClick="Login_Click" />
                </div>
                <asp:Label ID="loginStatus" runat="server" CssClass="form-status" EnableViewState="false" />
            </section>
        </section>
    </main>
</asp:Content>
