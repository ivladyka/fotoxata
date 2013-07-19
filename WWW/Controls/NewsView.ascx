<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsView.ascx.cs" Inherits="NewsView" %>
<%@ Register TagPrefix="uc1" TagName="EditorHTML" Src="ValueControls/EditorHTML.ascx" %>
<div>   <div class="PageNameStyle"> <asp:Label id="lbTitle" runat="server"></asp:Label></div>
<div class="dottedtop" style="margin-top: 10px; overflow: hidden; min-height:400px;">
<table cellpadding="0" cellspacing="0" border="0" width="100%">
<tr>
    <td style="padding-right: 20px; padding-bottom: 0px; padding-left: 20px; float: right;">
         <div class="PageNameStyle"><asp:Label id="lblDate" runat="server"></asp:Label></div>
    </td>
</tr>
<tr>
<td align="left" style="padding-right: 20px; padding-bottom: 0px; padding-left: 20px;">
<uc1:EditorHTML id="editor_NewsContent" runat="server" Editable="false" HasPermission="false"></uc1:EditorHTML>
<asp:HyperLink ID="hlBackNewsList" runat="server" NavigateUrl="~/Default.aspx?content=NewsLinkList"  Text="<%$Resources:Fotoxata, BackNewsList %>" CssClass="Adviceslink"></asp:HyperLink>
</td>
</tr>
</table>

</div><div class="bottomdottedtop" style="margin-top: 60px"></div>
</div>