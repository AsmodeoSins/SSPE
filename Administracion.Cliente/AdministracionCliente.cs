using Administracion.OTD;
using Administracion.Utilidades.ClasesAuxiliares;
using Administracion.Utilidades.Mapeadores;
using Administracion.Utilidades.Mapeos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace Administracion.Api.Cliente
{
    /// <summary>
    /// Clase auxiliar para establecer conexion con la aplicacion de administracion
    /// </summary>
    public static class ClienteAdministracion
    {
        #region Constantes
        /// <summary>
        /// Url donde estara publicada la web api de la aplicacion
        /// </summary>
        private static readonly string URL_INICIAR_APLICACION = "http://localhost:4321/api/Administracion/Iniciar";

        /// <summary>
        /// Error regresado cuando no se pudo contactar la aplicacioZNn
        /// </summary>
        private static readonly string ERROR_CONTACTANDO_APLICACION = "Hubo un problema contactando la aplicacion";

        /// <summary>
        /// Error de excepcion cuando la web api no esta inciada
        /// </summary>
        private readonly static string ERROR_API_NO_INICIADA = "Unable to connect to the remote server";

        /// <summary>
        /// Mensaje a regresar cuando el webapi no esta disponible
        /// </summary>
        private readonly static string MENSAJE_API_NO_INICIADA = "No se pudo conectar con la aplicacion";
        #endregion


        #region Metodos publicos
        /// <summary>
        /// Inicia la aplicacion administrativa dado un id de centro
        /// </summary>
        /// <param name="idCentro">Id del centro con el cual se incializara la aplicacion</param>
        /// <param name="connectionString"><example>DATA SOURCE=MiDataSource; PASSWORD=MiPassword; USER ID=MiUsuario</example></param>
        /// <returns>Un WebApiResponse con la informacion de la incializacion correspondiente</returns>
        public static WebApiRespuesta<SesionOtd> Iniciar(int idCentro, int idEmpleado, string connectionString)
        {
            try
            {
                Mapeadores.InicializarMapeadores();
                var javaScriptSerializer = new JavaScriptSerializer();

                var objetoDeSesion = new SesionOtd
                {
                    IdEmpleado = idEmpleado,
                    IdCentro = (short)idCentro,
                    Conexion = connectionString,
                    Usuario = new UsuarioOtd { ProcesosUsuario = new List<ProcesoUsuarioOtd>()}
                };

                var request = (HttpWebRequest)WebRequest.Create(URL_INICIAR_APLICACION);

                var sesionJson = javaScriptSerializer.Serialize(objetoDeSesion);

                var data = Encoding.ASCII.GetBytes(sesionJson);

                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return javaScriptSerializer.Deserialize<WebApiRespuesta<SesionOtd>>(responseString);
            }
            catch (Exception ex)
            {
                var mensaje = ObtenerMensajeDeError(ex);
                return new WebApiRespuesta<SesionOtd>
                {
                    Mensaje = mensaje,
                    Error = ERROR_CONTACTANDO_APLICACION,
                    LlamadoExistoso = false
                };
            }
        }

        private static string ObtenerMensajeDeError(Exception ex)
        {
            var mensaje = ex.Message;
            if (ex.Message.Contains(ERROR_API_NO_INICIADA))
            {
                mensaje = MENSAJE_API_NO_INICIADA;
            }
            return mensaje;
        }
        #endregion
    }
}
