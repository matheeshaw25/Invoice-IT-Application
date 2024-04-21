using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class ViewWorkItemList : System.Web.UI.Page
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

                Response.Write("Hello " + staffdet[0] + " | <a href='Logout.aspx'>Log out</a>"); //logout link

            }

            WorkItem WorkItem = new WorkItem(); //creates a new work item object

            List<List<string>> wrkitem = WorkItem.GetWorkItem(); //assigns the created object into a list

            if (wrkitem == null) // if there are no records
            {
                Response.Write("No records found");
            }
            else
            {
                int results = wrkitem.Count;

                // A bit of preamble
                Response.Write("<h3>Current Work Item List</h3>");
                Response.Write("<p>" + results + " Work Items Available </p>");

                Response.Write("<div class = 'crslistingcont'>");
                //construct display of tasks
                for (int i = 0; i <= results - 1; i++)
                {
                    Response.Write("<div class = 'crslistingrow'>");
                    Response.Write("<div class = 'workitemid'>" +"<b>Work Item ID:</b>" + wrkitem[i][0] + "</div>"); // 1- shows work item id
                    // Response.Write("<div class = 'clientid'>" + wrkitem[i][1] + "</div>");
                    //Response.Write("<div class = 'taskid'>" + wrkitem[i][2] + "</div>");
                    //Response.Write("<div class = 'staffid'>" + wrkitem[i][3] + "</div>");
                    Response.Write("<div class = 'date'>" +"<b>The date work was done</b>" + wrkitem[i][4] + "</div>"); // 2 - shows the date work was done
                    //Response.Write("<div class = 'itemstime'>" + wrkitem[i][5] + "</div>");
                    //Response.Write("<div class = 'itemetime'>" + wrkitem[i][6] + "</div>");
                    Response.Write("<div class = 'comment'>" + "<b>Comment:</b>" + wrkitem[i][7] + "</div>"); // shows the comment
                    //Response.Write("<div class = 'itemstatus'>" + wrkitem[i][8] + "</div>");
                    Response.Write("<div class = 'viewstaff'><a href='ViewWorkItemDetails.aspx?ID=" + wrkitem[i][0] + "'> View</a></div>"); //link to view specific work item
                    Response.Write("<div class = 'deletestaff'><a href='DeleteWorkItem.aspx?ID=" + wrkitem[i][0] + "'> Delete </a></div>"); // link to delete specific work item
                    Response.Write("</div>");
                }
                Response.Write("</div>");

            }
        }
    }
}