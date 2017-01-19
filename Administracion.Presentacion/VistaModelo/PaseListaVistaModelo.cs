using Administracion.Contratos;
using Administracion.Contratos.Servicios;
using Administracion.Enum;
using Administracion.OTD;
using Administracion.Presentacion.Controles;
using Administracion.Presentacion.Utilidades;
using Administracion.Utilidades.Autenticacion;
using Administracion.Utilidades.Constantes;
using Administracion.Utilidades.Controles;
using Administracion.Utilidades.Validadores;
using FluentValidation.Results;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Linq;
using System.Text;

//using Administracion.Presentacion.VistaModelo.Controles;

namespace Administracion.Presentacion.VistaModelo
{
    public class PaseListaVistaModelo : ViewModelBase, IPaseListaVistaModelo
    {
        #region Constantes
        private readonly string NOMBRE_MODULO = "ADM_CATALOGO_PL_CATALOGO";
        #endregion
        #region Miembros privados

        private bool _activarEliminar;
        private string _errores;
        private string _estatusSeleccionado;
        private int _hora;
        private int _minutos;
        private bool _modeloEsValido;
        private PLCatalogoOtd _paseDeLista;
        private IPLCatalogoEstatusServicio _paseDeListaCatalogoEstatusServicio;
        private IPLCatalogoServicio _paseDeListaCatalogoServicio;
        private PLCatalogoEstatusOtd _paseDeListaEstatusSeleccionado;
        private PLCatalogoOtd _paseDeListaSeleccionado;
        private PaseDeListaCatalogoValidador _validador;
        private UIColeccion<PLCatalogoOtd> _pasesDeListaCatalogos;
        private bool _datosCargados;
        private UIColeccion<PLCatalogoEstatusOtd> _paseDeListaEstatus;

        #endregion Miembros privados

        #region Permisos
        public bool PuedeInsertar
        {
            get
            {
                return Sesion.ObjetoDeSesion.PermisosModulos.Any(pm => pm.NombreModulo == NOMBRE_MODULO && pm.Insertar);
            }
        }
        public bool PuedeEditar
        {
            get
            {
                return Sesion.ObjetoDeSesion.PermisosModulos.Any(pm => pm.NombreModulo == NOMBRE_MODULO && pm.Editar);
            }
        }
        public bool PuedeLeer
        {
            get
            {
                return Sesion.ObjetoDeSesion.PermisosModulos.Any(pm => pm.NombreModulo == NOMBRE_MODULO && pm.Consultar);
            }
        }
        #endregion

        #region Propiedades

        /// <summary>
        /// Representa el estatus del boton eliminar
        /// </summary>
        public bool ActivarEliminar
        {
            get
            {
                return _activarEliminar;
            }
            set
            {
                _activarEliminar = value;
                RaisePropertyChanged("ActivarEliminar");
            }
        }

        /// <summary>
        /// Errores de validacion
        /// </summary>
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
        /// Representa el estatus seleccionado del pase de lista
        /// </summary>
        public string EstatusSeleccionadoId
        {
            get
            {
                return _estatusSeleccionado;
            }
            set
            {
                _estatusSeleccionado = value;
                RaisePropertyChanged("EstatusSeleccionadoId");
            }
        }

        /// <summary>
        /// Propiedad para la cantidad de horas del paso de lista
        /// </summary>
        public int Hora
        {
            get
            {
                return _hora;
            }
            set
            {
                _hora = value;
                RaisePropertyChanged("Hora");
            }
        }

        /// <summary>
        /// Propiedad para la cantidad de Minutos del paso de lista
        /// </summary>
        public int Minutos
        {
            get
            {
                return _minutos;
            }
            set
            {
                _minutos = value;
                RaisePropertyChanged("Minutos");
            }
        }

        /// <summary>
        /// Indica si el modelo es valido
        /// </summary>
        public bool ModeloEsValido
        {
            get
            {
                return _modeloEsValido;
            }
            set
            {
                _modeloEsValido = value;
                RaisePropertyChanged("ModeloEsValido");
            }
        }

        /// <summary>
        /// Pase de lista para inserciones
        /// </summary>
        public PLCatalogoOtd PaseDeLista
        {
            get
            {
                return _paseDeLista;
            }
            set
            {
                _paseDeLista = value;
                PrepararPaseDeLista();
                RaisePropertyChanged("PaseDeLista");
            }
        }

