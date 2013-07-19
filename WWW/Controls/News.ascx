<%@ Control Language="C#" AutoEventWireup="true" CodeFile="News.ascx.cs" Inherits="News" %>
<div>
<table id="tblNews" runat="server" style="width:210px" cellpadding="0" cellspacing="0" border="0" class="news">
<tr>
<td class="news1" valign="top" align="left">
<asp:HyperLink ID="HyperLink1" class="redlink" runat="server" NavigateUrl="~/Default.aspx?content=NewsLinkList">Новини</asp:HyperLink>
<hr Style="color:#da4740; width:155px;"/>
</td>
</tr>
</table>
</div>