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
    public class ProductsController : Controller
    {
        private LuxStore7DB8 db = new LuxStore7DB8();

        // GET: Products
        public ActionResult Index(int Id)
        {
            ViewBag.compId = Id;
            var products = db.Products.Include(p => p.Company).Include(p => p.MealCategory).Include(p => p.ProductCategory).Where(a => a.CompanyId == Id);
            return PartialView(products.ToList());
        }

        // GET: Products/Details/5.
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create(int Id)
        {
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", Id);
            ViewBag.MealCategoryId = new SelectList(db.MealCategories, "Id", "Name");
            ViewBag.ProductCategoryId = new SelectList(db.ProductCategories, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CompanyId,Name,PrepTime,Price,MealCategoryId,ProductCategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Details", "Companies", new { Id = product.CompanyId });
            }

            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", product.CompanyId);
            ViewBag.MealCategoryId = new SelectList(db.MealCategories, "Id", "Name", product.MealCategoryId);
            ViewBag.ProductCategoryId = new SelectList(db.ProductCategories, "Id", "Name", product.ProductCategoryId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", product.CompanyId);
            ViewBag.MealCategoryId = new SelectList(db.MealCategories, "Id", "Name", product.MealCategoryId);
            ViewBag.ProductCategoryId = new SelectList(db.ProductCategories, "Id", "Name", product.ProductCategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CompanyId,Name,PrepTime,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Companies", new { Id = product.CompanyId });
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", product.CompanyId);
            ViewBag.MealCategoryId = new SelectList(db.MealCategories, "Id", "Name", product.MealCategoryId);
            ViewBag.ProductCategoryId = new SelectList(db.ProductCategories, "Id", "Name", product.ProductCategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Details", "Companies", new { Id = product.CompanyId });
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
