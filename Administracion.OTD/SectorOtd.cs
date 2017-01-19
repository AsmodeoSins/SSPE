using Administracion.OTD.AtributosPersonalizados;
using System.Collections.Generic;

namespace Administracion.OTD
{
    /// <summary>
    /// Modelo para la tabla 'SECTOR'
    /// </summary>
    public class SectorOtd
    {
        /// <summary>
        /// Propiedad para la columna 'ID_SECTOR' de la tabla 'SECTOR'
        /// </summary>
        [NombreDeColumna("ID_SECTOR")]
        public short IdSector { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_CENTRO' de la tabla 'SECTOR'
        /// </summary>
        [NombreDeColumna("ID_CENTRO")]
        public short IdCentro { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_EDIFICIO' de la tabla 'SECTOR'
        /// </summary>
        [NombreDeColumna("ID_EDIFICIO")]
        public short IdEdificio { get; set; }

        /// <summary>
        /// Propiedad para la columna 'DESCR' de la tabla 'SECTOR'
        /// </summary>
        [NombreDeColumna("DESCR")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Propiedad para la columna 'PLANO' de la tabla 'SECTOR'
        /// </summary>
        [NombreDeColumna("PLANO")]
        public byte[] Plano { get; set; }

        /// <summary>
        /// Propiedad para la columna 'CELDAs' de la tabla 'SECTOR'
        /// </summary>
        [NombreDeColumna("CELDAs")]
        public ICollection<CeldaOtd> Celdas { get; set; }

        /// <summary>
        /// Propiedad para la columna 'CENTRO' de la tabla 'SECTOR'
        /// </summary>
        [NombreDeColumna("CENTRO")]
        public CentroOtd Centro { get; set; }

        /// <summary>
        /// Propiedad para la columna 'EDIFICIO' de la tabla 'SECTOR'
        /// </summary>
        [NombreDeColumna("EDIFICIO")]
        public EdificioOtd Edificio { get; set; }

        /// <summary>
        /// Propiedad para la columna 'PL_PROGRAMADO_ASIGNACION' de la tabla 'SECTOR'
        /// </summary>
        [NombreDeColumna("PL_PROGRAMADO_ASIGNACION")]
        public ICollection<PLProgramadoAsignacionOtd> PLProgramadoAsignaciones { get; set; }
    }
}
