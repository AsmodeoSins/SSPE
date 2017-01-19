using Administracion.Contratos;
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
    /// Servicio para la tabla 'INCIDENCIA'
    /// </summary>
    public class IncidenciaServicio: ServicioBase, IIncidenciaServicio
    {
        #region Miembros privados
        private IIncidenciaRepositorio _incidenciaRepositorio;
        #endregion
        #region Constructores
        /// <summary>
        /// Constructor por default
        /// </summary>
        public IncidenciaServicio(IIncidenciaRepositorio incidenciaRepositorio)
        {
            _incidenciaRepositorio = incidenciaRepositorio;
        }
        #endregion

        #region Metodos publicos
        /// <summary>
        /// Crea un nuevo Incidencia dado un IncidenciaOtd
        /// </summary>
        /// <param name="incidencia">Incidencia a insertar</param>
        /// <returns></returns>
        public PLIncidenciaCatalogoOtd CrearIncidencia(PLIncidenciaCatalogoOtd incidencia)
        {
            try
            {
                //incidencia.Evento = "A";
                incidencia.FechaModificacion = DateTime.Now;
                var entidad = PLIncidenciaCatalogoMapeos.MapearEntidad(incidencia);
                return PLIncidenciaCatalogoMapeos.MapearModelo(_incidenciaRepositorio.Insertar(entidad));
            }
            catch (Exception ex)
            {

                throw ObtenerFalla(ex);
            }
        }

        /// <summary>
        /// Obtiene un listado de Incidencias
        /// </summary>
        /// <returns></returns>
        public IList<PLIncidenciaCatalogoOtd> ObtenerIncidencias()
        {
            try
            {
                return PLIncidenciaCatalogoMapeos.MapearListaDeModelos(_incidenciaRepositorio.ObtenerTodos().ToList());
            }
            catch (Exception ex)
            {

                throw ObtenerFalla(ex);
            }
        }

        /// <summary>
        /// Modifica un Incidencia dado un IncidenciaOtd
        /// </summary>
        /// <param name="incidencia">Incidencia a modificar</param>
        public void ModificarIncidencia(PLIncidenciaCatalogoOtd incidencia)
        {
            try
            {
                var entidad = PLIncidenciaCatalogoMapeos.MapearEntidad(incidencia);
                _incidenciaRepositorio.ActualizarPorId<int>(entidad, entidad.ID);
                _incidenciaRepositorio.Guardar();
            }
            catch (Exception ex)
            {

                throw ObtenerFalla(ex);
            }
        }

        /// <summary>
        /// Obtiene un listado de IncidenciaModel dada una expresion
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>Lista de incidencias dada una expresion</returns>
        public IList<PLIncidenciaCatalogoOtd> EncontrarPor(Expression<Func<PLIncidenciaCatalogoOtd, bool>> expression)
        {
            try
            {
                var nuevaExpression = GeneradorDePredicados.Convertir<PLIncidenciaCatalogoOtd, PL_INCIDENCIA_CATALOGO>(expression);
                return PLIncidenciaCatalogoMapeos.MapearListaDeModelos(_incidenciaRepositorio.EncontrarPor(nuevaExpression).ToList());
            }
            catch (Exception ex)
            {

                throw ObtenerFalla(ex);
            }
        }
        #endregion
    }
}
