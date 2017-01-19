using Administracion.OTD.AtributosPersonalizados;
using System.Collections.Generic;

namespace Administracion.OTD
{
    public class EdificioOtd
    {
        /// <summary>
        /// Propiedad para la columna 'ID_EDIFICIO' de la tabla 'EDIFICIO'
        /// </summary>
        [NombreDeColumna("ID_EDIFICIO")]
        public short IdEdificio { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_CENTRO' de la tabla 'EDIFICIO'
        /// </summary>
        [NombreDeColumna("ID_CENTRO")]
        public short IdCentro { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_TIPO_EDIFICIO' de la tabla 'EDIFICIO'
        /// </summary>
        [NombreDeColumna("ID_TIPO_EDIFICIO")]
        public short? IdTipoEdificio { get; set; }

        /// <summary>
        /// Propiedad para la columna 'DESCR' de la tabla 'EDIFICIO'
        /// </summary>
        [NombreDeColumna("DESCR")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Propiedad para la columna 'CENTRO' de la tabla 'EDIFICIO'
        /// </summary>
        [NombreDeColumna("CENTRO")]
        public CentroOtd Centro { get; set; }

        /// <summary>
        /// Propiedad para la columna 'TIPO_EDIFICIO' de la tabla 'EDIFICIO'
        /// </summary>
        [NombreDeColumna("TIPO_EDIFICIO")]
        public TipoDeEdificioOtd TipoDeEdificio { get; set; }

        /// <summary>
        /// Propiedad para la columna 'SECTORs' de la tabla 'EDIFICIO'
        /// </summary>
        [NombreDeColumna("SECTORs")]
        public ICollection<SectorOtd> Sectores { get; set; }

        /// <summary>
        /// Propiedad para la columna 'PL_PROGRAMADO_ASIGNACION' de la tabla 'EDIFICIO'
        /// </summary>
        [NombreDeColumna("PL_PROGRAMADO_ASIGNACION")]
        public ICollection<PLProgramadoAsignacionOtd> PLProgramadoAsignaciones { get; set; }

    }
}
