﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using C43QLXeKhach.Models;
namespace C43QLXeKhach.Services.LOAIXEsService
{
    public interface ILoaiXeService
    {
        IList<LOAIXE> GetAll();
        int Add(LOAIXE nv);
        void Update(LOAIXE lx);
        void Delete(LOAIXE lx);
        NHANVIEN Detail(int? id);
    }
}