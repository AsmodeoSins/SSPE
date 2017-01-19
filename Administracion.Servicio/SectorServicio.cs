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
using System.Text;

namespace Administracion.Servicio
{
    public class SectorServicio : ServicioBase, ISectorServicio
    {
        #region Miembros privados
        private ISectorRepositorio _sectorRepositorio;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor para inyeccion de dependicias
        /// </summary>
        public SectorServicio(ISectorRepositorio sectorRepositorio)
        {
            _sectorRepositorio = sectorRepositorio;
        }
        #endregion

        #region Metodos publicos
        /// <summary>
        /// Obtiene un listado de sectores Disponibles
        /// </summary>
        /// <returns></returns>
        public IList<SectorOtd> ObtenerPasesDelistaProgramados()
        {
            try
            {
                return UbicacionMapeos.MapearSectores(_sectorRepositorio.ObtenerTodos().ToList());
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        /// <summary>
        /// Obtiene un listado de sectores dada una expresion
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public IList<SectorOtd> EncontrarPor(Expression<Func<SectorOtd, bool>> expression)
        {
            try
            {
                var nuevaExpression = GeneradorDePredicados.Convertir<SectorOtd, SECTOR>(expression);
                return UbicacionMapeos.MapearSectores(_sectorRepositorio.EncontrarPor(nuevaExpression).ToList());
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }
        #endregion
    }
}
