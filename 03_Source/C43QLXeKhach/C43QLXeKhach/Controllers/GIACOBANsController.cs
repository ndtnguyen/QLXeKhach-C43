using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using C43QLXeKhach.Models;
using C43QLXeKhach.Services.GIACOBANsService;
using NLog;

namespace C43QLXeKhach.Controllers
{
    public class GIACOBANsController : Controller
    {

        private QLXeKhachEntities db = new QLXeKhachEntities();
        IGiaCoBanService service;
        ILogger logger = LogManager.GetCurrentClassLogger();

        public GIACOBANsController(IGiaCoBanService service)
        {
            this.service = service;
        }
        // GET: GIACOBANs
        public ActionResult Index()
        {
            return View(db.GIACOBANs.ToList());
        }
        
        //POST: GIACOBANs/Details


        // GET: GIACOBANs/Details/5
        [HttpPost]
        public GIACOBAN GetDetails(string maTT1, string maTT2, string maLoai)
        {
            System.Diagnostics.Debug.WriteLine("hello1");
            if (maTT1 == null || maTT2 == null || maLoai == null)
            {
                return null;
            }
            GIACOBAN gIACOBAN = db.GIACOBANs.Find(maTT1,maTT2,int.Parse(maLoai));
            return gIACOBAN;
        }

        // GET: GIACOBANs/Details/5
        [HttpPost]
        public ActionResult Details()
        {
            string maTT1 = Request["maTT1"];
            string maTT2 = Request["maTT2"];
            string maLoai = Request["maLoai"];
            if (maTT1 == null || maTT2 == null || maLoai == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIACOBAN gIACOBAN = db.GIACOBANs.Find(maTT1, maTT2, int.Parse(maLoai));
            return View(gIACOBAN);
        }

        // GET: GIACOBANs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GIACOBANs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTT1,MaTT2,MaLoai,GiaCoBan1,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] GIACOBAN gIACOBAN)
        {
            if (ModelState.IsValid)
            {
                db.GIACOBANs.Add(gIACOBAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gIACOBAN);
        }

        // GET: GIACOBANs/Edit/
        [HttpPost]
        public ActionResult GetEditView()
        {
            string maTT1 = Request["maTT1"];
            string maTT2 = Request["maTT2"];
            string maLoai = Request["maLoai"];
            if (maTT1 == null || maTT2 == null || maLoai == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                GIACOBAN gIACOBAN = db.GIACOBANs.Find(maTT1,maTT2,int.Parse(maLoai));
                if (gIACOBAN == null)
                {
                    return HttpNotFound();
                }
                return View("Edit",gIACOBAN);
            }
            catch (Exception e)
            {

                return null;
            }
            
        }

       

        // POST: GIACOBANs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        {
            string maTT1 = Request["maTT1"];
            string maTT2 = Request["maTT2"];
            string maLoai = Request["maLoai"];
            string gia = Request["gia"];
            if (maTT1 == null || maTT2 == null || maLoai == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                GIACOBAN gIACOBAN = db.GIACOBANs.Find(maTT1, maTT2, int.Parse(maLoai));
                //GIACOBAN gIACOBAN = db.GIACOBANs.Where(x=> x.MaTT1 == id1 && x.MaTT2 == id2 && x.MaLoai == id3);
                if (gIACOBAN == null)
                {
                    return HttpNotFound();
                }
                gIACOBAN.GiaCoBan1 = int.Parse(gia);
                db.Entry(gIACOBAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                return null;
            }
           
        }

        // GET: GIACOBANs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIACOBAN gIACOBAN = db.GIACOBANs.Find(id);
            if (gIACOBAN == null)
            {
                return HttpNotFound();
            }
            return View(gIACOBAN);
        }

        // POST: GIACOBANs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            GIACOBAN gIACOBAN = db.GIACOBANs.Find(id);
            db.GIACOBANs.Remove(gIACOBAN);
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

            string[] paramList = temp.Split('+',' ');
            
            for (int i = 0; i < paramList.Length-1; i++)
            {
                string[] param = paramList[i].Split(',',' ');
                string maTT1 = param[0], maTT2 = param[1], maLoai = param[2];
                GIACOBAN gcb = service.Detail(maTT1,maTT2,int.Parse(maLoai));
                gcb.isDeleted = 1;
                service.Delete(gcb);
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
