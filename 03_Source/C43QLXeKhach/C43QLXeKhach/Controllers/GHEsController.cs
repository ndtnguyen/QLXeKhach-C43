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
    public class GHEsController : Controller
    {
        private QLXeKhachEntities db = new QLXeKhachEntities();

        // GET: GHEs
        public ActionResult Index()
        {
            return View(db.GHEs.ToList());
        }

        // GET: GHEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GHE gHE = db.GHEs.Find(id);
            if (gHE == null)
            {
                return HttpNotFound();
            }
            return View(gHE);
        }

        // GET: GHEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GHEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaXe,MaGhe,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] GHE gHE)
        {
            if (ModelState.IsValid)
            {
                db.GHEs.Add(gHE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gHE);
        }

        // GET: GHEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GHE gHE = db.GHEs.Find(id);
            if (gHE == null)
            {
                return HttpNotFound();
            }
            return View(gHE);
        }

        // POST: GHEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaXe,MaGhe,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] GHE gHE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gHE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gHE);
        }

        // GET: GHEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GHE gHE = db.GHEs.Find(id);
            if (gHE == null)
            {
                return HttpNotFound();
            }
            return View(gHE);
        }

        // POST: GHEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GHE gHE = db.GHEs.Find(id);
            db.GHEs.Remove(gHE);
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
