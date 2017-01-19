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
    public class PLProgramadoAsignacionServicio : ServicioBase, IPLProgramadoAsignacionServicio
    {
        #region Miembros privados
        private IPLProgramadoAsignacionRepositorio _plProgramadoAsignacionRepositorio;
        #endregion

        #region Constructores
        public PLProgramadoAsignacionServicio(IPLProgramadoAsignacionRepositorio repositorio)
        {
            _plProgramadoAsignacionRepositorio = repositorio;
        }
        #endregion

        #region Metodos publicos
        /// <summary>
        /// Crea una nueva asignacion dado un PLProgramadoAsignacionOtd
        /// </summary>
        /// <param name="paseDeListaProgramadoAsignacionAsignacion">PaseDeListaCatalogo a insertar</param>
        /// <returns></returns>
        public PLProgramadoAsignacionOtd CrearPaseDelistaProgramadoAsignacion(PLProgramadoAsignacionOtd paseDeListaProgramadoAsignacion)
        {
            try
            {
                var entidad = PLProgramadoAsignacionMapeos.MapearEntidad(paseDeListaProgramadoAsignacion);
                return PLProgramadoAsignacionMapeos.MapearModelo(_plProgramadoAsignacionRepositorio.Insertar(entidad));
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        /// <summary>
        /// Obtiene un listado de asignaciones Disponibles
        /// </summary>
        /// <returns></returns>
        public IList<PLProgramadoAsignacionOtd> ObtenerPasesDelistaProgramadoAsignacion()
        {
            try
            {
                return PLProgramadoAsignacionMapeos.MapearListaDeModelos(_plProgramadoAsignacionRepositorio.ObtenerTodos().ToList());
            }
            catch (Exception ex)
            {

                throw ObtenerFalla(ex);
            }
        }

        /// <summary>
        /// Modifica una asignacion dado un PLProgramadoAsignacionOtd
        /// </summary>
        /// <param name="paseDeListaProgramadoAsignacionAsignacion">PaseDeListaCatalogo a modificar</param>
        public void ModificarPaseDelistaProgramadoAsignacion(PLProgramadoAsignacionOtd paseDeListaProgramadoAsignacionAsignacion)
        {
            try
            {
                var entidad = PLProgramadoAsignacionMapeos.MapearEntidad(paseDeListaProgramadoAsignacionAsignacion);
                _plProgramadoAsignacionRepositorio.Actualizar(entidad);
                _plProgramadoAsignacionRepositorio.Guardar();
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        /// <summary>
        /// Obtiene un listado de asignaciones dada una expresion
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public IList<PLProgramadoAsignacionOtd> EncontrarPor(Expression<Func<PLProgramadoAsignacionOtd, bool>> expression)
        {
            try
            {
                var nuevaExpression = GeneradorDePredicados.Convertir<PLProgramadoAsignacionOtd, PL_PROGRAMADO_ASIGNACION>(expression);
                return PLProgramadoAsignacionMapeos.MapearListaDeModelos(_plProgramadoAsignacionRepositorio.EncontrarPor(nuevaExpression).ToList());
            }
            catch (Exception ex)
            {
                 throw ObtenerFalla(ex);
            }
        }
        #endregion
    }
}
