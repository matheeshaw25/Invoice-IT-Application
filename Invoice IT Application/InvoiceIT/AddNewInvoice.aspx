<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewInvoice.aspx.cs" Inherits="InvoiceIT.AddNewInvoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add New Invoice</title>
    <link rel="stylesheet" href="Style.css" />
</head>
<body>
    <h2> Add a New Invoice</h2>
    <form id="AddNewInvoice" runat="server">
        <div class="frm_row_cont">
            <asp:Literal ID="ClientListPH" runat="server"></asp:Literal>
        </div>

       <div class="frm_row_cont">
            <asp:Label ID="LblInvoiceSdate" runat="server" class="frmlabel" Text="Invoice Start Date*"></asp:Label><br />
            <asp:TextBox ID="CtrlInvoiceSdate" class="tbinput" runat="server" TextMode="Date"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvInvoiceSdate" 
                ControlToValidate="CtrlInvoiceSdate"
                Display="Static"
                runat="server" 
                ErrorMessage="An Invoice Start Date is required"> </asp:RequiredFieldValidator>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblInvoiceEdate" runat="server" class="frmlabel" Text="Invoice End Date*"></asp:Label><br />
            <asp:TextBox ID="CtrlInvoiceEdate" class="tbinput" runat="server" TextMode="Date"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvInvoiceEdate" 
                ControlToValidate="CtrlInvoiceEdate"
                Display="Static"
                runat="server" 
                ErrorMessage="An Invoice End Date is required"> </asp:RequiredFieldValidator>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblInvoiceGdate" runat="server" class="frmlabel" Text="Invoice Generated Date*"></asp:Label><br />
            <asp:TextBox ID="CtrlInvoiceGdate" class="tbinput" runat="server" TextMode="Date"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvInvoiceGdate" 
                ControlToValidate="CtrlInvoiceGdate"
                Display="Static"
                runat="server" 
                ErrorMessage="An Invoice Generated Date is required"> </asp:RequiredFieldValidator>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblInvoiceSentdate" runat="server" class="frmlabel" Text="Invoice Sent Date*"></asp:Label><br />
            <asp:TextBox ID="CtrlInvoiceSentdate" class="tbinput" runat="server" TextMode="Date"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvInvoiceSentdate" 
                ControlToValidate="CtrlInvoiceSentdate"
                Display="Static"
                runat="server" 
                ErrorMessage="An Invoice Sent Date is required"> </asp:RequiredFieldValidator>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblInvoiceDdate" runat="server" class="frmlabel" Text="Invoice Date Payment*"></asp:Label><br />
            <asp:TextBox ID="CtrlInvoiceDdate" class="tbinput" runat="server" TextMode="Date"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvInvoiceDdate" 
                ControlToValidate="CtrlInvoiceDdate"
                Display="Static"
                runat="server" 
                ErrorMessage="An Invoice Date Payment is required"> </asp:RequiredFieldValidator>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblInvStatus" runat="server" class="frmlabel" Text="Invoice Status*"></asp:Label><br />
            <asp:DropDownList ID="CtrlInvStatus" class="tbinput" runat="server">
                <asp:ListItem>Generated </asp:ListItem>
                <asp:ListItem>Sent </asp:ListItem>
                <asp:ListItem>Overdue </asp:ListItem>
                <asp:ListItem>Overdue </asp:ListItem>
                <asp:ListItem>Withdrawn </asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="frm_row_cont" >
            <asp:Button ID="BtnAddNewInvoice" runat="server" class="button" Text="Add New Invoice"  OnClick="BtnAddNewInvoice_Click"/>
        </div>

    </form>
</body>
</html>
