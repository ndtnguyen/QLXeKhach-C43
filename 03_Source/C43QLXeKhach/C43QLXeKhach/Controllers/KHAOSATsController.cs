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
            return View(service.GetAll());
        }

        // GET: KHAOSATs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IList<KHAOSAT> kHAOSAT = service.Detail(id);
            ViewBag.nguoiKS = kHAOSAT[0].NHANVIEN.TenNV;
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

            string nguoiKhaoSat = Request.Form["nhanVienDropList"].ToString();
            if (ModelState.IsValid)
            {
                kHAOSAT.isDeleted = 0;
                kHAOSAT.NguoiKS = Int32.Parse(nguoiKhaoSat);
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

            IList<KHAOSAT> kHAOSAT = service.Detail(id);
            if (kHAOSAT == null)
            {
                return HttpNotFound();
            }

            INhanVienService nhanVienService = new NhanVienService();
            IList<NHANVIEN> nhanVienList = nhanVienService.GetAll();
            List<SelectListItem> listItems = new List<SelectListItem>();
            for (int i = 0; i < nhanVienList.Count; i++)
            {
                if (kHAOSAT[0].NguoiKS == nhanVienList[i].MaNV)
                {
                    listItems.Add(new SelectListItem
                    {
                        Text = nhanVienList[i].TenNV,
                        Value = nhanVienList[i].MaNV.ToString(),
                        Selected = true

                    });
                }
                else
                {
                    listItems.Add(new SelectListItem
                    {
                        Text = nhanVienList[i].TenNV,
                        Value = nhanVienList[i].MaNV.ToString()

                    });
                }
            }
            ViewBag.listItems = listItems;
            return View(kHAOSAT[0]);
        }

        // POST: KHAOSATs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKS,NgayKS,NguoiKS,DiaChiKS,TiLeDonKhach,GiaKS,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] KHAOSAT kHAOSAT)
        {

            string nguoiKhaoSat = Request.Form["nhanVienDropList"].ToString();
            if (ModelState.IsValid)
            {
                INhanVienService nhanVienService = new NhanVienService();
                NHANVIEN nv = nhanVienService.Detail(Int32.Parse(nguoiKhaoSat));
                IList<KHAOSAT> ks = service.Detail(kHAOSAT.MaKS);
                ks[0].NguoiKS = Int32.Parse(nguoiKhaoSat);
                ks[0].DiaChiKS = kHAOSAT.DiaChiKS;
                ks[0].TiLeDonKhach = kHAOSAT.TiLeDonKhach;
                ks[0].GiaKS = kHAOSAT.GiaKS;
                ks[0].NgayKS = kHAOSAT.NgayKS;
                ks[0].NHANVIEN = nv;
                service.Update(ks[0]);
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
            IList<KHAOSAT> kHAOSAT = service.Detail(id);
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
            IList<KHAOSAT> kHAOSAT = service.Detail(id);
            kHAOSAT[0].isDeleted = 1;
            service.Delete(kHAOSAT[0]);
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
                IList<KHAOSAT> kHAOSAT = service.Detail(Int32.Parse(listDelete[i]));
                kHAOSAT[0].isDeleted = 1;
                service.Delete(kHAOSAT[0]);
            }
            return RedirectToAction("Index");
        }
    }
}
