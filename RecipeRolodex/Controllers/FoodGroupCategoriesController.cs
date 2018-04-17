using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecipeRolodex.Models;

namespace RecipeRolodex.Controllers
{
    public class FoodGroupCategoriesController : Controller
    {
        private RecipeRolodexEntities db = new RecipeRolodexEntities();

        // GET: FoodGroupCategories
        public ActionResult Index()
        {
            var foodGroupCategories = db.FoodGroupCategories.Include(f => f.FoodGroup);
            return View(foodGroupCategories.ToList());
        }

        // GET: FoodGroupCategories/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodGroupCategory foodGroupCategory = db.FoodGroupCategories.Find(id);
            if (foodGroupCategory == null)
            {
                return HttpNotFound();
            }
            return View(foodGroupCategory);
        }

        // GET: FoodGroupCategories/Create
        public ActionResult Create()
        {
            ViewBag.FoodGroupID = new SelectList(db.FoodGroups, "ID", "FoodGroup1");
            return View();
        }

        // POST: FoodGroupCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Category,FoodGroupID")] FoodGroupCategory foodGroupCategory)
        {
            if (ModelState.IsValid)
            {
                db.FoodGroupCategories.Add(foodGroupCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FoodGroupID = new SelectList(db.FoodGroups, "ID", "FoodGroup1", foodGroupCategory.FoodGroupID);
            return View(foodGroupCategory);
        }

        // GET: FoodGroupCategories/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodGroupCategory foodGroupCategory = db.FoodGroupCategories.Find(id);
            if (foodGroupCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.FoodGroupID = new SelectList(db.FoodGroups, "ID", "FoodGroup1", foodGroupCategory.FoodGroupID);
            return View(foodGroupCategory);
        }

        // POST: FoodGroupCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Category,FoodGroupID")] FoodGroupCategory foodGroupCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foodGroupCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FoodGroupID = new SelectList(db.FoodGroups, "ID", "FoodGroup1", foodGroupCategory.FoodGroupID);
            return View(foodGroupCategory);
        }

        // GET: FoodGroupCategories/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodGroupCategory foodGroupCategory = db.FoodGroupCategories.Find(id);
            if (foodGroupCategory == null)
            {
                return HttpNotFound();
            }
            return View(foodGroupCategory);
        }

        // POST: FoodGroupCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            FoodGroupCategory foodGroupCategory = db.FoodGroupCategories.Find(id);
            db.FoodGroupCategories.Remove(foodGroupCategory);
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
