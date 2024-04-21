using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class DeleteInvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.Params["ID"], out int Invoice_NO); //get invoice number as an int
            Invoice invoice = new Invoice(); // create new invoice object
            string Message = invoice.DeleteInvoice(Invoice_NO);

            if (Message == "Query Succeeded") // if deletion is successful
            {
                this.frmcont.Visible = false;
                Response.Write("<span class='success'>Invoice details deleted successfully.</span><br />");
                Response.Write("<a href='ViewInvoiceList.aspx'>Return to Invoice List</a>");
            }
            else // if deletion is unsuccessfull
            {
                this.frmcont.Visible = false;
                Response.Write("<span class='error'>Update failed; Invoice details have not been deleted.</span><br />");
                Response.Write("<a href='ViewInvoiceList.aspx'>Return to Invoice List</a>");
            }
        }
    }
}