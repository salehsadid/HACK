<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="Register.aspx.cs" Inherits="HACK.WebForms.Register" Title="HACK KUET Registration" %>
<asp:Content ID="RegisterContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="hero-banner" style="--hero-image: url('resource/Hardware.webp');">
        <div class="hero-content">
            <p class="hero-script">Join HACK</p>
            <h2 class="hero-title">REGISTER FOR THE CLUB</h2>
            <p class="hero-desc">
                Fill in your details below to submit your application. The form uses ASP.NET server controls and
                validates input on the server before saving it in memory.
            </p>
            <div class="hero-actions">
                <a href="#registration-form" class="btn btn-primary">Start Registration</a>
                <a href="Blog.aspx" class="btn btn-light">Read Blog</a>
            </div>
        </div>
    </section>

    <main class="page-wrap">
        <section id="registration-form" class="panel form-panel join-panel">
            <header class="panel-header">
                <p class="eyebrow">Join Us</p>
                <h2 class="panel-title">Join HACK By Filling This Form</h2>
                <p>Registration includes orientation, track selection, project assignment, and mentor onboarding.</p>
            </header>
            <div class="form-grid">
                <div class="form-field">
                    <label for="fullName">Full Name</label>
                    <asp:TextBox ID="fullName" runat="server" ClientIDMode="Static" placeholder="Your full name" />
                    <asp:RequiredFieldValidator ID="rfvFullName" runat="server" ControlToValidate="fullName" ErrorMessage="Full name is required." CssClass="form-status error" Display="Dynamic" />
                </div>
                <div class="form-field">
                    <label for="email">Email</label>
                    <asp:TextBox ID="email" runat="server" ClientIDMode="Static" TextMode="Email" placeholder="you@example.com" />
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="email" ErrorMessage="Email is required." CssClass="form-status error" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="email" ErrorMessage="Enter a valid email address." ValidationExpression="^[^\s@]+@[^\s@]+\.[^\s@]+$" CssClass="form-status error" Display="Dynamic" />
                </div>
                <div class="form-field">
                    <label for="phone">Phone</label>
                    <asp:TextBox ID="phone" runat="server" ClientIDMode="Static" placeholder="+8801XXXXXXXXX" />
                    <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="phone" ErrorMessage="Phone number is required." CssClass="form-status error" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="revPhone" runat="server" ControlToValidate="phone" ErrorMessage="Use a valid phone number format." ValidationExpression="^[0-9+\-\s]{7,20}$" CssClass="form-status error" Display="Dynamic" />
                </div>
                <div class="form-field">
                    <label for="department">Department</label>
                    <asp:TextBox ID="department" runat="server" ClientIDMode="Static" placeholder="EEE / CSE / ME / Others" />
                    <asp:RequiredFieldValidator ID="rfvDepartment" runat="server" ControlToValidate="department" ErrorMessage="Department is required." CssClass="form-status error" Display="Dynamic" />
                </div>
                <div class="form-field">
                    <label for="batch">Batch / Session</label>
                    <asp:TextBox ID="batch" runat="server" ClientIDMode="Static" placeholder="2023-24" />
                    <asp:RequiredFieldValidator ID="rfvBatch" runat="server" ControlToValidate="batch" ErrorMessage="Batch/session is required." CssClass="form-status error" Display="Dynamic" />
                </div>
                <div class="form-field">
                    <label for="interest">Interest Area</label>
                    <asp:DropDownList ID="interest" runat="server" ClientIDMode="Static">
                        <asp:ListItem Text="Select area" Value="" />
                        <asp:ListItem Text="Embedded Systems" Value="embedded" />
                        <asp:ListItem Text="Robotics and Control" Value="robotics" />
                        <asp:ListItem Text="IoT and Automation" Value="iot" />
                        <asp:ListItem Text="FPGA and HDL" Value="fpga" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvInterest" runat="server" ControlToValidate="interest" InitialValue="" ErrorMessage="Select an interest area." CssClass="form-status error" Display="Dynamic" />
                </div>
                <div class="form-field full">
                    <label for="message">Why Do You Want To Join?</label>
                    <asp:TextBox ID="message" runat="server" ClientIDMode="Static" TextMode="MultiLine" MaxLength="300" placeholder="Write a short motivation" />
                    <asp:RequiredFieldValidator ID="rfvMessage" runat="server" ControlToValidate="message" ErrorMessage="Please write a short motivation." CssClass="form-status error" Display="Dynamic" />
                    <p class="char-counter" data-char-counter>0 / 300</p>
                </div>
            </div>
            <div class="form-actions">
                <asp:Button ID="submitApplication" runat="server" CssClass="btn btn-primary" Text="Submit Application" OnClick="SubmitApplication_Click" />
            </div>
            <asp:Label ID="formStatus" runat="server" CssClass="form-status" EnableViewState="false" />
        </section>
    </main>
</asp:Content>