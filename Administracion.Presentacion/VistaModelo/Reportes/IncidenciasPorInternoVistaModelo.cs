using Administracion.Contratos;
using Administracion.Contratos.Servicios;
using Administracion.Enum;
using Administracion.OTD.Filtros;
using Administracion.OTD.Reportes;
using Administracion.Utilidades.Autenticacion;
using GalaSoft.MvvmLight;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.Integration;
using GalaSoft.MvvmLight.Command;
using Administracion.OTD;
using Administracion.Utilidades;
using System.Linq.Expressions;
using Administracion.Utilidades.ClasesAuxiliares;
using Administracion.Utilidades.Constantes;
using Administracion.Presentacion.Controles;
using Administracion.Presentacion.Utilidades;
using Administracion.Utilidades.Controles;

namespace Administracion.Presentacion.VistaModelo
{
    public class IncidenciasPorInternoVistaModelo : ViewModelBase, IIncidenciasPorInternoVistaModelo
    {
        #region Constantes
        private static readonly string TIPO_REPORTE = "REPORTE INCIDENCIAS DE PASE DE LISTA";
        #endregion

        #region Miembros privados
        private WindowsFormsHost _reporte;
        private ReportViewer _reporteador;
        private ReporteFiltroOtd _filtro;
        private IList<SectorOtd> _sectores;
        private IList<CeldaOtd> _celdas;
        private IList<ImputadoOtd> _imputados;
        private IList<ImputadoOtd> _imputadosCompleto;
        private CentroOtd _centro;
        private string _imputadoFiltro;
        private IPLIncidenciaBitacoraServicio _plIncidenciaBitacoraServicio;
        private IPLProgramadoServicio _plProgramadoServicio;
        private ICentroServicio _centroServicio;
        private IImputadoBiometricoServicio _imputadoBiometricoServicio;
        private IImputadoServicio _imputadoServicio;
        private IUbicacionServicio _ubicacionServicio;
        private IReportesServicio _reporteServicio;
        private IPLCatalogoServicio _plCatalogoServicio;
        private ImputadoOtd _impuadoSeleccionado;
        private bool _datosCargados;
        private IList<EdificioOtd> _edificios;
        private UIColeccion<PLCatalogoOtd> _pasesDeListaCatalogos;
        private string _errores;
        private ReporteIncidenciasRpt _reporteIncidencias;
        #endregion

        #region Propiedades
        public bool DatosCargados 
        {
            get
            {
                return _datosCargados;
            }
            set
            {
                _datosCargados = value;
                RaisePropertyChanged("DatosCargados");
            }
        }
        public IList<ImputadoOtd> Imputados
        {
            get
            {
                return _imputados;
            }
            set
            {
                _imputados = value;
                RaisePropertyChanged("Imputados");
            }
        }
        public WindowsFormsHost ReporteFormHost
        {
            get
            {
                return _reporte;
            }
            set
            {
                _reporte = value;
                RaisePropertyChanged("ReporteFormHost");
            }
        }

        public ReporteFiltroOtd Filtro
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

        public IList<SectorOtd> Sectores
        {
            get
            {
                return _sectores;
            }
            set
            {
                _sectores = value;
                RaisePropertyChanged("Sectores");
            }
        }

        public IList<CeldaOtd> Celdas
        {
            get
            {
                return _celdas;
            }
            set
            {
                _celdas = value;
                RaisePropertyChanged("Celdas");
            }
        }

        public IList<EdificioOtd> Edificios
        {
            get
            {
                return _edificios;
            }
            set
            {
                _edificios = value;
                RaisePropertyChanged("Edificios");
            }
        }

        public string ImputadosFiltro
        {
            get
            {
                return _imputadoFiltro;
            }
            set
            {
                _imputadoFiltro = value;
                RaisePropertyChanged("ImputadosFiltro");
            }
        }

        public ImputadoOtd ImputadoSeleccionado
        {
            get
            {
                return _impuadoSeleccionado;
            }
            set
            {
                _impuadoSeleccionado = value;
                LimpiarUbicacion();
                RaisePropertyChanged("ImputadoSeleccionado");
            }
        }

