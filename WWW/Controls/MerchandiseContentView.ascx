<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MerchandiseContentView.ascx.cs" Inherits="MerchandiseContentView" %>
<%@ Register TagPrefix="uc1" TagName="CategoryView" Src="CategoryView.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MerchandiseView" Src="MerchandiseView.ascx" %>
<%@ Register TagPrefix="uc1" TagName="GalleryView" Src="GalleryView.ascx" %>
<div>   
<div class="dottedtop" style="margin-top: 10px; overflow: hidden; min-height:400px;">
<table cellpadding="0" cellspacing="0" border="0" width="100%">
    <tr>
        <td align="center" >
            <uc1:MerchandiseView id="merchandiseView" runat="server"></uc1:MerchandiseView>
        </td>
    </tr>
    <tr>
        <td>

            <uc1:CategoryView id="categoryView" runat="server"></uc1:CategoryView>
        </td>
    </tr>
</table>
</div>
<div class="bottomdottedtop" style="margin-top: 40px"></div>
</div>