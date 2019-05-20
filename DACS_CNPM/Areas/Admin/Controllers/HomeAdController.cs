using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DACS_CNPM.Areas.Admin.Controllers
{
    public class HomeAdController : Controller
    {
        // GET: Admin/HomeAd
        public ActionResult IndexAd()
        {
            return View();
        }

        // GET: Admin/HomeAd/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/HomeAd/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/HomeAd/Create
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

        // GET: Admin/HomeAd/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/HomeAd/Edit/5
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

        // GET: Admin/HomeAd/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/HomeAd/Delete/5
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
