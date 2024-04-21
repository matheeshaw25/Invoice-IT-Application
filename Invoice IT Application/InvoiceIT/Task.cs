using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;

namespace InvoiceIT
{
    public class Task
    {
        public int Task_ID { get; set; }
        public string Task_Title { get; set; }
        public string Task_Desc { get; set; }
        public string Task_Rate { get; set; }
        public string Message { get; set; }



        public string AddTask(NameValueCollection NewTaskData)
        {
            this.Task_Title = NewTaskData["CtrlTaskTitle"]; //holds data passed by from when submitted
            this.Task_Desc = NewTaskData["CtrlTaskDesc"]; 
            this.Task_Rate = NewTaskData["CtrlTaskRate"];

            SqlConnection con = DBConnect.MakeConn(); //create a new connection
            SqlCommand AddTask = new SqlCommand  // create sql command to insert task
            {
                CommandText = "INSERT TASK (Task_Title, Task_Desc, Task_Rate) VALUES ('" + Task_Title + "'," +
                "'" + Task_Desc + "','" + Task_Rate + "')", 
                CommandType = CommandType.Text,
                Connection = con 
            };

            if (con.State == ConnectionState.Open)
            {
                int a = AddTask.ExecuteNonQuery();
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

            DBConnect.DropConn(con); //drop the connection
            return Message;
        }


        public List<List<string>> GetTask() // list to hold data
        {
            SqlConnection con = DBConnect.MakeConn(); // create a new connection

            SqlCommand GetAllTasks = new SqlCommand // sql command to get all the tasks
            {
                CommandText = " SELECT * FROM TASK ",
                CommandType = CommandType.Text,
                Connection = con
            };

            List<List<string>> AllTasks = new List<List<string>>(); //create a new list called AllTasks

            SqlDataReader r = GetAllTasks.ExecuteReader();

            if (r.HasRows) 
            {
                while (r.Read())
                {
                    // Add each record to the list
                    AllTasks.Add(new List<string> { r["Task_ID"].ToString(), r["Task_Title"].ToString(), r["Task_Desc"].ToString(), r["Task_Rate"].ToString() });
                }
                r.Close();
            }
            else
            {
                AllTasks = null; 
            }
            DBConnect.DropConn(con); //drop the connection
            return AllTasks;
        }

        public List<string> GetTask(int TaskID) // parameter to get specific task 
        {
            this.Task_ID = TaskID;
            List<string> details = new List<string>(4);// to hold the data 

            //create connection to the DB                                           
            SqlConnection con = DBConnect.MakeConn();

            // Sql sequence to get specific task details the caller wants
            SqlCommand GetTaskDetails = new SqlCommand
            {
                CommandText = " SELECT * FROM TASK WHERE Task_ID = " + Task_ID,
                CommandType = CommandType.Text,
                Connection = con
            };

            SqlDataReader r = GetTaskDetails.ExecuteReader(); // to get the above details (r will contains the details in a specific task)

            if (!r.HasRows)
            {
                details = null;
            }
            else
            {
                while (r.Read())
                {
                    details.Add(r["Task_ID"].ToString()); // Add task id to list index position 0
                    details.Add(r["Task_Title"].ToString()); // Add task title to list index position 1
                    details.Add(r["Task_Desc"].ToString()); // Add task description to list index position 2
                    details.Add(r["Task_Rate"].ToString()); // Add task rate to list index position 3
                    
                }

            }

            DBConnect.DropConn(con); // drop the connection
            return details;
        }

        public string UpdateTask(NameValueCollection UpdateTskData) // updates a task
        {
            this.Task_ID = Convert.ToInt32(UpdateTskData["CtrlTaskID"]); 
            this.Task_Title = UpdateTskData["CtrlTaskTitle"];
            this.Task_Desc = UpdateTskData["CtrlTaskDesc"];
            this.Task_Rate = UpdateTskData["CtrlTaskRate"];

            SqlConnection con = DBConnect.MakeConn(); //create a new connection

            SqlCommand UpdateTask = new SqlCommand // sql command to update task
            {
                CommandText = "UPDATE TASK SET Task_Title='" + Task_Title + "', Task_Desc='" +
                Task_Desc + "', Task_Rate='" + Task_Rate + "' WHERE Task_ID = " + Task_ID,
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int a = UpdateTask.ExecuteNonQuery();
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
        public string DeleteTask(int TaskID) // deletes the specific task that corresponds to the ID
        {
            this.Task_ID = TaskID;


            SqlConnection con = DBConnect.MakeConn(); // create a new connection

            SqlCommand DeleteTask = new SqlCommand // sql command to delete task
            {
                CommandText = "DELETE FROM TASK WHERE Task_ID = " + Task_ID,
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int a = DeleteTask.ExecuteNonQuery();
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