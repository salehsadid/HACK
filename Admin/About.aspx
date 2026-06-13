<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Admin.master" CodeFile="About.aspx.cs" Inherits="AdminAbout" Title="About Us — HACK Admin" %>

<asp:Content ID="C1" ContentPlaceHolderID="AdminContent" runat="server">
    <div class="admin-section-head">
        <div>
            <p class="eyebrow">About Page</p>
            <h1>About Us</h1>
        </div>
    </div>

    <asp:Label ID="pageStatus" runat="server" CssClass="form-status" EnableViewState="false" />

    <%-- Club description --%>
    <section class="admin-card">
        <header class="admin-section-head">
            <div><h2>Club Description</h2></div>
        </header>
        <div class="form-grid admin-form">
            <div class="form-field full">
                <label for="aboutText">About Paragraph</label>
                <asp:TextBox ID="aboutText" runat="server" ClientIDMode="Static" TextMode="MultiLine" MaxLength="1200" Rows="10" />
            </div>
        </div>
        <div class="admin-actions">
            <asp:Button ID="saveAboutBtn" runat="server" CssClass="btn btn-primary" Text="Save Description" CausesValidation="false" OnClick="SaveAbout_Click" />
        </div>
    </section>

    <%-- Add Moderator --%>
    <section class="admin-card">
        <header class="admin-section-head">
            <div><h2>Add Moderator</h2></div>
        </header>
        <div class="form-grid admin-form">
            <div class="form-field"><label>Name</label><asp:TextBox ID="addModName" runat="server" /></div>
            <div class="form-field"><label>Club Designation</label><asp:TextBox ID="addModDesignation" runat="server" placeholder="e.g. Moderator" /></div>
            <div class="form-field"><label>Info</label><asp:TextBox ID="addModInfo" runat="server" placeholder="e.g. Lecturer, Dept. of CSE, KUET" /></div>
            <div class="form-field"><label>Photo</label><asp:FileUpload ID="addModImage" runat="server" accept="image/*" /></div>
            <div class="form-field"><label>Display Order</label><asp:TextBox ID="addModOrder" runat="server" Text="1" TextMode="Number" /></div>
        </div>
        <div class="admin-actions">
            <asp:Button ID="addModBtn" runat="server" CssClass="btn btn-primary" Text="Add Moderator" CausesValidation="false" OnClick="AddModerator_Click" />
        </div>
    </section>

    <%-- Moderators grid --%>
    <section class="admin-card table-card">
        <h2>Moderators</h2>
        <asp:GridView ID="modGrid" runat="server" CssClass="admin-table" AutoGenerateColumns="false"
            DataKeyNames="Id"
            OnRowEditing="ModGrid_RowEditing"
            OnRowCancelingEdit="ModGrid_RowCancelingEdit"
            OnRowUpdating="ModGrid_RowUpdating"
            OnRowDeleting="ModGrid_RowDeleting">
            <Columns>
                <asp:TemplateField HeaderText="Photo">
                    <ItemTemplate>
                        <img src='<%# PersonImgSrc(Eval("Id")) %>' width="52" height="52" style="object-fit:cover;border-radius:50%;" onerror="this.style.display='none'" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <img src='<%# PersonImgSrc(Eval("Id")) %>' width="40" height="40" style="object-fit:cover;border-radius:50%;display:block;margin-bottom:4px;" onerror="this.style.display='none'" />
                        <asp:FileUpload ID="imgUpload" runat="server" accept="image/*" />
                        <asp:CheckBox ID="removeImage" runat="server" Text="Remove current image" />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ClubDesignation" HeaderText="Club Designation" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Info" HeaderText="Info" />
                <asp:BoundField DataField="DisplayOrder" HeaderText="Order" />
                <asp:CheckBoxField DataField="IsActive" HeaderText="Active" />
                <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
            </Columns>
        </asp:GridView>
    </section>

    <%-- Add Executive --%>
    <section class="admin-card">
        <header class="admin-section-head">
            <div><h2>Add Executive Member</h2></div>
        </header>
        <div class="form-grid admin-form">
            <div class="form-field"><label>Name</label><asp:TextBox ID="addExName" runat="server" /></div>
            <div class="form-field"><label>Club Designation</label><asp:TextBox ID="addExDesignation" runat="server" placeholder="e.g. President, Vice President, General Secretary" /></div>
            <div class="form-field"><label>Info</label><asp:TextBox ID="addExInfo" runat="server" placeholder="e.g. Roll: 1900001, Dept. of CSE, Batch 19" /></div>
            <div class="form-field"><label>Photo</label><asp:FileUpload ID="addExImage" runat="server" accept="image/*" /></div>
            <div class="form-field"><label>Display Order</label><asp:TextBox ID="addExOrder" runat="server" Text="1" TextMode="Number" /></div>
        </div>
        <div class="admin-actions">
            <asp:Button ID="addExBtn" runat="server" CssClass="btn btn-primary" Text="Add Executive" CausesValidation="false" OnClick="AddExecutive_Click" />
        </div>
    </section>

    <%-- Executives grid --%>
    <section class="admin-card table-card">
        <h2>Executive Committee</h2>
        <asp:GridView ID="exGrid" runat="server" CssClass="admin-table" AutoGenerateColumns="false"
            DataKeyNames="Id"
            OnRowEditing="ExGrid_RowEditing"
            OnRowCancelingEdit="ExGrid_RowCancelingEdit"
            OnRowUpdating="ExGrid_RowUpdating"
            OnRowDeleting="ExGrid_RowDeleting">
            <Columns>
                <asp:TemplateField HeaderText="Photo">
                    <ItemTemplate>
                        <img src='<%# PersonImgSrc(Eval("Id")) %>' width="52" height="52" style="object-fit:cover;border-radius:50%;" onerror="this.style.display='none'" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <img src='<%# PersonImgSrc(Eval("Id")) %>' width="40" height="40" style="object-fit:cover;border-radius:50%;display:block;margin-bottom:4px;" onerror="this.style.display='none'" />
                        <asp:FileUpload ID="imgUpload" runat="server" accept="image/*" />
                        <asp:CheckBox ID="removeImage" runat="server" Text="Remove current image" />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ClubDesignation" HeaderText="Club Designation" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Info" HeaderText="Info" />
                <asp:BoundField DataField="DisplayOrder" HeaderText="Order" />
                <asp:CheckBoxField DataField="IsActive" HeaderText="Active" />
                <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
            </Columns>
        </asp:GridView>
    </section>
</asp:Content>
