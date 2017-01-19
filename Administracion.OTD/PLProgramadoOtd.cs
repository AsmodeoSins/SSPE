using Administracion.OTD.AtributosPersonalizados;
using System;
using System.Collections.Generic;

namespace Administracion.OTD
{
    public class PLProgramadoOtd
    {
        /// <summary>
        /// Propiedad para la columna 'ID_PL_PROGRAMADO' de la tabla 'PL_PROGRAMADO'
        /// </summary>
        [NombreDeColumna("ID_PL_PROGRAMADO")]
        public int IdPlProgramado { get; set; }

        /// <summary>
        /// Propiedad para la columna 'IdPLCatalgo' de la tabla 'PL_PROGRAMADO'
        /// </summary>
        [NombreDeColumna("ID_PL_CATALOGO")]
        public short IdPLCatalogo { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_CENTRO' de la tabla 'PL_PROGRAMADO'
        /// </summary>
        [NombreDeColumna("ID_CENTRO")]
        public short IdCentro { get; set; }

        /// <summary>
        /// Propiedad para la columna 'VIGENTE' de la tabla 'PL_PROGRAMADO'
        /// </summary>
        [NombreDeColumna("VIGENTE")]
        public short Vigente { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_EMPLEADO_CREADO' de la tabla 'PL_PROGRAMADO'
        /// </summary>
        [NombreDeColumna("ID_EMPLEADO_CREADO")]
        public int IdEmpleadoCreado { get; set; }

        /// <summary>
        /// Propiedad para la columna 'FECH_CREADO' de la tabla 'PL_PROGRAMADO'
        /// </summary>
        [NombreDeColumna("FECH_CREADO")]
        public DateTime FechaCreado { get; set; }

        /// <summary>
        /// Propiedad para la columna 'CENTRO' de la tabla 'PL_PROGRAMADO'
        /// </summary>
        [NombreDeColumna("CENTRO")]
        public CentroOtd Centro { get; set; }

        /// <summary>
        /// Propiedad para la columna 'EMPLEADO' de la tabla 'PL_PROGRAMADO'
        /// </summary>
        [NombreDeColumna("EMPLEADO")]
        public EmpleadoOtd Empleado { get; set; }

        /// <summary>
        /// Propiedad para la columna 'PL_CATALOGO' de la tabla 'PL_PROGRAMADO'
        /// </summary>
        [NombreDeColumna("PL_CATALOGO")]
        public PLCatalogoOtd PLCatalogo { get; set; }

        /// <summary>
        /// Propiedad para la columna 'PL_PROGRAMADO' de la tabla 'PL_PROGRAMADO'
        /// </summary>
        [NombreDeColumna("ID_PL_PROGRAMADO")]
        public ICollection<PLProgramadoAsignacionOtd> PLProgramadoAsignaciones { get; set; }
    }
}
