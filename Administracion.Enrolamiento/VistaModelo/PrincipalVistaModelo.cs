using Administracion.Contratos;
using Administracion.Contratos.Enrolamiento;
using Administracion.Contratos.Servicios;
using Administracion.Enrolamiento.Properties;
using Administracion.Enum;
using Administracion.OTD;
using Administracion.Utilidades.Autenticacion;
using Administracion.Utilidades.Constantes;
using Administracion.Utilidades.Controles;
using Fulcrum.FbF.ClientControl.Enumerations;
using Fulcrum.FbF.Messaging;
using Fulcrum.FbF.WPF.ClientControl;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading;

namespace Administracion.Enrolamiento.VistaModelo
{
    public class PrincipalVistaModelo : ViewModelBase, IPrincipalVistaModelo
    {
        #region Miembros privados

        private bool _botonEnrolarActivo;
        private int _centroId;
        private string _contrasenaBD;
        private BiometricControl _controlBiometrico;
        private bool _esIndeterminado;
        private UIColeccion<string> _mensajes;
        private bool _mostrarProgreso;
        private List<PersonaOtd> _personas;
        private IPersonaServicio _personaServicio;
        private double _progresoActual;
        private string _progresoMensaje;
        private string _servidorBD;
        private string _servidorBiometrico;
        private BioServerStatuses _estatusBioServer;
        private int _totalPersonas;
        private string _usuarioBD;
        private IUsuarioServicio _usuarioServicio;
        private BackgroundWorker _worker;
        private List<string> _foliosProcesados;
        private bool _logsCambiaron;

        #endregion Miembros privados

        public PrincipalVistaModelo(IUsuarioServicio usuarioServicio, IPersonaServicio personaServicio)
        {
            _usuarioServicio = usuarioServicio;
            _personaServicio = personaServicio;
            Sesion.ObjetoDeSesion = new SesionOtd();
            _botonEnrolarActivo = true;
            ControlBiometrico = new BiometricControl();
            _foliosProcesados = new List<string>();
        }

        #region Propiedades

        public bool BotonEnrolarActivo
        {
            get
            {
                return _botonEnrolarActivo;
            }
            set
            {
                _botonEnrolarActivo = value;
                RaisePropertyChanged("BotonEnrolarActivo");
            }
        }

        public int CentroId
        {
            get
            {
                return _centroId;
            }
            set
            {
                _centroId = value;
                RaisePropertyChanged("CentroId");
            }
        }

        public string ContrasenaBD
        {
            get
            {
                return _contrasenaBD;
            }
            set
            {
                _contrasenaBD = value;
                RaisePropertyChanged("ContrasenaBD");
            }
        }

        public BiometricControl ControlBiometrico
        {
            get
            {
                return _controlBiometrico;
            }
            set
            {
                _controlBiometrico = value;
                RaisePropertyChanged("ControlBiometrico");
            }
        }

        public bool EsIndeterminado
        {
            get
            {
                return _esIndeterminado;
            }
            set
            {
                _esIndeterminado = value;
                RaisePropertyChanged("EsIndeterminado");
            }
        }

        public UIColeccion<string> Mensajes
        {
            get
            {
                return _mensajes;
            }
            set
            {
                _mensajes = value;
                RaisePropertyChanged("Mensajes");
                LogsCambiaron = true;
            }
        }

        public bool MostrarProgreso
        {
            get
            {
                return _mostrarProgreso;
            }
            set
            {
                _mostrarProgreso = value;
                RaisePropertyChanged("MostrarProgreso");
            }
        }

        public double ProgresoActual
        {
            get
            {
                return _progresoActual;
            }
            set
            {
                if (_progresoActual != value)
                {
                    _progresoActual = value;
                    RaisePropertyChanged("ProgresoActual");
                }
            }
        }

        public string ProgresoMensaje
        {
            get
            {
                return _progresoMensaje;
            }
            set
            {
                _progresoMensaje = value;
                RaisePropertyChanged("ProgresoMensaje");
            }
        }

