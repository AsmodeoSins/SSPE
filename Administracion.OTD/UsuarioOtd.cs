using Administracion.OTD.AtributosPersonalizados;
using System.Collections.Generic;

namespace Administracion.OTD
{
    public class UsuarioOtd
    {
        /// <summary>
        /// Representa la columna 'ID_USUARIO' de la tabla 'USUARIO'
        /// </summary>
        [NombreDeColumna("ID_USUARIO")]
        public string IdUsuario { get; set; }

        /// <summary>
        /// Representa la columna 'ID_EMPLEADO' de la tabla 'USUARIO'
        /// </summary>
        [NombreDeColumna("ID_PERSONA")]
        public int? IdPersona { get; set; }

        /// <summary>
        /// Representa la columna 'PASSWORD' de la tabla 'USUARIO'
        /// </summary>
        [NombreDeColumna("PASSWORD")]
        public string Password { get; set; }

        /// <summary>
        /// Representa la columna 'ESTATUS' de la tabla 'USUARIO'
        /// </summary>
        [NombreDeColumna("ESTATUS")]
        public string Estatus { get; set; }

        /// <summary>
        /// Representa la columna 'EMPLEADO' de la tabla 'USUARIO'
        /// </summary>
        [NombreDeColumna("PERSONA")]
        public PersonaOtd Persona { get; set; }

        /// <summary>
        /// Representa la columna 'PROCESO_USUARIO' de la tabla 'USUARIO'
        /// </summary>
        [NombreDeColumna("PROCESO_USUARIO")]
        public ICollection<ProcesoUsuarioOtd> ProcesosUsuario { get; set; }

        /// <summary>
        /// Representa la columna 'USUARIO_MENSAJE' de la tabla 'USUARIO'
        /// </summary>
        [NombreDeColumna("USUARIO_MENSAJE")]
        public ICollection<UsuarioMensajeOtd> UsuarioMensajes { get; set; }

        /// <summary>
        /// Representa la columna 'USUARIO_ROL' de la tabla 'USUARIO'
        /// </summary>
        [NombreDeColumna("USUARIO_ROL")]
        public ICollection<UsuarioRolOtd> UsuarioRoles { get; set; }
    }
}
