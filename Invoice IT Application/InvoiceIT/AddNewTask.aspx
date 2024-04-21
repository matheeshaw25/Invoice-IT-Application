<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewTask.aspx.cs" Inherits="InvoiceIT.AddNewTask" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add New Task</title>
    <link rel="stylesheet" href="Style.css" />
</head>
<body>
    <h2> Add a New Task</h2>
    <form id="AddNewTask" runat="server">
        <div class="frm_row_cont">
            <asp:Label ID="LblTaskTitle" runat="server" class="frmlabel" Text="Task Title*"></asp:Label><br />
            <asp:TextBox ID="CtrlTaskTitle" class="tbinput" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvTaskTitle" 
                ControlToValidate="CtrlTaskTitle"
                Display="Static"
                runat="server" 
                ErrorMessage="A Task Title is required">
            </asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblTaskDesc" runat="server" class="frmlabel" Text="Task Description*"></asp:Label><br />
            <asp:TextBox ID="CtrlTaskDesc" class="tbinput" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvTaskDesc" 
                ControlToValidate="CtrlTaskDesc"
                Display="Static"
                runat="server" 
                ErrorMessage="A Task Description is required">
            </asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblTaskRate" runat="server" class="frmlabel" Text="Task Rate*"></asp:Label><br />
            <asp:TextBox ID="CtrlTaskRate" class="tbinput" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvTaskRate" 
                ControlToValidate="CtrlTaskRate"
                Display="Static"
                runat="server" 
                ErrorMessage="A Task Rate is required">
            </asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont" >
            <asp:Button ID="BtnAddNewTask" runat="server" class="button" Text="Add New Task"  OnClick="BtnAddNewTask_Click"/>
        </div>

    </form>
</body>
</html>
