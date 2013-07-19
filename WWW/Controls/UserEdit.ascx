<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserEdit.ascx.cs" Inherits="UserEdit" %>
<%@ Register TagPrefix="uc1" TagName="PhotoSalonChoice" Src="ChoiceControls/PhotoSalonChoice.ascx" %>
<TABLE id="Table3" class="EditControl3" cellSpacing="2" cellPadding="2"  align="center" border="0" >	
		<tr>			
		<td align="right">Ім`я:
		</td>
		<td >
	        <asp:textbox id="text_FirstName" runat="server" CssClass="textBoxStyle" MaxLength="50"></asp:textbox>
          </td>
          </tr>
          <tr>
		<td align="right">Прізвище:
		</td>
		<td>
			<asp:textbox id="text_LastName" runat="server" CssClass="textBoxStyle" MaxLength="50"></asp:textbox>
		</td>
		</tr>
		  <tr>
		<td align="right">Телефон:
		</td>
		<td>
			<asp:textbox id="text_CellPhone" runat="server" CssClass="textBoxStyle" MaxLength="50"></asp:textbox>
			<asp:RequiredFieldValidator ID="rfvCellPhone" runat="server" ErrorMessage="Обов'язкове поле." ControlToValidate="text_CellPhone" Display="Dynamic"></asp:RequiredFieldValidator>
		</td>
		</tr>
	    <tr>
		<td align="right">Пароль:
		</td>
		<td>
			<asp:textbox id="text_Password" runat="server" CssClass="textBoxStyle" MaxLength="50"></asp:textbox>
			<asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Обов'язкове поле." ControlToValidate="text_Password" Display="Dynamic"></asp:RequiredFieldValidator>
		</td>
		</tr>
		<tr>
		<td align="right">Підтвердіть пароль:
		</td>
		<td>
			<asp:textbox id="tbPassword1" runat="server" CssClass="textBoxStyle" MaxLength="50"></asp:textbox>
			<asp:CompareValidator ID="cvComparePassword" runat="server" 
                ErrorMessage="<br>Паролі не рівні. Спробуйте ввести паролі ще раз." ControlToCompare="text_Password" 
                ControlToValidate="tbPassword1" Display="Dynamic" 
                Operator="Equal"></asp:CompareValidator>

		</td>
		</tr>
		<tr>
		<td align="right">E-mail:
		</td>
		<td>
			<asp:textbox id="text_EMailAddress" runat="server" CssClass="textBoxStyle" MaxLength="50"></asp:textbox>
			<asp:RegularExpressionValidator ID="revEmail" runat="server" 
                ControlToValidate="text_EMailAddress" Display="Dynamic" 
                ErrorMessage="&lt;br&gt;Введіть коректний E-mail адрес." 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
		</td>
		</tr>
		<tr>
		<td align="right">Фотосалон:
		</td>
		<td><uc1:PhotoSalonChoice id="choice_PhotoSalonID" runat="server" UseValueInsteadText="true" Width="300"></uc1:PhotoSalonChoice>
		</td>
		</tr>
		<tr>
		<td align="right">Активний:
		</td>
		<td>
           <asp:CheckBox id="chk_Active" runat="server" Text="" Checked="true"></asp:CheckBox>
		</td>
		</tr>
		<tr>
			<td align="right">Ролі:</td>
			<td><asp:CheckBoxList Runat=server ID="cblUserType" BorderStyle="Solid" 
                    BorderWidth="1px" BorderColor="#EAEAEA"></asp:CheckBoxList></td>
		</tr>
  	<tr>
	    <td colspan='2' align="right">
	   <asp:imagebutton id="btnUpdate" runat="server" CommandArgument="Update"  CssClass="b_style" commandname="Update" ImageUrl="~/NewImages/Update.gif"></asp:imagebutton>&nbsp;
			<asp:imagebutton id="btnCancel" runat="server" commandname="Cancel"  CssClass="b_style" causesvalidation="False" ImageUrl="~/NewImages/Cancel.gif"></asp:imagebutton>
			 </td>
	</tr>
</table>