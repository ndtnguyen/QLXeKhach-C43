using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using C43QLXeKhach.Models;

namespace C43QLXeKhach.Services.DOITACsService
{
    public interface IDoiTacService
    {
        IList<DOITAC> GetAll();
        int Add(DOITAC dtac);
        void Update(DOITAC dtac);
        void Delete(DOITAC dtac);
        DOITAC Detail(int? id);
        void Dispose();
        IList<DOITAC> Search(string input);
    }
}