using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

namespace InvoiceIT
{
    public partial class UpdateWorkItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int WorkItem_ID)) // to get WorkItem_ID output as an int 
            {
                WorkItem workitem = new WorkItem(); //creates a new work item object from the work item class
                _ = new List<string>(9); // contains 9 fileds
                List<string> WrkItemData = workitem.GetWorkItem(WorkItem_ID); 
                bool isEmpty = AppUtilities.IsEmpty(WrkItemData); // checks if empty

                this.updatecrsheader.InnerHtml = "<h3>Update Details for " + WrkItemData[0] + "</h3>";

                if (isEmpty)
                {
                    Response.Write("There was an unexpected error - no task details were returned"); // If TskData list is null or empty, inform user
                }
                else
                {
                    this.CtrlWorkItemID.Value = WrkItemData[0].ToString(); // ToString() was used because it is a form
                    this.CtrlClientID.Text = WrkItemData[1]; 
                    this.CtrlTaskID.Text = WrkItemData[2];
                    this.CtrlStaffID.Text = WrkItemData[3];
                    this.CtrlDate.Text = WrkItemData[4];
                    this.CtrlItemStime.Text = WrkItemData[5]; 
                    this.CtrlItemEtime.Text = WrkItemData[6];
                    this.CtrlComment.Text = WrkItemData[7];

                    string status = WrkItemData[8].Replace(" ", String.Empty);

                    string dlwrkitemstatus; // known as drop list work item status
                    if (status == "Paused") // if course in status is "pasued"
                    {
                        dlwrkitemstatus = "<select class='tbinput' name='CtrlStatus' id='CtrlStatus'>";
                        dlwrkitemstatus += "<option value='Paused' selected='selected'>Paused</option>"; //selected - paused
                        dlwrkitemstatus += "<option value='Ongoing'>Ongoing</option>"; 
                        dlwrkitemstatus += "<option value='Completed'>Completed</option>";
                        dlwrkitemstatus += "<option value='Discontinued'>Discontinued</option>";
                        dlwrkitemstatus += "</select>";
                    }
                    else if(status=="Ongoing")
                    {
                        dlwrkitemstatus = "<select class='tbinput' name='CtrlStatus' id='CtrlStatus'>";
                        dlwrkitemstatus += "<option value='Ongoing' selected='selected'>Ongoing</option>"; //selected - ongoing
                        dlwrkitemstatus += "<option value='Paused'>Paused</option>";
                        dlwrkitemstatus += "<option value='Completed'>Completed</option>";
                        dlwrkitemstatus += "<option value='Discontinued'>Discontinued</option>";
                        dlwrkitemstatus += "</select>";
                    }
                    else if(status == "Completed")
                    {
                        dlwrkitemstatus = "<select class='tbinput' name='CtrlStatus' id='CtrlStatus'>";
                        dlwrkitemstatus += "<option value='Completed' selected='selected'>Completed</option>"; //selected - completed
                        dlwrkitemstatus += "<option value='Ongoing'>Ongoing</option>";
                        dlwrkitemstatus += "<option value='Paused'>Paused</option>";
                        dlwrkitemstatus += "<option value='Discontinued'>Discontinued</option>";
                        dlwrkitemstatus += "</select>";
                    }
                    else
                    {
                        dlwrkitemstatus = "<select class='tbinput' name='CtrlStatus' id='CtrlStatus'>";
                        dlwrkitemstatus += "<option value='Discontinued' selected='selected'>Discontinued</option>"; // selected - discontinued
                        dlwrkitemstatus += "<option value='Completed'>Completed</option>";
                        dlwrkitemstatus += "<option value='Paused'>Paused</option>";
                        dlwrkitemstatus += "<option value='Ongoing'>Ongoing</option>";
                        dlwrkitemstatus += "</select>";
                    }


                    WorkItemStatusPH.Text = dlwrkitemstatus; // assigns the returned output into WorkItemStatusPH 

                }

            }
            else
            {
                Response.Write("No ID in url OR couldn't parse url parameter to an int");
            }

        }

        protected void BtnUpdateWorkItemDetails_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                NameValueCollection UpdateWrkItemData = Request.Form; // captures the form data
                WorkItem UpdateWrkItem = new WorkItem(); // New object from work item Class
                string Result = UpdateWrkItem.UpdateWorkItem(UpdateWrkItemData);
                if (Result == "Query Succeeded")
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='success'>Work Item details updated successfully.</span><br />"); // if updation is successful
                    Response.Write("<a href='ViewWorkItemList.aspx'>Return to Work Item List</a>"); //link to return to work item list
                }
                else
                {
                    this.frmcont.Visible = false;
                    Response.Write(Result);
                    Response.Write("Result<span class='error'>Update failed; Work Item details have not been changed.</span><br />"); // if updation is not sucessfull
                    Response.Write("<a href='ViewWorkItemList.aspx'>Return to Work Item List</a>"); // link to return to work item list
                }

            }
        }
    }
}