<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Default.ascx.cs" Inherits="Default" %>
<%@ Register TagPrefix="uc1" TagName="HomeSection" Src="HomeSection.ascx" %>
<style type="text/css">
   .galleria-thumbnails-container
    {
    	visibility: hidden !important;
    	display: none !important;
    }  
    .galleria-container
    {
        height: 530px !important;
    }
    .galleria-stage {
        bottom: 10px !important;
    }
 </style>
<div style="width:1000px; " align="center">
    <div id="gallery" runat="server" style="width: 700px" align="center">
    </div>
<div style="width:1000px; height:200px; ">    
    <uc1:HomeSection id="hsPrintInternet" runat="server" PageLink="~/Default.aspx?content=OrderAdd&CategoryID=9" CategoryID="9"></uc1:HomeSection>
    <uc1:HomeSection id="hsNews" runat="server" PageLink="~/Default.aspx?content=NewsLinkList" Title="<%$Resources:Fotoxata, News %>"></uc1:HomeSection>
    <uc1:HomeSection id="hsInteresting" runat="server" PageLink="~/Default.aspx?content=AdviceTableList" Title="<%$Resources:Fotoxata, Advices %>"></uc1:HomeSection>
    <uc1:HomeSection id="hsHandMake" runat="server" PageLink="~/Default.aspx?content=GalleryPhotoView&CategoryID=73" CategoryID="73"></uc1:HomeSection>
</div>
</div>
<script language="javascript">
    Galleria.loadTheme('galleria/themes/classic/galleria.classic.min.js');
    $("#<%=gallery.ClientID%>").galleria({
        width: 700,
        height: 550,
        autoplay: 5000,
        showImagenav: false,
        imagePosition: '0 0',
        thumbnails: false,
        transitionSpeed: 1000,
        debug: false
    });
</script>

