using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using C43QLXeKhach.Models;
using C43QLXeKhach.Constant;
using System.Data.Entity;
using System.Collections;

namespace C43QLXeKhach.Services.KHAOSATsService
{
    public class KhaoSatService : IKhaoSatService
    {
        public int Add(KHAOSAT ks)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                var user = HttpContext.Current.Session[GlobalConstant.USER];
                if (user != null)
                {
                    NHANVIEN currentUser = (NHANVIEN)user;
                    ks.createUser = currentUser.MaNV;
                    ks.lastupdateUser = currentUser.MaNV;
                }
                DateTime current = DateTime.Now;
                ks.createDate = current;
                ks.lastupdateDate = current;
                context.KHAOSATs.Add(ks);
                context.SaveChanges();
                return 1;
            }
        }

        public void Delete(KHAOSAT ks)
        {
            var user = HttpContext.Current.Session[GlobalConstant.USER];
            if (user != null)
            {
                NHANVIEN currentUser = (NHANVIEN)user;
                ks.lastupdateUser = currentUser.MaNV;
            }
            DateTime current = DateTime.Now;
            ks.lastupdateDate = current;
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Entry(ks).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public IList<KHAOSAT> Detail(int? id)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.KHAOSATs.Where(x => x.MaKS == id).Include(x => x.NHANVIEN).ToList();

            }
        }

        public void Dispose()
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Dispose();
            }
        }

        public IList<KHAOSAT> GetAll()
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.KHAOSATs.Where(x => x.isDeleted == 0).Include(x => x.NHANVIEN).ToList();
            }
        }

        public void Update(KHAOSAT ks)

        {
            var user = HttpContext.Current.Session[GlobalConstant.USER];
            if (user != null)
            {
                NHANVIEN currentUser = (NHANVIEN)user;
                ks.lastupdateUser = currentUser.MaNV;
            }
            DateTime current = DateTime.Now;
            ks.lastupdateDate = current;
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Entry(ks).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}