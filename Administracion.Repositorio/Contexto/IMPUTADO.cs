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
    
    public partial class IMPUTADO
    {
        public short ID_CENTRO { get; set; }
        public int ID_IMPUTADO { get; set; }
        public string PATERNO { get; set; }
        public string MATERNO { get; set; }
        public string NOMBRE { get; set; }
        public string SEXO { get; set; }
    
        public virtual CENTRO CENTRO { get; set; }
    }
}
