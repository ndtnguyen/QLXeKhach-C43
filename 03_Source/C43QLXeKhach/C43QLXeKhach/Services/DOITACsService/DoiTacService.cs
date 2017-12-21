using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using C43QLXeKhach.Models;
using System.Data.Entity;
using C43QLXeKhach.Constant;

namespace C43QLXeKhach.Services.DOITACsService
{
    public class DoiTacService : IDoiTacService
    {
        public IList<DOITAC> GetAll()
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.DOITACs.Where(x => x.isDeleted != 1).ToList();
            }
        }
        public int Add(DOITAC dtac)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                var user = HttpContext.Current.Session[GlobalConstant.USER];
                if (user != null)
                {
                    NHANVIEN currentUser = (NHANVIEN)user;
                    dtac.createUser = currentUser.MaNV;
                    dtac.lastupdateUser = currentUser.MaNV;
                }
                DateTime current = DateTime.Now;
                dtac.createDate = current;
                dtac.lastupdateDate = current;
                context.DOITACs.Add(dtac);
                context.SaveChanges();
                return 1;
            }
        }
        public void Update(DOITAC dtac)
        {
            var user = HttpContext.Current.Session[GlobalConstant.USER];
            if (user != null)
            {
                NHANVIEN currentUser = (NHANVIEN)user;
                dtac.lastupdateUser = currentUser.MaNV;
            }
            DateTime current = DateTime.Now;
            dtac.lastupdateDate = current;
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Entry(dtac).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Delete(DOITAC dtac)
        {
            var user = HttpContext.Current.Session[GlobalConstant.USER];
            if (user != null)
            {
                NHANVIEN currentUser = (NHANVIEN)user;
                dtac.lastupdateUser = currentUser.MaNV;
            }
            DateTime current = DateTime.Now;
            dtac.lastupdateDate = current;
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Entry(dtac).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public DOITAC Detail(int? id)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.DOITACs.Find(id);
            }
        }
        public void Dispose()
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Dispose();
            }
        }
        public IList<DOITAC> Search(string input)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.DOITACs.Where(x => x.isDeleted != 1 && (x.TenDT.Contains(input) || input == "")).ToList();
            }
        }
    }
}