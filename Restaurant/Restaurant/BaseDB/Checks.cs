//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Restaurant.BaseDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Checks
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Checks()
        {
            this.Check_All = new HashSet<Check_All>();
        }
    
        public int Id { get; set; }
        public System.DateTime Date_of_check { get; set; }
        public string Time { get; set; }
        public decimal Prase { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Check_All> Check_All { get; set; }
    }
}