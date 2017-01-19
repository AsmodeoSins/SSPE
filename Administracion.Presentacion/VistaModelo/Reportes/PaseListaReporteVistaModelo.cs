using Administracion.Contratos;
using Administracion.Contratos.Servicios;
using Administracion.Enum;
using Administracion.OTD;
using Administracion.OTD.Filtros;
using Administracion.OTD.Reportes;
using Administracion.Presentacion.Controles;
using Administracion.Presentacion.Utilidades;
using Administracion.Utilidades.Autenticacion;
using Administracion.Utilidades.Constantes;
using Administracion.Utilidades.Controles;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace Administracion.Presentacion.VistaModelo
{
    public class PaseListaReporteVistaModelo : ViewModelBase, IPaseListaReporteVistaModelo
    {
        #region Miembros Privados

        private readonly IPLCatalogoServicio _paseListaCatalogoServicio;
        private readonly IReportesServicio _reportesServicio;
        private readonly IUbicacionServicio _ubicacionServicio;

        private WindowsFormsHost _reporte;
        private ReportViewer _reporteador;
        private IList<SectorOtd> _sectores;
        private const PaseListaReporteTipo _tipoReporte = PaseListaReporteTipo.General;
        private bool _datosCargados;
        private IList<EdificioOtd> _edificios;

        #endregion

        public PaseListaReporteVistaModelo(IPLCatalogoServicio paseListaCatalogoServicio, IReportesServicio reportesServicio, IUbicacionServicio ubicacionServicio)
        {
            _paseListaCatalogoServicio = paseListaCatalogoServicio;
            _reportesServicio = reportesServicio;
            _ubicacionServicio = ubicacionServicio;
            InicializarObjetos();
            RegistrarSubscripciones();
        }

        #region Propiedades

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

        public ReporteFiltroOtd Filtro { get; set; }

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
                    if (Filtro.IdEdificio > 0)
                    {
                        var sectores = _ubicacionServicio.ObtenerSectoresPorCentroYEdificio(Sesion.ObjetoDeSesion.IdCentro, Filtro.IdEdificio);
                        sectores.Insert(0, new SectorOtd { Descripcion = "Todos", IdSector = -1 });
                        Sectores = sectores;
                    }
                });
            }
        }

        #endregion

        #region Metodos Privados

        private void InicializarObjetos()
        {
            Edificios = new List<EdificioOtd>();
            InicializarReporteador();
            Filtro = new ReporteFiltroOtd
            {
                FechaInicial = DateTime.Now,
                FechaFinal = DateTime.Now,
                IdCentro = Sesion.ObjetoDeSesion.IdCentro,
                TipoReporte = _tipoReporte
            };
        }

        private void CargarDatos()
        {
            _edificios = _ubicacionServicio.ObtenerEdificiosPorCentro(Sesion.ObjetoDeSesion.IdCentro);
            _edificios.Insert(0, new EdificioOtd { Descripcion = "Todos", IdEdificio = -1 });
        }

        private void InicializarReporteador()
        {
            _reporteador = new ReportViewer();
            _reporteador.ZoomMode = ZoomMode.PageWidth;
            _reporteador.ProcessingMode = ProcessingMode.Local;
            ReporteFormHost = new WindowsFormsHost();
            ReporteFormHost.Child = _reporteador;
        }

        private void EjecutarReporte()
        {
            _reporteador.LocalReport.DataSources.Clear();
            string reportePath = string.Empty;
            var reporte = new ReporteGeneralRpt();

            switch (Filtro.TipoReporte)
            {
                case PaseListaReporteTipo.General:
                    //reporte = _reportesServicio.ReportePaseListaGeneral(Filtro);
                    reporte = _reportesServicio.ReportePaseLista(Filtro);
                    reportePath = "Reportes/ReportePL.rdlc";
                    break;

                case PaseListaReporteTipo.Horario:
                    break;

                case PaseListaReporteTipo.Celda:
                    break;

                case PaseListaReporteTipo.Mes:
                    break;

                case PaseListaReporteTipo.Semana:
                    break;
            }

            _reporteador.LocalReport.ReportPath = reportePath;
            _reporteador.PageCountMode = PageCountMode.Actual;
            _reporteador.LocalReport.DataSources.Add(new ReportDataSource("Secciones", reporte.Datos));
            _reporteador.LocalReport.SetParameters(ActivarEncabezado(reporte.Encabezado));
            _reporteador.RefreshReport();
        }

        private ReportParameter[] ActivarEncabezado(EncabezadoBaseRpt encabezado)
        {
            ReportParameter[] parameters = new ReportParameter[3];
            parameters[0] = new ReportParameter("Centro", encabezado.Titulo);
            parameters[1] = new ReportParameter("TipoReporte", encabezado.Subtitulo);
            parameters[2] = new ReportParameter("Fechas", encabezado.RangoFechas);

            return parameters;
        }

        private void RegistrarSubscripciones()
        {
            Mensajero.RegistrarSuscripcion<TipoDeMensajeEnum>(this, (mensaje) =>
            {
                if (mensaje == TipoDeMensajeEnum.CargarReportes && !_datosCargados)
                {
                    _datosCargados = true;
                    Action accion = () => CargarDatos();
                    LoadingPantalla.Ejecutar(Sesion.PantallaPrincipal, SSPConst.CargandoMsg, accion);                    
                    Edificios = _edificios;
                }
            });
        }

        #endregion

    }
}