using Administracion.Contratos;
using Administracion.Enum;
using Administracion.OTD;
using Administracion.Presentacion.Controles;
using Administracion.Presentacion.Properties;
using Administracion.Presentacion.Utilidades;
using Administracion.Utilidades.Autenticacion;
using Administracion.Utilidades.Constantes;
using Fulcrum.FbF.ClientControl.Enumerations;
using Fulcrum.FbF.Messaging;
using Fulcrum.FbF.WPF.ClientControl;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Administracion.Presentacion.VistaModelo
{
    public class CapturaBiometricoVistaModelo : ViewModelBase, ICapturaBiometricoVistaModelo
    {
        private BiometricControl _controlBiometrico;
        private ImageSource _foto;
        private PersonaOtd _persona;
        private PersonaOtd _personaEncontrada;
        private bool _personaIdentificada;
        private IPersonaServicio _personaServicio;
        private bool _biometriaGuardada;
        private bool _enrolado;
        private bool _recapturarBiometria;
        private bool _activarEnrolarBoton;
        private bool _bioServerCambioEstatus;

        public CapturaBiometricoVistaModelo(IPersonaServicio personaServicio)
        {
            _personaServicio = personaServicio;
            RegistrarSuscripciones();
            Microsoft.Win32.SystemEvents.SessionSwitch += new Microsoft.Win32.SessionSwitchEventHandler(InterupcionesDeEventos);
        }

        #region Propiedades

        public List<FbFBioResult> BiometricosTemporales
        {
            get;
            set;
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

        public ImageSource Foto
        {
            get
            {
                return _foto;
            }
            set
            {
                _foto = value;
                RaisePropertyChanged("Foto");
            }
        }

        public PersonaOtd Persona
        {
            get
            {
                return _persona;
            }
            set
            {
                _persona = value;
                RaisePropertyChanged("Persona");
            }
        }

        public PersonaOtd PersonaEncontrada
        {
            get
            {
                return _personaEncontrada;
            }
            set
            {
                _personaEncontrada = value;
                RaisePropertyChanged("PersonaEncontrada");
            }
        }

        public bool PersonaIdentificada
        {
            get
            {
                return _personaIdentificada;
            }
            set
            {
                Persona.FueIdentificado = value;
                _personaIdentificada = value;
                RaisePropertyChanged("PersonaIdentificada");
            }
        }

        public bool BiometriaGuardada
        {
            get
            {
                return _biometriaGuardada;
            }
            set
            {
                _biometriaGuardada = value;
                RaisePropertyChanged("BiometriaGuardada");
            }
        }

        public bool RecapturarBiometria
        {
            get
            {
                return _recapturarBiometria;
            }
            set
            {
                _recapturarBiometria = value;
                RaisePropertyChanged("RecapturarBiometria");
                ActivarEnrolarBoton = value;
            }
        }

        public bool ActivarEnrolarBoton
        {
            get
            {
                return _activarEnrolarBoton;
            }
            set
            {
                _activarEnrolarBoton = value;
                RaisePropertyChanged("ActivarEnrolarBoton");
            }
        }

        #endregion Propiedades

        #region Commands

        public RelayCommand CancelarCommand
        {
            get
            {
                return new RelayCommand(Cancelar);
            }
        }

        public RelayCommand CapturarIrisCommand
        {
            get
            {
                return new RelayCommand(EscanearIris);
            }
        }

        #endregion Commands

        #region Metodos Privados

        private void AsignarPersonaSeleccionada(PersonaOtd persona)
        {
            if (persona != null)
            {
                if (persona.Biometricos == null)
                {
                    persona.Biometricos = new List<BiometricoOtd>();
                }

                Persona = persona;
                ActivarEnrolarBoton = !persona.BiometriaRegistrada;
            }
        }

        private void Cancelar()
        {
            InicializarObjetos();

            if (_controlBiometrico != null)
            {
                _controlBiometrico.CleanImage();
            }

            Mensajero.EnviarMensaje<bool>(true);
        }

        private void InicializarObjetos()
        {
            Persona = new PersonaOtd { Biometricos = new List<BiometricoOtd>() };
            PersonaEncontrada = new PersonaOtd();
            BiometricosTemporales = new List<FbFBioResult>();
            PersonaIdentificada = false;
            BiometriaGuardada = false;
            _enrolado = false;
            RecapturarBiometria = false;
        }

        private void RegistrarSuscripciones()
        {
            Mensajero.RegistrarSuscripcion<PersonaOtd>(this, AsignarPersonaSeleccionada);
        }

        #endregion Metodos Privados

        #region Fulcrum Configuracion


        private void controlBiometrico_OnError(object sender, FbFBioResult result, string message)
        {
            MessageBox.Show(message, "FbF Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EscanearIris()
        {
            LoadingPantalla.Ejecutar(Sesion.PantallaPrincipal, SSPConst.ConectandoMsg, () =>
            {
                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    ControlBiometrico = new BiometricControl();

                    _bioServerCambioEstatus = false;

                    if (!_controlBiometrico.IsConnectedWithListener)
                        _controlBiometrico.ConnectWithListener();

                    ConfigurarEscaneo();

                    _controlBiometrico.ConnectToBioServer();
                    _controlBiometrico.StartScanning();

                    ActivarEnrolarBoton = false;
                });
            });
        }

        private void ConfigurarEscaneo()
        {
            _controlBiometrico.BioServerAddress = string.Format(Settings.Default.BioServerAddress, Sesion.ObjetoDeSesion.BioServer);
            _controlBiometrico.BioLocation = FbFBioLocations.UnknownIris;
            _controlBiometrico.ImageTypes = FbFImageTypes.RefreshJPG;
            _controlBiometrico.DisplayImageType = FbFImageTypes.RefreshJPG;
            _controlBiometrico.TemplateTypes = FbFTemplateTypes.MMStandard;
            _controlBiometrico.ScanningActionType = FbFActions.Snap;
            _controlBiometrico.StreamResponseRequired = true;
            _controlBiometrico.PersonId = string.Format(SSPConst.EnrolIdPersona, Persona.IdAnio, Persona.Id, Persona.IdIngreso);
            _controlBiometrico.AutoIdentifyBeforeEnroll = false;

            _controlBiometrico.OnBioServerStatus += new BiometricControl.OnBioServerStatuses(controlBiometrico_OnBioServerStatus);
            _controlBiometrico.OnEnrollmentComplete += new BiometricControl.BooleanAsyncHandler(controlBiometrico_OnEnrollmentComplete);
            _controlBiometrico.OnIdentified += new BiometricControl.OnIdentifiedHandler(controlBiometrico_OnIdentified);
            _controlBiometrico.OnIdentificationComplete += new BiometricControl.BooleanAsyncHandler(controlBiometrico_OnIdentificationComplete);
            _controlBiometrico.OnSuccessResult += new BiometricControl.OnResultHandler(controlBiometrico_OnSuccessResult);
            _controlBiometrico.OnDeleteComplete += new BiometricControl.BooleanAsyncHandler(controlBiometrico_OnDeleteComplete);

            _controlBiometrico.OnError += new BiometricControl.OnErrorHandler(controlBiometrico_OnError);
        }

        private void controlBiometrico_OnEnrollmentComplete(object sender, bool success)
        {
            DispatcherHelper.CheckBeginInvokeOnUI(() =>
               {
                   if (success && !BiometriaGuardada)
                   {
                       Action accion = () =>
                           {
                               BiometriaGuardada = _personaServicio.AsignarBiometria(Persona);
                               Mensajero.EnviarMensaje<string>(Persona.Folio);
                           };

                       LoadingPantalla.Ejecutar(Sesion.PantallaPrincipal, SSPConst.GuardandoMsg, accion);
                   }
               });
        }

        private void controlBiometrico_OnIdentificationComplete(object sender, bool identificado)
        {
            if (!identificado && !Persona.FueIdentificado && !_enrolado)
            {
                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                   {
                       Action accion = () =>
                           {
                               foreach (var biometricos in BiometricosTemporales)
                               {
                                   var plantillaBiometrica = biometricos.Templates[0];

                                   if (plantillaBiometrica != null && (biometricos.BioLocation == FbFBioLocations.LeftIris || biometricos.BioLocation == FbFBioLocations.RightIris))
                                   {
                                       BiometricoOtd biometrico = new BiometricoOtd();
                                       biometrico.Tipo = biometricos.BioLocation == FbFBioLocations.LeftIris ? TipoBiometrico.OjoIzquierdo : TipoBiometrico.OjoDerecho;
                                       biometrico.Biometrico = plantillaBiometrica.Template;
                                       biometrico.Formato = FormatoBiometrico.BMP;

                                       Persona.Biometricos.Add(biometrico);
                                   }
                               }

                               _controlBiometrico.BiometricMode = ControlModes.Enrollment;

                               _enrolado = _controlBiometrico.EnrollAsync(BiometricosTemporales, string.Format(SSPConst.EnrolIdPersona, Persona.IdAnio, Persona.Id, Persona.IdIngreso));
                           };

                       LoadingPantalla.Ejecutar(Sesion.PantallaPrincipal, SSPConst.EnrolandoMsg, accion);
                   });
            }
        }

        private void controlBiometrico_OnIdentified(object sender, string idPersona, int matchscore)
        {
            DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    if (!string.IsNullOrWhiteSpace(idPersona) && !PersonaIdentificada)
                    {
                        Action accion = () =>
                            {
                                PersonaIdentificada = true;
                                var personas = _personaServicio.BuscarPersonaPorFiltro(
                                    new PersonaFiltroOtd
                                    {
                                        EsImputado = Persona.EsImputado,
                                        Folio = idPersona,
                                    });

                                if (personas != null && personas.Count > 0)
                                {
                                    PersonaEncontrada = personas.OrderBy(p => p.IdIngreso).LastOrDefault();
                                }
                            };

                        LoadingPantalla.Ejecutar(Sesion.PantallaPrincipal, SSPConst.ValidandoMsg, accion);
                    }
                });
        }

        private void controlBiometrico_OnSuccessResult(object sender, List<FbFBioResult> resultados, FbFResponseStatuses estatus)
        {
            DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    if (estatus == FbFResponseStatuses.Success && (BiometricosTemporales == null || BiometricosTemporales.Count <= 0))
                    {
                        _controlBiometrico.StopScanning();
                        BiometricosTemporales = resultados;

                        if (RecapturarBiometria)
                        {
                            Action accion = () =>
                            {
                                _personaServicio.RemoverBiometrias(Persona);
                                _controlBiometrico.DeleteAsync(_controlBiometrico.BioLocation, string.Format(SSPConst.EnrolIdPersona, Persona.IdAnio, Persona.Id, Persona.IdIngreso));
                            };

                            LoadingPantalla.Ejecutar(Sesion.PantallaPrincipal, SSPConst.RemoviendoMsg, accion);
                        }
                        else
                        {
                            _controlBiometrico.BiometricMode = ControlModes.Identification;
                            _controlBiometrico.IdentifyAsync(resultados);
                        }
                    }
                });
        }

        private void controlBiometrico_OnDeleteComplete(object sender, bool completado)
        {
            if (completado)
            {
                _enrolado = _controlBiometrico.EnrollAsync(BiometricosTemporales, string.Format(SSPConst.EnrolIdPersona, Persona.IdAnio, Persona.Id, Persona.IdIngreso));
            }
        }

        private void controlBiometrico_OnBioServerStatus(object sender, BioServerStatuses estatus)
        {
            if (!_bioServerCambioEstatus)
            {
                switch (estatus)
                {
                    case BioServerStatuses.NotConnected:
                        MessageBox.Show(SSPConst.BioServerNoConectadoMsg, "Error");
                        break;
                    case BioServerStatuses.InvalidEndPoint:
                        MessageBox.Show(SSPConst.BioServerSinServicio, "Error");
                        break;
                }
            }

            _bioServerCambioEstatus = true;
        }

        void InterupcionesDeEventos(object sender, Microsoft.Win32.SessionSwitchEventArgs e)
        {
            switch (e.Reason)
            {
                case Microsoft.Win32.SessionSwitchReason.ConsoleConnect:
                    _controlBiometrico.ConnectWithListener();
                    break;

                case Microsoft.Win32.SessionSwitchReason.ConsoleDisconnect:
                    _controlBiometrico.StopScanning();
                    if (_controlBiometrico.IsConnectedWithListener)
                        _controlBiometrico.DisconnectFromListener();
                    break;
            }
        }

        #endregion Fulcrum Configuracion
    }
}