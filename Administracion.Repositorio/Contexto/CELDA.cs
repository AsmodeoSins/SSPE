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
    
    public partial class CELDA
    {
        public CELDA()
        {
            this.PASELISTA_RESULTADO = new HashSet<PASELISTA_RESULTADO>();
        }
    
        public string ID_CELDA { get; set; }
        public short ID_CENTRO { get; set; }
        public short ID_EDIFICIO { get; set; }
        public short ID_SECTOR { get; set; }
        public string ID_TIPO_SEGURIDA { get; set; }
        public string ID_TIPO_CELDA { get; set; }
        public Nullable<short> NIVEL_EDIFICIO { get; set; }
    
        public virtual CENTRO CENTRO { get; set; }
        public virtual EDIFICIO EDIFICIO { get; set; }
        public virtual SECTOR SECTOR { get; set; }
        public virtual ICollection<PASELISTA_RESULTADO> PASELISTA_RESULTADO { get; set; }
    }
}