        /// <summary>
        /// Pase de lista estatus seleccionado
        /// </summary>
        public PLCatalogoEstatusOtd PaseDeListaCatalogoEstatusSeleccionado
        {
            get
            {
                return _paseDeListaEstatusSeleccionado;
            }
            set
            {
                _paseDeListaEstatusSeleccionado = value;
                RaisePropertyChanged("PaseDeListaCatalogoEstatusSeleccionado");
            }
        }

        /// <summary>
        /// Lista de incidencias existentes
        /// </summary>
        public UIColeccion<PLCatalogoEstatusOtd> PaseDeListaEstatus {
        get{
            return _paseDeListaEstatus;
        }

            set
            {
                _paseDeListaEstatus = value;
                RaisePropertyChanged("PaseDeListaEstatus");
            }
        }

        /// <summary>
        /// Pase de lista seleccionado para edicion/eliminar
        /// </summary>
        public PLCatalogoOtd PaseDeListaSeleccionado
        {
            get
            {
                return _paseDeListaSeleccionado;
            }
            set
            {
                _paseDeListaSeleccionado = value;
                RaisePropertyChanged("PaseDeListaSeleccionado");
            }
        }

        /// <summary>
        /// Pases de lista existentes
        /// </summary>
        public UIColeccion<PLCatalogoOtd> PasesDeListaCatalogos
        {
            get
            {
                return _pasesDeListaCatalogos;
            }
            set
            {
                _pasesDeListaCatalogos = value;
                RaisePropertyChanged("PasesDeListaCatalogos");
            }
        }

        #endregion Propiedades

        #region Constructores

        public PaseListaVistaModelo(IPLCatalogoServicio paseDelistaServicio, IPLCatalogoEstatusServicio paseDeListaEstatusServicio)
        {
            _paseDeListaCatalogoServicio = paseDelistaServicio;
            _paseDeListaCatalogoEstatusServicio = paseDeListaEstatusServicio;
            _paseDeLista = new PLCatalogoOtd();
            RegistrarSubscripciones();
        }

        #endregion Constructores

        #region Metodos publicos

        /// <summary>
        /// Edita un pase de lista seleccionado
        /// </summary>
        public void EditarPaseDeLista()
        {
            PaseDeLista.Estatus = EstatusSeleccionadoId;
            PaseDeLista.PLCatalogoEstatus = PaseDeListaCatalogoEstatusSeleccionado;
            _paseDeListaCatalogoServicio.ModificarPaseDeListaCatalogo(PaseDeLista);
            ActualizarLista(PaseDeLista);
        }

        /// <summary>
        /// Elimina un pase de lista
        /// </summary>
        public void EliminarPaseDeLista()
        {
            //PaseDeLista.IdEstatus = (int)Enum.Enums.PaseDeListaCatalogoEstatus.Inactivo;
            //_paseDeListaCatalogoServicio.ModificarPaseDeListaCatalogo(PaseDeLista);
            //PasesDeListaCatalogos.Remove(PaseDeLista);
            //LimpiarPaseDeLista();
        }

        /// <summary>
        /// Inserta un nuevo pase de lista
        /// </summary>
        public void InsertarPaseDeLista()
        {
            PaseDeLista.HoraInicio = new DateTime(0) + new TimeSpan(Hora, Minutos, 0);
            PaseDeLista.Estatus = PaseDeListaCatalogoEstatusSeleccionado.IdEstatus;
            var paseDeLista = _paseDeListaCatalogoServicio.CrearPaseDelistaCatalogo(PaseDeLista);
            PaseDeLista.PLCatalogoEstatus = PaseDeListaEstatus.FirstOrDefault(c => c.IdEstatus == PaseDeLista.Estatus);
            PasesDeListaCatalogos.Add(paseDeLista);
        }

        #endregion Metodos publicos

        #region Commands

        public RelayCommand CancelarCommand
        {
            get
            {
                return new RelayCommand(LimpiarPaseDeLista);
            }
        }

        public RelayCommand EliminarPaseDeListaCommand
        {
            get
            {
                return new RelayCommand(EliminarPaseDeLista);
            }
        }

