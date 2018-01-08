using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using C43QLXeKhach.Models;
using System.Data.Entity;
using C43QLXeKhach.Constant;

namespace C43QLXeKhach.Services.GIACOBANsService
{
    public class GiaCoBanService : IGiaCoBanService
    {
        public IList<GIACOBAN> GetAll()
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.GIACOBANs.Where(x => x.isDeleted != 1).ToList();
            }
        }
        public int Add(GIACOBAN dtac)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                var user = HttpContext.Current.Session[GlobalConstant.USER];
                if (user != null)
                {
                    NHANVIEN currentUser = (NHANVIEN)user;
                    dtac.createUser = currentUser.MaNV;
                    dtac.lastupdateUser = currentUser.MaNV;
                }
                DateTime current = DateTime.Now;
                dtac.createDate = current;
                dtac.lastupdateDate = current;
                context.GIACOBANs.Add(dtac);
                context.SaveChanges();
                return 1;
            }
        }
        public void Update(GIACOBAN dtac)
        {
            var user = HttpContext.Current.Session[GlobalConstant.USER];
            if (user != null)
            {
                NHANVIEN currentUser = (NHANVIEN)user;
                dtac.lastupdateUser = currentUser.MaNV;
            }
            DateTime current = DateTime.Now;
            dtac.lastupdateDate = current;
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Entry(dtac).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Delete(GIACOBAN gcb)
        {
            var user = HttpContext.Current.Session[GlobalConstant.USER];
            if (user != null)
            {
                NHANVIEN currentUser = (NHANVIEN)user;
                gcb.lastupdateUser = currentUser.MaNV;
            }
            DateTime current = DateTime.Now;
            gcb.lastupdateDate = current;
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Entry(gcb).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public GIACOBAN Detail(string maTT1, string maTT2, int maLoai)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.GIACOBANs.Find(maTT1, maTT2, maLoai);
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