<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SiteMapTree.ascx.cs" Inherits="SiteMapTree" %>
  <asp:TreeView ID="tvSiteMap" Runat="Server"  ImageSet="Custom" ShowStartingNode="False" Font-Strikeout="False" ShowLines="False" ExpandImageUrl="~/NewImages/separator.gif" CollapseImageUrl="~/NewImages/separatordown.gif" ExpandDepth="0"  >
      <ParentNodeStyle HorizontalPadding="12px" NodeSpacing="3px" />
      <HoverNodeStyle ForeColor="#ED1C24" />
      <SelectedNodeStyle ForeColor="#ED1C24" 
          HorizontalPadding="0px" VerticalPadding="0px" />
      <RootNodeStyle HorizontalPadding="5px" />
      <NodeStyle Font-Size="10pt" 
          HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
      <LeafNodeStyle  />
  </asp:TreeView>
