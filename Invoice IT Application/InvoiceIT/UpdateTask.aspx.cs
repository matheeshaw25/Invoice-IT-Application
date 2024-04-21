using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

namespace InvoiceIT
{
    public partial class UpdateTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Task_ID)) // gets the ID output as an int
            {
                Task task = new Task(); //creates a new task object from task class
                _ = new List<string>(4); // contains 4 update fields
                List<string> TskData = task.GetTask(Task_ID);
                bool isEmpty = AppUtilities.IsEmpty(TskData); // is TSKData is empty

                // Write customised header above form
                this.updatecrsheader.InnerHtml = "<h3>Update Details for " + TskData[1] + "</h3>";

                if (isEmpty)
                {
                    Response.Write("There was an unexpected error - no task details were returned"); // If TskData list is null or empty, inform user
                }
                else
                {
                    this.CtrlTaskID.Value = TskData[0].ToString(); // converts ID int into a string
                    this.CtrlTaskTitle.Text = TskData[1]; 
                    this.CtrlTaskDesc.Text = TskData[2];
                    this.CtrlTaskRate.Text = TskData[3];
                }
            }
            else
            {
                Response.Write("No ID in url OR couldn't parse url parameter to an int");
            }
        }

        protected void BtnUpdateTaskDetails_Click(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                NameValueCollection UpdateTskData = Request.Form; // Captures form data
                Task UpdateTsk = new Task(); // New object from Task Class
                string Result = UpdateTsk.UpdateTask(UpdateTskData);
                if (Result == "Query Succeeded") // if updation is sucessfull
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='success'>Task details updated successfully.</span><br />");
                    Response.Write("<a href='ViewTaskList.aspx'>Return to Task List</a>"); //link to return to task list
                }
                else // if updation is not successfull
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='error'>Update failed; Task details have not been changed.</span><br />");
                    Response.Write("<a href='ViewTaskList.aspx'>Return to Task List</a>"); // llink to return to task list
                }

            }
        }
    }
}