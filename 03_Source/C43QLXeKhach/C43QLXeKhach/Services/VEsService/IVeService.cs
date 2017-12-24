using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using C43QLXeKhach.Models;

namespace C43QLXeKhach.Services.VEsService
{
    public interface IVeService
    {
        IList<vw_ve> GetAll();
        int Add(VE v);
        void Update(VE nv);
        void Delete(VE nv);
        vw_ve Detail(int? id);
        VE LoadVeWWithMaVe(int? id);
        void Dispose();
    }
}