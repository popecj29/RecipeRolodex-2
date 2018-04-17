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
    public class MealCategoriesController : Controller
    {
        private RecipeRolodexEntities db = new RecipeRolodexEntities();

        // GET: MealCategories
        public ActionResult Index()
        {
            return View(db.MealCategories.ToList());
        }

        // GET: MealCategories/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MealCategory mealCategory = db.MealCategories.Find(id);
            if (mealCategory == null)
            {
                return HttpNotFound();
            }
            return View(mealCategory);
        }

        // GET: MealCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MealCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] MealCategory mealCategory)
        {
            if (ModelState.IsValid)
            {
                db.MealCategories.Add(mealCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mealCategory);
        }

        // GET: MealCategories/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MealCategory mealCategory = db.MealCategories.Find(id);
            if (mealCategory == null)
            {
                return HttpNotFound();
            }
            return View(mealCategory);
        }

        // POST: MealCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] MealCategory mealCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mealCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mealCategory);
        }

        // GET: MealCategories/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MealCategory mealCategory = db.MealCategories.Find(id);
            if (mealCategory == null)
            {
                return HttpNotFound();
            }
            return View(mealCategory);
        }

        // POST: MealCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            MealCategory mealCategory = db.MealCategories.Find(id);
            db.MealCategories.Remove(mealCategory);
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
