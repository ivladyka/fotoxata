<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsList.ascx.cs" Inherits="NewsList" %>
<%@ Register TagPrefix="uc1" TagName="EditableGrid" Src="EditableGrid.ascx" %>
<table width="100%" border="0" cellpadding="0" cellspacing="10">
	<tr valign="top" align="left">
		<td>
			<uc1:EditableGrid id="editableGrid" runat="server"></uc1:EditableGrid>
		</td>
	</tr>
</table>