        public UIColeccion<PLCatalogoOtd> PasesDeLista
        {
            get
            {
                return _pasesDeListaCatalogos;
            }
            set
            {
                _pasesDeListaCatalogos = value;
                RaisePropertyChanged("PasesDeLista");
            }
        }

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
        public IncidenciasPorInternoVistaModelo(IPLIncidenciaBitacoraServicio plIncidenciaBitacoraServicio, IPLProgramadoServicio plProgramadoServicio, ICentroServicio centroServicio, IImputadoBiometricoServicio imputadoBiometricoServicio, IImputadoServicio imputadoServicio, IUbicacionServicio ubicacionServicio, IReportesServicio reporteServicio, IPLCatalogoServicio plCatalogoServicio)
        {
            _plIncidenciaBitacoraServicio = plIncidenciaBitacoraServicio;
            _plProgramadoServicio = plProgramadoServicio;
            _centroServicio = centroServicio;
            _imputadoBiometricoServicio = imputadoBiometricoServicio;
            _imputadoServicio = imputadoServicio;
            _ubicacionServicio = ubicacionServicio;
            _reporteServicio = reporteServicio;
            _plCatalogoServicio = plCatalogoServicio;
            RegistrarSubscripciones();
            InicializarReporteador();
        }
        #endregion

        #region Commands
        public RelayCommand EjecutarReporteCommand
        {
            get
            {
                return new RelayCommand(EjecutarReporte);
            }

        }

