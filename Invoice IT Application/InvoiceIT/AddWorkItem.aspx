<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddWorkItem.aspx.cs" Inherits="InvoiceIT.AddWorkItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add a Work Item</title>
    <link rel="stylesheet" href="Style.css" />
</head>
<body>
    <h2> Add a New Work Item</h2>
    <form id="AddNewWorkItem" runat="server">

       <div class="frm_row_cont">
            <asp:Label ID="LblClientID" runat="server" class="frmlabel" Text="Client ID*"></asp:Label><br />
            <asp:TextBox ID="CtrlClientID" class="tbinput" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvClientID" 
                ControlToValidate="CtrlClientID"
                Display="Static"
                runat="server" 
                ErrorMessage="A Client ID is required">
            </asp:RequiredFieldValidator>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblTaskID" runat="server" class="frmlabel" Text="Task ID*"></asp:Label><br />
            <asp:TextBox ID="CtrlTaskID" class="tbinput" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvTaskID" 
                ControlToValidate="CtrlTaskID"
                Display="Static"
                runat="server" 
                ErrorMessage="A Task ID is required">
            </asp:RequiredFieldValidator>
        </div>

         <div class="frm_row_cont">
            <asp:Label ID="LblStaffID" runat="server" class="frmlabel" Text="Staff ID*"></asp:Label><br />
            <asp:TextBox ID="CtrlStaffID" class="tbinput" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvStaffID" 
                ControlToValidate="CtrlStaffID"
                Display="Static"
                runat="server" 
                ErrorMessage="A Staff ID is required">
            </asp:RequiredFieldValidator>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblDate" runat="server" class="frmlabel" Text="Date*"></asp:Label><br />
            <asp:TextBox ID="CtrlDate" class="tbinput" runat="server" TextMode="Date"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvDate" 
                ControlToValidate="CtrlDate"
                Display="Static"
                runat="server" 
                ErrorMessage="A Date is required">
            </asp:RequiredFieldValidator>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblItemStime" runat="server" class="frmlabel" Text="Start Time*"></asp:Label><br />
            <asp:TextBox ID="CtrlItemStime" class="tbinput" runat="server" TextMode="Time"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvItemStime" 
                ControlToValidate="CtrlItemStime"
                Display="Static"
                runat="server" 
                ErrorMessage="A Start Time is required">
            </asp:RequiredFieldValidator>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblItemEtime" runat="server" class="frmlabel" Text="End Time*"></asp:Label><br />
            <asp:TextBox ID="CtrlItemEtime" class="tbinput" runat="server" TextMode="Time"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvItemEtime" 
                ControlToValidate="CtrlItemEtime"
                Display="Static"
                runat="server" 
                ErrorMessage="A End Time is required">
            </asp:RequiredFieldValidator>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblComment" runat="server" class="frmlabel" Text="Comment*"></asp:Label><br />
            <asp:TextBox ID="CtrlComment" class="tbinput" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvComment" 
                ControlToValidate="CtrlComment"
                Display="Static"
                runat="server" 
                ErrorMessage="A Comment is required">
            </asp:RequiredFieldValidator>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblItemStatus" runat="server" class="frmlabel" Text="Status*"></asp:Label> <br />
            <asp:DropDownList ID="CtrlStatus" class="tbinput" runat="server">
                <asp:ListItem>Paused </asp:ListItem>
                <asp:ListItem>Ongoing </asp:ListItem>
                <asp:ListItem>Completed </asp:ListItem>
                <asp:ListItem>Discontinued </asp:ListItem>
            </asp:DropDownList>
        </div>

         <div class="frm_row_cont" >
            <asp:Button ID="BtnAddNewWorkItem" runat="server" class="button" Text="Add New Work Item"  OnClick="BtnAddNewWorkItem_Click"/>
        </div>
    </form>
</body>
</html>