        public string ServidorBD
        {
            get
            {
                return _servidorBD;
            }
            set
            {
                _servidorBD = value;
                RaisePropertyChanged("ServidorBD");
            }
        }

        public string ServidorBiometrico
        {
            get
            {
                return _servidorBiometrico;
            }
            set
            {
                _servidorBiometrico = value;
                RaisePropertyChanged("ServidorBiometrico");
            }
        }

        public int TotalPersonas
        {
            get
            {
                return _totalPersonas;
            }
            set
            {
                _totalPersonas = value;
                RaisePropertyChanged("TotalPersonas");
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

        private Notificacion Notificacion { get; set; }

        public bool LogsCambiaron
        {
            get
            {
                return _logsCambiaron;
            }
            set
            {
                _logsCambiaron = value;
                RaisePropertyChanged("LogsCambiaron");
            }
        }

        #endregion Propiedades

        #region Commands

        public RelayCommand EnrolarCommand
        {
            get
            {
                return new RelayCommand(IniciarHiloDeEnrolamiento);
            }
        }

        #endregion Commands

        #region Metodos Privados

        private void BuscarPersonas()
        {
            _worker.ReportProgress(0, new Notificacion()
            {
                Tipo = TipoNotificacion.Buscando,
                Mensaje = Constantes.BUSCANDO_PERSONAS
            });

            _personas = new List<PersonaOtd>();
            var filtro = new PersonaFiltroOtd
            {
                IdCentro = (short)CentroId,
                EsImputado = true,
                FiltrarSoloEnrolados = true
            };

            var imputados = _personaServicio.BuscarPersonaPorFiltro(filtro);

            if (imputados != null && imputados.Count > 0)
            {
                _personas.AddRange(imputados);
            }

            filtro.EsImputado = false;
            var custodios = _personaServicio.BuscarPersonaPorFiltro(filtro);

            if (custodios != null && custodios.Count > 0)
            {
                _personas.AddRange(custodios);
            }

            _personas = _personas.OrderBy(p => p.Id).ToList();
        }

        private void CambioEnElProceso(object sender, ProgressChangedEventArgs e)
        {
            Notificacion notificacion = e.UserState as Notificacion;

            switch (notificacion.Tipo)
            {
                case TipoNotificacion.Validando:
                case TipoNotificacion.Buscando:
                case TipoNotificacion.Conectando:
                    EsIndeterminado = true;
                    ProgresoMensaje = notificacion.Mensaje;
                    break;

                case TipoNotificacion.Enrolando:
                    EsIndeterminado = false;
                    Notificacion = notificacion;
                    ProgresoActual = e.ProgressPercentage;
                    ProgresoMensaje = string.Format("{0} de {1}", notificacion.TotalCompletado, _personas.Count);
                    break;

                case TipoNotificacion.Error:
                case TipoNotificacion.Compleado:
                    Mensajes.Add(notificacion.Mensaje);
                    break;
            }
        }

        private void EnrolarBiometrias(BiometricControl controlBiometrico)
        {
            if (_personas != null && _personas.Count > 0 && _estatusBioServer == BioServerStatuses.Connected)
            {
                for (int i = 0; i < _personas.Count; i++)
                {
                    var persona = _personas[i];
                    List<FbFBioResult> bioResults = new List<FbFBioResult>();

                    var porcentaje = (i * 100) / _personas.Count;
                    var folio = string.Format(SSPConst.EnrolIdPersona, persona.IdAnio, persona.Id, persona.IdIngreso);

                    if (persona.Biometricos.Any(b => b.Tipo == TipoBiometrico.OjoDerecho))
                    {
                        bioResults.Add(ObtenerBioResultPorIris(persona, TipoBiometrico.OjoDerecho));
                    }

                    if (persona.Biometricos.Any(b => b.Tipo == TipoBiometrico.OjoIzquierdo))
                    {
                        bioResults.Add(ObtenerBioResultPorIris(persona, TipoBiometrico.OjoIzquierdo));
                    }

                    if (bioResults.Count > 0)
                    {
                        _worker.ReportProgress(porcentaje, new Notificacion() { Tipo = TipoNotificacion.Enrolando, TotalCompletado = i, BioResults = bioResults, Persona = persona, Folio = folio });
                        _controlBiometrico.IdentifyAsync(bioResults);
                        Thread.Sleep(1000);
                    }
                }

                _worker.ReportProgress(0, new Notificacion() { Tipo = TipoNotificacion.Compleado, Mensaje = Constantes.ENROLAMIENTO_COMPLETADO });
            }
        }

        private void IniciarHiloDeEnrolamiento()
        {
            Mensajes = Convertidor.ConvertirLista<string>(null);
            BotonEnrolarActivo = false;
            MostrarProgreso = true;
            _worker = new BackgroundWorker();
            _worker.WorkerReportsProgress = true;
            _worker.DoWork += IniciarProcesoDeEnrolamiento;
            _worker.ProgressChanged += new ProgressChangedEventHandler(CambioEnElProceso);
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ProcesoCompletado);
            _worker.RunWorkerAsync(ControlBiometrico);
        }

        private void IniciarProcesoDeEnrolamiento(object sender, DoWorkEventArgs e)
        {
            try
            {
                var controlBiometrico = e.Argument as BiometricControl;

                bool baseDeDatosValida = ValidarConexionBD();
                HttpStatusCode servidorBiometricoEstatus = ValidarServidorBiometrico(controlBiometrico);

                if (CentroId <= 0)
                {
                    Mensajes.Add(Constantes.CENTRO_REQUERIDO);
                }

                if (!baseDeDatosValida)
                {
                    Mensajes.Add(Constantes.CONEXION_BD_FALLIDA);
                }

                if (servidorBiometricoEstatus == HttpStatusCode.NotFound)
                {
                    Mensajes.Add(string.Format(Constantes.BIOSERVER_NO_ENCONTRADO, Sesion.ObjetoDeSesion.BioServer));
                }

                if (_estatusBioServer != BioServerStatuses.Connected)
                {
                    Mensajes.Add(Constantes.BIOSERVER_NO_CONECTADO);
                }

                if (Mensajes.Count <= 0)
                {
                    BuscarPersonas();

                    if (_personas != null && _personas.Count > 0)
                    {
                        EnrolarBiometrias(controlBiometrico);
                    }
                    else
                    {
                        Mensajes.Add(Constantes.NO_HAY_PERSONAS);
                    }
                }
            }
            catch (Exception ex)
            {
                _worker.ReportProgress(0, new Notificacion() { Tipo = TipoNotificacion.Error, Mensaje = string.Format(Constantes.ERROR, ex.Message) });
            }
        }

        private FbFBioResult ObtenerBioResultPorIris(PersonaOtd persona, TipoBiometrico tipoIris)
        {
            var bioLocation = tipoIris == TipoBiometrico.OjoDerecho ? FbFBioLocations.RightIris : FbFBioLocations.LeftIris;

            return new FbFBioResult
                    {
                        BioLocation = bioLocation,
                        Templates = new List<FbFBioTemplate>
                            {
                                new FbFBioTemplate
                                {
                                    Template = persona.Biometricos.FirstOrDefault(b => b.Tipo == tipoIris).Biometrico,
                                    Type = FbFTemplateTypes.MMStandard
                                }
                            }
                    };
        }

        private void ProcesoCompletado(object sender, RunWorkerCompletedEventArgs e)
        {
            MostrarProgreso = false;
            BotonEnrolarActivo = true;
            ControlBiometrico.OnBioServerStatus -= new BiometricControl.OnBioServerStatuses(controlBiometrico_OnBioServerStatus);
            _personas = new List<PersonaOtd>();
            _foliosProcesados = new List<string>();
        }

        private bool ValidarConexionBD()
        {
            _worker.ReportProgress(0, new Notificacion()
            {
                Tipo = TipoNotificacion.Validando,
                Mensaje = Constantes.VALIDANDO_BD
            });

            string conexion = string.Format(Settings.Default.BDConexion, ServidorBD, ContrasenaBD, UsuarioBD);
            bool baseDeDatosValida = _usuarioServicio.ConexionValida(conexion);
            Sesion.ObjetoDeSesion.Conexion = conexion;
            return baseDeDatosValida;
        }

        private HttpStatusCode ValidarServidorBiometrico(BiometricControl controlBiometrico)
        {
            _worker.ReportProgress(0, new Notificacion()
            {
                Tipo = TipoNotificacion.Validando,
                Mensaje = Constantes.VALIDANDO_BIOSERVER
            });

            string servidorBiometrico = string.Format(Settings.Default.BioServerAddress, ServidorBiometrico);
            HttpStatusCode servidorBiometricoEstatus = _usuarioServicio.ServicioActivo(servidorBiometrico);
            Sesion.ObjetoDeSesion.BioServer = servidorBiometrico;

            ConectarServidorBiometrico(controlBiometrico);

            return servidorBiometricoEstatus;
        }

        #endregion Metodos Privados

        #region Fulcrum Configuracion

        private void ConectarServidorBiometrico(BiometricControl controlBiometrico)
        {
            _worker.ReportProgress(0, new Notificacion()
            {
                Tipo = TipoNotificacion.Conectando,
                Mensaje = Constantes.CONECTANDO_BIOSERVER
            });

            controlBiometrico.BioServerAddress = string.Format(Settings.Default.BioServerAddress, ServidorBiometrico);
            controlBiometrico.BiometricMode = ControlModes.Identification;
            controlBiometrico.BioLocation = FbFBioLocations.UnknownIris;
            _controlBiometrico.ImageTypes = FbFImageTypes.RefreshJPG;
            _controlBiometrico.DisplayImageType = FbFImageTypes.RefreshJPG;
            _controlBiometrico.TemplateTypes = FbFTemplateTypes.MMStandard;
            _controlBiometrico.ScanningActionType = FbFActions.Snap;

            controlBiometrico.OnBioServerStatus += new BiometricControl.OnBioServerStatuses(controlBiometrico_OnBioServerStatus);
            controlBiometrico.OnIdentificationComplete += new BiometricControl.BooleanAsyncHandler(controlBiometrico_OnIdentificationComplete);
            _controlBiometrico.OnEnrollmentComplete += new BiometricControl.BooleanAsyncHandler(controlBiometrico_OnEnrollmentComplete);

            controlBiometrico.ConnectToBioServer();
            Thread.Sleep(2000);
        }

        private void controlBiometrico_OnBioServerStatus(object sender, BioServerStatuses estatus)
        {
            _estatusBioServer = estatus;
        }

        private void controlBiometrico_OnIdentificationComplete(object sender, bool identificado)
        {
            if (!_foliosProcesados.Contains(Notificacion.Folio))
            {
                _foliosProcesados.Add(Notificacion.Folio);

                if (!identificado)
                {
                    _controlBiometrico.EnrollAsync(Notificacion.BioResults, Notificacion.Folio);
                }
                else
                {
                    var mensaje = string.Format(Constantes.IDENTIFICADO,
                                             Notificacion.Persona.EsImputado ? "Imputado" : "Custodio",
                                             string.Format("{0} {1}", Notificacion.Persona.Apellidos, Notificacion.Persona.Nombre),
                                             Notificacion.Folio);

                    Mensajes.Add(mensaje);
                }
            }
        }

        private void controlBiometrico_OnEnrollmentComplete(object sender, bool enrolado)
        {
            if (enrolado)
            {
                var mensaje = string.Format(Constantes.ENROLADO,
                                           Notificacion.Persona.EsImputado ? "Imputado" : "Custodio",
                                           string.Format("{0} {1}", Notificacion.Persona.Apellidos, Notificacion.Persona.Nombre),
                                           Notificacion.Folio);

                Mensajes.Add(mensaje);
            }
        }

        #endregion Fulcrum Configuracion
    }
}