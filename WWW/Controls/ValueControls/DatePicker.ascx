<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DatePicker.ascx.cs" Inherits="Control_DatePicker" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
    <telerik:RadDatePicker id="dateInput" Runat="server" MaxDate="3000-01-01" 
    MinDate="1900-01-01" Skin="Default">
                    <DateInput Width="90px" Skin="Default"></DateInput>
                    <Calendar FocusedDate="1000-01-01"></Calendar>
  </telerik:RadDatePicker>
  <asp:RequiredFieldValidator ID="rfvDateInput" runat="server" ErrorMessage="Обов'язкове поле." ControlToValidate="dateInput" Display="Dynamic" Enabled="false"></asp:RequiredFieldValidator>
