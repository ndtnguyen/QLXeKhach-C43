using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using C43QLXeKhach.Models;

using C43QLXeKhach.Services.LOAIXEsService;
using NLog;

namespace C43QLXeKhach.Controllers
{
    public class LOAIXEsController : Controller
    {
        ILoaiXeService service;
        ILogger logger = LogManager.GetCurrentClassLogger();
        public LOAIXEsController(ILoaiXeService service)
        {
            this.service = service;
        }

        // GET: LOAIXEs
        public ActionResult Index()
        {
            return View(service.GetAll());
        }

        // GET: LOAIXEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LOAIXEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoai,TenLoai,SLGhe,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] LOAIXE lOAIXE)
        {
            if (ModelState.IsValid)
            {
                lOAIXE.isDeleted = 0;
                service.Add(lOAIXE);
                return RedirectToAction("Index");
            }
            return View(lOAIXE);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIXE lOAIXE = service.Detail(id);
            if (lOAIXE == null)
            {
                return HttpNotFound();
            }
            return View(lOAIXE);
        }

        // GET: LOAIXEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIXE lOAIXE = service.Detail(id);
            if (lOAIXE == null)
            {
                return HttpNotFound();
            }
            return View(lOAIXE);
        }

        // POST: LOAIXEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoai,TenLoai,SLGhe,createUser,lastupdateUser,createDate,lastupdateDate,isDeleted")] LOAIXE lOAIXE)
        {
            if (ModelState.IsValid)
            {
                LOAIXE lx = service.Detail(lOAIXE.MaLoai);
                lx.TenLoai = lOAIXE.TenLoai;
                lx.SLGhe = lOAIXE.SLGhe;
                service.Update(lx);
                return RedirectToAction("Index");
            }
            return View(lOAIXE);
        }

        // GET: LOAIXEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIXE lOAIXE = service.Detail(id);
            if (lOAIXE == null)
            {
                return HttpNotFound();
            }
            return View(lOAIXE);
        }

        // POST: LOAIXEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LOAIXE lOAIXE = service.Detail(id);
            lOAIXE.isDeleted = 1;
            service.Delete(lOAIXE);
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
                LOAIXE lOAIXE = service.Detail(int.Parse(listDelete[i]));
                lOAIXE.isDeleted = 1;
                service.Delete(lOAIXE);
            }
            return RedirectToAction("Index");
        }
    }
}
