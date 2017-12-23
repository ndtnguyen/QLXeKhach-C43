using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using C43QLXeKhach.Models;
using C43QLXeKhach.Constant;

namespace C43QLXeKhach.Services.TUYENXEsService
{
    public class TuyenXeService : ITuyenXeService
    {
        public IList<TUYENXE> GetAll()
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.TUYENXEs.Where(x => x.isDeleted != 1).Include(x => x.TINHTHANH).ToList();
            }
        }

        public int Add(TUYENXE tuyen)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                var user = HttpContext.Current.Session[GlobalConstant.USER];
                if (user != null)
                {
                    NHANVIEN currentUser = (NHANVIEN)user;
                    tuyen.createUser = currentUser.MaNV;
                    tuyen.lastupdateUser = currentUser.MaNV;
                }
                DateTime current = DateTime.Now;
                tuyen.createDate = current;
                tuyen.lastupdateDate = current;
                context.TUYENXEs.Add(tuyen);
                context.SaveChanges();
                return 1;
            }
        }

        public void Update(TUYENXE tuyen)
        {
            var user = HttpContext.Current.Session[GlobalConstant.USER];
            if (user != null)
            {
                NHANVIEN currentUser = (NHANVIEN)user;
                tuyen.lastupdateUser = currentUser.MaNV;
            }
            DateTime current = DateTime.Now;
            tuyen.lastupdateDate = current;
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Entry(tuyen).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(TUYENXE tuyen)
        {
            var user = HttpContext.Current.Session[GlobalConstant.USER];
            if (user != null)
            {
                NHANVIEN currentUser = (NHANVIEN)user;
                tuyen.lastupdateUser = currentUser.MaNV;
            }
            DateTime current = DateTime.Now;
            tuyen.lastupdateDate = current;
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Entry(tuyen).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public IList<TUYENXE> Detail(int? id)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                //return context.TUYENXEs.Find(id);
                return context.TUYENXEs.Where(x => x.MaTuyen == id).Include(x => x.TINHTHANH).ToList();
            }
        }

        public void Dispose()
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Dispose();
            }
        }

        /*public IList<TUYENXE> Search(string input)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.TUYENXEs.Where(x => x.isDeleted != 1 && (x.Tentuyen.Contains(input) || x.DiaChi.Contains(input) || input == "")).ToList();
            }
        }*/
    }
}