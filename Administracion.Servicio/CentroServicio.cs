using Administracion.Contratos;
using Administracion.Contratos.Servicios;
using Administracion.OTD;
using Administracion.Modelos.Entidades;
using Administracion.Repositorio.Accesso;
using Administracion.Utilidades;
using Administracion.Utilidades.Mapeadores;
using Administracion.Utilidades.Mapeos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Administracion.Servicio
{
    /// <summary>
    /// Servicio para la tabla 'CENTRO'
    /// </summary>
    public class CentroServicio : ServicioBase, ICentroServicio
    {
        #region Miembros privados
        ICentroRepositorio _centroRepositorio;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por default
        /// </summary>
        public CentroServicio()
        {
            _centroRepositorio = new CentroRepositorio();
        }

        /// <summary>
        /// Constructor para mockeo de repositorio en pruebas
        /// </summary>
        /// <param name="repositorio"></param>
        public CentroServicio(ICentroRepositorio repositorio)
        {
            _centroRepositorio = repositorio;
        }
        #endregion

        #region Metodos publicos
        /// <summary>
        /// Crea un nuevo Centro dado un CentroOdt
        /// </summary>
        /// <param name="Centro">Centro a insertar</param>
        /// <returns></returns>
        public CentroOtd CrearCentro(CentroOtd centro)
        {
            try
            {
                var centroEntidad = CentroMapeos.MapearEntidad(centro);
                return CentroMapeos.MapearModelo(_centroRepositorio.Insertar(centroEntidad));
            }
            catch (Exception ex)
            {

                throw ObtenerFalla(ex);
            }
        }

        /// <summary>
        /// Obtiene un listado de Centros
        /// </summary>
        /// <returns></returns>
        public IList<CentroOtd> ObtenerCentros()
        {
            try
            {
                return CentroMapeos.MapearListaDeModelos(_centroRepositorio.ObtenerTodos().ToList());
            }
            catch (Exception ex)
            {

                throw ObtenerFalla(ex);
            }
        }

        /// <summary>
        /// Modifica un Centro dado un CentroOdt
        /// </summary>
        /// <param name="Centro">Centro a modificar</param>
        public void ModificarCentro(CentroOtd centro)
        {
            try
            {
                var centroEntidad = CentroMapeos.MapearEntidad(centro);
                _centroRepositorio.Actualizar(centroEntidad);
                _centroRepositorio.Guardar();
            }
            catch (Exception ex)
            {

                throw ObtenerFalla(ex);
            }
        }

        /// <summary>
        /// Obtiene un listado de CentroModel dada una expresion
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public IList<CentroOtd> EncontrarPor(Expression<Func<CentroOtd, bool>> expression)
        {
            try
            {
                var nuevaExpression = GeneradorDePredicados.Convertir<CentroOtd, CENTRO>(expression);
                return CentroMapeos.MapearListaDeModelos(_centroRepositorio.EncontrarPor(nuevaExpression).ToList());
            }
            catch (Exception ex)
            {

                throw ObtenerFalla(ex);
            }
        }
        #endregion
    }
}
