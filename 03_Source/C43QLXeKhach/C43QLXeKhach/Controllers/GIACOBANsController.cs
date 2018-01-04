using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using C43QLXeKhach.Models;

namespace C43QLXeKhach.Controllers
{
    public class GIACOBANsController : Controller
    {
        private QLXeKhachEntities db = new QLXeKhachEntities();

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
            System.Diagnostics.Debug.WriteLine("hello2"+maTT1+maTT2);
            System.Diagnostics.Debug.WriteLine("hello1");
            if (maTT1 == null || maTT2 == null || maLoai == null)
            {
                return null;
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

        // GET: GIACOBANs/Edit/5
        public ActionResult Edit(string id1, string id2, int id3)
        {

            if (id1 == null || id2 == null || id3 < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                GIACOBAN gIACOBAN = db.GIACOBANs.Find(id1,id2,id3);
                //GIACOBAN gIACOBAN = db.GIACOBANs.Where(x=> x.MaTT1 == id1 && x.MaTT2 == id2 && x.MaLoai == id3);
                if (gIACOBAN == null)
                {
                    return HttpNotFound();
                }
                return View(gIACOBAN);
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
        public ActionResult Edit([Bind(Include = "MaTT1,MaTT2,MaLoai,GiaCoBan1,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] GIACOBAN gIACOBAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gIACOBAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gIACOBAN);
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
