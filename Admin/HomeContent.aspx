<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Admin.master" CodeFile="HomeContent.aspx.cs" Inherits="AdminHomeContent" Title="Home Page — HACK Admin" %>

<asp:Content ID="C1" ContentPlaceHolderID="AdminContent" runat="server">
    <div class="admin-section-head">
        <div>
            <p class="eyebrow">Home Page</p>
            <h1>Hero & What We Do</h1>
        </div>
        <a href="<%: ResolveUrl("~/Home.aspx") %>" class="btn btn-ghost btn-sm">View Home Page</a>
    </div>

    <asp:Label ID="pageStatus" runat="server" CssClass="form-status" EnableViewState="false" />

    <section class="admin-card">
        <header class="admin-section-head">
            <div><h2>Hero Section</h2></div>
        </header>
        <div class="form-grid admin-form">
            <div class="form-field">
                <label for="heroEyebrowInput">Eyebrow</label>
                <asp:TextBox ID="heroEyebrowInput" runat="server" ClientIDMode="Static" MaxLength="120" />
            </div>
            <div class="form-field">
                <label for="heroImageUrlInput">Background Image URL</label>
                <asp:TextBox ID="heroImageUrlInput" runat="server" ClientIDMode="Static" MaxLength="600" />
            </div>
            <div class="form-field full">
                <label for="heroTitleInput">Heading</label>
                <asp:TextBox ID="heroTitleInput" runat="server" ClientIDMode="Static" MaxLength="180" />
            </div>
            <div class="form-field full">
                <label for="heroCopyInput">Short Copy</label>
                <asp:TextBox ID="heroCopyInput" runat="server" ClientIDMode="Static" TextMode="MultiLine" MaxLength="500" Rows="4" />
            </div>
            <div class="form-field">
                <label for="heroPrimaryTextInput">Primary Button Text</label>
                <asp:TextBox ID="heroPrimaryTextInput" runat="server" ClientIDMode="Static" MaxLength="80" />
            </div>
            <div class="form-field">
                <label for="heroPrimaryUrlInput">Primary Button URL</label>
                <asp:TextBox ID="heroPrimaryUrlInput" runat="server" ClientIDMode="Static" MaxLength="260" />
            </div>
            <div class="form-field">
                <label for="heroSecondaryTextInput">Secondary Button Text</label>
                <asp:TextBox ID="heroSecondaryTextInput" runat="server" ClientIDMode="Static" MaxLength="80" />
            </div>
            <div class="form-field">
                <label for="heroSecondaryUrlInput">Secondary Button URL</label>
                <asp:TextBox ID="heroSecondaryUrlInput" runat="server" ClientIDMode="Static" MaxLength="260" />
            </div>

            <div class="form-field"><label for="metric1Value">Metric 1 Value</label><asp:TextBox ID="metric1Value" runat="server" ClientIDMode="Static" MaxLength="20" /></div>
            <div class="form-field"><label for="metric1Label">Metric 1 Label</label><asp:TextBox ID="metric1Label" runat="server" ClientIDMode="Static" MaxLength="80" /></div>
            <div class="form-field"><label for="metric2Value">Metric 2 Value</label><asp:TextBox ID="metric2Value" runat="server" ClientIDMode="Static" MaxLength="20" /></div>
            <div class="form-field"><label for="metric2Label">Metric 2 Label</label><asp:TextBox ID="metric2Label" runat="server" ClientIDMode="Static" MaxLength="80" /></div>
            <div class="form-field"><label for="metric3Value">Metric 3 Value</label><asp:TextBox ID="metric3Value" runat="server" ClientIDMode="Static" MaxLength="20" /></div>
            <div class="form-field"><label for="metric3Label">Metric 3 Label</label><asp:TextBox ID="metric3Label" runat="server" ClientIDMode="Static" MaxLength="80" /></div>
            <div class="form-field"><label for="metric4Value">Metric 4 Value</label><asp:TextBox ID="metric4Value" runat="server" ClientIDMode="Static" MaxLength="20" /></div>
            <div class="form-field"><label for="metric4Label">Metric 4 Label</label><asp:TextBox ID="metric4Label" runat="server" ClientIDMode="Static" MaxLength="80" /></div>
        </div>
    </section>

    <section class="admin-card">
        <header class="admin-section-head">
            <div><h2>What We Do Section</h2></div>
        </header>
        <div class="form-grid admin-form">
            <div class="form-field">
                <label for="whatEyebrowInput">Eyebrow</label>
                <asp:TextBox ID="whatEyebrowInput" runat="server" ClientIDMode="Static" MaxLength="120" />
            </div>
            <div class="form-field full">
                <label for="whatTitleInput">Heading</label>
                <asp:TextBox ID="whatTitleInput" runat="server" ClientIDMode="Static" MaxLength="180" />
            </div>
        </div>

        <div class="form-grid admin-form">
            <div class="form-field"><label for="feature1Number">Card 1 Number</label><asp:TextBox ID="feature1Number" runat="server" ClientIDMode="Static" MaxLength="10" /></div>
            <div class="form-field"><label for="feature1Title">Card 1 Title</label><asp:TextBox ID="feature1Title" runat="server" ClientIDMode="Static" MaxLength="100" /></div>
            <div class="form-field full"><label for="feature1Description">Card 1 Description</label><asp:TextBox ID="feature1Description" runat="server" ClientIDMode="Static" TextMode="MultiLine" MaxLength="300" Rows="3" /></div>

            <div class="form-field"><label for="feature2Number">Card 2 Number</label><asp:TextBox ID="feature2Number" runat="server" ClientIDMode="Static" MaxLength="10" /></div>
            <div class="form-field"><label for="feature2Title">Card 2 Title</label><asp:TextBox ID="feature2Title" runat="server" ClientIDMode="Static" MaxLength="100" /></div>
            <div class="form-field full"><label for="feature2Description">Card 2 Description</label><asp:TextBox ID="feature2Description" runat="server" ClientIDMode="Static" TextMode="MultiLine" MaxLength="300" Rows="3" /></div>

            <div class="form-field"><label for="feature3Number">Card 3 Number</label><asp:TextBox ID="feature3Number" runat="server" ClientIDMode="Static" MaxLength="10" /></div>
            <div class="form-field"><label for="feature3Title">Card 3 Title</label><asp:TextBox ID="feature3Title" runat="server" ClientIDMode="Static" MaxLength="100" /></div>
            <div class="form-field full"><label for="feature3Description">Card 3 Description</label><asp:TextBox ID="feature3Description" runat="server" ClientIDMode="Static" TextMode="MultiLine" MaxLength="300" Rows="3" /></div>

            <div class="form-field"><label for="feature4Number">Card 4 Number</label><asp:TextBox ID="feature4Number" runat="server" ClientIDMode="Static" MaxLength="10" /></div>
            <div class="form-field"><label for="feature4Title">Card 4 Title</label><asp:TextBox ID="feature4Title" runat="server" ClientIDMode="Static" MaxLength="100" /></div>
            <div class="form-field full"><label for="feature4Description">Card 4 Description</label><asp:TextBox ID="feature4Description" runat="server" ClientIDMode="Static" TextMode="MultiLine" MaxLength="300" Rows="3" /></div>
        </div>

        <div class="admin-actions">
            <asp:Button ID="saveHomeContentBtn" runat="server" CssClass="btn btn-primary" Text="Save Home Page" CausesValidation="false" OnClick="SaveHomeContent_Click" />
        </div>
    </section>
</asp:Content>
