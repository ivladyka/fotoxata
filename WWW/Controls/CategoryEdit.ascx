<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CategoryEdit.ascx.cs" Inherits="CategoryEdit" %>
<%@ Register TagPrefix="uc1" TagName="NumericInput" Src="ValueControls/NumericInput.ascx" %>
<%@ Register TagPrefix="uc1" TagName="EditorHTML" Src="ValueControls/EditorHTML.ascx" %>
<%@ Register TagPrefix="uc1" TagName="GalleryList" Src="GalleryList.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MerchandiseList" Src="MerchandiseList.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<br />
<telerik:RadTabStrip ID="rtsCategory" runat="server" AutoPostBack="true" Align="Justify" Width="747px" BorderColor="#EAEAEA" OnTabClick="rtsCategory1_TabClick">
    <Tabs>
        <telerik:RadTab Text="Категорія" Selected="True">
        </telerik:RadTab>
        <telerik:RadTab Text="Фотографії">
        </telerik:RadTab>
        <telerik:RadTab Text="Товари">
        </telerik:RadTab>
    </Tabs>
</telerik:RadTabStrip>
<asp:Panel ID="pnlCategoryEdit" runat="server" >
    <table id="Table3" align="center" border="0" cellpadding="2" cellspacing="5" 
        style="margin: 20px">
            <tr>
                <td align="right">
                    Назва:
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="text_Name" runat="server" CssClass="textBoxStyle" 
                        MaxLength="255"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" 
                        ControlToValidate="text_Name" Display="Dynamic" 
                        ErrorMessage="Обов'язкове поле."></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td align="right">
                    Назва (рос.):
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="text_Name_ru" runat="server" CssClass="textBoxStyle" 
                        MaxLength="255"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RequiredFieldValidator ID="rfvName_ru" runat="server" 
                        ControlToValidate="text_Name_ru" Display="Dynamic" 
                        ErrorMessage="Обов'язкове поле."></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td align="right">
                    Назва (анг.):
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="text_Name_en" runat="server" CssClass="textBoxStyle" 
                        MaxLength="255"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RequiredFieldValidator ID="rfvName_en" runat="server" 
                        ControlToValidate="text_Name_en" Display="Dynamic" 
                        ErrorMessage="Обов'язкове поле."></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td align="right">
                    Заголовок:
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="text_Title" runat="server" CssClass="textBoxStyle" 
                        MaxLength="255"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td align="right">
                    Заголовок (рос.):
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="text_Title_ru" runat="server" CssClass="textBoxStyle" 
                        MaxLength="255"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td align="right">
                    Заголовок (анг.):
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="text_Title_en" runat="server" CssClass="textBoxStyle" 
                        MaxLength="255"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td align="right">
                    Відображати в галереї:
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:CheckBox ID="chk_IsGallery" runat="server" Text="" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    Ціна, грн:
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; від
                    <uc1:NumericInput ID="num_PriceFrom" runat="server" />
                    &nbsp;&nbsp;&nbsp; до
                    <uc1:NumericInput ID="num_PriceTo" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    Показати на Прайсі:
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:CheckBox ID="chk_DisplayOnPrice" runat="server" Text="" />
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    Опис:
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <uc1:EditorHTML ID="editor_CategoryContent" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    Опис (рос.):
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <uc1:EditorHTML ID="editor_CategoryContent_ru" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    Опис (анг.):
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <uc1:EditorHTML ID="editor_CategoryContent_en" runat="server" />
                </td>
            </tr>
            <tr>
                    <td align="right" colspan="2">
                        &nbsp;
                        <asp:ImageButton ID="btnUpdate" runat="server" CommandArgument="Update" 
                            commandname="Update" CssClass="b_style" ImageUrl="~/NewImages/Update.gif" />
                        &nbsp;
                        <asp:ImageButton ID="btnCancel" runat="server" causesvalidation="False" 
                            commandname="Cancel" CssClass="b_style" ImageUrl="~/NewImages/Cancel.gif" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
            </tr>
    </table>
</asp:Panel>
<asp:Panel ID="pnlGalleryList" runat="server" Visible="false">
    <uc1:GalleryList id="GalleryList" runat="server"></uc1:GalleryList>
</asp:Panel>
<asp:Panel ID="pnlMerchandiseList" runat="server" Visible="false">
    <uc1:MerchandiseList id="merchandiseList" runat="server"></uc1:MerchandiseList>
</asp:Panel>