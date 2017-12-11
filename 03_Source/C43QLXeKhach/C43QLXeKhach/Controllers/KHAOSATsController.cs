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
using C43QLXeKhach.Services.KHAOSATsService;
using C43QLXeKhach.Services.NHANVIENsService;
using System.Collections;

namespace C43QLXeKhach.Controllers
{
    public class KHAOSATsController : Controller
    {
        
        IKhaoSatService service;
        ILogger logger = LogManager.GetCurrentClassLogger();
        public KHAOSATsController(IKhaoSatService service)
        {
            this.service = service;
        }
       
        // GET: KHAOSATs
        public ActionResult Index()
        {
            //INhanVienService nhanVienService = new NhanVienService();
            //IList<NHANVIEN> nhanVienList = nhanVienService.GetAll();
            //ViewBag.nhanVienList = nhanVienList;
            //IList<dynamic> list =  service.GetAll();
            //ViewBag.list = list;
            return View(service.GetAll());
        }

        // GET: KHAOSATs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHAOSAT kHAOSAT = service.Detail(id);
            if (kHAOSAT == null)
            {
                return HttpNotFound();
            }
            return View(kHAOSAT);
        }

        // GET: KHAOSATs/Create
        public ActionResult Create()
        {
            INhanVienService nhanVienService = new NhanVienService();
            IList<NHANVIEN> nhanVienList = nhanVienService.GetAll();
            List<SelectListItem> listItems = new List<SelectListItem>();
            for (int i = 0; i < nhanVienList.Count; i++)
            {
                listItems.Add(new SelectListItem
                {
                    Text = nhanVienList[i].TenNV,
                    Value = nhanVienList[i].MaNV.ToString()
                });
            }
            ViewBag.listItems = listItems;
            return View();
        }

        // POST: KHAOSATs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKS,NgayKS,NguoiKS,DiaChiKS,TiLeDonKhach,GiaKS,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] KHAOSAT kHAOSAT)
        {
            
            if (ModelState.IsValid)
            {
                kHAOSAT.isDeleted = 0;
                service.Add(kHAOSAT);
                return RedirectToAction("Index");
            }
            return View(kHAOSAT);
        }

        // GET: KHAOSATs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHAOSAT kHAOSAT = service.Detail(id);
            if (kHAOSAT == null)
            {
                return HttpNotFound();
            }
            return View(kHAOSAT);
        }

        // POST: KHAOSATs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKS,NgayKS,NguoiKS,DiaChiKS,TiLeDonKhach,GiaKS,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] KHAOSAT kHAOSAT)
        {
            if (ModelState.IsValid)
            {
                KHAOSAT ks = service.Detail(kHAOSAT.MaKS);
                //ks.TenLoai = lOAIXE.TenLoai;
                //ks.SLGhe = lOAIXE.SLGhe;
                service.Update(ks);
                return RedirectToAction("Index");
            }
            return View(kHAOSAT);
        }

        // GET: KHAOSATs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHAOSAT kHAOSAT = service.Detail(id);
            if (kHAOSAT == null)
            {
                return HttpNotFound();
            }
            return View(kHAOSAT);
        }

        // POST: KHAOSATs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KHAOSAT kHAOSAT = service.Detail(id);
            kHAOSAT.isDeleted = 1;
            service.Delete(kHAOSAT);
            return RedirectToAction("Index");
        }
    }
}
