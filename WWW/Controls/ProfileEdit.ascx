<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProfileEdit.ascx.cs" Inherits="ProfileEdit" %>
<%@ Register TagPrefix="uc1" TagName="PhotoSalonChoice" Src="ChoiceControls/PhotoSalonChoice.ascx" %>
<script language="javascript">
    function VIKKI_RequiredCheckBox(source, arguments) {
        var AgreeCheckBox = document.getElementById('<%= chkAgree.ClientID %>');
        if (AgreeCheckBox != null) {
            if (!AgreeCheckBox.checked) {
                arguments.IsValid = false;
                return;
            }
        }
        arguments.IsValid = true;
    }
</script>
<div>   
<div class="dottedtop" style="margin-top: 10px; overflow: hidden; min-height:450px;">
<TABLE id="Table3" style="margin: 10px 50px 50px 100px; vertical-align: middle; text-align: left;" border="0" width="450" align="center" cellpadding="3" cellspacing="10"    align="center" border="0" >	
		<tr>			
		<td align="right"><%=FirstName %>:
		</td>
		<td >
	        <asp:textbox id="text_FirstName" runat="server" CssClass="textBoxStyle" MaxLength="50"></asp:textbox>
          </td>
          </tr>
          <tr>
		<td align="right"><%=Surname%>:
		</td>
		<td>
			<asp:textbox id="text_LastName" runat="server" CssClass="textBoxStyle" MaxLength="50"></asp:textbox>
		</td>
		</tr>
		  <tr>
		<td align="right"><%=Phone%>:
		</td>
		<td>
			<asp:textbox id="text_CellPhone" runat="server" CssClass="textBoxStyle" MaxLength="50"></asp:textbox>
			<asp:RequiredFieldValidator ID="rfvCellPhone" runat="server" ErrorMessage="<%$Resources:Fotoxata, RequiredField %>" ControlToValidate="text_CellPhone" Display="Dynamic" ValidationGroup="ProfileEdit"></asp:RequiredFieldValidator>
		</td>
		</tr>
	    <tr>
		<td align="right"><%=Password%>:
		</td>
		<td>
			<asp:textbox id="text_Password" runat="server" CssClass="textBoxStyle" MaxLength="50"></asp:textbox>
			<asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="<%$Resources:Fotoxata, RequiredField %>" ControlToValidate="text_Password" Display="Dynamic" ValidationGroup="ProfileEdit"></asp:RequiredFieldValidator>
		</td>
		</tr>
		<tr>
		<td align="right"><%=PasswordConfirm%>:
		</td>
		<td>
			<asp:textbox id="tbPassword1" runat="server" CssClass="textBoxStyle" MaxLength="50"></asp:textbox>
			<asp:CompareValidator ID="cvComparePassword" runat="server" 
                ErrorMessage="<%$Resources:Fotoxata, PasswordNotEqual %>" ControlToCompare="text_Password" 
                ControlToValidate="tbPassword1" Display="Dynamic" 
                Operator="Equal" ValidationGroup="ProfileEdit"></asp:CompareValidator>

		</td>
		</tr>
		<tr>
		<td align="right">E-mail:
		</td>
		<td>
			<asp:textbox id="text_EMailAddress" runat="server" CssClass="textBoxStyle" MaxLength="50"></asp:textbox>
			<asp:RegularExpressionValidator ID="revEmail" runat="server" 
                ControlToValidate="text_EMailAddress" Display="Dynamic" 
                ErrorMessage="<%$Resources:Fotoxata, EmailIncorrect %>" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="ProfileEdit"></asp:RegularExpressionValidator>
		</td>
		</tr>	
    <tr id="rowAffreement" runat="server">
        <td align="right"><br />
            <asp:CheckBox ID="chkAgree" runat="server" Text="" Checked="true" />
        </td>
        <td>
            <%=Agreement%>
            <br />
            <asp:CustomValidator ID="cvAgree" runat="server" EnableClientScript="true" ClientValidationFunction="VIKKI_RequiredCheckBox" ErrorMessage="<%$Resources:Fotoxata, RequiredField %>" ValidationGroup="ProfileEdit"></asp:CustomValidator>
        </td>
    </tr>
  	<tr>
	    <td colspan='2' align="right">
	   <asp:imagebutton id="btnUpdate" runat="server" CommandArgument="Update"  CssClass="b_style" commandname="Update" ImageUrl="~/NewImages/Update.gif" ValidationGroup="ProfileEdit"></asp:imagebutton>&nbsp;
			<asp:imagebutton id="btnCancel" runat="server" commandname="Cancel"  CssClass="b_style" causesvalidation="False" ImageUrl="~/NewImages/Cancel.gif"></asp:imagebutton>
			 </td>
	</tr>
</table>
<div class="bottomdottedtop" style="margin-top: 40px"></div>
</div>