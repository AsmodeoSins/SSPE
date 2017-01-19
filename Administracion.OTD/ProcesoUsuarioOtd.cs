using Administracion.OTD.AtributosPersonalizados;
using System;

namespace Administracion.OTD
{
    public class ProcesoUsuarioOtd
    {
        /// <summary>
        /// Representa la columna 'ID_PROCESO' de la tabla 'PROCESO_USUARIO'
        /// </summary>
        [NombreDeColumna("ID_PROCESO")]
        public short IdProceso { get; set; }

        /// <summary>
        /// Representa la columna 'ID_USUARIO' de la tabla 'PROCESO_USUARIO'
        /// </summary>
        [NombreDeColumna("ID_USUARIO")]
        public string IdUsuario { get; set; }

        /// <summary>
        /// Representa la columna 'ID_ROL' de la tabla 'PROCESO_USUARIO'
        /// </summary>
        [NombreDeColumna("ID_ROL")]
        public short IdRol { get; set; }

        /// <summary>
        /// Representa la columna 'INSERTAR' de la tabla 'PROCESO_USUARIO'
        /// </summary>
        [NombreDeColumna("INSERTAR")]
        public Nullable<short> Insertar { get; set; }

        /// <summary>
        /// Representa la columna 'EDITAR' de la tabla 'PROCESO_USUARIO'
        /// </summary>
        [NombreDeColumna("EDITAR")]
        public Nullable<short> Editar { get; set; }

        /// <summary>
        /// Representa la columna 'CONSULTAR' de la tabla 'PROCESO_USUARIO'
        /// </summary>
        [NombreDeColumna("CONSULTAR")]
        public Nullable<short> Consultar { get; set; }

        /// <summary>
        /// Representa la columna 'IMPRIMIR' de la tabla 'PROCESO_USUARIO'
        /// </summary>
        [NombreDeColumna("IMPRIMIR")]
        public Nullable<short> Imprimir { get; set; }

        /// <summary>
        /// Representa la columna 'DIGITALIZAR' de la tabla 'PROCESO_USUARIO'
        /// </summary>
        [NombreDeColumna("DIGITALIZAR")]
        public Nullable<short> Digitalizar { get; set; }

        /// <summary>
        /// Representa la columna 'PROCESO' de la tabla 'PROCESO_USUARIO'
        /// </summary>
        [NombreDeColumna("PROCESO")]
        public ProcesoOtd Proceso { get; set; }

        /// <summary>
        /// Representa la columna 'USUARIO' de la tabla 'PROCESO_USUARIO'
        /// </summary>
        [NombreDeColumna("USUARIO")]
        public virtual UsuarioOtd Usuario { get; set; }
    }
}
