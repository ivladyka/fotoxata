<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Schedule.ascx.cs" Inherits="Schedule" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="uc1" TagName="PhotoSalonChoice" Src="ChoiceControls/PhotoSalonChoice.ascx" %>   
<script language="javascript">
    function VIKKI_PopupClosing(sender, eventArgs)
    {
        var popup = eventArgs.get_popupControl();
        alert(popup.getTime());
    }
</script>		                   
<table style="color: #a1a1a1">
    <tr>
        <td>
            <telerik:RadAjaxPanel id="RadAjaxPanel1" runat="server" EnableAJAX="True" 
                LoadingPanelID="RadAjaxLoadingPanel1" >
                <telerik:RadScheduler 
                runat="server" 
                ID="RadScheduler1" 
                Width="1000px"
                Height="1030px"
                SelectedDate="2009-02-02" 
                DayEndTime="21:00:00"                        
                FirstDayOfWeek="Monday" 
                LastDayOfWeek="Sunday"
                OnAppointmentDelete="RadScheduler1_AppointmentDelete"
                OnAppointmentUpdate="RadScheduler1_AppointmentUpdate"
                OnAppointmentInsert="RadScheduler1_AppointmentInsert" 
                Culture="Ukrainian (Ukraine)" 
                ShowAllDayRow="False" 
                onnavigationcomplete="RadScheduler1_NavigationComplete" 
                DayView-GroupingDirection="Horizontal" 
                DayView-DayEndTime="20:00:00" 
                DayView-WorkDayEndTime="20:00:00" 
                MinimumInlineFormHeight="40" 
                TimelineView-SlotDuration="01.00:00:00" 
                TimelineView-TimeLabelSpan="01" 
                RowHeight="20px" 
                HoursPanelTimeFormat="HH:mm" 
                ForeColor="#a1a1a1" 
                Font-Bold="True" 
                MinutesPerRow="15" 
                MonthView-VisibleAppointmentsPerDay="4" StartInsertingInAdvancedForm="True" 
                onformcreated="RadScheduler1_FormCreated" DataEndField="EndTime" 
                DataKeyField="AppointmentID" DataStartField="StartTime" 
                DataSubjectField="Subject" 
                CustomAttributeNames="PhotoSalonID, MoneyAdvance, PhoneNumber, PhotoSalonAddress, AssignedUserName" 
                EnableCustomAttributeEditing="True" 
                onappointmentcommand="RadScheduler1_AppointmentCommand" 
                onappointmentdatabound="RadScheduler1_AppointmentDataBound" 
                 AppointmentStyleMode="Simple">
                <DayView DayEndTime="20:00:00" WorkDayEndTime="20:00:00" UserSelectable="False" />
                <AdvancedForm Modal="true" EnableCustomAttributeEditing="True" />
                <TimelineView UserSelectable="false" />
                <AppointmentTemplate>
                   <div class="rsAptSubject" >
                    <%# Eval("PhotoSalonAddress")%>  <i><%# Eval("Subject") %></i>
                   </div>
                </AppointmentTemplate>
         <TimeSlotContextMenuSettings EnableDefault="true" />
         <AppointmentContextMenuSettings  />

         <MonthView VisibleAppointmentsPerDay="4" />
            <AdvancedEditTemplate>
				<div class="rsAdvancedEdit" style="position: relative; background-color: #FFFFFF; border: 1px solid #eaeaea; padding:0px;">  
                <%-- Title bar. --%> 
                <div style=" width: 100%; height: 30px; vertical-align: middle; " >  
                    <%-- The rsAdvInnerTitle element is used as a drag handle when the form is modal. --%> 
                      
                    <div style="margin-left: 25px; margin-top: 8px;" class="WindowPageName">  Редагувати інформацію</div>
                    <div class="CancelButtonStyle" style="margin-right: 5px; margin-top:5px;">     
                    <asp:imagebutton  ID="Imagebutton1" runat="server" CommandName="Cancel"  CssClass="b_style" CausesValidation="false" ImageUrl="../Cancel.gif" ToolTip='закрити'></asp:imagebutton> 
                    </div>
                  </div> 
                <div class="rsAdvContentWrapper" style=" border-style: none; padding-left:20px; padding-top:10px; ">  
                    <table  border="0" cellpadding="0" cellspacing="4">
                    <tr>
					   <td colspan="2">
					    <table  border="0" cellpadding="0" cellspacing="0"  style="margin:0px; " width="580px">
                    <tr>
					   <td>
							<asp:Label ID="Label2" AssociatedControlID="StartDate" runat="server" CssClass="inline-label" Font-Bold="True">Початок:</asp:Label>
							<telerik:RadDatePicker	runat="server" ID="StartDate" CssClass="rsAdvDatePicker"
										Width="103px" SharedCalendarID="SharedCalendar"
										Culture="Ukrainian (Ukraine)"
										MinDate="1900-01-01" Skin="Simple">
								<DatePopupButton ToolTip="Редагувати дату" ></DatePopupButton>
					            <DateInput ID="DateInput1"
						            runat="server"
						            EmptyMessageStyle-CssClass="radInvalidCss_Default" EmptyMessage=" " BackColor="#FBFBFB" BorderColor="#EAEAEA"/>
				            </telerik:RadDatePicker>
				            <telerik:RadTimePicker
						        runat="server" ID="StartTime" CssClass="rsAdvTimePicker"
						        Width="65px"  Skin="Simple" Culture="Ukrainian (Ukraine)">
						        <TimePopupButton ToolTip="Редагувати час"></TimePopupButton>
					            <DateInput ID="DateInput2" runat="server"
						            EmptyMessageStyle-CssClass="radInvalidCss_Default" EmptyMessage=" " BackColor="#FBFBFB" BorderColor="#EAEAEA"/>
					            <TimeView ID="TimeView1"
						            runat="server"
						            Columns="2" ShowHeader="false"
						            StartTime="08:00" EndTime="22:00" Interval="00:30"  Skin="Simple"/>
				            </telerik:RadTimePicker>
				            <asp:RequiredFieldValidator ID="rfvStartDate" runat="server" ErrorMessage="<br>Обов'язкове поле." ControlToValidate="StartDate" Display="Dynamic"></asp:RequiredFieldValidator>
				            <asp:RequiredFieldValidator ID="rfvStartTime" runat="server" ErrorMessage="<br>Обов'язкове поле." ControlToValidate="StartTime" Display="Dynamic"></asp:RequiredFieldValidator>
					   </td>
					   <td style="padding: 0px">
							<asp:Label ID="Label3" AssociatedControlID="EndDate" runat="server" CssClass="inline-label" Font-Bold="True">Кінець:</asp:Label>
							<telerik:RadDatePicker	runat="server" ID="EndDate" CssClass="rsAdvDatePicker"
										Width="103px" SharedCalendarID="SharedCalendar"
										Culture="Ukrainian (Ukraine)"
										MinDate="1900-01-01" Skin="Simple">
								<DatePopupButton ToolTip="Редагувати дату"></DatePopupButton>
					            <DateInput ID="DateInput3"
						            runat="server"
						            EmptyMessageStyle-CssClass="radInvalidCss_Default" EmptyMessage=" " BackColor="#FBFBFB" BorderColor="#EAEAEA"/>
				            </telerik:RadDatePicker>
				            <telerik:RadTimePicker
						        runat="server" ID="EndTime" CssClass="rsAdvTimePicker"
						        Width="65px"  Skin="Simple" Culture="Ukrainian (Ukraine)">
						        <TimePopupButton ToolTip="Редагувати час"></TimePopupButton>
					            <DateInput ID="DateInput4" runat="server"
						            EmptyMessageStyle-CssClass="radInvalidCss_Default" EmptyMessage=" " BackColor="#FBFBFB" BorderColor="#EAEAEA"/>
					            <TimeView ID="TimeView2"
						            runat="server"
						            Columns="2" ShowHeader="false"
						            StartTime="08:00" EndTime="22:00" Interval="00:30"  Skin="Simple"/>
				            </telerik:RadTimePicker>
				            <asp:RequiredFieldValidator ID="rfvEndDate" runat="server" ErrorMessage="<br>Обов'язкове поле." ControlToValidate="EndDate" Display="Dynamic"></asp:RequiredFieldValidator>
				            <asp:RequiredFieldValidator ID="rfvEndTime" runat="server" ErrorMessage="<br>Обов'язкове поле." ControlToValidate="EndTime" Display="Dynamic"></asp:RequiredFieldValidator>
					   </td>
					  </tr>
					  <tr>
					    <td colspan="2">
					        <asp:CompareValidator ID="cvFromToDate" runat="server" 
                                ErrorMessage="Кінцева дата має бути більша початкової дати." 
                                ControlToCompare="EndDate" ControlToValidate="StartDate" Display="Dynamic" 
                                Operator="LessThanEqual"></asp:CompareValidator>
					    </td>
					  </tr>
					  </table>
					   </td>
					  </tr>
					  <tr>
					    <td><b>Фотосалон:</b>
					    </td>
					    <td>
					        <telerik:RadComboBox ID="ddlPhotoSalon" runat="server" BackColor="#FBFBFB" BorderColor="#EAEAEA" BorderStyle="Solid" BorderWidth="1px" Width="300"></telerik:RadComboBox>
                        </td>
					  </tr> 
					  <tr>
                      <td>
							<b>Інформація:</b>
					  </td>
					  <td>
							<asp:TextBox ID="TitleTextBox" Rows="4" Columns="20" runat="server" Text='<%# Bind("Subject") %>'
								Width="97%" TextMode="MultiLine" BackColor="#FBFBFB" BorderColor="#EAEAEA" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
						    <asp:RequiredFieldValidator ID="rfvSubject" runat="server" ErrorMessage="Обов'язкове поле." ControlToValidate="TitleTextBox" Display="Dynamic"></asp:RequiredFieldValidator>
						    <asp:RegularExpressionValidator ID="revTitleTextBox" runat="server" ErrorMessage="Максимальна довжина цього поля 255 символів." 
                                ControlToValidate="TitleTextBox" ValidationExpression=".{0,255}" Display="Dynamic"></asp:RegularExpressionValidator>
					  </td>
					  </tr>		
					  <tr>
					    <td><b>Аванс, грн.:</b></td>
					    <td>
					        <telerik:RadNumericTextBox ID="rntbMoneyAdvance" runat="server" BackColor="#FBFBFB" BorderColor="#EAEAEA"></telerik:RadNumericTextBox>
					    </td>
					  </tr>		
					  <tr>
					    <td><b>Номер телефону:</b></td>
					    <td>
					        <telerik:RadMaskedTextBox  ID="rmtbPhoneNumber" runat="server" Mask="+38(###) #######" BackColor="#FBFBFB" BorderColor="#EAEAEA"></telerik:RadMaskedTextBox >
					    </td>
					  </tr>	  
					  <tr>
					    <td><b>Додано:</b></td>
					    <td>
					        <asp:Label ID="lbAssigned" runat="server" ></asp:Label>
					    </td>
					  </tr>
					  </table>
                    <asp:Panel runat="server" ID="ButtonsPanel" CssClass="rsAdvancedSubmitArea">  
                        <div class="rsAdvButtonWrapper">  

             <asp:imagebutton ID="UpdateButton" runat="server" CommandArgument="Update"  CssClass="b_style" CommandName="Update" ImageUrl="~/NewImages/Update.gif"></asp:imagebutton>&nbsp;
			<asp:imagebutton  ID="CancelButton" runat="server" CommandName="Cancel"  CssClass="b_style" causesvalidation="False" ImageUrl="~/NewImages/Cancel.gif"></asp:imagebutton> 
                        </div> 
                    </asp:Panel> 
                </div> 
            </div> 
            <telerik:RadCalendar	runat="server" ID="SharedCalendar"	CultureInfo="Ukrainian (Ukraine)"	ShowRowHeaders="false"	RangeMinDate="1900-01-01" Skin="Simple"/>
			</AdvancedEditTemplate>
			<AdvancedInsertTemplate>
				<div class="rsAdvancedEdit"style="position: relative; background-color: #FFFFFF; border: 1px solid #eaeaea; padding:0px;">  
                <%-- Title bar. --%> 
               <div style=" width: 100%; height: 30px; vertical-align: middle; " >  
                    <%-- The rsAdvInnerTitle element is used as a drag handle when the form is modal. --%> 
                      <div style="margin-left: 25px; margin-top: 8px;" class="WindowPageName">  Додати Призначення</div>
                     <div class="CancelButtonStyle" style="margin-right: 5px; margin-top:5px;">     
                    <asp:imagebutton  ID="AdvancedEditCloseButton" runat="server" CommandName="Cancel"  CssClass="b_style" CausesValidation="false" ImageUrl="../Cancel.gif" ToolTip='закрити'></asp:imagebutton> 
                    </div>
                  </div> 

                <div class="rsAdvContentWrapper" style="border-style: none; padding-left:20px; padding-top:10px; ">  
                      <table  border="0" cellpadding="0" cellspacing="4">
                    <tr>
					   <td colspan="2">
					    <table  border="0" cellpadding="0" cellspacing="0"  style="margin:0px; " width="580px">
                    <tr>
					   <td>
							<asp:Label ID="Label2" runat="server" CssClass="inline-label" Font-Bold="True">Початок:</asp:Label>
							<telerik:RadDatePicker runat="server" ID="StartDate" CssClass="rsAdvDatePicker"
										Width="103px" SharedCalendarID="SharedCalendar"
										Culture="Ukrainian (Ukraine)"
										MinDate="1900-01-01" Skin="Simple">
								<DatePopupButton ToolTip="Редагувати дату"></DatePopupButton>
					            <DateInput ID="DateInput1"
						            runat="server"
						            EmptyMessageStyle-CssClass="radInvalidCss_Default" EmptyMessage=" " BackColor="#FBFBFB" BorderColor="#EAEAEA" />
				            </telerik:RadDatePicker>
				            <telerik:RadTimePicker
						        runat="server" ID="StartTime" CssClass="rsAdvTimePicker"
						        Width="65px" Skin="Simple" Culture="Ukrainian (Ukraine)">
						        <TimePopupButton ToolTip="Редагувати час"></TimePopupButton>
					            <DateInput ID="DateInput2" runat="server"
						            EmptyMessageStyle-CssClass="radInvalidCss_Default" EmptyMessage=" "  BackColor="#FBFBFB" BorderColor="#EAEAEA"/>
					            <TimeView ID="TimeView1"
						            runat="server"
						            Columns="2" ShowHeader="false"
						            StartTime="08:00" EndTime="22:00" Interval="00:30" Skin="Simple"/>
				            </telerik:RadTimePicker>
				            <asp:RequiredFieldValidator ID="rfvStartDate" runat="server" ErrorMessage="<br>Обов'язкове поле." ControlToValidate="StartDate" Display="Dynamic"></asp:RequiredFieldValidator>
				            <asp:RequiredFieldValidator ID="rfvStartTime" runat="server" ErrorMessage="<br>Обов'язкове поле." ControlToValidate="StartTime" Display="Dynamic"></asp:RequiredFieldValidator>
					   </td>
					   <td>
							<asp:Label ID="Label3" AssociatedControlID="EndDate" runat="server" CssClass="inline-label" Font-Bold="True">Кінець:</asp:Label>
							<telerik:RadDatePicker	runat="server" ID="EndDate" CssClass="rsAdvDatePicker"
										Width="103px" SharedCalendarID="SharedCalendar"
										Culture="Ukrainian (Ukraine)"
										MinDate="1900-01-01" Skin="Simple">
								
					            <DateInput ID="DateInput3"
						            runat="server"
						            EmptyMessageStyle-CssClass="radInvalidCss_Default" EmptyMessage=" " BackColor="#FBFBFB" BorderColor="#EAEAEA"/>
				            </telerik:RadDatePicker>
				            <telerik:RadTimePicker
						        runat="server" ID="EndTime" CssClass="rsAdvTimePicker"
						        Width="65px" Skin="Simple" Culture="Ukrainian (Ukraine)">
						        <TimePopupButton ToolTip="Редагувати час"></TimePopupButton>
					            <DateInput ID="DateInput4" runat="server"
						            EmptyMessageStyle-CssClass="radInvalidCss_Default" EmptyMessage=" " BackColor="#FBFBFB" BorderColor="#EAEAEA"/>
					            <TimeView ID="TimeView2"
						            runat="server"
						            Columns="2" ShowHeader="false"
						            StartTime="08:00" EndTime="22:00" Interval="00:30" Skin="Simple"/>
				            </telerik:RadTimePicker>
				            <asp:RequiredFieldValidator ID="rfvEndDate" runat="server" ErrorMessage="<br>Обов'язкове поле." ControlToValidate="EndDate" Display="Dynamic"></asp:RequiredFieldValidator>
				            <asp:RequiredFieldValidator ID="rfvEndTime" runat="server" ErrorMessage="<br>Обов'язкове поле." ControlToValidate="EndTime" Display="Dynamic"></asp:RequiredFieldValidator>
					 </td>
					  </tr>
					  <tr>
					    <td colspan="2">
					        <asp:CompareValidator ID="cvFromToDate" runat="server" 
                                ErrorMessage="Кінцева дата має бути більша початкової дати." 
                                ControlToCompare="EndDate" ControlToValidate="StartDate" Display="Dynamic" 
                                Operator="LessThanEqual"></asp:CompareValidator>
					    </td>
					  </tr>
					  </table>
					   </td>
					  </tr>
					  <tr>
					    <td><b>Фотосалон:</b>
					    </td>
					    <td>
					        <telerik:RadComboBox ID="ddlPhotoSalon" runat="server" BackColor="#FBFBFB" BorderColor="#EAEAEA" Width="300" Skin="Default" BorderStyle="Solid" BorderWidth="1"></telerik:RadComboBox>
                        </td>
					  </tr> 
					  <tr>
                      <td>
							<b>Інформація:</b>
					  </td>
					  <td>
							<asp:TextBox ID="TitleTextBox" Rows="4" Columns="20" runat="server" Text='<%# Bind("Subject") %>'
								Width="97%" TextMode="MultiLine"  BackColor="#FBFBFB" BorderColor="#EAEAEA" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
						    <asp:RequiredFieldValidator ID="rfvSubject" runat="server" Display="Dynamic" ErrorMessage="Обов'язкове поле." ControlToValidate="TitleTextBox"></asp:RequiredFieldValidator>
						    <asp:RegularExpressionValidator ID="revTitleTextBox" runat="server" Display="Dynamic" ErrorMessage="Максимальна довжина цього поля 255 символів." 
                                ControlToValidate="TitleTextBox" ValidationExpression=".{0,255}"></asp:RegularExpressionValidator>
					  </td>
					  </tr>
					  <tr>
					    <td><b>Аванс, грн.:</b></td>
					    <td>
					        <telerik:RadNumericTextBox ID="rntbMoneyAdvance" runat="server" BackColor="#FBFBFB" BorderColor="#EAEAEA"></telerik:RadNumericTextBox>
					    </td>
					  </tr>
					  <tr>
					    <td><b>Номер телефону:</b></td>
					    <td>
					        <telerik:RadMaskedTextBox  ID="rmtbPhoneNumber" runat="server" Mask="+38(###) #######" BackColor="#FBFBFB" BorderColor="#EAEAEA"></telerik:RadMaskedTextBox >
					    </td>
					  </tr>
					  </table>
                    <asp:Panel runat="server" ID="ButtonsPanel" CssClass="rsAdvancedSubmitArea">  
                        <div class="rsAdvButtonWrapper">  
             <asp:imagebutton ID="UpdateButton" runat="server" CommandArgument="Update"  CssClass="b_style" CommandName="Insert" ImageUrl="~/NewImages/Update.gif"></asp:imagebutton>&nbsp;
			<asp:imagebutton  ID="CancelButton" runat="server" commandname="Cancel"  CssClass="b_style" causesvalidation="False" ImageUrl="~/NewImages/Cancel.gif"></asp:imagebutton>

                        </div> 
                    </asp:Panel> 
                </div> 
            </div> 
            <telerik:RadCalendar
	runat="server" ID="SharedCalendar"
	CultureInfo="Ukrainian (Ukraine)"
	ShowRowHeaders="false"
	RangeMinDate="1900-01-01" Skin="Simple" />
			</AdvancedInsertTemplate>
         </telerik:RadScheduler>
         </telerik:RadAjaxPanel>
        </td>
    </tr>
</table>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Sunset" />