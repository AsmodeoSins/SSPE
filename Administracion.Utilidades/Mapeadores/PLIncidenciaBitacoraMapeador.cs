using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Administracion.Utilidades.Mapeadores
{
    public static class PLIncidenciaBitacoraMapeador
    {
        public static void Configuracion()
        {
            CrearMapeadorParaPLIncidenciaBitacora();
            CrearMapeadorParaPLProgramadoBitacora();
        }

        private static void CrearMapeadorParaPLIncidenciaBitacora()
        {
            Mapper.CreateMap<PL_INCIDENCIA_BITACORA, PLIncidenciaBitacoraOtd>()
                .ForMember(dest => dest.Estatus, entidad => entidad.MapFrom(ft => ft.ESTATUS))
                .ForMember(dest => dest.FechaCreacion, entidad => entidad.MapFrom(ft => ft.FECHA_CREACION))
                .ForMember(dest => dest.FechaSolucion, entidad => entidad.MapFrom(ft => ft.FECHA_SOLUCION))
                .ForMember(dest => dest.HoraCreacion, entidad => entidad.MapFrom(ft => ft.HORA_CREACION))
                .ForMember(dest => dest.HoraSolucion, entidad => entidad.MapFrom(ft => ft.HORA_SOLUCION))
                .ForMember(dest => dest.IdAnio, entidad => entidad.MapFrom(ft => ft.ID_ANIO))
                .ForMember(dest => dest.IdCentro, entidad => entidad.MapFrom(ft => ft.ID_CENTRO))
                .ForMember(dest => dest.IdImputado, entidad => entidad.MapFrom(ft => ft.ID_IMPUTADO))
                .ForMember(dest => dest.IdIncidencia, entidad => entidad.MapFrom(ft => ft.ID_INCIDENCIA))
                .ForMember(dest => dest.IdPLIncidenciaBit, entidad => entidad.MapFrom(ft => ft.ID_PL_INCIDENCIA_BIT))
                .ForMember(dest => dest.IdPLProgramadoBit, entidad => entidad.MapFrom(ft => ft.ID_PL_PROGRAMADO_BIT))
                .ForMember(dest => dest.Observaciones, entidad => entidad.MapFrom(ft => ft.OBSERVACIONES))
                .ForMember(dest => dest.Imputado, entidad => entidad.MapFrom(ft => Mapper.Map<ImputadoOtd>(ft.IMPUTADO)))
                .ForMember(dest => dest.Incidencia, entidad => entidad.MapFrom(ft => Mapper.Map<PLIncidenciaCatalogoOtd>(ft.PL_INCIDENCIA_CATALOGO)))
                .ForMember(dest => dest.IncidenciaEstatus, entidad => entidad.MapFrom(ft => Mapper.Map<PLIncidenciaEstatus>(ft.PL_INCIDENCIA_ESTATUS)))
                .ForMember(dest => dest.PLProgramadoBitacora, entidad => entidad.MapFrom(ft => Mapper.Map<PLProgramadoBitacoraOtd>(ft.PL_PROGRAMADO_BITACORA)));
        }

        private static void CrearMapeadorParaPLProgramadoBitacora()
        {
            Mapper.CreateMap<PL_PROGRAMADO_BITACORA, PLProgramadoBitacoraOtd>()
                .ForMember(dest => dest.FechaEjecucion, entidad => entidad.MapFrom(ft => ft.FECHA_EJECUCION))
                .ForMember(dest => dest.IdPLBitacora, entidad => entidad.MapFrom(ft => ft.ID_PL_BITACORA))
                .ForMember(dest => dest.IdPlProgramado, entidad => entidad.MapFrom(ft => ft.ID_PL_PROGRAMADO))
                .ForMember(dest => dest.Resultados, entidad => entidad.Ignore());
        }
    }
}
