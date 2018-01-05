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
using C43QLXeKhach.Services.XEsService;
using C43QLXeKhach.Services.LOAIXEsService;

namespace C43QLXeKhach.Controllers
{
    public class XEsController : Controller
    {
        IXeService service;
        ILogger logger = LogManager.GetCurrentClassLogger();

        public XEsController(IXeService service)
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
            IList<XE> xE = service.Detail(id);
            XE xe = new XE();
           
            ViewBag.loaixe = xE[0].LOAIXE1.TenLoai;
            if (xE == null)
            {
                return HttpNotFound();
            }
            xe = xE[0];
            return View(xe);
        }

        // GET: TRAMXEs/Create
        public ActionResult Create()
        {
            ILoaiXeService loaiXeService = new LoaiXeService();
            IList<LOAIXE> loaiXeList = loaiXeService.GetAll();
            List<SelectListItem> listItems = new List<SelectListItem>();
            for (int i = 0; i < loaiXeList.Count; i++)
            {
                listItems.Add(new SelectListItem
                {
                    Text = loaiXeList[i].TenLoai,
                    Value = loaiXeList[i].MaLoai.ToString()
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
        public ActionResult Create([Bind(Include = "MaXe,LoaiXe,BienSoXe,HangXe,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] XE xE)
        {
            string thuocXe = Request.Form["xeDropList"];
            if (ModelState.IsValid)
            {
                xE.isDeleted = 0;
                xE.LoaiXe = Int32.Parse(thuocXe);
                service.Add(xE);
                return RedirectToAction("Index");
            }

            return View(xE);
        }

        // GET: TRAMXEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TRAMXE tRAMXE = db.TRAMXEs.Find(id);
            IList<XE> xE = service.Detail(id);
            if (xE == null)
            {
                return HttpNotFound();
            }

            ILoaiXeService loaiXeService = new LoaiXeService();
            IList<LOAIXE> loaiXeList = loaiXeService.GetAll();
            List<SelectListItem> listItems = new List<SelectListItem>();
            for (int i = 0; i < loaiXeList.Count; i++)
            {
                if (xE[0].LoaiXe == loaiXeList[i].MaLoai)
                {
                    listItems.Add(new SelectListItem
                    {
                        Text = loaiXeList[i].TenLoai,
                        Value = loaiXeList[i].MaLoai.ToString(),
                        Selected = true

                    });
                }
                else
                {
                    listItems.Add(new SelectListItem
                    {
                        Text = loaiXeList[i].TenLoai,
                        Value = loaiXeList[i].MaLoai.ToString()

                    });
                }
            }
            ViewBag.listItems = listItems;
            return View(xE[0]);
        }

        // POST: TRAMXEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaXe,LoaiXe,BienSoXe,HangXe,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] XE xE)
        {
            int thuocXe;
            int.TryParse(Request.Form["xeDropList"], out thuocXe);

            if (ModelState.IsValid)
            {
                ILoaiXeService loaiXeService = new LoaiXeService();
                LOAIXE lx = loaiXeService.Detail(thuocXe);
                IList<XE> xe = service.Detail(xE.MaXe);
                xe[0].LoaiXe = thuocXe;
                xe[0].BienSoXe = xE.BienSoXe;
                xe[0].HangXe = xE.HangXe;
                service.Update(xe[0]);
                return RedirectToAction("Index");
            }
            return View(xE);
        }

        // GET: TRAMXEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TRAMXE tRAMXE = db.TRAMXEs.Find(id);
            IList<XE> xE = service.Detail(id);
            if (xE == null)
            {
                return HttpNotFound();
            }
            return View(xE);
        }

        // POST: TRAMXEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IList<XE> xE = service.Detail(id);
            xE[0].isDeleted = 1;
            service.Delete(xE[0]);
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
                IList<XE> xE = service.Detail(Int32.Parse(listDelete[i]));
                xE[0].isDeleted = 1;
                service.Delete(xE[0]);
            }
            return RedirectToAction("Index");
        }
    }
}
