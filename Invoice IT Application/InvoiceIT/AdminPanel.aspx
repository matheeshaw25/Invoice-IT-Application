<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="InvoiceIT.AdminPanel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>WELCOME TO THE ADMIN PANEL</h1>
    <hr />
    <h3><i>1.CLIENT</i></h3>
    <p> <a href ="AddNewClient.aspx">Add a New Client</a></p>
    <p> <a href ="ViewClientList.aspx">View Full Client List</a></p>

    <h3><i>2.TASK</i></h3>
    <p> <a href ="AddNewTask.aspx">Add a new Task</a></p>
     <p> <a href ="ViewTaskList.aspx">View Full Task List</a></p>

    <h3><i>3.WORK ITEM</i></h3>
    <p> <a href ="AddWorkItem.aspx">Add a new Work Item</a></p>
     <p> <a href ="ViewWorkItemList.aspx">View Full  Work Item List</a></p>

    <h3><i>4.STAFF</i></h3>
    <p> <a href ="AddNewStaff.aspx">Add a new Staff Member</a></p>
     <p> <a href ="ViewStaffList.aspx">View Full Staff Member  List</a></p>

    <h3><i>5.INVOICE</i></h3>
    <p> <a href ="AddNewInvoice.aspx">Add a new Invoice</a></p>
     <p> <a href ="ViewInvoiceList.aspx">View Full Invoice List</a></p>

    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
