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
    public class TAIXEsController : Controller
    {
        private QLXeKhachEntities db = new QLXeKhachEntities();

        // GET: TAIXEs
        public ActionResult Index()
        {
            return View(db.TAIXEs.ToList());
        }

        // GET: TAIXEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAIXE tAIXE = db.TAIXEs.Find(id);
            if (tAIXE == null)
            {
                return HttpNotFound();
            }
            return View(tAIXE);
        }

        // GET: TAIXEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TAIXEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTX,TenTX,CMND,SDT,DiaChi,NgaySinh,SoBangLai,LoaiBangLai,ThoiHanBangLai,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] TAIXE tAIXE)
        {
            if (ModelState.IsValid)
            {
                db.TAIXEs.Add(tAIXE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tAIXE);
        }

        // GET: TAIXEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAIXE tAIXE = db.TAIXEs.Find(id);
            if (tAIXE == null)
            {
                return HttpNotFound();
            }
            return View(tAIXE);
        }

        // POST: TAIXEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTX,TenTX,CMND,SDT,DiaChi,NgaySinh,SoBangLai,LoaiBangLai,ThoiHanBangLai,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] TAIXE tAIXE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tAIXE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tAIXE);
        }

        // GET: TAIXEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAIXE tAIXE = db.TAIXEs.Find(id);
            if (tAIXE == null)
            {
                return HttpNotFound();
            }
            return View(tAIXE);
        }

        // POST: TAIXEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TAIXE tAIXE = db.TAIXEs.Find(id);
            db.TAIXEs.Remove(tAIXE);
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
