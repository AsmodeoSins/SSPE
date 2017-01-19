using Administracion.OTD.AtributosPersonalizados;
using System;

namespace Administracion.OTD
{
    /// <summary>
    /// Modelo para la tabla 'PARAMETRO'
    /// </summary>
    public class ParametroOtd
    {
        /// <summary>
        /// Propiedad para la columna 'ID_CLAVE' de la tabla 'PARAMETRO'
        /// </summary>
        [NombreDeColumna("ID_CLAVE")]
        public string IdClave { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_CENTRO' de la tabla 'PARAMETRO'
        /// </summary>
        [NombreDeColumna("ID_CENTRO")]
        public short IdCentro { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_CLAVE' de la tabla 'PARAMETRO'
        /// </summary>
        [NombreDeColumna("Valor")]
        public string Valor { get; set; }

        /// <summary>
        /// Propiedad para la columna 'VALOR_NUM' de la tabla 'PARAMETRO'
        /// </summary>
        [NombreDeColumna("VALOR_NUM")]
        public int? ValorNum { get; set; }

        /// <summary>
        /// Propiedad para la columna 'CONTENIDO' de la tabla 'PARAMETRO'
        /// </summary>
        [NombreDeColumna("CONTENIDO")]
        public byte[] Contenido { get; set; }

        /// <summary>
        /// Propiedad para la columna 'PARAMETRO_CLAVE' de la tabla 'PARAMETRO'
        /// </summary>
        [NombreDeColumna("PARAMETRO_CLAVE")]
        public ParametroClaveOtd ParametroClave { get; set; }
    }
}
