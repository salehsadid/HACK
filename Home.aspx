<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="Home.aspx.cs" Inherits="HACK.WebForms.Home" Title="HACK KUET | Hardware Acceleration Club" %>
<asp:Content ID="HomeContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="hero-banner" style="--hero-image: url('resource/Hardware.webp');">
        <div class="hero-content">
            <p class="hero-script">The Heart</p>
            <h2 class="hero-title">OF KUET HARDWARE COMMUNITY</h2>
            <p class="hero-desc">
                HACK is where ambitious students design electronics, build robots, and launch real-world embedded
                systems with mentorship, technical standards, and competition-level discipline.
            </p>
            <div class="hero-actions">
                <a href="#join" class="btn btn-primary">Join The Club</a>
                <a href="projects-workshops.html" class="btn btn-light">Explore Projects</a>
            </div>
        </div>
    </section>

    <main class="page-wrap">
        <section class="panel">
            <header class="panel-header">
                <p class="eyebrow">Club Snapshot</p>
                <h2 class="panel-title">Premium Experience For Hardware Builders</h2>
            </header>
            <div class="info-strip">
                <article class="card">
                    <p class="value">120+</p>
                    <p class="label">Active members</p>
                </article>
                <article class="card">
                    <p class="value">35+</p>
                    <p class="label">Workshops each year</p>
                </article>
                <article class="card">
                    <p class="value">18</p>
                    <p class="label">Competition awards</p>
                </article>
                <article class="card">
                    <p class="value">9</p>
                    <p class="label">Running project teams</p>
                </article>
            </div>
        </section>

        <section id="about" class="panel">
            <header class="panel-header">
                <p class="eyebrow">About HACK</p>
                <h2 class="panel-title">Build Skills, Build Teams, Build Impact</h2>
            </header>
            <div class="grid-3">
                <article class="card">
                    <h3>Mission</h3>
                    <p>Enable KUET students to master practical embedded engineering through guided project execution.</p>
                </article>
                <article class="card">
                    <h3>Vision</h3>
                    <p>Create Bangladesh's most inspiring student ecosystem for robotics, acceleration, and IoT.</p>
                </article>
                <article class="card">
                    <h3>Core Domains</h3>
                    <ul>
                        <li>Embedded Systems</li>
                        <li>Robotics and Control</li>
                        <li>FPGA and HDL</li>
                        <li>Automation and IoT</li>
                    </ul>
                </article>
            </div>
        </section>

        <section id="events" class="panel">
            <header class="panel-header">
                <p class="eyebrow">Events</p>
                <h2 class="panel-title">Upcoming Learning Flow</h2>
            </header>
            <div class="grid-3">
                <article class="card">
                    <span class="tag">May 2026</span>
                    <h3>ESP32 Sprint Camp</h3>
                    <p>Hands-on firmware and cloud integration sessions for smart sensor networks.</p>
                </article>
                <article class="card">
                    <span class="tag">June 2026</span>
                    <h3>Autonomous Robot Lab</h3>
                    <p>Performance trials on obstacle response, lane logic, and tuning strategy.</p>
                </article>
                <article class="card">
                    <span class="tag">July 2026</span>
                    <h3>Demo &amp; Showcase Night</h3>
                    <p>Teams pitch prototypes to mentors, alumni, and potential collaborators.</p>
                </article>
            </div>
        </section>

        <section id="join" class="panel form-panel join-panel">
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

        <section id="contact" class="panel">
            <header class="panel-header">
                <p class="eyebrow">Contact</p>
                <h2 class="panel-title">Connect With HACK KUET</h2>
            </header>
            <div class="contact-grid">
                <p><strong>Location:</strong> KUET Campus, Khulna</p>
                <p><strong>Email:</strong> hack@kuet.ac.bd</p>
                <p><strong>Phone:</strong> +880-1XXX-XXXXXX</p>
                <p><strong>Office Hours:</strong> Sunday-Thursday, 3:00 PM to 8:00 PM</p>
            </div>
        </section>
    </main>
</asp:Content>