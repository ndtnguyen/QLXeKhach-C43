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
    
    public partial class LOAIXE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAIXE()
        {
            this.XEs = new HashSet<XE>();
        }
    
        public int MaLoai { get; set; }
        public string TenLoai { get; set; }
        public Nullable<int> SLGhe { get; set; }
        public Nullable<int> createUser { get; set; }
        public Nullable<int> lastupdateUser { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> lastupdateDate { get; set; }
        public Nullable<int> isDeleted { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XE> XEs { get; set; }
    }
}
