using Administracion.OTD.AtributosPersonalizados;
using System.Collections.Generic;

namespace Administracion.OTD
{
    public class ParametroClaveOtd
    {
        /// <summary>
        /// Propiedad para la columna 'ID_CLAVE' de la tabla 'PARAMETRO_CLAVE'
        /// </summary>
        [NombreDeColumna("ID_CLAVE")]
        public string IdClave { get; set; }

        /// <summary>
        /// Propiedad para la columna 'DESCR' de la tabla 'PARAMETRO_CLAVE'
        /// </summary>
        [NombreDeColumna("DESCR")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Propiedad para la columna 'SISTEMA' de la tabla 'PARAMETRO_CLAVE'
        /// </summary>
        [NombreDeColumna("SISTEMA")]
        public string Sistema { get; set; }

        /// <summary>
        /// Propiedad para la columna 'PARAMETROes' de la tabla 'PARAMETRO_CLAVE'
        /// </summary>
        [NombreDeColumna("PARAMETROes")]
        public virtual ICollection<ParametroOtd> Parametros { get; set; }
    }
}
