using Administracion.Contratos;
using Administracion.Contratos.Servicios;
using Administracion.Modelos.Entidades;
using Administracion.OTD;
using Administracion.Repositorio.Accesso;
using Administracion.Utilidades;
using Administracion.Utilidades.Mapeos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Administracion.Servicio
{
    /// <summary>
    /// Servicio para la tabla 'IMPUTADO'
    /// </summary>
    public class ImputadoServicio : ServicioBase, IImputadoServicio
    {
        #region Miembros privados
        private IImputadoRepositorio _imputadoRepositorio;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por default
        /// </summary>
        public ImputadoServicio()
        {
            _imputadoRepositorio = new ImputadoRepositorio();
        }

        /// <summary>
        /// Constructor para mockeo de repositorio en pruebas
        /// </summary>
        /// <param name="repositorio"></param>
        public ImputadoServicio(IImputadoRepositorio repositorio)
        {
            _imputadoRepositorio = repositorio;
        }
        #endregion

        #region Metodos publicos

        /// <summary>
        /// Crea un nuevo Imputado dado un ImputadoOtd
        /// </summary>
        /// <param name="Imputado">Imputado a insertar</param>
        /// <returns></returns>
        public ImputadoOtd CrearImputado(ImputadoOtd imputado)
        {
            try
            {
                var entidad = ImputadoMapeos.MapearEntidad(imputado);
                return ImputadoMapeos.MapearModelo(_imputadoRepositorio.Insertar(entidad));
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        /// <summary>
        /// Obtiene un listado de Imputados
        /// </summary>
        /// <returns></returns>
        public IList<ImputadoOtd> ObtenerImputados(bool desactivarLazyLoading = false)
        {
            try
            {
                if (desactivarLazyLoading)
                {
                    _imputadoRepositorio.DesactivarLazyLoading();
                }
                var imputados = ImputadoMapeos.MapearListaDeModelos(_imputadoRepositorio.ObtenerTodos().ToList());
                _imputadoRepositorio.ActivarLazyLoading();
                return imputados;
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        /// <summary>
        /// Modifica un Imputado dado un ImputadoOtd
        /// </summary>
        /// <param name="Imputado">Imputado a modificar</param>
        public void ModificarImputado(ImputadoOtd imputado)
        {
            try
            {
                var entidad = ImputadoMapeos.MapearEntidad(imputado);
                _imputadoRepositorio.Actualizar(entidad);
                _imputadoRepositorio.Guardar();
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        /// <summary>
        /// Obtiene un listado de ImputadoModel dada una expresion
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public IList<ImputadoOtd> EncontrarPor(Expression<Func<ImputadoOtd, bool>> expression, bool desactivarLazyLoading = false)
        {
            try
            {
                if (desactivarLazyLoading)
                {
                    _imputadoRepositorio.DesactivarLazyLoading();
                }
                var nuevaExpression = GeneradorDePredicados.Convertir<ImputadoOtd, IMPUTADO>(expression);
                var imputados = _imputadoRepositorio.EncontrarPor(nuevaExpression);

                if (imputados != null && imputados.Count() > 0)
                {
                    return ImputadoMapeos.MapearListaDeModelos(imputados.ToList());
                }
                _imputadoRepositorio.ActivarLazyLoading();
                return null;
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }
        
        #endregion
    }
}
