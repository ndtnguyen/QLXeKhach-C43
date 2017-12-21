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
using C43QLXeKhach.Services.LOTRINHsService;
using C43QLXeKhach.Services.TRAMXEsService;
using C43QLXeKhach.Services.TUYENXEsService;

namespace C43QLXeKhach.Controllers
{
    public class LOTRINHsController : Controller
    {
        ILoTrinhService service;
        ILogger logger = LogManager.GetCurrentClassLogger();

        public LOTRINHsController(ILoTrinhService service)
        {
            this.service = service;
        }

        // GET: LOTRINHs
        public ActionResult Index()
        {
            return View(service.GetAll());
        }

        // GET: LOTRINHs/Details/5
        public ActionResult Details(int? id, int? id1)
        {
            if (id == null || id1 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IList<LOTRINH> lOTRINH = service.Detail(id, id1);
            if (lOTRINH == null)
            {
                return HttpNotFound();
            }
            return View(lOTRINH);
        }

        // GET: LOTRINHs/Create
        public ActionResult Create()
        {
            ITuyenXeService tuyenXeService = new TuyenXeService();
            ITramXeService tramXeService = new TramXeService();
            IList<TUYENXE> tuyenXeList = tuyenXeService.GetAll();
            IList<TRAMXE> tramXeList = tramXeService.GetAll();
            List<SelectListItem> listItems = new List<SelectListItem>();
            List<SelectListItem> listItems1 = new List<SelectListItem>();
            for (int i = 0; i < tuyenXeList.Count; i++)
            {
                listItems.Add(new SelectListItem
                {
                    Text = tuyenXeList[i].DiemDi + "-" + tuyenXeList[i].DiemDen,
                    Value = tuyenXeList[i].MaTuyen.ToString()
                });
            }
            for (int i = 0; i < tramXeList.Count; i++)
            {
                listItems1.Add(new SelectListItem
                {
                    Text = tramXeList[i].TenTram,
                    Value = tramXeList[i].MaTram.ToString()
                });
            }
            ViewBag.listItems = listItems;
            ViewBag.listItems1 = listItems1;
            return View();
        }

        // POST: LOTRINHs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTuyen,MaTram,ThuTu,KhoangThoiGian,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] LOTRINH lOTRINH)
        {
            string thuocTuyenXe = Request.Form["tuyenXeDropList"].ToString();
            string thuocTramXe = Request.Form["tramXeDropList"].ToString();
            ITuyenXeService tuyenXeService = new TuyenXeService();
            IList<TUYENXE> tx = tuyenXeService.Detail(Int32.Parse(thuocTuyenXe));
            ITramXeService tramXeService = new TramXeService();
            IList<TRAMXE> txe = tramXeService.Detail(Int32.Parse(thuocTramXe));
            if (ModelState.IsValid)
            {
                if (lOTRINH.ThuTu == 1)
                {
                    if (txe[0].MaTT == tx[0].DiemDi)
                    {
                        lOTRINH.isDeleted = 0;
                        lOTRINH.MaTuyen = Int32.Parse(thuocTuyenXe);
                        lOTRINH.MaTram = Int32.Parse(thuocTramXe);
                        service.Add(lOTRINH);
                        return RedirectToAction("Index", "TUYENXEs");
                    }
                    else
                    {
                        return RedirectToAction("Create");
                    }
                }
                else
                {
                    lOTRINH.isDeleted = 0;
                    lOTRINH.MaTuyen = Int32.Parse(thuocTuyenXe);
                    lOTRINH.MaTram = Int32.Parse(thuocTramXe);
                    service.Add(lOTRINH);
                    return RedirectToAction("Index");
                }                
            }

            return View(lOTRINH);
        }

        // GET: LOTRINHs/Edit/5, 10001
        public ActionResult Edit(int? id, int? id1)
        {
            if (id == null || id1 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IList<LOTRINH> lOTRINH = service.Detail(id, id1);
            if (lOTRINH == null)
            {
                return HttpNotFound();
            }
            ITuyenXeService tuyenXeService = new TuyenXeService();
            ITramXeService tramXeService = new TramXeService();
            IList<TUYENXE> tuyenXeList = tuyenXeService.GetAll();
            IList<TRAMXE> tramXeList = tramXeService.GetAll();
            List<SelectListItem> listItems = new List<SelectListItem>();
            List<SelectListItem> listItems1 = new List<SelectListItem>();
            for (int i = 0; i < tuyenXeList.Count; i++)
            {
                if (lOTRINH[0].MaTuyen == tuyenXeList[i].MaTuyen)
                {
                    listItems.Add(new SelectListItem
                    {
                        Text = tuyenXeList[i].MaTuyen.ToString(),
                        Value = tuyenXeList[i].MaTuyen.ToString(),
                        Selected = true

                    });
                }
                else
                {
                    listItems.Add(new SelectListItem
                    {
                        Text = tuyenXeList[i].MaTuyen.ToString(),
                        Value = tuyenXeList[i].MaTuyen.ToString()

                    });
                }
            }
            for (int i = 0; i < tramXeList.Count; i++)
            {
                if (lOTRINH[0].MaTram == tramXeList[i].MaTram)
                {
                    listItems1.Add(new SelectListItem
                    {
                        Text = tramXeList[i].TenTram.ToString(),
                        Value = tramXeList[i].MaTram.ToString(),
                        Selected = true

                    });
                }
                else
                {
                    listItems1.Add(new SelectListItem
                    {
                        Text = tramXeList[i].TenTram.ToString(),
                        Value = tramXeList[i].MaTram.ToString()

                    });
                }
            }
            ViewBag.listItems = listItems;
            ViewBag.listItems1 = listItems1;
            return View(lOTRINH[0]);
        }

        // POST: LOTRINHs/Edit/5, 10001
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTuyen,MaTram,ThuTu,KhoangThoiGian,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] LOTRINH lOTRINH)
        {
            string thuocTuyenXe = Request.Form["tuyenXeDropList"].ToString();
            string thuocTramXe = Request.Form["tramXeDropList"].ToString();
            int maTuyen = Int32.Parse(thuocTuyenXe);
            int maTram = Int32.Parse(thuocTramXe);

            if (ModelState.IsValid)
            {
                ITuyenXeService tuyenXeService = new TuyenXeService();
                ITramXeService tramXeService = new TramXeService();
                IList<TUYENXE> tuyenxe = tuyenXeService.Detail(maTuyen);
                IList<TRAMXE> tramxe = tramXeService.Detail(maTram);
                IList<LOTRINH> ltrinh = service.Detail(lOTRINH.MaTuyen, lOTRINH.MaTram);
                IList<LOTRINH> lt = service.Detail(lOTRINH.MaTuyen);
                if (ltrinh[0].ThuTu == 1 || ltrinh[0].ThuTu == lt.Count)
                {
                    if (tramxe[0].MaTT == tuyenxe[0].DiemDi || tramxe[0].MaTT == tuyenxe[0].DiemDen)
                    {
                        ltrinh[0].MaTuyen = maTuyen;
                        ltrinh[0].MaTram = maTram;
                        ltrinh[0].ThuTu = lOTRINH.ThuTu;
                        ltrinh[0].KhoangThoiGian = lOTRINH.KhoangThoiGian;
                        ltrinh[0].TUYENXE = tuyenxe[0];
                        ltrinh[0].TRAMXE = tramxe[0];
                        service.Update(lOTRINH);
                        return RedirectToAction("Index");
                    } 
                    else
                    {
                        return RedirectToAction("Index");
                    }                   
                }      
                else
                {
                    ltrinh[0].MaTuyen = maTuyen;
                    ltrinh[0].MaTram = maTram;
                    ltrinh[0].ThuTu = lOTRINH.ThuTu;
                    ltrinh[0].KhoangThoiGian = lOTRINH.KhoangThoiGian;
                    ltrinh[0].TUYENXE = tuyenxe[0];
                    ltrinh[0].TRAMXE = tramxe[0];
                    service.Update(lOTRINH);
                    return RedirectToAction("Index");
                }          
            }
            return View(lOTRINH);
        }

        // GET: LOTRINHs/Delete/5
        public ActionResult Delete(int? id, int? id1)
        {
            if (id == null || id1 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TRAMXE tRAMXE = db.TRAMXEs.Find(id);
            IList<LOTRINH> lOTRINH = service.Detail(id, id1);
            if (lOTRINH == null)
            {
                return HttpNotFound();
            }
            return View(lOTRINH);
        }

        // POST: LOTRINHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int id1)
        {
            IList<LOTRINH> lOTRINH = service.Detail(id, id1);
            lOTRINH[0].isDeleted = 1;
            service.Delete(lOTRINH[0]);
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
                IList<LOTRINH> lOTRINH = service.Detail(Int32.Parse(listDelete[i]), Int32.Parse(listDelete[i]));
                lOTRINH[0].isDeleted = 1;
                service.Delete(lOTRINH[0]);
            }
            return RedirectToAction("Index");
        }
    }
}
