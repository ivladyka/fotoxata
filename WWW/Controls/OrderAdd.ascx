<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OrderAdd.ascx.cs" Inherits="OrderAdd" %>
<%@ Register TagPrefix="uc1" TagName="CategoryView" Src="CategoryView.ascx" %>
<%@ Register TagPrefix="uc1" TagName="DeliveryChoice" Src="ChoiceControls/DeliveryChoice.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PhotoFormatChoice" Src="ChoiceControls/PhotoFormatChoice.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PaperTypeChoice" Src="ChoiceControls/PaperTypeChoice.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PriceList" Src="PriceList.ascx" %>
<%@ Register TagPrefix="uc1" TagName="GaleryWindowControl" Src="GaleryWindowControl.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="radg" Namespace="Telerik.WebControls" Assembly="RadGrid.Net2" %>
<%@ Register TagPrefix="radi" Namespace="Telerik.WebControls" Assembly="RadInput.Net2" %>
<style type="text/css">
.GridEditRow_Black td input {
background:White none repeat scroll 0 0 !important;
color: #a1a1a1 !important;
}

.ComboBox_Default input
{
	background:White none repeat scroll 0 0 !important;
    color: #a1a1a1 !important;
}
.RadUpload_Black input.ruFakeInput
{

    color: #a1a1a1;
    background-color: White;
    background-image: none;
}

