using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class UpdateInvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Invoice_No)) // gets invoice number as an int
            {

                Invoice invoice = new Invoice(); //createsnew invoice object
                _ = new List<string>(9); // contains 9 fileds to update
                List<string> InvData = invoice.GetInvoice(Invoice_No);
                bool isEmpty = AppUtilities.IsEmpty(InvData);

                this.updatecrsheader.InnerHtml = "<h3>Update Details for " + InvData[1] + "</h3>";

                if (isEmpty)
                {
                    Response.Write("There was an unexpected error - no invoice details were returned"); // If InvData list is null or empty, inform user
                }
                else
                {
                    this.CtrlInvoiceNo.Value = InvData[0].ToString(); // ToString() was used because it is a form
                    this.ClientListPH.Text = InvData[1]; 
                    this.CtrlInvoiceSdate.Text = InvData[2];
                    this.CtrlInvoiceEdate.Text = InvData[3];
                    this.CtrlInvoiceGdate.Text = InvData[4];
                    this.CtrlInvoiceSentdate.Text = InvData[5];
                    this.CtrlInvoiceDdate.Text = InvData[6];

                    //--
                    string dlBusinessName;

                    Client AllClients = new Client(); // creates new client object

                    List<List<string>> allclients = AllClients.GetClient();
                    if (allclients == null)
                    {

                        ClientListPH.Text = "Error - no business names returned";
                    }
                    else
                    {
                        int clientcnt = allclients.Count; // gets total client count
                        // the dropdown list to choose business name of the receipent
                        dlBusinessName = "<span id='LblClientList' class='frmlabel'>Business Name of the recepient*</span><br />";
                        dlBusinessName += "<select class='dllist' name='CtrlBusinessName'>";
                        dlBusinessName += "<option value='0'>--Please make a selection--</option>";

                        for (int i = 0; i <= clientcnt - 1; i++) // gets the options for the dropdown 
                        {
                            dlBusinessName += "<option value='" + allclients[i][0] + "'>" + allclients[i][1] + "</option>";
                        }

                        dlBusinessName += "</select>";
                        ClientListPH.Text = dlBusinessName; // assigns the dlBusinessName into ClientListPH

                    }

                    //--
                    string status = InvData[7].Replace(" ", String.Empty); // to remove any spaces

                    string dlinvoicestatus; // known as drop list course status 
                    if (status == "Generated") // if invoice status in DB is "generated"
                    {
                        dlinvoicestatus = "<select class='tbinput' name='CtrlInvStatus' id='CtrlInvStatus'>";
                        dlinvoicestatus += "<option value='Generated' selected='selected'>Generated</option>";
                        dlinvoicestatus += "<option value='Sent'>Sent</option>";
                        dlinvoicestatus += "<option value='Overdue'>Overdue</option>";
                        dlinvoicestatus += "<option value='Paid'>Paid</option>";
                        dlinvoicestatus += "<option value='Withdrawn'>Withdrawn</option>";
                        dlinvoicestatus += "</select>";
                    }
                    else if (status == "Sent")
                    {
                        dlinvoicestatus = "<select class='tbinput' name='CtrlInvStatus' id='CtrlInvStatus'>";
                        dlinvoicestatus += "<option value='Generated'>Generated</option>";
                        dlinvoicestatus += "<option value='Sent' selected='selected'>Sent</option>";
                        dlinvoicestatus += "<option value='Overdue'>Overdue</option>";
                        dlinvoicestatus += "<option value='Paid'>Paid</option>";
                        dlinvoicestatus += "<option value='Withdrawn'>Withdrawn</option>";
                        dlinvoicestatus += "</select>";
                    }
                    else if (status == "Overdue")
                    {
                        dlinvoicestatus = "<select class='tbinput' name='CtrlInvStatus' id='CtrlInvStatus'>";
                        dlinvoicestatus += "<option value='Generated'>Generated</option>";
                        dlinvoicestatus += "<option value='Sent'>Sent</option>";
                        dlinvoicestatus += "<option value='Overdue' selected='selected'>Overdue</option>";
                        dlinvoicestatus += "<option value='Paid'>Paid</option>";
                        dlinvoicestatus += "<option value='Withdrawn'>Withdrawn</option>";
                        dlinvoicestatus += "</select>";
                    }
                    else if(status == "Paid")
                    {
                        dlinvoicestatus = "<select class='tbinput' name='CtrlStatus' id='CtrlStatus'>";
                        dlinvoicestatus += "<option value='Generated'>Generated</option>";
                        dlinvoicestatus += "<option value='Sent'>Sent</option>";
                        dlinvoicestatus += "<option value='Overdue' >Overdue</option>";
                        dlinvoicestatus += "<option value='Withdrawn'>Withdrawn</option>";
                        dlinvoicestatus += "<option value='Paid' selected='selected'>Paid</option>";
                        dlinvoicestatus += "</select>";
                    }

                    else
                    {
                        dlinvoicestatus = "<select class='tbinput' name='CtrlStatus' id='CtrlStatus'>";
                        dlinvoicestatus += "<option value='Generated'>Generated</option>";
                        dlinvoicestatus += "<option value='Sent'>Sent</option>";
                        dlinvoicestatus += "<option value='Overdue' >Overdue</option>";
                        dlinvoicestatus += "<option value='Withdrawn' selected='selected'>Withdrawn</option>";
                        dlinvoicestatus += "<option value='Paid'>Paid</option>";
                        dlinvoicestatus += "</select>";
                    }

                    InvoiceStatusPH.Text = dlinvoicestatus;

                }

            }
            else
            {
                Response.Write("No ID in url OR couldn't parse url parameter to an int");
            }


        }

        protected void BtnUpdateInvoiceDetails_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                NameValueCollection UpdateInvData = Request.Form; // form data captured into UpdateInvData 
                Invoice UpdateInv = new Invoice(); // New object from invoice Class
                string Result = UpdateInv.UpdateInvoice(UpdateInvData);
                if (Result == "Query Succeeded") // if updation is successfull
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='success'>Invoice details updated successfully.</span><br />");
                    Response.Write("<a href='ViewInvoiceList.aspx'>Return to Invoice List</a>");
                }
                else // if updation is not successful
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='error'>Update failed; Invoice details have not been changed.</span><br />");
                    Response.Write("<a href='ViewInvoiceList.aspx'>Return to Invoice List</a>");
                }


            }
        }
    }

}