using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class ViewClientList : System.Web.UI.Page
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

            // Instantiate a new client object from the client class
            Client AllCourses = new Client();

            // Assign returned result to multi dimensional string list 
            List<List<string>> allclients = AllCourses.GetClient(); // holds all the records we get from get client method 

            if (allclients == null) // if there are no records
            {
                Response.Write("No records found");
            }
            else
            {
                int results = allclients.Count; //how many items are in the returned data set 

                // A bit of preamble
                Response.Write("<h3>Current Client List</h3>"); // this is the current client list
                Response.Write("<p>" + results + " Clients Available </p>"); // the no.of client that are available

                Response.Write("<div class = 'crslistingcont'>");
                //construct display of courses
                for (int i = 0; i <= results - 1; i++)  // -1 because it started at zero not one.
                {
                    Response.Write("<div class = 'crslistingrow'>");
                    Response.Write("<div >" + "<b>Client ID:</b>"+ allclients[i][0] + "</div>"); //first cell = client id
                    Response.Write("<div> " + "<b>Client Name:</b> "+allclients[i][1] + "</div>"); // second cell = client name
                    Response.Write("<div ><a href='ViewClientDetails.aspx?ID=" + allclients[i][0] + "'> View</a></div>"); //link to view specific client details
                    Response.Write("<div ><a href='DeleteClient.aspx?ID=" + allclients[i][0] + "'> Delete </a></div>"); //link to  delete client details
                    Response.Write("<br>");
                    Response.Write("</div>");
                }
                Response.Write("</div>");


            }


        }
    }
}