using Administracion.OTD;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;

namespace Administracion.Contratos.Servicios
{
    public interface IUsuarioServicio
    {
        /// <summary>
        /// Obtiene un listado de usuarios Disponibles
        /// </summary>
        /// <returns></returns>
        IList<UsuarioOtd> ObtenerUsuarios();

        /// <summary>
        /// Obtiene un listado de usuarios dada una expresion.
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        IList<UsuarioOtd> EncontrarPor(Expression<Func<UsuarioOtd, bool>> expression);

        /// <summary>
        /// Verifica que la conexion dada sea valida y este activa.
        /// </summary>
        /// <param name="conexion"></param>
        /// <returns></returns>
        bool ConexionValida(string conexion);

        /// <summary>
        /// Verifica que un servicio dado se encuentre activo.
        /// </summary>
        /// <param name="servicioUrl">servico a verificar</param>
        /// <returns>El estado de conexion</returns>
        HttpStatusCode ServicioActivo(string servicioUrl);
    }
}