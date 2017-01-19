using Administracion.Contratos;
using Administracion.Contratos.Servicios;
using Administracion.Enum;
using Administracion.OTD;
using Administracion.OTD.Filtros;
using Administracion.OTD.Reportes;
using Administracion.Utilidades.Autenticacion;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace Administracion.Presentacion.VistaModelo
{
    public class IncidenciasReporteVistaModelo : ViewModelBase, IIncidenciasReporteVistaModelo
    {
        #region Miembros Privados

        private readonly IPLCatalogoServicio _paseListaCatalogoServicio;
        private readonly IReportesServicio _reportesServicio;
        private readonly IUbicacionServicio _ubicacionServicio;
        private readonly IPersonaServicio _personaServicio;
        private WindowsFormsHost _reporte;
        private ReportViewer _reporteador;
        private IList<SectorOtd> _sectores;
        private IList<CeldaOtd> _celdas;
        private const PaseListaReporteTipo _tipoReporte = PaseListaReporteTipo.General;

        #endregion

        public IncidenciasReporteVistaModelo(IPLCatalogoServicio paseListaCatalogoServicio, IReportesServicio reportesServicio, 
            IUbicacionServicio ubicacionServicio, IPersonaServicio personaServicio)
        {
            _paseListaCatalogoServicio = paseListaCatalogoServicio;
            _reportesServicio = reportesServicio;
            _ubicacionServicio = ubicacionServicio;
            _personaServicio = personaServicio;

            InicializarObjetos();
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

        public IList<PersonaOtd> Imputados { get; set; }

        public IList<EdificioOtd> Edificios { get; set; }

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

        public IList<CeldaOtd> Celdas {
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

        public RelayCommand BuscarCeldasCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (!string.IsNullOrWhiteSpace(Filtro.IdCelda) && Filtro.IdCelda.ToUpper() != "TODAS")
                    {
                        var celdas = _ubicacionServicio.ObtenerCeldas(Sesion.ObjetoDeSesion.IdCentro, Filtro.IdEdificio, Filtro.IdSector);
                        celdas.Insert(0, new CeldaOtd { IdCelda = "Todas" });
                        Celdas = celdas;
                    }
                });
            }
        }

        #endregion

        #region Metodos publicos

        #endregion

        #region Metodos Privados

        private void InicializarObjetos()
        {
            InicializarReporteador();
            InicializarEdificios();
            InicializarFiltro();
            //InicializarImputados();
        }

        private void InicializarFiltro()
        {

            Filtro = new ReporteFiltroOtd
            {
                FechaInicial = DateTime.Now,
                FechaFinal = DateTime.Now,
                IdCentro = Sesion.ObjetoDeSesion.IdCentro,
                TipoReporte = _tipoReporte
            };
        }

        private void InicializarEdificios()
        {
            Edificios = _ubicacionServicio.ObtenerEdificiosPorCentro(Sesion.ObjetoDeSesion.IdCentro);
            Edificios.Insert(0, new EdificioOtd { Descripcion = "Todos", IdEdificio = -1 });
        }

        private void InicializarReporteador()
        {
            _reporteador = new ReportViewer();
            _reporteador.ProcessingMode = ProcessingMode.Local;
            ReporteFormHost = new WindowsFormsHost();
            ReporteFormHost.Child = _reporteador;
        }

        private void InicializarImputados()
        {
            Imputados = _personaServicio.BuscarPersonaPorFiltro(new PersonaFiltroOtd { IdCentro = Sesion.ObjetoDeSesion.IdCentro, EsImputado = true });
            Imputados.Insert(0, new PersonaOtd { Nombre = "Todos", Id = -1 });
        }

        private void EjecutarReporte()
        {
            //_reporteador.LocalReport.DataSources.Clear();
            //string reportePath = string.Empty;
            //var reporte = new ReporteGeneralRpt();

            //switch (Filtro.TipoReporte)
            //{
            //    case PaseListaReporteTipo.General:
            //        reporte = _reportesServicio.ReporteIncidenciasGenerales(Filtro);
            //        reportePath = "Reportes/IncidenciaGeneral.rdlc";
            //        break;
            //}

            //_reporteador.LocalReport.ReportPath = reportePath;
            //_reporteador.LocalReport.DataSources.Add(new ReportDataSource("Secciones", reporte.Datos));
            //_reporteador.LocalReport.SetParameters(ActivarEncabezado(reporte.Encabezado));
            //_reporteador.RefreshReport();
        }

        private ReportParameter[] ActivarEncabezado(EncabezadoBaseRpt encabezado)
        {
            ReportParameter[] parameters = new ReportParameter[3];
            parameters[0] = new ReportParameter("Centro", encabezado.Titulo);
            parameters[1] = new ReportParameter("TipoReporte", encabezado.Subtitulo);
            parameters[2] = new ReportParameter("Fechas", encabezado.RangoFechas);

            return parameters;
        }

        #endregion

    }
}