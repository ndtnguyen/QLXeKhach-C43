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
    public class TUYENXEsController : Controller
    {
        private QLXeKhachEntities db = new QLXeKhachEntities();

        // GET: TUYENXEs
        public ActionResult Index()
        {
            return View(db.TUYENXEs.ToList());
        }

        // GET: TUYENXEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TUYENXE tUYENXE = db.TUYENXEs.Find(id);
            if (tUYENXE == null)
            {
                return HttpNotFound();
            }
            return View(tUYENXE);
        }

        // GET: TUYENXEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TUYENXEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTuyen,DiemDi,DiemDen,QuangDuong,ThoiGian,SoChuyen1Ngay,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] TUYENXE tUYENXE)
        {
            if (ModelState.IsValid)
            {
                db.TUYENXEs.Add(tUYENXE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tUYENXE);
        }

        // GET: TUYENXEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TUYENXE tUYENXE = db.TUYENXEs.Find(id);
            if (tUYENXE == null)
            {
                return HttpNotFound();
            }
            return View(tUYENXE);
        }

        // POST: TUYENXEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTuyen,DiemDi,DiemDen,QuangDuong,ThoiGian,SoChuyen1Ngay,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] TUYENXE tUYENXE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tUYENXE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tUYENXE);
        }

        // GET: TUYENXEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TUYENXE tUYENXE = db.TUYENXEs.Find(id);
            if (tUYENXE == null)
            {
                return HttpNotFound();
            }
            return View(tUYENXE);
        }

        // POST: TUYENXEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TUYENXE tUYENXE = db.TUYENXEs.Find(id);
            db.TUYENXEs.Remove(tUYENXE);
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
