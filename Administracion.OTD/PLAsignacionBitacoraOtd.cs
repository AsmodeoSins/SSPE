using Administracion.OTD.AtributosPersonalizados;
using System;

namespace Administracion.OTD
{

    public class PLAsignacionBitacoraOtd
    {
        /// <summary>
        /// Propiedad para la columna 'ID_ASIGNACION_BITACORA' de la tabla 'PL_ASIGNACION_BITACORA'
        /// </summary>
        [NombreDeColumna("ID_ASIGNACION_BITACORA")]
        public int IdAsignacionBitacora { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_PL_PROGRAMADO_BITACORA' de la tabla 'ID_PL_PROGRAMADO_BITACORA'
        /// </summary>
        [NombreDeColumna("ID_PL_PROGRAMADO_BITACORA")]
        public int IdPLProgramadoBitacora { get; set; }

        /// <summary>
        /// Propiedad para la columna 'HORA_INICIAL' de la tabla 'ID_PL_PROGRAMADO_BITACORA'
        /// </summary>
        [NombreDeColumna("HORA_INICIAL")]
        public DateTime? HoraInical { get; set; }

        /// <summary>
        /// Propiedad para la columna 'HORA_FINAL' de la tabla 'ID_PL_PROGRAMADO_BITACORA'
        /// </summary>
        [NombreDeColumna("HORA_FINAL")]
        public DateTime? HoraFinal { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_EMPLEADO' de la tabla 'ID_PL_PROGRAMADO_BITACORA'
        /// </summary>
        [NombreDeColumna("ID_EMPLEADO")]
        public int IdEmpleado { get; set; }

        /// <summary>
        /// Propiedad para la columna 'EMPLEADO' de la tabla 'ID_PL_PROGRAMADO_BITACORA'
        /// </summary>
        [NombreDeColumna("EMPLEADO")]
        public EmpleadoOtd Empleado { get; set; }
    }
}
