using Administracion.OTD.AtributosPersonalizados;
using System.Collections.Generic;

namespace Administracion.OTD
{
    public class TipoDeCeldaOtd
    {
        /// <summary>
        /// Propiedad para la columna 'ID_TIPO_CELDA' de la tabla 'TIPO_CELDA'
        /// </summary>
        [NombreDeColumna("ID_TIPO_CELDA")]
        public string IdTipoCelda { get; set; }

        /// <summary>
        /// Propiedad para la columna 'DESCR' de la tabla 'TIPO_CELDA'
        /// </summary>
        [NombreDeColumna("DESCR")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Propiedad para la columna 'CELDAs' de la tabla 'TIPO_CELDA'
        /// </summary>
        [NombreDeColumna("CELDAs")]
        public virtual ICollection<CeldaOtd> Celdas { get; set; }
    }
}
