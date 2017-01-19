using Administracion.Contratos.Repositorio;
using Administracion.Contratos.Servicios;
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
    /// <summary>
    /// Servicio para la tabla 'PASELISTA_CATALOGO_ESTATUS'
    /// </summary>
    public class PLCatalogoEstatusRepositorio : ServicioBase, IPLCatalogoEstatusServicio
    {
        #region Miembros privados

        private IPLCatalogoEstatusRepositorio _paseDeListaCatalogoEstatusRepositorio;

        #endregion

        #region Constructores

        public PLCatalogoEstatusRepositorio(IPLCatalogoEstatusRepositorio repositorio)
        {
            _paseDeListaCatalogoEstatusRepositorio = repositorio;
        }

        #endregion

        #region Metodos publicos
        /// <summary>
        /// Obtiene un listado de PaseDeListaCatalogoEstatuss
        /// </summary>
        /// <returns></returns>
        public IList<PLCatalogoEstatusOtd> ObtenerPaseDeListaCatalogoEstatus()
        {
            try
            {
                return PLCatalogoMapeos.MapearListaDeModelos(_paseDeListaCatalogoEstatusRepositorio.ObtenerTodos().ToList());
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        /// <summary>
        /// Obtiene un listado de PaseDeListaCatalogoEstatusModel dada una expresion
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public IList<PLCatalogoEstatusOtd> EncontrarPor(Expression<Func<PLCatalogoEstatusOtd, bool>> expression)
        {
            try
            {
                var nuevaExpression = GeneradorDePredicados.Convertir<PLCatalogoEstatusOtd, PL_CATALOGO_ESTATUS>(expression);
                return PLCatalogoMapeos.MapearListaDeModelos(_paseDeListaCatalogoEstatusRepositorio.EncontrarPor(nuevaExpression).ToList());
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        #endregion
    }
}
