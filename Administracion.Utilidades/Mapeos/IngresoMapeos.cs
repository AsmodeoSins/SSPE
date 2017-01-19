using Administracion.OTD;
using Administracion.Modelos.Entidades;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeos
{
    public static class IngresoMapeos
    {
        public static INGRESO MapearEntidad(IngresoOtd ingreso)
        {
            return Mapper.Map<INGRESO>(ingreso);
        }

        public static IngresoOtd MapearModelo(INGRESO ingreso)
        {
            return Mapper.Map<IngresoOtd>(ingreso);
        }

        public static IList<IngresoOtd> MapearListaDeModelos(IList<INGRESO> ingresos)
        {
            return Mapper.Map<IList<INGRESO>, IList<IngresoOtd>>(ingresos);
        }
    }
}
