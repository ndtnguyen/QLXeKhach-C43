using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using C43QLXeKhach.Models;
using System.Data.Entity;
using System.Text;
using C43QLXeKhach.Constant;
using C43QLXeKhach.Utils;

namespace C43QLXeKhach.Services.TRAMXEsService
{
    public class TramXeService : ITramXeService
    {
        public IList<TRAMXE> GetAll()
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.TRAMXEs.Where(x => x.isDeleted != 1).ToList();
            }
        }

        public int Add(TRAMXE tt)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                var user = HttpContext.Current.Session[GlobalConstant.USER];
                if (user != null)
                {
                    NHANVIEN currentUser = (NHANVIEN)user;
                    tt.createUser = currentUser.MaNV;
                    tt.lastupdateUser = currentUser.MaNV;
                }
                DateTime current = DateTime.Now;
                tt.createDate = current;
                tt.lastupdateDate = current;
                context.TRAMXEs.Add(tt);
                context.SaveChanges();
                return 1;
            }
        }

        public void Update(TRAMXE tt)
        {
            var user = HttpContext.Current.Session[GlobalConstant.USER];
            if (user != null)
            {
                NHANVIEN currentUser = (NHANVIEN)user;
                tt.lastupdateUser = currentUser.MaNV;
            }
            DateTime current = DateTime.Now;
            tt.lastupdateDate = current;
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Entry(tt).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(TRAMXE tt)
        {
            var user = HttpContext.Current.Session[GlobalConstant.USER];
            if (user != null)
            {
                NHANVIEN currentUser = (NHANVIEN)user;
                tt.lastupdateUser = currentUser.MaNV;
            }
            DateTime current = DateTime.Now;
            tt.lastupdateDate = current;
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Entry(tt).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public TRAMXE Detail(string id)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.TRAMXEs.Find(id);
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