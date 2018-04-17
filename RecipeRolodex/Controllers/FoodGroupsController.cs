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
    public class FoodGroupsController : Controller
    {
        private RecipeRolodexEntities db = new RecipeRolodexEntities();

        // GET: FoodGroups
        public ActionResult Index()
        {
            return View(db.FoodGroups.ToList());
        }

        // GET: FoodGroups/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodGroup foodGroup = db.FoodGroups.Find(id);
            if (foodGroup == null)
            {
                return HttpNotFound();
            }
            return View(foodGroup);
        }

        // GET: FoodGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FoodGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FoodGroup1")] FoodGroup foodGroup)
        {
            if (ModelState.IsValid)
            {
                db.FoodGroups.Add(foodGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(foodGroup);
        }

        // GET: FoodGroups/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodGroup foodGroup = db.FoodGroups.Find(id);
            if (foodGroup == null)
            {
                return HttpNotFound();
            }
            return View(foodGroup);
        }

        // POST: FoodGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FoodGroup1")] FoodGroup foodGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foodGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(foodGroup);
        }

        // GET: FoodGroups/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodGroup foodGroup = db.FoodGroups.Find(id);
            if (foodGroup == null)
            {
                return HttpNotFound();
            }
            return View(foodGroup);
        }

        // POST: FoodGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            FoodGroup foodGroup = db.FoodGroups.Find(id);
            db.FoodGroups.Remove(foodGroup);
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
