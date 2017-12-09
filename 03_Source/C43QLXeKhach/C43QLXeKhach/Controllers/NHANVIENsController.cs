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
using C43QLXeKhach.Services.NHANVIENsService;
using System.Security.Cryptography;
using System.Text;
using C43QLXeKhach.Utils;

namespace C43QLXeKhach.Controllers
{
    public class NHANVIENsController : Controller
    {
        INhanVienService service;
        ILogger logger = LogManager.GetCurrentClassLogger();

        public NHANVIENsController(INhanVienService service)
        {
            this.service = service;
        }


        // GET: NHANVIENs
        public ActionResult Index()
        {
            //if (Request.Params["input"] == null)
                return View(service.GetAll());
            /*else
                return View(service.Search(Request.Params["input"]));*/
        }

        // GET: NHANVIENs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = service.Detail(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // GET: NHANVIENs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NHANVIENs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNV,TenNV,CMND,NgaySinh,DiaChi,SDT,Email,Password,TrangThaiTaiKhoan,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] NHANVIEN nHANVIEN)
        {
            if (ModelState.IsValid)
            {
                nHANVIEN.Password = EncryptionUtil.instant(nHANVIEN.CMND);
                nHANVIEN.TrangThaiTaiKhoan = 0;
                nHANVIEN.isDeleted = 0;
                service.Add(nHANVIEN);
                return RedirectToAction("Index");
            }

            return View(nHANVIEN);
        }
        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // GET: NHANVIENs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = service.Detail(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // POST: NHANVIENs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNV,TenNV,CMND,NgaySinh,DiaChi,SDT,Email,Password,TrangThaiTaiKhoan,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] NHANVIEN nHANVIEN)
        {
            if (ModelState.IsValid)
            {
                NHANVIEN nv = service.Detail(nHANVIEN.MaNV);
                nv.TenNV = nHANVIEN.TenNV;
                nv.CMND = nHANVIEN.CMND;
                nv.NgaySinh = nHANVIEN.NgaySinh;
                nv.DiaChi = nHANVIEN.DiaChi;
                nv.SDT = nHANVIEN.SDT;
                service.Update(nv);
               return RedirectToAction("Index");
            }
            return View(nHANVIEN);
        }
        // GET: NHANVIENs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = service.Detail(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // POST: NHANVIENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NHANVIEN nHANVIEN = service.Detail(id);
            nHANVIEN.isDeleted = 1;
            service.Delete(nHANVIEN);
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Index")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMany()
        {
            string temp = Request.Form["deletecheckbox"];
            if(temp==null)
            {
                return RedirectToAction("Index");
            }
            string []listDelete = temp.Split(',');
            for(int i=0;i< listDelete.Length;i++)
            {
                NHANVIEN nHANVIEN = service.Detail(int.Parse(listDelete[i]));
                nHANVIEN.isDeleted = 1;
                service.Delete(nHANVIEN);
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
