using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            Staff staff = new Staff(); // create new staff object
            _ = new List<string>(2); // contains the email and password
            List<string> StaffDetails = staff.GetStaff(Request.Form["CtrlStaffEmail"], Request.Form["CtrlStaffPassword"]);
            bool isEmpty = AppUtilities.IsEmpty(StaffDetails); // checks if details are empty
            if (isEmpty)
            {
                Response.Write("No user found with these credentials. Return to <a href='login.aspx'>Login Page</a>");
            }
            else
            {
                // Response.Write("Staff Fname: " + StaffDetails[0] + "<br />");
                // Response.Write("Staff Acc Level: " + StaffDetails[1] + "<br />");
                ArrayList SessStaff = new ArrayList
                            {
                                StaffDetails[0], // Staff First Name
                                StaffDetails[1] // Staff Access Level
                            };
                Session["CurrStffs"] = SessStaff;

                // Response.Write("Staff Fname in Session Var: " + StaffDetails[0] + "<br />");
                // Response.Write("Staff Acc Lvl in Session Var: " + StaffDetails[1] + "<br />");


                // Response.Write("The Role ID is " + RoleID);

                if (StaffDetails[1] == "Administrator")
                {
                    Response.Redirect("AdminPanel.aspx");
                }
                else
                {
                    Response.Redirect("StaffPanel.aspx");
                }
            }
        }
    }
}