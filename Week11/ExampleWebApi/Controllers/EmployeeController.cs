using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;

namespace ExampleWebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        static string testvalue = "Julian";
        static string testvalue2 = "Assange";
        static int testvalue3 = 4;

        // GET: api/Employee
        public IEnumerable<string> Get()
        {

            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            SqlDataReader rdr;
            String query;
            List<String> output = new List<string>();

            try
            {
                conn.Open();


                query = "select * from employee";
                cmd = new SqlCommand(query, conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    output.Add("{staffid: " + rdr.GetValue(0)
                                 + ", givenname: \"" + rdr.GetValue(1) + "\""
                                 + ", surname: \"" + rdr.GetValue(2) + "\"}");
                }

            }
            catch(Exception e)
            {
                output.Clear();
                output.Add(e.Message);
                
            }
            finally
            {
                if(conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return output;
        }

        // GET: api/Employee/5
        public string Get(int id)
        {

            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            SqlDataReader rdr;
            String query;
            String output = "";

            try
            {
                conn.Open();


                query = "select * from employee where staffid =" + id;
                cmd = new SqlCommand(query, conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    output = output + "{staffid: " + rdr.GetValue(0)
                                 + ", givenname: \"" + rdr.GetValue(1) + "\""
                                 + ", surname: \"" + rdr.GetValue(2) + "\"}";
                }

            }
            catch (Exception e)
            {
                output = "";
                output = output + e.Message;

            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return output;
        }

        // POST: api/Employee
        public void Post([FromBody]string value)
        {

            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            SqlDataAdapter rda;
            String query;
            String output = "";

            try
            {
                conn.Open();


                query = "Insert into employee (staffid,givenname,surname) values('" + testvalue3 + "', '" + testvalue + "'," + testvalue2 + "' )";
                cmd = new SqlCommand(query, conn);
                rda = new SqlDataAdapter();

                rda.InsertCommand = new SqlCommand(query, conn);
                rda.InsertCommand.ExecuteNonQuery();


            }
            catch (Exception e)
            {
                output = "";
                output = output + e.Message;

            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }

        }

        // PUT: api/Employee/5
        public void Put(int id, [FromBody]string value)
        {
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            SqlDataAdapter rda;
            String query;

            string output = "";

            try
            {
                conn.Open();


                query = "Update employee set givenname='" + testvalue + "', surname='" + testvalue2 + "' where staffid=" +id;
                cmd = new SqlCommand(query, conn);
                rda = new SqlDataAdapter();

                rda.UpdateCommand = new SqlCommand(query, conn);
                rda.UpdateCommand.ExecuteNonQuery();

                output = "Query Complete";


            }
            catch (Exception e)
            {
                output = "";
                output = output + e.Message;

            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }

        }

        // DELETE: api/Employee/5
        public void Delete(int id)
        {
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            SqlDataAdapter rda;
            String query;

            string output = "";

            try
            {
                conn.Open();


                query = "delete employee where staffid=" + id;
                cmd = new SqlCommand(query, conn);
                rda = new SqlDataAdapter();

                rda.DeleteCommand = new SqlCommand(query, conn);
                rda.DeleteCommand.ExecuteNonQuery();

                output = "Employee Deletion Complete";


            }
            catch (Exception e)
            {
                output = "";
                output = output + e.Message;

            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}
