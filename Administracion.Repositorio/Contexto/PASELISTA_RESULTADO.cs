//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Administracion.Repositorio.Contexto
{
    using System;
    using System.Collections.Generic;
    
    public partial class PASELISTA_RESULTADO
    {
        public int ID { get; set; }
        public int ID_PASELISTA_ASIGN { get; set; }
        public string ID_CELDA { get; set; }
        public Nullable<System.DateTime> HORA_INICIAL { get; set; }
        public Nullable<System.DateTime> HORA_FINAL { get; set; }
        public Nullable<short> ASISTENCIAS { get; set; }
        public Nullable<short> INASISTENCIAS { get; set; }
    
        public virtual CELDA CELDA { get; set; }
        public virtual PASELISTA_ASIGNADO PASELISTA_ASIGNADO { get; set; }
    }
}
