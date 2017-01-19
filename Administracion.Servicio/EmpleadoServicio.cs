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
using System.Text;

namespace Administracion.Servicio
{
    public class EmpleadoServicio : ServicioBase, IEmpleadoServicio
    {
        #region Miembros privados
        IEmpleadoRepositorio _empleadoRepositorio;
        #endregion

        #region Constructores
        public EmpleadoServicio()
        {
            _empleadoRepositorio = new EmpleadoRepositorio();
        }
        /// <summary>
        /// Constructor para inyeccion de dependencias
        /// </summary>
        /// <param name="empleadoRepositorio"></param>
        public EmpleadoServicio(IEmpleadoRepositorio empleadoRepositorio)
        {
            _empleadoRepositorio = empleadoRepositorio;
        }
        #endregion

        #region Metodos publicos
        /// <summary>
        /// Obtiene un listado de empleados Disponibles
        /// </summary>
        /// <returns></returns>
        public IList<EmpleadoOtd> ObtenerEmpleados()
        {
            return EmpleadoMapeos.MapearListaDeModelos(_empleadoRepositorio.ObtenerTodos().ToList());
        }

        /// <summary>
        /// Obtiene un listado de empleados dada una expresion
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public IList<EmpleadoOtd> EncontrarPor(Expression<Func<EmpleadoOtd, bool>> expression)
        {
            try
            {
                var nuevaExpression = GeneradorDePredicados.Convertir<EmpleadoOtd, EMPLEADO>(expression);
                return EmpleadoMapeos.MapearListaDeModelos(_empleadoRepositorio.EncontrarPor(nuevaExpression).ToList());
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }
        #endregion
    }
}
