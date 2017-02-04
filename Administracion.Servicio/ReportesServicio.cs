using Administracion.Contratos;
using Administracion.Contratos.Servicios;
using Administracion.Enum;
using Administracion.Modelos;
using Administracion.Modelos.Entidades;
using Administracion.OTD;
using Administracion.OTD.Filtros;
using Administracion.OTD.Reportes;
using Administracion.Utilidades.Autenticacion;
using Administracion.Utilidades.Constantes;
using Administracion.Utilidades.Mapeos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Administracion.Servicio
{
    public class ReportesServicio : ServicioBase, IReportesServicio
    {
        #region Miembros privados
        private readonly IPLProgramadoBitRepositorio _paseListaBitacoraRepositorio;
        private readonly IPLAsignacionResultRepositorio _asignacionResultRepositorio;
        private readonly ICentroRepositorio _centroRepositorio;
        private readonly IPLIncidenciaBitacoraServicio _plIncidenciaBitacoraServicio;
        private readonly ICentroServicio _centroServicio;
        private readonly IUbicacionServicio _ubicacionServicio;
        private readonly IPLProgramadoServicio _plProgramadoServicio;
        private readonly IImputadoServicio _imputadoServicio;
        private readonly IImputadoBiometricoServicio _imputadoBiometricoServicio;
        #endregion

        #region Constructores
        public ReportesServicio(IPLProgramadoBitRepositorio paseListaBitacora, IPLAsignacionResultRepositorio asignacionResultRepositorio, ICentroRepositorio centroRepositorio, IIngresoServicio ingresoServicio, IPLIncidenciaBitacoraServicio plIncidenciaBitacoraServicio, ICentroServicio centroServicio, IUbicacionServicio ubicacionServicio, IPLProgramadoServicio plProgramadoServicio, IImputadoServicio imputadoServicio, IImputadoBiometricoServicio imputadoBiometricoServicio)
        {
            _paseListaBitacoraRepositorio = paseListaBitacora;
            _asignacionResultRepositorio = asignacionResultRepositorio;
            _centroRepositorio = centroRepositorio;
            _plIncidenciaBitacoraServicio = plIncidenciaBitacoraServicio;
            _centroServicio = centroServicio;
            _ubicacionServicio = ubicacionServicio;
            _plProgramadoServicio = plProgramadoServicio;
            _imputadoServicio = imputadoServicio;
            _imputadoBiometricoServicio = imputadoBiometricoServicio;
        }
        #endregion

        public ReporteGeneralRpt ReportePaseListaGeneral(ReporteFiltroOtd filtro)
        {
            try
            {
                //Se crea el reporte con su encabezado correspondiente
                var reporte = new ReporteGeneralRpt
                {
                    Encabezado = ObternerEncabezado(filtro),
                    Datos = new List<RenglonBaseRpt>()
                };

                //Se obtienen los resultados por el centro
                var resultados = _asignacionResultRepositorio.EncontrarPor(ar => ar.ID_CENTRO == filtro.IdCentro
                    && ar.PL_PROGRAMADO_BITACORA.FECHA_EJECUCION >= filtro.FechaInicial
                    && ar.PL_PROGRAMADO_BITACORA.FECHA_EJECUCION <= filtro.FechaFinal);

                if (resultados != null && resultados.Count() > 0)
                {
                    if (filtro.IdEdificio > 0)
                    {
                        resultados = resultados.Where(ar => ar.ID_EDIFICIO == filtro.IdEdificio);
                    }

                    if (filtro.IdSector > 0)
                    {
                        resultados = resultados.Where(ar => ar.ID_SECTOR == filtro.IdSector);
                    }

                    //Se agrupan los resultados por catalogo
                    var pasesDeListaAgrupados = resultados.GroupBy(r => new { r.PL_PROGRAMADO_BITACORA.PL_PROGRAMADO.PL_CATALOGO, r.PL_PROGRAMADO_BITACORA })
                        .Select(r => new { Catalogo = r.Key.PL_CATALOGO, Bitacora = r.Key.PL_PROGRAMADO_BITACORA }).ToList();

                    foreach (var paseDeLista in pasesDeListaAgrupados)
                    {

                        //Se agrupan los datos por edificio
                        var edificios = paseDeLista.Bitacora.PL_ASIGNACION_RESULTADO.GroupBy(a => new { a.EDIFICIO.DESCR, a.PL_PROGRAMADO_BITACORA, a.PL_PROGRAMADO_BITACORA.PL_PROGRAMADO.PL_CATALOGO })
                                                                .Select(a => new { Edificio = a.Key, ResultadosPorCelda = a.Key.PL_PROGRAMADO_BITACORA.PL_ASIGNACION_RESULTADO.ToList() }).ToList();

                        foreach (var edificio in edificios)
                        {
                            //Se crea y asigna el titulo del pase de lista
                            RenglonBaseRpt TituloSeccion = new RenglonBaseRpt();
                            TituloSeccion.PrimeraColumna = string.Format(SSPConst.PLSeccionTitulo, paseDeLista.Catalogo.NOMBRE, paseDeLista.Bitacora.FECHA_EJECUCION.ToString(SSPConst.FechaFormato));
                            TituloSeccion.EsTituloSeccion = true;
                            reporte.Datos.Add(TituloSeccion);

                            //Encabezado de tabla por edificio
                            reporte.Datos.Add(ObtenerEncabezadoDeTabla(edificio.Edificio.DESCR));

                            if (filtro.IdSector > 0)
                            {
                                AgregarCeldas(reporte, edificio.ResultadosPorCelda);
                            }
                            else
                            {
                                AgruparYAgregarPorSectores(reporte, edificio.ResultadosPorCelda);
                            }
                        }
                    }
                }
                return reporte;
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        #region Reporte de Incidencias por Imputado
        public ReporteIncidenciasRpt ReporteIncidenciaPorUbicacion(ReporteFiltroOtd filtro, IList<ImputadoOtd> imputados)
        {
            try
            {
                var reporte = new ReporteIncidenciasRpt();
                GenerarReportPorUbicacion(reporte, filtro, imputados);
                return reporte;
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }


        /// <summary>
        /// Genera el reporte para incidencias por imputado
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public ReporteIncidenciasRpt ReporteIncidenciasPorInterno(ReporteFiltroOtd filtro)
        {
            try
            {
                if (filtro.Imputado == null)
                {
                    throw new Exception("El Imputado es requerido");
                }

                var reporte = new ReporteIncidenciasRpt();
                GenerarReportePorImputado(reporte, filtro);
                return reporte;
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }
        #endregion

        #region Metodos privados
        private void AgruparYAgregarPorSectores(ReporteGeneralRpt reporte, IList<PL_ASIGNACION_RESULTADO> resultadosPorCelda)
        {
            var sectores = ObtenerSectores(resultadosPorCelda);
            var sectoresAgrupados = resultadosPorCelda.GroupBy(resultado => resultado.SECTOR.DESCR,
                      (key, group) => new { Sector = key, PLAsignacionesResultados = group.ToList() }).ToList();
            foreach (var sector in sectoresAgrupados)
            {
                int asisTotales = 0;
                int faltasTotales = 0;
                int asisPorSector = int.Parse(sector.PLAsignacionesResultados.Sum(s => s.ASISTENCIAS.HasValue ? s.ASISTENCIAS.Value : 0).ToString());
                int faltasPorSector = int.Parse(sector.PLAsignacionesResultados.Sum(s => s.INASISTENCIAS.HasValue ? s.INASISTENCIAS.Value : 0).ToString());
                bool esPrimerRenglon = true;
                foreach (var asignacion in sector.PLAsignacionesResultados)
                {
                    //Creacion de la tabla por sectores
                    var horaInicial = asignacion.HORA_INICIAL;
                    var horaFinal = asignacion.HORA_FINAL;

                    reporte.Datos.Add(new RenglonBaseRpt
                    {
                        PrimeraColumna = string.Format("{0}", esPrimerRenglon ? sector.Sector : string.Empty),
                        CuartaColumna = horaInicial.HasValue ? horaInicial.Value.ToString(SSPConst.HoraFormato) : string.Empty,
                        QuintaColumna = horaFinal.HasValue ? horaFinal.Value.ToString(SSPConst.HoraFormato) : string.Empty,
                        SextaColumna = asignacion.ASISTENCIAS.GetValueOrDefault().ToString(),
                        SeptimaColumna = asignacion.INASISTENCIAS.GetValueOrDefault().ToString(),
                        OctavaColumna = (asisPorSector + faltasPorSector).ToString()
                    });

                    asisTotales = asisTotales + asisPorSector;
                    faltasTotales = faltasTotales + faltasPorSector;
                    esPrimerRenglon = false;
                }

                //Se agrega el total de asistencias y totales a la tabla
                reporte.Datos.Add(ObtenerPieDeTabla(asisTotales, faltasTotales));
            }
        }

        private void AgregarCeldas(ReporteGeneralRpt reporte, IList<PL_ASIGNACION_RESULTADO> resultadosPorCelda)
        {
            int asisTotales = 0;
            int faltasTotales = 0;

            foreach (var celda in resultadosPorCelda)
            {
                int asistencia = celda.ASISTENCIAS.HasValue ? int.Parse(celda.ASISTENCIAS.ToString()) : 0;
                int faltas = celda.INASISTENCIAS.HasValue ? int.Parse(celda.INASISTENCIAS.ToString()) : 0;

                //Creacion de la tabla por celdas y custodios
                var renglon = new RenglonBaseRpt();
                renglon.PrimeraColumna = string.Format("{0} - {1}", celda.SECTOR.DESCR.Trim(), celda.CELDA.ID_CELDA.Trim());
                renglon.SegundaColumna = string.Format("{0} {1} {2}", celda.PL_PROGRAMADO_ASIGNACION.EMPLEADO.PERSONA.NOMBRE.Trim(), celda.PL_PROGRAMADO_ASIGNACION.EMPLEADO.PERSONA.PATERNO.Trim(), celda.PL_PROGRAMADO_ASIGNACION.EMPLEADO.PERSONA.MATERNO.Trim());
                renglon.CuartaColumna = celda.HORA_INICIAL.HasValue ? celda.HORA_INICIAL.Value.ToString(SSPConst.HoraFormato) : string.Empty;
                renglon.QuintaColumna = celda.HORA_FINAL.HasValue ? celda.HORA_FINAL.Value.ToString(SSPConst.HoraFormato) : string.Empty;
                renglon.SextaColumna = asistencia.ToString();
                renglon.SeptimaColumna = faltas.ToString();
                renglon.OctavaColumna = (asistencia + faltas).ToString();

                reporte.Datos.Add(renglon);

                asisTotales = asisTotales + asistencia;
                faltasTotales = faltasTotales + faltas;
            }

            //Se agrega el total de asistencias y totales a la tabla
            reporte.Datos.Add(ObtenerPieDeTabla(asisTotales, faltasTotales));
        }

        private IOrderedEnumerable<IGrouping<string, PL_ASIGNACION_RESULTADO>> ObtenerSectores(IList<PL_ASIGNACION_RESULTADO> resultados)
        {
            var sectores = from celdas in resultados
                           group celdas by celdas.SECTOR.DESCR into sector
                           orderby sector.Key
                           select sector;

            return sectores;
        }

        private IEnumerable<IGrouping<string, PL_ASIGNACION_RESULTADO>> AgruparPorSector(IEnumerable<PL_ASIGNACION_RESULTADO> resultados)
        {
            var grupos = resultados.GroupBy(g => g.SECTOR.DESCR).OrderBy(s => s.Key).ToList();
            return grupos;
        }

        private EncabezadoBaseRpt ObternerEncabezado(ReporteFiltroOtd filtro)
        {
            return new EncabezadoBaseRpt
            {
                Titulo = string.Format(SSPConst.PLReporteEncabezado, _centroRepositorio.EncontrarPor(c => c.ID_CENTRO == filtro.IdCentro).FirstOrDefault().DESCR.Trim()),
                Subtitulo = SSPConst.PLReporteSubtitulo,
                RangoFechas = string.Format("{0} al {1}", filtro.FechaInicial.ToString(SSPConst.FechaFormato), filtro.FechaFinal.ToString(SSPConst.FechaFormato))
            };
        }

        private RenglonBaseRpt ObtenerEncabezadoDeTabla(string edificio)
        {
            return new RenglonBaseRpt
            {
                PrimeraColumna = edificio.Trim(),
                CuartaColumna = SSPConst.Inicial,
                QuintaColumna = SSPConst.Final,
                SextaColumna = SSPConst.Asistencias,
                SeptimaColumna = SSPConst.Incidencias,
                OctavaColumna = SSPConst.Subtotal,
                EsEncabezadoDeTabla = true,
            };
        }

        private RenglonBaseRpt ObtenerPieDeTabla(int asisTotales, int faltasTotales)
        {
            return new RenglonBaseRpt
             {
                 QuintaColumna = SSPConst.Totales,
                 SextaColumna = asisTotales.ToString(),
                 SeptimaColumna = faltasTotales.ToString(),
                 OctavaColumna = (asisTotales + faltasTotales).ToString(),
                 EsPieDeSeccion = true
             };
        }

        #region Reportes Incidencias

        private ReporteIncidenciasRpt GenerarReportePorImputado(ReporteIncidenciasRpt reporte, ReporteFiltroOtd filtro)
        {
            var fechaFinal = filtro.FechaFinal.AddDays(1).AddMinutes(-1);
            var incidenciasBitacoras = _plIncidenciaBitacoraServicio.EncontrarPor(ib => ib.IdImputado == filtro.Imputado.IdImputado 
                                        && ib.IdCentro == filtro.Imputado.IdCentro && ib.IdAnio == filtro.Imputado.IdAnio
                                        && ib.FechaCreacion >= filtro.FechaInicial
                                        && ib.FechaCreacion <= fechaFinal).ToList();
            reporte.Imputado = filtro.Imputado;

            var plProgramadosCentro = _plProgramadoServicio.EncontrarPor(pl => pl.IdCentro == Sesion.ObjetoDeSesion.IdCentro);
            var imputadosBiometricos = _imputadoBiometricoServicio.EncontrarPor(ib => ib.IdImputado == filtro.Imputado.IdImputado && ib.IdCentro == filtro.Imputado.IdCentro && ib.IdTipoBiometrico == (short)TipoBiometrico.FotoFrenteRegistro);

            GenerarDatosPorImputado(reporte, incidenciasBitacoras, plProgramadosCentro, imputadosBiometricos);

            return reporte;
        }

        private ReporteIncidenciasRpt GenerarReportPorUbicacion(ReporteIncidenciasRpt reporte, ReporteFiltroOtd filtro, IList<ImputadoOtd> imputados)
        {
            var incidenciasBitacoras = new List<PLIncidenciaBitacoraOtd>();
            var edificio = new EdificioOtd();
            bool filtrado = false;

            if (!string.IsNullOrWhiteSpace(filtro.IdCelda) && filtro.IdCelda != "Todas")
            {
                incidenciasBitacoras = _plIncidenciaBitacoraServicio.EncontrarPor(ib => ib.IdEdificio == filtro.IdEdificio 
                                        && ib.IdSector == filtro.IdSector 
                                        && ib.IdCelda == filtro.IdCelda).ToList();
                filtrado = true;
            }

            if (filtro.IdSector > default(int) && !filtrado)
            {
                incidenciasBitacoras = _plIncidenciaBitacoraServicio.EncontrarPor(ib => ib.IdEdificio == filtro.IdEdificio && ib.IdSector == filtro.IdSector).ToList();
                filtrado = true;
            }

            if (filtro.IdEdificio > default(int) && !filtrado)
            {
                incidenciasBitacoras = _plIncidenciaBitacoraServicio.EncontrarPor(ib => ib.IdEdificio == filtro.IdEdificio).ToList();
                edificio = _ubicacionServicio.EncontrarEdificiosPor(e => e.IdEdificio == filtro.IdEdificio).SingleOrDefault();
                filtrado = true;
            }

            var plProgramadosCentro = _plProgramadoServicio.EncontrarPor(pl => pl.IdCentro == Sesion.ObjetoDeSesion.IdCentro);

            if (filtro.IdPLCatalogo > default(int))
            {
                var plProgramadosPL = plProgramadosCentro.Where(plp => plp.IdPLCatalogo == filtro.IdPLCatalogo).ToList();
                incidenciasBitacoras = incidenciasBitacoras.Where(ib => plProgramadosPL.Any(plp => plp.IdPlProgramado == ib.PLProgramadoBitacora.IdPlProgramado)).ToList();
            }

            if (filtro.FechaInicial > default(DateTime))
            {
                incidenciasBitacoras =
                    incidenciasBitacoras.Where(ib => ib.FechaCreacion >= filtro.FechaInicial)
                        .ToList();
            }

            if (filtro.FechaFinal > default(DateTime))
            {
                incidenciasBitacoras =
                    incidenciasBitacoras.Where(
                        ib => ib.FechaCreacion <= filtro.FechaFinal.AddDays(1).AddMinutes(-1))
                        .ToList();
            }


            var imputadosBiometricosCentro = _imputadoBiometricoServicio.EncontrarPor(ib => ib.IdCentro == Sesion.ObjetoDeSesion.IdCentro && ib.IdTipoBiometrico == (short)TipoBiometrico.FotoFrenteRegistro, true);

            GenerarDatosPorUbicacion(reporte, incidenciasBitacoras, plProgramadosCentro, imputadosBiometricosCentro, imputados);
            return reporte;
        }

        private void GenerarDatosPorImputado(ReporteIncidenciasRpt reporte, IList<PLIncidenciaBitacoraOtd> incidenciasBitacoras, IList<PLProgramadoOtd> plProgramadosCentro, IList<ImputadoBiometricoOtd> imputadosBiometricos)
        {
            foreach (var incidenciaBitacora in incidenciasBitacoras)
            {
                var plProgramado = plProgramadosCentro.FirstOrDefault(plp => plp.IdPlProgramado == incidenciaBitacora.PLProgramadoBitacora.IdPlProgramado);
                var imputadoBiometrico = imputadosBiometricos.FirstOrDefault(ib => ib.IdImputado == incidenciaBitacora.IdImputado && ib.IdCentro == incidenciaBitacora.IdCentro);
                reporte.Datos.Add(new RenglonBaseRpt
                {
                    PrimeraColumna = incidenciaBitacora.FechaCreacion.GetValueOrDefault().ToShortDateString(),
                    SegundaColumna = plProgramado.PLCatalogo.Nombre,
                    TerceraColumna = incidenciaBitacora.Incidencia.Descripcion,
                    CuartaColumna = string.Format("{0} - {1} - {2}", incidenciaBitacora.Celda.Sector.Edificio.Descripcion.Trim(), incidenciaBitacora.Celda.Sector.Descripcion.Trim(), incidenciaBitacora.Celda.IdCelda.Trim()),
                    QuintaColumna = incidenciaBitacora.FechaCreacion.GetValueOrDefault().ToShortTimeString(),
                    SextaColumna = incidenciaBitacora.Estatus,
                    SeptimaColumna = incidenciaBitacora.Observaciones,
                    FotoImputado = imputadoBiometrico != null ? imputadoBiometrico.Biometrico : null
                });
            }
        }

        private void GenerarDatosPorUbicacion(ReporteIncidenciasRpt reporte, IList<PLIncidenciaBitacoraOtd> incidenciasBitacoras, IList<PLProgramadoOtd> plProgramadosCentro, IList<ImputadoBiometricoOtd> imputadosBiometricos, IList<ImputadoOtd> imputados)
        {
            foreach (var incidenciaBitacora in incidenciasBitacoras)
            {
                var plProgramado = plProgramadosCentro.SingleOrDefault(plp => plp.IdPlProgramado == incidenciaBitacora.PLProgramadoBitacora.IdPlProgramado);
                var imputadoBiometrico = imputadosBiometricos.FirstOrDefault(ib => ib.IdImputado == incidenciaBitacora.IdImputado && ib.IdCentro == incidenciaBitacora.IdCentro);
                var imputado = imputados.FirstOrDefault(i => i.IdImputado == incidenciaBitacora.IdImputado && i.IdAnio == incidenciaBitacora.IdAnio && i.IdCentro == i.IdCentro);
                reporte.Datos.Add(new RenglonBaseRpt
                {
                    PrimeraColumna = incidenciaBitacora.FechaCreacion.GetValueOrDefault().ToShortDateString(),
                    SegundaColumna = string.Format("{0} {1} {2}", imputado.Nombre != null ? imputado.Nombre.Trim() : string.Empty, imputado.Paterno != null ? imputado.Paterno.Trim() : string.Empty, imputado.Materno != null ? imputado.Materno.Trim() : string.Empty),
                    TerceraColumna = incidenciaBitacora.Incidencia.Descripcion.Trim(),
                    CuartaColumna = string.Format("{0} - {1} - {2}", incidenciaBitacora.Celda.Sector.Edificio.Descripcion.Trim(), incidenciaBitacora.Celda.Sector.Descripcion.Trim(), incidenciaBitacora.Celda.IdCelda.Trim()),
                    QuintaColumna = plProgramado.PLCatalogo.Nombre,
                    FotoImputado = imputadoBiometrico != null ? imputadoBiometrico.Biometrico : null
                });
            }

            reporte.Datos = reporte.Datos.OrderBy(i => i.QuintaColumna).ToList();
        }
        #endregion

        #region Reporte Pase De Lista v2
        public ReporteGeneralRpt ReportePaseLista(ReporteFiltroOtd filtro)
        {
            try
            {
                var reporte = new ReporteGeneralRpt
                {
                    Encabezado = ObternerEncabezado(filtro),
                    Datos = new List<RenglonBaseRpt>()
                };

                filtro.FechaFinal = filtro.FechaFinal.AddHours(23).AddMinutes(59);

                var asignacionResultados = _asignacionResultRepositorio.EncontrarPor(ar => ar.ID_CENTRO == filtro.IdCentro
                    && ar.PL_PROGRAMADO_BITACORA.FECHA_EJECUCION >= filtro.FechaInicial
                    && ar.PL_PROGRAMADO_BITACORA.FECHA_EJECUCION <= filtro.FechaFinal);

                if (filtro.IdEdificio > default(int))
                {
                    asignacionResultados = asignacionResultados.Where(ar => ar.ID_EDIFICIO == filtro.IdEdificio);
                }

                if (filtro.IdSector > default(int))
                {
                    asignacionResultados = asignacionResultados.Where(ar => ar.ID_SECTOR == filtro.IdSector);
                }

                var resultados = asignacionResultados.ToList();


                // Agrupacion por pase de lista
                //Se agrupan los resultados por catalogo
                var asignacionResultadosPorPL = resultados.GroupBy(resultado => resultado.PL_PROGRAMADO_ASIGNACION.PL_PROGRAMADO.PL_CATALOGO.ID_PL_CATALOGO,
                      (key, group) => new { PLCatalogo = key, PLAsignacionesResultados = group.ToList() }).ToList();

                foreach (var paseLista in asignacionResultadosPorPL)
                {
                    if (paseLista.PLAsignacionesResultados.Any())
                    {
                        var paseDeListaCatalogo = resultados.FirstOrDefault(ar => ar.PL_PROGRAMADO_ASIGNACION.PL_PROGRAMADO.ID_PL_CATALOGO == paseLista.PLCatalogo).PL_PROGRAMADO_ASIGNACION.PL_PROGRAMADO.PL_CATALOGO;
                        AgregarEncabezadoPaseLista(paseDeListaCatalogo, reporte);
                        // Agrupacion por edificio
                        var asignacionesResultadosPorEdificio = paseLista.PLAsignacionesResultados.GroupBy(resultado => resultado.ID_EDIFICIO,
                          (key, group) => new { IdEdificio = key, PLAsignacionesResultados = group.ToList() }).ToList();

                        foreach (var asignacionPorEdificio in asignacionesResultadosPorEdificio)
                        {
                            var edificio = asignacionPorEdificio.PLAsignacionesResultados.FirstOrDefault(ar => ar.ID_EDIFICIO == asignacionPorEdificio.IdEdificio).EDIFICIO;
                            AgregarEncabezadoEdificio(edificio, reporte);
                            PaseDeListaPorEdificio(reporte, paseDeListaCatalogo, asignacionPorEdificio.PLAsignacionesResultados, filtro);
                            AgregarTotalesPorEdificio(reporte, asignacionPorEdificio.PLAsignacionesResultados);
                        }
                    }
                }

                return reporte;
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        private void PaseDeListaPorEdificio(ReporteGeneralRpt reporte, PL_CATALOGO paseDeLista, List<PL_ASIGNACION_RESULTADO> plAsignacionResultados, ReporteFiltroOtd filtro)
        {
            var renglones = new List<RenglonBaseRpt>();
            // Agrupacion por sector
            var plAsignacionResultadosPorSector = plAsignacionResultados.GroupBy(resultado => resultado.ID_SECTOR,
                      (key, group) => new { IdSector = key, PLAsignacionesResultados = group.ToList() }).ToList();

            foreach (var sectorAgrupacion in plAsignacionResultadosPorSector)
            {
                if (filtro.IdSector > default(int))
                {
                    foreach (var plAsignacionResultado in plAsignacionResultados)
                    {
                        var plProgramadoAsignacion = plAsignacionResultado.PL_PROGRAMADO_ASIGNACION;
                        var asistencias = plAsignacionResultado.ASISTENCIAS.GetValueOrDefault();
                        var inasistencias = plAsignacionResultado.INASISTENCIAS.GetValueOrDefault();
                        reporte.Datos.Add(new RenglonBaseRpt
                            {
                                PrimeraColumna = plAsignacionResultado.SECTOR.DESCR.Trim(),
                                SegundaColumna = plAsignacionResultado.CELDA.ID_CELDA.Trim(),
                                TerceraColumna = string.Format("{0} {1} {2}", plProgramadoAsignacion.EMPLEADO.PERSONA.NOMBRE.Trim(), plProgramadoAsignacion.EMPLEADO.PERSONA.PATERNO.Trim(), plProgramadoAsignacion.EMPLEADO.PERSONA.MATERNO.Trim()),
                                CuartaColumna = plAsignacionResultado.HORA_INICIAL.HasValue ? plAsignacionResultado.HORA_INICIAL.Value.ToString(SSPConst.HoraFormato) : string.Empty,
                                QuintaColumna = plAsignacionResultado.HORA_FINAL.HasValue ? plAsignacionResultado.HORA_FINAL.Value.ToString(SSPConst.HoraFormato) : string.Empty,
                                SextaColumna = asistencias.ToString(),
                                SeptimaColumna = inasistencias.ToString(),
                                OctavaColumna = (asistencias + inasistencias).ToString()
                            });
                    }
                }
                else
                {
                    var asistencias = sectorAgrupacion.PLAsignacionesResultados.Sum(ar => ar.ASISTENCIAS.GetValueOrDefault());
                    var inasistencias = sectorAgrupacion.PLAsignacionesResultados.Sum(ar => ar.INASISTENCIAS.GetValueOrDefault());
                    var sector = plAsignacionResultados.FirstOrDefault(ar => ar.ID_SECTOR == sectorAgrupacion.IdSector).SECTOR;
                    //Creacion de la tabla por sectores
                    var horaInicial = sectorAgrupacion.PLAsignacionesResultados.OrderBy(s => s.HORA_INICIAL).FirstOrDefault().HORA_INICIAL;
                    var horaFinal = sectorAgrupacion.PLAsignacionesResultados.OrderBy(s => s.HORA_FINAL).LastOrDefault().HORA_FINAL;
                    reporte.Datos.Add(new RenglonBaseRpt
                    {
                        PrimeraColumna = string.Format("{0}", sector.DESCR.Trim()),
                        CuartaColumna = horaInicial.HasValue ? horaInicial.Value.ToString(SSPConst.HoraFormato) : string.Empty,
                        QuintaColumna = horaFinal.HasValue ? horaFinal.Value.ToString(SSPConst.HoraFormato) : string.Empty,
                        SextaColumna = asistencias.ToString(),
                        SeptimaColumna = inasistencias.ToString(),
                        OctavaColumna = (asistencias + inasistencias).ToString()
                    });
                }
            }
        }

        private void AgregarEncabezadoPaseLista(PL_CATALOGO paselista, ReporteGeneralRpt reporte)
        {
            reporte.Datos.Add(new RenglonBaseRpt
                {
                    PrimeraColumna = paselista.NOMBRE.Trim(),
                    EsEncabezadoDeTabla = true
                });
        }

        private void AgregarEncabezadoEdificio(EDIFICIO edificio, ReporteGeneralRpt reporte)
        {
            reporte.Datos.Add(new RenglonBaseRpt
                {
                    CuartaColumna = "INICIAL",
                    QuintaColumna = "FINAL",
                    SextaColumna = "ASISTENCIA",
                    SeptimaColumna = "INCIDENCIA",
                    OctavaColumna = "SUBTOTAL",
                    PrimeraColumna = edificio.DESCR.Trim(),
                    EsTituloSeccion = true
                });
        }

        private void AgregarTotalesPorEdificio(ReporteGeneralRpt reporte, List<PL_ASIGNACION_RESULTADO> asignacionResultados)
        {
            var asistenciasTotales = asignacionResultados.Sum(ar => ar.ASISTENCIAS.GetValueOrDefault());
            var inasistenciasTotales = asignacionResultados.Sum(ar => ar.INASISTENCIAS.GetValueOrDefault());

            reporte.Datos.Add(new RenglonBaseRpt
                {
                    QuintaColumna = "Totales",
                    SextaColumna = asistenciasTotales.ToString(),
                    SeptimaColumna = inasistenciasTotales.ToString(),
                    OctavaColumna = (asistenciasTotales + inasistenciasTotales).ToString(),
                    EsPieDeSeccion = true
                });
        }
        #endregion
        #endregion
    }
}