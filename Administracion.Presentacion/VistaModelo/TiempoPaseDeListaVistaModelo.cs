using Administracion.Contratos;
using Administracion.Contratos.Servicios;
using Administracion.Enum;
using Administracion.OTD;
using Administracion.Presentacion.Controles;
using Administracion.Presentacion.Utilidades;
using Administracion.Utilidades.Autenticacion;
using Administracion.Utilidades.Constantes;
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
    /// Contrato para la pantalla de tiempo de pase de lista
    /// </summary>
    public class TiempoPaseDeListaVistaModelo : ViewModelBase, ITiempoPaseDeListaVistaModelo
    {
        #region Miembros privados
        private ParametroOtd _horaCentro;
        private IParametroServicio _parametroServicio;
        private ParametroValidador _validador;
        private bool _modeloEsValido;
        private string _errores;
        private bool _parametroExiste;
        private bool _datosCargados;
        #endregion

        #region Propiedades
        /// <summary>
        /// Representa el valor de hora especificado para el centro actual
        /// </summary>
        public ParametroOtd HoraCentro
        {
            get
            {
                return _horaCentro;
            }
            set
            {
                _horaCentro = value;
                RaisePropertyChanged("HoraCentro");
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
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor para inicializacion del servicio
        /// </summary>
        /// <param name="parametroServicio"></param>
        public TiempoPaseDeListaVistaModelo(IParametroServicio parametroServicio)
        {
            _parametroServicio = parametroServicio;
            RegistrarSubscripciones();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Inserta/Edita el parametro cargado en la tabla 'PARAMETRO'
        /// </summary>
        public void Guardar()
        {
            if (Validar())
            {
                if (!_parametroExiste)
                {
                    InsertarParametro();
                }
                else
                {
                    EditarParametro();
                }
            }
        }
        #endregion

        #region Metodos privados
        /// <summary>
        /// Inserta un nuevo registro en la tabla 'PARAMETRO'
        /// </summary>
        private void InsertarParametro()
        {
            _parametroServicio.CrearParametro(HoraCentro);
        }

        /// <summary>
        /// Edita el parametro del centro actual en al tabla 'PARAMETRO'
        /// </summary>
        private void EditarParametro()
        {
            _parametroServicio.ModificarParametro(HoraCentro);
        }

        /// <summary>
        /// Regresa los valores del parametro a los que estan cargados en la base de datos
        /// </summary>
        private void Cancelar()
        {
            HoraCentro = _parametroServicio.EncontrarPor(p => p.IdCentro == Sesion.ObjetoDeSesion.IdCentro).FirstOrDefault();
        }

        /// <summary>
        /// Inicializa los objetos cuando se llama desde el constructor
        /// </summary>
        private void InicializarObjetos()
        {
            var dbParametro = _parametroServicio.EncontrarPor(p => p.IdCentro == Sesion.ObjetoDeSesion.IdCentro && p.IdClave == "PASELISTA_TIEMPO").SingleOrDefault();
            _parametroExiste = dbParametro != null;
            HoraCentro =  _parametroExiste ? dbParametro :
                new ParametroOtd { IdCentro = Sesion.ObjetoDeSesion.IdCentro, IdClave = "PASELISTA_TIEMPO" };
            _validador = new ParametroValidador();
        }
        #endregion

        #region Commands
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

        public RelayCommand CancelarCommand
        {
            get
            {
                return new RelayCommand(Cancelar);
            }
        }
        #endregion

        #region Validaciones
        /// <summary>
        /// Valida el modelo y actualiza las propiedades para desplegarse en pantalla
        /// </summary>
        /// <returns></returns>
        private bool Validar()
        {
            var resultado = _validador.Validate(HoraCentro);
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
        #endregion
    }
}
