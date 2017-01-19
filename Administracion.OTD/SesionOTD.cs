using System;
using System.Collections.Generic;
using System.Linq;

namespace Administracion.OTD
{
    public class SesionOtd
    {
        /// <summary>
        /// Representa el centro actual
        /// </summary>
        public short IdCentro { get; set; }

        /// <summary>
        /// Usuario logeado
        /// </summary>
        public int IdEmpleado { get; set; }

        /// <summary>
        /// Representa el string de conexion a la base de datos Ejemplo: <bold>DATA SOURCE=XE;PASSWORD=MiPassword;USER ID=MiUsuario</bold>
        /// </summary>
        /// <example>DATA SOURCE=XE;PASSWORD=MiPassword;USER ID=MiUsuario</example>
        public string Conexion { get; set; }

        public string BioServer { get; set; }

        /// <summary>
        /// Representa el modelo del usuario actual
        /// </summary>
        public UsuarioOtd Usuario { get; set; }

        /// <summary>
        /// Permisos para los modulos de la aplicacion para el usuario
        /// </summary>
        public List<PermisosModulo> PermisosModulos
        {
            get
            {
                return Usuario.ProcesosUsuario.Select(pu =>
                    new PermisosModulo
                    {
                        NombreModulo = pu.Proceso.Descripcion.Trim(),
                        Consultar = Convert.ToBoolean(pu.Consultar),
                        Editar = Convert.ToBoolean(pu.Editar),
                        Insertar = Convert.ToBoolean(pu.Insertar)
                    }).ToList();
            }
        }

        public bool EsNueva { get; set; }
    }
}
