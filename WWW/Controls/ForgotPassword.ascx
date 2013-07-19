<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.ascx.cs" Inherits="ForgotPassword" %>
<table>
    <tr>
        <td colspan="2"><%=ForgotPasswordMessage%></td>
    </tr>
    <tr>
        <td width="130px">
            <%=MobilePhone%>:
        </td>
        <td>
            <asp:textbox id="tbCellPhoneNumber" runat="server" Width="140px" MaxLength="50" TextMode="SingleLine"></asp:textbox>
			<asp:RequiredFieldValidator id="rfvUserName" runat="server" ErrorMessage="<%$Resources:Fotoxata, RequiredField %>" ControlToValidate="tbCellPhoneNumber"
			    Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:Label id="lbNotFound" runat="server" ForeColor="Red" Visible="False" Font-Bold="true"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:ImageButton ToolTip="<%$Resources:Fotoxata, Send %>" onmouseover="VIKKI_PuzzleOnMouseOver(event, 'NewImages/send1.gif' );" 
                onmouseout="VIKKI_PuzzleOnMouseOver(event, 'NewImages/send.gif');" ID="btnSendPassword" runat="server" style="border: none;" OnClick="btnSendPassword_Click" />
        </td>
    </tr>
</table>