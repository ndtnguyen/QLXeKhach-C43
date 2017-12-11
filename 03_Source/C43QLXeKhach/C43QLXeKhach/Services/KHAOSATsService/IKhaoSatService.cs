using C43QLXeKhach.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace C43QLXeKhach.Services.KHAOSATsService
{
    public interface IKhaoSatService
    {
        IEnumerable GetAll();
        int Add(KHAOSAT ks);
        void Update(KHAOSAT ks);
        void Delete(KHAOSAT ks);
        KHAOSAT Detail(int? id);
        void Dispose();
    }
}