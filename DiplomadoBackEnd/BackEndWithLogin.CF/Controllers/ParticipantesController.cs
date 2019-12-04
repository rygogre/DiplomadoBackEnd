using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BackEndWithLogin.CF.Models;

namespace BackEndWithLogin.CF.Controllers
{
    public class ParticipantesController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: Participantes
        public ActionResult Index()
        {
            return View(db.Participantes.ToList());
        }

        [HttpPost]
        public ActionResult Index(string nombre)
        {
            var result = db.Participantes.
                Where(x => x.Nombre.Equals(nombre)).ToList();
            return View("Index",result);
        }

        // GET: Participantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participante participante = db.Participantes.Find(id);
            if (participante == null)
            {
                return HttpNotFound();
            }
            return View(participante);
        }

        // GET: Participantes/Create
        public ActionResult Create()
        {
            ViewBag.IDProvincia = new SelectList(db.Provincias, "IDProvincia", "Nombre");
            //GetMunicipios(0);           

            return View();
        }

        public JsonResult GetMunicipios(int idProvincia)
        {
            //ViewBag.IDMunicipio = new SelectList(db.Municipos.Where(x => x.IDProvincia == idProvincia).OrderBy(x => x.Nombre), "IDMunicipio", "Nombre");

            var result = db.Municipos.
                Where(x => x.IDProvincia == idProvincia).
                OrderBy(x => x.Nombre).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // POST: Participantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDParticipante,Cedula,Nombre,Apellidos,FechaNacimiento,IDMunicipio,Telefono,Celular,Email,ConfirmarEmail,URLImage,Sexo")] Participante participante)
        {
            if (ModelState.IsValid)
            {
                db.Participantes.Add(participante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDProvincia = new SelectList(db.Provincias, "IDProvincia", "Nombre");
            return View(participante);
        }

        // GET: Participantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participante participante = db.Participantes.Find(id);
            if (participante == null)
            {
                return HttpNotFound();
            }
            return View(participante);
        }

        // POST: Participantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDParticipante,Cedula,Nombre,Apellidos,FechaNacimiento,IDCiudad,Telefono,Celular,Email,URLImage,Sexo")] Participante participante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(participante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(participante);
        }

        // GET: Participantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participante participante = db.Participantes.Find(id);
            if (participante == null)
            {
                return HttpNotFound();
            }
            return View(participante);
        }

        // POST: Participantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Participante participante = db.Participantes.Find(id);
            db.Participantes.Remove(participante);
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
