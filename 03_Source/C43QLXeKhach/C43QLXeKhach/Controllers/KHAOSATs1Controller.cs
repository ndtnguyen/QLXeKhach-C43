using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using C43QLXeKhach.Models;

namespace C43QLXeKhach.Controllers
{
    public class KHAOSATs1Controller : Controller
    {
        private QLXeKhachEntities db = new QLXeKhachEntities();

        // GET: KHAOSATs1
        public ActionResult Index()
        {
            return View(db.KHAOSATs.ToList());
        }

        // GET: KHAOSATs1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHAOSAT kHAOSAT = db.KHAOSATs.Find(id);
            if (kHAOSAT == null)
            {
                return HttpNotFound();
            }
            return View(kHAOSAT);
        }

        // GET: KHAOSATs1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KHAOSATs1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKS,NgayKS,NguoiKS,DiaChiKS,TiLeDonKhach,GiaKS,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] KHAOSAT kHAOSAT)
        {
            if (ModelState.IsValid)
            {
                db.KHAOSATs.Add(kHAOSAT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kHAOSAT);
        }

        // GET: KHAOSATs1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHAOSAT kHAOSAT = db.KHAOSATs.Find(id);
            if (kHAOSAT == null)
            {
                return HttpNotFound();
            }
            return View(kHAOSAT);
        }

        // POST: KHAOSATs1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKS,NgayKS,NguoiKS,DiaChiKS,TiLeDonKhach,GiaKS,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] KHAOSAT kHAOSAT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kHAOSAT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kHAOSAT);
        }

        // GET: KHAOSATs1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHAOSAT kHAOSAT = db.KHAOSATs.Find(id);
            if (kHAOSAT == null)
            {
                return HttpNotFound();
            }
            return View(kHAOSAT);
        }

        // POST: KHAOSATs1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KHAOSAT kHAOSAT = db.KHAOSATs.Find(id);
            db.KHAOSATs.Remove(kHAOSAT);
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
