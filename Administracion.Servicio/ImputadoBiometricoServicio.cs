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
    /// Servicio para la tabla 'IMPUTADO_BIOMETRICO'
    /// </summary>
    public class ImputadoBiometricoServicio : ServicioBase, IImputadoBiometricoServicio
    {
        #region Miembros privados
        private IImputadoBiometricoRepositorio _imputadoBiometricoRepositorio;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por default
        /// </summary>
        public ImputadoBiometricoServicio()
        {
            _imputadoBiometricoRepositorio = new ImputadoBiometricoRepositorio();
        }

        /// <summary>
        /// Constructor para mockeo de repositorio en pruebas
        /// </summary>
        /// <param name="repositorio"></param>
        public ImputadoBiometricoServicio(IImputadoBiometricoRepositorio repositorio)
        {
            _imputadoBiometricoRepositorio = repositorio;
        }
        #endregion

        #region Metodos publicos
        /// <summary>
        /// Crea un nuevo Imputado dado un ImputadoModelo
        /// </summary>
        /// <param name="ImputadoBiometrico">ImputadoBiometrico a insertar</param>
        /// <returns></returns>
        public ImputadoBiometricoOtd CrearImputadoBiometrico(ImputadoBiometricoOtd imputadoBiometrico)
        {
            try
            {
                var entidad = ImputadoBiometricoMapeos.MapearEntidad(imputadoBiometrico);
                return ImputadoBiometricoMapeos.MapearModelo(_imputadoBiometricoRepositorio.Insertar(entidad));
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        /// <summary>
        /// Obtiene un listado de ImputadosBiometricos
        /// </summary>
        /// <returns></returns>
        public IList<ImputadoBiometricoOtd> ObtenerImputadosBiometricos(bool desactivarLazyLoading = false)
        {
            try
            {
                if (desactivarLazyLoading)
                {
                    _imputadoBiometricoRepositorio.DesactivarLazyLoading();
                }
                var resultado = ImputadoBiometricoMapeos.MapearListaDeModelos(_imputadoBiometricoRepositorio.ObtenerTodos().ToList());
                _imputadoBiometricoRepositorio.ActivarLazyLoading();
                return resultado;
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        /// <summary>
        /// Modifica un Imputado dado un ImputadoBiometricoOtd
        /// </summary>
        /// <param name="Imputado">ImputadoBiometrico a modificar</param>
        public void ModificarImputadoBiometrico(ImputadoBiometricoOtd imputadoBiometrico)
        {
            try
            {
                var entidad = ImputadoBiometricoMapeos.MapearEntidad(imputadoBiometrico);
                _imputadoBiometricoRepositorio.Actualizar(entidad);
                _imputadoBiometricoRepositorio.Guardar();
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        /// <summary>
        /// Obtiene un listado de ImputadoBiometricoOtd dada una expresion
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public IList<ImputadoBiometricoOtd> EncontrarPor(Expression<Func<ImputadoBiometricoOtd, bool>> expression, bool desactivarLazyLoading = false)
        {
            try
            {
                if(desactivarLazyLoading)
                { 
                    _imputadoBiometricoRepositorio.DesactivarLazyLoading();
                }
                var nuevaExpression = GeneradorDePredicados.Convertir<ImputadoBiometricoOtd, IMPUTADO_BIOMETRICO>(expression);
                var imputadoBiometricos =  ImputadoBiometricoMapeos.MapearListaDeModelos(_imputadoBiometricoRepositorio.EncontrarPor(nuevaExpression).ToList());
                _imputadoBiometricoRepositorio.ActivarLazyLoading();
                return imputadoBiometricos;
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }
        #endregion
    }
}
