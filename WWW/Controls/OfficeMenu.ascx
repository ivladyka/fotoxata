<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OfficeMenu.ascx.cs" Inherits="OfficeMenu" %>
<div class="dottedtop" style="margin-top: 10px; overflow: hidden; min-height:400px;">
<ul id="ulmenu" style="font-size: 14px; font-weight: normal; text-decoration: none; list-style-type: none; vertical-align: top;" >
<li runat="server" ID="liOrders"><asp:HyperLink  runat="server" NavigateUrl="~/Office/Office.aspx?content=OrderDashboard" Text="ЗАМОВЛЕННЯ"  CssClass="Headerlink">ЗАМОВЛЕННЯ</asp:HyperLink></li>
<li runat="server" ID="liScheduling"><asp:HyperLink  runat="server" NavigateUrl="~/Office/Office.aspx?content=ScheduleList" Text="ПЛАНУВАННЯ"  CssClass="Headerlink">ПЛАНУВАННЯ</asp:HyperLink></li>     
<li ID="liUsers" Visible="false" runat="server"><asp:HyperLink runat="server" NavigateUrl="~/Office/Office.aspx?content=UserList" Text="КОРИСТУВАЧІ" CssClass="Headerlink" >КОРИСТУВАЧІ</asp:HyperLink></li>
<li ID="liPhotoSalon" runat="server" Visible="false"><asp:HyperLink  runat="server" NavigateUrl="~/Office/Office.aspx?content=PhotoSalonList" Text="ФОТОСАЛОНИ"   CssClass="Headerlink">ФОТОСАЛОНИ</asp:HyperLink></li>  
<li runat="server" ID="liCategory" Visible="false"><asp:HyperLink  runat="server" NavigateUrl="~/Office/Office.aspx?content=CategoryList" Text="КАТЕГОРІЇ"  CssClass="Headerlink">КАТЕГОРІЇ</asp:HyperLink>  </li>    
<li runat="server" ID="liAdvice" Visible="false"><asp:HyperLink  runat="server" NavigateUrl="~/Office/Office.aspx?content=AdviceList" Text="ПОРАДИ"  CssClass="Headerlink">ПОРАДИ</asp:HyperLink> </li>     
<li runat="server" ID="liDelivery" Visible="false"><asp:HyperLink  runat="server" NavigateUrl="~/Office/Office.aspx?content=DeliveryList" Text="ДОСТАВКА"  CssClass="Headerlink">ДОСТАВКА</asp:HyperLink></li>
<li runat="server" ID="liNews" Visible="false"><asp:HyperLink  runat="server" NavigateUrl="~/Office/Office.aspx?content=NewsList" Text="НОВИНИ" CssClass="Headerlink">НОВИНИ</asp:HyperLink> </li>     
<li runat="server" ID="liOrderStatus" Visible="false"><asp:HyperLink  runat="server" NavigateUrl="~/Office/Office.aspx?content=OrderStatusList" Text="СТАТУС ЗАМОВЛЕННЯ" CssClass="Headerlink">СТАТУС ЗАМОВЛЕННЯ</asp:HyperLink></li>     
<li runat="server" ID="liDeleteOrders" Visible="false"><asp:HyperLink ID="hlDeleteOrders"  runat="server" NavigateUrl="~/Office/Office.aspx?content=DeleteOrders" Text="ВИДАЛИТИ ЗАМОВЛЕННЯ" CssClass="Headerlink">ВИДАЛИТИ ЗАМОВЛЕННЯ</asp:HyperLink></li>     
</ul> 
</div> <div class="bottomdottedtop" style="margin-top: 60px"></div>