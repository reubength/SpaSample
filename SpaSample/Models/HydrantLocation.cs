//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SpaSample.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HydrantLocation
    {
        public int hydrant_Id { get; set; }
        public int hydrant_District { get; set; }
        public double hydrant_Longitude { get; set; }
        public double hydrant_Latitude { get; set; }
        public Nullable<int> hydrant_City { get; set; }
    
        public virtual City City { get; set; }
        public virtual District District { get; set; }
    }
}
