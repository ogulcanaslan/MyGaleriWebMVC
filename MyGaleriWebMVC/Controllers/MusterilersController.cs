using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyGaleriWebMVC.Models;

namespace MyGaleriWebMVC.Controllers
{
    public class MusterilersController : Controller
    {
        private MyGaleriEntities db = new MyGaleriEntities();

        // GET: Musterilers
        public ActionResult Index()
        {
            return View(db.Musterilers.ToList());
        }

        // GET: Musterilers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteriler musteriler = db.Musterilers.Find(id);
            if (musteriler == null)
            {
                return HttpNotFound();
            }
            return View(musteriler);
        }

        // GET: Musterilers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Musterilers/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MusteriNo,MusteriIsim,MusteriYas,MusteriBakiye")] Musteriler musteriler)
        {
            if (ModelState.IsValid)
            {
                db.Musterilers.Add(musteriler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(musteriler);
        }

        // GET: Musterilers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteriler musteriler = db.Musterilers.Find(id);
            if (musteriler == null)
            {
                return HttpNotFound();
            }
            return View(musteriler);
        }

        // POST: Musterilers/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MusteriNo,MusteriIsim,MusteriYas,MusteriBakiye")] Musteriler musteriler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musteriler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(musteriler);
        }

        // GET: Musterilers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteriler musteriler = db.Musterilers.Find(id);
            if (musteriler == null)
            {
                return HttpNotFound();
            }
            return View(musteriler);
        }

        // POST: Musterilers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Musteriler musteriler = db.Musterilers.Find(id);
            db.Musterilers.Remove(musteriler);
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
