using Administracion.OTD.AtributosPersonalizados;
using System;
using System.Collections.Generic;

namespace Administracion.OTD
{
    public class PLCatalogoOtd
    {
        /// <summary>
        /// Propiedad para la columna 'IdPLCatalgo' de la tabla 'PL_CATALOGO'
        /// </summary>
        [NombreDeColumna("ID_PL_CATALOGO")]
        public short IdPLCatalgo { get; set; }

        /// <summary>
        /// Propiedad para la columna 'NOMBRE' de la tabla 'PL_CATALOGO'
        /// </summary>
        [NombreDeColumna("NOMBRE")]
        public string Nombre { get; set; }

        /// <summary>
        /// Propiedad para la columna 'DESCR' de la tabla 'PL_CATALOGO'
        /// </summary>
        [NombreDeColumna("DESCR")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Propiedad para la columna 'HORA_INICIO' de la tabla 'PL_CATALOGO'
        /// </summary>
        [NombreDeColumna("HORA_INICIO")]
        public DateTime? HoraInicio { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ESTATUS' de la tabla 'PL_CATALOGO'
        /// </summary>
        [NombreDeColumna("ESTATUS")]
        public string Estatus { get; set; }

        /// <summary>
        /// Propiedad para la columna 'FECHA_CREADO' de la tabla 'PL_CATALOGO'
        /// </summary>
        [NombreDeColumna("FECHA_CREADO")]
        public DateTime? FechaCreado { get; set; }


        /// <summary>
        /// Propiedad para la columna 'PL_CATALOGO_ESTATUS' de la tabla 'PL_CATALOGO'
        /// </summary>
        [NombreDeColumna("PL_CATALOGO_ESTATUS")]
        public PLCatalogoEstatusOtd PLCatalogoEstatus { get; set; }

        /// <summary>
        /// Propiedad para la columna 'PL_PROGRAMADO' de la tabla 'PL_CATALOGO'
        /// </summary>
        [NombreDeColumna("PL_PROGRAMADO")]
        public virtual ICollection<PLProgramadoOtd> PLProgramados { get; set; }
    }
}
