using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class DeleteTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.Params["ID"], out int Task_ID); // gets output Task_ID as int
            Task task = new Task(); // creates a new task object from task class
            string Message = task.DeleteTask(Task_ID);

            if (Message == "Query Succeeded") // if deletion is successful
            {
                this.frmcont.Visible = false;
                Response.Write("<span class='success'>Task details deleted successfully.</span><br />");
                Response.Write("<a href='ViewTaskList.aspx'>Return to task List</a>");
            }
            else //if deletion success.
            {
                this.frmcont.Visible = false; 
                Response.Write("<span class='error'>Deletion failed; Task details have not been deleted.</span><br />");
                Response.Write("<a href='ViewTaskList.aspx'>Return to task List</a>");
            }




        }
    }
}