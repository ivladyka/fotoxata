<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PriceList.ascx.cs" Inherits="PriceList" %>
<%@ Register TagPrefix="uc1" TagName="EditableGrid" Src="EditableGrid.ascx" %>
<table width="100%" border="0" cellpadding="0" cellspacing="10">
	<tr valign="top" align="center">
		<td>
			<uc1:EditableGrid id="editableGrid" runat="server" HideCommandPanel="True" AllowRowResize="false" AllowColumnResize="false"></uc1:EditableGrid>
		</td>
	</tr>
</table>