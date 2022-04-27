using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FideGames.Models;
using FideGames.Controllers;
using System.Data.Entity;
using System.Net;

namespace FideGames.Controllers
{
    public class ProductController : Controller
    {
        proyectoFideGamesEntities1 db = new proyectoFideGamesEntities1();
        // GET: Product
        public ActionResult ListaProducts()
        {
            IEnumerable<product> list = db.product.ToList();
            return View(list);
        }

        public ActionResult DetallarProduct(int id)
        {
            product Product = db.product.Find(id);
            return View(Product);
        }

        public ActionResult CreateProduct()
        {
            ViewBag.brand_id = new SelectList(db.brand_product, "brand_product_id", "brand_product_name");
            ViewBag.deparment_id = new SelectList(db.deparment_product, "deparment_product_id", "deparment_product_name");
            ViewBag.type_product_id = new SelectList(db.type_product, "type_product_id", "type_product_name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct([Bind(Include = "product_id,userName,product_name,type_product_id,deparment_id,brand_id,product_description,quantities,price")] product Product)
        {
            if (ModelState.IsValid)
            {
                db.product.Add(Product);
                db.SaveChanges();
                return RedirectToAction("ListaProducts", "Product");
            }

            ViewBag.brand_product_id = new SelectList(db.brand_product, "brand_product_id", "brand_product_name");
            ViewBag.deparment_id = new SelectList(db.deparment_product, "deparment_product_id", "deparment_product_name");
            ViewBag.type_product_id = new SelectList(db.type_product, "type_product_id", "type_product_name");
            return View(Product);
        }
        // Editar Productos
        public ActionResult EditarProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product Product = db.product.Find(id);
            if (Product == null)
            {
                return HttpNotFound();
            }
            ViewBag.brand_id = new SelectList(db.brand_product, "brand_product_id", "brand_product_name");
            ViewBag.deparment_id = new SelectList(db.deparment_product, "deparment_product_id", "deparment_product_name");
            ViewBag.type_product_id = new SelectList(db.type_product, "type_product_id", "type_product_name");
            return View(Product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarProduct([Bind(Include = "product_id,userName,product_name,type_product_id,deparment_id,brand_id,product_description,quantities,price")] product Product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListaProducts");
            }
            ViewBag.brand_id = new SelectList(db.brand_product, "brand_product_id", "brand_product_name");
            ViewBag.deparment_id = new SelectList(db.deparment_product, "deparment_product_id", "deparment_product_name");
            ViewBag.type_product_id = new SelectList(db.type_product, "type_product_id", "type_product_name");
            return View(Product);
        }
        // Eliminar Producto
        public ActionResult EliminarProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product Product = db.product.Find(id);
            if (Product == null)
            {
                return HttpNotFound();
            }
            return View(Product);
        }

        //Eliminar Users
        [HttpPost, ActionName("EliminarProduct")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            product Product = db.product.Find(id);
            db.product.Remove(Product);
            db.SaveChanges();
            return RedirectToAction("ListaProducts");
        }
    }
}