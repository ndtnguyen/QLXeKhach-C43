using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using C43QLXeKhach.Models;
using System.Data.Entity;

namespace C43QLXeKhach.Services.NHANVIENsService
{
    public class NhanVienService : INhanVienService
    {
        public IList<NHANVIEN> GetAll()
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.NHANVIENs.ToList();
            }
        }
        public int Add(NHANVIEN nv)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.NHANVIENs.Add(nv);
                context.SaveChanges();
                return 1;
            }
        }
        public void Update(NHANVIEN nv)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Entry(nv).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Delete(NHANVIEN nv)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {

                context.NHANVIENs.Remove(nv);
                context.SaveChanges();
            }
        }
        public NHANVIEN Detail(int? id)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.NHANVIENs.Find(id);
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