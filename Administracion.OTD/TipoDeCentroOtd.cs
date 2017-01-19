using Administracion.OTD.AtributosPersonalizados;
using System.Collections.Generic;

namespace Administracion.OTD
{
    public class TipoDeCentroOtd
    {
        /// <summary>
        /// Propiedad para la columna 'ID_TIPO_CENTRO' de la tabla 'TIPO_CENTRO'
        /// </summary>
        [NombreDeColumna("ID_TIPO_CENTRO")]
        public short idTipoCentro { get; set; }

        /// <summary>
        /// Propiedad para la columna 'DESCR' de la tabla 'TIPO_CENTRO'
        /// </summary>
        [NombreDeColumna("DESCR")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Propiedad para la columna 'CENTROes' de la tabla 'TIPO_CENTRO'
        /// </summary>
        [NombreDeColumna("CENTROes")]
        public virtual ICollection<CentroOtd> Centros { get; set; }
    }
}
