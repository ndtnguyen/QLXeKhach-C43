using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using C43QLXeKhach.Models;
using System.Data.Entity;
using C43QLXeKhach.Constant;

namespace C43QLXeKhach.Services.XEsService
{
    public class XeService : IXeService
    {
        public IList<XE> GetAll()
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.XEs.Where(x => x.isDeleted != 1).Include(x => x.LOAIXE1).ToList();
            }
        }

        public int Add(XE xe)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                var user = HttpContext.Current.Session[GlobalConstant.USER];
                if (user != null)
                {
                    NHANVIEN currentUser = (NHANVIEN)user;
                    xe.createUser = currentUser.MaNV;
                    xe.lastupdateUser = currentUser.MaNV;
                }
                DateTime current = DateTime.Now;
                xe.createDate = current;
                xe.lastupdateDate = current;
                var result = context.XEs.Add(xe);
                context.SaveChanges();
                LOAIXE loaiXe = context.LOAIXEs.Find(xe.LoaiXe);
                for (int i=0; i < loaiXe.SLGhe; i++)
                {
                    GHE ghe = new GHE();
                    ghe.createDate = DateTime.Now;
                    ghe.lastupdateDate = DateTime.Now;
                    ghe.MaGhe = i + 1;
                    ghe.MaXe = xe.MaXe;
               
                }
                return 1;
            }
        }

        public void Update(XE xe)
        {
            var user = HttpContext.Current.Session[GlobalConstant.USER];
            if (user != null)
            {
                NHANVIEN currentUser = (NHANVIEN)user;
                xe.lastupdateUser = currentUser.MaNV;
            }
            DateTime current = DateTime.Now;
            xe.lastupdateDate = current;
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Entry(xe).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(XE xe)
        {
            var user = HttpContext.Current.Session[GlobalConstant.USER];
            if (user != null)
            {
                NHANVIEN currentUser = (NHANVIEN)user;
                xe.lastupdateUser = currentUser.MaNV;
            }
            DateTime current = DateTime.Now;
            xe.lastupdateDate = current;
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Entry(xe).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public IList <XE> Detail(int? id)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                 // return context.XEs.Find(id);
               return context.XEs.Where(x => x.MaXe == id).Include(x => x.LOAIXE1).ToList();

            }
        }

        public void Dispose()
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Dispose();
            }
        }


        public IList<XE> Search(string input)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.XEs.Where(x => x.isDeleted != 1 && (x.BienSoXe.Contains(input) || x.HangXe.Contains(input) || input == "")).ToList();
            }
        }



    }
}