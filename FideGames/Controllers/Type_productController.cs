using FideGames.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FideGames.Controllers
{
    public class Type_productController : Controller
    {
        // GET: Type_product
        Models.proyectoFideGamesEntities1 db = new proyectoFideGamesEntities1();
        // Listar Categorias
        public ActionResult ListaType_product()
        {
            IEnumerable<type_product> list = db.type_product.ToList();
            return View(list);
        }

        //crear marca
        public ActionResult CrearType_product()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearType_product([Bind(Include = "type_product_id,type_product_Name")] type_product Type_Product)
        {
            if (ModelState.IsValid)
            {
                db.type_product.Add(Type_Product);
                db.SaveChanges();
                ViewBag.exito = "Se ha agregado la nueva categoría";
            }
            return RedirectToAction("ListaType_product");
        }

        // Detalles de categoria
        public ActionResult DetallarType_product(int id)
        {
            type_product Type_Product = db.type_product.Find(id);
            return View(Type_Product);
        }
        public ActionResult EditarType_product(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            type_product Type_Product = db.type_product.Find(id);
            if (Type_Product == null)
            {
                return HttpNotFound();
            }
            return View(Type_Product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarType_product([Bind(Include = "type_product_id,type_product_Name")] type_product Type_Product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Type_Product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListaType_product");
            }
            return View(Type_Product);
        }
        //Eliminar categoría
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarType_product(type_product Type_Product)
        {
            db.Entry(Type_Product).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            ViewBag.exito = "Se ha eliminado la categoría";
            return RedirectToAction("ListaType_product");

        }
    }
}