using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class DeleteWorkItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.Params["ID"], out int WorkItem_ID); //gets the ID value ouputted as an int
            WorkItem workitem = new WorkItem(); //creates a new work item object
            string Message = workitem.DeleteWorkItem(WorkItem_ID);

            if (Message == "Query Succeeded") // if deletion successfull
            {
                this.frmcont.Visible = false;
                Response.Write("<span class='success'>Work Item details deleted successfully.</span><br />");
                Response.Write("<a href='ViewWorkItemList.aspx'>Return to Work Item List</a>"); //link to return to work item list
            }
            else // if deletion unscessfull
            {
                this.frmcont.Visible = false;
                Response.Write("<span class='error'>Update failed; Work Item details have not been deleted.</span><br />");
                Response.Write("<a href='ViewWorkItemList.aspx'>Return to Work Item List</a>"); //link to return to work item list
            }

        }
    }
}