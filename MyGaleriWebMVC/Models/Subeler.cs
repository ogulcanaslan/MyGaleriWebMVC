//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyGaleriWebMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Subeler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Subeler()
        {
            this.Araclars = new HashSet<Araclar>();
        }
    
        public int SubeNo { get; set; }
        public string SubeAdi { get; set; }
        public Nullable<int> SubeCalisanSayisi { get; set; }
        public Nullable<decimal> SubeCiro { get; set; }
        public Nullable<int> MusteriNo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Araclar> Araclars { get; set; }
        public virtual Musteriler Musteriler { get; set; }
    }
}