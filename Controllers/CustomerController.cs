using WebApplication6.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Data.Entity.Infrastructure;

namespace WebApplication6.Controllers
{
    public class CustomerController : Controller
    {
        private dotnetmvc_demoEntities context = new dotnetmvc_demoEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Detsils of  Customers
        public ActionResult List()
        {
            //var context = new dotnetmvc_demoEntities();
            return View(context.customers.ToList());
        }
        
        // GET: List of a single Customers
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //var context = new dotnetmvc_demoEntities();
            var customer = context.customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //Edit a single customer
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //var context = new dotnetmvc_demoEntities();
            var customer = context.customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            //PopulateDepartmentsDropDownList(customer.CustomerId);
            return View(customer);
        }

        //updating a customer
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
          //  var context = new dotnetmvc_demoEntities();
            var customerToUpdate = context.customers.Find(id);
            if (TryUpdateModel(customerToUpdate, "",
               new string[] { "Name", "Country", "CustomerId" }))
            {
                try
                {
                    context.SaveChanges();

                    return RedirectToAction("List");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
           // PopulateDepartmentsDropDownList(courseToUpdate.DepartmentID);
            return View(customerToUpdate);
        }


        [HttpPost]
        public ActionResult Index(customer customer)
        {
           using (dotnetmvc_demoEntities entities = new dotnetmvc_demoEntities())
            {
                entities.customers.Add(customer);
                entities.SaveChanges();
                int CustomerId = customer.CustomerId;
            }
            return View("Index");

        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        //    var context = new dotnetmvc_demoEntities();
            var customer = context.customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customer/Delete/5 delete a specific customer

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
        //    var context = new dotnetmvc_demoEntities();
            var customer = context.customers.Find(id);
            context.customers.Remove(customer);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}