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
    
    public partial class CENTRO
    {
        public CENTRO()
        {
            this.CELDA = new HashSet<CELDA>();
            this.EDIFICIO = new HashSet<EDIFICIO>();
            this.PASELISTA_PROGRAMADO = new HashSet<PASELISTA_PROGRAMADO>();
            this.IMPUTADO = new HashSet<IMPUTADO>();
            this.PARAMETRO = new HashSet<PARAMETRO>();
            this.SECTOR = new HashSet<SECTOR>();
        }
    
        public short ID_CENTRO { get; set; }
        public Nullable<short> ID_TIPO_CENTRO { get; set; }
        public string ID_ENTIDAD { get; set; }
        public string ID_MUNICIPIO { get; set; }
        public string DESCR { get; set; }
    
        public virtual ICollection<CELDA> CELDA { get; set; }
        public virtual ICollection<EDIFICIO> EDIFICIO { get; set; }
        public virtual ICollection<PASELISTA_PROGRAMADO> PASELISTA_PROGRAMADO { get; set; }
        public virtual ICollection<IMPUTADO> IMPUTADO { get; set; }
        public virtual ICollection<PARAMETRO> PARAMETRO { get; set; }
        public virtual ICollection<SECTOR> SECTOR { get; set; }
    }
}