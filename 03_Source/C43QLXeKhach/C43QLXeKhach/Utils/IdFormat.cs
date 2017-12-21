using C43QLXeKhach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace C43QLXeKhach.Utils
{
    public class IdFormat
    {
        public static string TinhThanhFormat(string MaTT)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                TINHTHANH tt = context.TINHTHANHs.Find(MaTT);
                if (tt != null)
                {
                    return tt.TenTT;
                } else
                {
                    return "N/A";
                }
                
            }
        }
    }
}