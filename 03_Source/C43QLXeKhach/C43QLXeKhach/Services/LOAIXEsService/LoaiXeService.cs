using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using C43QLXeKhach.Models;
using System.Data.Entity;
using System.Text;
using C43QLXeKhach.Constant;
using C43QLXeKhach.Utils;

namespace C43QLXeKhach.Services.LOAIXEsService
{
    public class LoaiXeService : ILoaiXeService
    {
        public IList<LOAIXE> GetAll()
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.LOAIXEs.Where(x => x.isDeleted == 0).ToList();
            }
        }
        public int Add(LOAIXE lx)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                var user = HttpContext.Current.Session[GlobalConstant.USER];
                if (user != null)
                {
                    NHANVIEN currentUser = (NHANVIEN)user;
                    lx.createUser = currentUser.MaNV;
                    lx.lastupdateUser = currentUser.MaNV;
                }
                DateTime current = DateTime.Now;
                lx.createDate = current;
                lx.lastupdateDate = current;
                context.LOAIXEs.Add(lx);
                context.SaveChanges();
                return 1;
            }
        }

        public void Update(LOAIXE lx)
        {
            var user = HttpContext.Current.Session[GlobalConstant.USER];
            if (user != null)
            {
                NHANVIEN currentUser = (NHANVIEN)user;
                lx.lastupdateUser = currentUser.MaNV;
            }
            DateTime current = DateTime.Now;
            lx.lastupdateDate = current;
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Entry(lx).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(LOAIXE lx)
        {
            var user = HttpContext.Current.Session[GlobalConstant.USER];
            if (user != null)
            {
                NHANVIEN currentUser = (NHANVIEN)user;
                lx.lastupdateUser = currentUser.MaNV;
            }
            DateTime current = DateTime.Now;
            lx.lastupdateDate = current;
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Entry(lx).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public LOAIXE Detail(int? id)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.LOAIXEs.Find(id);
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