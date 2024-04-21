<%@ Page Language="C#"  EnableEventValidation="false" AutoEventWireup="true" CodeBehind="UpdateStaff.aspx.cs" Inherits="InvoiceIT.UpdateStaff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Staff Details</title>
    <link rel="stylesheet" href="Style.css" />
</head>
<body>
    <div id="frmcont" runat="server">
    <div id="updatestaffheader" runat="server"></div>
    <form id="UpdateStaff" runat="server">
        <asp:HiddenField ID="CtrlStaffID" runat="server" Value=""></asp:HiddenField>

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
            <asp:Label ID="LblStaffAccLvl" runat="server" class="frmlabel" Text="Staff Access Level*"></asp:Label> <br />
            <asp:Literal ID="StaffAccLvlPH" runat="server"></asp:Literal>
              <!--<asp:DropDownList ID="CtrlStaffAccLvl" class="tbinput" runat="server">
                <asp:ListItem>Good </asp:ListItem>
                <asp:ListItem>In Arrears </asp:ListItem>
                <asp:ListItem>Discontinued </asp:ListItem>
            </asp:DropDownList>  -->
        </div>
       


         <div class="frm_row_cont">
            <asp:Label ID="LblStaffStatus" runat="server" class="frmlabel" Text="Staff Status*"></asp:Label> <br />
            <asp:Literal ID="StaffStatusPH" runat="server"></asp:Literal>
              <!--<asp:DropDownList ID="CtrlStaffStatus" class="tbinput" runat="server">
                <asp:ListItem>Good </asp:ListItem>
                <asp:ListItem>In Arrears </asp:ListItem>
                <asp:ListItem>Discontinued </asp:ListItem>
            </asp:DropDownList>  -->
        </div>
         <div class="frm_row_cont">
            <asp:Label ID="LblStaffPassword" runat="server" class="frmlabel" Text=" Password*"></asp:Label><br />
            <asp:TextBox ID="CtrlStaffPassword" class="tbinput" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvStaffPassword" 
                ControlToValidate="CtrlStaffMobile"
                Display="Static"
                runat="server" 
                ErrorMessage="A password is required">
            </asp:RequiredFieldValidator>
        </div>

         <div class="frm_row_cont">
            <asp:Button ID="BtnUpdateStaffDetails" runat="server" class="button" Text="Update Staff Details" Onclick="BtnUpdateStaffDetails_Click" />
        </div>
        
    </form>
        </div>
</body>
</html>
