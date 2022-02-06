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
    public class AraclarsController : Controller
    {
        private MyGaleriEntities db = new MyGaleriEntities();

        // GET: Araclars
        public ActionResult Index()
        {
            var araclars = db.Araclars.Include(a => a.Subeler);
            return View(araclars.ToList());
        }

        // GET: Araclars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Araclar araclar = db.Araclars.Find(id);
            if (araclar == null)
            {
                return HttpNotFound();
            }
            return View(araclar);
        }

        // GET: Araclars/Create
        public ActionResult Create()
        {
            ViewBag.SubeNo = new SelectList(db.Subelers, "SubeNo", "SubeAdi");
            return View();
        }

        // POST: Araclars/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AracNo,AracFiyat,AracAdet,AracMarka,AracModel,AracOzellik,AracMotor,AracPaket,AracRenk,SubeNo")] Araclar araclar)
        {
            if (ModelState.IsValid)
            {
                db.Araclars.Add(araclar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubeNo = new SelectList(db.Subelers, "SubeNo", "SubeAdi", araclar.SubeNo);
            return View(araclar);
        }

        // GET: Araclars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Araclar araclar = db.Araclars.Find(id);
            if (araclar == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubeNo = new SelectList(db.Subelers, "SubeNo", "SubeAdi", araclar.SubeNo);
            return View(araclar);
        }

        // POST: Araclars/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AracNo,AracFiyat,AracAdet,AracMarka,AracModel,AracOzellik,AracMotor,AracPaket,AracRenk,SubeNo")] Araclar araclar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(araclar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubeNo = new SelectList(db.Subelers, "SubeNo", "SubeAdi", araclar.SubeNo);
            return View(araclar);
        }

        // GET: Araclars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Araclar araclar = db.Araclars.Find(id);
            if (araclar == null)
            {
                return HttpNotFound();
            }
            return View(araclar);
        }

        // POST: Araclars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Araclar araclar = db.Araclars.Find(id);
            db.Araclars.Remove(araclar);
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
