//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace C43QLXeKhach.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TUYENXE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TUYENXE()
        {
            this.LOTRINHs = new HashSet<LOTRINH>();
        }
    
        public int MaTuyen { get; set; }
        public string DiemDi { get; set; }
        public string DiemDen { get; set; }
        public Nullable<int> QuangDuong { get; set; }
        public Nullable<double> ThoiGian { get; set; }
        public Nullable<int> SoChuyen1Ngay { get; set; }
        public Nullable<int> createUser { get; set; }
        public Nullable<int> lastupdateUser { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> lastupdateDate { get; set; }
        public Nullable<int> isDeleted { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOTRINH> LOTRINHs { get; set; }
        public virtual TINHTHANH TINHTHANH { get; set; }
        public virtual TINHTHANH TINHTHANH1 { get; set; }
    }
}
