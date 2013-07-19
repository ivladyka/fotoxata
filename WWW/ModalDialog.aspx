<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModalDialog.aspx.cs" Inherits="ModalDialog" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="pragma" content="nocache">
		<meta http-equiv="Expires" content="-1">
		<base target="_self">
		<script src="Scripts.js" type="text/javascript"></script>
        <LINK href="style.css" type="text/css" rel="stylesheet">
		<LINK href="style_global.css" type="text/css" rel="stylesheet">
		<link href="RadControls/Grid/ColorSchemes/Yellow/Styles.css" type="text/css" rel="stylesheet">
</head>
<body style="padding: 0px; margin:0px; width:auto; height: auto"  onload="VIKKI_LoadModalDialog();">
    <form id="form1" runat="server" style="padding: 0px; margin:0px; height: auto; width:auto;">
    <telerik:RadScriptManager runat="Server" ID="RadScriptManager1" />
    <table  border="0" cellpadding="0" cellspacing="0" >
				<tr>
					<td>
					<table width="100%" cellpadding="0" cellspacing="0" border="0">
						<tr>
							<td style="padding-top: 5px; padding-left: 5px; margin:0px;">
								<b>
									<asp:Label id="lbTitle" runat="server" CssClass="FontSmall">Label</asp:Label></b>
							</td>
						</tr>
					</table>
					</td>
				</tr>
				<tr>
					<td align="center">
						<asp:PlaceHolder id="PlaceHolder1" runat="server"></asp:PlaceHolder>
					</td>
				</tr>
			</table>
    </form>
</body>
</html>
