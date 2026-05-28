<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="Register.aspx.cs" Inherits="HACK.WebForms.Register" Title="HACK KUET Registration" %>
<asp:Content ID="RegisterContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="subpage">
        <section class="registration-shell">
            <div class="registration-intro">
                <p class="eyebrow">Membership Application</p>
                <h1>Apply to HACK KUET</h1>
                <p>Your application goes to the admin dashboard first. Approved applicants become registered club members.</p>
                <div class="apply-steps">
                    <span>Submit profile</span>
                    <span>Admin review</span>
                    <span>Member onboarding</span>
                </div>
            </div>

            <section id="registration-form" class="form-panel">
                <div class="form-grid">
                    <div class="form-field">
                        <label for="fullName">Full Name</label>
                        <asp:TextBox ID="fullName" runat="server" ClientIDMode="Static" placeholder="Your full name" />
                        <asp:RequiredFieldValidator ID="rfvFullName" runat="server" ControlToValidate="fullName" ValidationGroup="Register" ErrorMessage="Full name is required." CssClass="field-error" Display="Dynamic" />
                    </div>
                    <div class="form-field">
                        <label for="email">Email</label>
                        <asp:TextBox ID="email" runat="server" ClientIDMode="Static" TextMode="Email" placeholder="you@example.com" />
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="email" ValidationGroup="Register" ErrorMessage="Email is required." CssClass="field-error" Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="email" ValidationGroup="Register" ErrorMessage="Enter a valid email address." ValidationExpression="^[^\s@]+@[^\s@]+\.[^\s@]+$" CssClass="field-error" Display="Dynamic" />
                    </div>
                    <div class="form-field">
                        <label for="phone">Phone</label>
                        <asp:TextBox ID="phone" runat="server" ClientIDMode="Static" placeholder="+8801XXXXXXXXX" />
                        <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="phone" ValidationGroup="Register" ErrorMessage="Phone number is required." CssClass="field-error" Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="revPhone" runat="server" ControlToValidate="phone" ValidationGroup="Register" ErrorMessage="Use a valid phone number." ValidationExpression="^[0-9+\-\s]{7,20}$" CssClass="field-error" Display="Dynamic" />
                    </div>
                    <div class="form-field">
                        <label for="department">Department</label>
                        <asp:TextBox ID="department" runat="server" ClientIDMode="Static" placeholder="EEE / CSE / ME / Others" />
                        <asp:RequiredFieldValidator ID="rfvDepartment" runat="server" ControlToValidate="department" ValidationGroup="Register" ErrorMessage="Department is required." CssClass="field-error" Display="Dynamic" />
                    </div>
                    <div class="form-field">
                        <label for="batch">Batch / Session</label>
                        <asp:TextBox ID="batch" runat="server" ClientIDMode="Static" placeholder="2023-24" />
                        <asp:RequiredFieldValidator ID="rfvBatch" runat="server" ControlToValidate="batch" ValidationGroup="Register" ErrorMessage="Batch/session is required." CssClass="field-error" Display="Dynamic" />
                    </div>
                    <div class="form-field">
                        <label for="interest">Interest Area</label>
                        <asp:DropDownList ID="interest" runat="server" ClientIDMode="Static">
                            <asp:ListItem Text="Select area" Value="" />
                            <asp:ListItem Text="Embedded Systems" Value="Embedded Systems" />
                            <asp:ListItem Text="Robotics and Control" Value="Robotics and Control" />
                            <asp:ListItem Text="IoT and Automation" Value="IoT and Automation" />
                            <asp:ListItem Text="FPGA and HDL" Value="FPGA and HDL" />
                            <asp:ListItem Text="PCB and Fabrication" Value="PCB and Fabrication" />
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvInterest" runat="server" ControlToValidate="interest" InitialValue="" ValidationGroup="Register" ErrorMessage="Select an interest area." CssClass="field-error" Display="Dynamic" />
                    </div>
                    <div class="form-field full">
                        <label for="message">Why do you want to join?</label>
                        <asp:TextBox ID="message" runat="server" ClientIDMode="Static" TextMode="MultiLine" MaxLength="600" placeholder="Write a short motivation" />
                        <asp:RequiredFieldValidator ID="rfvMessage" runat="server" ControlToValidate="message" ValidationGroup="Register" ErrorMessage="Please write a short motivation." CssClass="field-error" Display="Dynamic" />
                        <p class="char-counter" data-char-counter>0 / 600</p>
                    </div>
                </div>
                <div class="form-actions">
                    <asp:Button ID="submitApplication" runat="server" CssClass="btn btn-primary" Text="Submit Application" ValidationGroup="Register" OnClick="SubmitApplication_Click" />
                </div>
                <asp:Label ID="formStatus" runat="server" CssClass="form-status" EnableViewState="false" />
            </section>
        </section>
    </main>
</asp:Content>
