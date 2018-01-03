using C43QLXeKhach.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace C43QLXeKhach.Services.CHUYENXEsService
{
    public interface IChuyenXeService
    {
        IList<CHUYENXE> GetAll();
        int Add(CHUYENXE cx);
        void Update(CHUYENXE cx);
        void Delete(CHUYENXE cx);
        CHUYENXE Detail(int? id);
        void Dispose();
    }
}