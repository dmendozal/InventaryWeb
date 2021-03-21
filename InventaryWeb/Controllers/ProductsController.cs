using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using InventaryWeb.DALContext;
using InventaryWeb.Models;
using QRCoder;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Http;

namespace InventaryWeb.Controllers
{
    public class ProductsController : Controller
    {
        private InventaryContext db = new InventaryContext();

        // GET: Products
        public ActionResult Index()
        {
            var product = db.Product.Include(p => p.Category).Include(p => p.Provider).Include(p => p.Unit);
            return View(product.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Category, "Id", "Name");
            ViewBag.ProviderID = new SelectList(db.Provider, "Id", "Name");
            ViewBag.UnitID = new SelectList(db.Unit, "Id", "Description");
            return View();
        }

        // POST: Products/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Name,Description,Stock,PurchasePrice,SalePrice,MainImage,ExpirationTime,UnitID,CategoryID,ProviderID")] Product product)
        {
            string fileName = Guid.NewGuid() + ".jpg";
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            if (ModelState.IsValid)
            {
                //string data ="Producto: " + product.Name + "\n" + "Cantidad: "+ product.Stock;
                QRCodeData qrCodeData = qrGenerator.CreateQrCode("vacio", QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20);
                var folder = "..\\Qrs\\";
                var Route = folder + fileName;
                var path = System.Web.HttpContext.Current.Server.MapPath(folder);
                qrCodeImage.Save(path + fileName, ImageFormat.Jpeg);
                product.CodeQR = Route;
                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Category, "Id", "Name", product.CategoryID);
            ViewBag.ProviderID = new SelectList(db.Provider, "Id", "Name", product.ProviderID);
            ViewBag.UnitID = new SelectList(db.Unit, "Id", "Description", product.UnitID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Category, "Id", "Name", product.CategoryID);
            ViewBag.ProviderID = new SelectList(db.Provider, "Id", "Ci", product.ProviderID);
            ViewBag.UnitID = new SelectList(db.Unit, "Id", "Description", product.UnitID);
            return View(product);
        }

        // POST: Products/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Name,Description,Stock,PurchasePrice,SalePrice,MainImage,ExpirationTime,UnitID,CategoryID,ProviderID")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Category, "Id", "Name", product.CategoryID);
            ViewBag.ProviderID = new SelectList(db.Provider, "Id", "Ci", product.ProviderID);
            ViewBag.UnitID = new SelectList(db.Unit, "Id", "Description", product.UnitID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Product.Find(id);
            db.Product.Remove(product);
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

        public JsonResult getQrCode()
        {
            
            string fileName = Guid.NewGuid() + ".jpg";
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(fileName, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            var folder = "..\\Qrs\\";
            var Route = folder + fileName;
            var path = System.Web.HttpContext.Current.Server.MapPath(folder);
            qrCodeImage.Save(path + fileName, ImageFormat.Jpeg);
            

            return Json("hs",JsonRequestBehavior.AllowGet);
        }
        public int Sum(int a, int b)
        {
            return a + b;
        }
        public int ProductIndex()
        {
            return db.Product.ToList().Count();
        }
        public int ProductWithAmount()
        {
            var product = db.Product;
            return product.ToList().Max(p => p.Stock);
        }


    }
}
