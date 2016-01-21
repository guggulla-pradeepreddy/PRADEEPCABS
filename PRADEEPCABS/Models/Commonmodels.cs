using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRADEEPCABS.Models
{
    public class Commonmodels
    {

    }
    public class DriverDto
    {
        public int Driverid { get; set; }
        public string Vehicletype{ get; set; }
        public int Licenseno { get; set; }
        public string Typeoflicense { get; set; }
        public string Carno { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phoneno { get; set; }
        public int Fareforkilometer { get; set; }
    }

    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Phoneno { get; set; }
        public string Carddetails { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class BookingDto
    {
        public int BookingId { get; set; }
        public int Driverid { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public string FromD { get; set; }
        public string ToD { get; set; }
        public int Distance { get; set; }
        public int Totalfare { get; set; }
        public string Vehicletype { get; set; }
    }
}