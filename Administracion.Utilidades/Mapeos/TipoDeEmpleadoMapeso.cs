using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeos
{
    public static class TipoDeEmpleadoMapeso
    {
        public static TIPO_EMPLEADO MapearEntidad(TipoDeEmpleadoOtd tipoDeEmpleado)
        {
            return Mapper.Map<TIPO_EMPLEADO>(tipoDeEmpleado);
        }

        public static TipoDeEmpleadoOtd MapearModelo(TIPO_EMPLEADO tipoDeEmpleado)
        {
            return Mapper.Map<TipoDeEmpleadoOtd>(tipoDeEmpleado);
        }

        public static IList<TipoDeEmpleadoOtd> MapearListaDeModelos(IList<TIPO_EMPLEADO> tiposDeEmpleados)
        {
            return Mapper.Map<IList<TIPO_EMPLEADO>, IList<TipoDeEmpleadoOtd>>(tiposDeEmpleados);
        }
    }
}
