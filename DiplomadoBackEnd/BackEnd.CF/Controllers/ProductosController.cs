using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BackEnd.CF.Models;
using ClosedXML.Excel;

namespace BackEnd.CF.Controllers
{
    public class ProductosController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: Productos
        public ActionResult Index()
        {
            
            var productos = db.Productos.Include(p => p.Categoria);
            ViewBag.TotalProductos = productos.Count();

            return View(productos.ToList());
        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Descripcion");
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductoID,Descripcion,Precio,FechaVencimiento,Costo,Estatus,CategoriaID")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Productos.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Descripcion", producto.CategoriaID);
            return View(producto);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Descripcion", producto.CategoriaID);
            return View(producto);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductoID,Descripcion,Precio,FechaVencimiento,Costo,Estatus,CategoriaID")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Descripcion", producto.CategoriaID);
            return View(producto);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Productos.Find(id);
            db.Productos.Remove(producto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public FileResult Exportar()
        {
            var productos = db.Productos.Include(p => p.Categoria);

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Descripcion");
            dt.Columns.Add("Precio");

            foreach(var producto in productos)
            {
                dt.Rows.Add(producto.ProductoID,
                    producto.Descripcion,
                    producto.Precio);               
            }

            using(XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "productos");

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(),
                        "application/vnp.openxmlformats-officedocuments.spreadsheet.sheet",
                        "pr.xlsx");
                }
            }


            //return View();
        }


        //Accion para para hacer una validacion utilizando REMOTE
        public JsonResult ValidaDescripcion(string descripcion) //Validamos la descripción no pueda tener mas de 4 palabras.
        {
            string[] espacios = descripcion.Split(' ');
            bool isValid = true;

            if (espacios.Count() > 4)
                isValid = false;

            return Json(isValid, JsonRequestBehavior.AllowGet);
        }


        //public FileResult Dow()
        //{

        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("Des");
        //    dt.Columns.Add("pre");
        //    //dt.Rows.Add()

        //    var productos = db.Productos.Include(p => p.Categoria).ToList();

        //    foreach(var producto in productos)
        //    {
        //        dt.Rows.Add(producto.Descripcion, producto.Precio);
        //    }

        //    using (XLWorkbook wb = new XLWorkbook())
        //    {
        //        wb.Worksheets.Add(dt, "prfgsgfsfg");
        //        using (MemoryStream stream = new MemoryStream())
        //        {
        //            wb.SaveAs(stream);
        //            return File(stream.ToArray(), "application/vnp.openxmlformats-officedocuments.spreadsheet.sheet", "pr.xlsx");
        //        }
        //    }
        //}

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
