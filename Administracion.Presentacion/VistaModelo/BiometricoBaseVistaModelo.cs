using Administracion.Contratos;
using Administracion.OTD;
using Administracion.Presentacion.Utilidades;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace Administracion.Presentacion.VistaModelo
{
    public class BiometricoBaseVistaModelo : ViewModelBase, IBiometricoBaseVistaModelo
    {
        #region Miembros Privados

        private bool _busquedaPersonaVisible;
        private bool _capturaBiometricaVisible;
        private PersonaFiltroOtd _filtro;

        #endregion Miembros Privados

        public BiometricoBaseVistaModelo()
        {
            InicializarObjetos();
            RegistrarSuscripciones();
        }

        #region Propiedades

        public bool BusquedaPersonaVisible
        {
            get
            {
                return _busquedaPersonaVisible;
            }
            set
            {
                _busquedaPersonaVisible = value;
                RaisePropertyChanged("BusquedaPersonaVisible");
            }
        }

        public bool CapturaBiometricaVisible
        {
            get
            {
                return _capturaBiometricaVisible;
            }
            set
            {
                _capturaBiometricaVisible = value;
                RaisePropertyChanged("CapturaBiometricaVisible");
            }
        }

        public string Anio { get; set; }

        public string ImputadoId { get; set; }

        public PersonaFiltroOtd Filtro
        {
            get
            {
                return _filtro;
            }
            set
            {
                _filtro = value;
                RaisePropertyChanged("Filtro");
            }
        }

        #endregion Propiedades

        #region Commands

        public RelayCommand<KeyEventArgs> BuscarKeyUpCommand
        {
            get
            {
                return new RelayCommand<KeyEventArgs>((e) =>
                {
                    if (e.Key == Key.Enter)
                    {
                        BuscarPersonas();
                    }
                });
            }
        }

        public RelayCommand BuscarPersonaCommand
        {
            get
            {
                return new RelayCommand(BuscarPersonas);
            }
        }

        #endregion Commands

        #region Metodos Privados

        private void BuscarPersonas()
        {
            if (Filtro != null)
            {
                Filtro.Folio = Filtro.EsImputado ? string.Format("{0} / {1}", Anio, ImputadoId) : string.Empty;

                Mensajero.EnviarMensaje<PersonaFiltroOtd>(Filtro);

                if (!BusquedaPersonaVisible)
                {
                    MostrarOcultarControloes();
                }
            }
        }

        private void InicializarObjetos()
        {
            Filtro = new PersonaFiltroOtd { EsImputado = true };
            BusquedaPersonaVisible = true;
        }

        private void MostrarOcultarControloes()
        {
            CapturaBiometricaVisible = CapturaBiometricaVisible ? false : true;
            BusquedaPersonaVisible = BusquedaPersonaVisible ? false : true;
        }

        private void RegistrarSuscripciones()
        {
            Mensajero.RegistrarSuscripcion<PersonaOtd>(this, (mensaje) => { if (mensaje != null) { MostrarOcultarControloes(); } });
            Mensajero.RegistrarSuscripcion<bool>(this, (mensaje) => { if (mensaje) { MostrarOcultarControloes(); } });
        }

        #endregion Metodos Privados
    }
}