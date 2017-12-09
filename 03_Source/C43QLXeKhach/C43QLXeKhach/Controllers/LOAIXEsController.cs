using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using C43QLXeKhach.Models;
using C43QLXeKhach.Services.LOAIXEsService;

namespace C43QLXeKhach.Controllers
{
    public class LOAIXEsController : Controller
    {
        private QLXeKhachEntities db = new QLXeKhachEntities();
        ILoaiXeService service;
        // GET: LOAIXEs
        public ActionResult Index()
        {
            return View(service.GetAll());
            
        }

        // GET: LOAIXEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIXE lOAIXE = db.LOAIXEs.Find(id);
            if (lOAIXE == null)
            {
                return HttpNotFound();
            }
            return View(lOAIXE);
        }

        // GET: LOAIXEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LOAIXEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoai,TenLoai,SLGhe,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] LOAIXE lOAIXE)
        {
            if (ModelState.IsValid)
            {
                db.LOAIXEs.Add(lOAIXE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lOAIXE);
        }

        // GET: LOAIXEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIXE lOAIXE = db.LOAIXEs.Find(id);
            if (lOAIXE == null)
            {
                return HttpNotFound();
            }
            return View(lOAIXE);
        }

        // POST: LOAIXEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoai,TenLoai,SLGhe,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] LOAIXE lOAIXE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOAIXE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lOAIXE);
        }

        // GET: LOAIXEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIXE lOAIXE = db.LOAIXEs.Find(id);
            if (lOAIXE == null)
            {
                return HttpNotFound();
            }
            return View(lOAIXE);
        }

        // POST: LOAIXEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LOAIXE lOAIXE = db.LOAIXEs.Find(id);
            db.LOAIXEs.Remove(lOAIXE);
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
