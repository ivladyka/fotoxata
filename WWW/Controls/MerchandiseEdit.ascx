<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MerchandiseEdit.ascx.cs" Inherits="MerchandiseEdit" %>
<%@ Register TagPrefix="uc1" TagName="NumericInput" Src="ValueControls/NumericInput.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PhotoUpload" Src="ValueControls/PhotoUpload.ascx" %>
<TABLE id="Table3" class="EditControl3" cellSpacing="2" cellPadding="2" align="center" border="0" Width="600px">	
    <tr>			
		<td align="right">Назва:
		</td>
		<td >
	        <asp:textbox id="text_Name" runat="server" CssClass="textBoxStyle" MaxLength="50"></asp:textbox>
	        <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Обов'язкове поле." ControlToValidate="text_Name" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>			
		<td align="right">Назва (рос.):
		</td>
		<td >
	        <asp:textbox id="text_Name_ru" runat="server" CssClass="textBoxStyle" MaxLength="50"></asp:textbox>
	        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Обов'язкове поле." ControlToValidate="text_Name_ru" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>			
		<td align="right">Назва (анг.):
		</td>
		<td >
	        <asp:textbox id="text_Name_en" runat="server" CssClass="textBoxStyle" MaxLength="50"></asp:textbox>
	        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Обов'язкове поле." ControlToValidate="text_Name_en" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>			
		<td align="right">Опис:
		</td>
		<td >
	        <asp:textbox id="text_Description" runat="server" CssClass="textBoxStyle" TextMode="MultiLine" Rows="5"></asp:textbox>
        </td>
    </tr>
    <tr>			
		<td align="right">Опис (рос.):
		</td>
		<td >
	        <asp:textbox id="text_Description_ru" runat="server" CssClass="textBoxStyle" TextMode="MultiLine" Rows="5"></asp:textbox>
        </td>
    </tr>
    <tr>			
		<td align="right">Опис (анг.):
		</td>
		<td >
	        <asp:textbox id="text_Description_en" runat="server" CssClass="textBoxStyle" TextMode="MultiLine" Rows="5"></asp:textbox>
        </td>
    </tr>
	<tr>
		<td align="right">Зображення:
		</td>
		<td>
           <uc1:PhotoUpload id="upload_PhotoName" runat="server" AllowedFileExtensions="jpg"></uc1:PhotoUpload>
		</td>
	</tr>
	<tr>
		<td align="right">Ціна, грн:
		</td>
		<td>
           від <uc1:NumericInput id="num_PriceFrom" runat="server"></uc1:NumericInput>
		    до <uc1:NumericInput id="num_PriceTo" runat="server"></uc1:NumericInput>
		</td>
	</tr>
	<tr>
		<td align="right">Показати на Прайсі:
		</td>
		<td>
           <asp:CheckBox id="chk_DisplayOnPrice" runat="server" Text=""></asp:CheckBox>
		</td>
	</tr>
	<tr>
	    <td colspan='2' align="right">
  <asp:imagebutton id="btnUpdate" runat="server" CommandArgument="Update"  CssClass="b_style" commandname="Update" ImageUrl="~/NewImages/Update.gif"></asp:imagebutton>&nbsp;
			<asp:imagebutton id="btnCancel" runat="server" commandname="Cancel"  CssClass="b_style" causesvalidation="False" ImageUrl="~/NewImages/Cancel.gif"></asp:imagebutton>
        </td>
	</tr>
</TABLE>