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
    public partial class AddNewInvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["CurrStffs"] == null)
            {
                Response.Redirect("login.aspx"); // redirect user to login page if they access this page without login in
            }
            else
            {
                _ = new ArrayList();
                ArrayList staffdet = (ArrayList)Session["CurrStffs"];
                int.TryParse((string)staffdet[1], out int RoleID);
                // Response.Write("The Role ID is " + RoleID);

                Response.Write("Hello " + staffdet[0] + " | <a href='Logout.aspx'>Log out</a>"); // contains logout link

            }

            string dlBusinessName;

            Client AllClients = new Client(); // creates new client object

            List<List<string>> allclients = AllClients.GetClient(); // assigns GetClient() to the list
            if (allclients == null) 
            {

                ClientListPH.Text = "Error - no business names returned";
            }
            else
            {
                int clientcnt = allclients.Count;

                dlBusinessName = "<span id='LblClientList' class='frmlabel'>Select a Client</span><br />";
                dlBusinessName += "<select class='dllist' name='CtrlBusinessName'>"; // contains the business name list
                dlBusinessName += "<option value='0'>--Please make a selection--</option>";

                for (int i = 0; i <= clientcnt - 1; i++) // gets id and business name for the total business names available
                {
                    dlBusinessName += "<option value='" + allclients[i][0] + "'>" + allclients[i][1] + "</option>";
                }

                dlBusinessName += "</select>";
                ClientListPH.Text = dlBusinessName; // assigns dlBusinessName into ClientList PH

            }


        }

        protected void BtnAddNewInvoice_Click(object sender, EventArgs e)
        {
            NameValueCollection NewInvoiceData = Request.Form; //captures form data into NewInvoiceData
            Invoice NewInvoice = new Invoice(); // creates a new invoice object
            string Result = NewInvoice.AddInvoice(NewInvoiceData);
            Response.Write(Result);
            AppUtilities.ClearForm(Form.Controls); // clears the form after submission
        }

       
    }
}