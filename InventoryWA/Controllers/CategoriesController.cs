using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryWA.Models;

namespace InventoryWA.Controllers
{
    public class CategoriesController : Controller
    {
        private InventoryContext db = new InventoryContext();

        // GET: Categories
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        /// <summary>
        /// Get All categories JsonResult
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAllCategories()
        {
            List<Categorie> Categories = db.Categories.ToList();
            return Json(Categories, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get Categorie by ID ActionResult
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetCategorie(int? id)
        {
            Categorie _Categorie = db.Categories.Find(id);
            return Json(_Categorie, JsonRequestBehavior.AllowGet);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorie categorie = db.Categories.Find(id);
            if (categorie == null)
            {
                return HttpNotFound();
            }
            return View(categorie);
        }

        [HttpPost]
        public JsonResult SaveCategorie(Categorie categorie)
        {
            try
            {
                categorie.Id = db.Categories.Select(c => c.Id).DefaultIfEmpty(0).Max() + 1;
            }
            catch (Exception)
            {
                categorie.Id = 1;
            }
            JsonResult respons = Json("");
            db.Categories.Add(categorie);
            db.SaveChanges();
            respons = Json(new { status = "success", data = categorie }, JsonRequestBehavior.AllowGet);
            
            return respons;
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorie categorie = db.Categories.Find(id);
            if (categorie == null)
            {
                return HttpNotFound();
            }
            return View(categorie);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Nombre")] Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categorie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categorie);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorie categorie = db.Categories.Find(id);
            if (categorie == null)
            {
                return HttpNotFound();
            }
            return View(categorie);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categorie categorie = db.Categories.Find(id);
            db.Categories.Remove(categorie);
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
