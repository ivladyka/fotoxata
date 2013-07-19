<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsEdit.ascx.cs" Inherits="NewsEdit" %>
<%@ Register TagPrefix="uc1" TagName="EditorHTML" Src="ValueControls/EditorHTML.ascx" %>
<%@ Register TagPrefix="uc1" TagName="DatePicker" Src="ValueControls/DatePicker.ascx" %>
<TABLE id="Table3" class="EditControl3" cellSpacing="2" cellPadding="2" border="0" >	
    <tr>			
		<td align="right">Заголовок:
		</td>
		<td >
	        <asp:textbox id="text_Title" runat="server" MaxLength="50" CssClass="textBoxStyle" Width="300px"></asp:textbox>
        </td>
    </tr>   
    <tr>
        <td align="right">Заголовок (рос.):</td>
        <td>
            <asp:TextBox ID="text_Title_ru" runat="server" CssClass="textBoxStyle" MaxLength="50"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">Заголовок (анг.):
        </td>
        <td>
            <asp:TextBox ID="text_Title_en" runat="server" CssClass="textBoxStyle" MaxLength="50"></asp:TextBox>
        </td>
    </tr>
    <tr>			
		<td align="right">Дата:
		</td>
		<td >
	        <uc1:DatePicker id="date_DateNews" runat="server" IsRequire="true"></uc1:DatePicker>
        </td>
    </tr>   
    <tr>			
		<td align="right">Дата закінчення:
		</td>
		<td >
	        <uc1:DatePicker id="date_DateExpired" runat="server"></uc1:DatePicker>
        </td>
    </tr>  
	<tr>
		<td align="right">Новина:
		</td>
		<td>
           <uc1:EditorHTML id="editor_NewsContent" runat="server" IsRequire="true"></uc1:EditorHTML>
		</td>
	</tr> 
	<tr>
		<td align="right">Новина (рос.):
		</td>
		<td>
           <uc1:EditorHTML id="editor_NewsContent_ru" runat="server" IsRequire="true"></uc1:EditorHTML>
		</td>
	</tr> 
    <tr>
		<td align="right">Новина (анг.):
		</td>
		<td>
           <uc1:EditorHTML id="editor_NewsContent_en" runat="server" IsRequire="true"></uc1:EditorHTML>
		</td>
	</tr> 
	<tr>
	    <td colspan='2' align="right">
	      <asp:imagebutton id="btnUpdate" runat="server" CommandArgument="Update"  CssClass="b_style" commandname="Update" ImageUrl="~/NewImages/Update.gif"></asp:imagebutton>&nbsp;
			<asp:imagebutton id="btnCancel" runat="server" commandname="Cancel"  CssClass="b_style" causesvalidation="False" ImageUrl="~/NewImages/Cancel.gif"></asp:imagebutton>
        </td>
	</tr>
</TABLE>