<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdviceEdit.ascx.cs" Inherits="AdviceEdit" %>
<%@ Register TagPrefix="uc1" TagName="EditorHTML" Src="ValueControls/EditorHTML.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PhotoUpload" Src="ValueControls/PhotoUpload.ascx" %>
<TABLE id="Table3" class="EditControl3" cellSpacing="2" cellPadding="2"  align="center" border="0" >	
    <tr>			
		<td align="right">Запитання:
		</td>
		<td >
	        <asp:textbox id="text_Question" runat="server" CssClass="textBoxStyle" MaxLength="250" Width="440px"></asp:textbox>
	        <asp:RequiredFieldValidator ID="rfvQuestion" runat="server" ErrorMessage="Обов'язкове поле." ControlToValidate="text_Question" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>			
		<td align="right">Запитання (рос.):
		</td>
		<td >
	        <asp:textbox id="text_Question_ru" runat="server" CssClass="textBoxStyle" MaxLength="250" Width="440px"></asp:textbox>
	        <asp:RequiredFieldValidator ID="rfvQuestion_ru" runat="server" ErrorMessage="Обов'язкове поле." ControlToValidate="text_Question_ru" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>			
		<td align="right">Запитання (анг.):
		</td>
		<td >
	        <asp:textbox id="text_Question_en" runat="server" CssClass="textBoxStyle" MaxLength="250" Width="440px"></asp:textbox>
	        <asp:RequiredFieldValidator ID="rfvQuestion_en" runat="server" ErrorMessage="Обов'язкове поле." ControlToValidate="text_Question_en" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
		<td align="right">Відповідь:
		</td>
		<td>
           <uc1:EditorHTML id="editor_Answer" runat="server" IsRequire="true"></uc1:EditorHTML>
		</td>
	</tr> 
    <tr>
		<td align="right">Відповідь (рос.):
		</td>
		<td>
           <uc1:EditorHTML id="editor_Answer_ru" runat="server" IsRequire="true"></uc1:EditorHTML>
		</td>
	</tr> 
    <tr>
		<td align="right">Відповідь (анг.):
		</td>
		<td>
           <uc1:EditorHTML id="editor_Answer_en" runat="server" IsRequire="true"></uc1:EditorHTML>
		</td>
	</tr> 
  	<tr>
	    <td colspan='2' align="right">
	   <asp:imagebutton id="btnUpdate" runat="server" CommandArgument="Update"  CssClass="b_style" commandname="Update" ImageUrl="~/NewImages/Update.gif"></asp:imagebutton>&nbsp;
			<asp:imagebutton id="btnCancel" runat="server" commandname="Cancel"  CssClass="b_style" causesvalidation="False" ImageUrl="~/NewImages/Cancel.gif"></asp:imagebutton>
			 </td>
	</tr>
</TABLE>