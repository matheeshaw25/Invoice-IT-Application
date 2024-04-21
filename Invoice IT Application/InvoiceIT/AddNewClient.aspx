<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewClient.aspx.cs" Inherits="InvoiceIT.AddNewClient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add New Client</title>
    <link rel="stylesheet" href="Style.css" />
</head>
<body>
    <h2> Add a New Client</h2>
    <form id="AddNewClient" runat="server">
        <div class="frm_row_cont">
            <asp:Label ID="LblCompName" runat="server" class="frmlabel" Text="Company Name*"></asp:Label><br />
            <asp:TextBox ID="CtrlCompName" class="tbinput" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvCompName" 
                ControlToValidate="CtrlCompName"
                Display="Static"
                runat="server" 
                ErrorMessage="A company name is required">
            </asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblCompAdd1" runat="server" class="frmlabel" Text="Company Address 1*"></asp:Label><br />
            <asp:TextBox ID="CtrlCompAdd1" class="tbinput" runat="server"  TextMode="MultiLine" Height="100px"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvCompAdd1" 
                ControlToValidate="CtrlCompAdd1"
                Display="Static"
                runat="server" 
                ErrorMessage="A company Address 1 is required">
            </asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblCompAdd2" runat="server" class="frmlabel"  Text="Company Address 2*"></asp:Label><br />
            <asp:TextBox ID="CtrlCompAdd2" class="tbinput" runat="server" TextMode="MultiLine" Height="100px"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvCompAdd2" 
                ControlToValidate="CtrlCompAdd2"
                Display="Static"
                runat="server" 
                ErrorMessage="A company Address 2 is required">
            </asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblCompLoc" runat="server" class="frmlabel" Text="Company Location*"></asp:Label><br />
            <asp:TextBox ID="CtrlCompLoc" class="tbinput" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvCompLoc" 
                ControlToValidate="CtrlCompLoc"
                Display="Static"
                runat="server" 
                ErrorMessage="A company location is required">
            </asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblCompCode" runat="server" class="frmlabel" Text="Company Code*"></asp:Label><br />
            <asp:TextBox ID="CtrlCompCode" class="tbinput" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvCompCode" 
                ControlToValidate="CtrlCompCode"
                Display="Static"
                runat="server" 
                ErrorMessage="A company code is required">
            </asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblContactFname" runat="server" class="frmlabel" Text="Contact First Name*"></asp:Label><br />
            <asp:TextBox ID="CtrlContactFname" class="tbinput" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvContactFname" 
                ControlToValidate="CtrlContactFname"
                Display="Static"
                runat="server" 
                ErrorMessage="A contact first name is required">
            </asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblContactLname" runat="server" class="frmlabel" Text="Contact Last Name*"></asp:Label><br />
            <asp:TextBox ID="CtrlContactLname" class="tbinput" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvContactLname" 
                ControlToValidate="CtrlContactLname"
                Display="Static"
                runat="server" 
                ErrorMessage="A contact last name is required">
            </asp:RequiredFieldValidator> 
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblContactEmail" runat="server" class="frmlabel" Text="Contact Email*"></asp:Label><br />
            <asp:TextBox ID="CtrlContactEmail" class="tbinput" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvContactEmail" 
                ControlToValidate="CtrlContactEmail"
                Display="Static"
                runat="server" 
                ErrorMessage="A contact email is required">
            </asp:RequiredFieldValidator> 
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblContactMobile" runat="server" class="frmlabel" Text="Contact Mobile*"></asp:Label><br />
            <asp:TextBox ID="CtrlContactMobile" class="tbinput" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvContactMobile" 
                ControlToValidate="CtrlContactMobile"
                Display="Static"
                runat="server" 
                ErrorMessage="A contact mobile number is required">
            </asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblBillTo" runat="server" class="frmlabel"  Text="Bill To*"></asp:Label><br />
            <asp:TextBox ID="CtrlBillTo" class="tbinput" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvBillTo" 
                ControlToValidate="CtrlBillTo"
                Display="Static"
                runat="server" 
                ErrorMessage="A bill to is required">
            </asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblStatus" runat="server" class="frmlabel" Text="Status*"></asp:Label> <br />
            <asp:DropDownList ID="CtrlStatus" class="tbinput" runat="server">
                <asp:ListItem>Good </asp:ListItem>
                <asp:ListItem>In Arrears </asp:ListItem>
                <asp:ListItem>Discontinued </asp:ListItem>
            </asp:DropDownList>
        </div>
       

        <div class="frm_row_cont" >
            <asp:Button ID="BtnAddNewClient" runat="server" class="button" Text="Add New Client"  OnClick="BtnAddNewClient_Click"/>
        </div>
        
    </form>
</body>
</html>
