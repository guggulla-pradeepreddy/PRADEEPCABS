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
    
    [RoutePrefix("api/customers")]
    public partial class CustomerController : ApiController
    {
        private CustomerServices _customerServices = new CustomerServices();            
        [HttpGet]
        [Route("get-customers")]
        public List<CustomerDto> GetCustomers(int userId)
        {
            List<CustomerDto> customers = new List<CustomerDto>();
            customers = _customerServices.GetCustomers(userId);
            return customers;
        }

        [HttpGet]
        [Route("get-customer")]
        public CustomerDto Getcustomer(int customerId)
        {
            List<CustomerDto> customer = new List<CustomerDto>();
            customer = _customerServices.GetCustomers();
            var Customer = customer.FirstOrDefault(p => p.CustomerId == customerId);
            if (customer == null)
            {
                return new CustomerDto();
            }
            return Customer;
        }

        [HttpPost]
        [Route("post-customer")]
        public bool SaveCustomer(CustomerDto customer)
        {
            var response = _customerServices.Savecustomer(customer);
            return response;
        }
        [HttpGet]
        [Route("delete-customer")]
        public bool DeleteCustomer(int customerId)
        {
            var response = _customerServices.DeleteCustomer(customerId);
            return response;
        }
        [HttpGet]
        public List<CustomerDto>GetLogin(string username,string password)
        {
            var response = _customerServices.GetLogin(username, password);
            return response;
        }
    }

 }

