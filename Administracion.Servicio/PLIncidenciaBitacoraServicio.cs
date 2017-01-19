using Administracion.Contratos;
using Administracion.Contratos.Repositorio;
using Administracion.Modelos.Entidades;
using Administracion.OTD;
using Administracion.Utilidades;
using Administracion.Utilidades.Mapeos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Administracion.Servicio
{
    public class PLIncidenciaBitacoraServicio : ServicioBase, IPLIncidenciaBitacoraServicio
    {
        #region Miembros privados
        private IPLIncidenciaBitacoraRepositorio _plIncidenciaBitacoraRepositorio;
        #endregion

        #region Constructores
        public PLIncidenciaBitacoraServicio(IPLIncidenciaBitacoraRepositorio plIncidenciaBitacoraRepositorio)
        {
            _plIncidenciaBitacoraRepositorio = plIncidenciaBitacoraRepositorio;
        }
        #endregion

        #region Metodos publicos
        /// <summary>
        /// Obtiene un listado de bitacoras de incidencias Disponibles
        /// </summary>
        /// <returns></returns>
        public IList<PLIncidenciaBitacoraOtd> ObtenerPLIncidenciasBitacoras()
        {
            try
            {
                return PLIncidenciaBitacoraMapeos.MapearLista(_plIncidenciaBitacoraRepositorio.ObtenerTodos().ToList());
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        /// <summary>
        /// Obtiene un listado de bitacoras de incidencias dada una expresion
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public IList<PLIncidenciaBitacoraOtd> EncontrarPor(Expression<Func<PLIncidenciaBitacoraOtd, bool>> expression)
        {
            try
            {
                var nuevaExpression = GeneradorDePredicados.Convertir<PLIncidenciaBitacoraOtd, PL_INCIDENCIA_BITACORA>(expression);
                return PLIncidenciaBitacoraMapeos.MapearLista(_plIncidenciaBitacoraRepositorio.EncontrarPor(nuevaExpression).ToList());
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }
        #endregion
    }
}
