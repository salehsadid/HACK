<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="Home.aspx.cs" Inherits="Home" Title="HACK KUET | Hardware Acceleration Club" %>
<asp:Content ID="HomeContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <section class="hero">
            <div class="hero-media">
                <asp:Image ID="heroImage" runat="server" AlternateText="Hardware lab bench with electronics components" />
            </div>
            <div class="hero-inner">
                <p class="eyebrow"><asp:Literal ID="heroEyebrow" runat="server" /></p>
                <h1><asp:Literal ID="heroTitle" runat="server" /></h1>
                <p class="hero-copy"><asp:Literal ID="heroCopy" runat="server" /></p>
                <div class="hero-actions">
                    <a id="heroPrimaryLink" runat="server" class="btn btn-primary" href="Register.aspx">Apply for Membership</a>
                    <a id="heroSecondaryLink" runat="server" class="btn btn-ghost" href="#projects">View Projects</a>
                </div>
                <div class="metric-row" aria-label="Club statistics">
                    <asp:Repeater ID="metricsRepeater" runat="server">
                        <ItemTemplate>
                            <div>
                                <strong><%# EncodeText(Eval("Value")) %></strong>
                                <span><%# EncodeText(Eval("Label")) %></span>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </section>

        <section id="about" class="section two-column">
            <div>
                <p class="eyebrow"><asp:Literal ID="whatEyebrow" runat="server" /></p>
                <h2><asp:Literal ID="whatTitle" runat="server" /></h2>
            </div>
            <div class="feature-grid">
                <asp:Repeater ID="featuresRepeater" runat="server">
                    <ItemTemplate>
                        <article>
                            <span><%# EncodeText(Eval("Number")) %></span>
                            <h3><%# EncodeText(Eval("Title")) %></h3>
                            <p><%# EncodeText(Eval("Description")) %></p>
                        </article>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </section>

        <section id="notices" class="section">
            <div class="section-head">
                <p class="eyebrow">Notices</p>
                <h2>Club Updates</h2>
            </div>
            <div class="notice-list">
                <asp:Repeater ID="noticesRepeater" runat="server">
                    <ItemTemplate>
                        <article class="notice-item">
                            <span><%# Eval("Meta") %></span>
                            <div>
                                <h3><%# Eval("Title") %></h3>
                                <p><%# Eval("Body") %></p>
                                <asp:Image ID="noticeImg" runat="server"
                                    ImageUrl='<%# ContentImgSrc(Eval("Id")) %>'
                                    Visible='<%# NoticeHasImage(Eval("HasImage")) %>'
                                    CssClass="notice-img" AlternateText='<%# Eval("Title") %>' />
                            </div>
                        </article>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </section>

        <section id="achievements" class="section">
            <div class="section-head">
                <p class="eyebrow">Achievements</p>
                <h2>Proof From The Workbench</h2>
            </div>  
            <div class="card-grid">
                <asp:Repeater ID="achievementsRepeater" runat="server">
                    <ItemTemplate>
                        <article class="content-card">
                            <img src='<%# ContentImgSrc(Eval("Id")) %>' alt='<%# Eval("Title") %>' onerror="this.style.display='none'" />
                            <div>
                                <span class="pill"><%# Eval("Meta") %></span>
                                <h3><%# Eval("Title") %></h3>
                                <p><%# Eval("Subtitle") %></p>
                            </div>
                        </article>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </section>

        <section id="projects" class="section dark-band">
            <div class="section-head">
                <p class="eyebrow">Projects</p>     
                <h2>Current Build Tracks</h2>
            </div>
            <div class="card-grid">
                <asp:Repeater ID="projectsRepeater" runat="server">
                    <ItemTemplate>
                        <article class="content-card">
                            <img src='<%# ContentImgSrc(Eval("Id")) %>' alt='<%# Eval("Title") %>' onerror="this.style.display='none'" />
                            <div>
                                <span class="pill"><%# Eval("Meta") %></span>
                                <h3><%# Eval("Title") %></h3>
                                <p><%# Eval("Subtitle") %></p>
                            </div>
                        </article>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </section>

        <section id="gallery" class="section">
            <div class="section-head">
                <p class="eyebrow">Gallery</p>
                <h2>Inside The Lab</h2>
            </div>
            <div class="gallery-grid">
                <asp:Repeater ID="galleryRepeater" runat="server">
                    <ItemTemplate>
                        <figure>
                            <img src='<%# ContentImgSrc(Eval("Id")) %>' alt='<%# Eval("Title") %>' onerror="this.style.display='none'" />
                            <figcaption>
                                <span class="pill"><%# Eval("Meta") %></span>
                                <strong><%# Eval("Title") %></strong>
                                <span><%# Eval("Subtitle") %></span>
                            </figcaption>
                        </figure>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </section>

        <section id="contact" class="section contact-band">
            <div>
                <p class="eyebrow">Join The Floor</p>
                <h2>Ready to work on hardware that has to survive real testing?</h2>
            </div>
            <div class="contact-actions">
                <a class="btn btn-primary" href="Register.aspx">Open Registration</a>
                <p><strong>Location:</strong> KUET Campus, Khulna<br /><strong>Email:</strong> hack@kuet.ac.bd</p>
            </div>
        </section>
    </main>
</asp:Content>
