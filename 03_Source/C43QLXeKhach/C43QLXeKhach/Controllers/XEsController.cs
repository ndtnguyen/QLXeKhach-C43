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
    public class XEsController : Controller
    {
        private QLXeKhachEntities db = new QLXeKhachEntities();

        // GET: XEs
        public ActionResult Index()
        {
            return View(db.XEs.ToList());
        }

        // GET: XEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XE xE = db.XEs.Find(id);
            if (xE == null)
            {
                return HttpNotFound();
            }
            return View(xE);
        }

        // GET: XEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: XEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaXe,LoaiXe,BienSoXe,HangXe,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] XE xE)
        {
            if (ModelState.IsValid)
            {
                db.XEs.Add(xE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(xE);
        }

        // GET: XEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XE xE = db.XEs.Find(id);
            if (xE == null)
            {
                return HttpNotFound();
            }
            return View(xE);
        }

        // POST: XEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaXe,LoaiXe,BienSoXe,HangXe,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] XE xE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(xE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(xE);
        }

        // GET: XEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XE xE = db.XEs.Find(id);
            if (xE == null)
            {
                return HttpNotFound();
            }
            return View(xE);
        }

        // POST: XEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            XE xE = db.XEs.Find(id);
            db.XEs.Remove(xE);
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
