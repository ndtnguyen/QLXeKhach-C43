using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using C43QLXeKhach.Models;

namespace C43QLXeKhach.Services.HOPDONGsService
{
    public interface IHopDongService
    {
        IList<HOPDONG> GetAll();
        int Add(HOPDONG hd);
        void Update(HOPDONG hd);
        void Delete(HOPDONG hd);
        IList<HOPDONG> Detail(int? id);
        void Dispose();
    }
}