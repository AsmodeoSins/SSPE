using Administracion.Contratos;
using Administracion.Modelos;
using Administracion.OTD;
using Administracion.Repositorio.Accesso;
using Administracion.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Administracion.Servicio
{
    /// <summary>
    /// Servicio para la tabla 'expediente'
    /// </summary>
    public class ExpedienteServicio : ServicioBase, IExpedienteServicio
    {
        #region Miembros privados
        private IExpedienteRepositorio _expedienteRepositorio;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por default
        /// </summary>
        public ExpedienteServicio()
        {
            _expedienteRepositorio = new ExpedienteRepositorio();
        }

        /// <summary>
        /// Constructor para pruebas unitarias
        /// </summary>
        /// <param name="repositorio"></param>
        public ExpedienteServicio(IExpedienteRepositorio repositorio)
        {
            _expedienteRepositorio = repositorio;
        }
        #endregion

        #region Metodos publicos
        /// <summary>
        /// Crea un nuevo expediente dado un ExpedienteModelo
        /// </summary>
        /// <param name="expediente">Expediente a insertar</param>
        /// <returns>Entidad insertada</returns>
        public ExpedienteModelo CrearExpediente(ExpedienteModelo expediente)
        {
            try
            {
                _expedienteRepositorio.Insertar(expediente);
                return expediente;
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }  
        }

        /// <summary>
        /// Obtiene un listado de expedientes
        /// </summary>
        /// <returns></returns>
        public IList<ExpedienteModelo> ObtenerExpedientes()
        {
            try 
	        {
                return _expedienteRepositorio.ObtenerTodos().ToList();
	        }
	        catch (Exception e)
	        {
                throw ObtenerFalla(e);
	        }
            
        }

        /// <summary>
        /// Modifica un expediente dado un ExpedienteModelo
        /// </summary>
        /// <param name="expediente">Expediente a modificar</param>
        public void ModificarExpediente(ExpedienteModelo expediente)
        {
            try
            {
                _expedienteRepositorio.Actualizar(expediente);
                _expedienteRepositorio.Guardar();
            }
            catch (Exception ex)
            {
                
                throw ObtenerFalla(ex);
            }
        }

        /// <summary>
        /// Obtiene un listado de ExpedienteModel dada una expresion
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public IList<ExpedienteModelo> EncontrarPor(Expression<Func<ExpedienteModelo, bool>> expression)
        {
            try
            {
                return _expedienteRepositorio.EncontrarPor(expression).ToList();
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }
        #endregion
    }
}
