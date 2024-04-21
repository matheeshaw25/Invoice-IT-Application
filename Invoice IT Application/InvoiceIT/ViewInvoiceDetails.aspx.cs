using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class ViewInvoiceDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Invoice_No)) //gets invoice number in a string format
            {
                Invoice invoice = new Invoice(); // creates a invoice object
                _ = new List<string>(8); // contains 8 fields
                List<string> InvoiceData = invoice.GetInvoice(Invoice_No); // passes a paramter (ID) to the function
                bool isEmpty = AppUtilities.IsEmpty(InvoiceData); // checks if data is empty

                if (isEmpty) // true means empty
                {
                    Response.Write("There was an unexpected error -  no invoice details were found");
                }
                else
                {
                    Response.Write("Invoice No: " + InvoiceData[0] + "<br/>"); // 1 - invoice no
                    Response.Write("Business Name: " + InvoiceData[1] + "<br/>"); // 2 - business name of the recepient
                    Response.Write("Invoice Start Date Period: " + InvoiceData[2] + "</br/>"); 
                    Response.Write("Invoice End Date Period: " + InvoiceData[3] + "</br/>");
                    Response.Write("Invoice Generated Date: " + InvoiceData[4] + "<br/>");
                    Response.Write("Invoice Sent Date: " + InvoiceData[5] + "<br/>");
                    Response.Write("Payment Due Data: " + InvoiceData[6] + "</br/>");
                    Response.Write("Status: " + InvoiceData[7] + "</br/>");
                    Response.Write("<br/>");
                    Response.Write("<a href = 'UpdateInvoice.aspx?ID=" + InvoiceData[0] + "'>Update Invoice Details</a>"); // link to update invoice details
                }

            }
            else
            {
                Response.Write("No ID in URL or couldn't parse to an int");
            }
          

        }
    }
}