using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;

namespace InvoiceIT
{
    public class Staff
    {
        public int Staff_ID { get; set; }
        public string Staff_Fname { get; set; }
        public string Staff_Sname { get; set; }
        public string Staff_Email { get; set; }
        public string Staff_Mobile { get; set; }
        public string Staff_AccLvl { get; set; }
        public string Staff_Status { get; set; }
        public string Staff_Password { get; set; }
        public string Message { get; set; }



        public string AddStaff(NameValueCollection NewStaffData)
        {
            this.Staff_Fname = NewStaffData["CtrlStaffFname"]; 
            this.Staff_Sname = NewStaffData["CtrlStaffSname"];
            this.Staff_Email = NewStaffData["CtrlStaffEmail"];
            this.Staff_Mobile = NewStaffData["CtrlStaffMobile"];
            this.Staff_AccLvl = NewStaffData["CtrlStaffAccLvl"];
            this.Staff_Status = NewStaffData["CtrlStaffStatus"];
            this.Staff_Password = NewStaffData["CtrlStaffPassword"];

            SqlConnection con = DBConnect.MakeConn(); //create a new connection
            SqlCommand AddStaff = new SqlCommand // sql command to add staff
            {   
                CommandText = "INSERT STAFF  (Staff_Fname, Staff_Sname, Staff_Email,Staff_Mobile,Staff_AccLvl,Staff_Status,Staff_Password) VALUES ('" + Staff_Fname + "'," +
                "'" + Staff_Sname + "','" + Staff_Email + "','" + Staff_Mobile + "','" + Staff_AccLvl + "','" + Staff_Status + "','" + Staff_Password + "')",
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int a = AddStaff.ExecuteNonQuery();
                if (a == 0)
                {
                    this.Message = "Query Failed";
                }
                else
                {
                    this.Message = "Query Succeeded";
                }
            }
            else
            {
                this.Message = "SQL DB CONNECT FAILED";
            }

            DBConnect.DropConn(con); // drop the connection
            return Message;


        }


        public List<List<string>> GetStaff()
        {

            SqlConnection con = DBConnect.MakeConn(); //create connection
            SqlCommand GetAllStaff = new SqlCommand // create sql command to get all staff
            {
                CommandText = " SELECT * FROM STAFF ",
                CommandType = CommandType.Text,
                Connection = con
            };

            List<List<string>> AllStaff = new List<List<string>>(); // create a new list

            SqlDataReader r = GetAllStaff.ExecuteReader();

            if (r.HasRows)
            {
                while (r.Read())
                {
                    // Add each record to the list
                    AllStaff.Add(new List<string> { r["Staff_ID"].ToString(), r["Staff_Fname"].ToString(), r["Staff_Sname"].ToString(), r["Staff_Email"].ToString(), 
                        r["Staff_Mobile"].ToString(), r["Staff_AccLvl"].ToString(), r["Staff_Status"].ToString(), r["Staff_Password"].ToString() });
                }
                r.Close();
            }
            else
            {
                AllStaff = null;
            }
            DBConnect.DropConn(con); // drop the connection
            return AllStaff;

        }

        public List<string> GetStaff(int StaffID) // parameter passed to get specific staff details
        {
            this.Staff_ID = StaffID;
            List<string> details = new List<string>(8);// list contains 8 fields to show

            //create connection to the DB                                           
            SqlConnection con = DBConnect.MakeConn();

            // Sql sequence to get specific client the caller wants
            SqlCommand GetStaffDetails = new SqlCommand
            {
                CommandText = " SELECT * FROM STAFF WHERE Staff_ID = " + Staff_ID,
                CommandType = CommandType.Text,
                Connection = con
            };

            SqlDataReader r = GetStaffDetails.ExecuteReader();

            if (!r.HasRows)
            {
                details = null;
            }
            else
            {
                while (r.Read())
                {
                    details.Add(r["Staff_ID"].ToString()); // Add staffid to list index position 0
                    details.Add(r["Staff_Fname"].ToString()); // Add staff first name to list index position 1
                    details.Add(r["Staff_Sname"].ToString()); // Add staff last name to list index position 2
                    details.Add(r["Staff_Email"].ToString()); // Add staff email to list index position 3
                    details.Add(r["Staff_Mobile"].ToString());
                    details.Add(r["Staff_AccLvl"].ToString());
                    details.Add(r["Staff_Status"].ToString());
                    details.Add(r["Staff_Password"].ToString());


                }

            }

            DBConnect.DropConn(con); // drop connection 
            return details;

        }

