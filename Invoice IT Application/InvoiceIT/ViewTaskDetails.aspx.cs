using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class ViewTaskDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Task_ID))
            {
                Task task = new Task();  // creates a new task object
                _ = new List<string>(4); // contains 4 fields 
                List<string> TaskData = task.GetTask(Task_ID); 
                bool isEmpty = AppUtilities.IsEmpty(TaskData); // checks if TaskData is empty

                if (isEmpty) // true means empty
                {
                    Response.Write("There was an unexpected error -  no task details were found");
                }
                else 
                {
                    Response.Write("Task ID: " + TaskData[0] + "<br/>"); // 1 - Task ID
                    Response.Write("Task Name: " + TaskData[1] + "<br/>"); //2 - Task Name
                    Response.Write("Task Description: " + TaskData[2] + "</br/>"); // 3 - Task Description
                    Response.Write("Task Rate: " + TaskData[3] + "</br/>"); // 4 - Task Rate
                    Response.Write("<br/>");
                    Response.Write("<a href = 'UpdateTask.aspx?ID=" + TaskData[0] + "'>Update Task Details</a>"); //Link to update task details
                }


            }
            else
            {
                Response.Write("No ID in URL or couldn't parse to an int");
            }



        }
    }
}