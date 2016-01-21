using PRADEEPCABS.BusinessLogic;
using PRADEEPCABS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRADEEPCABS.Controllers
{
    //[Authorize]
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
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
            string cname = form["cname"];
            string pwd = form["pwd"];
            var result = new CustomerServices().Login(cname, pwd);
            if (result.CustomerId > 0)
            {
                Session["customerId"] = result.CustomerId;
                return RedirectToAction("CabsList");
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

        public ActionResult Home()
        {
            ViewBag.Drivers = new DriverServices().GetDrivers();
            return View();
        }

        public ActionResult CabsList()
        {
            ViewBag.Drivers = new DriverServices().GetDrivers();
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            CustomerDto customer = new CustomerDto();
            customer.Address = form["address"];
            customer.Carddetails = form["carddetais"];
            customer.City = form["city"];
            customer.Country = form["country"];
            customer.Firstname = form["firstname"];
            customer.Lastname = form["lastname"];
            customer.Phoneno = form["phonenumber"];
            customer.State = form["state"];
            customer.Username = form["username"];
            customer.Password = form["password"];
            CustomerServices cs = new CustomerServices();
            cs.Savecustomer(customer);
            return View();
        }
    }
}