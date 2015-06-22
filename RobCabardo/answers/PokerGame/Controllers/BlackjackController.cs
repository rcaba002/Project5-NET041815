using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokerGame.Controllers
{
    public class BlackjackController : Controller
    {
        // GET: Blackjack
        public ActionResult Welcome()
        {
            return View();
        }

        // GET: Blackjack/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Blackjack/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blackjack/Create
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

        // GET: Blackjack/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Blackjack/Edit/5
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

        // GET: Blackjack/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Blackjack/Delete/5
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
