using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using C43QLXeKhach.Models;

namespace C43QLXeKhach.Services.TUYENXEsService
{
    public interface ITuyenXeService
    {
        IList<TUYENXE> GetAll();
        int Add(TUYENXE tuyen);
        void Update(TUYENXE tuyen);
        void Delete(TUYENXE tuyen);
        void Dispose();
        //IList<TUYENXE> Search(string input);
        IList<TUYENXE> Detail(int? id);
    }
}