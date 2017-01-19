using Administracion.Contratos;
using Administracion.OTD;
using Administracion.Presentacion.Controles;
using Administracion.Presentacion.Utilidades;
using Administracion.Utilidades.Autenticacion;
using Administracion.Utilidades.Constantes;
using Administracion.Utilidades.Controles;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;

namespace Administracion.Presentacion.VistaModelo
{
    public class BusquedaPersonaVistaModelo : ViewModelBase, IBusquedaPersonaVistaModelo
    {
        #region Miembros Privados

        private string _busquedaMsg;
        private bool _ocultarMensaje;
        private ObservableCollection<PersonaOtd> _personas;
        private PersonaOtd _personaSeleccionada;
        private IPersonaServicio _personaServicio;

        #endregion Miembros Privados

        public BusquedaPersonaVistaModelo(IPersonaServicio personaServicio)
        {
            _personaServicio = personaServicio;
            RegistrarSuscripciones();
            InicializarObjetos();
        }

        #region Propiedades

        public string BusquedaMensaje
        {
            get
            {
                return _busquedaMsg;
            }
            set
            {
                _busquedaMsg = value;
                RaisePropertyChanged("BusquedaMensaje");
            }
        }

        public bool MostrarMensaje
        {
            get
            {
                return _ocultarMensaje;
            }
            set
            {
                _ocultarMensaje = value;
                RaisePropertyChanged("MostrarMensaje");
            }
        }

        public ObservableCollection<PersonaOtd> Personas
        {
            get
            {
                return _personas;
            }
            set
            {
                _personas = value;
                RaisePropertyChanged("Personas");
            }
        }

        public PersonaOtd PersonaSeleccionada
        {
            get
            {
                return _personaSeleccionada;
            }
            set
            {
                _personaSeleccionada = value;
                RaisePropertyChanged("PersonaSeleccionada");
            }
        }

        #endregion Propiedades

        #region Commands

        public RelayCommand SeleccionarPersonaCommand
        {
            get
            {
                return new RelayCommand(SeleccionarPersona);
            }
        }

        #endregion Commands

        #region Metodos Publicos

        public void BuscarPersonaPorFiltro(PersonaFiltroOtd filtro)
        {
            Action accion = () => BuscarPersona(filtro);
            LoadingPantalla.Ejecutar(Sesion.PantallaPrincipal, SSPConst.BuscandoMsg, accion);
        }

        #endregion Metodos Publicos

        #region Metodos Privados

        private void InicializarObjetos()
        {
            _personaSeleccionada = new PersonaOtd();
            BusquedaMensaje = SSPConst.BusquedaMsjInicial;
            MostrarMensaje = true;
        }

        private void RegistrarSuscripciones()
        {
            Mensajero.RegistrarSuscripcion<PersonaFiltroOtd>(this, BuscarPersonaPorFiltro);

            Mensajero.RegistrarSuscripcion<string>(this, ActualizarPersona);
        }

        private void SeleccionarPersona()
        {
            Mensajero.EnviarMensaje<PersonaOtd>(PersonaSeleccionada);
        }

        private void BuscarPersona(PersonaFiltroOtd filtro)
        {
            filtro.IdCentro = Sesion.ObjetoDeSesion.IdCentro;
            Personas = Convertidor.ConvertirLista(_personaServicio.BuscarPersonaPorFiltro(filtro));
            MostrarMensaje = false;

            if (Personas.Count < 1)
            {
                BusquedaMensaje = SSPConst.BusquedaMsjNoResultados;
                MostrarMensaje = true;
            }
        }

        private void ActualizarPersona(string folio)
        {
            for (var i = 0; i < Personas.Count; i++)
            {
                if (string.Equals(Personas[i].Folio, folio))
                {
                    PersonaSeleccionada.BiometriaRegistrada = true;
                    Personas[i] = PersonaSeleccionada;
                    break;
                }
            }
        }

        #endregion Metodos Privados
    }
}