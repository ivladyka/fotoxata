<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OrderPhotoList.ascx.cs" Inherits="OrderPhotoList" %>
<%@ Register TagPrefix="uc1" TagName="EditableGrid" Src="EditableGrid.ascx" %>
<%@ Register TagPrefix="uc1" TagName="GaleryWindowControl" Src="GaleryWindowControl.ascx" %>
<table width="100%" border="0" cellpadding="0" cellspacing="2">
	<tr valign="top">
		<td>
			<uc1:EditableGrid id="editableGrid" runat="server"></uc1:EditableGrid>
		</td>
	</tr>
</table>
<uc1:GaleryWindowControl id="galeryWindowControl" runat="server"></uc1:GaleryWindowControl>