using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventaryWeb.DALContext;
using InventaryWeb.Models;

namespace InventaryWeb.Controllers
{
    public class EntryDetailsController : Controller
    {
        private InventaryContext db = new InventaryContext();

        // GET: EntryDetails
        public ActionResult Index()
        {
            var entryDetails = db.EntryDetails.Include(e => e.EntryNote).Include(e => e.Product);
            return View(entryDetails.ToList());
        }

        // GET: EntryDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntryDetails entryDetails = db.EntryDetails.Find(id);
            if (entryDetails == null)
            {
                return HttpNotFound();
            }
            return View(entryDetails);
        }

        // GET: EntryDetails/Create
        public ActionResult Create()
        {
            ViewBag.EntryNoteID = new SelectList(db.EntryNote, "Id", "Id");
            ViewBag.ProductID = new SelectList(db.Product, "Id", "Code");
            return View();
        }

        // POST: EntryDetails/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Amount,Price,Subtotal,ProductID,EntryNoteID")] EntryDetails entryDetails)
        {
            if (ModelState.IsValid)
            {
                db.EntryDetails.Add(entryDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EntryNoteID = new SelectList(db.EntryNote, "Id", "Id", entryDetails.EntryNoteID);
            ViewBag.ProductID = new SelectList(db.Product, "Id", "Code", entryDetails.ProductID);
            return View(entryDetails);
        }

        // GET: EntryDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntryDetails entryDetails = db.EntryDetails.Find(id);
            if (entryDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.EntryNoteID = new SelectList(db.EntryNote, "Id", "Id", entryDetails.EntryNoteID);
            ViewBag.ProductID = new SelectList(db.Product, "Id", "Code", entryDetails.ProductID);
            return View(entryDetails);
        }

        // POST: EntryDetails/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Amount,Price,Subtotal,ProductID,EntryNoteID")] EntryDetails entryDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entryDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EntryNoteID = new SelectList(db.EntryNote, "Id", "Id", entryDetails.EntryNoteID);
            ViewBag.ProductID = new SelectList(db.Product, "Id", "Code", entryDetails.ProductID);
            return View(entryDetails);
        }

        // GET: EntryDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntryDetails entryDetails = db.EntryDetails.Find(id);
            if (entryDetails == null)
            {
                return HttpNotFound();
            }
            return View(entryDetails);
        }

        // POST: EntryDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EntryDetails entryDetails = db.EntryDetails.Find(id);
            db.EntryDetails.Remove(entryDetails);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