.VIKKI_GridCheckbox input
{
	background:White;
	background-color:#eaeaea
}
</style>
<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
<script language="javascript">
    var VIKKI_AddPhotoClick = false;
    var dgdOrderPhoto;

    function VIKKI_CheckUploadedFiles(CheckCellPhone) {
        var ul = $find("<%= auFile.ClientID %>");
        if (CheckCellPhone) {
            if (dgdOrderPhoto.MasterTableView.Rows != null && dgdOrderPhoto.MasterTableView.Rows.length == 0 && ul._uploadedFiles.length == 0) {
                alert("<%=AtFirstUploadPhoto%>");
                return false;
            }
            var text_CellPhone = document.getElementById('<%= text_CellPhone.ClientID %>');
            VIKKI_TrimString(text_CellPhone.value)
            if (VIKKI_TrimString(text_CellPhone.value) == '') {
                alert("<%=MobilePhoneRequire%>");
                return false;
            }
        }
        else {
            if (ul._uploadedFiles.length == 0) {
                alert("<%=AtFirstUploadPhoto%>");
                return false;
            }
        }
        var inputs = ul.getInvalidFiles();
        for (i = inputs.length - 1; i >= 0; i--) {
            if (!ul.isExtensionValid(inputs[i])) {
                alert("<%=ImageFormatAlert%>");
                return false;
            }
        }
        if (ul.get_element().innerHTML.indexOf('ruUploadFailure') != -1 || ul.get_element().innerHTML.indexOf('ruUploadCancelled') != -1) {
            alert("<%=MaxImageSizeAlert%>");
            return false;
        }
        if ($("ul.ruInputs li span.ruUploadProgress:not(.ruUploadSuccess)").length > 0) {
            alert("<%=WaitCompleteUploadingAlert%>");
            return false;
        }
        if (!CheckCellPhone) {
            VIKKI_AddPhotoClick = true;
        }
        return true;
    }
        
        function GetOrderPhotoGridObject() {
			dgdOrderPhoto = this;
			VIKKI_HideGridColumn(document.getElementById(dgdOrderPhoto.MasterTableView.ClientID), 6, true);
		}

        function dgdOrderPhotoRequestEnd() {
            if (VIKKI_AddPhotoClick) {
                var upload = $find("<%= auFile.ClientID %>");
                var inputs = upload._uploadedFiles;
                for (var i = inputs.length - 1; i >= 0; i--) {
                    upload.deleteFileInputAt(i);
                }
                VIKKI_AddPhotoClick = false;
            }
        }

        function VIKKI_OrderPhotoCheckAllCheckboxes(e) {
            var chkDeleteAllControl = VIKKI_GetCurrentElementOrTarget(e);
            var checkBoxes = document.forms[0].elements;
            for (var i = 0; i < checkBoxes.length; i++) {
                if (checkBoxes[i].type == 'checkbox' && checkBoxes[i].id.indexOf("chkDeleteRow") >= 0) {
                    checkBoxes[i].checked = chkDeleteAllControl.checked;
                }
            }
        }

        function VIKKI_CalculateTotalAmounts() {
            var OrderPhotoObject = window["<%= rgdOrderPhoto.ClientID %>"];
            var VIKKI_Elements = OrderPhotoObject.MasterTableView.Control.all;
            var inputs = OrderPhotoObject.MasterTableView.Control.getElementsByTagName("input");
            var VIKKI_CountPhotos = 0;
            var VIKKI_TotalAmount = 0;
            var lastCountPhotos = 1;
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == 'text' && inputs[i].id.indexOf("numTextBox_Value") >= 0) {
                    lastCountPhotos = parseInt(inputs[i].value);
                    VIKKI_CountPhotos += lastCountPhotos;
                }
                if (inputs[i].type == 'text' && inputs[i].id.indexOf("MerchandiseID_Input") >= 0) {
                    //Calculate Amount
                    VIKKI_TotalAmount += lastCountPhotos * VIKKI_GetPriceByFormat(inputs[i].value);
                    lastCountPhotos = 1;
                }
            }
            if (OrderPhotoObject.MasterTableView.Control.rows.length > 3) {
                var VIKKI_footerRow = VIKKI_GetFooterRow(OrderPhotoObject.MasterTableView.Control);
                VIKKI_footerRow.cells[2].innerHTML = VIKKI_CountPhotos;
                var numTotalAmount = new Number(VIKKI_TotalAmount);
                VIKKI_footerRow.cells[5].innerHTML = numTotalAmount.toFixed(2).replace('.', ',') + " " + "<%=Grn%>";
            }
        }

        function VIKKI_GetPriceByFormat(format) {
            var PriceGrid = $find("<%= priceList.GridClientID %>");
            for (var i = 0; i < PriceGrid.get_masterTableView().get_element().rows.length; i++) {
                if (PriceGrid.get_masterTableView().get_element().rows[i].cells[0].innerHTML == format) {
                    var price = parseFloat(PriceGrid.get_masterTableView().get_element().rows[i].cells[1].innerHTML.replace(',', '.'));
                    if (!isNaN(price)) {
                        return price;
                    }
                }
            }
            return 0;
        }

        function VIKKI_GetFooterRow(OrderPhotoTable) {
            for (var i = 0; i < OrderPhotoTable.rows.length; i++) {
                if (OrderPhotoTable.rows[i].cells.length >= 2) {
                    if (OrderPhotoTable.rows[i].cells[1].innerHTML.indexOf("<%=Total%>") >= 0) {
                        return OrderPhotoTable.rows[i];
                    }
                }
            }
            return OrderPhotoTable.rows[OrderPhotoTable.rows.length - 1];
        }

    $(document).ready(function () {
        if ("<%=IsPostBack%>" == "False") {
            VIKKI_SetCookie('FOTOXATA_CURR_OrderGuid', '<%=NewGuidID%>');
        }
    });

    function VIKKI_OnClientFileUploadRemoving(sender, args)
    {
        if (args.get_row().id.indexOf('auFilerow') > 0)
        {
            VIKKI_SetInputValue('<%= hdClientPhotoNameRemove.ClientID %>', args.get_fileName());
            VIKKI_ClickButtonByClientID('<%= btnRemovePhoto.ClientID %>');
        }
    }

    function VIKKI_OnClientFileUploadFailed(sender, args)
    {
        //$("#divUploadError").text($("#divUploadError").text() + "<br>" + args.get_loadedModuleName() + " : " + args.get_message());
        args.set_handled(true);
    }

    Telerik.Web.UI.RadAsyncUpload.prototype._cancelUpload = function (row) {
        $("#" + row.id + " .ruFileWrap .ruUploadProgress").addClass("ruUploadCancelled");
        $("#" + row.id + " [name='RowRemove']").addClass("ruRemove");
        $("#" + row.id + " [name='RowRemove']").removeClass("ruCancel");
        $("#" + row.id + " [name='RowRemove']").val("Видалити");
    }

    /*Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

    function EndRequestHandler(sender, args) {
        if (args.get_error() != undefined) {
            var objError = args.get_error();
            args.set_errorHandled(true);
            alert(objError.message);
            //showMessage({ messageType: 'error', message: objError.message });
        }
    }

    if (!document.all) {
        alert('hi2');
        window.onbeforeunload = function () {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(VIKKI_endRequest);
        }
    }

    function VIKKI_endRequest(sender, e) {
        alert('hi');
        err = e.get_error();
        if (err) {
            if (err.name == "Sys.WebForms.PageRequestManagerServerErrorException") {
                e.set_errorHandled(true);
            }
        }
    }*/
