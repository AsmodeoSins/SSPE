using Administracion.OTD.AtributosPersonalizados;
using System.Collections.Generic;

namespace Administracion.OTD
{
    public class PLProgramadoAsignacionOtd
    {
        /// <summary>
        /// Propiedad para la columna 'ID_PL_ASIGNACION' de la tabla 'PL_ASIGNACION'
        /// </summary>
        [NombreDeColumna("ID_PL_ASIGNACION")]
        public int IdPLAsignacion { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_PL_PROGRAMADO' de la tabla 'PL_ASIGNACION'
        /// </summary>
        [NombreDeColumna("ID_PL_PROGRAMADO")]
        public int IdPLProgramado { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_EDIFICIO' de la tabla 'PL_ASIGNACION'
        /// </summary>
        [NombreDeColumna("ID_EDIFICIO")]
        public short IdEdificio { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_SECTOR' de la tabla 'PL_ASIGNACION'
        /// </summary>
        [NombreDeColumna("ID_SECTOR")]
        public short IdSector { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_EMPLEADO' de la tabla 'PL_ASIGNACION'
        /// </summary>
        [NombreDeColumna("ID_EMPLEADO")]
        public int IdEmpleado { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_CENTRO' de la tabla 'PL_ASIGNACION'
        /// </summary>
        [NombreDeColumna("ID_CENTRO")]
        public short IdCentro { get; set; }

        /// <summary>
        /// Propiedad para la columna 'EDIFICIO' de la tabla 'PL_ASIGNACION'
        /// </summary>
        [NombreDeColumna("EDIFICIO")]
        public EdificioOtd Edificio { get; set; }

        /// <summary>
        /// Propiedad para la columna 'EMPLEADO' de la tabla 'PL_ASIGNACION'
        /// </summary>
        [NombreDeColumna("EMPLEADO")]
        public EmpleadoOtd Empleado { get; set; }

        /// <summary>
        /// Propiedad para la columna 'PL_ASIGNACION_RESULTADO' de la tabla 'PL_ASIGNACION'
        /// </summary>
        [NombreDeColumna("PL_ASIGNACION_RESULTADO")]
        public ICollection<PLAsignacionResultadoOtd> PlAsignacionResultado { get; set; }

        /// <summary>
        /// Propiedad para la columna 'PL_PROGRAMADO' de la tabla 'PL_ASIGNACION'
        /// </summary>
        [NombreDeColumna("PL_PROGRAMADO")]
        public PLProgramadoOtd PLProgramdo { get; set; }

        /// <summary>
        /// Propiedad para la columna 'SECTOR' de la tabla 'PL_ASIGNACION'
        /// </summary>
        [NombreDeColumna("SECTOR")]
        public SectorOtd Sector { get; set; }
    }
}
