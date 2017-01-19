using Administracion.OTD.AtributosPersonalizados;
using System.Collections.Generic;

namespace Administracion.OTD
{
    public class ProcesoOtd
    {
        /// <summary>
        /// Representa la columna 'ID_PROCESO' de la tabla 'PROCESO'
        /// </summary>
        [NombreDeColumna("ID_PROCESO")]
        public short IdProceso { get; set; }

        /// <summary>
        /// Representa la columna 'DESCR' de la tabla 'PROCESO'
        /// </summary>
        [NombreDeColumna("DESCR")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Representa la columna 'VENTANA' de la tabla 'PROCESO'
        /// </summary>
        [NombreDeColumna("VENTANA")]
        public string Ventana { get; set; }

        /// <summary>
        /// Representa la columna 'PROCESO_ROL' de la tabla 'PROCESO'
        /// </summary>
        [NombreDeColumna("PROCESO_ROL")]
        public ICollection<ProcesoRolOtd> ProcesoRoles { get; set; }

        /// <summary>
        /// Representa la columna 'PROCESO_USUARIO' de la tabla 'PROCESO'
        /// </summary>
        [NombreDeColumna("PROCESO_USUARIO")]
        public ICollection<ProcesoUsuarioOtd> ProcesoUsuarios { get; set; }
    }
}
