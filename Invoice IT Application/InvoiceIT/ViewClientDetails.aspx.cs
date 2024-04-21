using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class ViewClientDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Client_ID)) 
            {
                Client client = new Client(); // new object from Client class
                _ = new List<string>(12); // holds 12 data
                List<string> ClientData = client.GetClient(Client_ID); 
                bool isEmpty = AppUtilities.IsEmpty(ClientData); // checks if ClientData list is empty
                if (isEmpty) // true means empty
                {
                    Response.Write("There was an unexpected error -  no client details were found");
                }
                else // there is something in the collection of ClientData
                {
                    Response.Write("Client ID: " + ClientData[0] + "<br/>"); // 0 is position of the client id
                    Response.Write("Company Name: " + ClientData[1] + "<br/>"); // 1 is position of client name
                    Response.Write("Company Address 1: " + ClientData[2] + "</br/>"); // 2 is position of the company address
                    Response.Write("Company Address 2: " + ClientData[3] + "</br/>");
                    Response.Write("Company Location: " + ClientData[4] + "</br/>");
                    Response.Write("Company Code: " + ClientData[5] + "</br/>");
                    Response.Write("Contact First Name: " + ClientData[6] + "</br/>");
                    Response.Write("Contact Last Name: " + ClientData[7] + "</br/>");
                    Response.Write("Contact Email: " + ClientData[8] + "</br/>");
                    Response.Write("Contact Mobile: " + ClientData[9] + "</br/>");
                    Response.Write("BillTo: " + ClientData[10] + "</br/>");
                    Response.Write("Status: " + ClientData[11] + "</br/>");
                    Response.Write("<br/>");
                    Response.Write("<a href = 'UpdateClient.aspx?ID=" + ClientData[0] + "'>Update Client Details</a>"); // update client link
                }


            }
            else
            {
                Response.Write("No ID in URL or couldn't parse to an int");
            }
        }
    }
}