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
    
    public partial class IMPUTADO
    {
        public IMPUTADO()
        {
            this.IMPUTADO_BIOMETRICO = new HashSet<IMPUTADO_BIOMETRICO>();
            this.PL_INCIDENCIA_BITACORA = new HashSet<PL_INCIDENCIA_BITACORA>();
            this.INGRESOes = new HashSet<INGRESO>();
        }
    
        public short ID_CENTRO { get; set; }
        public short ID_ANIO { get; set; }
        public int ID_IMPUTADO { get; set; }
        public string PATERNO { get; set; }
        public string MATERNO { get; set; }
        public string NOMBRE { get; set; }
        public string SEXO { get; set; }
        public Nullable<short> ID_ETNIA { get; set; }
        public Nullable<short> ID_NACIONALIDAD { get; set; }
        public Nullable<short> NACIMIENTO_PAIS { get; set; }
        public Nullable<short> NACIMIENTO_ESTADO { get; set; }
        public Nullable<short> NACIMIENTO_MUNICIPIO { get; set; }
        public Nullable<System.DateTime> NACIMIENTO_FECHA { get; set; }
        public string NACIMIENTO_LUGAR { get; set; }
        public string PATERNO_MADRE { get; set; }
        public string MATERNO_MADRE { get; set; }
        public string NOMBRE_MADRE { get; set; }
        public string PATERNO_PADRE { get; set; }
        public string MATERNO_PADRE { get; set; }
        public string NOMBRE_PADRE { get; set; }
        public string TABAJADOR_CERESO { get; set; }
        public string RFC { get; set; }
        public string CURP { get; set; }
        public string IFE { get; set; }
        public string NIP { get; set; }
        public Nullable<System.DateTime> BI_FECALTA { get; set; }
        public string BI_USER { get; set; }
        public string TELORIGINAL { get; set; }
        public string SPATERNO { get; set; }
        public string SMATERNO { get; set; }
        public string SNOMBRE { get; set; }
        public Nullable<short> ID_IDIOMA { get; set; }
        public Nullable<short> ID_DIALECTO { get; set; }
        public string TRADUCTOR { get; set; }
    
        public virtual CENTRO CENTRO { get; set; }
        public virtual ICollection<IMPUTADO_BIOMETRICO> IMPUTADO_BIOMETRICO { get; set; }
        public virtual ICollection<PL_INCIDENCIA_BITACORA> PL_INCIDENCIA_BITACORA { get; set; }
        public virtual ICollection<INGRESO> INGRESOes { get; set; }
    }
}
