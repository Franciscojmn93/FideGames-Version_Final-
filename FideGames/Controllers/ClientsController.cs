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
    public class ClientsController : Controller
    {
        // GET: Clients
        Models.proyectoFideGamesEntities1 db = new proyectoFideGamesEntities1();
        // Listar cliente
        public ActionResult ListaClients()
        {
            IEnumerable<clients> list = db.clients.ToList();
            return View(list);
        }

        //crearcliente
        public ActionResult CrearClients()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearClients([Bind(Include = "client_name1,client_name2,client_lastname1,client_lastname2,client_id_card,client_email,client_direcction")] clients Clients)
        {
            if (ModelState.IsValid)
            {
                db.clients.Add(Clients);
                db.SaveChanges();
                ViewBag.exito = "Se ha agregado un nuevo cliente";
            }
            return RedirectToAction("ListaClients");
        }

        // Detalles de ccliente
        public ActionResult DetallarClients(int id)
        {
            clients Clients = db.clients.Find(id);
            return View(Clients);
        }
        public ActionResult EditarClients(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clients Clients = db.clients.Find(id);
            if (Clients == null)
            {
                return HttpNotFound();
            }
            return View(Clients);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarClients([Bind(Include = "client_id,client_name1,client_name2,client_lastname1,client_lastname2,client_id_card,client_email,client_direcction")] clients Clients)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Clients).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListaClients");
            }
            return View(Clients);
        }
        //Eliminar cliente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarClients(clients Clients)
        {
            db.Entry(Clients).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            ViewBag.exito = "Se ha eliminado el cliente";
            return RedirectToAction("ListaClients");

        }
    }
}