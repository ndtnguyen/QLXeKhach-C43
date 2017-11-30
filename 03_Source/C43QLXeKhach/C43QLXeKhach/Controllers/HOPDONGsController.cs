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
    public class HOPDONGsController : Controller
    {
        private QLXeKhachEntities db = new QLXeKhachEntities();

        // GET: HOPDONGs
        public ActionResult Index()
        {
            return View(db.HOPDONGs.ToList());
        }

        // GET: HOPDONGs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOPDONG hOPDONG = db.HOPDONGs.Find(id);
            if (hOPDONG == null)
            {
                return HttpNotFound();
            }
            return View(hOPDONG);
        }

        // GET: HOPDONGs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HOPDONGs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHD,NgayLap,GiaThoaThuan,MaTram,ThoiHanThue,MaDT,NguoiLap,MoTa,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] HOPDONG hOPDONG)
        {
            if (ModelState.IsValid)
            {
                db.HOPDONGs.Add(hOPDONG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hOPDONG);
        }

        // GET: HOPDONGs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOPDONG hOPDONG = db.HOPDONGs.Find(id);
            if (hOPDONG == null)
            {
                return HttpNotFound();
            }
            return View(hOPDONG);
        }

        // POST: HOPDONGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHD,NgayLap,GiaThoaThuan,MaTram,ThoiHanThue,MaDT,NguoiLap,MoTa,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] HOPDONG hOPDONG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOPDONG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hOPDONG);
        }

        // GET: HOPDONGs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOPDONG hOPDONG = db.HOPDONGs.Find(id);
            if (hOPDONG == null)
            {
                return HttpNotFound();
            }
            return View(hOPDONG);
        }

        // POST: HOPDONGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HOPDONG hOPDONG = db.HOPDONGs.Find(id);
            db.HOPDONGs.Remove(hOPDONG);
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
