<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MerchandiseContentViewLessImage.ascx.cs" Inherits="MerchandiseContentViewLessImage" %>
<%@ Register TagPrefix="uc1" TagName="CategoryView" Src="CategoryView.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PriceList" Src="PriceList.ascx" %>
<%@ Register TagPrefix="uc1" TagName="GalleryTableView" Src="GalleryTableView.ascx" %>
<div>
<div class="dottedtop" style="margin-top: 10px; overflow: hidden; min-height:400px;">
<table cellpadding="0" cellspacing="0" border="0" width="100%">
    <tr>
        <td>
            <uc1:CategoryView id="categoryView" runat="server"></uc1:CategoryView>
        </td>
    </tr>

    <tr>
        <td align="center">
         <uc1:PriceList id="merchandiseView" runat="server"></uc1:PriceList>
        </td>
    </tr>
</table>
</div>
<div class="bottomdottedtop" style="margin-top: 40px"></div>
</div>