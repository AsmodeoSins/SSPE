using Administracion.Modelos.Entidades;
using Administracion.OTD.Reportes;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Administracion.Utilidades.Mapeos
{
    public static class ReporteMapeos
    {
        public static IList<SeccionBaseRpt> ReportePLGeneralSecciones(List<IGrouping<PL_CATALOGO, PL_ASIGNACION_RESULTADO>> secciones)
        {
            var seccionesReporte = new List<SeccionBaseRpt>();

            //if (secciones != null && secciones.Count > 0)
            //{
            //    foreach (var seccion in secciones)
            //    {
            //        seccionesReporte.Add(new SeccionBaseRpt
            //        {
            //            Titulo = seccion.Key.NOMBRE,
            //            Tablas = new List<TablaBaseRpt>
            //            {
            //                ObtenerTablaPLReporte()
            //            }
            //        });
            //    }
            //}

            return seccionesReporte;
        }

        private static TablaBaseRpt ObtenerTablaPLReporte()
        {
            return new TablaBaseRpt
            {
                Encabezado = ObtenerEncabezadoPLReporte("EDIFICIO A"),
                Datos = new List<RenglonBaseRpt>()
            };
        }

        private static RenglonBaseRpt ObtenerEncabezadoPLReporte(string edificio)
        {
            return new RenglonBaseRpt
            {
                PrimeraColumna = edificio,
                CuartaColumna = "HORA INICIO",
                QuintaColumna = "HORA FINAL",
                SextaColumna = "ASISTENCIAS",
                SeptimaColumna = "INCIDENCIAS",
                OctavaColumna = "SUBTOTAL",
            };
        }

        public static IList<SeccionBaseRpt> MapearReportePLGeneral(List<PL_ASIGNACION_RESULTADO> resultados)
        {

            List<SeccionBaseRpt> secciones = new List<SeccionBaseRpt>();

            foreach (var resultado in resultados)
            {
                var seccion = new SeccionBaseRpt();

                var titulo = string.Format("PASE DE LISTA {0} {1}", resultado.PL_PROGRAMADO_BITACORA.PL_PROGRAMADO.PL_CATALOGO.DESCR, resultado.PL_PROGRAMADO_BITACORA.FECHA_EJECUCION.ToString("MMM dd yyyy"));

                seccion.Titulo = secciones.Where(s => s.Titulo.Contains(titulo)).Count() < 0 ? titulo : string.Empty;
            }

            var test = resultados.GroupBy(r => r.PL_PROGRAMADO_BITACORA.FECHA_EJECUCION, rl => rl.PL_PROGRAMADO_BITACORA.PL_PROGRAMADO.PL_CATALOGO);
            return Mapper.Map<IList<SeccionBaseRpt>>(resultados);
        }
    }
}
