<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OrderEdit.ascx.cs" Inherits="OrderEdit" %>
<%@ Register TagPrefix="uc1" TagName="OrderPhotoList" Src="OrderPhotoList.ascx" %>
<%@ Register TagPrefix="uc1" TagName="OrderStatusChoice" Src="ChoiceControls/OrderStatusChoice.ascx" %>
<%@ Register TagPrefix="uc1" TagName="EditableGrid" Src="EditableGrid.ascx" %>
<TABLE id="Table3" class="EditControl3" cellSpacing="2" cellPadding="2"  align="center" border="0" width="700px">	
	<tr>
	<td>
	<table cellPadding="2"  cellSpacing="2" align="left" border="0">
	<tr>
		<td align="right">Телефон:
		</td>
		<td >
	      <asp:Label ID="lblCellPhone" runat="server" Text="" Font-Size="12pt"></asp:Label>
     </td>
          </tr>
    <tr>
		<td align="right">Прізвище:
		</td>
		<td>
		<asp:Label ID="lblUserName" runat="server" Text="" Font-Size="12pt"></asp:Label>
			</td>
		</tr>
	<tr>
		<td align="right">Примітки клієнта:
		</td>
		<td>
			<asp:Label ID="lblClientNote" runat="server" Text="" Font-Size="12pt"></asp:Label>	</td>
		</tr>	
	<tr>
		<td align="right">Дата замовлення:
		</td>
		<td>
			<asp:Label ID="lblDateCreated" runat="server" Text="" Font-Size="12pt"></asp:Label>	</td>
		</tr>	 
	<tr>
		<td align="right">Кількість фото:
		</td>
		<td>
			<asp:Label ID="lblPhotoCount" runat="server" Text="" Font-Size="12pt"></asp:Label>	</td>
		</tr>	
	<tr>
		<td align="right">Ціна:
		</td>
		<td>
			<asp:Label ID="lblAmount" runat="server" Text="" Font-Size="12pt"></asp:Label>	грн</td>
		</tr>   
		<tr>
		<td align="right">Cтатус замовлення:
		</td>
		<td>
			<uc1:OrderStatusChoice id="choice_OrderStatusID" runat="server" AddEmptyItem="false" AllowCustomText="false" UseValueInsteadText="true"></uc1:OrderStatusChoice>
		</tr>   
	<tr>
		
		<td align="right" valign="top">Примітка працівників фотосалону:
		</td>
		<td>
			<asp:textbox id="text_OfficeNote" runat="server" CssClass="textBoxStyle" TextMode="MultiLine" Rows="5"></asp:textbox>
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
  <asp:imagebutton id="btnUpdate" runat="server" CommandArgument="Update"  CssClass="b_style" commandname="Update" ImageUrl="~/NewImages/Update.gif"></asp:imagebutton>&nbsp;
			<asp:imagebutton id="btnCancel" runat="server" commandname="Cancel"  CssClass="b_style" causesvalidation="False" ImageUrl="~/NewImages/Cancel.gif"></asp:imagebutton>
		 </td>
	</tr>
</TABLE>