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
    
    public partial class DOITAC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DOITAC()
        {
            this.HOPDONGs = new HashSet<HOPDONG>();
        }
    
        public int MaDT { get; set; }
        public string TenDT { get; set; }
        public string NguoiDaiDien { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public Nullable<int> createUser { get; set; }
        public Nullable<int> lastupdateUser { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> lastupdateDate { get; set; }
        public Nullable<int> isDeleted { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOPDONG> HOPDONGs { get; set; }
    }
}
