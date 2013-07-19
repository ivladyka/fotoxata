<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdviceView.ascx.cs" Inherits="AdviceView" %>
<%@ Register TagPrefix="uc1" TagName="EditorHTML" Src="ValueControls/EditorHTML.ascx" %>
<div class="dottedtop" style="margin-top: 10px; overflow: hidden; min-height:400px;">
<table cellpadding="0" cellspacing="0" border="0" style="padding-top: 20px" > 
<tr>
<td align="left">
<uc1:EditorHTML id="editor_Answer" runat="server" Editable="false" HasPermission="false"></uc1:EditorHTML>
<asp:HyperLink ID="hlBAckAdviceList" runat="server" NavigateUrl="~/Default.aspx?content=AdviceTableList"  Text="<%$Resources:Fotoxata, BackAdviceList %>" CssClass="Adviceslink"></asp:HyperLink>
</td>
</tr>
</table>

</div><div class="bottomdottedtop" style="margin-top: 60px"></div>
        