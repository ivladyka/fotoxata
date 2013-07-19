<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OrderUserView.ascx.cs" Inherits="OrderUserView" %>
<%@ Register TagPrefix="uc1" TagName="OrderPhotoList" Src="OrderPhotoList.ascx" %>
<%@ Register TagPrefix="uc1" TagName="OrderStatusChoice" Src="ChoiceControls/OrderStatusChoice.ascx" %>
<%@ Register TagPrefix="uc1" TagName="EditableGrid" Src="EditableGrid.ascx" %>
<TABLE id="Table3" class="EditControl3" cellSpacing="2" cellPadding="2"  align="center" border="0" width="100%">	
	<tr>
	<td>
	<table cellPadding="2"  cellSpacing="2" align="left" border="0">
	<tr>
		<td align="right"><%=Phone%>:
		</td>
		<td >
	      <asp:Label ID="lblCellPhone" runat="server" Text="" Font-Size="12pt"></asp:Label>
     </td>
          </tr>
    <tr>
		<td align="right"><%=Surname%>:
		</td>
		<td>
		<asp:Label ID="lblUserName" runat="server" Text="" Font-Size="12pt"></asp:Label>
			</td>
		</tr>
	<tr>
		<td align="right"><%=ClientNote%>:
		</td>
		<td>
			<asp:Label ID="lblClientNote" runat="server" Text="" Font-Size="12pt"></asp:Label>	</td>
		</tr>	
	<tr>
		<td align="right"><%=OrderDate%>:
		</td>
		<td>
			<asp:Label ID="lblDateCreated" runat="server" Text="" Font-Size="12pt"></asp:Label>	</td>
		</tr>	 
	<tr>
		<td align="right"><%=PhotoCount%>:
		</td>
		<td>
			<asp:Label ID="lblPhotoCount" runat="server" Text="" Font-Size="12pt"></asp:Label>	</td>
		</tr>	
	<tr>
		<td align="right"><%=Cost%>:
		</td>
		<td>
			<asp:Label ID="lblAmount" runat="server" Text="" Font-Size="12pt"></asp:Label>	<%=Grn%></td>
		</tr>   
		<tr>
		<td align="right"><%=OrderStatus%>:
		</td>
		<td>
		<asp:Label ID="lblOrderStatus" runat="server" Text="" Font-Size="12pt"></asp:Label>
		</td>
		</tr>   
	<tr>		
		<td align="right" valign="top"><%=PhotoNotice%>:
		</td>
		<td>
		<asp:Label ID="lblOfficeNote" runat="server" Text="" Font-Size="12pt"></asp:Label>
			</td>
		</tr> 
	</table>
	</td>
	</tr>	
	<tr>
	    <td>
	        <uc1:OrderPhotoList id="orderPhotoList" runat="server"></uc1:OrderPhotoList>
		</td>
	</tr>
  	<tr>
	    <td align="right">
	   	<asp:imagebutton id="btnCancel" runat="server" commandname="Cancel"  CssClass="b_style" causesvalidation="False" ImageUrl="../Cancel.gif"></asp:imagebutton>
		 </td>
	</tr>
</TABLE>