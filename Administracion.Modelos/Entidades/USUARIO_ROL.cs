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
    
    public partial class USUARIO_ROL
    {
        public string ID_USUARIO { get; set; }
        public short ID_ROL { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
        public short ID_CENTRO { get; set; }
    
        public virtual USUARIO USUARIO { get; set; }
        public virtual CENTRO CENTRO { get; set; }
    }
}
