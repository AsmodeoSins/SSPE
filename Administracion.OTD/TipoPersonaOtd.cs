using Administracion.OTD.AtributosPersonalizados;
using System.Collections.Generic;

namespace Administracion.OTD
{
    public class TipoPersonaOtd
    {
        /// <summary>
        /// Propiedad para la columna 'ID_TIPO_PERSONA' de la tabla 'TIPO_PERSONA'
        /// </summary>
        [NombreDeColumna("ID_TIPO_PERSONA")]
        public short IdTipoPersona { get; set; }

        /// <summary>
        /// Propiedad para la columna 'DESCR' de la tabla 'TIPO_PERSONA'
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Propiedad para la columna 'PERSONAs' de la tabla 'TIPO_PERSONA'
        /// </summary>
        public virtual ICollection<PersonaOtd> PERSONAs { get; set; }
    }
}
