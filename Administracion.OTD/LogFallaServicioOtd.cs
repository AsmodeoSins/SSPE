using Administracion.OTD.AtributosPersonalizados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Administracion.OTD
{
    public class LogFallaServicioOtd
    {
        /// <summary>
        /// Propiedad para la columna 'ID' de la tabla 'LOGFALLASERVICIO'
        /// </summary>
        [NombreDeColumna("ID")]
        public int LogFallaServicioId { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID' de la tabla 'LOGFALLASERVICIO'
        /// </summary>
        [NombreDeColumna("CODIGODEERROR")]
        public string CodigoDeError { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID' de la tabla 'LOGFALLASERVICIO'
        /// </summary>
        [NombreDeColumna("MENSAJEDEERROR")]
        public string MensajeDeError { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID' de la tabla 'LOGFALLASERVICIO'
        /// </summary>
        [NombreDeColumna("DETALLEDELERROR")]
        public string DetalleDeErrror { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID' de la tabla 'LOGFALLASERVICIO'
        /// </summary>
        [NombreDeColumna("APPLICATIONNAME")]
        public string ApplicationName { get; set; }

        /// <summary>
        /// Propiedad para la columna 'FECHADECREACION' de la tabla 'LOGFALLASERVICIO'
        /// </summary>
        [NombreDeColumna("FECHADECREACION")]
        public DateTime FechaDeCreacion { get; set; }
    }
}
