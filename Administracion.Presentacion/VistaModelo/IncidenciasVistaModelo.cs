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

namespace Administracion.Presentacion.VistaModelo
{
    /// <summary>
    /// Vista modelo para el control de incidencias
    /// </summary>
    public class IncidenciasVistaModelo : ViewModelBase, IIncidenciasVistaModelo
    {
        #region Miembros privados

        private string _errores;
        private PLIncidenciaCatalogoOtd _incidencia;
        private PLIncidenciaCatalogoOtd _incidenciaSeleccionada;
        private IIncidenciaServicio _incidenciaServicio;
        private bool _modeloEsValido;
        private IncidenciaValidador _validador;
        private UIColeccion<PLIncidenciaCatalogoOtd> _incidencias;
        private bool _datosCargados;
        #endregion Miembros privados

        #region Propiedades

        /// <summary>
        /// Contiene los errores de validacion del modelo
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
        /// Modelo para insercion de nuevas incdencia
        /// </summary>
        public PLIncidenciaCatalogoOtd Incidencia
        {
            get
            {
                return _incidencia;
            }
            set
            {
                _incidencia = value;
                RaisePropertyChanged("Incidencia");
            }
        }

        /// <summary>
        /// Lista de incidencias existentes
        /// </summary>
        public UIColeccion<PLIncidenciaCatalogoOtd> Incidencias {
            get
            {
                return _incidencias;
            }
            set
            {
                _incidencias = value;
                RaisePropertyChanged("Incidencias");
            }
        }

        /// <summary>
        /// Modelo para insercion de nuevas incdencia
        /// </summary>
        public PLIncidenciaCatalogoOtd IncidenciaSeleccionada
        {
            get
            {
                return _incidenciaSeleccionada;
            }
            set
            {
                _incidenciaSeleccionada = value;
                RaisePropertyChanged("IncidenciaSeleccionada");
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

        #endregion Propiedades

        #region Constructores

        /// <summary>
        /// Constructor que recibe una instancia de tipo IIncidenciaServicio
        /// </summary>
        /// <param name="servicio"></param>
        public IncidenciasVistaModelo(IIncidenciaServicio servicio)
        {
            _incidenciaServicio = servicio;
            RegistrarSubscripciones();
        }

        #endregion Constructores

        #region Metodos publicos

        /// <summary>
        /// Pone una incidencia en estatus inactivo o eliminado
        /// </summary>
        /// <param name="incidencia"></param>
        public void EliminarIncidencia()
        {
            IncidenciaSeleccionada.Visible = 0;
            IncidenciaSeleccionada.ModificadoPor = string.Format("usuario {0}", Sesion.ObjetoDeSesion.IdEmpleado);
            _incidenciaServicio.ModificarIncidencia(IncidenciaSeleccionada);
            Incidencias.Remove(IncidenciaSeleccionada);
        }

        /// <summary>
        /// Crea una nueva incidencia
        /// </summary>
        public void InsertarIncidencia()
        {
            Incidencia.Visible = 1;
            if (Validar())
            {
                Incidencia.ModificadoPor = string.Format("usuario {0}", Sesion.ObjetoDeSesion.IdEmpleado);
                var incidenciaNueva = _incidenciaServicio.CrearIncidencia(Incidencia);
                Incidencias.Add(incidenciaNueva);
                Incidencia = new PLIncidenciaCatalogoOtd();
            }
        }

        /// <summary>
        /// Modifica la incidencia seleccionada
        /// </summary>
        public void ModificarIncidencia()
        {
            if (Validar())
            {
                Incidencia.ModificadoPor = string.Format("usuario {0}", Sesion.ObjetoDeSesion.IdEmpleado);
                _incidenciaServicio.ModificarIncidencia(Incidencia);
            }
        }

        #endregion Metodos publicos

        #region Commands

        /// <summary>
        /// Invoca el metodo para limpiar pantalla
        /// </summary>
        public RelayCommand CancelarCommand
        {
            get
            {
                return new RelayCommand(Limpiar);
            }
        }

        /// <summary>
        /// Invoca el metodo para eliminar una incidencia
        /// </summary>
        public RelayCommand EliminarIncidenciaCommand
        {
            get
            {
                return new RelayCommand(EliminarIncidencia);
            }
        }

        /// <summary>
        /// Invoca el metodo para insertar incidencia
        /// </summary>
        public RelayCommand GuardarCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Action accion = () => Guardar();
                    LoadingPantalla.Ejecutar(Sesion.PantallaPrincipal, SSPConst.GuardandoMsg, accion);
                });
            }
        }

        #endregion Commands

        #region Metodos privados

        private void Guardar()
        {
            if (Incidencia.IdPLIncidenciaCatalogo > default(int))
            {
                ModificarIncidencia();
            }
            else
            {
                InsertarIncidencia();
            }

            Limpiar();
        }

        /// <summary>
        /// Inicializa cuando es llamado desde el constructor
        /// </summary>
        private void InicializarObjetos()
        {
            Incidencia = new PLIncidenciaCatalogoOtd();
            Incidencias = Convertidor.ConvertirLista(_incidenciaServicio.EncontrarPor(i => i.Visible == 1).OrderBy(i => i.IdPLIncidenciaCatalogo));
            _validador = new IncidenciaValidador();
        }

        /// <summary>
        /// Limpia la pantalla
        /// </summary>
        private void Limpiar()
        {
            Incidencia = new PLIncidenciaCatalogoOtd();
        }

        private void RegistrarSubscripciones()
        {
            Mensajero.RegistrarSuscripcion<TipoDeMensajeEnum>(this, (mensaje) =>
            {
                if (mensaje == TipoDeMensajeEnum.CargarCatalogos && !_datosCargados)
                {
                    _datosCargados = true;
                    Action accion = () => InicializarObjetos();
                    LoadingPantalla.Ejecutar(Sesion.PantallaPrincipal, SSPConst.GuardandoMsg, accion);                    
                }
            });
        }

        #endregion Metodos privados

        #region Validaciones

        /// <summary>
        /// Valida el modelo y actualiza las propiedades para desplegarse en pantalla
        /// </summary>
        /// <returns></returns>
        private bool Validar()
        {
            var resultado = _validador.Validate(Incidencia);
            var sBuilder = new StringBuilder();
            foreach (ValidationFailure error in resultado.Errors)
            {
                sBuilder.AppendLine(error.ErrorMessage);
            }

            ModeloEsValido = !resultado.Errors.Any();
            Errores = sBuilder.ToString();
            return ModeloEsValido;
        }

        #endregion Validaciones
    }
}