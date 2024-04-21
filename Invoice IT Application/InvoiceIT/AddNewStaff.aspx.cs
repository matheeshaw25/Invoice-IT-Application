using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class AddNewStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["CurrStffs"] == null) //user can get into this page only by the login page
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

        }

        protected void BtnAddNewStaff_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                NameValueCollection NewStaffData = Request.Form; // capturies form data into NewStaffData
                Staff NewStaff = new Staff(); // creates a new class object
                string Result = NewStaff.AddStaff(NewStaffData);
                Response.Write(Result);
                AppUtilities.ClearForm(Form.Controls); // clears form after submission
            }



        }
    }
}