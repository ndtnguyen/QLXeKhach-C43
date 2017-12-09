using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using C43QLXeKhach.Models;
namespace C43QLXeKhach.Services.NHANVIENsService
{
    public interface INhanVienService
    {
        IList<NHANVIEN> GetAll();
        int Add(NHANVIEN nv);
        void Update(NHANVIEN nv);
        void Delete(NHANVIEN nv);
        NHANVIEN Detail(int ?id);
        void Dispose();
        NHANVIEN Login(string email, string password);
        void LogOut();
        //IList<NHANVIEN> Search(string input);

        void ResetPassword(string password, string confirmPassword);
    }
}