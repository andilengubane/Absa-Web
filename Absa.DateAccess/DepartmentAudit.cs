//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Absa.DateAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class DepartmentAudit
    {
        public int DepartmentAuditID { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> DateLogged { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdateOn { get; set; }
    
        public virtual Department Department { get; set; }
    }
}
