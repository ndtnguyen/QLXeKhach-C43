using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace C43QLXeKhach.Models
{
    public class GiaCoBanEntity
    {
        public string MaTT1 { get; set; }
        public string MaTT2 { get; set; }
        public string MaLoai { get; set; }
        public Nullable<decimal> GiaCoBan1 { get; set; }
        public Nullable<int> createUser { get; set; }
        public Nullable<int> lastupdateUser { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> lastupdateDate { get; set; }
        public Nullable<int> isDeleted { get; set; }
    }
}