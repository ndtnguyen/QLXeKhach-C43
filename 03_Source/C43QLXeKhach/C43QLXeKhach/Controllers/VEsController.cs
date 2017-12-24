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
using C43QLXeKhach.Services.VEsService;
using System.Security.Cryptography;
using System.Text;
using C43QLXeKhach.Utils;

namespace C43QLXeKhach.Controllers
{
    public class VEsController : Controller
    {
        IVeService service;
        ILogger logger = LogManager.GetCurrentClassLogger();

        public VEsController(IVeService service)
        {
            this.service = service;
        }
        // GET: VEs
        public ActionResult Index()
        {
            return View(service.GetAll());
        }

        // GET: VEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vw_ve vE = service.Detail(id);
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
                
                return RedirectToAction("Index");
            }

            return View(vE);
        }

        // GET: VEs/Edit/5
        public ActionResult Edit(int? id)
        {
          
            return View();
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
                
                return RedirectToAction("Index");
            }
            return View(vE);
        }

        // GET: VEs/Delete/5
        public ActionResult Delete(int? id)
        {
           
            return View();
        }

        // POST: VEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
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
                VE vE = service.LoadVeWWithMaVe(int.Parse(listDelete[i]));
                vE.isDeleted = 1;
                service.Delete(vE);
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
