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
        // GET: Categories/Details/5
        public JsonResult Details(int? id)
        {
            Categorie categorie = db.Categories.Find(id);
            return Json(categorie, JsonRequestBehavior.AllowGet);
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
            db.Categories.Add(categorie);
            db.SaveChanges();
            
            return Json(new { status = "success", data = categorie }, JsonRequestBehavior.AllowGet); ;
        }

        [HttpPost]
        public JsonResult Edit(Categorie categorie)
        {
            db.Entry(categorie).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Json(new { status = "success"}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        // GET: Categories/Delete/5
        public JsonResult Delete(int? id)
        {
            Categorie categorie =db.Categories.Find(id);
            db.Categories.Remove(categorie);
            db.SaveChanges();
            return Json(new { status = "success" }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCategorieExist(int id, string property, string value)
        {
            if (value != "")
            {
                if (property == "Code")
                {
                    if (db.Categories.Where(c => c.Id != id && c.Code == value).Count() > 0)
                    {
                        return Json(new { status = false }, JsonRequestBehavior.AllowGet);
                    }
                }
                if (property == "Nombre")
                {
                    if (db.Categories.Where(c => c.Id != id && c.Nombre == value).Count() > 0)
                    {
                        return Json(new { status = false }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            return Json(new { status = true }, JsonRequestBehavior.AllowGet);
        }
    }
}
