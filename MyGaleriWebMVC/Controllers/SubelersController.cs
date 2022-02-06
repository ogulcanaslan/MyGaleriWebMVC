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
    public class SubelersController : Controller
    {
        private MyGaleriEntities db = new MyGaleriEntities();

        // GET: Subelers
        public ActionResult Index()
        {
            var subelers = db.Subelers.Include(s => s.Musteriler);
            return View(subelers.ToList());
        }

        // GET: Subelers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subeler subeler = db.Subelers.Find(id);
            if (subeler == null)
            {
                return HttpNotFound();
            }
            return View(subeler);
        }

        // GET: Subelers/Create
        public ActionResult Create()
        {
            ViewBag.MusteriNo = new SelectList(db.Musterilers, "MusteriNo", "MusteriIsim");
            return View();
        }

        // POST: Subelers/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubeNo,SubeAdi,SubeCalisanSayisi,SubeCiro,MusteriNo")] Subeler subeler)
        {
            if (ModelState.IsValid)
            {
                db.Subelers.Add(subeler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MusteriNo = new SelectList(db.Musterilers, "MusteriNo", "MusteriIsim", subeler.MusteriNo);
            return View(subeler);
        }

        // GET: Subelers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subeler subeler = db.Subelers.Find(id);
            if (subeler == null)
            {
                return HttpNotFound();
            }
            ViewBag.MusteriNo = new SelectList(db.Musterilers, "MusteriNo", "MusteriIsim", subeler.MusteriNo);
            return View(subeler);
        }

        // POST: Subelers/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubeNo,SubeAdi,SubeCalisanSayisi,SubeCiro,MusteriNo")] Subeler subeler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subeler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MusteriNo = new SelectList(db.Musterilers, "MusteriNo", "MusteriIsim", subeler.MusteriNo);
            return View(subeler);
        }

        // GET: Subelers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subeler subeler = db.Subelers.Find(id);
            if (subeler == null)
            {
                return HttpNotFound();
            }
            return View(subeler);
        }

        // POST: Subelers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subeler subeler = db.Subelers.Find(id);
            db.Subelers.Remove(subeler);
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
