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
using C43QLXeKhach.Services.TRAMXEsService;
using C43QLXeKhach.Services.TINHTHANHsService;

namespace C43QLXeKhach.Controllers
{
    public class TRAMXEsController : Controller
    {
        ITramXeService service;
        ILogger logger = LogManager.GetCurrentClassLogger();

        public TRAMXEsController(ITramXeService service)
        {
            this.service = service;
        }

        // GET: TRAMXEs
        public ActionResult Index()
        {
            return View(service.GetAll());
        }

        // GET: TRAMXEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IList<TRAMXE> tRAMXE = service.Detail(id);
            ViewBag.maTT = tRAMXE[0].TINHTHANH.TenTT;
            if (tRAMXE == null)
            {
                return HttpNotFound();
            }
            return View(tRAMXE);
        }

        // GET: TRAMXEs/Create
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

        // POST: TRAMXEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTram,TenTram,MaTT,DiaChi,MoTa,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] TRAMXE tRAMXE)
        {
            string thuocTinhThanh = Request.Form["tinhThanhDropList"].ToString();
            if (ModelState.IsValid)
            {
                tRAMXE.isDeleted = 0;
                tRAMXE.MaTT = thuocTinhThanh;
                service.Add(tRAMXE);
                return RedirectToAction("Index");
            }

            return View(tRAMXE);
        }

        // GET: TRAMXEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TRAMXE tRAMXE = db.TRAMXEs.Find(id);
            IList<TRAMXE> tRAMXE = service.Detail(id);
            if (tRAMXE == null)
            {
                return HttpNotFound();
            }

            ITinhThanhService tinhThanhService = new TinhThanhService();
            IList<TINHTHANH> tinhThanhList = tinhThanhService.GetAll();
            List<SelectListItem> listItems = new List<SelectListItem>();
            for (int i = 0; i < tinhThanhList.Count; i++)
            {
                if (tRAMXE[0].MaTT == tinhThanhList[i].MaTT)
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
            ViewBag.listItems = listItems;
            return View(tRAMXE[0]);
        }

        // POST: TRAMXEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTram,TenTram,MaTT,DiaChi,MoTa,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] TRAMXE tRAMXE)
        {
            string thuocTinhThanh = Request.Form["tinhThanhDropList"].ToString();

            if (ModelState.IsValid)
            {
                ITinhThanhService tinhThanhService = new TinhThanhService();
                TINHTHANH tt = tinhThanhService.Detail(thuocTinhThanh);
                IList<TRAMXE> tram = service.Detail(tRAMXE.MaTram);
                tram[0].MaTT = thuocTinhThanh;
                tram[0].TenTram = tRAMXE.TenTram;
                tram[0].DiaChi = tRAMXE.DiaChi;
                tram[0].MoTa = tRAMXE.MoTa;
                tram[0].TINHTHANH = tt;
                service.Update(tram[0]);
                return RedirectToAction("Index");
            }
            return View(tRAMXE);
        }

        // GET: TRAMXEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TRAMXE tRAMXE = db.TRAMXEs.Find(id);
            IList<TRAMXE> tRAMXE = service.Detail(id);
            if (tRAMXE == null)
            {
                return HttpNotFound();
            }
            return View(tRAMXE);
        }

        // POST: TRAMXEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IList<TRAMXE> tRAMXE = service.Detail(id);
            tRAMXE[0].isDeleted = 1;
            service.Delete(tRAMXE[0]);
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
                IList<TRAMXE> tRAMXE = service.Detail(Int32.Parse(listDelete[i]));
                tRAMXE[0].isDeleted = 1;
                service.Delete(tRAMXE[0]);
            }
            return RedirectToAction("Index");
        }
    }
}
