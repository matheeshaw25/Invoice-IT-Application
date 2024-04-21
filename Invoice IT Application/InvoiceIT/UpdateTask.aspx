<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateTask.aspx.cs" Inherits="InvoiceIT.UpdateTask" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Task Details</title>
    <link rel="stylesheet" href="Style.css" />
</head>
<body>
    <div id="frmcont" runat="server"> <!-- wrapped up entire form in div | did so the whole form can dissapear after the update procedure takes place-->
    <div id="updatecrsheader" runat="server"></div>
    <form id="UpdateTask" runat="server">
        <asp:HiddenField ID="CtrlTaskID" runat="server" Value=""></asp:HiddenField> 

         <div class="frm_row_cont">
            <asp:Label ID="LblTaskTitle" runat="server" class="frmlabel" Text="Task Title*"></asp:Label><br />
            <asp:TextBox ID="CtrlTaskTitle" class="tbinput" runat="server" ReadOnly="true"></asp:TextBox> <!-- readonly is true because the user cannot change the course name -->
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblTaskDesc" runat="server" class="frmlabel" Text="Task Description*"></asp:Label><br />
            <asp:TextBox ID="CtrlTaskDesc" runat="server" class="tbinput" TextMode="MultiLine" Height="100px"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="revTaskDesc"
                ControlToValidate="CtrlTaskDesc"
                Display="Static"
                runat="server"
                ErrorMessage="A task description is required"></asp:RequiredFieldValidator>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblTaskRate" runat="server" class="frmlabel" Text="Task Rate*"></asp:Label><br />
            <asp:TextBox ID="CtrlTaskRate" runat="server" class="tbinput" TextMode="MultiLine" Height="100px"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="rfcraskRate"
                ControlToValidate="CtrlTaskRate"
                Display="Static"
                runat="server"
                ErrorMessage="A task rate is required"></asp:RequiredFieldValidator>
        </div>

        <div>
            <asp:Button ID="BtnUpdateTaskDetails" runat="server" class="button" Text="Update Task Details" Onclick="BtnUpdateTaskDetails_Click" />
        </div>


    </form>
    </div>
</body>
</html>
