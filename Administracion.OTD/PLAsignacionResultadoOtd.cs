using Administracion.OTD.AtributosPersonalizados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Administracion.OTD
{
    public class PLAsignacionResultadoOtd
    {
        /// <summary>
        /// Propiedad para la columna 'ID_ASIGNACION_RESULTADO' de la tabla 'PL_ASIGNACION_RESULTADO'
        /// </summary>
        [NombreDeColumna("ID_ASIGNACION_RESULTADO")]
        public int IdAsignacionResulado { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_PL_ASIGNACION' de la tabla 'PL_ASIGNACION_RESULTADO'
        /// </summary>
        [NombreDeColumna("ID_PL_ASIGNACION")]
        public int IdPLAsignacion { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_CELDA' de la tabla 'PL_ASIGNACION_RESULTADO'
        /// </summary>
        [NombreDeColumna("ID_CELDA")]
        public string IdCelda { get; set; }

        /// <summary>
        /// Propiedad para la columna 'HORA_INICIAL' de la tabla 'PL_ASIGNACION_RESULTADO'
        /// </summary>
        [NombreDeColumna("HORA_INICIAL")]
        public DateTime HoraInicial { get; set; }

        /// <summary>
        /// Propiedad para la columna 'HORA_FINAL' de la tabla 'PL_ASIGNACION_RESULTADO'
        /// </summary>
        [NombreDeColumna("HORA_FINAL")]
        public DateTime HoraFinal { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ASISTENCIAS' de la tabla 'PL_ASIGNACION_RESULTADO'
        /// </summary>
        [NombreDeColumna("ASISTENCIAS")]
        public short? Asistencias { get; set; }

        /// <summary>
        /// Propiedad para la columna 'INASISTENCIAS' de la tabla 'PL_ASIGNACION_RESULTADO'
        /// </summary>
        [NombreDeColumna("INASISTENCIAS")]
        public short? Inasistencias { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_CENTRO' de la tabla 'PL_ASIGNACION_RESULTADO'
        /// </summary>
        [NombreDeColumna("ID_CENTRO")]
        public short IdCentro { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_EDIFICIO' de la tabla 'PL_ASIGNACION_RESULTADO'
        /// </summary>
        [NombreDeColumna("ID_EDIFICIO")]
        public short IdEdificio { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_SECTOR' de la tabla 'PL_ASIGNACION_RESULTADO'
        /// </summary>
        [NombreDeColumna("ID_SECTOR")]
        public short IdSector { get; set; }

        /// <summary>
        /// Propiedad para la columna 'CELDA' de la tabla 'PL_ASIGNACION_RESULTADO'
        /// </summary>
        [NombreDeColumna("CELDA")]
        public virtual CeldaOtd Celda { get; set; }

        /// <summary>
        /// Propiedad para la columna 'PL_PROGRAMADO_ASIGNACION' de la tabla 'PL_ASIGNACION_RESULTADO'
        /// </summary>
        [NombreDeColumna("PL_PROGRAMADO_ASIGNACION")]
        public PLProgramadoAsignacionOtd PLProgramadoAsignacion { get; set; }
    }
}