        public RelayCommand GuardarCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Action accion = () => Guardar();
                    var resultado = LoadingPantalla.Ejecutar(Sesion.PantallaPrincipal, SSPConst.GuardandoMsg, accion);
                });
            }
        }

        #endregion Commands

        #region Metodos privados

        /// <summary>
        /// Actualiza el elemento en la lista despues de ser modificado
        /// </summary>
        /// <param name="paseDeLista"></param>
        private void ActualizarLista(PLCatalogoOtd paseDeLista)
        {
            var elemento = PasesDeListaCatalogos.SingleOrDefault(pl => pl.IdPLCatalgo == paseDeLista.IdPLCatalgo);
            var indice = PasesDeListaCatalogos.IndexOf(elemento);
            PasesDeListaCatalogos.RemoveAt(indice);

            if (elemento.Estatus != "CA")
            {
                elemento.HoraInicio = paseDeLista.HoraInicio;
                elemento.Nombre = paseDeLista.Nombre;
                elemento.PLCatalogoEstatus = paseDeLista.PLCatalogoEstatus;
                elemento.Estatus = paseDeLista.Estatus;
                PasesDeListaCatalogos.Insert(indice, elemento);
            }
        }

        private void Guardar()
        {
            if (Validar())
            {
                if (PaseDeLista.IdPLCatalgo > default(int))
                {
                    EditarPaseDeLista();
                }
                else
                {
                    InsertarPaseDeLista();
                }

                LimpiarPaseDeLista();
                Mensajero.EnviarMensaje<TipoDeMensajeEnum>(TipoDeMensajeEnum.ActualizarTiposDePL);
            }
        }

        private void InicializarObjetos()
        {
            var pasesDeLista = _paseDeListaCatalogoServicio.EncontrarPor(pl => pl.Estatus != "CA");
            PasesDeListaCatalogos = pasesDeLista != null && pasesDeLista.Count > 0 ? Convertidor.ConvertirLista(pasesDeLista) : new UIColeccion<PLCatalogoOtd>();
            PaseDeListaEstatus = Convertidor.ConvertirLista(_paseDeListaCatalogoEstatusServicio.ObtenerPaseDeListaCatalogoEstatus());
            _validador = new PaseDeListaCatalogoValidador();
        }

        private void LimpiarPaseDeLista()
        {
            Errores = string.Empty;
            _paseDeLista = new PLCatalogoOtd();
            PaseDeLista = _paseDeLista;
            ActivarEliminar = false;
        }

        private void PrepararPaseDeLista()
        {
            if (_paseDeLista == null)
            {
                LimpiarPaseDeLista();
            }

            EstatusSeleccionadoId = _paseDeLista.Estatus;
            Hora = _paseDeLista.HoraInicio.GetValueOrDefault().Hour;
            Minutos = _paseDeLista.HoraInicio.GetValueOrDefault().Minute;
            ActivarEliminar = true;
        }

        #endregion Metodos privados

        #region Validaciones

        /// <summary>
        /// Metodo para la validacion del modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool Validar()
        {
            PaseDeLista.HoraInicio = new DateTime(0) + new TimeSpan(Hora, Minutos, 0);
            PaseDeLista.Estatus = PaseDeListaCatalogoEstatusSeleccionado != null ? PaseDeListaCatalogoEstatusSeleccionado.IdEstatus : string.Empty;
            var resultado = _validador.Validate(PaseDeLista);
            var sBuilder = new StringBuilder();
            foreach (ValidationFailure error in resultado.Errors)
            {
                sBuilder.AppendLine(error.ErrorMessage);
            }

            ModeloEsValido = !resultado.Errors.Any();
            Errores = sBuilder.ToString();
            return ModeloEsValido;
        }

        private void RegistrarSubscripciones()
        {
            Mensajero.RegistrarSuscripcion<TipoDeMensajeEnum>(this, (mensaje) =>
            {
                if (mensaje == TipoDeMensajeEnum.CargarCatalogos && !_datosCargados)
                {
                    _datosCargados = true;
                    Action accion = () => InicializarObjetos();
                    LoadingPantalla.Ejecutar(Sesion.PantallaPrincipal, SSPConst.CargandoMsg, accion);                    
                }
            });
        }

        #endregion Validaciones
    }
}