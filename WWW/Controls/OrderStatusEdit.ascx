<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OrderStatusEdit.ascx.cs" Inherits="OrderStatusEdit" %>
<TABLE id="Table3" class="EditControl4" cellSpacing="2" cellPadding="2"  align="center" border="0" >	
    <tr>			
		<td align="right">Назва:
		</td>
		<td >
	        <asp:textbox id="text_Name" runat="server" CssClass="textBoxStyle" MaxLength="50"></asp:textbox>
	        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Обов'язкове поле." ControlToValidate="text_Name" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>			
		<td align="right">Назва (рос.):
		</td>
		<td >
	        <asp:textbox id="text_Name_ru" runat="server" CssClass="textBoxStyle" MaxLength="50"></asp:textbox>
	        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Обов'язкове поле." ControlToValidate="text_Name_ru" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>			
		<td align="right">Назва (анг.):
		</td>
		<td >
	        <asp:textbox id="text_Name_en" runat="server" CssClass="textBoxStyle" MaxLength="50"></asp:textbox>
	        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Обов'язкове поле." ControlToValidate="text_Name_en" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
		<td align="right">Діючий:
		</td>
		<td>
           <asp:CheckBox id="chk_Active" runat="server" Text="" Checked="true"></asp:CheckBox>
		</td>
    </tr>
  	<tr>
	    <td colspan='2' align="right">
 <asp:imagebutton id="btnUpdate" runat="server" CommandArgument="Update"  CssClass="b_style" commandname="Update" ImageUrl="~/NewImages/Update.gif"></asp:imagebutton>&nbsp;
			<asp:imagebutton id="btnCancel" runat="server" commandname="Cancel"  CssClass="b_style" causesvalidation="False" ImageUrl="~/NewImages/Cancel.gif"></asp:imagebutton>
			 </td>
	</tr>
</table>