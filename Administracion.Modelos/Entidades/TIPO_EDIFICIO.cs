//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Administracion.Modelos.Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class TIPO_EDIFICIO
    {
        public TIPO_EDIFICIO()
        {
            this.EDIFICIOs = new HashSet<EDIFICIO>();
        }
    
        public short ID_TIPO_EDIFICIO { get; set; }
        public string DESCR { get; set; }
    
        public virtual ICollection<EDIFICIO> EDIFICIOs { get; set; }
    }
}
