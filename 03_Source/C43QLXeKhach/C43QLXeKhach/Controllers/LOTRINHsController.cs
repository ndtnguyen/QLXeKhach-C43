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
        private QLXeKhachEntities db = new QLXeKhachEntities();
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
        [HttpPost]
        public LOTRINH GetDetails(string maTuyen, string maTram)
        {
            System.Diagnostics.Debug.WriteLine("hello1");
            if (maTuyen == null || maTram == null)
            {
                return null;
            }
            LOTRINH lOTRINH = db.LOTRINHs.Find(Int32.Parse(maTuyen), Int32.Parse(maTram));
            return lOTRINH;
        }

        // GET: LOTRINHs/Details/5
        [HttpPost]
        public ActionResult Details()
        {
            string maTuyen = Request["maTuyen"];
            string maTram = Request["maTram"];
            if (maTuyen == null || maTram == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOTRINH lOTRINH = db.LOTRINHs.Find(Int32.Parse(maTuyen), Int32.Parse(maTram));
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
                lOTRINH.isDeleted = 0;
                lOTRINH.MaTuyen = Int32.Parse(thuocTuyenXe);
                lOTRINH.MaTram = Int32.Parse(thuocTramXe);
                service.Add(lOTRINH);
                return RedirectToAction("Index");
            }

            return View(lOTRINH);
        }

        // GET: LOTRINHs/Edit/5
        [HttpPost]
        public ActionResult EditView()
        {
            string maTuyen = Request["maTuyen"];
            string maTram = Request["maTram"];
            if (maTuyen == null || maTram == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOTRINH lOTRINH = db.LOTRINHs.Find(Int32.Parse(maTuyen), Int32.Parse(maTram));
            if (lOTRINH == null)
            {
                return HttpNotFound();
            }
            return View("Edit", lOTRINH);
        }

        // POST: LOTRINHs/Edit/5, 10001
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        {
            string maTuyen = Request["maTuyen"];
            string maTram = Request["maTram"];
            string tgian = Request["tgian"];
            if (maTuyen == null || maTram == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOTRINH lOTRINH = db.LOTRINHs.Find(Int32.Parse(maTuyen), Int32.Parse(maTram));
            if (lOTRINH == null)
            {
                return HttpNotFound();
            }
            lOTRINH.KhoangThoiGian = Int32.Parse(tgian);
            db.Entry(lOTRINH).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: LOTRINHs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOTRINH lOTRINH = db.LOTRINHs.Find(id);
            if (lOTRINH == null)
            {
                return HttpNotFound();
            }
            return View(lOTRINH);
        }

        // POST: LOTRINHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LOTRINH lOTRINH = db.LOTRINHs.Find(id);
            db.LOTRINHs.Remove(lOTRINH);
            db.SaveChanges();
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

            string[] paramList = temp.Split('+', ' ');

            for (int i = 0; i < paramList.Length - 1; i++)
            {
                string[] param = paramList[i].Split(',', ' ');
                string maTuyen = param[0], maTram = param[1];
                IList<LOTRINH> ltrinh = service.Detail(Int32.Parse(maTuyen), Int32.Parse(maTram));
                ltrinh[0].isDeleted = 1;
                service.Delete(ltrinh[0]);
            }
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
