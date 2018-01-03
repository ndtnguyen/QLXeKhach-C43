using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using C43QLXeKhach.Models;
using System.Data.Entity;
using System.Text;
using C43QLXeKhach.Constant;
using C43QLXeKhach.Utils;
namespace C43QLXeKhach.Services.CHUYENXEsService
{
    public class ChuyenXeService : IChuyenXeService
    {
        public IList<CHUYENXE> GetAll()
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.CHUYENXEs.Where(x => x.isDeleted != 1).ToList();
            }
        }
        public int Add(CHUYENXE cx)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                var user = HttpContext.Current.Session[GlobalConstant.USER];
                if (user != null)
                {
                    NHANVIEN currentUser = (NHANVIEN)user;
                    cx.createUser = currentUser.MaNV;
                    cx.lastupdateUser = currentUser.MaNV;
                }
                DateTime current = DateTime.Now;
                cx.createDate = current;
                cx.lastupdateDate = current;
                context.CHUYENXEs.Add(cx);
                context.SaveChanges();
                return 1;
            }
        }
        public void Update(CHUYENXE cx)
        {
            var user = HttpContext.Current.Session[GlobalConstant.USER];
            if (user != null)
            {
                NHANVIEN currentUser = (NHANVIEN)user;
                cx.lastupdateUser = currentUser.MaNV;
            }
            DateTime current = DateTime.Now;
            cx.lastupdateDate = current;
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Entry(cx).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Delete(CHUYENXE cx)
        {
            var user = HttpContext.Current.Session[GlobalConstant.USER];
            if (user != null)
            {
                NHANVIEN currentUser = (NHANVIEN)user;
                cx.lastupdateUser = currentUser.MaNV;
            }
            DateTime current = DateTime.Now;
            cx.lastupdateDate = current;
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Entry(cx).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public CHUYENXE Detail(int? id)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.CHUYENXEs.Find(id);
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