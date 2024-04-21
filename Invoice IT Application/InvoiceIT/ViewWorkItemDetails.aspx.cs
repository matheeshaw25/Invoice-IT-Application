using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class ViewWorkItemDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int WorkItem_ID)) // gets workitemid as an int
            {
                WorkItem workitem = new WorkItem(); //creates new work item object
                _ = new List<string>(9); // contains 9 data that needs to be output
                List<string> WorkItemData = workitem.GetWorkItem(WorkItem_ID);
                bool isEmpty = AppUtilities.IsEmpty(WorkItemData);// checks if list is empty

                if (isEmpty) // true means empty
                {
                    Response.Write("There was an unexpected error -  no work item details were found");
                }
                else
                {
                    Response.Write("WorkItem ID: " + WorkItemData[0] + "<br/>"); // 1 - workitem id is displayed
                    Response.Write("Client ID: " + WorkItemData[1] + "<br/>"); // 2 - client id is displayed
                    Response.Write("Task ID: " + WorkItemData[2] + "</br/>"); // 3- task id is displayed
                    Response.Write("Staff ID: " + WorkItemData[3] + "</br/>"); //4- staff id is displayed
                    Response.Write("Date: " + WorkItemData[4] + "<br/>");
                    Response.Write("Start Time: " + WorkItemData[5] + "<br/>");
                    Response.Write("End Time: " + WorkItemData[6] + "</br/>");
                    Response.Write("Comment: " + WorkItemData[7] + "</br/>");
                    Response.Write("Status: " + WorkItemData[8] + "</br/>");
                    Response.Write("<br/>");
                    Response.Write("<a href = 'UpdateWorkItem.aspx?ID=" + WorkItemData[0] + "'>Update Work Item Details</a>"); //link to update specific work item
                }


            }
            else
            {
                Response.Write("No ID in URL or couldn't parse to an int");
            }
        }
    }
}