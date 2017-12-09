using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using C43QLXeKhach.Models;

namespace C43QLXeKhach.Services.LOAIXEsService
{
    public class LoaiXeService : ILoaiXeService
    {
        public IList<LOAIXE> GetAll()
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.LOAIXEs.Where(x => x.isDeleted == 0).ToList();
            }
        }

        public int Add(LOAIXE nv)
        {
            return 1;

        }
        public void Update(LOAIXE lx)
        {

        }
        public void Delete(LOAIXE lx)
        {

        }
        public NHANVIEN Detail(int? id)
        {
            NHANVIEN a = new NHANVIEN();
            return a;
        }
    }
}