using Administracion.Contratos.Repositorio;
using Administracion.Contratos.Servicios;
using Administracion.Modelos.Entidades;
using Administracion.OTD;
using Administracion.Repositorio.Accesso;
using Administracion.Utilidades;
using Administracion.Utilidades.Mapeos;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Net;

namespace Administracion.Servicio
{
    public class UsuarioServicio : ServicioBase, IUsuarioServicio
    {
        #region Miembros privados
        private IUsuarioRepositorio _usuarioRepositorio;
        #endregion

        #region Constructores
        public UsuarioServicio()
        {
            _usuarioRepositorio = new UsuarioRepositorio();
        }
        /// <summary>
        /// Constructor para inyeccion de dependencias
        /// </summary>
        /// <param name="usuarioRepositorio"></param>
        public UsuarioServicio(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        #endregion

        #region Metodos publicos

        /// <summary>
        /// Obtiene un listado de usuarios Disponibles
        /// </summary>
        /// <returns></returns>
        public IList<UsuarioOtd> ObtenerUsuarios()
        {
            try
            {
                return UsuarioMapeos.MapearUsuarios(_usuarioRepositorio.ObtenerTodos().ToList());
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        /// <summary>
        /// Obtiene un listado de usuarios dada una expresion
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public IList<UsuarioOtd> EncontrarPor(Expression<Func<UsuarioOtd, bool>> expression)
        {
            try
            {
                var nuevaExpression = GeneradorDePredicados.Convertir<UsuarioOtd, USUARIO>(expression);
                return UsuarioMapeos.MapearUsuarios(_usuarioRepositorio.EncontrarPor(nuevaExpression).ToList());
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        /// <summary>
        /// Verifica que la conexion dada sea valida y este activa
        /// </summary>
        /// <param name="conexion"></param>
        /// <returns></returns>
        public bool ConexionValida(string conexion)
        {
            try
            {
                OracleConnection oracleConexion = new OracleConnection(conexion);

                oracleConexion.Open();

                if (oracleConexion.State == System.Data.ConnectionState.Open)
                {
                    oracleConexion.Close();
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public HttpStatusCode ServicioActivo(string servicioUrl)
        {
            try
            {
                HttpWebRequest peticionWeb = WebRequest.Create(servicioUrl) as HttpWebRequest;
                peticionWeb.Timeout = 10000;

                using (HttpWebResponse respuestaWeb = peticionWeb.GetResponse() as HttpWebResponse)
                {
                    return respuestaWeb.StatusCode;
                }
            }
            catch (WebException)
            {
                return HttpStatusCode.NotFound;
            }
            catch (Exception)
            {
                return HttpStatusCode.NotFound;
            }
        }

        #endregion
    }
}
