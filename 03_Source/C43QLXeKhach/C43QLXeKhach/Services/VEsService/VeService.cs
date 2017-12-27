using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using C43QLXeKhach.Models;
using System.Data.Entity;
using System.Text;
using C43QLXeKhach.Constant;
using C43QLXeKhach.Utils;

namespace C43QLXeKhach.Services.VEsService
{
    public class VeService :IVeService
    {
        public IList<vw_ve> GetAll()
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.vw_ve.ToList();
            }
        }
        public int Add(VE v)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                var user = HttpContext.Current.Session[GlobalConstant.USER];
                if (user != null)
                {
                    NHANVIEN currentUser = (NHANVIEN)user;
                    v.createUser = currentUser.MaNV;
                    v.lastupdateUser = currentUser.MaNV;
                }
                DateTime current = DateTime.Now;
                v.createDate = current;
                v.lastupdateDate = current;
                context.VEs.Add(v);
                context.SaveChanges();
                return 1;
            }
        }
        public void Update(VE v)
        {
            var user = HttpContext.Current.Session[GlobalConstant.USER];
            if (user != null)
            {
                NHANVIEN currentUser = (NHANVIEN)user;
                v.lastupdateUser = currentUser.MaNV;
            }
            DateTime current = DateTime.Now;
            v.lastupdateDate = current;
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Entry(v).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Delete(VE v)
        {
            var user = HttpContext.Current.Session[GlobalConstant.USER];
            if (user != null)
            {
                NHANVIEN currentUser = (NHANVIEN)user;
                v.lastupdateUser = currentUser.MaNV;
            }
            DateTime current = DateTime.Now;
            v.lastupdateDate = current;
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Entry(v).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public vw_ve Detail(int ?id)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.vw_ve.Where(x => x.MaVe == id).FirstOrDefault();
            }
        }
        public VE LoadVeWWithMaVe(int ?id)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.VEs.Find(id);
            }
        }
        public IList<sp_GetDiemDi_Result> GetDiemDi(int maTramLen, int maTramXuong)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {

                return context.sp_GetDiemDi(maTramLen, maTramXuong).ToList();
            }
        }
        //public IList<sp_Get_DiemDen_Result> GetDiemDen(string maDiemDi)
        //{
        //    using (QLXeKhachEntities context = new QLXeKhachEntities())
        //    {
               
        //        return context.sp_Get_DiemDen(maDiemDi).ToList();
        //    }
        //}
        public IList<sp_Get_DiemDen_v2_Result> GetDiemDen(string maDiemDi, int maTramLen, int maTramXuong)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {

                return context.sp_Get_DiemDen_v2(maDiemDi, maTramLen, maTramXuong).ToList();
            }
        }
        //public IList<sp_GetTramLen_Result> GetTramLen(string maDiemDi, string maDiemDen)
        //{
        //    using (QLXeKhachEntities context = new QLXeKhachEntities())
        //    {
        //        return context.sp_GetTramLen(maDiemDi, maDiemDen).ToList();
        //    }
        //}
        public IList<sp_GetTramLen_v2_Result> GetTramLen()
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.sp_GetTramLen_v2().ToList();
            }
        }
        //public IList<sp_GetTramXuong_Result> GetTramXuong(string maDiemDi, string maDiemDen, int thuTuTramLen)
        //{
        //    using (QLXeKhachEntities context = new QLXeKhachEntities())
        //    {
        //        return context.sp_GetTramXuong(maDiemDi, maDiemDen, thuTuTramLen).ToList();
        //    }
        //}
        public IList<sp_GetTramXuong_v2_Result> GetTramXuong(int maTramLen)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.sp_GetTramXuong_v2(maTramLen).ToList();
            }
        }
        public IList<sp_GetGioKH_Result> GetGioKH(string maDiemDi, string maDiemDen)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.sp_GetGioKH(maDiemDi, maDiemDen).ToList();
            }
        }
        public string GetGioLenXe(string maDiemDi, string maDiemDen, int maChuyen, int maTramLen)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.sp_GetGioLenXe(maDiemDi, maDiemDen, maChuyen, maTramLen).FirstOrDefault();
            }
        }
        public decimal? GetGiaVe(int maTramLen, int maTramXuong, int maChuyen)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.sp_GetGiaVe(maTramLen, maTramXuong, maChuyen).FirstOrDefault();
            }
        }
        public IList<sp_getGheTrong_Result> GetGheTrong(int maChuyen)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.sp_getGheTrong(maChuyen).ToList();
            }
        }
        public sp_Get_Ve_Detail_Result GetVeEdit(int mave)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.sp_Get_Ve_Detail(mave).FirstOrDefault();
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