        public string UpdateStaff(NameValueCollection UpdateStaffData)
        {
            this.Staff_ID = Convert.ToInt32(UpdateStaffData["CtrlStaffID"]); // so form data is in string form, thats why we use Convert.ToInt32
            this.Staff_Fname = UpdateStaffData["CtrlStaffFname"];
            this.Staff_Sname = UpdateStaffData["CtrlStaffSname"];
            this.Staff_Email = UpdateStaffData["CtrlStaffEmail"];
            this.Staff_Mobile = UpdateStaffData["CtrlStaffMobile"];
            this.Staff_AccLvl = UpdateStaffData["CtrlStaffAccLvl"];
            this.Staff_Status = UpdateStaffData["CtrlStaffStatus"];
            this.Staff_Password = UpdateStaffData["CtrlStaffPassword"];



            SqlConnection con = DBConnect.MakeConn(); //create a new connection

            SqlCommand UpdateStaff = new SqlCommand // create sql command to update staff
            {
                CommandText = "UPDATE STAFF SET Staff_Fname='" + Staff_Fname + "', Staff_Sname='" +
                Staff_Sname + "', Staff_Email='" + Staff_Email + "', Staff_Mobile='" +
                Staff_Mobile + "', Staff_AccLvl='" + Staff_AccLvl + "', Staff_Status='" + Staff_Status + "',Staff_Password='" +
                Staff_Password + "' WHERE Staff_ID = " + Staff_ID,
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int a = UpdateStaff.ExecuteNonQuery();
                if (a == 0)
                {
                    this.Message = "Query Failed";
                }
                else
                {
                    this.Message = "Query Succeeded";
                }

            }
            else
            {
                this.Message = "SQL DB Connect Failed";
            }
            DBConnect.DropConn(con); // drop the connection con
            return Message;




        }

        public string DeleteStaff(int StaffID) // paramter staffid passed to delete that specific staff id
        {
            this.Staff_ID = StaffID;


            SqlConnection con = DBConnect.MakeConn(); // create a new connection

            SqlCommand DeleteStaff = new SqlCommand // sql command to delete staff id
            {
                CommandText = "DELETE FROM STAFF WHERE Staff_ID = " + Staff_ID,
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int a = DeleteStaff.ExecuteNonQuery();
                if (a == 0)
                {
                    this.Message = "Query Failed";
                }
                else
                {
                    this.Message = "Query Succeeded";
                }

            }
            else
            {
                this.Message = "SQL DB Connect Failed";
            }
            DBConnect.DropConn(con); // drop the connection
            return Message;

        }


        public List<string> GetStaff(string StaffEmail, string StaffPassword) //get the staff member who contains the specific email and password
        {
            this.Staff_Email = StaffEmail;
            this.Staff_Password = StaffPassword;

            List<string> details = new List<string>(2); // list to hold email and password

            // Make connection to the database
            SqlConnection con = DBConnect.MakeConn();

            // SQL sequence to get the specific course the caller wants
            SqlCommand GetStaffDetails = new SqlCommand
            {
                CommandText = "SELECT Staff_Fname, Staff_AccLvl FROM [STAFF] WHERE Staff_Email = '" + Staff_Email + "' AND Staff_Password = '" + Staff_Password + "'",
                CommandType = CommandType.Text,
                Connection = con
            };

            SqlDataReader r = GetStaffDetails.ExecuteReader();

            if (!r.HasRows)
            {
                details = null;
            }
            else
            {
                while (r.Read())
                {
                    details.Add(r["Staff_Fname"].ToString()); // Add staff first name to list index position 0
                    details.Add(r["Staff_AccLvl"].ToString()); // Add staff access level  to list index position 1
                }
            }

            DBConnect.DropConn(con);
            return details;

        }


    }
}