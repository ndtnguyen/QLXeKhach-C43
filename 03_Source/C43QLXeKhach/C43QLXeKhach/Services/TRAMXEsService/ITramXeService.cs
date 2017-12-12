using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using C43QLXeKhach.Models;
namespace C43QLXeKhach.Services.TRAMXEsService
{
    public interface ITramXeService
    {
        IList<TRAMXE> GetAll();
        int Add(TRAMXE tt);
        void Update(TRAMXE tt);
        void Delete(TRAMXE tt);
        TRAMXE Detail(string id);
        void Dispose();
        IList<TRAMXE> Search(string input);

    }
}