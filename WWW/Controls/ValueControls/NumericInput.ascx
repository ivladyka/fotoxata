<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NumericInput.ascx.cs" Inherits="Controls_ValueControls_NumericInput" %>
<%@ Register TagPrefix="radi" Namespace="Telerik.WebControls" Assembly="RadInput.Net2" %>
<radi:RadNumericTextBox Skin="Telerik"  BorderColor="#eaeaea"   BackColor="#fbfbfb"
    ID="numInput" runat="server" Culture="Ukrainian (Ukraine)">
<NumberFormat AllowRounding="True"></NumberFormat>
</radi:RadNumericTextBox>