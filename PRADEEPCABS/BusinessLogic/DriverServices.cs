using PRADEEPCABS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Web;


namespace PRADEEPCABS.BusinessLogic
{
    public class DriverServices
    {
        private string connString = ConfigurationManager.ConnectionStrings["PCDB"].ToString();
        public bool SaveDriver(DriverDto driver)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                var query = "insert into pc_drivers(vehicletype,licenseno,typeoflicense,carno,firstname,address,city,state,phoneno,fareforkilometer,password,username,lastname) values(@vehicletype,@licenseno,@typeoflicense,@carno,@firstname,@address,@city,@state,@phoneno,@fareforkilometer,@password,@username,@lastname)";
                //var query = "insert into pc_drivers(vehicletype,licenseno,typeoflicense,carno,firstname,address,city,state,phoneno,fareforkilometer,password,username,lastname) values(@vehicletype,@licenseno,@typeoflicense,@carno,@name,@address,@city,@state,@phoneno,@fareforkilometer,@password,@uname,@lname)";
                //SqlCommand comm = new SqlCommand(query, conn);
                //comm.Parameters.AddWithValue("@name", driver.Firstname);               
                //comm.Parameters.AddWithValue("@vehicletype", driver.Vehicletype);
                //comm.Parameters.AddWithValue("@licenseno", driver.Licenseno);
                //comm.Parameters.AddWithValue("@typeoflicense", driver.Typeoflicense);
                //comm.Parameters.AddWithValue("@carno", driver.Carno);
                //comm.Parameters.AddWithValue("@address", driver.Address);
                //comm.Parameters.AddWithValue("@city", driver.City);
                //comm.Parameters.AddWithValue("@state", driver.State);
                //comm.Parameters.AddWithValue("@phoneno", driver.Phoneno);
                //comm.Parameters.AddWithValue("@fareforkilometer", driver.Fareforkilometer);
                //comm.Parameters.AddWithValue("@password", driver.Password);
                //comm.Parameters.AddWithValue("@uname", driver.Username);
                //comm.Parameters.AddWithValue("@lname", driver.Lastname);
                var result = conn.Query<DriverDto>(query,driver);

                if (result !=null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public DriverDto Login(string dname, string pwd)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                var query = "select * from PC_Drivers where username=@dname and password=@pwd";
                //var query = "select * from PC_Customers where username=@dname and password=@pwd";
                //SqlCommand comm = new SqlCommand(query, conn);
                //comm.Parameters.AddWithValue("@dname", cname);
                //comm.Parameters.AddWithValue("@pwd", pwd);
                //var result = comm.ExecuteReader();
                var result = conn.Query<DriverDto>(query, param: new { dname = dname, pwd = pwd });
                if (result != null)
                {
                    return result.ToList()[0];
                }
                else
                {
                    return new DriverDto();
                }
            }
        }
        public List<DriverDto> GetDrivers()
        {
            List<DriverDto> drivers = new List<DriverDto>();
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                drivers = conn.Query<DriverDto>("select * from PC_Drivers").ToList();

            }
                
            return drivers;
        }
        public bool DeleteDriver(int driverId)
        {
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                var driver = conn.Query("delete from PC_Bookings where DriverId = @driverId;delete from PC_Drivers where DriverId = @driverId", param: new { driverId = driverId }).ToList();
                if (driver != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public List<DriverDto> GetLogin(string username, string password)
        {
            List<DriverDto> driver = new List<DriverDto>();
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                driver = conn.Query<DriverDto>("select * from PC_Drivers where username=@username and password=@password", param: new { username = username, password = password }).ToList();
                return driver;
            }
        }
    }
}