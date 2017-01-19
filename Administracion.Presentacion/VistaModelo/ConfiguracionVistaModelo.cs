using Administracion.Contratos;
using Administracion.Contratos.Servicios;
using Administracion.OTD;
using Administracion.Presentacion.Properties;
using Administracion.Servicio;
using Administracion.Utilidades.Autenticacion;
using Administracion.Utilidades.ClasesAuxiliares;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml;

namespace Administracion.Presentacion.VistaModelo
{
    public class ConfiguracionVistaModelo : ViewModelBase, IConfiguracionVista
    {
        #region Constantes
        /// <summary>
        /// Mensaje de excepcion cuando los datos de conexion son invalidos
        /// </summary>
        private readonly string ERROR_CREDENCIALES_INVALIDAS = "The underlying provider failed on Open.";
        /// <summary>
        /// Mensaje a regresar cuando los datos de conexion no son validos
        /// </summary>
        private readonly string MENSAJE_CREDENCIALES_INVALIDAS = "Los datos de conexion proporcionados no son validos";
        /// <summary>
        /// Mensaje a regresar cuando el empleado especificado no existe
        /// </summary>
        private readonly string MENSAJE_EMPLEADO_NO_EXISTE = "El empleado especificado no existe";
        /// <summary>
        /// Mensaje a regresar cuando el empleado no pertenece al centro;
        /// </summary>
        private readonly string MENSAJE_EMPLEADO_NO_PERTENECE_AL_CENTRO = "El empleado especificado no pertnece al centro indicado";
        /// <summary>
        /// Mensaje a regresar cuando hubo un error desconocido
        /// </summary>
        private readonly string MENSAJE_ERROR_DESCONOCIDO = "Hubo un problema probando los datos. Intente de nuevo o contacte a su administrador";
        /// <summary>
        /// Mensaje a regresar cuando los datos fueron probados correctamente
        /// </summary>
        private readonly string MENSAJE_DATOS_CORRECTOS = "Los datos fueron probados correctamente!";
        /// <summary>
        /// Mensaje a mostrar cuando los datos se han guardado correctamente
        /// </summary>
        private readonly string MENSAJE_DATOS_GUARDADOS_CORRECTAMENTE = "Los datos se han guardado correctamente, la applicacion se reiniciara para aplicar los cambios";
        /// <summary>
        /// Mensaje a regresar cuando el bio server no responde desde la direccion especificada
        /// </summary>
        private readonly string MENSAJE_BIOSERVER_NO_RESPONDE = "No se Pudo Conectar con el Servidor Biometrico";
        #endregion

        #region Miembros privados
        private int _idCentro;
        private int _idEmpleado;
        private string _servicio;
        private string _usuarioBD;
        private string _password;
        private string _mensaje;
        private string _sesionBase64;
        private string _ipBioServer;
        private IEmpleadoServicio _empleadoServicio;
        private IUsuarioServicio _usuarioServicio;
        private bool _mostrarBotonGuardar;
        #endregion

        #region Propiedades
        public int IdCentro
        {
            get
            {
                return _idCentro;
            }
            set
            {
                _idCentro = value;
                RaisePropertyChanged("IdCentro");
            }
        }

        public int IdEmpleado
        {
            get
            {
                return _idEmpleado;
            }
            set
            {
                _idEmpleado = value;
                RaisePropertyChanged("IdEmpleado");
            }
        }

        public string Servicio
        {
            get
            {
                return _servicio;
            }
            set
            {
                _servicio = value;
                RaisePropertyChanged("Servicio");
            }
        }

        public string UsuarioBD
        {
            get
            {
                return _usuarioBD;
            }
            set
            {
                _usuarioBD = value;
                RaisePropertyChanged("UsuarioBD");
            }
        }

