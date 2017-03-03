using Administracion.OTD.AtributosPersonalizados;
using System.Collections.Generic;

namespace Administracion.OTD
{
    public class TipoVisitaOtd
    {
        /// <summary>
        /// Propiedad para la columna 'ID_TIPO_PERSONA' de la tabla 'TIPO_VISITA'
        /// </summary>
        [NombreDeColumna("ID_TIPO_VISITA")]
        public int IdTipoVisita { get; set; }

        /// <summary>
        /// Propiedad para la columna 'DESCR' de la tabla 'TIPO_VISITA'
        /// </summary>
        [NombreDeColumna("DESCR")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ESTATUS' de la tabla 'TIPO_VISITA'
        /// </summary>
        [NombreDeColumna("ESTATUS")]
        public virtual string Estatus { get; set; }
    }
}
