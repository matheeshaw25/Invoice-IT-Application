<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="InvoiceIT.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Login</title>
    <link rel="stylesheet" href="Style.css" />
</head>
<body>
    <hr />
   <h3>LOGIN PAGE</h3>
    <hr />
   <form id="StaffLogin" runat="server">

        <div class="frm_row_cont">
            <asp:Label ID="LblStaffEmail" runat="server" Text="Email Address"></asp:Label><br />
            <asp:TextBox ID="CtrlStaffEmail" class="tbinput" runat ="server"></asp:TextBox>
            <asp:RequiredFieldValidator
               ControlToValidate="CtrlStaffEmail"
               Display="Static"
               ErrorMessage="An email address is required."
               ID="rfvCtrlStaffEmail"
               RunAt="Server" />
            <asp:RegularExpressionValidator  
                ControlToValidate="CtrlStaffEmail"
                ErrorMessage="Invalid email address. Please try again."
                ID="revCtrlStaffEmail"
                ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"
                runat="server" />
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblStaffPassword" runat="server" Text="Password"></asp:Label><br />
            <asp:TextBox ID="CtrlStaffPassword" class="tbinput" runat="server" TextMode="Password" ></asp:TextBox>
            <asp:RequiredFieldValidator
               ControlToValidate="CtrlStaffPassword"
               Display="Static"
               ErrorMessage="A password is required."
               ID="rfvCtrlStaffPassword"
               RunAt="Server" />
        </div>

        <div class="frm_row_cont">
            <asp:Button ID="BtnLogin" runat="server" class="button" Text="Login" OnClick="BtnLogin_Click" />
        </div>

    </form>
</body>
</html>
