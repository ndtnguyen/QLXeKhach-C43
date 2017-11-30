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
    public class CHUYENXEsController : Controller
    {
        private QLXeKhachEntities db = new QLXeKhachEntities();

        // GET: CHUYENXEs
        public ActionResult Index()
        {
            return View(db.CHUYENXEs.ToList());
        }

        // GET: CHUYENXEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUYENXE cHUYENXE = db.CHUYENXEs.Find(id);
            if (cHUYENXE == null)
            {
                return HttpNotFound();
            }
            return View(cHUYENXE);
        }

        // GET: CHUYENXEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CHUYENXEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaChuyen,NgayKH,NgayDen,MaTuyen,MaXe,MaTX,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] CHUYENXE cHUYENXE)
        {
            if (ModelState.IsValid)
            {
                db.CHUYENXEs.Add(cHUYENXE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cHUYENXE);
        }

        // GET: CHUYENXEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUYENXE cHUYENXE = db.CHUYENXEs.Find(id);
            if (cHUYENXE == null)
            {
                return HttpNotFound();
            }
            return View(cHUYENXE);
        }

        // POST: CHUYENXEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaChuyen,NgayKH,NgayDen,MaTuyen,MaXe,MaTX,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] CHUYENXE cHUYENXE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHUYENXE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cHUYENXE);
        }

        // GET: CHUYENXEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUYENXE cHUYENXE = db.CHUYENXEs.Find(id);
            if (cHUYENXE == null)
            {
                return HttpNotFound();
            }
            return View(cHUYENXE);
        }

        // POST: CHUYENXEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CHUYENXE cHUYENXE = db.CHUYENXEs.Find(id);
            db.CHUYENXEs.Remove(cHUYENXE);
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
