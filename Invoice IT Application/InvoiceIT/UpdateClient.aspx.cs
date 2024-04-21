using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class UpdateClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Client_ID))
            {

                Client client = new Client(); 
                _ = new List<string>(12);
                List<string> ClientData = client.GetClient(Client_ID); 
                bool isEmpty = AppUtilities.IsEmpty(ClientData); 

                // Write customised header above form
                this.updateclientheader.InnerHtml = "<h3>Update Details for " + ClientData[1] + "</h3>";

                if (isEmpty)
                {
                    Response.Write("There was an unexpected error - no client details were returned"); 
                }
                else
                { 
                    this.CtrlClientID.Value = ClientData[0].ToString(); 
                    this.CtrlCompName.Text = ClientData[1]; 
                    this.CtrlCompAdd1.Text = ClientData[2];
                    this.CtrlCompAdd2.Text = ClientData[3];
                    this.CtrlCompLoc.Text = ClientData[4];
                    this.CtrlCompCode.Text = ClientData[5];
                    this.CtrlContactFname.Text = ClientData[6];
                    this.CtrlContactLname.Text = ClientData[7];
                    this.CtrlContactEmail.Text = ClientData[8];
                    this.CtrlContactMobile.Text = ClientData[9];
                    this.CtrlBillTo.Text = ClientData[10];
                    

                    // string status = ClientData[11];
                    string status = ClientData[11].Replace(" ", String.Empty); // removes any spaces in the status bar
                   

                    string dlclientstatus; // known as drop list course status 
                    if (status == "Good") 
                    {
                        dlclientstatus = "<select class='tbinput' name='CtrlStatus' id='CtrlStatus'>";
                        dlclientstatus += "<option value='Good' selected='selected'>Good</option>";
                        dlclientstatus += "<option value='InArrears'>In Arrears</option>";
                        dlclientstatus += "<option value='Discontinued'>Discontinued</option>";
                        dlclientstatus += "</select>";
                    }
                    else if(status == "In Arrears")
                    {
                        dlclientstatus = "<select class='tbinput' name='CtrlStatus' id='CtrlStatus'>";
                        dlclientstatus += "<option value='Good'>Good</option>";
                        dlclientstatus += "<option value='InArrears' selected='selected'>In Arrears</option>";
                        dlclientstatus += "<option value='Discontinued'>Discontinued</option>";
                        dlclientstatus += "</select>";
                    }
                    else
                    {
                        dlclientstatus = "<select class='tbinput' name='CtrlStatus' id='CtrlStatus'>";
                        dlclientstatus += "<option value='Good'>Good</option>";
                        dlclientstatus += "<option value='InArrears'>In Arrears</option>";
                        dlclientstatus += "<option value='Discontinued' selected='selected'>Discontinued</option>";
                        dlclientstatus += "</select>";
                    }


                    ClientStatusPH.Text = dlclientstatus; // placing everything in dlclientstatus to the place holder ClientStatusPH.

                }
            }
            else
            {
                Response.Write("No ID in url OR couldn't parse url parameter to an int");
            }
        }

        protected void BtnUpdateClientDetails_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                NameValueCollection UpdateClientData = Request.Form; // Capturing form data
                Client UpdateClient = new Client(); // Creates New object from Client Class
                string Result = UpdateClient.UpdateClient(UpdateClientData);
                if (Result == "Query Succeeded")
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='success'>Client details updated successfully.</span><br />"); //if client details updated without error.
                    Response.Write("<a href='ViewClientList.aspx'>Return to Client List</a>");
                }
                else
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='error'>Update failed; client details have not been changed.</span><br />"); // if client details were not updated.
                    Response.Write("<a href='ViewClientList.aspx'>Return to Client List</a>");
                }

            }
        }
    }
}