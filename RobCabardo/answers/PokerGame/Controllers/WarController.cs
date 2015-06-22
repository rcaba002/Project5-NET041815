using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokerGame.Controllers
{
    public class WarController : Controller
    {
        // GET: War
        public ActionResult Welcome()
        {
            return View();
        }

        // GET: War/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: War/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: War/Create
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

        // GET: War/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: War/Edit/5
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

        // GET: War/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: War/Delete/5
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
