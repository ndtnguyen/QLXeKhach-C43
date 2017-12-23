using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using C43QLXeKhach.Constant;
using C43QLXeKhach.Models;


namespace C43QLXeKhach.Services.LOTRINHsService
{
    public class LoTrinhService : ILoTrinhService
    {
        public IList<LOTRINH> GetAll()
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.LOTRINHs.Where(x => x.isDeleted != 1).Include(x => x.TRAMXE).ToList();
            }
        }
        public int Add(LOTRINH ltrinh)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                var user = HttpContext.Current.Session[GlobalConstant.USER];
                if (user != null)
                {
                    NHANVIEN currentUser = (NHANVIEN)user;
                    ltrinh.createUser = currentUser.MaNV;
                    ltrinh.lastupdateUser = currentUser.MaNV;
                }
                DateTime current = DateTime.Now;
                ltrinh.createDate = current;
                ltrinh.lastupdateDate = current;
                context.LOTRINHs.Add(ltrinh);
                context.SaveChanges();
                return 1;
            }
        }
        public void Update(LOTRINH ltrinh)
        {
            var user = HttpContext.Current.Session[GlobalConstant.USER];
            if (user != null)
            {
                NHANVIEN currentUser = (NHANVIEN)user;
                ltrinh.lastupdateUser = currentUser.MaNV;
            }
            DateTime current = DateTime.Now;
            ltrinh.lastupdateDate = current;
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Entry(ltrinh).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Delete(LOTRINH ltrinh)
        {
            var user = HttpContext.Current.Session[GlobalConstant.USER];
            if (user != null)
            {
                NHANVIEN currentUser = (NHANVIEN)user;
                ltrinh.lastupdateUser = currentUser.MaNV;
            }
            DateTime current = DateTime.Now;
            ltrinh.lastupdateDate = current;
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Entry(ltrinh).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Dispose()
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Dispose();
            }
        }

        /*public IList<LOTRINH> Search(string input)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.TRAMXEs.Where(x => x.isDeleted != 1 && (x.TenTram.Contains(input) || x.DiaChi.Contains(input) || input == "")).ToList();
            }
        }*/
        public IList<LOTRINH> Detail(int? id, int? id1)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                //return context.TRAMXEs.Find(id);
                return context.LOTRINHs.Where(x => x.MaTuyen == id && x.MaTram == id1).Include(x => x.TRAMXE).ToList();

            }
        }
        public IList<LOTRINH> Detail(int? id)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                //return context.TRAMXEs.Find(id);
                return context.LOTRINHs.Where(x => x.MaTuyen == id).Include(x => x.TRAMXE).ToList();

            }
        }
    }
}