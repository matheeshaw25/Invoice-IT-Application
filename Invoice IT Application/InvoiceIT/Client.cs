using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;

namespace InvoiceIT
{
    public class Client
    {
        public int Client_ID { get; set; }
        public string Comp_Name { get; set; }
        public string Comp_Add1 { get; set; }
        public string Comp_Add2 { get; set; }
        public string Comp_Loc { get; set; }
        public string Comp_Code { get; set; }
        public string Contact_Fname { get; set; }
        public string Contact_Lname { get; set; }
        public string Contact_Email { get; set; }
        public string Contact_Mobile{ get; set; }
        public string BillTo { get; set; }
        public string Status { get; set; }
        
        public string Message { get; set; }


        //Add a New Client 
        public string AddClient(NameValueCollection NewClientData) 
        {
            this.Comp_Name = NewClientData["CtrlCompName"]; //captures form data 
            this.Comp_Add1 = NewClientData["CtrlCompAdd1"];
            this.Comp_Add2 = NewClientData["CtrlCompAdd2"];
            this.Comp_Loc = NewClientData["CtrlCompLoc"];
            this.Comp_Code = NewClientData["CtrlCompCode"];
            this.Contact_Fname = NewClientData["CtrlContactFname"];
            this.Contact_Lname = NewClientData["CtrlContactLname"];
            this.Contact_Email = NewClientData["CtrlContactEmail"];
            this.Contact_Mobile = NewClientData["CtrlContactMobile"];
            this.BillTo = NewClientData["CtrlBillTo"];
            this.Status = NewClientData["CtrlStatus"];


            SqlConnection con = DBConnect.MakeConn(); //established a con
            SqlCommand AddClient = new SqlCommand //create new sql command
            {
                CommandText = "INSERT CLIENT (Comp_Name, Comp_Add1, Comp_Add2,Comp_Loc,Comp_Code,Contact_Fname,Contact_Lname,Contact_Email,Contact_Mobile,BillTo,Status) VALUES" +
                " ('" + Comp_Name + "'," + "'" + Comp_Add1 + "','" + Comp_Add2 + "','" + Comp_Loc + "','" + Comp_Code + "'" +
                ",'" + Contact_Fname + "','" + Contact_Lname + "','" + Contact_Email + "','" + Contact_Mobile + "','" + BillTo + "','" + Status + "')", 
                CommandType = CommandType.Text,
                Connection = con // the connection to be used is con
            };

            if (con.State == ConnectionState.Open)
            {
                int a = AddClient.ExecuteNonQuery(); // if a is not zero then query succeeded
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

            DBConnect.DropConn(con); //close the connection
            return Message; 
        }
        //List all available clients
        public List<List<string>> GetClient() 
        {
            // This method will retrieve all client when no client ID is passed
            SqlConnection con = DBConnect.MakeConn(); //create connection to the DB 

            // Sql sequence to get all client
            SqlCommand GetAllClients = new SqlCommand
            {
                CommandText = " SELECT * FROM CLIENT ",
                CommandType = CommandType.Text,
                Connection = con
            };

            // create multi-dimensional list to hold query results
            List<List<string>> AllClients = new List<List<string>>();

            // Get the results by using the sql command
            SqlDataReader r = GetAllClients.ExecuteReader();

            if (r.HasRows) //if records are found then do what follows
            {
                while (r.Read())
                {
                    // Add each record to the list
                    AllClients.Add(new List<string> { r["Client_ID"].ToString(), r["Comp_Name"].ToString(), r["Comp_Add1"].ToString()
                        , r["Comp_Add2"].ToString(), r["Comp_Loc"].ToString(), r["Comp_Code"].ToString(), r["Contact_Fname"].ToString()
                        , r["Contact_Lname"].ToString(), r["Contact_Email"].ToString(), r["Contact_Mobile"].ToString(), r["BillTo"].ToString(), r["Status"].ToString() });
                }
                r.Close();
            }
            else
            {
                AllClients = null; // if no records are returned
            }
            DBConnect.DropConn(con); // close the connection
            return AllClients; 

        }
        public List<string> GetClient(int ClientID) // parameter ClientID passed to get specific client details 
        {
            this.Client_ID = ClientID;
            List<string> details = new List<string>(12);// to hold the data 
            //create connection to the DB                                           
            SqlConnection con = DBConnect.MakeConn();

            // Sql sequence to get specific client the caller wants
            SqlCommand GetClientDetails = new SqlCommand
            {
                CommandText = " SELECT * FROM CLIENT WHERE Client_ID = " + Client_ID,
                CommandType = CommandType.Text,
                Connection = con
            };

            SqlDataReader r = GetClientDetails.ExecuteReader(); // to get the above details (r will contains the details in a specific client)

            if (!r.HasRows)
            {
                details = null;
            }
            else
            {
                while (r.Read())
                {
                    details.Add(r["Client_ID"].ToString()); // Add client id to list index position 0
                    details.Add(r["Comp_Name"].ToString()); // Add  company name to list index position 1
                    details.Add(r["Comp_Add1"].ToString()); // Add company address 1 to list index position 2
                    details.Add(r["Comp_Add2"].ToString()); // Add company address 2 to list index position 3
                    details.Add(r["Comp_Loc"].ToString());
                    details.Add(r["Comp_Code"].ToString());
                    details.Add(r["Contact_Fname"].ToString());
                    details.Add(r["Contact_Lname"].ToString());
                    details.Add(r["Contact_Email"].ToString());
                    details.Add(r["Contact_Mobile"].ToString());
                    details.Add(r["BillTo"].ToString());
                    details.Add(r["Status"].ToString());
                }

            }

            DBConnect.DropConn(con); // drop toe connection
            return details;
        }

        public string UpdateClient(NameValueCollection UpdateClientData) 
        {
            this.Client_ID = Convert.ToInt32(UpdateClientData["CtrlClientID"]); // capturing form data , so form data is in string form, thats why we use Convert.ToInt32
            this.Comp_Name = UpdateClientData["CtrlCompName"];
            this.Comp_Add1 = UpdateClientData["CtrlCompAdd1"];
            this.Comp_Add2 = UpdateClientData["CtrlCompAdd2"];
            this.Comp_Loc = UpdateClientData["CtrlCompLoc"];
            this.Comp_Code = UpdateClientData["CtrlCompCode"];
            this.Contact_Fname = UpdateClientData["CtrlContactFname"];
            this.Contact_Lname = UpdateClientData["CtrlContactLname"];
            this.Contact_Email = UpdateClientData["CtrlContactEmail"];
            this.Contact_Mobile = UpdateClientData["CtrlContactMobile"];
            this.BillTo = UpdateClientData["CtrlBillTo"];
            this.Status = UpdateClientData["CtrlStatus"];

            SqlConnection con = DBConnect.MakeConn(); // create a connection

            //create sql command for update
            SqlCommand UpdateClient = new SqlCommand
            {
                CommandText = "UPDATE CLIENT SET Comp_Name='" + Comp_Name + "', Comp_Add1='" +
                Comp_Add1 + "', Comp_Add2='" + Comp_Add2 + "',Comp_Loc='" +
                Comp_Loc + "',Comp_Code='" + Comp_Code + "',Contact_Fname='" + Contact_Fname +
                "',Contact_Lname='" + Contact_Lname + "',Contact_Email='" + Contact_Email + "',Contact_Mobile='" + Contact_Mobile
                + "',BillTo='" + BillTo + "',Status='" + Status + "' WHERE Client_ID = " + Client_ID,
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int a = UpdateClient.ExecuteNonQuery();
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
            DBConnect.DropConn(con);
            return Message;



        }

        public string DeleteClient(int ClientID) 
        {
            this.Client_ID = ClientID;


            SqlConnection con = DBConnect.MakeConn(); //create a connection

            SqlCommand DeleteClient = new SqlCommand // sql command for deleting
            {
                CommandText = "DELETE FROM CLIENT WHERE Client_ID = " + Client_ID,
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int a = DeleteClient.ExecuteNonQuery();
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
            DBConnect.DropConn(con); //close the connection
            return Message;

        }
    }
}