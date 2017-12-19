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
using C43QLXeKhach.Services.KHACHHANGsService;
using System.Text;
using C43QLXeKhach.Utils;

namespace C43QLXeKhach.Controllers
{
    public class KHACHHANGsController : Controller
    {
        IKhachHangService service;
        ILogger logger = LogManager.GetCurrentClassLogger();

        public KHACHHANGsController(IKhachHangService service)
        {
            this.service = service;
        }


        // GET: KHACHHANGs
        public ActionResult Index()
        {
            return View(service.GetAll());
        }

        // GET: KHACHHANGs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACHHANG kHACHHANG = service.Detail(id);
            if (kHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACHHANG);
        }

        // GET: KHACHHANGs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KHACHHANGs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKH,TenKH,SDT,CMND,DiaChi,NgaySinh,Email,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] KHACHHANG kHACHHANG)
        {
            if (ModelState.IsValid)
            {
          
                kHACHHANG.isDeleted = 0;
                service.Add(kHACHHANG);
                return RedirectToAction("Index");
            }

            return View(kHACHHANG);
        }

        // GET: KHACHHANGs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACHHANG kHACHHANG = service.Detail(id);
            if (kHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACHHANG);
        }

        // POST: KHACHHANGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKH,TenKH,SDT,CMND,DiaChi,NgaySinh,Email,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] KHACHHANG kHACHHANG)
        {
            if (ModelState.IsValid)
            {
                KHACHHANG kh = service.Detail(kHACHHANG.MaKH);
                kh.TenKH = kHACHHANG.TenKH;
                kh.SDT = kHACHHANG.SDT;
                kh.CMND = kHACHHANG.CMND;
                kh.DiaChi = kHACHHANG.DiaChi;
                kh.NgaySinh = kHACHHANG.NgaySinh;
                kh.Email = kHACHHANG.Email;
                service.Update(kh);
                return RedirectToAction("Index");
            }
            return View(kHACHHANG);
        }

        // GET: KHACHHANGs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACHHANG kHACHHANG = service.Detail(id);
            if (kHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACHHANG);
        }

        // POST: KHACHHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KHACHHANG kHACHHANG = service.Detail(id);
            kHACHHANG.isDeleted = 1;
            service.Delete(kHACHHANG);
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
                KHACHHANG nKhachHang = service.Detail(int.Parse(listDelete[i]));
                nKhachHang.isDeleted = 1;
                service.Delete(nKhachHang);
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
