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
    
    public partial class TIPO_CENTRO
    {
        public TIPO_CENTRO()
        {
            this.CENTROes = new HashSet<CENTRO>();
        }
    
        public short ID_TIPO_CENTRO { get; set; }
        public string DESCR { get; set; }
    
        public virtual ICollection<CENTRO> CENTROes { get; set; }
    }
}
