//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolPerfectProject.App_Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Student
    {

        public int SID { get; set; }
        [Required]
        public string SName { get; set; }
        [Required]
        [RegularExpression(@"([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})")]
        public string SEmail { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
        public Nullable<int> FID { get; set; }
        public Nullable<int> DID { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual Faculty Faculty { get; set; }
    }
}
