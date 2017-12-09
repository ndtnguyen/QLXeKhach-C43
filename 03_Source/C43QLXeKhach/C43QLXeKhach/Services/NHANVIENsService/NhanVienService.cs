using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using C43QLXeKhach.Models;
using System.Data.Entity;
using System.Text;
using C43QLXeKhach.Constant;
using C43QLXeKhach.Utils;

namespace C43QLXeKhach.Services.NHANVIENsService
{
    public class NhanVienService : INhanVienService
    {
        public IList<NHANVIEN> GetAll()
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.NHANVIENs.Where(x=>x.isDeleted!=1).ToList();
            }
        }
        public int Add(NHANVIEN nv)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                var user = HttpContext.Current.Session[GlobalConstant.USER];
                if (user != null)
                {
                    NHANVIEN currentUser = (NHANVIEN)user;
                    nv.createUser= currentUser.MaNV;
                    nv.lastupdateUser = currentUser.MaNV;
                }
                DateTime current = DateTime.Now;
                nv.createDate = current;
                nv.lastupdateDate = current;
                context.NHANVIENs.Add(nv);
                context.SaveChanges();
                return 1;
            }
        }
        public void Update(NHANVIEN nv)
        {
            var user = HttpContext.Current.Session[GlobalConstant.USER];
            if (user != null)
            {
                NHANVIEN currentUser = (NHANVIEN)user;
                nv.lastupdateUser = currentUser.MaNV;
            }
            DateTime current = DateTime.Now;
            nv.lastupdateDate = current;
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Entry(nv).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Delete(NHANVIEN nv)
        {
            var user = HttpContext.Current.Session[GlobalConstant.USER];
            if (user != null)
            {
                NHANVIEN currentUser = (NHANVIEN)user;
                nv.lastupdateUser = currentUser.MaNV;
            }
            DateTime current = DateTime.Now;
            nv.lastupdateDate = current;
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Entry(nv).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public NHANVIEN Detail(int? id)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                return context.NHANVIENs.Find(id);
            }
        }
        public void Dispose()
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                context.Dispose();
            }
        }

        public NHANVIEN Login(string email, string password)
        {
            using (QLXeKhachEntities context = new QLXeKhachEntities())
            {
                //kiểm tra tồn tại
                string sqlString = "SELECT * FROM NHANVIEN WHERE Email='" + email + "' AND Password='" + password + "'";
                List<NHANVIEN> result = context.NHANVIENs.SqlQuery(sqlString).ToList<NHANVIEN>();
                if (result.Count > 0) {
                    //tạo session
                    C_SESSION session = new C_SESSION();
                    session.C_Status = 1;
                    session.LoginTime = DateTime.Now;
                    session.MaNV = result[0].MaNV;
                    try
                    {
                        C_SESSION resultSession = context.C_SESSION.Add(session);
                        context.SaveChanges();
                        HttpContext.Current.Session[GlobalConstant.SESSION_ID] = resultSession;
                    } catch (Exception e)
                    {
                        
                        System.Diagnostics.Debug.WriteLine(e);
                    }
                    
                    HttpContext.Current.Session[GlobalConstant.USER] = result[0];
                    return result[0];
                } else
                {
                    return null;
                }
                
            }
        }
        //public IList<NHANVIEN> Search(string input)
        //{
        //    using (QLXeKhachEntities context = new QLXeKhachEntities())
        //    {
        //        return context.NHANVIENs.Where(x => x.isDeleted!=1 &&(x.TenNV.Contains(input) || input == "")).ToList();
        //    }
        //}
        public void LogOut()
        {
            var session = HttpContext.Current.Session[GlobalConstant.SESSION_ID];
            if (session != null)
            {
                C_SESSION mySession = (C_SESSION)session;
                mySession.LogoutTime = DateTime.Now;
                using (QLXeKhachEntities context = new QLXeKhachEntities())
                {
                    try
                    {
                        var entity = context.C_SESSION.Find(mySession.MaSession);
                        if (entity == null)
                        {
                            return;
                        }

                        context.Entry(entity).CurrentValues.SetValues(session);
                        context.SaveChanges();
                    } catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine(e);
                    }
                }
                HttpContext.Current.Session.Clear();
            } else
            {
                return;
            }
        }

        public void ResetPassword(string password, string confirmPassword)
        {
            if (password == confirmPassword)
            {
                var user = HttpContext.Current.Session[GlobalConstant.USER];
                if (user != null)
                {
                    NHANVIEN currentUser = (NHANVIEN)user;
                    currentUser.Password = EncryptionUtil.instant(password);
                    currentUser.TrangThaiTaiKhoan = 1;
                    //change password
                    using (QLXeKhachEntities context = new QLXeKhachEntities())
                    {
                        try
                        {
                            var entity = context.NHANVIENs.Find(currentUser.MaNV);
                            if (entity == null)
                            {
                                return;
                            }

                            context.Entry(entity).CurrentValues.SetValues(currentUser);
                            context.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            System.Diagnostics.Debug.WriteLine(e);
                        }
                    }
                }
            } else
            {
                throw new ArgumentException("Mật khẩu xác nhận không chính xác");
            }
            
        }
    }
}