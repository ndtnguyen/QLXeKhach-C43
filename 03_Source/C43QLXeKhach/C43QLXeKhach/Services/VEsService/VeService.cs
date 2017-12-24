using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using C43QLXeKhach.Models;
using System.Data.Entity;
using System.Text;
using C43QLXeKhach.Constant;
using C43QLXeKhach.Utils;

namespace C43QLXeKhach.Services.VEsService
{
    public class VeService :IVeService
    {
        public IList<vw_ve> GetAll()
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.vw_ve.ToList();
            }
        }
        public int Add(VE v)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                var user = HttpContext.Current.Session[GlobalConstant.USER];
                if (user != null)
                {
                    NHANVIEN currentUser = (NHANVIEN)user;
                    v.createUser = currentUser.MaNV;
                    v.lastupdateUser = currentUser.MaNV;
                }
                DateTime current = DateTime.Now;
                v.createDate = current;
                v.lastupdateDate = current;
                context.VEs.Add(v);
                context.SaveChanges();
                return 1;
            }
        }
        public void Update(VE v)
        {
            var user = HttpContext.Current.Session[GlobalConstant.USER];
            if (user != null)
            {
                NHANVIEN currentUser = (NHANVIEN)user;
                v.lastupdateUser = currentUser.MaNV;
            }
            DateTime current = DateTime.Now;
            v.lastupdateDate = current;
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Entry(v).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Delete(VE v)
        {
            var user = HttpContext.Current.Session[GlobalConstant.USER];
            if (user != null)
            {
                NHANVIEN currentUser = (NHANVIEN)user;
                v.lastupdateUser = currentUser.MaNV;
            }
            DateTime current = DateTime.Now;
            v.lastupdateDate = current;
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Entry(v).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public vw_ve Detail(int ?id)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.vw_ve.Where(x => x.MaVe == id).FirstOrDefault();
            }
        }
        public VE LoadVeWWithMaVe(int ?id)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.VEs.Find(id);
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