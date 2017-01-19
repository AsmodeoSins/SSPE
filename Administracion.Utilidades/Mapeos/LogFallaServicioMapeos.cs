using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeos
{
    public static class LogFallaServicioMapeos
    {
        public static LogFallaServicioOtd MapearModelo(LOGFALLASERVICIO logFallaServicio)
        {
            return Mapper.Map<LogFallaServicioOtd>(logFallaServicio);
        }

        public static IList<LogFallaServicioOtd> MapearListaModelos(IList<LOGFALLASERVICIO> logFallaServicios)
        {
            return Mapper.Map<IList<LogFallaServicioOtd>>(logFallaServicios);
        }

        public static LOGFALLASERVICIO MapearEntidad(LogFallaServicioOtd logFallaServicio)
        {
            return Mapper.Map<LOGFALLASERVICIO>(logFallaServicio);
        }
    }
}
