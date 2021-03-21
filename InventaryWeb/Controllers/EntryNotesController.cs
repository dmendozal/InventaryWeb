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
    public class EntryNotesController : Controller
    {
        private InventaryContext db = new InventaryContext();

        // GET: EntryNotes
        public ActionResult Index()
        {
            var entryNote = db.EntryNote.Include(e => e.User);
            return View(entryNote.ToList());
        }

        // GET: EntryNotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntryNote entryNote = db.EntryNote.Find(id);
            if (entryNote == null)
            {
                return HttpNotFound();
            }
            return View(entryNote);
        }

        // GET: EntryNotes/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.User, "Id", "Username");
            return View();
        }

        // POST: EntryNotes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Total,UserID")] EntryNote entryNote)
        {
            if (ModelState.IsValid)
            {
                db.EntryNote.Add(entryNote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.User, "Id", "Username", entryNote.UserID);
            return View(entryNote);
        }

        // GET: EntryNotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntryNote entryNote = db.EntryNote.Find(id);
            if (entryNote == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.User, "Id", "Username", entryNote.UserID);
            return View(entryNote);
        }

        // POST: EntryNotes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Total,UserID")] EntryNote entryNote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entryNote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.User, "Id", "Username", entryNote.UserID);
            return View(entryNote);
        }

        // GET: EntryNotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntryNote entryNote = db.EntryNote.Find(id);
            if (entryNote == null)
            {
                return HttpNotFound();
            }
            return View(entryNote);
        }

        // POST: EntryNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EntryNote entryNote = db.EntryNote.Find(id);
            db.EntryNote.Remove(entryNote);
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
