using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeos
{
    public static class PersonaMapeos
    {
        public static IList<PersonaOtd> MapearPersonas(IList<EMPLEADO> empleados)
        {
            return Mapper.Map<IList<PersonaOtd>>(empleados);
        }

        public static IList<PersonaOtd> MapearPersonas(IList<PERSONA> personas)
        {
            return Mapper.Map<IList<PersonaOtd>>(personas);
        }

        public static IList<PersonaOtd> MapearImputados(IList<IMPUTADO> imputados)
        {
            return Mapper.Map<IList<PersonaOtd>>(imputados);
        }
    }
}