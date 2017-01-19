using Administracion.OTD.AtributosPersonalizados;
using System;

namespace Administracion.OTD
{
    public class UsuarioRolOtd
    {
        /// <summary>
        /// Representa la columna 'ID_USUARIO' de la tabla 'PROCESO'
        /// </summary>
        [NombreDeColumna("ID_USUARIO")]
        public string IdUsuario { get; set; }

        /// <summary>
        /// Representa la columna 'ID_ROL' de la tabla 'PROCESO'
        /// </summary>
        [NombreDeColumna("ID_ROL")]
        public short IdRol { get; set; }

        /// <summary>
        /// Representa la columna 'FECHA' de la tabla 'PROCESO'
        /// </summary>
        [NombreDeColumna("FECHA")]
        public DateTime? Fecha { get; set; }

        /// <summary>
        /// Representa la columna 'USUARIO' de la tabla 'PROCESO'
        /// </summary>
        [NombreDeColumna("USUARIO")]
        public UsuarioOtd Usuario { get; set; }
    }
}
