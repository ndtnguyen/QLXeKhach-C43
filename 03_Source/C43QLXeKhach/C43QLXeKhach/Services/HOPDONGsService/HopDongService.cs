using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using C43QLXeKhach.Models;
using C43QLXeKhach.Constant;
using System.Data.Entity;

namespace C43QLXeKhach.Services.HOPDONGsService
{
    public class HopDongService : IHopDongService
    {
        public IList<HOPDONG> GetAll()
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.HOPDONGs.Where(x => x.isDeleted == 0).Include(x => x.TRAMXE).Include(x => x.DOITAC).Include(x => x.NHANVIEN).ToList();
            }
        }
        public int Add(HOPDONG hd)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                var user = HttpContext.Current.Session[GlobalConstant.USER];
                if (user != null)
                {
                    NHANVIEN currentUser = (NHANVIEN)user;
                    hd.createUser = currentUser.MaNV;
                    hd.lastupdateUser = currentUser.MaNV;
                }
                DateTime current = DateTime.Now;
                hd.createDate = current;
                hd.lastupdateDate = current;
                context.HOPDONGs.Add(hd);
                context.SaveChanges();
                return 1;
            }
        }
        public void Update(HOPDONG hd)
        {
            var user = HttpContext.Current.Session[GlobalConstant.USER];
            if (user != null)
            {
                NHANVIEN currentUser = (NHANVIEN)user;
                hd.lastupdateUser = currentUser.MaNV;
            }
            DateTime current = DateTime.Now;
            hd.lastupdateDate = current;
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Entry(hd).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Delete(HOPDONG hd)
        {
            var user = HttpContext.Current.Session[GlobalConstant.USER];
            if (user != null)
            {
                NHANVIEN currentUser = (NHANVIEN)user;
                hd.lastupdateUser = currentUser.MaNV;
            }
            DateTime current = DateTime.Now;
            hd.lastupdateDate = current;
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Entry(hd).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public IList<HOPDONG> Detail(int? id)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.HOPDONGs.Where(x => x.MaHD == id).Include(x => x.TRAMXE).Include(x => x.DOITAC).Include(x => x.NHANVIEN).ToList();
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