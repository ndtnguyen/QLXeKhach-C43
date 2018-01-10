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
using C43QLXeKhach.Services.TUYENXEsService;
using C43QLXeKhach.Services.TINHTHANHsService;

namespace C43QLXeKhach.Controllers
{
    public class TUYENXEsController : Controller
    {
        private QLXeKhachEntities db = new QLXeKhachEntities();
        ITuyenXeService service;
        ILogger logger = LogManager.GetCurrentClassLogger();

        public TUYENXEsController(ITuyenXeService service)
        {
            this.service = service;
        }

        // GET: TUYENXEs
        public ActionResult Index()
        {
            return View(service.GetAll());
        }

        // GET: TUYENXEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TUYENXE tUYENXE = db.TUYENXEs.Find(id);
            if (tUYENXE == null)
            {
                return HttpNotFound();
            }
            return View(tUYENXE);
        }

        // GET: TUYENXEs/Create
        public ActionResult Create()
        {
            ITinhThanhService tinhThanhService = new TinhThanhService();
            IList<TINHTHANH> tinhThanhList = tinhThanhService.GetAll();
            List<SelectListItem> listItems = new List<SelectListItem>();
            for (int i = 0; i < tinhThanhList.Count; i++)
            {
                listItems.Add(new SelectListItem
                {
                    Text = tinhThanhList[i].TenTT,
                    Value = tinhThanhList[i].MaTT.ToString()
                });
            }
            ViewBag.listItems = listItems;
            return View();
        }

        // POST: TUYENXEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTuyen,DiemDi,DiemDen,QuangDuong,ThoiGian,SoChuyen1Ngay,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] TUYENXE tUYENXE)
        {
            string thuocTinhThanh = Request.Form["tinhThanhDropList"].ToString();
            string thuocTinhThanh1 = Request.Form["tinhThanhDropList1"].ToString();
            if (thuocTinhThanh != thuocTinhThanh1)
            {
                if (ModelState.IsValid)
                {
                    tUYENXE.isDeleted = 0;
                    tUYENXE.DiemDi = thuocTinhThanh;
                    tUYENXE.DiemDen = thuocTinhThanh1;
                    service.Add(tUYENXE);
                    return RedirectToAction("Index");
                }
            }            
            else { return RedirectToAction("Create"); }
            return View(tUYENXE);
        }

        // GET: TUYENXEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            IList<TUYENXE> tUYENXE = service.Detail(id);
            if (tUYENXE == null)
            {
                return HttpNotFound();
            }
            ITinhThanhService tinhThanhService = new TinhThanhService();
            IList<TINHTHANH> tinhThanhList = tinhThanhService.GetAll();
            List<SelectListItem> listItems = new List<SelectListItem>();
            IList<TINHTHANH> tinhThanhList1 = tinhThanhService.GetAll();
            List<SelectListItem> listItems1 = new List<SelectListItem>();
            for (int i = 0; i < tinhThanhList.Count; i++)
            {                
                if (tUYENXE[0].DiemDi == tinhThanhList[i].MaTT)
                {
                    listItems.Add(new SelectListItem
                    {
                        Text = tinhThanhList[i].TenTT,
                        Value = tinhThanhList[i].MaTT.ToString(),
                        Selected = true

                    });
                }
                else
                {
                    listItems.Add(new SelectListItem
                    {
                        Text = tinhThanhList[i].TenTT,
                        Value = tinhThanhList[i].MaTT.ToString()

                    });
                }
            }
            for (int i = 0; i < tinhThanhList1.Count; i++)
            {
                if (tUYENXE[0].DiemDen == tinhThanhList1[i].MaTT)
                {
                    listItems1.Add(new SelectListItem
                    {
                        Text = tinhThanhList1[i].TenTT,
                        Value = tinhThanhList1[i].MaTT.ToString(),
                        Selected = true

                    });
                }
                else
                {
                    listItems1.Add(new SelectListItem
                    {
                        Text = tinhThanhList1[i].TenTT,
                        Value = tinhThanhList1[i].MaTT.ToString()

                    });
                }
            }
            ViewBag.listItems = listItems;
            ViewBag.listItems1 = listItems1;
            return View(tUYENXE[0]);
        }

        // POST: TUYENXEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTuyen,DiemDi,DiemDen,QuangDuong,ThoiGian,SoChuyen1Ngay,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] TUYENXE tUYENXE)
        {
            string thuocTinhThanh = Request.Form["tinhThanhDropList"].ToString();
            string thuocTinhThanh1 = Request.Form["tinhThanhDropList1"].ToString();
            if (thuocTinhThanh != thuocTinhThanh1)
            {
                if (ModelState.IsValid)
                {
                    ITinhThanhService tinhThanhService = new TinhThanhService();
                    TINHTHANH tt = tinhThanhService.Detail(thuocTinhThanh);
                    TINHTHANH tt1 = tinhThanhService.Detail(thuocTinhThanh1);
                    IList<TUYENXE> tuyen = service.Detail(tUYENXE.MaTuyen);
                    tuyen[0].DiemDi = thuocTinhThanh;
                    tuyen[0].DiemDen = thuocTinhThanh1;
                    tuyen[0].QuangDuong = tUYENXE.QuangDuong;
                    tuyen[0].ThoiGian = tUYENXE.ThoiGian;
                    tuyen[0].SoChuyen1Ngay = tUYENXE.SoChuyen1Ngay;
                    tuyen[0].TINHTHANH = tt;
                    tuyen[0].TINHTHANH = tt1;
                    service.Update(tuyen[0]);
                    return RedirectToAction("Index");
                }
            }  
            else { return RedirectToAction("Index"); }         
            return View(tUYENXE);
        }

        // GET: TUYENXEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IList<TUYENXE> tUYENXE = service.Detail(id);
            if (tUYENXE == null)
            {
                return HttpNotFound();
            }
            return View(tUYENXE);
        }

        // POST: TUYENXEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IList<TUYENXE> tUYENXE = service.Detail(id);
            tUYENXE[0].isDeleted = 1;
            service.Delete(tUYENXE[0]);
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
                IList<TUYENXE> tUYENXE = service.Detail(Int32.Parse(listDelete[i]));
                tUYENXE[0].isDeleted = 1;
                service.Delete(tUYENXE[0]);
            }
            return RedirectToAction("Index");
        }
    }
}
