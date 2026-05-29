<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="About.aspx.cs" Inherits="About" Title="About — HACK KUET" %>

<asp:Content ID="C1" ContentPlaceHolderID="MainContent" runat="server">
    <main>

        <section class="subpage section">
            <p class="eyebrow">About HACK</p>
            <h1>Hardware Acceleration Club of KUET</h1>
            <asp:Label ID="lblAbout" runat="server" CssClass="about-body" />
        </section>

        <section class="section">
            <div class="section-head">
                <p class="eyebrow">Faculty</p>
                <h2>Our Moderators</h2>
            </div>
            <div class="person-grid">
                <asp:Repeater ID="moderatorsRepeater" runat="server">
                    <ItemTemplate>
                        <article class="person-card">
                            <div class="person-photo-wrap">
                                <img class="person-photo" src='<%# PersonImgSrc(Eval("Id")) %>' alt='<%# Eval("Name") %>' />
                            </div>
                            <span class="pill"><%# Eval("ClubDesignation") %></span>
                            <h3><%# Eval("Name") %></h3>
                            <p><%# Eval("Info") %></p>
                        </article>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </section>

        <section class="section dark-band">
            <div class="section-head">
                <p class="eyebrow">Leadership</p>
                <h2>Executive Committee</h2>
            </div>
            <div class="person-grid">
                <asp:Repeater ID="executivesRepeater" runat="server">
                    <ItemTemplate>
                        <article class="person-card">
                            <div class="person-photo-wrap">
                                <img class="person-photo" src='<%# PersonImgSrc(Eval("Id")) %>' alt='<%# Eval("Name") %>' />
                            </div>
                            <span class="pill"><%# Eval("ClubDesignation") %></span>
                            <h3><%# Eval("Name") %></h3>
                            <p><%# Eval("Info") %></p>
                        </article>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </section>

    </main>
</asp:Content>
