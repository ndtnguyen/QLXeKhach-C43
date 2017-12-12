using System.Collections.Generic;
using C43QLXeKhach.Models;
namespace C43QLXeKhach.Services.TRAMXEsService
{
    public interface ITramXeService
    {
        IList<TRAMXE> GetAll();
        int Add(TRAMXE tram);
        void Update(TRAMXE tram);
        void Delete(TRAMXE tram);
        //TRAMXE Detail(int? id);
        void Dispose();
        IList<TRAMXE> Search(string input);
        IList<TRAMXE> Detail(int? id);

    }
}