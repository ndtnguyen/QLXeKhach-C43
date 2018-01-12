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
    }
}