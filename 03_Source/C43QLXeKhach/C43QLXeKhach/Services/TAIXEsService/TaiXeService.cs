using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using C43QLXeKhach.Models;
using System.Data.Entity;
using System.Text;
using C43QLXeKhach.Constant;
using C43QLXeKhach.Utils;
namespace C43QLXeKhach.Services.TAIXEsService
{
    public class TaiXeService : ITaiXeService
    {
        public IList<TAIXE> GetAll()
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.TAIXEs.Where(x => x.isDeleted != 1).ToList();
            }
        }
        public int Add(TAIXE tx)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                var user = HttpContext.Current.Session[GlobalConstant.USER];
                if (user != null)
                {
                    NHANVIEN currentUser = (NHANVIEN)user;
                    tx.createUser = currentUser.MaNV;
                    tx.lastupdateUser = currentUser.MaNV;
                }
                DateTime current = DateTime.Now;
                tx.createDate = current;
                tx.lastupdateDate = current;
                context.TAIXEs.Add(tx);
                context.SaveChanges();
                return 1;
            }
        }
        public void Update(TAIXE tx)
        {
            var user = HttpContext.Current.Session[GlobalConstant.USER];
            if (user != null)
            {
                NHANVIEN currentUser = (NHANVIEN)user;
                tx.lastupdateUser = currentUser.MaNV;
            }
            DateTime current = DateTime.Now;
            tx.lastupdateDate = current;
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Entry(tx).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Delete(TAIXE tx)
        {
            var user = HttpContext.Current.Session[GlobalConstant.USER];
            if (user != null)
            {
                NHANVIEN currentUser = (NHANVIEN)user;
                tx.lastupdateUser = currentUser.MaNV;
            }
            DateTime current = DateTime.Now;
            tx.lastupdateDate = current;
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Entry(tx).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public TAIXE Detail(int? id)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.TAIXEs.Find(id);
            }
        }
        public void Dispose()
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Dispose();
            }
        }
    }
}