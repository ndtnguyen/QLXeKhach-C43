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
using C43QLXeKhach.Services.TAIXEsService;

namespace C43QLXeKhach.Controllers
{
    public class TAIXEsController : Controller
    {
        ITaiXeService service;
        ILogger logger = LogManager.GetCurrentClassLogger();

        public TAIXEsController(ITaiXeService service)
        {
            this.service = service;
        }

        // GET: TAIXEs
        public ActionResult Index()
        {
            return View(service.GetAll());
        }

        // GET: TAIXEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAIXE tAIXE = service.Detail(id);
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
                tAIXE.isDeleted = 0;
                service.Add(tAIXE);
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
            TAIXE tAIXE =service.Detail(id);
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
                TAIXE tx = service.Detail(tAIXE.MaTX);
                tx.TenTX = tAIXE.TenTX;
                tx.CMND = tAIXE.CMND;
                tx.SDT = tAIXE.SDT;
                tx.DiaChi = tAIXE.DiaChi;
                tx.NgaySinh = tAIXE.NgaySinh;
                tx.SoBangLai = tAIXE.SoBangLai;
                tx.LoaiBangLai = tAIXE.LoaiBangLai;
                tx.ThoiHanBangLai = tAIXE.ThoiHanBangLai;
                service.Update(tx);
                return RedirectToAction("Index");
            }
            return View(tAIXE);
        }

        //// GET: TAIXEs/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    TAIXE tAIXE = db.TAIXEs.Find(id);
        //    if (tAIXE == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tAIXE);
        //}

        //// POST: TAIXEs/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    TAIXE tAIXE = db.TAIXEs.Find(id);
        //    db.TAIXEs.Remove(tAIXE);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
                TAIXE tAIXE = service.Detail(int.Parse(listDelete[i]));
                tAIXE.isDeleted = 1;
                service.Delete(tAIXE);
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
