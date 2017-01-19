using Administracion.Contratos;
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
    /// Servicio para la tabla 'INGRESO'
    /// </summary>
    public class IngresoServicio : ServicioBase, IIngresoServicio
    {
        #region Miembros privados
        private IIngresoRepositorio _ingresoRepositorio;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por default
        /// </summary>
        public IngresoServicio()
        {
            _ingresoRepositorio = new IngresoRepositorio();
        }

        /// <summary>
        /// Constructor para mockeo de repositorio en pruebas
        /// </summary>
        /// <param name="repositorio"></param>
        public IngresoServicio(IIngresoRepositorio repositorio)
        {
            _ingresoRepositorio = repositorio;
        }
        #endregion

        #region Metodos publicos
        /// <summary>
        /// Crea un nuevo Ingreso dado un IngresoOtd
        /// </summary>
        /// <param name="Ingreso">Ingreso a insertar</param>
        /// <returns></returns>
        public IngresoOtd CrearIngreso(IngresoOtd Ingreso)
        {
            try
            {
                var entidad = IngresoMapeos.MapearEntidad(Ingreso);
                return IngresoMapeos.MapearModelo(_ingresoRepositorio.Insertar(entidad));
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        /// <summary>
        /// Obtiene un listado de Ingresos
        /// </summary>
        /// <returns></returns>
        public IList<IngresoOtd> ObtenerIngresos()
        {
            try
            {
                return IngresoMapeos.MapearListaDeModelos(_ingresoRepositorio.ObtenerTodos().ToList());
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        /// <summary>
        /// Modifica un Ingreso dado un IngresoOtd
        /// </summary>
        /// <param name="Ingreso">Ingreso a modificar</param>
        public void ModificarIngreso(IngresoOtd ingreso)
        {
            try
            {
                var entidad = IngresoMapeos.MapearEntidad(ingreso);
                _ingresoRepositorio.Actualizar(entidad);
                _ingresoRepositorio.Guardar();
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        /// <summary>
        /// Obtiene un listado de IngresoModel dada una expresion
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public IList<IngresoOtd> EncontrarPor(Expression<Func<IngresoOtd, bool>> expression)
        {
            try
            {
                var nuevaExpression = GeneradorDePredicados.Convertir<IngresoOtd, INGRESO>(expression);
                return IngresoMapeos.MapearListaDeModelos(_ingresoRepositorio.EncontrarPor(nuevaExpression).ToList());
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }
        #endregion
    }
}
