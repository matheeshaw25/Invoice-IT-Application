using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class AdminPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["CurrStffs"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                _ = new ArrayList(); //create a new list
                ArrayList staffdet = (ArrayList)Session["CurrStffs"];
                int.TryParse((string)staffdet[1], out int RoleID);
                // Response.Write("The Role ID is " + RoleID);
                Response.Write("<b>Hello</b> " +" <b>" +staffdet[0]+ "</b>" +" !!" + " | <a href='Logout.aspx'>Log out</a>"); //logout link

            }
        }
    }
}