        public RelayCommand BuscarSectoresCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (Filtro.IdEdificio > default(int))
                    {
                        var sectores = _ubicacionServicio.ObtenerSectoresPorCentroYEdificio(Sesion.ObjetoDeSesion.IdCentro, Filtro.IdEdificio);
                        sectores.Insert(0, new SectorOtd { Descripcion = "Todos", IdSector = -1 });
                        Sectores = sectores;
                    }
                });
            }
        }

        public RelayCommand BuscarCeldasCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (Filtro.IdSector > default(int) && Filtro.IdEdificio > default(int))
                    {
                        var celdas = _ubicacionServicio.ObtenerCeldas(Sesion.ObjetoDeSesion.IdCentro, Filtro.IdEdificio, Filtro.IdSector);
                        celdas.Insert(0, new CeldaOtd { IdCelda = "Todas" });
                        Celdas = celdas;
                    }
                });
            }
        }

        public RelayCommand<string> FiltrarImputadosCommand
        {
            get
            {
                return new RelayCommand<string>(FiltrarImputados);
            }
        }
        #endregion

        #region Metodos privados
        private void InicializarReporteador()
        {
            _reporteador = new ReportViewer();
            _reporteador.LocalReport.ReportPath = "Reportes/ReporteVacio.rdlc";
            _reporteador.ProcessingMode = ProcessingMode.Local;
            _reporteador.ZoomMode = ZoomMode.PageWidth;
            _reporteador.PageCountMode = PageCountMode.Actual;
            ReporteFormHost = new WindowsFormsHost();
            ReporteFormHost.Child = _reporteador;
            Filtro = new ReporteFiltroOtd();
            Filtro.FechaInicial = DateTime.Now.AddDays(-7);
            Filtro.FechaFinal = DateTime.Now;
            Edificios = new List<EdificioOtd>();
        }

        private void FiltrarImputados(string filtro)
        {
            var aa = ImputadosFiltro;
            filtro = filtro.ToLower();
            Imputados = _imputadosCompleto.Where(i => (!string.IsNullOrWhiteSpace(i.Nombre) && i.Nombre.ToLower().Contains(filtro))
                || (!string.IsNullOrWhiteSpace(i.Paterno) && i.Paterno.ToLower().Contains(filtro))
                || (!string.IsNullOrWhiteSpace(i.Materno) && i.Materno.ToLower().Contains(filtro))).ToList();
        }

        private void EjecutarReporte()
        {
            bool filtroValido = Filtro.IdEdificio > default(int) || ImputadoSeleccionado != null;
            if (!filtroValido)
            {
                Errores = "Debes seleccionar ya sea un imputado o una unbicacion";
                return;
            }
            else
            {
                Errores = string.Empty;
            }

            var a = DateTime.Now - DateTime.Now.AddMonths(4);

            _reporteador.Reset();
            var reportePath = ImputadoSeleccionado != null ? "Reportes/IncidenciasPorInterno.rdlc" : "Reportes/IncidenciasPorUbicacion.rdlc";
            _reporteador.Refresh();
            _reporteador.LocalReport.ReportPath = reportePath;


            Action accion = () => PrepararReporte();
            LoadingPantalla.Ejecutar(Sesion.PantallaPrincipal, SSPConst.CargandoMsg, accion);

            if (ImputadoSeleccionado != null)
            {
                GenerarReportePorImputado(_reporteIncidencias);
            }
            else
            {
                GenerarReportePorUbicacion(_reporteIncidencias);
            }
            
            _reporteador.RefreshReport();
        }

        private void PrepararReporte()
        {
            _reporteIncidencias = new ReporteIncidenciasRpt();
            if (ImputadoSeleccionado != null)
            {
                Filtro.Imputado = ImputadoSeleccionado;
                _reporteIncidencias = _reporteServicio.ReporteIncidenciasPorInterno(Filtro);
                
            }
            else
            {
                _reporteIncidencias = _reporteServicio.ReporteIncidenciaPorUbicacion(Filtro, Imputados);
            }
        }

        private void GenerarReportePorImputado(ReporteIncidenciasRpt reporte)
        {
            var imputadoCompleto = _imputadoServicio.EncontrarPor(i => i.IdImputado == reporte.Imputado.IdImputado
                && i.IdAnio == reporte.Imputado.IdAnio && i.IdCentro == Sesion.ObjetoDeSesion.IdCentro).SingleOrDefault();
            var ubicacionActual = string.Empty;

            ReportParameter[] parameters = new ReportParameter[8];
            parameters[0] = new ReportParameter("Centro", _centro.Descripcion.Trim());
            parameters[1] = new ReportParameter("TipoReporte", TIPO_REPORTE);
            parameters[2] = new ReportParameter("Fechas", string.Format("DEL {0} DE {1} DE {2} AL {3} DE {4} DE {5}", Filtro.FechaInicial.Day, Filtro.FechaInicial.ObtenerStringMes(true), Filtro.FechaInicial.Year, Filtro.FechaFinal.Day, Filtro.FechaFinal.ObtenerStringMes(true), Filtro.FechaFinal.Year));
            parameters[3] = new ReportParameter("UbicacionActual", ubicacionActual);
            parameters[4] = new ReportParameter("Activo", "Si");

            parameters[5] = new ReportParameter("NoIngresos", imputadoCompleto != null ? imputadoCompleto.Ingresos.Count().ToString() : string.Empty);
            parameters[6] = new ReportParameter("NombreInterno", reporte.Imputado != null ? reporte.NombreDeInterno : string.Empty);
            parameters[7] = new ReportParameter("Expediente", reporte.Imputado != null ? string.Format("{0}/{1}", Filtro.Imputado.IdAnio, Filtro.Imputado.IdImputado) : string.Empty);
            _reporteador.LocalReport.DataSources.Add(new ReportDataSource("Secciones", reporte.Datos));
            _reporteador.LocalReport.SetParameters(parameters);
        }

        private void GenerarReportePorUbicacion(ReporteIncidenciasRpt reporte)
        {
            var plProgramadosCentro = _plProgramadoServicio.EncontrarPor(pl => pl.IdCentro == _centro.IdCentro);

            var ubicacionActual = string.Empty;

            ReportParameter[] parameters = new ReportParameter[5];
            parameters[0] = new ReportParameter("Centro", _centro.Descripcion.Trim());
            parameters[1] = new ReportParameter("TipoReporte", TIPO_REPORTE);
            parameters[2] = new ReportParameter("Fechas", string.Format("DEL {0} DE {1} DE {2} AL {3} DE {4} DE {5}", Filtro.FechaInicial.Day, Filtro.FechaInicial.ObtenerStringMes(true), Filtro.FechaInicial.Year, Filtro.FechaFinal.Day, Filtro.FechaFinal.ObtenerStringMes(true), Filtro.FechaFinal.Year));
            parameters[3] = new ReportParameter("FechaReporte", DateTime.Now.ToShortDateString());
            parameters[4] = new ReportParameter("PaseDeLista", "PL PRUEBA");
            _reporteador.LocalReport.DataSources.Add(new ReportDataSource("Secciones", reporte.Datos));
            _reporteador.LocalReport.SetParameters(parameters);
        }

        private void ObtenerUbicacion(IList<PLIncidenciaBitacoraOtd> incidenciasBitacoras, ref EdificioOtd edificio, ref string ubicacionActual)
        {
            if (incidenciasBitacoras.Any())
            {
                var idCentro = incidenciasBitacoras.LastOrDefault().Celda.IdCentro;
                _centro = _centroServicio.EncontrarPor(c => c.IdCentro == idCentro).FirstOrDefault();
                if (edificio == null)
                {
                    var idEdificio = incidenciasBitacoras.LastOrDefault().Celda.IdEdificio;
                    edificio = _ubicacionServicio.EncontrarEdificiosPor(e => e.IdEdificio == idEdificio).SingleOrDefault();
                }
                var ultimaIncidenciaBitacora = incidenciasBitacoras.LastOrDefault();
                if (ultimaIncidenciaBitacora != null)
                {
                    ubicacionActual = string.Format("{0}-{1}-{2}", edificio.Descripcion.Trim(), ultimaIncidenciaBitacora.Celda.Sector.Descripcion.Trim(), ultimaIncidenciaBitacora.Celda.IdCelda.Trim());
                }
                else
                {
                    ubicacionActual = string.Format("{0}", edificio.Descripcion.Trim(), ultimaIncidenciaBitacora.Celda.IdCelda.Trim());
                }
            }
        }

        private void LimpiarUbicacion()
        {
            Filtro.IdEdificio = 0;
            Filtro.IdSector = 0;
            Filtro.IdCelda = string.Empty;
        }

        private void InicializarObjetos()
        {
            _edificios = _ubicacionServicio.ObtenerEdificiosPorCentro(Sesion.ObjetoDeSesion.IdCentro);
            _edificios.Insert(0, new EdificioOtd { Descripcion = "Todos", IdEdificio = -1 });
            Imputados = _imputadoServicio.ObtenerImputados(true);
            _centro = _centroServicio.EncontrarPor(c => c.IdCentro == Sesion.ObjetoDeSesion.IdCentro).SingleOrDefault();
            CargarPasesDeLista();
            _imputadosCompleto = Imputados;
        }

        private void CargarPasesDeLista()
        {
            var pasesDeLista = _plCatalogoServicio.EncontrarPor(pl => pl.Estatus != "CA").ToList();
            _pasesDeListaCatalogos = pasesDeLista != null ? Convertidor.ConvertirLista(pasesDeLista) : new UIColeccion<PLCatalogoOtd>();
        }

        private void RegistrarSubscripciones()
        {
            Mensajero.RegistrarSuscripcion<TipoDeMensajeEnum>(this, (mensaje) =>
            {
                if (mensaje == TipoDeMensajeEnum.ActualizarTiposDePL)
                {
                    CargarPasesDeLista();
                    _pasesDeListaCatalogos.Insert(0, new PLCatalogoOtd { Nombre = "Todos", IdPLCatalgo = -1 });
                    PasesDeLista = _pasesDeListaCatalogos;
                }
            });
            
            Mensajero.RegistrarSuscripcion<TipoDeMensajeEnum>(this, (mensaje) =>
            {
                if (mensaje == TipoDeMensajeEnum.CargarReportes && !DatosCargados)
                {
                    DatosCargados = true;
                    Action accion = () => InicializarObjetos();
                    LoadingPantalla.Ejecutar(Sesion.PantallaPrincipal, SSPConst.CargandoMsg, accion);
                    _reporteador.RefreshReport();
                    Edificios = _edificios;
                    _pasesDeListaCatalogos.Insert(0, new PLCatalogoOtd { Nombre = "Todos", IdPLCatalgo = -1 });
                    PasesDeLista = _pasesDeListaCatalogos;
                }
            });
        }

        private void CargarReporte()
        {

        }
        #endregion
    }
}
