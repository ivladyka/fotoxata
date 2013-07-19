<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="Header" %>
     <table class="headerMenu"  cellpadding="0" cellspacing="0" border="0" width="1000px" style="height:155px;">
            <tr >
            <td style=" vertical-align:top; text-align:left; padding-top:0px;"  valign="top">
            </td>
            <td  valign="top">
            <div class="vikki_newsbtn">  <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Default.aspx?content=NewsLinkList"><img id="imgNews" runat="server" class="VIKKI_HandCursor" src="~/Images/vikki_top21.png" style="border-width:0px;" title="НОВИНИ" /></asp:HyperLink>
            </div>
            </td>
            <td  valign="top">
            <div class="vikki_interestingbtn"><asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Default.aspx?content=Interesting"><img id="imgInteresting" runat="server"  class="VIKKI_HandCursor" src="~/Images/vikki_top31.png" style="border-width:0px;" title="ЦІКАВЕ" /></asp:HyperLink>
            </div>
            </td>         
            <td style=" vertical-align:top; text-align:right; padding-right:0px; padding-top:10px;">
            </td>
            </tr>
            </table>   