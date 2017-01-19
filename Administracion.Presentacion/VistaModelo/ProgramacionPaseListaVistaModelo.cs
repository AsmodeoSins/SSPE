using Administracion.Contratos;
using Administracion.Contratos.Servicios;
using Administracion.Enum;
using Administracion.OTD;
using Administracion.Presentacion.Controles;
using Administracion.Presentacion.Utilidades;
using Administracion.Utilidades.Autenticacion;
using Administracion.Utilidades.ClasesAuxiliares;
using Administracion.Utilidades.Constantes;
using Administracion.Utilidades.Controles;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace Administracion.Presentacion.VistaModelo
{
    /// <summary>
    /// Vista modelo para la pantallla de pases de lista programados
    /// </summary>
    public class ProgramacionPaseListaVistaModelo : ViewModelBase, IProgramacionPaseListaVistaModelo
    {
        #region Miembros privados

        private IPLCatalogoServicio _paseListaCatalogoServicio;
        private IPaseListaServicio _paseListaServicio;
        private IPersonaServicio _personaServicio;

        private UIColeccion<PersonaOtd> _custodios;
        private UIColeccion<PaseListaOtd> _pasesDelista;
        private UIColeccion<PaseListaOtd> _pasesDeListaOriginales;

        private PaseListaOtd _paseLista;
        private string _errores;
        ICollectionView _asignacionesVista;
        IList<PLCatalogoOtd> _tiposPaseDeLista;
        private bool _datosCargados;
        private DateTime _fechaProgramacion;

        #endregion Miembros privados

        #region Constructores

        /// <summary>
        /// Constructor principal
        /// </summary>
        /// <param name="paseListaCatalogoServicio"></param>
        /// <param name="paseListaServicio"></param>
        /// <param name="personaServicio"></param>
        public ProgramacionPaseListaVistaModelo(IPLCatalogoServicio paseListaCatalogoServicio, IPaseListaServicio paseListaServicio, IPersonaServicio personaServicio)
        {
            _paseListaCatalogoServicio = paseListaCatalogoServicio;
            _paseListaServicio = paseListaServicio;
            _personaServicio = personaServicio;
            RegistrarSubscripciones();
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Pases de lista disponibles
        /// </summary>
        public UIColeccion<PaseListaOtd> PasesDeLista
        {
            get
            {
                return _pasesDelista;
            }
            set
            {
                _pasesDelista = value;
                RaisePropertyChanged("PasesDeLista");
            }
        }

        /// <summary>
        /// Custodios disponibles para el centro actual
        /// </summary>
        public UIColeccion<PersonaOtd> Custodios
        {
            get
            {
                return _custodios;
            }
            set
            {
                _custodios = value;
                RaisePropertyChanged("Custodios");
            }
        }

        /// <summary>
        /// Pase de lista actualmente seleccionado por el usuario
        /// </summary>
        public PaseListaOtd PaseLista
        {
            get
            {
                return _paseLista;
            }
            set
            {
                _paseLista = value;
                RaisePropertyChanged("PaseLista");
            }
        }

        /// <summary>
        /// Tipos de pase de lista disponibles para seleccion del usuario
        /// </summary>
        public IList<PLCatalogoOtd> TiposPaseLista
        {
            get
            {
                return _tiposPaseDeLista;
            }
            set
            {
                _tiposPaseDeLista = value;
                RaisePropertyChanged("TiposPaseLista");
            }
        }

        /// <summary>
        /// Indica si la asignacion se hara por nivel o individual
        /// </summary>
        public bool AsignacionPorNivel { get; set; }

        public string Errores
        {
            get
            {
                return _errores;
            }
            set
            {
                _errores = value;
                RaisePropertyChanged("Errores");
            }
        }

        /// <summary>
        /// Lista de las asignaciones presentadas en pantalla
        /// </summary>
        public ICollectionView AsignacionesVista
        {
            get
            {
                return _asignacionesVista;
            }
            set
            {
                _asignacionesVista = value;
                RaisePropertyChanged("AsignacionesVista");
            }
        }

        public DateTime FechaProgramacion
        {
            get
            {
                return _fechaProgramacion;
            }
            set
            {
                _fechaProgramacion = value;
                RaisePropertyChanged("FechaProgramacion");
            }
        }

        #endregion Propiedades

        #region Commands

        public RelayCommand GuardarPaseDeListaCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Action accion = () => GuardarPaseDeLista();
                    LoadingPantalla.Ejecutar(Sesion.PantallaPrincipal, SSPConst.GuardandoMsg, accion);
                });
            }
        }

        public RelayCommand<AsignacionOtd> CustodioCambiadoCommand
        {
            get
            {
                return new RelayCommand<AsignacionOtd>(CambiarAsignacion);
            }
        }

        public RelayCommand<PLCatalogoOtd> CambioPaseDeListaCommand
        {
            get
            {
                return new RelayCommand<PLCatalogoOtd>(CambioDePaseDeLista);
            }
        }

        public RelayCommand CancelarCommand
        {
            get
            {
                return new RelayCommand(Cancelar);
            }
        }

        #endregion Commands

        #region Metodos Privados

        private void GuardarPaseDeLista()
        {
            PaseLista.Asignaciones = AsignacionesVista.Cast<AsignacionOtd>().ToList();

            if (Validar())
            {
                var asignaciones = PaseLista.Asignaciones.Clonar();
                _paseListaServicio.GuardarPasesDeLista(PaseLista);
                PaseLista.Asignaciones = asignaciones;
                ActualizarLista();
            }
        }

        private void CargarDatos()
        {
            PasesDeLista = Convertidor.ConvertirLista(_paseListaServicio.InicializarPasesListaPorCentro(Sesion.ObjetoDeSesion.IdCentro));
            _pasesDeListaOriginales = PasesDeLista;
            PaseLista = PasesDeLista.First().Clonar();

            var custodios = _personaServicio.TraerCustodiosParaPaseLista();
            custodios.Insert(0, new PersonaOtd { Id = 0, Nombre = "Seleccione" });

            _custodios = Convertidor.ConvertirLista(custodios);
            _tiposPaseDeLista = _paseListaCatalogoServicio.EncontrarPor(pl => pl.Estatus == "AC");
        }

        private void CambiarAsignacion(AsignacionOtd asignacion)
        {
            if (AsignacionPorNivel && asignacion != null)
            {
                var ubicaciones = _paseLista.Asignaciones.Where(a => a.Edificio.Id == asignacion.Edificio.Id && a.Nivel == asignacion.Nivel).ToList();
                ubicaciones.ForEach(u => u.Custodio = asignacion.Custodio);
                PaseLista = _paseLista.Clonar();

                RecargarAsignacionesVista(PaseLista.Asignaciones);
            }
            else
            {
                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    AsignacionesVista.Refresh();
                });
            }
        }

        private void RecargarAsignacionesVista(List<AsignacionOtd> asignaciones)
        {
            DispatcherHelper.CheckBeginInvokeOnUI(() =>
            {
                AsignacionesVista = CollectionViewSource.GetDefaultView(asignaciones);
                AsignacionesVista.GroupDescriptions.Clear();
                AsignacionesVista.GroupDescriptions.Add(new PropertyGroupDescription("Custodio.Nombre"));
                AsignacionesVista.Refresh();
            });
        }

        private void CambioDePaseDeLista(PLCatalogoOtd paseDeLista)
        {
            PaseLista = paseDeLista != null ? _pasesDelista.SingleOrDefault(pl => pl.TipoDePaseListaId == paseDeLista.IdPLCatalgo).Clonar() : _pasesDelista.First().Clonar();
            RecargarAsignacionesVista(PaseLista.Asignaciones);
        }

        private void ActualizarLista()
        {
            var elemento = PasesDeLista.SingleOrDefault(pl => pl.TipoDePaseListaId == PaseLista.TipoDePaseListaId);
            var indice = PasesDeLista.IndexOf(elemento);

            PasesDeLista.RemoveAt(indice);
            PasesDeLista.Insert(indice, PaseLista.Clonar());
            _pasesDeListaOriginales.RemoveAt(indice);
            _pasesDeListaOriginales.Insert(indice, PaseLista.Clonar());

            DispatcherHelper.CheckBeginInvokeOnUI(() =>
             {
                 AsignacionesVista.Refresh();
             });
        }

        private void Cancelar()
        {
            _pasesDelista = _pasesDeListaOriginales;
            CambioDePaseDeLista(new PLCatalogoOtd { IdPLCatalgo = PaseLista.TipoDePaseListaId });
        }

        private void RegistrarSubscripciones()
        {
            Mensajero.RegistrarSuscripcion<TipoDeMensajeEnum>(this, (mensaje) =>
            {
                if (mensaje == TipoDeMensajeEnum.ActualizarTiposDePL)
                {
                    CargarDatos();
                    Custodios = _custodios;
                    TiposPaseLista = _tiposPaseDeLista;
                    CambioDePaseDeLista(TiposPaseLista.FirstOrDefault());
                }
            });

            Mensajero.RegistrarSuscripcion<TipoDeMensajeEnum>(this, (mensaje) =>
            {
                if (mensaje == TipoDeMensajeEnum.CargarProgramacionPaseLista && !_datosCargados)
                {
                    _datosCargados = true;
                    Action accion = () => CargarDatos();
                    LoadingPantalla.Ejecutar(Sesion.PantallaPrincipal, SSPConst.CargandoMsg, accion);
                    Custodios = _custodios;
                    TiposPaseLista = _tiposPaseDeLista;
                    CambioDePaseDeLista(TiposPaseLista.FirstOrDefault());
                    FechaProgramacion = DateTime.Today.AddDays(1);
                }
            });

        }

        #endregion Metodos Privados

        #region Validaciones

        private bool Validar()
        {
            Errores = !PaseLista.Asignaciones.Any(a => a.Custodio.Id > 0) ? Errores = SSPConst.PLProgramacionError : string.Empty;

            return string.IsNullOrEmpty(Errores);
        }

        #endregion
    }
}