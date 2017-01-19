using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeos
{
    public static class EmpleadoMapeos
    {
        public static EMPLEADO MapearEntidad(EmpleadoOtd empleado)
        {
            return Mapper.Map<Modelos.Entidades.EMPLEADO>(empleado);
        }

        public static EmpleadoOtd MapearModelo(EMPLEADO empleado)
        {
            return Mapper.Map<EmpleadoOtd>(empleado);
        }

        public static IList<EmpleadoOtd> MapearListaDeModelos(IList<EMPLEADO> empleados)
        {
            return Mapper.Map<IList<EMPLEADO>, IList<EmpleadoOtd>>(empleados);
        }
    }
}
