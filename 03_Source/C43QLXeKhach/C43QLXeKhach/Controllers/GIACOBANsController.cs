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
    public class GIACOBANsController : Controller
    {
        private QLXeKhachEntities db = new QLXeKhachEntities();

        // GET: GIACOBANs
        public ActionResult Index()
        {
            return View(db.GIACOBANs.ToList());
        }

        // GET: GIACOBANs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIACOBAN gIACOBAN = db.GIACOBANs.Find(id);
            if (gIACOBAN == null)
            {
                return HttpNotFound();
            }
            return View(gIACOBAN);
        }

        // GET: GIACOBANs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GIACOBANs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTT1,MaTT2,MaLoai,GiaCoBan1,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] GIACOBAN gIACOBAN)
        {
            if (ModelState.IsValid)
            {
                db.GIACOBANs.Add(gIACOBAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gIACOBAN);
        }

        // GET: GIACOBANs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIACOBAN gIACOBAN = db.GIACOBANs.Find(id);
            if (gIACOBAN == null)
            {
                return HttpNotFound();
            }
            return View(gIACOBAN);
        }

        // POST: GIACOBANs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTT1,MaTT2,MaLoai,GiaCoBan1,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] GIACOBAN gIACOBAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gIACOBAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gIACOBAN);
        }

        // GET: GIACOBANs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIACOBAN gIACOBAN = db.GIACOBANs.Find(id);
            if (gIACOBAN == null)
            {
                return HttpNotFound();
            }
            return View(gIACOBAN);
        }

        // POST: GIACOBANs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            GIACOBAN gIACOBAN = db.GIACOBANs.Find(id);
            db.GIACOBANs.Remove(gIACOBAN);
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
