using System.Collections.Generic;
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
        IList<LOTRINH> Search(string input);
        IList<LOTRINH> Detail(int? id, int? id1);
    }
}