        public string PasswordBD
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                RaisePropertyChanged("PasswordBD");
            }
        }

        public string Mensaje
        {
            get
            {
                return _mensaje;
            }
            set
            {
                _mensaje = value;
                RaisePropertyChanged("Mensaje");
            }
        }

        public string IpBioServer
        {
            get
            {
                return _ipBioServer;
            }
            set
            {
                _ipBioServer = value;
                RaisePropertyChanged("IpBioServer");
            }
        }

        public bool MostrarBotonGuardar
        {
            get
            {
                return _mostrarBotonGuardar;
            }
            set
            {
                _mostrarBotonGuardar = value;
                RaisePropertyChanged("MostrarBotonGuardar");
            }
        }

        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por default
        /// </summary>
        public ConfiguracionVistaModelo(IEmpleadoServicio empleadoServicio, IUsuarioServicio usuarioServicio)
        {
            _empleadoServicio = empleadoServicio;
            _usuarioServicio = usuarioServicio;
        }
        #endregion

        #region Commands

        public RelayCommand ProbarDatosCommand
        {
            get
            {
                return new RelayCommand(ProbarDatos);
            }
        }

        public RelayCommand GuardarCommand
        {
            get
            {
                return new RelayCommand(GuardarDatos);
            }
        }

        #endregion

        #region Metodos privados

        /// <summary>
        /// Valida que los datos introducidos sean validos
        /// </summary>
        /// <returns></returns>
        private void ProbarDatos()
        {
            try
            {
                MostrarBotonGuardar = false;

                var sesion = new SesionOtd
                {
                    Conexion = string.Format("DATA SOURCE={0};PASSWORD={1};USER ID={2}", Servicio, PasswordBD, UsuarioBD),
                    IdCentro = (short)IdCentro,
                    IdEmpleado = IdEmpleado,
                };

                Sesion.ObjetoDeSesion = sesion;

                var usuarios = _usuarioServicio.EncontrarPor(u => u.IdPersona == IdEmpleado);
                sesion.Usuario = usuarios.FirstOrDefault();
                sesion.Usuario.ProcesosUsuario = sesion.Usuario.ProcesosUsuario.OrderBy(pu => pu.IdRol).ToList();
                sesion.BioServer = IpBioServer;

                Sesion.ObjetoDeSesion = sesion;

                var empleados = _empleadoServicio.EncontrarPor(e => e.IdEmpleado == IdEmpleado);

                var bioServerEstatus = _usuarioServicio.ServicioActivo(string.Format(Settings.Default.BioServerAddress, Sesion.ObjetoDeSesion.BioServer));

                var empleadoExiste = empleados != null && empleados.Any();
                var empleadoPerteneceAlCentro = empleadoExiste && empleados.Any(e => e.Centro.IdCentro == IdCentro);

                if (!empleadoExiste)
                {
                    Mensaje = MENSAJE_EMPLEADO_NO_EXISTE;
                }
                else if (!empleadoPerteneceAlCentro)
                {
                    Mensaje = MENSAJE_EMPLEADO_NO_PERTENECE_AL_CENTRO;
                }

                if (bioServerEstatus == HttpStatusCode.OK)
                {
                    Mensaje = MENSAJE_DATOS_CORRECTOS;
                    var json = new JavaScriptSerializer().Serialize(Sesion.ObjetoDeSesion);
                    _sesionBase64 = CodificadorBase64.CodificarABase64(json);
                    MostrarBotonGuardar = true;
                }
                else
                {
                    Mensaje = MENSAJE_BIOSERVER_NO_RESPONDE;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains(ERROR_CREDENCIALES_INVALIDAS))
                {
                    Mensaje = MENSAJE_CREDENCIALES_INVALIDAS;
                }
                else
                {
                    Mensaje = MENSAJE_ERROR_DESCONOCIDO;
                }
            }
        }

        private void GuardarDatos()
        {
            XmlDocument XmlDoc = new XmlDocument();

            XmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            foreach (XmlElement xElement in XmlDoc.DocumentElement)
            {
                if (xElement.Name == "applicationSettings")
                {
                    foreach (XmlNode xNode in xElement.ChildNodes[0])
                    {
                        if (xNode.Attributes[0].Value == "DatosDeConfiguracion")
                        {
                            xNode.ChildNodes[0].InnerText = _sesionBase64;
                        }
                    }
                }
            }
            XmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            MessageBox.Show(MENSAJE_DATOS_GUARDADOS_CORRECTAMENTE, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Restart();
            App.Current.Shutdown();        
        }

        public static bool RealizarPing(string ip, int timeout)
        {
            try
            {
                PingReply reply = null;

                using (var ping = new Ping())
                {
                    reply = ping.Send(ip, timeout);

                    return reply.Status == IPStatus.Success;
                }
            }
            catch
            {
                return false;
            }
        }


        public static string ExtraerDominio(string Url)
        {
            if (!Url.Contains("://"))
                Url = "http://" + Url;

            return new Uri(Url).Host;
        }
        #endregion
    }
}
