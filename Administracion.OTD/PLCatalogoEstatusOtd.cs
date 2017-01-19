using Administracion.OTD.AtributosPersonalizados;
using System.Collections.Generic;

namespace Administracion.OTD
{
    public class PLCatalogoEstatusOtd
    {
        /// <summary>
        /// Propiedad para la columna 'ID_ESTATUS' de la tabla 'PL_CATALOGO_ESTATUS'
        /// </summary>
        [NombreDeColumna("ID_ESTATUS")]
        public string IdEstatus { get; set; }

        /// <summary>
        /// Propiedad para la columna 'DESCR' de la tabla 'PL_CATALOGO_ESTATUS'
        /// </summary>
        [NombreDeColumna("DESCR")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Propiedad para la columna 'PL_CATALOGO' de la tabla 'PL_CATALOGO_ESTATUS'
        /// </summary>
        [NombreDeColumna("PL_CATALOGO")]
        public virtual ICollection<PLCatalogoOtd> PLCatalogos { get; set; }
    }
}
