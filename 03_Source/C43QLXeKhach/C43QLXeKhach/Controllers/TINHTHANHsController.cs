using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using C43QLXeKhach.Models;
using NLog;
using C43QLXeKhach.Services.TINHTHANHsService;

namespace C43QLXeKhach.Controllers
{
    public class TINHTHANHsController : Controller
    {
        ITinhThanhService service;
        ILogger logger = LogManager.GetCurrentClassLogger();

        public TINHTHANHsController(ITinhThanhService service)
        {
            this.service = service;
        }

        // GET: TINHTHANHs
        public ActionResult Index()
        {
            return View(service.GetAll());
        }

        // GET: TINHTHANHs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINHTHANH tINHTHANH = service.Detail(id);
            if (tINHTHANH == null)
            {
                return HttpNotFound();
            }
            return View(tINHTHANH);
        }

        // GET: TINHTHANHs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TINHTHANHs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTT,TenTT,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] TINHTHANH tINHTHANH)
        {
            if (ModelState.IsValid)
            {
                tINHTHANH.isDeleted = 0;
                service.Add(tINHTHANH);
                return RedirectToAction("Index");
            }

            return View(tINHTHANH);
        }

        // GET: TINHTHANHs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINHTHANH tINHTHANH = service.Detail(id);
            if (tINHTHANH == null)
            {
                return HttpNotFound();
            }
            return View(tINHTHANH);
        }

        // POST: TINHTHANHs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTT,TenTT,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] TINHTHANH tINHTHANH)
        {
            if (ModelState.IsValid)
            {
                TINHTHANH tt = service.Detail(tINHTHANH.MaTT);
                tt.TenTT = tINHTHANH.TenTT;
                service.Update(tt);
                return RedirectToAction("Index");
            }
            return View(tINHTHANH);
        }

        // GET: TINHTHANHs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINHTHANH tINHTHANH = service.Detail(id);
            if (tINHTHANH == null)
            {
                return HttpNotFound();
            }
            return View(tINHTHANH);
        }

        // POST: TINHTHANHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TINHTHANH tINHTHANH = service.Detail(id);
            tINHTHANH.isDeleted = 1;
            service.Delete(tINHTHANH);
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Index")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMany()
        {
            string temp = Request.Form["deletecheckbox"];
            if (temp == null)
            {
                return RedirectToAction("Index");
            }
            string[] listDelete = temp.Split(',');
            for (int i = 0; i < listDelete.Length; i++)
            {
                TINHTHANH tINHTHANH = service.Detail((listDelete[i]));
                tINHTHANH.isDeleted = 1;
                service.Delete(tINHTHANH);
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                service.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
