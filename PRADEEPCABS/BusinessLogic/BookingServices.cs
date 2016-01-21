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
    public class BookingServices
    {
        private string connString = ConfigurationManager.ConnectionStrings["PCDB"].ToString();


        public bool SaveBookings(BookingDto booking)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                booking.Date = DateTime.Now;
                conn.Open();
                var query = "insert into pc_bookings(driverid,customerid,date,fromd,tod,distance,totalfare,vehicletype) values(@driverid,@customerid,@date,@fromd,@tod,@distance,@totalfare,@vehicletype)";
                
                //var query = "insert into pc_bookings(driverid,customerid,date,fromd,tod,distance,totalfare,vehicletype) values(@driverid,@customerid,@date,@from,@to,@distance,@totalfare,@vehicletype)";
                //SqlCommand comm = new SqlCommand(query, conn);
                //comm.Parameters.AddWithValue("@driverid", booking.Driverid);
                //comm.Parameters.AddWithValue("@customerid", booking.CustomerId);
                //comm.Parameters.AddWithValue("@date", booking.Date);
                //comm.Parameters.AddWithValue("@from", booking.FromD);
                //comm.Parameters.AddWithValue("@to", booking.ToD);
                //comm.Parameters.AddWithValue("@distance", booking.Distance);
                //comm.Parameters.AddWithValue("@totalfare", booking.Totalfare);
                //comm.Parameters.AddWithValue("@vehicletype", booking.Vehicletype);
                var result = conn.Query<BookingDto>(query,booking);

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
        public List<BookingDto> GetBookings(int userId=0)
        {
           List<BookingDto> booking=new List<BookingDto> ();
             using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                 if(userId == 0)
                 {
                     booking = conn.Query<BookingDto>("select * from PC_bookings").ToList();

                 }
                 else
                 {
                     booking = conn.Query<BookingDto>("select * from PC_bookings where CustomerId = @userId", param: new { userId = userId }).ToList();

                 }
                
            }
                
            return booking;

        }

        public bool DeleteBooking(int bookingId)
        {
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                var booking = conn.Query<BookingDto>("delete from PC_bookings where BookingId = @bookingId", param: new { bookingId = bookingId }).ToList();
                if (booking != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }                   
            }
        }

        public List<BookingDto> GetBookingsByDriver(int driverId)
        {
            using(var conn=new SqlConnection(connString))
            {
                conn.Open();
                var bookings = conn.Query<BookingDto>("select * from PC_bookings where driverId=@driverId", param: new { driverId = driverId }).ToList();
                return bookings;
            }
        }
        }

       
    }

