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
    public partial class AddWorkItem : System.Web.UI.Page
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

                Response.Write("Hello " + staffdet[0] + " | <a href='Logout.aspx'>Log out</a>"); //link to logout

            }

        }

        protected void BtnAddNewWorkItem_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                NameValueCollection NewWorkItemData = Request.Form; //captures form data
                WorkItem NewWorkItem = new WorkItem(); //creates a work item object from the work item class
                string Result = NewWorkItem.AddWorkItem(NewWorkItemData);
                Response.Write(Result); 
                AppUtilities.ClearForm(Form.Controls); // clears the form after submission
            }
        }
    }
}