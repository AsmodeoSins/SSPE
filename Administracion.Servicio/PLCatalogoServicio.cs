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
    public class PLCatalogoServicio: ServicioBase, IPLCatalogoServicio
    {
        #region Miembros privados
        private IPLCatalogoRepositorio _paseDeListaCatalogoRepositorio;
        #endregion

        #region Constructores
        public PLCatalogoServicio(IPLCatalogoRepositorio repositorio)
        {
            _paseDeListaCatalogoRepositorio = repositorio;
        }
        #endregion

        #region Metodos publicos

        /// <summary>
        /// Crea un nuevo Imputado dado un PaseDeListaCatalogoOtd
        /// </summary>
        /// <param name="paseDeListaCatalogo">PaseDeListaCatalogo a insertar</param>
        /// <returns></returns>
        public PLCatalogoOtd CrearPaseDelistaCatalogo(PLCatalogoOtd paseDeListaCatalogo)
        {
            try
            {
                paseDeListaCatalogo.IdPLCatalgo = (short)(_paseDeListaCatalogoRepositorio.ObtenerTodos().Count() + 1);
                var entidad = PLCatalogoMapeos.MapearEntidad(paseDeListaCatalogo);                
                _paseDeListaCatalogoRepositorio.Insertar(entidad);

                return paseDeListaCatalogo;
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        /// <summary>
        /// Obtiene un listado de pases de lista que no han sido cancelados
        /// </summary>
        /// <returns></returns>
        public IList<PLCatalogoOtd> ObtenerPasesDeListaCatalogo()
        {
            try
            {
                var pasesDeLista = _paseDeListaCatalogoRepositorio.EncontrarPor(c => c.ESTATUS != "CA");

                if (pasesDeLista != null && pasesDeLista.Count() > 0)
                {
                    return PLCatalogoMapeos.MapearListaDeModelos(pasesDeLista.ToList());
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        /// <summary>
        /// Modifica un PaseDeListaCatalogo dado un PLCatalogoOtd
        /// </summary>
        /// <param name="paseDeListaCatalogo">PaseDeListaCatalogo a modificar</param>
        public void ModificarPaseDeListaCatalogo(PLCatalogoOtd paseDeListaCatalogo)
        {
            try
            {
                var entidad = PLCatalogoMapeos.MapearEntidad(paseDeListaCatalogo);
                _paseDeListaCatalogoRepositorio.ActualizarPorId<int>(entidad, entidad.ID_PL_CATALOGO);
                _paseDeListaCatalogoRepositorio.Guardar();
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        /// <summary>
        /// Obtiene un listado de pases de lista dada una expresion
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public IList<PLCatalogoOtd> EncontrarPor(Expression<Func<PLCatalogoOtd, bool>> expression)
        {
            try
            {
                var nuevaExpression = GeneradorDePredicados.Convertir<PLCatalogoOtd, PL_CATALOGO>(expression);
                return PLCatalogoMapeos.MapearListaDeModelos(_paseDeListaCatalogoRepositorio.EncontrarPor(nuevaExpression).ToList());
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }
        #endregion
    }
}
