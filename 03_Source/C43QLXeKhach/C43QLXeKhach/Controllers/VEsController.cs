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
    public class VEsController : Controller
    {
        private QLXeKhachEntities db = new QLXeKhachEntities();

        // GET: VEs
        public ActionResult Index()
        {
            return View(db.VEs.ToList());
        }

        // GET: VEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VE vE = db.VEs.Find(id);
            if (vE == null)
            {
                return HttpNotFound();
            }
            return View(vE);
        }

        // GET: VEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaVe,NgayMua,GiaMua,MaGhe,MaXe,MaChuyen,MaKH,TramLen,TramXuong,GioDi,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] VE vE)
        {
            if (ModelState.IsValid)
            {
                db.VEs.Add(vE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vE);
        }

        // GET: VEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VE vE = db.VEs.Find(id);
            if (vE == null)
            {
                return HttpNotFound();
            }
            return View(vE);
        }

        // POST: VEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaVe,NgayMua,GiaMua,MaGhe,MaXe,MaChuyen,MaKH,TramLen,TramXuong,GioDi,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] VE vE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vE);
        }

        // GET: VEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VE vE = db.VEs.Find(id);
            if (vE == null)
            {
                return HttpNotFound();
            }
            return View(vE);
        }

        // POST: VEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VE vE = db.VEs.Find(id);
            db.VEs.Remove(vE);
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
