using Administracion.OTD.AtributosPersonalizados;
using System.Collections.Generic;

namespace Administracion.OTD
{
    /// <summary>
    /// Modelo de la tabla 'EMPLEADO'
    /// </summary>
    public class EmpleadoOtd
    {
        /// <summary>
        /// Propiedad para la columna 'ID_EMPLEADO' de la tabla 'EMPLEADO'
        /// </summary>
        [NombreDeColumna("ID_EMPLEADO")]
        public int IdEmpleado { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_TIPO_EMPLEADO' de la tabla 'EMPLEADO'
        /// </summary>
        [NombreDeColumna("ID_TIPO_EMPLEADO")]
        public short? IdTipoDeEmpleado { get; set; }

        ///// <summary>
        ///// Propiedad para la columna 'ID_AREA_EMP' de la tabla 'EMPLEADO'
        ///// </summary>
        //[NombreDeColumna("ID_AREA_EMP")]
        //public short? IdAreaEmpleado { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_CENTRO' de la tabla 'EMPLEADO'
        /// </summary>
        [NombreDeColumna("ID_CENTRO")]
        public short? IdCentro { get; set; }

        /// <summary>
        /// Propiedad para la columna 'NUMERO_EMPLEADO' de la tabla 'EMPLEADO'
        /// </summary>
        [NombreDeColumna("NUMERO_EMPLEADO")]
        public string NumeroDeEmpleado { get; set; }

        /// <summary>
        /// Propiedad para la columna 'CENTRO' de la tabla 'EMPLEADO'
        /// </summary>
        [NombreDeColumna("CENTRO")]
        public CentroOtd Centro { get; set; }

        /// <summary>
        /// Propiedad para la columna 'TIPO_EMPLEADO' de la tabla 'EMPLEADO'
        /// </summary>
        [NombreDeColumna("TIPO_EMPLEADO")]
        public TipoDeEmpleadoOtd TipoDeEmpleado { get; set; }

        /// <summary>
        /// Propiedad para la columna 'PL_ASIGNACION_BITACORA' de la tabla 'EMPLEADO'
        /// </summary>
        [NombreDeColumna("PL_ASIGNACION_BITACORA")]
        public ICollection<PLAsignacionBitacoraOtd> PLAsignacionBitacoras { get; set; }

        /// <summary>
        /// Propiedad para la columna 'PL_PROGRAMADO' de la tabla 'EMPLEADO'
        /// </summary>
        [NombreDeColumna("PL_PROGRAMADO")]
        public virtual ICollection<PLProgramadoOtd> PLProgramados { get; set; }

        /// <summary>
        /// Propiedad para la columna 'PL_PROGRAMADO_ASIGNACION' de la tabla 'EMPLEADO'
        /// </summary>
        [NombreDeColumna("PL_PROGRAMADO_ASIGNACION")]
        public virtual ICollection<PLProgramadoAsignacionOtd> PLProgramadoAsignaciones { get; set; }

        public PersonaOtd Persona { get; set; }
    }
}
