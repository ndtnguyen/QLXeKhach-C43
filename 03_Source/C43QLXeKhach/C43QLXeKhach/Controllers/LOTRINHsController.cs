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
    public class LOTRINHsController : Controller
    {
        private QLXeKhachEntities db = new QLXeKhachEntities();

        // GET: LOTRINHs
        public ActionResult Index()
        {
            return View(db.LOTRINHs.ToList());
        }

        // GET: LOTRINHs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOTRINH lOTRINH = db.LOTRINHs.Find(id);
            if (lOTRINH == null)
            {
                return HttpNotFound();
            }
            return View(lOTRINH);
        }

        // GET: LOTRINHs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LOTRINHs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTuyen,MaTram,ThuTu,KhoangThoiGian,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] LOTRINH lOTRINH)
        {
            if (ModelState.IsValid)
            {
                db.LOTRINHs.Add(lOTRINH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lOTRINH);
        }

        // GET: LOTRINHs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOTRINH lOTRINH = db.LOTRINHs.Find(id);
            if (lOTRINH == null)
            {
                return HttpNotFound();
            }
            return View(lOTRINH);
        }

        // POST: LOTRINHs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTuyen,MaTram,ThuTu,KhoangThoiGian,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] LOTRINH lOTRINH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOTRINH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lOTRINH);
        }

        // GET: LOTRINHs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOTRINH lOTRINH = db.LOTRINHs.Find(id);
            if (lOTRINH == null)
            {
                return HttpNotFound();
            }
            return View(lOTRINH);
        }

        // POST: LOTRINHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LOTRINH lOTRINH = db.LOTRINHs.Find(id);
            db.LOTRINHs.Remove(lOTRINH);
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
