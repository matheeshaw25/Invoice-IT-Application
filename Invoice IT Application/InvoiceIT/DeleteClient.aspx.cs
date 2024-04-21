using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class DeleteClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.Params["ID"], out int Client_ID); //getting the Client_ID output as int
            Client client = new Client(); //Creates a new client object from the Client class.
            string Message = client.DeleteClient(Client_ID);

            if (Message == "Query Succeeded")
            {
                this.frmcont.Visible = false;
                Response.Write("<span class='success'>Client details deleted successfully.</span><br />"); //If client details deleted without error.
                Response.Write("<a href='ViewClientList.aspx'>Return to Client List</a>"); // Link to go back to client list
            }
            else
            {
                this.frmcont.Visible = false;
                Response.Write("<span class='error'>Update failed; Client details have not been deleted.</span><br />"); //If client details were not deleted.
                Response.Write("<a href='ViewClientList.aspx'>Return to Client List</a>");
            }
        }
    }
}