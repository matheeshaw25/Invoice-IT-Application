using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class ViewStaffDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Staff_ID)) //gets staff id as in int
            {
                Staff staff = new Staff(); //creates new staff object
                _ = new List<string>(8); // list contains 8 fileds
                List<string> StaffData = staff.GetStaff(Staff_ID); //assign GetStaff(Staff_ID) method to the list created
                bool isEmpty = AppUtilities.IsEmpty(StaffData); //checks if list is empty

                if (isEmpty) // true means empty
                {
                    Response.Write("There was an unexpected error -  no staff details were found");
                }
                else
                {
                    Response.Write("Staff ID: " + StaffData[0] + "<br/>"); //1- shows staff id
                    Response.Write("Staff First Name: " + StaffData[1] + "<br/>"); //2 - shows staff first name
                    Response.Write("Staff Surname: " + StaffData[2] + "</br/>"); //3 - shows staff surname
                    Response.Write("Staff Email: " + StaffData[3] + "</br/>");
                    Response.Write("Staff Mobile: " + StaffData[4] + "</br/>");
                    Response.Write("STaff Access Level: " + StaffData[5] + "</br/>");
                    Response.Write("Staff Status: " + StaffData[6] + "</br/>");
                    Response.Write("Staff Password: " + StaffData[7] + "</br/>");

                    Response.Write("<br/>");
                    Response.Write("<a href = 'UpdateStaff.aspx?ID=" + StaffData[0] + "'>Update Staff Details</a>"); // link to update staff details
                }


            }
            else
            {
                Response.Write("No ID in URL or couldn't parse to an int");
            }







        }
    }
}