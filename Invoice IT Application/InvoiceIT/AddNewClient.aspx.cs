using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Collections;

namespace InvoiceIT
{
    public partial class AddNewClient : System.Web.UI.Page
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

                Response.Write("Hello " + staffdet[0] + " | <a href='Logout.aspx'>Log out</a>"); //logout link along with the hello staff name.

            }
        }

        protected void BtnAddNewClient_Click(object sender, EventArgs e)
        {
           // Response.Write("The form data was sent");
           if (IsPostBack)
            {
                /*Response.Write(Request.Form["CtrlCompName"] +"<br/>");
                Response.Write(Request.Form["CtrlCompAdd1"] + "<br/>");
                Response.Write(Request.Form["CtrlCompAdd2"] + "<br/>");
                Response.Write(Request.Form["CtrlCompLoc"] + "<br/>");
                Response.Write(Request.Form["CtrlCompCode"] + "<br/>");
                Response.Write(Request.Form["CtrlContactFname"] + "<br/>");
                Response.Write(Request.Form["CtrlContactLname"] + "<br/>");
                Response.Write(Request.Form["CtrlContactEmail"] + "<br/>");
                Response.Write(Request.Form["CtrlContactMobile"] + "<br/>");
                Response.Write(Request.Form["CtrlBillTo"] + "<br/>");
                Response.Write(Request.Form["CtrlStatus"] + "<br/>");
                */
                NameValueCollection NewClientData = Request.Form; 
                Client NewClient = new Client(); //creating new client object from the client class
                string Result = NewClient.AddClient(NewClientData); // pass the data in the NewClientData to the AddClient method 
                Response.Write(Result); 
                AppUtilities.ClearForm(Form.Controls); // to clear the form data after submission
            }
        }
    }
}