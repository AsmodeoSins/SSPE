using Administracion.OTD.AtributosPersonalizados;
using System.Collections.Generic;

namespace Administracion.OTD
{
    public class HorarioVisitaOtd
    {
        /// <summary>
        /// Propiedad para la columna 'ID' de la tabla 'HORARIO_VISITA'
        /// </summary>
        [NombreDeColumna("ID")]
        public int Id { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_TIPO_VISITA' de la tabla 'HORARIO_VISITA'
        /// </summary>
        [NombreDeColumna("ID_TIPO_VISITA")]
        public short? IdTipoVisita { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_DIA' de la tabla 'HORARIO_VISITA'
        /// </summary>
        [NombreDeColumna("ID_DIA")]
        public short? IdDia { get; set; }

        /// <summary>
        /// Propiedad para la columna 'HORA_INICIO' de la tabla 'HORARIO_VISITA'
        /// </summary>
        [NombreDeColumna("HORA_INICIO")]
        public string HoraInicio { get; set; }

        /// <summary>
        /// Propiedad para la columna 'HORA_FIN' de la tabla 'HORARIO_VISITA'
        /// </summary>
        [NombreDeColumna("HORA_FIN")]
        public string HoraFin { get; set; }
    }
}
