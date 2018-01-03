using C43QLXeKhach.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace C43QLXeKhach.Services.TAIXEsService
{
    public interface ITaiXeService
    {
        IList<TAIXE> GetAll();
        int Add(TAIXE cx);
        void Update(TAIXE cx);
        void Delete(TAIXE cx);
        TAIXE Detail(int? id);
        void Dispose();
    }
}