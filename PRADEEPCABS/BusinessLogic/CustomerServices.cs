using PRADEEPCABS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Web;

namespace PRADEEPCABS.BusinessLogic
{
    public class CustomerServices
    {
        private string connString = ConfigurationManager.ConnectionStrings["PCDB"].ToString();
        public bool Savecustomer(CustomerDto customer)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                var query = "insert into pc_customers(firstname,lastname,address,city,state,country,phoneno,carddetails,username,password) values(@firstname,@lastname,@address,@city,@state,@country,@phoneno,@carddetails,@username,@password)";
                // var query = "insert into pc_customers(firstname,lastname,address,city,state,country,phoneno,carddetails,username,password) values(@firstname,@lastname,@address,@city,@state,@country,@phoneno,@carddetails,@username,@password)";
                //SqlCommand comm = new SqlCommand(query, conn);
                //comm.Parameters.AddWithValue("@firstname", customer.Firstname);
                //comm.Parameters.AddWithValue("@lastname", customer.Lastname);
                //comm.Parameters.AddWithValue("@address", customer.Address);
                //comm.Parameters.AddWithValue("@city", customer.City);
                //comm.Parameters.AddWithValue("@state", customer.State);
                //comm.Parameters.AddWithValue("@country", customer.Country);
                //comm.Parameters.AddWithValue("@phoneno", customer.Phoneno);
                //comm.Parameters.AddWithValue("@carddetails", customer.Carddetails);
                //comm.Parameters.AddWithValue("@username", customer.Username);
                //comm.Parameters.AddWithValue("@password", customer.Password);
                var result = conn.Query<CustomerDto>(query,customer);

                if (result != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public CustomerDto Login(string cname,string pwd)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                var query = "select * from PC_Customers where username=@cname and password=@pwd";
                //var query = "select * from PC_Customers where username=@cname and password=@pwd";
                //SqlCommand comm = new SqlCommand(query, conn);
                //comm.Parameters.AddWithValue("@cname", cname);
                //comm.Parameters.AddWithValue("@pwd", pwd);
                //var result = comm.ExecuteReader();
                var result = conn.Query<CustomerDto>(query, param: new { cname = cname,pwd = pwd});
                if (result != null)
                {
                    return result.ToList()[0];
                }
                else
                {
                    return new CustomerDto();
                }
            }
        }
        public List<CustomerDto> GetCustomers(int userId = 0)
        {
            List<CustomerDto> customer = new List<CustomerDto>();
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                customer = conn.Query<CustomerDto>("select * from PC_customers").ToList();

            }

            return customer;

        }

        public bool DeleteCustomer(int customerId)
        {
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                var customer = conn.Query("delete from PC_Customers where CustomerId = @customerId", param: new {customerId = customerId }).ToList();
                if (customer != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public List<CustomerDto> GetLogin(string username, string password)
        {
            List<CustomerDto> customer = new List<CustomerDto>();
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                customer = conn.Query<CustomerDto>("select * from PC_Customers where username=@username and password=@password", param: new { username = username, password = password }).ToList();
                return customer;
            }
        }
    }
}