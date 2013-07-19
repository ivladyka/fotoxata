<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PhotoSalonEdit.ascx.cs" Inherits="PhotoSalonEdit" %>
<%@ Register TagPrefix="uc1" TagName="MaskedTextBox" Src="ValueControls/MaskedTextBox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="EditorHTML" Src="ValueControls/EditorHTML.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PhotoUpload" Src="ValueControls/PhotoUpload.ascx" %>
<TABLE id="Table3" class="EditControl4" cellSpacing="3" cellPadding="2"  align="center" border="0" >	
		<tr>			
		<td align="right">Адреса:
		</td>
		<td >
	        <asp:textbox id="text_Address" runat="server" CssClass="textBoxStyle" MaxLength="50"></asp:textbox>
	        <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="Обов'язкове поле." ControlToValidate="text_Address" Display="Dynamic"></asp:RequiredFieldValidator>
          </td>
        </tr>
        <tr>			
		<td align="right">Адреса (рос.):
		</td>
		<td >
	        <asp:textbox id="text_Address_ru" runat="server" CssClass="textBoxStyle" MaxLength="50"></asp:textbox>
	        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Обов'язкове поле." ControlToValidate="text_Address_ru" Display="Dynamic"></asp:RequiredFieldValidator>
          </td>
        </tr>
        <tr>			
		<td align="right">Адреса (анг.):
		</td>
		<td >
	        <asp:textbox id="text_Address_en" runat="server" CssClass="textBoxStyle" MaxLength="50"></asp:textbox>
	        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Обов'язкове поле." ControlToValidate="text_Address_en" Display="Dynamic"></asp:RequiredFieldValidator>
          </td>
        </tr>
        <tr>
		<td align="right">Телефон 1:
		</td>
		<td>
			<uc1:MaskedTextBox id="msk_Phone1" runat="server" Mask="+38(###) #######" UseTextWithLiterals="true" ></uc1:MaskedTextBox>
		</td>
		</tr>
		  <tr>
		<td align="right">Телефон 2:
		</td>
		<td>
		    <uc1:MaskedTextBox id="msk_Phone2" runat="server" Mask="+38(###) #######" UseTextWithLiterals="true"></uc1:MaskedTextBox>
		</td>
		</tr>
				  <tr>
		<td align="right">Телефон 3:
		</td>
		<td>
			<uc1:MaskedTextBox id="msk_Phone3" runat="server" Mask="+38(###) #######" UseTextWithLiterals="true"></uc1:MaskedTextBox>
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
		<td align="right">Кнопка:
		</td>
		<td>
           <uc1:PhotoUpload id="upload_ButtonImage" runat="server" AllowedFileExtensions="png,jpg" CreateThumbnail="True"></uc1:PhotoUpload>
		</td>
	</tr>
	<tr>
		<td align="right">Про фотосалон:
		</td>
		<td>
           <uc1:EditorHTML id="editor_Description" runat="server" IsRequire="true" ></uc1:EditorHTML>
		</td>
	</tr> 
    <tr>
		<td align="right">Про фотосалон (рос.):
		</td>
		<td>
           <uc1:EditorHTML id="editor_Description_ru" runat="server" IsRequire="true" ></uc1:EditorHTML>
		</td>
	</tr> 
    <tr>
		<td align="right">Про фотосалон (анг.):
		</td>
		<td>
           <uc1:EditorHTML id="editor_Description_en" runat="server" IsRequire="true" ></uc1:EditorHTML>
		</td>
	</tr> 
  	<tr>
	    <td colspan='2' align="right">
	   <asp:imagebutton id="btnUpdate" runat="server" CommandArgument="Update"  CssClass="b_style" commandname="Update" ImageUrl="~/NewImages/Update.gif"></asp:imagebutton>&nbsp;
			<asp:imagebutton id="btnCancel" runat="server" commandname="Cancel"  CssClass="b_style" causesvalidation="False" ImageUrl="~/NewImages/Cancel.gif"></asp:imagebutton>
			 </td>
	</tr>
</table>