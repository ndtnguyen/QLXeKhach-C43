﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using C43QLXeKhach.Models;

namespace C43QLXeKhach.Utils
{
    public class VeInfo
    {
        public static IList<TRAMXE> GetTramLen()
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.TRAMXEs.Where(x=>x.isDeleted!=1).ToList();
            }
        }
    }
}