using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;

namespace InvoiceIT
{
    public class WorkItem
    {
        public int WorkItem_ID { get; set; }
        public int Client_ID { get; set; }
        public int Task_ID { get; set; }
        public int Staff_ID { get; set; }
        public string Date { get; set; }
        public string ItemStime { get; set; }
        public string ItemEtime { get; set; }
        public string ItemStatus { get; set; }
        public string Comment { get; set; }
        public string Message { get; set; }


        public string AddWorkItem(NameValueCollection AddWorkItemData) // add work item to db
        {
            this.Client_ID =Convert.ToInt32( AddWorkItemData["CtrlClientID"]); // convert to int because form passes data as strings
            this.Task_ID = Convert.ToInt32(AddWorkItemData["CtrlTaskID"]);
            this.Staff_ID = Convert.ToInt32( AddWorkItemData["CtrlStaffID"]);
            this.Date = AddWorkItemData["CtrlDate"];
            this.ItemStime = AddWorkItemData["CtrlItemStime"];
            this.ItemEtime = AddWorkItemData["CtrlItemEtime"];
            this.Comment = AddWorkItemData["CtrlComment"];
            this.ItemStatus = AddWorkItemData["CtrlStatus"];


            SqlConnection con = DBConnect.MakeConn(); // create a new connection
            SqlCommand AddWorkItem = new SqlCommand // create sql command to add work items
            {
                CommandText = "INSERT WORKITEM (Client_ID, Task_ID, Staff_ID,Date,ItemStime,ItemEtime,ItemStatus,Comment) VALUES" +
                " ('" + Client_ID + "'," + "'" + Task_ID + "','" + Staff_ID + "','" + Date + "','" + ItemStime + "'" +
                ",'" + ItemEtime + "','" + ItemStatus + "','" + Comment + "')",
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int a = AddWorkItem.ExecuteNonQuery();
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

            DBConnect.DropConn(con); // drop connection
            return Message;

        }
        public List<List<string>> GetWorkItem()
        {
            SqlConnection con = DBConnect.MakeConn(); // create a connection

            SqlCommand GetAllWorkItems = new SqlCommand // sql command to get all the form items 
            {
                CommandText = " SELECT * FROM WORKITEM ",
                CommandType = CommandType.Text,
                Connection = con
            };
            List<List<string>> AllWorkItems = new List<List<string>>(); // create a new list

            SqlDataReader r = GetAllWorkItems.ExecuteReader();

            if (r.HasRows)
            {
                while (r.Read())
                {
                    // Add each record to the list
                    AllWorkItems.Add(new List<string> { r["WorkItem_ID"].ToString(), r["Client_ID"].ToString(), r["Task_ID"].ToString(), r["Staff_ID"].ToString(),
                        r["Date"].ToString(), r["ItemStime"].ToString(), r["ItemEtime"].ToString(), r["Comment"].ToString(), r["ItemStatus"].ToString() });
                }
                r.Close();
            }
            else
            {
                AllWorkItems = null;
            }
            DBConnect.DropConn(con); // drop the connection
            return AllWorkItems;
        }

        public List<string> GetWorkItem(int WorkItemID) // passes paramter workitemid to get the details of specific work item
        {
            this.WorkItem_ID = WorkItemID;
            List<string> details = new List<string>(9); // contains 9 data fields

            SqlConnection con = DBConnect.MakeConn(); // create a new connection

            // Sql sequence to get specific workitem details the caller wants
            SqlCommand GetWorkItemDetails = new SqlCommand
            {
                CommandText = " SELECT * FROM WORKITEM WHERE WorkItem_ID = " + WorkItem_ID,
                CommandType = CommandType.Text,
                Connection = con
            };

            SqlDataReader r = GetWorkItemDetails.ExecuteReader();

            if (!r.HasRows)
            {
                details = null;
            }
            else 
            {
                while (r.Read())
                {
                    details.Add(r["WorkItem_ID"].ToString()); // Add work item id  to list index position 0
                    details.Add(r["Client_ID"].ToString()); // Add client id to list index position 1
                    details.Add(r["Task_ID"].ToString()); // Add task id to list index position 2
                    details.Add(r["Staff_ID"].ToString()); // Add staff id to list index position 3
                    details.Add(r["Date"].ToString()); 
                    details.Add(r["ItemStime"].ToString()); 
                    details.Add(r["ItemEtime"].ToString()); 
                    details.Add(r["Comment"].ToString()); 
                    details.Add(r["ItemStatus"].ToString()); 

                }

            }

            DBConnect.DropConn(con); // drop the connection
            return details;

        }

        public string UpdateWorkItem(NameValueCollection UpdateWrkItemData)
        {
            this.WorkItem_ID = Convert.ToInt32(UpdateWrkItemData["CtrlWorkItemID"]);
            this.Client_ID = Convert.ToInt32(UpdateWrkItemData["CtrlClientID"]);
            this.Task_ID = Convert.ToInt32(UpdateWrkItemData["CtrlTaskID"]);
            this.Staff_ID = Convert.ToInt32(UpdateWrkItemData["CtrlStaffID"]);
            this.Date = UpdateWrkItemData["CtrlDate"];
            this.ItemStime = UpdateWrkItemData["CtrlItemStime"];
            this.ItemEtime = UpdateWrkItemData["CtrlItemEtime"];
            this.Comment = UpdateWrkItemData["CtrlComment"];
            this.ItemStatus = UpdateWrkItemData["CtrlStatus"];

            SqlConnection con = DBConnect.MakeConn(); // create a new connection

            SqlCommand UpdateWorkItem = new SqlCommand // sql command to update work item
            {
                CommandText = "UPDATE WORKITEM SET Client_ID='" +
                Client_ID + "', Task_ID='" + Task_ID + "',Staff_ID='" +
                Staff_ID + "',Date='" + Date + "',ItemStime='" + ItemStime +
                "',ItemEtime='" + ItemEtime + "',Comment='" + Comment + "',ItemStatus='" + ItemStatus + "' WHERE WorkItem_ID = " + WorkItem_ID,
                CommandType = CommandType.Text,
                Connection = con // the connection to be used is con
            };

            if (con.State == ConnectionState.Open)
            {
                int a = UpdateWorkItem.ExecuteNonQuery();
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

        public string DeleteWorkItem(int WorkItemID) // paramter workitemid passed to delete specific work item
        {
            this.WorkItem_ID = WorkItemID;

            SqlConnection con = DBConnect.MakeConn(); // create connection

            SqlCommand DeleteWorkItem = new SqlCommand // create new sql command to delete work item corresponding to the id passed
            {
                CommandText = "DELETE FROM WORKITEM WHERE WorkItem_ID = " + WorkItem_ID,
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int a = DeleteWorkItem.ExecuteNonQuery();
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