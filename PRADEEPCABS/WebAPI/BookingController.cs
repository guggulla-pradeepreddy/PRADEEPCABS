using PRADEEPCABS.BusinessLogic;
using PRADEEPCABS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PRADEEPCABS.WebAPI
{
    [RoutePrefix("api/bookings")]
    public partial class BookingController : ApiController
    {
        private BookingServices _bookingServices = new BookingServices();            
        [HttpGet]
        [Route("get-bookings")]
        public List<BookingDto> GetBookings(int userId)
        {
            List<BookingDto> bookings = new List<BookingDto>();
            bookings = _bookingServices.GetBookings(userId);
            return bookings;
        }

        [HttpGet]
        [Route("get-bookings-bydriver")]
        public List<BookingDto> GetBookingsByDriver(int driverId)
        {
            List<BookingDto> bookings = new List<BookingDto>();
            bookings = _bookingServices.GetBookingsByDriver(driverId);
            return bookings;
        }

        [HttpGet]
        [Route("get-booking")]
        public BookingDto GetBooking(int bookingId)
        {
            List<BookingDto> bookings = new List<BookingDto>();
            bookings = _bookingServices.GetBookings();
            var booking = bookings.FirstOrDefault(b => b.BookingId == bookingId);
            if (booking == null)
            {
                return new BookingDto();
            }
            return booking;
        }

        [HttpPost]
        [Route("post-booking")]
        public bool SaveBooking(BookingDto booking)
        {
            var response = _bookingServices.SaveBookings(booking);
            return response;
        }
        [HttpGet]
        [Route("delete-booking")]
        public bool DeleteBooking(int bookingId)
        {
            var response = _bookingServices.DeleteBooking(bookingId);
            return response;
        }
    }
}
