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
    
    public partial class PARAMETRO_CLAVE
    {
        public PARAMETRO_CLAVE()
        {
            this.PARAMETROes = new HashSet<PARAMETRO>();
        }
    
        public string ID_CLAVE { get; set; }
        public string DESCR { get; set; }
        public string SISTEMA { get; set; }
    
        public virtual ICollection<PARAMETRO> PARAMETROes { get; set; }
    }
}
