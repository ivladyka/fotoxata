<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TopMenu.ascx.cs" Inherits="TopMenu"  %>
  <asp:menu ID="mnTop" 
    Runat="server" 
       dynamicverticaloffset="5" 
       staticdisplaylevels="1"
       orientation="Horizontal"  
        Font-Size="9pt" 
        DynamicEnableDefaultPopOutImage="False" 
  StaticPopOutImageUrl="~/NewImages/separator.gif" 
  DynamicPopOutImageUrl="~/NewImages/separator.gif" 
  DynamicHoverStyle-ForeColor="White" 
  StaticHoverStyle-ForeColor="#ED1C24" 
  StaticSelectedStyle-ForeColor="#ED1C24" 
  DynamicMenuItemStyle-BackColor="white" 
  DynamicMenuStyle-HorizontalPadding="0" 
  DynamicHoverStyle-BackColor="#ED1C24" 
  Font-Strikeout="False" 
  DynamicMenuStyle-CssClass="DynamicMenustyle1"
  DynamicMenuItemStyle-CssClass="DynMenuItemStyle" 
  DynamicMenuStyle-Width="270px" 
  DynamicMenuItemStyle-HorizontalPadding="0" 
  DynamicMenuItemStyle-VerticalPadding="5" 
  DynamicHoverStyle-Width="270px" 
  ItemWrap="True" DynamicHoverStyle-CssClass="DynMenuHoverStyle">
<DynamicHoverStyle BackColor="#ED1C24" ForeColor="White" Width="270px" ></DynamicHoverStyle>
<DynamicMenuItemStyle  BackColor="White" CssClass="DynMenuItemStyle" HorizontalPadding="10px" Width="270px"></DynamicMenuItemStyle>
<DynamicMenuStyle HorizontalPadding="0px" CssClass="DynamicMenustyle1" Width="270px"></DynamicMenuStyle>
<StaticHoverStyle ForeColor="#ED1C24"></StaticHoverStyle>
<StaticMenuItemStyle CssClass="uuu" HorizontalPadding="5px" />
<StaticSelectedStyle ForeColor="#ED1C24"></StaticSelectedStyle>
 </asp:menu>