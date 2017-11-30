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
    public class TRAMXEsController : Controller
    {
        private QLXeKhachEntities db = new QLXeKhachEntities();

        // GET: TRAMXEs
        public ActionResult Index()
        {
            return View(db.TRAMXEs.ToList());
        }

        // GET: TRAMXEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRAMXE tRAMXE = db.TRAMXEs.Find(id);
            if (tRAMXE == null)
            {
                return HttpNotFound();
            }
            return View(tRAMXE);
        }

        // GET: TRAMXEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TRAMXEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTram,TenTram,MaTT,DiaChi,MoTa,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] TRAMXE tRAMXE)
        {
            if (ModelState.IsValid)
            {
                db.TRAMXEs.Add(tRAMXE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tRAMXE);
        }

        // GET: TRAMXEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRAMXE tRAMXE = db.TRAMXEs.Find(id);
            if (tRAMXE == null)
            {
                return HttpNotFound();
            }
            return View(tRAMXE);
        }

        // POST: TRAMXEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTram,TenTram,MaTT,DiaChi,MoTa,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] TRAMXE tRAMXE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tRAMXE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tRAMXE);
        }

        // GET: TRAMXEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRAMXE tRAMXE = db.TRAMXEs.Find(id);
            if (tRAMXE == null)
            {
                return HttpNotFound();
            }
            return View(tRAMXE);
        }

        // POST: TRAMXEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TRAMXE tRAMXE = db.TRAMXEs.Find(id);
            db.TRAMXEs.Remove(tRAMXE);
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
