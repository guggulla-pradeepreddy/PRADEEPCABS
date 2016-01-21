using PRADEEPCABS.BusinessLogic;
using PRADEEPCABS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRADEEPCABS.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult Create(int driverId,int customerId)
        {
            ViewBag.DriverId = driverId;
            ViewBag.CustomerId = customerId;
            return View();
        }

        public ActionResult Bookings(int userId = 0)
        {

            return View();
        }

        [HttpPost]
        public ActionResult Book(FormCollection frm)
        {
            BookingDto booking = new BookingDto();
            booking.ToD = frm["to"];
            booking.FromD = frm["from"];
            booking.Distance = 553;
            booking.Totalfare = booking.Distance * 5;
            booking.Driverid = Convert.ToInt16(frm["driverId"]);
            booking.CustomerId = Convert.ToInt16(frm["customerId"]);
            booking.Vehicletype = frm["vehicleType"];
            booking.Date = DateTime.Now;
            var result = new BookingServices().SaveBookings(booking);
            ViewBag.Message = "booking successful";
            return View("Index");
        }
    }
}