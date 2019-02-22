using WebApplication6.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication6.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(customer customer)
        {
           using (dotnetmvc_demoEntities entities = new dotnetmvc_demoEntities())
            {
                entities.customers.Add(customer);
                entities.SaveChanges();
                int id = customer.CustomerId;
            }
            return View("Index");

        }
    }
}