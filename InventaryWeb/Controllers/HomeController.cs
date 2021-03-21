using InventaryWeb.DALContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using InventaryWeb.Models;

namespace InventaryWeb.Controllers
{
    public class HomeController : Controller
    {
        private InventaryContext db = new InventaryContext();
        public ActionResult Index()
        {
            var product = db.Product;
            var test1 = product.ToList().OrderByDescending(p => p.ExpirationTime);
            var test2 = product.ToList().OrderBy(p => p.ExpirationTime);
            //var prd = db.Product;
            //var test = prd.SqlQuery("SELECT * from dbo.Products where CategoryID = 1").ToList();
            //var tes2 = test[0];
            //ViewBag.Contact = db.Contact.ToList();
            return View(product.ToList().OrderByDescending(p => p.ExpirationTime));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public int OldestProducts()
        {
            Product product = db.Product.OrderByDescending(p => p.ExpirationTime).First();
            return product.Id;
        }
        public int NewProduct()
        {
            Product product = db.Product.OrderBy(p => p.ExpirationTime).First();
            return product.Id;
        }
        [HttpPost]
        public ActionResult BestContact()
        {
            string name = Request.Form["nombre"];
            string email = Request.Form["email"];
            string message = Request.Form["message"];
            Contact contact = new Contact();
            contact.Name = name;
            contact.Email = email;
            contact.Message = message;
            db.Contact.Add(contact);
            db.SaveChanges();
            return Redirect("Home/Index");
        }
    }
}