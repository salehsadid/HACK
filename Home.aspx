<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="Home.aspx.cs" Inherits="Home" Title="HACK KUET | Hardware Acceleration Club" %>
<asp:Content ID="HomeContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <section class="hero">
            <div class="hero-media">
                <img src="https://images.unsplash.com/photo-1518770660439-4636190af475?auto=format&amp;fit=crop&amp;w=1800&amp;q=85" alt="Hardware lab bench with electronics components" />
            </div>
            <div class="hero-inner">
                <p class="eyebrow">KUET Hardware Community</p>
                <h1>Build real hardware, from bare board to working system.</h1>
                <p class="hero-copy">HACK is a student engineering club for embedded systems, robotics, FPGA, IoT, automation, PCB assembly, and competition-ready prototyping.</p>
                <div class="hero-actions">
                    <a class="btn btn-primary" href="Register.aspx">Apply for Membership</a>
                    <a class="btn btn-ghost" href="#projects">View Projects</a>
                </div>
                <div class="metric-row" aria-label="Club statistics">
                    <div><strong>120+</strong><span>builders</span></div>
                    <div><strong>35+</strong><span>labs yearly</span></div>
                    <div><strong>18</strong><span>awards</span></div>
                    <div><strong>9</strong><span>active teams</span></div>
                </div>
            </div>
        </section>

        <section id="about" class="section two-column">
            <div>
                <p class="eyebrow">What We Do</p>
                <h2>Hardware engineering with a product mindset.</h2>
            </div>
            <div class="feature-grid">
                <article>
                    <span>01</span>
                    <h3>Embedded Systems</h3>
                    <p>Firmware, board bring-up, sensors, communication protocols, telemetry, and debugging discipline.</p>
                </article>
                <article>
                    <span>02</span>
                    <h3>Robotics</h3>
                    <p>Motor control, chassis design, perception, autonomous navigation, and competition practice.</p>
                </article>
                <article>
                    <span>03</span>
                    <h3>Digital Design</h3>
                    <p>FPGA workflows, HDL, timing, signal processing, and hardware acceleration experiments.</p>
                </article>
                <article>
                    <span>04</span>
                    <h3>Fabrication</h3>
                    <p>PCB layout, soldering, mechanical prototyping, enclosure review, and reliable assembly habits.</p>
                </article>
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
                            <img src="<%# Eval("ImageUrl") %>" alt="<%# Eval("Title") %>" />
                            <div>
                                <span class="pill"><%# Eval("Meta") %></span>
                                <h3><%# Eval("Title") %></h3>
                                <p><%# Eval("Body") %></p>
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
                            <img src="<%# Eval("ImageUrl") %>" alt="<%# Eval("Title") %>" />
                            <div>
                                <span class="pill"><%# Eval("Meta") %></span>
                                <h3><%# Eval("Title") %></h3>
                                <p><%# Eval("Body") %></p>
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
                            <img src="<%# Eval("ImageUrl") %>" alt="<%# Eval("Title") %>" />
                            <figcaption>
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
