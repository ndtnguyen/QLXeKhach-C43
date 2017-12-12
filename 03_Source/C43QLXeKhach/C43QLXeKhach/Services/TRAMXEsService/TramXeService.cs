using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using C43QLXeKhach.Models;
using System.Data.Entity;
using C43QLXeKhach.Constant;

namespace C43QLXeKhach.Services.TRAMXEsService
{
    public class TramXeService : ITramXeService
    {
        public IList<TRAMXE> GetAll()
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.TRAMXEs.Where(x => x.isDeleted != 1).Include(x => x.TINHTHANH).ToList();
            }
        }

        public int Add(TRAMXE tram)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                var user = HttpContext.Current.Session[GlobalConstant.USER];
                if (user != null)
                {
                    NHANVIEN currentUser = (NHANVIEN)user;
                    tram.createUser = currentUser.MaNV;
                    tram.lastupdateUser = currentUser.MaNV;
                }
                DateTime current = DateTime.Now;
                tram.createDate = current;
                tram.lastupdateDate = current;
                context.TRAMXEs.Add(tram);
                context.SaveChanges();
                return 1;
            }
        }

        public void Update(TRAMXE tram)
        {
            var user = HttpContext.Current.Session[GlobalConstant.USER];
            if (user != null)
            {
                NHANVIEN currentUser = (NHANVIEN)user;
                tram.lastupdateUser = currentUser.MaNV;
            }
            DateTime current = DateTime.Now;
            tram.lastupdateDate = current;
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Entry(tram).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(TRAMXE tram)
        {
            var user = HttpContext.Current.Session[GlobalConstant.USER];
            if (user != null)
            {
                NHANVIEN currentUser = (NHANVIEN)user;
                tram.lastupdateUser = currentUser.MaNV;
            }
            DateTime current = DateTime.Now;
            tram.lastupdateDate = current;
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Entry(tram).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public IList<TRAMXE> Detail(int? id)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                //return context.TRAMXEs.Find(id);
                return context.TRAMXEs.Where(x => x.MaTram == id).Include(x => x.TINHTHANH).ToList();

            }
        }

        public void Dispose()
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Dispose();
            }
        }


        public IList<TRAMXE> Search(string input)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.TRAMXEs.Where(x => x.isDeleted != 1 && (x.TenTram.Contains(input) || x.DiaChi.Contains(input) || input == "")).ToList();
            }
        }



    }
}