using Administracion.OTD.AtributosPersonalizados;
using System.Collections.Generic;

namespace Administracion.OTD
{
    public class CeldaOtd
    {
        /// <summary>
        /// Propiedad para la columna 'ID_CELDA' de la tabla 'CELDA'
        /// </summary>
        [NombreDeColumna("ID_CELDA")]
        public string IdCelda { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_CELDA' de la tabla 'CELDA'
        /// </summary>
        [NombreDeColumna("ID_CENTRO")]
        public short IdCentro { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_EDIFICIO' de la tabla 'CELDA'
        /// </summary>
        [NombreDeColumna("ID_EDIFICIO")]
        public short IdEdificio { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_SECTOR' de la tabla 'CELDA'
        /// </summary>
        [NombreDeColumna("ID_SECTOR")]
        public short IdSector { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_TIPO_SEGURIDA' de la tabla 'CELDA'
        /// </summary>
        [NombreDeColumna("ID_TIPO_SEGURIDAD")]
        public string IdTipoSeguridad { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_CELDA' de la tabla 'CELDA'
        /// </summary>
        [NombreDeColumna("ID_TIPO_CELDA")]
        public string IdTipoCelda { get; set; }

        /// <summary>
        /// Propiedad para la columna 'NIVEL_EDIFICIO' de la tabla 'CELDA'
        /// </summary>
        [NombreDeColumna("NIVEL_EDIFICIO")]
        public short? NivelEdificio { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ESTATUS' de la tabla 'CELDA'
        /// </summary>
        [NombreDeColumna("ESTATUS")]
        public string  Estatus { get; set; }

        /// <summary>
        /// Propiedad para la columna 'EDIFICIO' de la tabla 'CELDA'
        /// </summary>
        [NombreDeColumna("EDIFICIO")]
        public EdificioOtd Edificio { get; set; }

        /// <summary>
        /// Propiedad para la columna 'SECTOR' de la tabla 'CELDA'
        /// </summary>
        [NombreDeColumna("SECTOR")]
        public SectorOtd Sector { get; set; }

        /// <summary>
        /// Propiedad para la columna 'PASELISTA_RESULTADO' de la tabla 'CELDA'
        /// </summary>
        [NombreDeColumna("PL_ASIGNACION_RESULTADO")]
        public ICollection<PLAsignacionResultadoOtd> PLAsignacionResultados { get; set; }

        /// <summary>
        /// Propiedad para la columna 'TIPO_CELDA' de la tabla 'CELDA'
        /// </summary>
        [NombreDeColumna("TIPO_CELDA")]
        public TipoDeCeldaOtd TipoCelda { get; set; }
    }
}
