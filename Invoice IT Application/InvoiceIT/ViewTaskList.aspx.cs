using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class ViewTaskList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["CurrStffs"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                _ = new ArrayList();
                ArrayList staffdet = (ArrayList)Session["CurrStffs"];
                int.TryParse((string)staffdet[1], out int RoleID);
                // Response.Write("The Role ID is " + RoleID);

                Response.Write("Hello " + staffdet[0] + " | <a href='Logout.aspx'>Log out</a>");

            }



            Task AllTasks = new Task();

            List<List<string>> alltsks = AllTasks.GetTask();

            if (alltsks == null) // if there are no records
            {
                Response.Write("No records found");
            }
            else
            {
                int results = alltsks.Count; //gets the count of total tasks

                // A bit of preamble
                Response.Write("<h3>Current Task List</h3>");
                Response.Write("<p>" + results + " Tasks Available </p>"); //outputs the totals no.of tasks to the user

                Response.Write("<div class = 'crslistingcont'>");
                //construct display of tasks
                for (int i = 0; i <= results - 1; i++)  
                {
                    Response.Write("<div class = 'crslistingrow'>");
                    Response.Write("<div class '>" + "<b>Task ID:</b> "+alltsks[i][0] + "</div>"); //displays task id
                    Response.Write("<div class >" +"<b>Task Name: </b>" +alltsks[i][1] + "</div>"); //displays task name
                    Response.Write("<div class = 'taskdesc'><a href='ViewTaskDetails.aspx?ID=" + alltsks[i][0] + "'> View</a></div>"); //link to view specific task details
                    Response.Write("<div class = 'deletetask'><a href='DeleteTask.aspx?ID=" + alltsks[i][0] + "'> Delete </a></div>"); // link to delete speicific task
                    Response.Write("<br>");
                    Response.Write("</div>");
                }
                Response.Write("</div>"); //close the div 


            }

        }
    }
}