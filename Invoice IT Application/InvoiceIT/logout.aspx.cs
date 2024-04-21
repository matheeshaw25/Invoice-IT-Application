using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceIT
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["CurrStffs"] != null) //if current session is null
            {
                Session.Abandon();
                Response.Redirect("login.aspx"); // redirects user to login page after logout
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
    }
}