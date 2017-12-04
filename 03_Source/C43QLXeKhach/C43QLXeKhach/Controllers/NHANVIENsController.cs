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
using C43QLXeKhach.Services.NHANVIENsService;
namespace C43QLXeKhach.Controllers
{
    public class NHANVIENsController : Controller
    {
        INhanVienService service;
        ILogger logger = LogManager.GetCurrentClassLogger();

        public NHANVIENsController(INhanVienService service)
        {
            this.service = service;
        }


        // GET: NHANVIENs
        public ActionResult Index()
        {
            return View(service.GetAll());
        }

        // GET: NHANVIENs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = service.Detail(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // GET: NHANVIENs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NHANVIENs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNV,TenNV,CMND,NgaySinh,DiaChi,SDT,Email,Password,TrangThaiTaiKhoan,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] NHANVIEN nHANVIEN)
        {
            if (ModelState.IsValid)
            {
                service.Add(nHANVIEN);
                return RedirectToAction("Index");
            }

            return View(nHANVIEN);
        }

        // GET: NHANVIENs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = service.Detail(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // POST: NHANVIENs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNV,TenNV,CMND,NgaySinh,DiaChi,SDT,Email,Password,TrangThaiTaiKhoan,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] NHANVIEN nHANVIEN)
        {
            if (ModelState.IsValid)
            {
                service.Update(nHANVIEN);
               return RedirectToAction("Index");
            }
            return View(nHANVIEN);
        }

        // GET: NHANVIENs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = service.Detail(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // POST: NHANVIENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NHANVIEN nHANVIEN = service.Detail(id);
            service.Delete(nHANVIEN);
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Index")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMany()
        {
            string temp = Request.Form["deletecheckbox"];
            if(temp==null)
            {
                return RedirectToAction("Index");
            }
            string []listDelete = temp.Split(',');
            for(int i=0;i< listDelete.Length;i++)
            {
                NHANVIEN nHANVIEN = service.Detail(int.Parse(listDelete[i]));
                service.Delete(nHANVIEN);
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
