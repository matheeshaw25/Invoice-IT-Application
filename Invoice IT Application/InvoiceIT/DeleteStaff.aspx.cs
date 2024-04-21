using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class DeleteStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.Params["ID"], out int Staff_ID); //gets the id output in int format
            Staff staff = new Staff(); //creates a new staff object from staff class
            string Message = staff.DeleteStaff(Staff_ID); //delete the data relevant to the staff id

            if (Message == "Query Succeeded")  // if deletion successfull
            {
                this.frmcont.Visible = false;
                Response.Write("<span class='success'>Staff details deleted successfully.</span><br />");
                Response.Write("<a href='ViewStaffList.aspx'>Return to Staff List</a>"); //link to view staff list
            }
            else // if deletion unsuccesfull
            {
                this.frmcont.Visible = false;
                Response.Write("<span class='error'>Delete failed; Staff details have not been deleted.</span><br />");
                Response.Write("<a href='ViewStaffList.aspx'>Return to Staff List</a>"); //link to view staff list after deletion
            }


        }
    }
}