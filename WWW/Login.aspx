<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMP.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script src="Scripts.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphWithoutScroll" Runat="Server">

    <script language="javascript">
        function VIKKI_RedirectFromLoginPage(url, VS_FX_LVIDValue) {
		VIKKI_SetCookie('VS_FX_LVID', VS_FX_LVIDValue);
		window.location.replace(url);
	}
</script>
<table cellpadding="3" cellspacing="10"  
        style="margin: 50px 50px 50px 100px; vertical-align: middle; text-align: left;" 
        border="0" width="580">
    <tr>
        <td class="pageName" colspan="3"><%=LogInSystem%>
        </td>
    </tr>
    <tr>
        <td width="180px;" align="right"> 
            <%=MobilePhone%>:
        </td>
        <td >
            <asp:textbox id="tbCellPhoneNumber" runat="server" Width="200px" MaxLength="50" 
                TextMode="SingleLine"  CssClass="textBoxStyle"></asp:textbox>
			
        </td>
        <td width="200">
        <asp:RequiredFieldValidator id="rfvUserName" runat="server" ErrorMessage="<%$Resources:Fotoxata, RequiredField %>" ControlToValidate="tbCellPhoneNumber"
			    Display="Dynamic"></asp:RequiredFieldValidator>
		</td>
    </tr>
    <tr>
        <td align="right">
            <%=Password%>: </td>
         <td>
            <asp:textbox id="tbPassword" runat="server" Width="200px" MaxLength="50" 
                 TextMode="Password"  CssClass="textBoxStyle"></asp:textbox>
		</td>
		<td>	<asp:RequiredFieldValidator id="rfvPassword" runat="server" ErrorMessage="<%$Resources:Fotoxata, RequiredField %>" ControlToValidate="tbPassword"
			    Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="right">
           
        </td>
        <td> <asp:CheckBox id="chkKeepInSystem" runat="server" Text="" BackColor="#FBFBFB" 
                BorderColor="#EAEAEA"></asp:CheckBox>
            <%=StayLogged%>
        </td>
        <td></td>
    </tr>
    <tr>
        <td colspan="3" align="center">
            <asp:Label id="lbNotFound" runat="server" ForeColor="Red" Visible="False" Text="<%$Resources:Fotoxata, LoginIsIncorrect %>"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="3" align="right" style="padding-right: 120px">
               <asp:ImageButton id="btnLogin" runat="server"  EnableViewState="True" OnClick="btnLogin_Click" ImageUrl="~/NewImages/entrance.gif" ImageAlign="NotSet"
               onmouseover="VIKKI_PuzzleOnMouseOver(event, 'NewImages/entrance1.gif' );" onmouseout="VIKKI_PuzzleOnMouseOver(event, 'NewImages/entrance.gif');" style="border: none;"></asp:ImageButton>
        </td>
    </tr>
     <tr>
        <td colspan="3">
            <asp:HyperLink id="hlForgotPassword" runat="server" NavigateUrl="Default.aspx?content=ForgotPassword" CssClass="colorlink" Text="<%$Resources:Fotoxata, ForgotPassword %>"></asp:HyperLink>
        </td>
    </tr>  
</table>
</asp:Content>