</script>
</telerik:RadCodeBlock>
<div class="dottedtop" style="margin-top: 10px; min-height:400px;">
<telerik:RadAjaxPanel id="rapImageView" runat="server" EnableAJAX="True" 
    LoadingPanelID="ralpOrderPhoto" ClientEvents-OnResponseEnd="dgdOrderPhotoRequestEnd" 
                BorderColor="#a1a1a1">
<TABLE id="Table3" cellSpacing="0" cellPadding="0"  align="center" border="0" >
    <tr>
        <td colspan="2">
        <br />
            <uc1:CategoryView id="categoryView" runat="server"></uc1:CategoryView>
        </td>
    </tr>
    <tr >
        <td colspan="2" >
        <table border="0" cellpadding="5" cellspacing="5" style= "margin-bottom:20px; ">
        <tr>
        <td colspan="2" class="pageName" style="font-size: 14pt; "> 
            <asp:Label id="lblForOrderPrint" runat="server" Text="<%$Resources:Fotoxata, ForOrderPrint %>" />
        </td>
        </tr>
        <tr>
		<td align="right"><b><asp:Label id="lblMobilePhone" runat="server" Text="<%$Resources:Fotoxata, MobilePhone%>" />:</b>
		</td>
		<td style=" padding:5px;">
			<asp:textbox id="text_CellPhone" runat="server" CssClass="textBoxStyle" MaxLength="50" ></asp:textbox>
		</td>
    </tr>
    <tr>
        <td align="right"><b><asp:Label id="lblDelivery" runat="server" Text="<%$Resources:Fotoxata, Delivery%>" />:</b></td>
        <td><uc1:DeliveryChoice id="ddlDelivery" runat="server" AddEmptyItem="false" AllowCustomText="false"></uc1:DeliveryChoice></td>
    </tr>
    <tr>
        <td align="right"><b><asp:Label id="lblNote" runat="server" Text="<%$Resources:Fotoxata, Note%>" />:</b></td>
        <td>
            <asp:textbox id="tbClientNote" runat="server" CssClass="textBoxStyle" TextMode="MultiLine" Rows="5"></asp:textbox>
        </td>
    </tr>
        </table>
           
        </td>
    </tr>
    <tr>
        <td colspan="2"  class="pageName" style="font-size: 12pt; border-top:1px solid #d8d8d8; padding-top:20px;">
        <asp:Label id="lblUploatPhoto" runat="server" Text="<%$Resources:Fotoxata, UploatPhoto%>" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <table border="0" cellpadding="2" cellspacing="2">
                <tr>
                    <td>
                        <asp:Panel ID="pnlUploadPhoto" runat="server">
                        <telerik:RadAsyncUpload runat="server" ID="auFile" 
                            AllowedFileExtensions="jpg,bmp,jpeg,png,tiff,tif" Width="300px" Skin="Default" 
                                MultipleFileSelection="Automatic" ForeColor="#d8d8d8" HttpHandlerUrl="~/PhotoUpload.ashx" OnClientFileUploadRemoving="VIKKI_OnClientFileUploadRemoving"
                             OnClientFileUploadFailed="VIKKI_OnClientFileUploadFailed">
                            <Localization Remove="Видалити" Select="Вибрати" Cancel="Відмінити" />
                        </telerik:RadAsyncUpload>
                        </asp:Panel>
                        <asp:Label ID="lblAllowedExtensions" runat="server" Text="<%$Resources:Fotoxata, SelectImages %>"></asp:Label>
                    </td>
                    <td>
                    <table cellSpacing="8" cellPadding="2" border="0">
                     <tr>
                        <td align="right" style="width: 100px;"><asp:Label id="lblNumber" runat="server" Text="<%$Resources:Fotoxata, Number%>" />:</td>
                        <td style="width:100px;">
                            <telerik:RadNumericTextBox ID="rntbCount" runat="server" 
                             MinValue="1" ShowSpinButtons="True" Skin="Sitefinity" 
                            Width="60px">
                            <NumberFormat DecimalDigits="0" DecimalSeparator="!" GroupSeparator="" />
                            </telerik:RadNumericTextBox>
                        </td>
                        <td align="right"><asp:Label id="lblFormat" runat="server" Text="<%$Resources:Fotoxata, Format%>" />:</td>
                        <td>
                            <uc1:PhotoFormatChoice id="photoFormatChoice" runat="server" AddEmptyItem="false" AllowCustomText="false"></uc1:PhotoFormatChoice>
                        </td>
                    </tr>
                    <tr>
                        <td align="right"><asp:Label id="lblBorder" runat="server" Text="<%$Resources:Fotoxata, Border%>" />:</td>
                        <td>
                            <asp:CheckBox ID="chkBorder" runat="server" />
                        </td>
                        <td align="right"><asp:Label id="lblPaper" runat="server" Text="<%$Resources:Fotoxata, Paper%>" />:</td>
                        <td>
                            <uc1:PaperTypeChoice id="paperTypeChoice" runat="server" AddEmptyItem="false" AllowCustomText="false"></uc1:PaperTypeChoice>
                        </td>
                    </tr>
                    </table>
                    </td>
                    <td valign="bottom">
                   <asp:ImageButton ToolTip="<%$Resources:Fotoxata, AddPhoto%>" 
                            onmouseover="VIKKI_PuzzleOnMouseOver(event, 'NewImages/addphoto1.gif' );" 
                            onmouseout="VIKKI_PuzzleOnMouseOver(event, 'NewImages/addphoto.gif');" 
                            ID="btnAddPhoto" runat="server" ValidationGroup="AddPhoto"  
                            style="border: none;" onclick="btnAddPhoto_Click"  />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td colspan="2"><hr  style="border-top-style: solid; border-top-width: 1px; border-top-color: #f0f0f0"/>
        </td>
    </tr>
    <tr>
        <td colspan="2" id="tdAddedPhoto" runat="server" class="pageName" style="font-size: 12pt; padding-bottom: 10px;">
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Panel ID="pnlOrderPhotoList" runat="server" BorderColor="#a1a1a1">
                <radg:radgrid id="rgdOrderPhoto" runat="server" Width="100%" CssClass="RadGrid"
					DataMember="OrderPhoto" AutoGenerateColumns="False" SkinsPath="~/RadControls/Grid/Skins"
					EnableAJAXLoadingTemplate="True" AllowAutomaticUpdates="True" AllowSorting="True" 
                    AllowMultiRowEdit="True" AllowMultiRowSelection="True"
					Skin="Outlook" onitemdatabound="rgdOrderPhoto_ItemDataBound" 
                    oncreatecolumneditor="rgdOrderPhoto_CreateColumnEditor" 
                    BorderColor="White" ForeColor="#a1a1a1">
					<GroupHeaderItemStyle  BorderColor="#a1a1a1"></GroupHeaderItemStyle>
					<MasterTableView EditMode="InPlace" CommandItemDisplay="Top" CssClass="MasterTable">
						<RowIndicatorColumn UniqueName="RowIndicator" Visible="False">
							<HeaderStyle Width="20px" CssClass="GridHeader"></HeaderStyle>
						</RowIndicatorColumn>
						<NoRecordsTemplate>
                            <table width="300px" style="height:35px;" border="0"><tr><td valign="middle" style="border: none 0px #272727"><asp:Label ID="lblNoRecords" runat="server" Text="<%$Resources:Fotoxata, NoRecords%>" /></td></tr>
                            </table>
                        </NoRecordsTemplate>
						<EditFormSettings>
							<EditColumn UniqueName="EditCommandColumn"></EditColumn>
						</EditFormSettings>
						<Columns>
						    <radg:GridTemplateColumn HeaderText="">
						        <HeaderTemplate><asp:CheckBox runat="server" ID="chkDeleteAll" /></HeaderTemplate>
						        <HeaderStyle Width="25px"></HeaderStyle>
						        <ItemTemplate>
						            <asp:CheckBox runat="server" ID="chkDeleteRow" />
						        </ItemTemplate>
						    </radg:GridTemplateColumn>
							<radg:GridBoundColumn HeaderText="<%$Resources:Fotoxata, Photo%>" DataField="ClientPhotoName" UniqueName="ClientPhotoName" ReadOnly="True" FooterText="<%$Resources:Fotoxata, Total%>" >
							    <FooterStyle HorizontalAlign="Right" Font-Bold="true" Font-Size="12pt" />
							    <HeaderStyle HorizontalAlign="Center" /> 
							</radg:GridBoundColumn>
							<radg:GridBoundColumn HeaderText="<%$Resources:Fotoxata, Number%>" DataField="PhotoCount" UniqueName="PhotoCount">
								<HeaderStyle Width="90px" HorizontalAlign="Center"></HeaderStyle>
								<ItemStyle Font-Size="15px" BorderColor="#EAEAEA" />
								<FooterStyle Font-Bold="true" Font-Size="12pt" HorizontalAlign="Center" />
							</radg:GridBoundColumn>
							<radg:GridCheckBoxColumn HeaderText="<%$Resources:Fotoxata, Border%>" DataField="Border" UniqueName="Border">
							    <HeaderStyle Width="80px" HorizontalAlign="Center"></HeaderStyle>
							    <ItemStyle CssClass="VIKKI_GridCheckbox" Font-Size="14px" />
							</radg:GridCheckBoxColumn>
							<radg:GridDropDownColumn HeaderText="<%$Resources:Fotoxata, Format%>" ListDataMember="PhotoFormat"
										DataField="MerchandiseID" ListValueField="MerchandiseID" ListTextField="<%$Resources:Fotoxata, NameField%>" UniqueName="MerchandiseID"
										FooterText="Вартість: &nbsp;">
								<HeaderStyle Width="150px" HorizontalAlign="Center"></HeaderStyle>
								<ItemStyle Font-Size="15px" />
								<FooterStyle Font-Bold="true" ForeColor="White" Font-Size="12pt" HorizontalAlign="Right" />
							</radg:GridDropDownColumn>
							<radg:GridDropDownColumn HeaderText="<%$Resources:Fotoxata, Paper%>" ListDataMember="PaperType"
										DataField="PaperTypeID" ListValueField="PaperTypeID" ListTextField="<%$Resources:Fotoxata, NameField%>" UniqueName="PaperTypeID">
								<HeaderStyle Width="170px" HorizontalAlign="Center"></HeaderStyle>
								<ItemStyle Font-Size="15px" ForeColor="#a1a1a1"/>
								<FooterStyle Font-Bold="true"  Font-Size="12pt" HorizontalAlign="Left" />
							</radg:GridDropDownColumn>
							<radg:GridBoundColumn HeaderText="OrderPhotoID" DataField="OrderPhotoID" ReadOnly="True" UniqueName="OrderPhotoID">
								<HeaderStyle></HeaderStyle>
							</radg:GridBoundColumn>
						</Columns>
						<CommandItemTemplate>
							<asp:Panel ID="pnlCommandItem" Runat="server" CssClass="CommandItem">
								<table width="100%" border="0">
									<tr height="19">
										<td width="180" onclick="return confirm('<%=DeleteAlert %>');">
											<asp:LinkButton ID="btnDeleteSelected" runat="server" CommandName="DeleteSelected" ToolTip="<%$Resources:Fotoxata, DeleteSelectedRow %>">
													<img border="0" alt="<%=DeleteSelectedRow %>" src="Images/Delete.gif" /><%=DeleteSelectedRow %></asp:LinkButton>
										</td>
										<td>
											
										</td>
										<td align="right">
                                        <asp:LinkButton ID="btnRedindGrid" runat="server" CommandName="RebindGrid" ToolTip="">
                                        </asp:LinkButton>
                                        </td>
									</tr>
								</table>
							</asp:Panel>
						</CommandItemTemplate>
						<ExpandCollapseColumn ButtonType="ImageButton" UniqueName="ExpandColumn" Visible="False">
							<HeaderStyle Width="19px"></HeaderStyle>
						</ExpandCollapseColumn>
					</MasterTableView>
					<SortingSettings SortedAscToolTip="<%$Resources:Fotoxata, SortedASC %>" 
                        SortedDescToolTip="<%$Resources:Fotoxata, SortedDESC %>" SortToolTip="<%$Resources:Fotoxata, Sort %>" />
                    <AJAXLoadingTemplate>
		                <table border="0" width="100%" cellpadding="0" cellpadding="0" height="100%" style="background-color: white;">
			                <tr>
				                <td align="center" valign="middle">
					                <img align="middle" id="imgLoading" runat="server" src="~/Images/LoadingBlack.gif" alt="" />
				                </td>
			                </tr>
		                </table>
	                </AJAXLoadingTemplate>
	                <PagerStyle Height="18px" CssClass="GridPager" Mode="NumericPages"></PagerStyle>
					<HeaderStyle CssClass="GridHeader"></HeaderStyle>
					<SelectedItemStyle CssClass="SelectedRow"></SelectedItemStyle>
					<ItemStyle HorizontalAlign="Center" CssClass="GridRow"></ItemStyle>
					<FooterStyle CssClass="GridPager" HorizontalAlign="Left"></FooterStyle>
					<ClientSettings>
						<ClientEvents OnGridCreated="GetOrderPhotoGridObject"></ClientEvents>
						<Selecting AllowRowSelect="True"></Selecting>
					</ClientSettings>
					<EditItemStyle Height="25px" CssClass="EditedGridRow"></EditItemStyle>
					<AlternatingItemStyle HorizontalAlign="Center" CssClass="GridAltRow"></AlternatingItemStyle>
				</radg:radgrid>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center" style="padding-top: 30px" valign="top">
            <asp:ImageButton ID="btnAddOrder" runat="server"  onclick="btnAddOrder_Click" 
            onmouseover="VIKKI_PuzzleOnMouseOver(event, 'NewImages/Ordering1.gif' );" onmouseout="VIKKI_PuzzleOnMouseOver(event, 'NewImages/Ordering.gif');" ValidationGroup="AddOrder"
            style="border: none;"/>
        </td>
    </tr>
