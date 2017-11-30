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
    public class DOITACsController : Controller
    {
        private QLXeKhachEntities db = new QLXeKhachEntities();

        // GET: DOITACs
        public ActionResult Index()
        {
            return View(db.DOITACs.ToList());
        }

        // GET: DOITACs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOITAC dOITAC = db.DOITACs.Find(id);
            if (dOITAC == null)
            {
                return HttpNotFound();
            }
            return View(dOITAC);
        }

        // GET: DOITACs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DOITACs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDT,TenDT,NguoiDaiDien,SDT,DiaChi,Email,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] DOITAC dOITAC)
        {
            if (ModelState.IsValid)
            {
                db.DOITACs.Add(dOITAC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dOITAC);
        }

        // GET: DOITACs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOITAC dOITAC = db.DOITACs.Find(id);
            if (dOITAC == null)
            {
                return HttpNotFound();
            }
            return View(dOITAC);
        }

        // POST: DOITACs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDT,TenDT,NguoiDaiDien,SDT,DiaChi,Email,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] DOITAC dOITAC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dOITAC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dOITAC);
        }

        // GET: DOITACs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOITAC dOITAC = db.DOITACs.Find(id);
            if (dOITAC == null)
            {
                return HttpNotFound();
            }
            return View(dOITAC);
        }

        // POST: DOITACs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DOITAC dOITAC = db.DOITACs.Find(id);
            db.DOITACs.Remove(dOITAC);
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
