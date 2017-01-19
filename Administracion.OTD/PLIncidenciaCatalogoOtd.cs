using Administracion.OTD.AtributosPersonalizados;
using System;

namespace Administracion.OTD
{
    public class PLIncidenciaCatalogoOtd
    {
        /// <summary>
        /// Propiedad para la columna 'INCIDENCIA' de la tabla 'INCIDENCIA'
        /// </summary>
        [NombreDeColumna("ID_INCIDENCIA")]
        public short IdPLIncidenciaCatalogo { get; set; }

        /// <summary>
        /// Propiedad para la columna 'DESCR' de la tabla 'INCIDENCIA'
        /// </summary>
        [NombreDeColumna("DESCR")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Propiedad para la columna 'LOGIN_MODIF' de la tabla 'INCIDENCIA'
        /// </summary>
        [NombreDeColumna("LOGIN_MODIF")]
        public string ModificadoPor { get; set; }

        /// <summary>
        /// Propiedad para la columna 'FECHA_MODIF' de la tabla 'INCIDENCIA'
        /// </summary>
        [NombreDeColumna("FECHA_MODIF")]
        public DateTime? FechaModificacion { get; set; }

        /// <summary>
        /// Propiedad para la columna 'VISIBLE' de la tabla 'INCIDENCIA'
        /// </summary>
        [NombreDeColumna("VISIBLE")]
        public short Visible { get; set; }
    }
}
