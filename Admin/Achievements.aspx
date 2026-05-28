<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Admin.master" CodeFile="Achievements.aspx.cs" Inherits="AdminAchievements" Title="Achievements — HACK Admin" %>

<asp:Content ID="C1" ContentPlaceHolderID="AdminContent" runat="server">
    <div class="admin-section-head">
        <div>
            <p class="eyebrow">Content Management</p>
            <h1>Achievements</h1>
        </div>
    </div>

    <asp:Label ID="pageStatus" runat="server" CssClass="form-status" EnableViewState="false" />

    <section class="admin-card">
        <header class="admin-section-head">
            <div><h2>Add Achievement</h2></div>
        </header>
        <div class="form-grid admin-form">
            <div class="form-field">
                <label for="contentTitle">Title</label>
                <asp:TextBox ID="contentTitle" runat="server" ClientIDMode="Static" />
                <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="contentTitle" ValidationGroup="Content" ErrorMessage="Title is required." CssClass="field-error" Display="Dynamic" />
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
                <asp:TextBox ID="contentImage" runat="server" ClientIDMode="Static" />
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
            <asp:Button ID="addButton" runat="server" CssClass="btn btn-primary" Text="Add Achievement" ValidationGroup="Content" OnClick="AddContent_Click" />
        </div>
    </section>

    <section class="admin-card table-card">
        <h2>All Achievements</h2>
        <asp:GridView ID="contentGrid" runat="server" CssClass="admin-table" AutoGenerateColumns="false"
            DataKeyNames="Id"
            OnRowEditing="ContentGrid_RowEditing"
            OnRowCancelingEdit="ContentGrid_RowCancelingEdit"
            OnRowUpdating="ContentGrid_RowUpdating"
            OnRowDeleting="ContentGrid_RowDeleting">
            <Columns>
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Subtitle" HeaderText="Subtitle" />
                <asp:BoundField DataField="Body" HeaderText="Body" />
                <asp:BoundField DataField="ImageUrl" HeaderText="Image URL" />
                <asp:BoundField DataField="Meta" HeaderText="Meta" />
                <asp:BoundField DataField="DisplayOrder" HeaderText="Order" />
                <asp:CheckBoxField DataField="IsActive" HeaderText="Active" />
                <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
            </Columns>
        </asp:GridView>
    </section>
</asp:Content>
