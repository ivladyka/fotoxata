<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SiteMapMenu.ascx.cs" Inherits="SiteMapMenu" %>
 <asp:SiteMapPath ID="siteMapPath1" Runat="server" Font-Size="7pt" 
    SiteMapProvider="TopMenuMap" PathDirection="RootToCurrent" 
    ParentLevelsDisplayed="2" PathSeparator="" Font-Underline="false"> 
     <PathSeparatorStyle CssClass="PathSeparator" Height="15" Width="15" Font-Underline="false"/>
     <CurrentNodeStyle ForeColor="#a1a1a1"  Font-Names="GOTHIC1" Font-Underline="false"/>
     <NodeStyle  Font-Names="GOTHIC1" Font-Underline="false"  CssClass="activeNodeStyle"/>
     <RootNodeStyle  ForeColor="#a1a1a1"  Font-Names="GOTHIC1" />
  </asp:SiteMapPath>


