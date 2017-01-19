using Administracion.OTD.AtributosPersonalizados;
using System;

namespace Administracion.OTD
{
    public class UsuarioMensajeOtd
    {
        /// <summary>
        /// Representa la columna 'ID_USUARIO' de la tabla 'USUARIO_MENSAJE'
        /// </summary>
        [NombreDeColumna("ID_USUARIO")]
        public string IdUsuario { get; set; }

        /// <summary>
        /// Representa la columna 'ID_MENSAJE' de la tabla 'USUARIO_MENSAJE'
        /// </summary>
        [NombreDeColumna("ID_MENSAJE")]
        public int IdMensaje { get; set; }

        /// <summary>
        /// Representa la columna 'LECTURA_FEC' de la tabla 'USUARIO_MENSAJE'
        /// </summary>
        [NombreDeColumna("LECTURA_FEC")]
        public DateTime LecturaFecha { get; set; }

        /// <summary>
        /// Representa la columna 'ESTATUS' de la tabla 'USUARIO_MENSAJE'
        /// </summary>
        [NombreDeColumna("ESTATUS")]
        public short? Estatus { get; set; }

        /// <summary>
        /// Representa la columna 'USUARIO' de la tabla 'USUARIO_MENSAJE'
        /// </summary>
        [NombreDeColumna("USUARIO")]
        public virtual UsuarioOtd Usuario { get; set; }
    }
}
