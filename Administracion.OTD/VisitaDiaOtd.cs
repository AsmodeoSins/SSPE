using Administracion.OTD.AtributosPersonalizados;
using System.Collections.Generic;

namespace Administracion.OTD
{
    public class VisitaDiaOtd
    {
        /// <summary>
        /// Propiedad para la columna 'ID_DIA' de la tabla 'VISITA_DIA'
        /// </summary>
        [NombreDeColumna("ID_DIA")]
        public int IdDia { get; set; }

        /// <summary>
        /// Propiedad para la columna 'DESCR' de la tabla 'VISITA_DIA'
        /// </summary>
        [NombreDeColumna("DESCR")]
        public string Descripcion { get; set; }
    }
}
