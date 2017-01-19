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
    public class ParametroServicio : ServicioBase, IParametroServicio
    {
        #region Miembros privados
        private IParametroRepositorio _parametroRepositorio;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor que recibe el repositorio como argumento
        /// </summary>
        /// <param name="parametroRepositorio"></param>
        public ParametroServicio(IParametroRepositorio parametroRepositorio)
        {
            _parametroRepositorio = parametroRepositorio;
        }
        #endregion

        #region Metodos publicos
        /// <summary>
        /// Crea un nuevo Centro dado un ParametroOtd
        /// </summary>
        /// <param name="parametro">Centro a insertar</param>
        /// <returns></returns>
        public ParametroOtd CrearParametro(ParametroOtd parametro)
        {
            try
            {
                var entidad = ParametroMapeos.MapearEntidad(parametro);
                return ParametroMapeos.MapearModelo(_parametroRepositorio.Insertar(entidad));
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        /// <summary>
        /// Obtiene un listado de Parametro
        /// </summary>
        /// <returns></returns>
        public IList<ParametroOtd> ObtenerParametro()
        {
            try
            {
                return ParametroMapeos.MapearListaDeModelos(_parametroRepositorio.ObtenerTodos().ToList());
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        /// <summary>
        /// Modifica un parametro dado un ParametroOtd
        /// </summary>
        /// <param name="parametro">Centro a modificar</param>
        public void ModificarParametro(ParametroOtd parametro)
        {
            try
            {
                var entidad = ParametroMapeos.MapearEntidad(parametro);
                _parametroRepositorio.ActualizarPorId<int, string>(entidad, parametro.IdCentro, entidad.ID_CLAVE);
                _parametroRepositorio.Guardar();
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        /// <summary>
        /// Obtiene un listado de ParametroOtd dada una expresion
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public IList<ParametroOtd> EncontrarPor(Expression<Func<ParametroOtd, bool>> expression)
        {
            try
            {
                var nuevaExpresion = GeneradorDePredicados.Convertir<ParametroOtd, PARAMETRO>(expression);
                return ParametroMapeos.MapearListaDeModelos(_parametroRepositorio.EncontrarPor(nuevaExpresion).ToList());
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }
        #endregion
    }
}
