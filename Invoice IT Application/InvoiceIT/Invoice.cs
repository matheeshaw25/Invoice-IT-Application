using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;

namespace InvoiceIT
{
    public class Invoice
    {
        public int Invoice_No { get; set; }
        public string Business_Name { get; set; }
        public string Invoice_Sdate { get; set; }
        public string Invoice_Edate { get; set; }
        public string Invoice_Gdate { get; set; }
        public string Invoice_Sentdate { get; set; }
        public string Invoice_Ddate { get; set; }
        public string Invoice_Status { get; set; }
        public string Message { get; set; }



        public string AddInvoice(NameValueCollection NewInvoiceData)
        {
            this.Business_Name = NewInvoiceData["CtrlBusinessName"];
            this.Invoice_Sdate = NewInvoiceData["CtrlInvoiceSdate"];
            this.Invoice_Edate = NewInvoiceData["CtrlInvoiceEdate"];
            this.Invoice_Gdate = NewInvoiceData["CtrlInvoiceGdate"];
            this.Invoice_Sentdate = NewInvoiceData["CtrlInvoiceSentdate"];
            this.Invoice_Ddate = NewInvoiceData["CtrlInvoiceDdate"];
            this.Invoice_Status = NewInvoiceData["CtrlInvStatus"];

            SqlConnection con = DBConnect.MakeConn(); //established a con
            SqlCommand AddInvoice = new SqlCommand // create sql command to add invoice to the database
            {
                CommandText = "INSERT INVOICE (Business_Name, Invoice_Sdate, Invoice_Edate,Invoice_Gdate,Invoice_Sentdate,Invoice_Ddate,Invoice_Status) VALUES" +
                " ('" + Business_Name + "'," + "'" + Invoice_Sdate + "','" + Invoice_Edate + "','" + Invoice_Gdate + "','" + Invoice_Sentdate + "'" +
                ",'" + Invoice_Ddate + "','" + Invoice_Status + "')",
                CommandType = CommandType.Text,
                Connection = con // the connection to be used is con
            };

            if (con.State == ConnectionState.Open)
            {
                int a = AddInvoice.ExecuteNonQuery();
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

        public List<List<string>> GetInvoice() // get all the invoices
        {
            SqlConnection con = DBConnect.MakeConn(); // create a new connection

            SqlCommand GetAllInvoices = new SqlCommand // sql command to get all invoices from db
            {
                CommandText = " SELECT * FROM INVOICE ",
                CommandType = CommandType.Text,
                Connection = con
            };

            List<List<string>> AllInvoices = new List<List<string>>(); //create a new list

            SqlDataReader r = GetAllInvoices.ExecuteReader();

            if (r.HasRows)
            {
                while (r.Read())
                {
                    // Add each record to the list
                    AllInvoices.Add(new List<string> { r["Invoice_No"].ToString(), r["Business_Name"].ToString(), r["Invoice_Sdate"].ToString(), r["Invoice_Edate"].ToString(), 
                        r["Invoice_Gdate"].ToString(), r["Invoice_Sentdate"].ToString(), r["Invoice_Ddate"].ToString(), r["Invoice_Status"].ToString() });
                }
                r.Close();
            }
            else
            {
                AllInvoices = null;
            }
            DBConnect.DropConn(con); // drop the connection
            return AllInvoices;

        }

        public List<string> GetInvoice(int InvoiceNo) // paramter InvoiceNo passed to get specific invoice corresponding to the invoice number given
        {
            this.Invoice_No = InvoiceNo;
            List<string> details = new List<string>(8); // needs to hold 8 details to display

            SqlConnection con = DBConnect.MakeConn(); // create a new connection

            // Sql sequence to get specific invoice the caller wants
            SqlCommand GetInvoiceDetails = new SqlCommand
            {
                CommandText = " SELECT * FROM INVOICE WHERE Invoice_No = " + Invoice_No,
                CommandType = CommandType.Text,
                Connection = con
            };
            SqlDataReader r = GetInvoiceDetails.ExecuteReader();
            if (!r.HasRows)
            {
                details = null;
            }
            else
            {
                while (r.Read())
                {
                    //add details to list
                    details.Add(r["Invoice_No"].ToString()); // Add invoice to list index position 0
                    details.Add(r["Business_Name"].ToString()); // Add business name to list index position 1
                    details.Add(r["Invoice_Sdate"].ToString()); 
                    details.Add(r["Invoice_Edate"].ToString());
                    details.Add(r["Invoice_Gdate"].ToString()); 
                    details.Add(r["Invoice_Sentdate"].ToString()); 
                    details.Add(r["Invoice_Ddate"].ToString()); 
                    details.Add(r["Invoice_Status"].ToString());
                }   
            }
            DBConnect.DropConn(con); // drop the connection
            return details;




        }

        public string UpdateInvoice(NameValueCollection UpdateInvData)
        {
            this.Invoice_No = Convert.ToInt32(UpdateInvData["CtrlInvoiceNo"]); // convert to int because data sent from form is in string format
            this.Business_Name = UpdateInvData["CtrlBusinessName"];
            this.Invoice_Sdate = UpdateInvData["CtrlInvoiceSdate"];
            this.Invoice_Edate = UpdateInvData["CtrlInvoiceEdate"];
            this.Invoice_Gdate = UpdateInvData["CtrlInvoiceGdate"];
            this.Invoice_Sentdate = UpdateInvData["CtrlInvoiceSentdate"];
            this.Invoice_Ddate = UpdateInvData["CtrlInvoiceDdate"];
            this.Invoice_Status = UpdateInvData["CtrlInvStatus"];

            SqlConnection con = DBConnect.MakeConn(); // create a new connection

            SqlCommand UpdateInvoice = new SqlCommand // sql comman to update invoice
            {
                CommandText = "UPDATE INVOICE SET Business_Name='" + Business_Name + "', Invoice_Sdate='" +
                Invoice_Sdate + "', Invoice_Edate='" + Invoice_Edate + "', Invoice_Gdate='" + Invoice_Gdate + "', Invoice_Sentdate='" +
                Invoice_Sentdate + "', Invoice_Ddate='" + Invoice_Ddate + "', Invoice_Status='" + Invoice_Status + "' WHERE Invoice_No = " + Invoice_No,
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int a = UpdateInvoice.ExecuteNonQuery();
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

        public string DeleteInvoice(int InvoiceNo)
        {

            this.Invoice_No = InvoiceNo;

            SqlConnection con = DBConnect.MakeConn(); // create a new connection

            SqlCommand DeleteInvoice = new SqlCommand //sql command to delete specific invoice corresponding to invoice number
            {
                CommandText = "DELETE FROM INVOICE WHERE Invoice_No = " + Invoice_No,
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int a = DeleteInvoice.ExecuteNonQuery();
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




    }
}