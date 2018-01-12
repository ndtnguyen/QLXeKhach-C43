using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using C43QLXeKhach.Models;

namespace C43QLXeKhach.Utils
{
    public class ChuyenXeInfo
    {
        public static string GetBienSo(int ?maxe)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                XE x = context.XEs.Find(maxe);
                if (x != null)
                {
                    return x.BienSoXe;
                }
                return "";
            }
        }
        public static string GetTaiXe(int ?mataixe)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                TAIXE tx = context.TAIXEs.Find(mataixe);
                if (tx != null)
                {
                    return tx.TenTX;
                }
                return "";
            }
        }
        public static string GetTuyen(int? matuyen)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                TUYENXE tx = context.TUYENXEs.Find(matuyen);
                if (tx != null)
                {
                    TINHTHANH tt1 = context.TINHTHANHs.Find(tx.DiemDi);
                    TINHTHANH tt2 = context.TINHTHANHs.Find(tx.DiemDen);
                    if(tt1!=null && tt2 != null)
                    {
                        return tt1.TenTT + " - " + tt2.TenTT;
                    }
                }
                return "";
            }
        }
        public static IList<XE> GetBienSo()
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                var xe = context.XEs.Where(x => x.isDeleted != 1).ToList();
                return xe;
            }
        }
        public static IList<TAIXE> GetTaiXe()
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.TAIXEs.Where(x => x.isDeleted != 1).ToList();
            }
        }
        public static IList<TuyenInfo> GetTuyen()
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                IList<TuyenInfo> result = new List<TuyenInfo>();
                var kq = (from tx in context.TUYENXEs
                            join tt1 in context.TINHTHANHs
                            on tx.DiemDi equals tt1.MaTT
                            join tt2 in context.TINHTHANHs
                            on tx.DiemDen equals tt2.MaTT
                            select new { MaTuyen = tx.MaTuyen, DiemDi = tt1.TenTT, DiemDen = tt2.TenTT }
                            ).ToList();
                foreach(var item in kq)
                {
                    var temp = new TuyenInfo();
                    temp.MaTuyen = item.MaTuyen;
                    temp.DiemDi = item.DiemDi;
                    temp.DiemDen = item.DiemDen;
                    result.Add(temp);
                }
                return result;
            }
        }
        public class TuyenInfo { 
            public int MaTuyen { get; set; }
            public string DiemDi { get; set;}
            public string DiemDen { get; set; }
        }
    }
}