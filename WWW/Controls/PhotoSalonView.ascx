<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PhotoSalonView.ascx.cs" Inherits="PhotoSalonView" %>
<%@ Register TagPrefix="uc1" TagName="EditorHTML" Src="ValueControls/EditorHTML.ascx" %>
<div class="dottedtop" style="margin-top: 10px; overflow: hidden; min-height:400px;">

<table cellpadding="10" cellspacing="10" border="0">
<tr>
    <td align="left">
    <div align="right" style="width: 220px; text-align: right;">
        <asp:Label ID="lblPhones" runat="server" Text="" Class="pageName" Font-Size="12pt"></asp:Label>
    </div>
    </td>
</tr>
<tr>
<td align="left">
<uc1:EditorHTML id="editor_Description" runat="server" Editable="false" HasPermission="false"></uc1:EditorHTML>
</td>
</tr>
</table>

</div> <div class="bottomdottedtop" style="margin-top: 60px"></div>