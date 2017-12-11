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
    public class TINHTHANHsController : Controller
    {
        private QLXeKhachEntities db = new QLXeKhachEntities();

        // GET: TINHTHANHs
        public ActionResult Index()
        {
            return View(db.TINHTHANHs.ToList());
        }

        // GET: TINHTHANHs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINHTHANH tINHTHANH = db.TINHTHANHs.Find(id);
            if (tINHTHANH == null)
            {
                return HttpNotFound();
            }
            return View(tINHTHANH);
        }

        // GET: TINHTHANHs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TINHTHANHs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTT,TenTT,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] TINHTHANH tINHTHANH)
        {
            if (ModelState.IsValid)
            {
                db.TINHTHANHs.Add(tINHTHANH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tINHTHANH);
        }

        // GET: TINHTHANHs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINHTHANH tINHTHANH = db.TINHTHANHs.Find(id);
            if (tINHTHANH == null)
            {
                return HttpNotFound();
            }
            return View(tINHTHANH);
        }

        // POST: TINHTHANHs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTT,TenTT,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] TINHTHANH tINHTHANH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tINHTHANH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tINHTHANH);
        }

        // GET: TINHTHANHs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINHTHANH tINHTHANH = db.TINHTHANHs.Find(id);
            if (tINHTHANH == null)
            {
                return HttpNotFound();
            }
            return View(tINHTHANH);
        }

        // POST: TINHTHANHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TINHTHANH tINHTHANH = db.TINHTHANHs.Find(id);
            db.TINHTHANHs.Remove(tINHTHANH);
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
