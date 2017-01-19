using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeos
{
    public static class CentroMapeos
    {
        public static CENTRO MapearEntidad(CentroOtd centro)
        {
            return Mapper.Map<Modelos.Entidades.CENTRO>(centro);
        }

        public static CentroOtd MapearModelo(CENTRO centro)
        {
            return Mapper.Map<CentroOtd>(centro);
        }

        public static IList<CentroOtd> MapearListaDeModelos(IList<CENTRO> centros)
        {
            try
            {
                return Mapper.Map<IList<CENTRO>, IList<CentroOtd>>(centros);
            }
            catch (System.Exception ex)
            {
                
                throw ex;
            }
            
        }

    }
}
