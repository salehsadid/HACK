<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="Blog.aspx.cs" Inherits="HACK.WebForms.Blog" Title="HACK KUET Blog" %>
<asp:Content ID="BlogContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="hero-banner" style="--hero-image: url('resource/blog-illustration.svg');">
        <div class="hero-content">
            <p class="hero-script">Our Stories</p>
            <h2 class="hero-title">HACK BLOG AND MEMBER INSIGHTS</h2>
            <p class="hero-desc">
                Follow project retrospectives, workshop recaps, and engineering reflections from the students building
                the next generation of hardware systems.
            </p>
            <div class="hero-actions">
                <a href="#latest" class="btn btn-primary">Read Latest</a>
                <a href="Register.aspx" class="btn btn-light">Join Form</a>
            </div>
        </div>
    </section>

    <main class="page-wrap">
        <section class="panel">
            <header class="panel-header">
                <p class="eyebrow">Featured</p>
                <h2 class="panel-title">Spotlight Story</h2>
            </header>
            <div class="grid-2">
                <article class="card">
                    <span class="tag">Build Story</span>
                    <h3><asp:Literal ID="featuredTitle" runat="server" /></h3>
                    <p><asp:Literal ID="featuredSummary" runat="server" /></p>
                    <a href="#latest" class="btn btn-outline">Read Full Story</a>
                </article>
                <article class="card">
                    <h3>Top Topics This Month</h3>
                    <ul>
                        <li>Embedded setup checklist for beginners</li>
                        <li>Hardware debug flow before competitions</li>
                        <li>Sensor calibration and test logging</li>
                        <li>Team sprint planning for project delivery</li>
                    </ul>
                </article>
            </div>
        </section>

        <section id="latest" class="panel">
            <header class="panel-header">
                <p class="eyebrow">Latest Posts</p>
                <h2 class="panel-title">Fresh From The Lab</h2>
            </header>
            <div class="grid-3">
                <asp:Repeater ID="postsRepeater" runat="server">
                    <ItemTemplate>
                        <article class="card">
                            <span class="tag"><%# Eval("Category") %></span>
                            <h3><%# Eval("Title") %></h3>
                            <p><%# Eval("Summary") %></p>
                            <a href="#" class="btn btn-outline">Read Post</a>
                        </article>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </section>

        <section class="panel cta-panel">
            <div>
                <p class="eyebrow">Contribute</p>
                <h2 class="panel-title">Have A Build Story To Share?</h2>
                <p>Members can submit technical articles, design logs, and competition journals.</p>
            </div>
            <a href="Register.aspx" class="btn btn-outline">Join The Club</a>
        </section>
    </main>
</asp:Content>