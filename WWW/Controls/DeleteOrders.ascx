<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DeleteOrders.ascx.cs" Inherits="DeleteOrders" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="uc1" TagName="IntInput" Src="ValueControls/IntInput.ascx" %>
<telerik:RadAjaxPanel id="rapImageView" runat="server" EnableAJAX="True" LoadingPanelID="ralpDeleteOrders" BorderColor="#a1a1a1">
<TABLE id="tblOrderDel" runat="server" class="EditControl3" cellSpacing="2" cellPadding="2" border="0" >	
    <tr>			
		<td align="right">Видалити всі замовлення, включно до : 
        <asp:TextBox ID="tbOrderNumber" runat="server"></asp:TextBox>
		</td>
    </tr>   
	<tr>
	    <td align="right">
	      <asp:imagebutton id="btnUpdate" runat="server" CommandArgument="Update"  
                CssClass="b_style" commandname="Update" ImageUrl="~/NewImages/Update.gif" 
                onclick="btnUpdate_Click" ToolTip="Видалити"></asp:imagebutton>&nbsp;
			<asp:imagebutton id="btnCancel" runat="server" commandname="Cancel"  
                CssClass="b_style" causesvalidation="False" ImageUrl="~/NewImages/Cancel.gif" 
                onclick="btnCancel_Click"></asp:imagebutton>
        </td>
	</tr>
</TABLE>
<asp:Label ID="lblError" runat="server" Font-Bold="true"></asp:Label>
</telerik:RadAjaxPanel> 
<telerik:RadAjaxLoadingPanel ID="ralpDeleteOrders" runat="server" Transparency="0" BackColor="White">
    <div style="width: 100%; height: 200px;">
        <img src="../Images/LoadingSunset.gif" style="padding-top: 70px;"/>
    </div>
</telerik:RadAjaxLoadingPanel> 