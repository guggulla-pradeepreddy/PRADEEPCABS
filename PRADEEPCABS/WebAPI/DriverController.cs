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
    [RoutePrefix("api/drivers")]
    public partial class DriverController : ApiController
    {
        private DriverServices _driverServices = new DriverServices();
       [HttpGet]
        [Route("get-drivers")]
        public List<DriverDto> GetDrivers()
        {
            List<DriverDto> drivers = new List<DriverDto>();
            drivers = _driverServices.GetDrivers();
            return drivers;
        }
        [HttpGet]
        [Route("get-drivers")]
       public DriverDto GetDriver(int driverId)
       {
           List<DriverDto> drivers = new List<DriverDto>();
           drivers = _driverServices.GetDrivers();
           var driver = drivers.FirstOrDefault(p => p.Driverid == driverId);
           if (driver == null)
           {
               return new DriverDto();
           }
           return driver;
       }

        [HttpPost]
        [Route("post-driver")]
        public bool SaveDriver(DriverDto driver)
        {
            var response = _driverServices.SaveDriver(driver);
            return response;
        }
        [HttpGet]
        [Route("delete-driver")]
        public bool DeleteDriver(int driverId)
        {
            var response = _driverServices.DeleteDriver(driverId);
            return response;
        }

        [HttpGet]
        public List<DriverDto> GetLogin(string username, string password)
        {
            var response = _driverServices.GetLogin(username, password);
            return response;
        }
    }

}
