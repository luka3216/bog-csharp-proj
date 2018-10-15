using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LuxStore7.Models;

namespace LuxStore7.Controllers
{
    public class MealCategoriesController : Controller
    {
        private LuxStore7DB8 db = new LuxStore7DB8();

        // GET: MealCategories
        public ActionResult Index()
        {
            return View(db.MealCategories.ToList());
        }

        // GET: MealCategories/Details/5
        public ActionResult Details(int? id)
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
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] MealCategory mealCategory)
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
        public ActionResult Edit(int? id)
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
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] MealCategory mealCategory)
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
        public ActionResult Delete(int? id)
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
        public ActionResult DeleteConfirmed(int id)
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
