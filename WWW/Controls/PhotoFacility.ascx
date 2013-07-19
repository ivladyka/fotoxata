<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PhotoFacility.ascx.cs" Inherits="PhotoFacility" %>
  <asp:SiteMapDataSource ID="SiteMapDataSource1" Runat="server" SiteMapProvider="TopMenuMap" ShowStartingNode="true" />
  <asp:TreeView ID="TreeView1" Runat="Server" DataSourceID="SiteMapDataSource1" ImageSet="Simple">
      <ParentNodeStyle  />
      <HoverNodeStyle ForeColor="#ED1C24" />
      <SelectedNodeStyle ForeColor="#ED1C24" 
          HorizontalPadding="0px" VerticalPadding="0px" />
      <RootNodeStyle  />
      <NodeStyle Font-Size="10pt" 
          HorizontalPadding="0px" NodeSpacing="0px" VerticalPadding="0px" />
      <LeafNodeStyle  />
  </asp:TreeView>
