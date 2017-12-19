using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using C43QLXeKhach.Models;
using System.Data.Entity;
using System.Text;
using C43QLXeKhach.Constant;
using C43QLXeKhach.Utils;

namespace C43QLXeKhach.Services.KHACHHANGsService
{
    public class KhachHangService : IKhachHangService
    {
        public IList<KHACHHANG> GetAll()
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.KHACHHANGs.Where(x=>x.isDeleted!=1).ToList();
            }
        }
        public int Add(KHACHHANG kh)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                var user = HttpContext.Current.Session[GlobalConstant.USER];
                if (user != null)
                {
                    NHANVIEN currentUser = (NHANVIEN)user;
                    kh.createUser= currentUser.MaNV;
                    kh.lastupdateUser = currentUser.MaNV;
                }
                DateTime current = DateTime.Now;
                kh.createDate = current;
                kh.lastupdateDate = current;
                context.KHACHHANGs.Add(kh);
                context.SaveChanges();
                return 1;
            }
        }
        public void Update(KHACHHANG kh)
        {
            var user = HttpContext.Current.Session[GlobalConstant.USER];
            if (user != null)
            {
                NHANVIEN currentUser = (NHANVIEN)user;
                kh.lastupdateUser = currentUser.MaNV;
            }
            DateTime current = DateTime.Now;
            kh.lastupdateDate = current;
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Entry(kh).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Delete(KHACHHANG kh)
        {
            var user = HttpContext.Current.Session[GlobalConstant.USER];
            if (user != null)
            {
                NHANVIEN currentUser = (NHANVIEN)user;
                kh.lastupdateUser = currentUser.MaNV;
            }
            DateTime current = DateTime.Now;
            kh.lastupdateDate = current;
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Entry(kh).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public KHACHHANG Detail(int? id)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.KHACHHANGs.Find(id);
            }
        }

        public void Dispose()
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Dispose();
            }
        }


        public IList<KHACHHANG> Search(string input)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.KHACHHANGs.Where(x => x.isDeleted != 1 && (x.TenKH.Contains(input) || input == "")).ToList();
            }
        }
    }
}