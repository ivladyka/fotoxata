<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HomeSection.ascx.cs" Inherits="Controls_HomeSection" %>
<div class="homepagetabl">  
<asp:HyperLink ID="hlTitle" runat="server" CssClass="homepagetablheader"></asp:HyperLink>
<br />
<asp:Label ID="lblContent" runat="server" Font-Size="11pt"></asp:Label>
<br />
<asp:HyperLink ID="hlDetail" runat="server" Text="Детальніше >>" Font-Size="10pt" CssClass="Adviceslink"></asp:HyperLink>
</div>