<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TreeView.ascx.cs" Inherits="TreeView" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
  <asp:SiteMapDataSource ID="SiteMapDataSource1" Runat="server" SiteMapProvider="TopMenuMap" ShowStartingNode="false" StartFromCurrentNode="true"/>
<%@ Register TagPrefix="uc1" TagName="CategoryView" Src="CategoryView.ascx" %>
<div style="margin-top: 10px"> 
<div style="width: 598px; overflow:hidden;     float: left;">
<div class="dottedtop" style="width: 598px !important;  height: 800px !important;"> 
 <asp:TreeView ID="TreeView1" Runat="Server" DataSourceID="SiteMapDataSource1" 
         ImageSet="Custom" Font-Strikeout="False" ShowLines="False" Width="500" 
         ExpandImageUrl="~/NewImages/separator.gif" 
         CollapseImageUrl="~/NewImages/separatordown.gif" ExpandDepth="0" Font-Size="12pt"  Font-Names="GOTHIC1" EnableViewState="True" PopulateNodesFromClient="True" ShowExpandCollapse="False">
      <ParentNodeStyle  Width="490" CssClass="parentstyle"/>
      <HoverNodeStyle ForeColor="#ED1C24"   />
      <SelectedNodeStyle ForeColor="#ED1C24" 
          HorizontalPadding="0px" VerticalPadding="0px" />
      <RootNodeStyle BorderStyle="None" />
      <NodeStyle Font-Size="10pt" 
          HorizontalPadding="0px" NodeSpacing="0px" VerticalPadding="0px" CssClass="Nodestyle"/>
      <LeafNodeStyle  />
  </asp:TreeView>

</div>
<div class="bottomdottedtop" style="width: 598px !important;"></div>
</div>  
<div style="width: 400px; float: right; vertical-align: top;">
<div style="float:none; text-align:right !important;" align="right">
 <uc1:CategoryView id="categoryView" runat="server"></uc1:CategoryView>
 </div>
</div>
</div>