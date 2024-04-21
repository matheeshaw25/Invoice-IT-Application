<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewStaff.aspx.cs" Inherits="InvoiceIT.AddNewStaff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add New Staff</title>
    <link rel="stylesheet" href="Style.css" />
</head>
<body>
    <h2>Add a new staff member</h2>
    <form id="AddNewStaff" runat="server">

        <div class="frm_row_cont">
            <asp:Label ID="LblStaffFname" runat="server" class="frmlabel" Text="Staff First Name*"></asp:Label><br />
            <asp:TextBox ID="CtrlStaffFname" class="tbinput" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvStaffFname" 
                ControlToValidate="CtrlStaffFname"
                Display="Static"
                runat="server" 
                ErrorMessage="A Staff first name is required">
            </asp:RequiredFieldValidator>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblStaffSname" runat="server" class="frmlabel" Text="Staff Surname*"></asp:Label><br />
            <asp:TextBox ID="CtrlStaffSname" class="tbinput" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvStaffLname" 
                ControlToValidate="CtrlStaffSname"
                Display="Static"
                runat="server" 
                ErrorMessage="A Staff Surname is required">
            </asp:RequiredFieldValidator>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblStaffEmail" runat="server" class="frmlabel" Text="Staff Email*"></asp:Label><br />
            <asp:TextBox ID="CtrlStaffEmail" class="tbinput" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvStaffEmail" 
                ControlToValidate="CtrlStaffEmail"
                Display="Static"
                runat="server" 
                ErrorMessage="A Staff email is required">
            </asp:RequiredFieldValidator>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblStaffMobile" runat="server" class="frmlabel" Text="Staff Mobile*"></asp:Label><br />
            <asp:TextBox ID="CtrlStaffMobile" class="tbinput" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvStaffMobile" 
                ControlToValidate="CtrlStaffMobile"
                Display="Static"
                runat="server" 
                ErrorMessage="A Staff Mobile is required">
            </asp:RequiredFieldValidator>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblStaffAccLvl" runat="server" class="frmlabel" Text="Staff Acess Level*"></asp:Label> <br />
            <asp:DropDownList ID="CtrlStaffAccLvl" class="tbinput" runat="server">
                <asp:ListItem>Staff </asp:ListItem>
                <asp:ListItem>Administrator </asp:ListItem>
            </asp:DropDownList>
        </div>
         
        <div class="frm_row_cont">
            <asp:Label ID="LblStaffStatus" runat="server" class="frmlabel" Text="Staff Status*"></asp:Label> <br />
            <asp:DropDownList ID="CtrlStaffStatus" class="tbinput" runat="server">
                <asp:ListItem>Active </asp:ListItem>
                <asp:ListItem>Inactive </asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblStaffPassword" runat="server" class="frmlabel" Text=" Password*"></asp:Label><br />
            <asp:TextBox ID="CtrlStaffPassword" class="tbinput" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvStaffPassword" 
                ControlToValidate="CtrlStaffPassword"
                Display="Static"
                runat="server" 
                ErrorMessage="A  Password is required">
            </asp:RequiredFieldValidator> 
        </div>

        <div class="frm_row_cont" >
            <asp:Button ID="BtnAddNewStaff" runat="server" class="button" Text="Add New Client"  OnClick="BtnAddNewStaff_Click"/>
        </div>

    </form>
</body>
</html>
