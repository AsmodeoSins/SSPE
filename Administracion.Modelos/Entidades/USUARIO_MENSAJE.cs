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
    
    public partial class USUARIO_MENSAJE
    {
        public string ID_USUARIO { get; set; }
        public int ID_MENSAJE { get; set; }
        public Nullable<System.DateTime> LECTURA_FEC { get; set; }
        public Nullable<short> ESTATUS { get; set; }
    
        public virtual USUARIO USUARIO { get; set; }
    }
}
