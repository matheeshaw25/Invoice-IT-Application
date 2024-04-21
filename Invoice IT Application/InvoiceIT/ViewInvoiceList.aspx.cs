using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class ViewInvoiceList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (System.Web.HttpContext.Current.Session["CurrStffs"] == null) // this page can be only accessed after successful login
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                _ = new ArrayList();
                ArrayList staffdet = (ArrayList)Session["CurrStffs"];
                int.TryParse((string)staffdet[1], out int RoleID);
                // Response.Write("The Role ID is " + RoleID);

                Response.Write("Hello " + staffdet[0] + " | <a href='Logout.aspx'>Log out</a>"); // logout link

            }


            Invoice AllInvoices = new Invoice(); // creates a new invoice object

            List<List<string>> allinvs = AllInvoices.GetInvoice(); // assigns the GetInvoice() to string
            if (allinvs == null) // if there are no records
            {
                Response.Write("No records found");
            }
            else
            {
                int results = allinvs.Count();

                Response.Write("<h3>Current Invoice List</h3>");
                Response.Write("<p>" + results + " <b>Invoices Available</b> </p>"); //shows total number of invoices present

                for (int i = 0; i <= results - 1; i++)
                {
                    Response.Write("<div class = 'crslistingrow'>");
                    Response.Write("<div class = 'invoiceno'>" + "<b>Invoice Number:</b> "+ allinvs[i][0] + "</div>"); //cell 1 - invoice number
                    Response.Write("<div class = 'businessname'>" + "<b>Business name of the recipient:  </b>" + allinvs[i][1] + "</div>"); //cell 2 - business name of the receipient
                    Response.Write("<div class = 'invoicestatus'>"+ "<b>Status of the invoice:</b>" + allinvs[i][2] + "</div>"); //cell 3 - invoice status
                    Response.Write("<div class = 'taskdesc'><a href='ViewInvoiceDetails.aspx?ID=" + allinvs[i][0] + "'> View</a></div>"); // link to view specific details
                    Response.Write("<div class = 'deletetask'><a href='DeleteInvoice.aspx?ID=" + allinvs[i][0] + "'> Delete </a></div>"); // link to delete an invoice
                    Response.Write("<br>");
                    Response.Write("</div>");
                }
               

            }

        }
    }
}