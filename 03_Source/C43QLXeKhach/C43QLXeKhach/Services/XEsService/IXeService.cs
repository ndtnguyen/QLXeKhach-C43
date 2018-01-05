using System.Collections.Generic;
using C43QLXeKhach.Models;
namespace C43QLXeKhach.Services.XEsService
{
    public interface IXeService
    {
        IList<XE> GetAll();
        int Add(XE xe);
        void Update(XE xe);
        void Delete(XE xe);
         //XE Detail(int? id);
        void Dispose();
        IList<XE> Search(string input);
      IList<XE> Detail(int? id);

    }
}