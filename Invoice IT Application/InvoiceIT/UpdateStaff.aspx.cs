using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

namespace InvoiceIT
{
    public partial class UpdateStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Staff_ID))
            {
                Staff staff = new Staff();
                _ = new List<string>(8); // contains 8 fields to update
                List<string> StffData = staff.GetStaff(Staff_ID);
                bool isEmpty = AppUtilities.IsEmpty(StffData); // checks if empty

                // Write customised header above form
                this.updatestaffheader.InnerHtml = "<h3>Update Details for " + StffData[1] + "</h3>"; //Displays the staff name that needs to be updated

                if (isEmpty)
                {
                    Response.Write("There was an unexpected error - no task details were returned"); // If StffData list is null or empty, inform user
                }
                else
                {
                    this.CtrlStaffID.Value = StffData[0].ToString();  //ToString() was used because it is a form
                    this.CtrlStaffFname.Text = StffData[1]; 
                    this.CtrlStaffSname.Text = StffData[2];
                    this.CtrlStaffEmail.Text = StffData[3];
                    this.CtrlStaffMobile.Text = StffData[4];
                    this.CtrlStaffPassword.Text = StffData[7];

                    string acclvl = StffData[5].Replace(" ", String.Empty);
                    string dlstffacclvl; // known as drop list access lvel 
                    if (acclvl == "Staff") // if acclvl in DB is "staff"
                    {
                        dlstffacclvl = "<select class='tbinput' name='CtrlStaffAccLvl' id='CtrlStaffAccLvl'>";
                        dlstffacclvl += "<option value='Staff' selected='selected'>Staff</option>"; // staff  is selected
                        dlstffacclvl += "<option value='Administrator'>Administrator</option>";
                        dlstffacclvl += "</select>";
                    }
                    else 
                    {
                        dlstffacclvl = "<select class='tbinput' name='CtrlStaffAccLvl' id='CtrlStaffAccLvl'>";
                        dlstffacclvl += "<option value='Staff'>Staff</option>";
                        dlstffacclvl += "<option value='Administrator' selected='selected'>Administrator</option>"; // administrator is selected
                        dlstffacclvl += "</select>";
                    } 
                    
                    StaffAccLvlPH.Text = dlstffacclvl;


                    string status = StffData[6].Replace(" ", String.Empty);
                    string dlstffstatus; // known as drop list course status | put all the asp html into this string and assign to that place holder in the form
                    if (status == "Active") // if course in DB is "active"
                    {
                        dlstffstatus = "<select class='tbinput' name='CtrlStaffStatus' id='CtrlStaffStatus'>";
                        dlstffstatus += "<option value='Active' selected='selected'>Active</option>";
                        dlstffstatus += "<option value='Inactive'>Inactive</option>";
                        dlstffstatus += "</select>";
                    }
                    else
                    {
                        dlstffstatus = "<select class='tbinput' name='CtrlStaffStatus' id='CtrlStaffStatus'>";
                        dlstffstatus += "<option value='Active'>Active</option>";
                        dlstffstatus += "<option value='Inactive' selected='selected'>Inactive</option>";
                        dlstffstatus += "</select>";
                    }

                    StaffStatusPH.Text = dlstffstatus; // assigns the value to StaffStatusPH
                }
                 
            }
            else
            {
                Response.Write("No ID in url OR couldn't parse url parameter to an int");
            }

        }

        protected void BtnUpdateStaffDetails_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                NameValueCollection UpdateStffData = Request.Form; // UpdateStffData captures the form data
                Staff UpdateStff = new Staff(); // New object from staff Class
                string Result = UpdateStff.UpdateStaff(UpdateStffData);
                if (Result == "Query Succeeded") // if updation is successful
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='success'>Staff details updated successfully.</span><br />");
                    Response.Write("<a href='ViewStaffList.aspx'>Return to Staff List</a>"); // link to return to staff list
                }
                else // if updation is unsucessful
                {
                    this.frmcont.Visible = false;
                    Response.Write(Result);
                    Response.Write("Result<span class='error'>Update failed; Staff details have not been changed.</span><br />");
                    Response.Write("<a href='ViewStaffList.aspx'>Return to Staff List</a>"); // link to return to staff list
                }

            }
        }
    }
}