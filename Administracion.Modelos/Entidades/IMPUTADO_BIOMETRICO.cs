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
    
    public partial class IMPUTADO_BIOMETRICO
    {
        public short ID_CENTRO { get; set; }
        public short ID_ANIO { get; set; }
        public int ID_IMPUTADO { get; set; }
        public short ID_TIPO_BIOMETRICO { get; set; }
        public byte[] BIOMETRICO { get; set; }
        public Nullable<short> CALIDAD { get; set; }
        public short ID_FORMATO { get; set; }
        public string TOMA { get; set; }
    
        public virtual BIOMETRICO_TIPO BIOMETRICO_TIPO { get; set; }
        public virtual IMPUTADO IMPUTADO { get; set; }
    }
}
