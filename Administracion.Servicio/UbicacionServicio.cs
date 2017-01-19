using Administracion.Contratos;
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
    public class UbicacionServicio : ServicioBase, IUbicacionServicio
    {
        private readonly IEdificioRepositorio _edificioRepositorio;
        private readonly ISectorRepositorio _sectorRepositorio;
        private readonly ICeldaRepositorio _celdaRepositorio;

        public UbicacionServicio(IEdificioRepositorio edificioRepositorio, ISectorRepositorio sectorRepositorio, ICeldaRepositorio celdaRepositorio)
        {
            _edificioRepositorio = edificioRepositorio;
            _sectorRepositorio = sectorRepositorio;
            _celdaRepositorio = celdaRepositorio;
        }

        public IList<EdificioOtd> ObtenerEdificiosPorCentro(short idCentro)
        {
            try
            {
                var edificios = _edificioRepositorio.EncontrarPor(e => e.ID_CENTRO == idCentro);

                if (edificios != null && edificios.Count() > 0)
                {
                    return UbicacionMapeos.MapearEdificios(edificios.ToList());
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        public IList<SectorOtd> ObtenerSectoresPorCentroYEdificio(short idCentro, short idEdificio)
        {
            try
            {
                var sectores = _sectorRepositorio.EncontrarPor(e => e.ID_CENTRO == idCentro && e.ID_EDIFICIO==idEdificio);

                if (sectores != null && sectores.Count() > 0)
                {
                    return UbicacionMapeos.MapearSectores(sectores.ToList());
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }


        public IList<CeldaOtd> ObtenerCeldas(short idCentro, short idEdificio, short idSector)
        {
            try
            {
                var celdas = _celdaRepositorio.EncontrarPor(e => e.ID_CENTRO == idCentro && e.ID_EDIFICIO == idEdificio && e.ID_SECTOR == idSector);

                if (celdas != null && celdas.Count() > 0)
                {
                    return UbicacionMapeos.MapearCeldas(celdas.ToList());
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        public IList<EdificioOtd> EncontrarEdificiosPor(Expression<Func<EdificioOtd, bool>> expresion)
        {
            try
            {
                var nuevaExpression = GeneradorDePredicados.Convertir<EdificioOtd, EDIFICIO>(expresion);
                return UbicacionMapeos.MapearEdificios(_edificioRepositorio.EncontrarPor(nuevaExpression).ToList());
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }
    }
}
