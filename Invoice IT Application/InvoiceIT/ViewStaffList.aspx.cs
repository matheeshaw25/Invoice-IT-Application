using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class ViewStaffList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["CurrStffs"] == null) // this page can be only accessed through login page only
            {
                Response.Redirect("login.aspx"); // redirect user to login page
            }
            else
            {
                _ = new ArrayList();
                ArrayList staffdet = (ArrayList)Session["CurrStffs"];
                int.TryParse((string)staffdet[1], out int RoleID);
                // Response.Write("The Role ID is " + RoleID);

                Response.Write("Hello " + staffdet[0] + " | <a href='Logout.aspx'>Log out</a>");

            }


            Staff AllStaff = new Staff(); // creates a new staff object

            List<List<string>> allstff = AllStaff.GetStaff(); // creates a new list and assign GetStaff() method into it

            if (allstff == null) // if there are no records
            {
                Response.Write("No records found");
            }
            else
            {
                int results = allstff.Count;

                // A bit of preamble
                Response.Write("<h3>Current Staff List</h3>");
                Response.Write("<p>" + results + " Staff Available </p>"); // displays user the number of staff available

                Response.Write("<div class = 'crslistingcont'>");
                //construct display of tasks
                for (int i = 0; i <= results - 1; i++)
                {
                    Response.Write("<div class = 'crslistingrow'>");
                    Response.Write("<div >" +"<b>Staff ID: </b>" +allstff[i][0] + "</div>"); //1- staff id
                    Response.Write("<div >" +"<b>Staff First Name: </b>" +allstff[i][1] + "</div>"); //2 - staff first name
                    //Response.Write("<div >" + allstff[i][2] + "</div>"); // 3- staff password
                    Response.Write("<div ><a href='ViewStaffDetails.aspx?ID=" + allstff[i][0] + "'> View</a></div>"); // link to view specific staff details
                    Response.Write("<div ><a href='DeleteStaff.aspx?ID=" + allstff[i][0] + "'> Delete </a></div>"); // link to delete specific staff member
                    Response.Write("<br>");
                    Response.Write("</div>");
                }
                Response.Write("</div>");
            }






        }
    }
}