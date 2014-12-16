using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.Web.WebPages.OAuth;
using Firma.Models;
using WebMatrix.WebData;

namespace Firma.Controllers
{
    public class KlienciController : Controller
    {
        private FirmaContext db = new FirmaContext();

        //
        // GET: /Klienci/

        public ActionResult Index()
        {
            return View(db.Klients.ToList());
        }

        //
        // GET: /Klienci/Details/5

        public ActionResult Details(int id = 0)
        {
            Klient klient = db.Klients.Find(id);
            if (klient == null)
            {
                return HttpNotFound();
            }
            return View(klient);
        }

        //
        // GET: /Klienci/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Klienci/Create

        [HttpPost]
        public ActionResult Create(Klient klient)
        {
            if (ModelState.IsValid)
            {
                db.Klients.Add(klient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(klient);
        }

        //
        // GET: /Klienci/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Klient klient = db.Klients.Find(id);
            if (klient == null)
            {
                return HttpNotFound();
            }
            return View(klient);
        }

        //
        // POST: /Klienci/Edit/5

        [HttpPost]
        public ActionResult Edit(Klient klient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(klient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(klient);
        }

        //
        // GET: /Klienci/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Klient klient = db.Klients.Find(id);
            if (klient == null)
            {
                return HttpNotFound();
            }
            return View(klient);
        }

        //
        // POST: /Klienci/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Klient klient = db.Klients.Find(id);
            db.Klients.Remove(klient);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}