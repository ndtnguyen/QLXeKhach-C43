using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using C43QLXeKhach.Models;

namespace C43QLXeKhach.Services.VEsService
{
    public interface IVeService
    {
        IList<vw_ve> GetAll();
        int Add(VE v);
        void Update(VE nv);
        void Delete(VE nv);
        vw_ve Detail(int? id);
        VE LoadVeWWithMaVe(int? id);
        void Dispose();
        IList<sp_Get_DiemDen_Result> GetDiemDen(string maDiemDi);
        IList<sp_GetTramLen_Result> GetTramLen(string maDiemDi,string maDiemDen);
        IList<sp_GetTramXuong_Result> GetTramXuong(string maDiemDi, string maDiemDen,int thuTuTramLen);
        IList<sp_GetGioKH_Result> GetGioKH(string maDiemDi, string maDiemDen);
        DateTime? GetGioLenXe(string maDiemDi, string maDiemDen,int maChuyen,int maTramLen);
        decimal? GetGiaVe(int maTramLen, int maTramXuong, int maChuyen);
        IList<sp_getGheTrong_Result> GetGheTrong(int maChuyen);
    }
}