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
    public class ExitNotesController : Controller
    {
        private InventaryContext db = new InventaryContext();

        // GET: ExitNotes
        public ActionResult Index()
        {
            var exitNote = db.ExitNote.Include(e => e.User);
            return View(exitNote.ToList());
        }

        // GET: ExitNotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExitNote exitNote = db.ExitNote.Find(id);
            if (exitNote == null)
            {
                return HttpNotFound();
            }
            return View(exitNote);
        }

        // GET: ExitNotes/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.User, "Id", "Username");
            return View();
        }

        // POST: ExitNotes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Total,UserID")] ExitNote exitNote)
        {
            if (ModelState.IsValid)
            {
                db.ExitNote.Add(exitNote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.User, "Id", "Username", exitNote.UserID);
            return View(exitNote);
        }

        // GET: ExitNotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExitNote exitNote = db.ExitNote.Find(id);
            if (exitNote == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.User, "Id", "Username", exitNote.UserID);
            return View(exitNote);
        }

        // POST: ExitNotes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Total,UserID")] ExitNote exitNote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exitNote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.User, "Id", "Username", exitNote.UserID);
            return View(exitNote);
        }

        // GET: ExitNotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExitNote exitNote = db.ExitNote.Find(id);
            if (exitNote == null)
            {
                return HttpNotFound();
            }
            return View(exitNote);
        }

        // POST: ExitNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExitNote exitNote = db.ExitNote.Find(id);
            db.ExitNote.Remove(exitNote);
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
