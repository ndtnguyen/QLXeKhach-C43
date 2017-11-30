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
    public class C_SESSIONController : Controller
    {
        private QLXeKhachEntities db = new QLXeKhachEntities();

        // GET: C_SESSION
        public ActionResult Index()
        {
            return View(db.C_SESSION.ToList());
        }

        // GET: C_SESSION/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            C_SESSION c_SESSION = db.C_SESSION.Find(id);
            if (c_SESSION == null)
            {
                return HttpNotFound();
            }
            return View(c_SESSION);
        }

        // GET: C_SESSION/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: C_SESSION/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNV,LoginTime,LogoutTime,C_Status")] C_SESSION c_SESSION)
        {
            if (ModelState.IsValid)
            {
                db.C_SESSION.Add(c_SESSION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(c_SESSION);
        }

        // GET: C_SESSION/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            C_SESSION c_SESSION = db.C_SESSION.Find(id);
            if (c_SESSION == null)
            {
                return HttpNotFound();
            }
            return View(c_SESSION);
        }

        // POST: C_SESSION/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNV,LoginTime,LogoutTime,C_Status")] C_SESSION c_SESSION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(c_SESSION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c_SESSION);
        }

        // GET: C_SESSION/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            C_SESSION c_SESSION = db.C_SESSION.Find(id);
            if (c_SESSION == null)
            {
                return HttpNotFound();
            }
            return View(c_SESSION);
        }

        // POST: C_SESSION/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            C_SESSION c_SESSION = db.C_SESSION.Find(id);
            db.C_SESSION.Remove(c_SESSION);
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
