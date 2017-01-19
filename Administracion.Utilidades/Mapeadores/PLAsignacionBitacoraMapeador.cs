using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Administracion.Utilidades.Mapeadores
{
    public static class PLAsignacionBitacoraMapeador
    {
        public static void Configuracion()
        {
            CrearMapeadorParaPLAsignacionBitacora();
            CrearMapeadorParaPLAsignacionBitacoraEntidad();
        }

        private static void CrearMapeadorParaPLAsignacionBitacora()
        {
            Mapper.CreateMap<PL_ASIGNACION_BITACORA, PLAsignacionBitacoraOtd>()
                .ForMember(dest => dest.HoraFinal, entidad => entidad.MapFrom(ft => ft.HORA_FINAL))
                .ForMember(dest => dest.HoraInical, entidad => entidad.MapFrom(ft => ft.HORA_INICIAL))
                .ForMember(dest => dest.IdAsignacionBitacora, entidad => entidad.MapFrom(ft => ft.ID_ASIGNACION_BITACORA))
                .ForMember(dest => dest.IdEmpleado, entidad => entidad.MapFrom(ft => ft.ID_EMPLEADO))
                .ForMember(dest => dest.IdPLProgramadoBitacora, entidad => entidad.MapFrom(ft => ft.ID_PL_PROGRAMADO_BITACORA))
                .ForMember(dest => dest.Empleado, entidad => entidad.MapFrom(ft => Mapper.Map<EmpleadoOtd>(ft.EMPLEADO)));
        }

        private static void CrearMapeadorParaPLAsignacionBitacoraEntidad()
        {
            Mapper.CreateMap<PL_ASIGNACION_BITACORA, PLAsignacionBitacoraOtd>()
                .ForMember(dest => dest.HoraFinal, entidad => entidad.MapFrom(ft => ft.HORA_FINAL))
                .ForMember(dest => dest.HoraInical, entidad => entidad.MapFrom(ft => ft.HORA_INICIAL))
                .ForMember(dest => dest.IdAsignacionBitacora, entidad => entidad.MapFrom(ft => ft.ID_ASIGNACION_BITACORA))
                .ForMember(dest => dest.IdEmpleado, entidad => entidad.MapFrom(ft => ft.ID_EMPLEADO))
                .ForMember(dest => dest.IdPLProgramadoBitacora, entidad => entidad.MapFrom(ft => ft.ID_PL_PROGRAMADO_BITACORA))
                .ForMember(dest => dest.Empleado, entidad => entidad.MapFrom(ft => Mapper.Map<EmpleadoOtd>(ft.EMPLEADO)));
        }
    }
}
