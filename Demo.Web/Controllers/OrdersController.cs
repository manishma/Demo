using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Data;
using Demo.Domain;

namespace Demo.Web.Controllers
{
    public class OrdersController : Controller
    {
        //
        // GET: /Orders/

        public ActionResult ByUser(int id)
        {
            var orders = SessionManager.CurrentSession.QueryOver<Order>()
                .Where(x => x.Customer.Id == id)
                .List();

            return View(orders);
        }

        //
        // GET: /Orders/Details/5

        public ActionResult Details(int id)
        {
            var order = SessionManager.CurrentSession.Get<Order>(id);

            return View(order);
        }

        //
        // GET: /Orders/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Orders/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Orders/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Orders/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Orders/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Orders/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
