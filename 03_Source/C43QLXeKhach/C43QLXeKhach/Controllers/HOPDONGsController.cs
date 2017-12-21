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
using C43QLXeKhach.Services.HOPDONGsService;
using C43QLXeKhach.Services.NHANVIENsService;
using C43QLXeKhach.Services.TRAMXEsService;
using C43QLXeKhach.Services.DOITACsService;
using System.Collections;

namespace C43QLXeKhach.Controllers
{
    public class HOPDONGsController : Controller
    {
        IHopDongService service;
        ILogger logger = LogManager.GetCurrentClassLogger();
        public HOPDONGsController(IHopDongService service)
        {
            this.service = service;
        }

        // GET: HOPDONGs
        public ActionResult Index()
        {
            return View(service.GetAll());
        }

        // GET: HOPDONGs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IList<HOPDONG> hOPDONG = service.Detail(id);
            if (hOPDONG == null)
            {
                return HttpNotFound();
            }
            return View(hOPDONG[0]);
        }

        // GET: HOPDONGs/Create
        public ActionResult Create()
        {
            INhanVienService nhanVienService = new NhanVienService();
            IList<NHANVIEN> nhanVienList = nhanVienService.GetAll();
            List<SelectListItem> listNhanVien = new List<SelectListItem>();
            for (int i = 0; i < nhanVienList.Count; i++)
            {
                listNhanVien.Add(new SelectListItem
                {
                    Text = nhanVienList[i].TenNV,
                    Value = nhanVienList[i].MaNV.ToString()
                });
            }
            ViewBag.listNhanVien = listNhanVien;

            IDoiTacService doiTacService = new DoiTacService();
            IList<DOITAC> doiTacList = doiTacService.GetAll();
            List<SelectListItem> listDoiTac = new List<SelectListItem>();
            for (int i = 0; i < doiTacList.Count; i++)
            {
                listDoiTac.Add(new SelectListItem
                {
                    Text = doiTacList[i].TenDT,
                    Value = doiTacList[i].MaDT.ToString()
                });
            }
            ViewBag.listDoiTac = listDoiTac;

            ITramXeService tramXeService = new TramXeService();
            IList<TRAMXE> tramXeList = tramXeService.GetAll();
            List<SelectListItem> listTramXe = new List<SelectListItem>();
            for (int i = 0; i < tramXeList.Count; i++)
            {
                listTramXe.Add(new SelectListItem
                {
                    Text = tramXeList[i].TenTram,
                    Value = tramXeList[i].MaTram.ToString()
                });
            }
            ViewBag.listTramXe = listTramXe;

            return View();
        }

        // POST: HOPDONGs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHD,NgayLap,GiaThoaThuan,MaTram,ThoiHanThue,MaDT,NguoiLap,MoTa,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] HOPDONG hOPDONG)
        {
            string nguoiLap = Request.Form["nhanVienDropList"].ToString();
            string doiTac = Request.Form["doiTacDropList"].ToString();
            string tramXe = Request.Form["tramXeDropList"].ToString();
            if (ModelState.IsValid)
            {
                hOPDONG.isDeleted = 0;
                hOPDONG.NguoiLap = Int32.Parse(nguoiLap);
                hOPDONG.MaDT = Int32.Parse(doiTac);
                hOPDONG.MaTram = Int32.Parse(tramXe);
                service.Add(hOPDONG);
                return RedirectToAction("Index");
            }
            return View(hOPDONG);
        }

        // GET: HOPDONGs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IList<HOPDONG> hOPDONG = service.Detail(id);
            if (hOPDONG == null)
            {
                return HttpNotFound();
            }

            INhanVienService nhanVienService = new NhanVienService();
            IList<NHANVIEN> nhanVienList = nhanVienService.GetAll();
            List<SelectListItem> listNhanVien = new List<SelectListItem>();
            for (int i = 0; i < nhanVienList.Count; i++)
            {
                if (hOPDONG[0].NguoiLap == nhanVienList[i].MaNV)
                {
                    listNhanVien.Add(new SelectListItem
                    {
                        Text = nhanVienList[i].TenNV,
                        Value = nhanVienList[i].MaNV.ToString(),
                        Selected = true

                    });
                }
                else
                {
                    listNhanVien.Add(new SelectListItem
                    {
                        Text = nhanVienList[i].TenNV,
                        Value = nhanVienList[i].MaNV.ToString()
                    });
                }
            }
            ViewBag.listNhanVien = listNhanVien;

