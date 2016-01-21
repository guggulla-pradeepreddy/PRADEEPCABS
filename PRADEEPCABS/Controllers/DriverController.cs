using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PRADEEPCABS.Models;
using PRADEEPCABS.BusinessLogic;

namespace PRADEEPCABS.Controllers
{
    public class DriverController : Controller
    {
        // GET: Drivers
        public ActionResult Index()
        {
            return View();
        }
        
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            string dname = form["dname"];
            string pwd = form["pwd"];
            var result = new DriverServices().Login(dname, pwd);
            if (result.Driverid > 0)
            {
                Session["driverId"] = result.Driverid;
                return RedirectToAction("Bookings");
            }
            else
            {
                ViewBag.Message = "User does not exist";
                return View();
            }
        }

        public ActionResult LogOff()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(FormCollection frm)
        {
            DriverDto driver = new DriverDto();
            driver.Carno = frm["carnumber"];
            driver.Address = frm["address"];
            driver.City = frm["city"];
            driver.Fareforkilometer = Convert.ToInt32(frm["fareforkilometer"]);
            driver.Licenseno = Convert.ToInt32(frm["licenseno"]);
            driver.Firstname = frm["fname"];
            driver.Lastname = frm["lname"];
            driver.Username = frm["uname"];
            driver.Password = frm["password"];
            driver.Phoneno = frm["phonenumber"];
            driver.State = frm["state"];
            driver.Typeoflicense = frm["licensetype"];
            driver.Vehicletype = frm["vehicletype"];
            DriverServices ds = new DriverServices();
            ds.SaveDriver(driver);
            return View();
        }

        public ActionResult Bookings()
        {
            //int driverId = Convert.ToInt32(Session["driverId"]);
           // ViewBag.Bookings = new BookingServices().GetbookingsByDriver(driverId);
            return View();
        }
    }
}