using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using C43QLXeKhach.Models;
namespace C43QLXeKhach.Services.KHACHHANGsService
{
    public interface IKhachHangService
    {
        IList<KHACHHANG> GetAll();
        int Add(KHACHHANG kh);
        void Update(KHACHHANG kh);
        void Delete(KHACHHANG kh);
        KHACHHANG Detail(int ?id);
        void Dispose();
        IList<KHACHHANG> Search(string input);
        KHACHHANG GetKH_SDT(string sdt);
        KHACHHANG GetKH_MaVe(int? mave);
    }
}