            IDoiTacService doiTacService = new DoiTacService();
            IList<DOITAC> doiTacList = doiTacService.GetAll();
            List<SelectListItem> listDoiTac = new List<SelectListItem>();
            for (int i = 0; i < doiTacList.Count; i++)
            {
                if (hOPDONG[0].MaDT == doiTacList[i].MaDT)
                {
                    listDoiTac.Add(new SelectListItem
                    {
                        Text = doiTacList[i].TenDT,
                        Value = doiTacList[i].MaDT.ToString(),
                        Selected = true

                    });
                }
                else
                {
                    listDoiTac.Add(new SelectListItem
                    {
                        Text = doiTacList[i].TenDT,
                        Value = doiTacList[i].MaDT.ToString()
                    });
                }
            }
            ViewBag.listDoiTac = listDoiTac;

            ITramXeService tramXeService = new TramXeService();
            IList<TRAMXE> tramXeList = tramXeService.GetAll();
            List<SelectListItem> listTramXe = new List<SelectListItem>();
            for (int i = 0; i < tramXeList.Count; i++)
            {
                if (hOPDONG[0].MaTram == tramXeList[i].MaTram)
                {
                    listTramXe.Add(new SelectListItem
                    {
                        Text = tramXeList[i].TenTram,
                        Value = tramXeList[i].MaTram.ToString(),
                        Selected = true

                    });
                }
                else
                {
                    listTramXe.Add(new SelectListItem
                    {
                        Text = tramXeList[i].TenTram,
                        Value = tramXeList[i].MaTram.ToString()
                    });
                }
            }
            ViewBag.listTramXe = listTramXe;
            return View(hOPDONG[0]);
        }

        // POST: HOPDONGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHD,NgayLap,GiaThoaThuan,MaTram,ThoiHanThue,MaDT,NguoiLap,MoTa,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] HOPDONG hOPDONG)
        {
            string nguoiLap = Request.Form["nhanVienDropList"].ToString();
            string doiTac = Request.Form["doiTacDropList"].ToString();
            string tramXe = Request.Form["tramXeDropList"].ToString();
            if (ModelState.IsValid)
            {
                INhanVienService nhanVienService = new NhanVienService();
                NHANVIEN nv = nhanVienService.Detail(Int32.Parse(nguoiLap));

                IDoiTacService doiTacService = new DoiTacService();
                DOITAC dtac = doiTacService.Detail(Int32.Parse(doiTac));

                ITramXeService tramXeService = new TramXeService();
                TRAMXE tx = tramXeService.Detail(Int32.Parse(tramXe))[0];

                IList<HOPDONG> hd = service.Detail(hOPDONG.MaHD);
                hd[0].NgayLap = hOPDONG.NgayLap;
                hd[0].GiaThoaThuan = hOPDONG.GiaThoaThuan;
                hd[0].MaTram = Int32.Parse(tramXe);
                hd[0].ThoiHanThue = hOPDONG.ThoiHanThue;
                hd[0].MaDT = Int32.Parse(doiTac);
                hd[0].NguoiLap = Int32.Parse(nguoiLap);
                hd[0].MoTa = hOPDONG.MoTa;
                hd[0].NHANVIEN = nv;
                hd[0].DOITAC = dtac;
                hd[0].TRAMXE = tx;
                service.Update(hd[0]);
                return RedirectToAction("Index");
            }
            return View(hOPDONG);
        }

        // GET: HOPDONGs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IList<HOPDONG> hOPDONG = service.Detail(id);
            if (hOPDONG == null)
            {
                return HttpNotFound();
            }
            return View(hOPDONG);
        }

        // POST: HOPDONGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IList<HOPDONG> hOPDONG = service.Detail(id);
            hOPDONG[0].isDeleted = 1;
            service.Delete(hOPDONG[0]);
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
                IList<HOPDONG> hOPDONG = service.Detail(Int32.Parse(listDelete[i]));
                hOPDONG[0].isDeleted = 1;
                service.Delete(hOPDONG[0]);
            }
            return RedirectToAction("Index");
        }
    }
}