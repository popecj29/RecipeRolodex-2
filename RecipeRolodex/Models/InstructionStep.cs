//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RecipeRolodex.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class InstructionStep
    {
        public long ID { get; set; }
        public long RecipeID { get; set; }
        public string Description { get; set; }
        public int StepNumber { get; set; }
    
        public virtual Recipe Recipe { get; set; }
    }
}
