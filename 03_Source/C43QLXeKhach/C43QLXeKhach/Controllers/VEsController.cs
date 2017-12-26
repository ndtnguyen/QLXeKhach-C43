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
using C43QLXeKhach.Services.KHACHHANGsService;
using System.Security.Cryptography;
using System.Text;
using C43QLXeKhach.Utils;

namespace C43QLXeKhach.Controllers
{
    public class VEsController : Controller
    {
        IVeService service;
        IKhachHangService khService;
        ILogger logger = LogManager.GetCurrentClassLogger();

        public VEsController(IVeService service,IKhachHangService khService)
        {
            this.service = service;
            this.khService = khService;
        }
        // GET: VEs
        public ActionResult Index()
        {
            return View(service.GetAll());
        }
        //GetDiemDi
        [HttpGet]
        public ActionResult DiemDi()
        {
            var maTramLen = int.Parse(Request.Params["maTramLen"]);
            var maTramXuong = int.Parse(Request.Params["maTramXuong"]);
            var kq = service.GetDiemDi(maTramLen,maTramXuong);
            if (kq == null)
            {
                return HttpNotFound();
            }

            return Json(kq, JsonRequestBehavior.AllowGet);
        }
        //GetDiemDen
        [HttpGet]
        public ActionResult DiemDen()
        {
            var maDiemDi = Request.Params["maDiemDi"];
            var maTramLen = int.Parse(Request.Params["maTramLen"]);
            var maTramXuong = int.Parse(Request.Params["maTramXuong"]);
            var kq = service.GetDiemDen(maDiemDi,maTramLen,maTramXuong);
            if (kq == null)
            {
                return HttpNotFound();
            }

            return Json(kq, JsonRequestBehavior.AllowGet);
        }

        //GetTramLen
        [HttpGet]
        public ActionResult TramLen()
        {
            
            var kq = service.GetTramLen();
            if (kq == null)
            {
                return HttpNotFound();
            }

            return Json(kq, JsonRequestBehavior.AllowGet);
        }

        //GetTramXuong
        [HttpGet]
        public ActionResult TramXuong()
        {
            var maTramLen = int.Parse(Request.Params["maTramLen"]);
            var kq = service.GetTramXuong(maTramLen);
            if (kq == null)
            {
                return HttpNotFound();
            }

            return Json(kq, JsonRequestBehavior.AllowGet);
        }
        //GetGioKH
        [HttpGet]
        public ActionResult GioKH()
        {
            var maDiemDi = Request.Params["maDiemDi"];
            var maDiemDen = Request.Params["maDiemDen"];
            var kq = service.GetGioKH(maDiemDi, maDiemDen);
            if (kq == null)
            {
                return HttpNotFound();
            }

            return Json(kq, JsonRequestBehavior.AllowGet);
        }

        //GetGioLenXe
        [HttpGet]
        public ActionResult GioLenXe()
        {
            var maDiemDi = Request.Params["maDiemDi"];
            var maDiemDen = Request.Params["maDiemDen"];
            var maChuyen = int.Parse(Request.Params["maChuyen"]);
            var maTramLen = int.Parse(Request.Params["maTramLen"]);
            var kq = service.GetGioLenXe(maDiemDi, maDiemDen,maChuyen,maTramLen).ToString();
            if (kq == null)
            {
                return HttpNotFound();
            }

            return Json(kq, JsonRequestBehavior.AllowGet);
        }
        //GetGiaVe
        [HttpGet]
        public ActionResult GiaVe()
        {
            var maChuyen = int.Parse(Request.Params["maChuyen"]);
            var maTramLen = int.Parse(Request.Params["maTramLen"]);
            var maTramXuong = int.Parse(Request.Params["maTramXuong"]);
            var kq = service.GetGiaVe(maTramLen, maTramXuong, maChuyen).ToString();
            if (kq == null)
            {
                return HttpNotFound();
            }

            return Json(kq, JsonRequestBehavior.AllowGet);
        }
        //GetGheTrong
        [HttpGet]
        public ActionResult GheTrong()
        {
            var maChuyen = int.Parse(Request.Params["maChuyen"]);
            var kq = service.GetGheTrong(maChuyen);
            if (kq == null)
            {
                return HttpNotFound();
            }

            return Json(kq, JsonRequestBehavior.AllowGet);
        }
        //GetKhachHang
        [HttpGet]
        public ActionResult KhachHang()
        {
            var sdt = Request.Params["SDT"];
            var kq = khService.GetKH_SDT(sdt);
            

            return Json(kq, JsonRequestBehavior.AllowGet);
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
        public ActionResult Create([Bind(Include="TenKH,SDT,CMND,DiaChi,Email")] KHACHHANG KH, [Bind(Include = "GiaMua,MaChuyen,TramLen,TramXuong,GioDi,MaXe")] VE vE, string strGhe,string MaKH)
        {
            if (ModelState.IsValid)
            {
                string[] dsGhe= strGhe.Split(',');
                int maKHNew=-1;
                if (MaKH=="") {
                    KH.isDeleted = 0;
                    maKHNew = khService.Add(KH);
                }
                else
                {
                    maKHNew = int.Parse(MaKH);
                }            
                DateTime current = DateTime.Now;
                for(int i = 0; i < dsGhe.Length; i++)
                {
                    vE.MaKH = maKHNew;
                    vE.MaGhe = int.Parse(dsGhe[i]);
                    vE.isDeleted = 0;
                    vE.NgayMua = current;
                    service.Add(vE);
;                }            
                return RedirectToAction("Index");
            }

            return View(vE);
        }

        // GET: VEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACHHANG kHACHHANG = khService.GetKH_MaVe(id);
            if(kHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACHHANG);
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
