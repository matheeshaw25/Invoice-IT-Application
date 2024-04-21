<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateWorkItem.aspx.cs" Inherits="InvoiceIT.UpdateWorkItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Work Item Details</title>
    <link rel="stylesheet" href="Style.css" />
</head>
<body>
    <div id="frmcont" runat="server"> <!-- wrapped up entire form in div | did so the whole form can dissapear after the update procedure takes place-->
    <div id="updatecrsheader" runat="server"></div>
    <form id="UpdateWorkItem" runat="server">
        <asp:HiddenField ID="CtrlWorkItemID" runat="server" Value=""></asp:HiddenField> 

        <div class="frm_row_cont">
            <asp:Label ID="LblClientID" runat="server" class="frmlabel" Text="Client ID*"></asp:Label><br />
            <asp:TextBox ID="CtrlClientID" runat="server" class="tbinput" ></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="rfvClientID"
                ControlToValidate="CtrlClientID"
                Display="Static"
                runat="server"
                ErrorMessage="A Client ID is required"></asp:RequiredFieldValidator>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblTaskID" runat="server" class="frmlabel" Text="Task ID*"></asp:Label><br />
            <asp:TextBox ID="CtrlTaskID" runat="server" class="tbinput" ></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="rfvTaskID"
                ControlToValidate="CtrlTaskID"
                Display="Static"
                runat="server"
                ErrorMessage="A Task ID is required"></asp:RequiredFieldValidator>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblStaffID" runat="server" class="frmlabel" Text="Staff ID*"></asp:Label><br />
            <asp:TextBox ID="CtrlStaffID" runat="server" class="tbinput" ></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="rfvStaffID"
                ControlToValidate="CtrlStaffID"
                Display="Static"
                runat="server"
                ErrorMessage="A Staff ID is required"></asp:RequiredFieldValidator>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblDate" runat="server" class="frmlabel" Text="Date*"></asp:Label><br />
            <asp:TextBox ID="CtrlDate" runat="server" class="tbinput" ></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="rfvDate"
                ControlToValidate="CtrlDate"
                Display="Static"
                runat="server"
                ErrorMessage="A Date is required"></asp:RequiredFieldValidator>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblItemStime" runat="server" class="frmlabel" Text="Start Time*"></asp:Label><br />
            <asp:TextBox ID="CtrlItemStime" runat="server" class="tbinput" ></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="rfvItemStime"
                ControlToValidate="CtrlItemStime"
                Display="Static"
                runat="server"
                ErrorMessage="A Start Time is required"></asp:RequiredFieldValidator>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblItemEtime" runat="server" class="frmlabel" Text="End Time*"></asp:Label><br />
            <asp:TextBox ID="CtrlItemEtime" runat="server" class="tbinput" ></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="rfvItemEtime"
                ControlToValidate="CtrlItemEtime"
                Display="Static"
                runat="server"
                ErrorMessage="An End Time is required"></asp:RequiredFieldValidator>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblComment" runat="server" class="frmlabel" Text="Comment*"></asp:Label><br />
            <asp:TextBox ID="CtrlComment" runat="server" class="tbinput" ></asp:TextBox>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblWorkItemStatus" runat="server" class="frmlabel" Text="Status*"></asp:Label> <br />
            <asp:Literal ID="WorkItemStatusPH" runat="server"></asp:Literal>
        </div>

        <div class="frm_row_cont">
            <asp:Button ID="BtnUpdateWorkItemDetails" runat="server" class="button" Text="Update Work Item Details" Onclick="BtnUpdateWorkItemDetails_Click" />
        </div>

    </form>
    </div>
</body>
</html>
