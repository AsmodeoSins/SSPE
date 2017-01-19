using Administracion.Contratos;
using Administracion.Contratos.Servicios;
using Administracion.Enum;
using Administracion.OTD;
using Administracion.Servicio;
using Administracion.Utilidades.Autenticacion;
using Administracion.Utilidades.ClasesAuxiliares;
using Administracion.Utilidades.Mapeadores;
using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace Administracion.Api
{

    public class AdministracionController : ApiController
    {
        #region Constantes
        /// <summary>
        /// Constante para el nombre de proceso de la aplicacion administrativa
        /// </summary>
        private readonly string NOMBRE_PROCESO_APPLICACION = "Administracion.Presentacion";

        /// <summary>
        /// Constante para el ejecutable de la aplicacion administrativa
        /// </summary>
        private readonly string NOMBRE_EJECUTABLE_APPLICACION = "Administracion.Presentacion.exe";

        /// <summary>
        /// Error regresado cuando el centro recibido es invalido
        /// </summary>
        private readonly string ERROR_SESION_REQUERIDA = "El objeto de sesion es requerido";
        
        /// <summary>
        /// Mensaje regresado cuando el proceso ya esta en ejecucion
        /// </summary>
        private readonly string ERROR_PROCESO_EN_EJECUCION = "El proceso ya esta en ejecucion";
        
        /// <summary>
        /// Error regresado cuando no se pudo iniciar la aplicacion
        /// </summary>
        private readonly string ERROR_INICIANDO_APLICACION = "Hubo un error al iniciar la aplicacion administrativa";
        
        /// <summary>
        /// Mensaje regresado cuando la aplicacion se inicio correctamente
        /// </summary>
        private readonly string APPLICACION_INICIADA_EXITOSAMENTE = "La aplicacion fue iniciada exitosamente";

        /// <summary>
        /// Mensaje de excepcion cuando los datos de conexion son invalidos
        /// </summary>
        private readonly string ERROR_CREDENCIALES_INVALIDAS = "The underlying provider failed on Open.";

        /// <summary>
        /// Mensaje a regresar cuando los datos de conexion no son validos
        /// </summary>
        private readonly string MENSAJE_CREDENCIALES_INVALIDAS = "Los datos de conexion proporcionados no son validos";
        #endregion

        #region Miembros privados
        private ICentroServicio _centroServicio;
        private IEmpleadoServicio _empleadoServicio;
        private IUsuarioServicio _usuarioServicio;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor para incializacion de centro servicio
        /// </summary>
        /// <param name="centroServicio"></param>
        public AdministracionController()
        {
            UbicacionMapeador.Configuracion();
            _centroServicio = new CentroServicio();
            _empleadoServicio = new EmpleadoServicio();
            _usuarioServicio = new UsuarioServicio();
        }
        #endregion

        [HttpPost]
        public WebApiRespuesta<SesionOtd> Iniciar(SesionOtd sesion)
        {
            try
            {
                var mensaje = string.Empty;
                Sesion.ObjetoDeSesion = sesion;

                if (sesion == null)
                {
                    throw new Exception(ERROR_SESION_REQUERIDA);
                }

                Mapeadores.InicializarMapeadores();
                var centroCompleto = _centroServicio.EncontrarPor(c => c.IdCentro == sesion.IdCentro).FirstOrDefault();
                var custodiosPorCentro = _empleadoServicio.EncontrarPor(e => e.IdTipoDeEmpleado == (short)TipoEmpleado.Comandancia04 && e.IdCentro == sesion.IdCentro);
                var usuarios = _usuarioServicio.EncontrarPor(u => u.IdPersona == sesion.IdEmpleado);
                if (usuarios == null)
                {
                    throw new Exception("El empleado especificado no existe");
                }

                if (centroCompleto == null)
                {
                    throw new Exception("El centro especificado no existe");
                }

                if (custodiosPorCentro == null || !custodiosPorCentro.Any(c => c.IdEmpleado == sesion.IdEmpleado))
                {
                    throw new Exception("El id del empleado no pertenece al centro que se especifico");
                }

                if (ManejoDeVentanas.EstaEjecutandose(NOMBRE_PROCESO_APPLICACION))
                {
                    mensaje = ERROR_PROCESO_EN_EJECUCION;
                }
                else
                {
                    sesion.Usuario = usuarios.FirstOrDefault();
                    var json = new JavaScriptSerializer().Serialize(sesion);
                    var base64 = CodificadorBase64.CodificarABase64(json);
                    ProcessStartInfo startInfo = new ProcessStartInfo(NOMBRE_EJECUTABLE_APPLICACION);
                    var proceso = Process.Start(startInfo.FileName, base64);
                    mensaje = APPLICACION_INICIADA_EXITOSAMENTE;
                }

                return new WebApiRespuesta<SesionOtd>
                {
                    Datos = null,
                    LlamadoExistoso = true,
                    Mensaje = mensaje
                };
            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
                return new WebApiRespuesta<SesionOtd>
                {
                    Datos = null,
                    Error = MENSAJE_CREDENCIALES_INVALIDAS,
                    LlamadoExistoso = false,
                    Mensaje = ObtenerMensajeDeError(ex)
                };
            }
        }

        private string ObtenerMensajeDeError(Exception ex)
        {
            var mensaje = ex.Message;
            if (ex.Message.Contains(ERROR_CREDENCIALES_INVALIDAS))
            {
                mensaje = MENSAJE_CREDENCIALES_INVALIDAS;
            }
            return mensaje;
        }
    }
}
