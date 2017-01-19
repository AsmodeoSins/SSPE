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
    public class PLProgramadoServicio: ServicioBase, IPLProgramadoServicio
    {
        #region Miembros privados
        private IPLProgramadoRepositorio _plProgrmadaRepositorio;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor para inyeccion de repositorio
        /// </summary>
        /// <param name="plProgramadoRepositorio"></param>
        public PLProgramadoServicio(IPLProgramadoRepositorio plProgramadoRepositorio)
        {
            _plProgrmadaRepositorio = plProgramadoRepositorio;
        }
        #endregion

        #region Metodos publicos
        /// <summary>
        /// Crea un nuevo Imputado dado un PaseDeListaCatalogoOtd
        /// </summary>
        /// <param name="paseDeListaCatalogo">PaseDeListaCatalogo a insertar</param>
        /// <returns></returns>
        public PLProgramadoOtd CrearPaseDelistaProgramado(PLProgramadoOtd paseDeListaProgramado)
        {
            try
            {
                var entidad = PLProgramadoMapeos.MapearEntidad(paseDeListaProgramado);
                return PLProgramadoMapeos.MapearModelo(_plProgrmadaRepositorio.Insertar(entidad));
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        /// <summary>
        /// Obtiene un listado de Catalogos Disponibles
        /// </summary>
        /// <returns></returns>
        public IList<PLProgramadoOtd> ObtenerPasesDelistaProgramados()
        {
            try
            {
                return PLProgramadoMapeos.MapearListaDeModelos(_plProgrmadaRepositorio.ObtenerTodos().ToList());
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        /// <summary>
        /// Modifica un Imputado dado un PaseDeListaCatalogoOtd
        /// </summary>
        /// <param name="paseDeListaCatalogo">PaseDeListaCatalogo a modificar</param>
        public void ModificarPaseDelistaProgramado(PLProgramadoOtd paseDeListaProgramado)
        {
            try
            {
                var entidad = PLProgramadoMapeos.MapearEntidad(paseDeListaProgramado);
                _plProgrmadaRepositorio.ActualizarPorId<int>(entidad, entidad.ID_PL_PROGRAMADO);
                _plProgrmadaRepositorio.Guardar();
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
        public IList<PLProgramadoOtd> EncontrarPor(Expression<Func<PLProgramadoOtd, bool>> expression)
        {
            try
            {
                var nuevaExpression = GeneradorDePredicados.Convertir<PLProgramadoOtd, PL_PROGRAMADO>(expression);
                return PLProgramadoMapeos.MapearListaDeModelos(_plProgrmadaRepositorio.EncontrarPor(nuevaExpression).ToList());
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        /// <summary>
        /// Desactiva un pase de lista programado dado un id
        /// </summary>
        /// <param name="paseListaProgramadoId">Id del pase de lista programado a desactivar</param>
        public void DesactivarPaseDeListaProgramado(int paseListaProgramadoId)
        {
            try
            {
                var paseLista = EncontrarPor(pl => pl.IdPlProgramado == paseListaProgramadoId).SingleOrDefault();

                if (paseLista == null)
                {
                    throw new Exception(string.Format("El pase de lista con id {0} no existe", paseListaProgramadoId));
                }

                paseLista.Vigente = 0;
                ModificarPaseDelistaProgramado(paseLista);
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }
        #endregion
    }
}
