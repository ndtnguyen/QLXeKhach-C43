using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using C43QLXeKhach.Models;

namespace C43QLXeKhach.Services.LOTRINHsService
{
    public interface ILoTrinhService
    {
        IList<LOTRINH> GetAll();
        int Add(LOTRINH ltrinh);
        void Update(LOTRINH ltrinh);
        void Delete(LOTRINH ltrinh);
        void Dispose();
        //IList<LOTRINH> Search(string input);
        IList<LOTRINH> Detail(int? id, int? id1);
        IList<LOTRINH> Detail(int? id);
    }
}