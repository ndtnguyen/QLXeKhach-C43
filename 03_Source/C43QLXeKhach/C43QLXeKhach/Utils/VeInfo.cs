using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using C43QLXeKhach.Models;

namespace C43QLXeKhach.Utils
{
    public class VeInfo
    {
        public static IList<TINHTHANH> GetDiemDi()
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.TINHTHANHs.ToList();
            }
        }
        public static IList<TINHTHANH> GetDiemDen(string maDiemDi)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                //IList< = context.TUYENXEs.Where(x => x.DiemDi == maDiemDi).ToList();
                var listTT = (from tx in context.TUYENXEs
                              join tt in context.TINHTHANHs
                              on tx.DiemDen equals tt.MaTT
                              where tx.DiemDi == maDiemDi
                              select tt).ToList();
                return listTT;
            }
        }
    }
}