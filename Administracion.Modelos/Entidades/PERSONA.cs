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
    
    public partial class PERSONA
    {
        public PERSONA()
        {
            this.USUARIOs = new HashSet<USUARIO>();
            this.PERSONA_BIOMETRICO = new HashSet<PERSONA_BIOMETRICO>();
        }
    
        public int ID_PERSONA { get; set; }
        public Nullable<short> ID_TIPO_PERSONA { get; set; }
        public string PATERNO { get; set; }
        public string MATERNO { get; set; }
        public string NOMBRE { get; set; }
        public string SEXO { get; set; }
        public string DOMICILIO_CALLE { get; set; }
        public Nullable<int> DOMICILIO_NUM_EXT { get; set; }
        public string DOMICILIO_NUM_INT { get; set; }
        public Nullable<int> ID_COLONIA { get; set; }
        public Nullable<short> ID_MUNICIPIO { get; set; }
        public Nullable<short> ID_ENTIDAD { get; set; }
        public Nullable<short> ID_PAIS { get; set; }
        public Nullable<int> DOMICILIO_CODIGO_POSTAL { get; set; }
        public string CURP { get; set; }
        public string RFC { get; set; }
        public Nullable<System.DateTime> FEC_NACIMIENTO { get; set; }
        public string LUGAR_NACIMIENTO { get; set; }
        public Nullable<short> NACIONALIDAD { get; set; }
        public Nullable<short> ESTADO_CIVIL { get; set; }
        public string TELEFONO { get; set; }
        public string TELEFONO_MOVIL { get; set; }
        public string CORREO_ELECTRONICO { get; set; }
        public Nullable<short> ID_ETNIA { get; set; }
        public string IFE { get; set; }
        public Nullable<short> ID_TIPO_DISCAPACIDAD { get; set; }
        public Nullable<int> NORIGINAL { get; set; }
        public string CORIGINAL { get; set; }
        public string SPATERNO { get; set; }
        public string SMATERNO { get; set; }
        public string SNOMBRE { get; set; }
        public string NOTA_TECNICA { get; set; }
    
        public virtual EMPLEADO EMPLEADO { get; set; }
        public virtual TIPO_PERSONA TIPO_PERSONA { get; set; }
        public virtual ICollection<USUARIO> USUARIOs { get; set; }
        public virtual ICollection<PERSONA_BIOMETRICO> PERSONA_BIOMETRICO { get; set; }
    }
}
