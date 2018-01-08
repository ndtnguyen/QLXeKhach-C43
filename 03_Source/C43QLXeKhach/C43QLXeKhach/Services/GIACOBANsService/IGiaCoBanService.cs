using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using C43QLXeKhach.Models;

namespace C43QLXeKhach.Services.GIACOBANsService
{
    public interface IGiaCoBanService
    {
        IList<GIACOBAN> GetAll();
        int Add(GIACOBAN dtac);
        void Update(GIACOBAN dtac);
        void Delete(GIACOBAN dtac);
        GIACOBAN Detail(string maTT1,string maTT2, int maLoai);
        void Dispose();
    }
}