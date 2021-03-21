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
    public class ExitDetailsController : Controller
    {
        private InventaryContext db = new InventaryContext();

        // GET: ExitDetails
        public ActionResult Index()
        {
            var exitDetails = db.ExitDetails.Include(e => e.ExitNote).Include(e => e.Product);
            return View(exitDetails.ToList());
        }

        // GET: ExitDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExitDetails exitDetails = db.ExitDetails.Find(id);
            if (exitDetails == null)
            {
                return HttpNotFound();
            }
            return View(exitDetails);
        }

        // GET: ExitDetails/Create
        public ActionResult Create()
        {
            ViewBag.ExitNoteID = new SelectList(db.ExitNote, "Id", "Id");
            ViewBag.ProductID = new SelectList(db.Product, "Id", "Code");
            return View();
        }

        // POST: ExitDetails/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Amount,Price,Subtotal,ProductID,ExitNoteID")] ExitDetails exitDetails)
        {
            if (ModelState.IsValid)
            {
                db.ExitDetails.Add(exitDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExitNoteID = new SelectList(db.ExitNote, "Id", "Id", exitDetails.ExitNoteID);
            ViewBag.ProductID = new SelectList(db.Product, "Id", "Code", exitDetails.ProductID);
            return View(exitDetails);
        }

        // GET: ExitDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExitDetails exitDetails = db.ExitDetails.Find(id);
            if (exitDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExitNoteID = new SelectList(db.ExitNote, "Id", "Id", exitDetails.ExitNoteID);
            ViewBag.ProductID = new SelectList(db.Product, "Id", "Code", exitDetails.ProductID);
            return View(exitDetails);
        }

        // POST: ExitDetails/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Amount,Price,Subtotal,ProductID,ExitNoteID")] ExitDetails exitDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exitDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExitNoteID = new SelectList(db.ExitNote, "Id", "Id", exitDetails.ExitNoteID);
            ViewBag.ProductID = new SelectList(db.Product, "Id", "Code", exitDetails.ProductID);
            return View(exitDetails);
        }

        // GET: ExitDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExitDetails exitDetails = db.ExitDetails.Find(id);
            if (exitDetails == null)
            {
                return HttpNotFound();
            }
            return View(exitDetails);
        }

        // POST: ExitDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExitDetails exitDetails = db.ExitDetails.Find(id);
            db.ExitDetails.Remove(exitDetails);
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