</TABLE>  
</telerik:RadAjaxPanel>  
<div style="margin-top: 0px; width:100%; margin-left:35px;">
    <table cellpadding="0" cellspacing="0" border="0" align="left">
    <tr>
    <td id="tdPriceOnPrint" runat="server" class="pageName" style="font-size: 12pt; margin-left: 10px;"><br />&nbsp;&nbsp;Ціни на друк</td>
    </tr>
    <tr>
        <td >
        <div>
            <uc1:PriceList id="priceList" runat="server"></uc1:PriceList>
            </div>
        </td>
    </tr>
    </table>
    </div>
<uc1:GaleryWindowControl id="galeryWindowControl" runat="server"></uc1:GaleryWindowControl>
<telerik:RadAjaxLoadingPanel ID="ralpOrderPhoto" runat="server" Transparency="50" BackColor="White">
    <div style="width: 100%; height: 100%;">
        <img src="Images/LoadingSunset.gif" style="position:fixed; right: 50%; top: 49%;" />
    </div>
</telerik:RadAjaxLoadingPanel>
<div class="bottomdottedtop" style="margin-top: 40px"></div>
<telerik:RadAjaxPanel id="rapCommands" runat="server" EnableAJAX="True">
    <asp:Button ID="btnRemovePhoto" runat="server" onclick="btnRemovePhoto_Click" CssClass="VIKKI_HiddenButton"></asp:Button>
    <INPUT id="hdClientPhotoNameRemove" type="hidden" name="hdClientPhotoNameRemove" runat="server" value=""/>
</telerik:RadAjaxPanel>
<!--<div id="divUploadError"></div>-->
</div>
