using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeadores
{
    public static class CentroMapeador
    {
        //public static void Configuracion()
        //{
        //    CrearMapeadorParaCentro();
        //    CrearMapeadorParaCentroEntidad();
        //}

        //private static void CrearMapeadorParaCentro()
        //{
        //    Mapper.CreateMap<CENTRO, CentroOtd>()
        //        .ForMember(dest => dest.IdCentro, entidad => entidad.MapFrom(ft => ft.ID_CENTRO))
        //        .ForMember(dest => dest.IdTipoCentro, entidad => entidad.MapFrom(ft => ft.ID_TIPO_CENTRO))
        //        .ForMember(dest => dest.IdEntidad, entidad => entidad.MapFrom(ft => ft.ID_ENTIDAD))
        //        .ForMember(dest => dest.IdMunicipio, entidad => entidad.MapFrom(ft => ft.ID_MUNICIPIO))
        //        .ForMember(dest => dest.Descripcion, entidad => entidad.MapFrom(ft => ft.DESCR))
        //        .ForMember(dest => dest.Calle, entidad => entidad.MapFrom(ft => ft.CALLE))
        //        .ForMember(dest => dest.NumeroExterior, entidad => entidad.MapFrom(ft => ft.NUM_EXT))
        //        .ForMember(dest => dest.NumeroInterior, entidad => entidad.MapFrom(ft => ft.NUM_INT))
        //        .ForMember(dest => dest.Colonia, entidad => entidad.MapFrom(ft => ft.COLONIA))
        //        .ForMember(dest => dest.CP, entidad => entidad.MapFrom(ft => ft.CP))
        //        .ForMember(dest => dest.Telefono, entidad => entidad.MapFrom(ft => ft.TELEFONO))
        //        .ForMember(dest => dest.Fax, entidad => entidad.MapFrom(ft => ft.FAX))
        //        .ForMember(dest => dest.Director, entidad => entidad.MapFrom(ft => ft.DIRECTOR))
        //        .ForMember(dest => dest.IdEmisor, entidad => entidad.MapFrom(ft => ft.ID_EMISOR))
        //        .ForMember(dest => dest.ConsAnual, entidad => entidad.MapFrom(ft => ft.CONS_ANUAL))
        //        .ForMember(dest => dest.Estatus, entidad => entidad.MapFrom(ft => ft.ESTATUS))
        //        .ForMember(dest => dest.TipoDeCentro, entidad => entidad.Ignore())//)
        //        .ForMember(dest => dest.Edificios, entidad => entidad.Ignore())//entidad.MapFrom(ft => Mapper.Map<ICollection<EdificioOtd>>(ft.EDIFICIOs)))
        //        .ForMember(dest => dest.Empleados, entidad => entidad.Ignore())//.MapFrom(ft => Mapper.Map<ICollection<EmpleadoOtd>>(ft.EMPLEADOes)))
        //        .ForMember(dest => dest.Imputados, entidad => entidad.Ignore())//.MapFrom(ft => Mapper.Map<ICollection<ImputadoOtd>>(ft.IMPUTADOes)))
        //        .ForMember(dest => dest.Ingresos, entidad => entidad.Ignore())//.MapFrom(ft => Mapper.Map<ICollection<IngresoOtd>>(ft.INGRESOes)))
        //        .ForMember(dest => dest.PLProgramados, entidad => entidad.Ignore());//.MapFrom(ft => Mapper.Map<ICollection<PLProgramadoOtd>>(ft.PL_PROGRAMADO)));

        //}

        //private static void CrearMapeadorParaCentroEntidad()
        //{
        //    Mapper.CreateMap<CentroOtd,CENTRO>()
        //        .ForMember(dest => dest.ID_CENTRO, entidad => entidad.MapFrom(ft => ft.IdCentro))
        //        .ForMember(dest => dest.ID_TIPO_CENTRO, entidad => entidad.MapFrom(ft => ft.IdTipoCentro))
        //        .ForMember(dest => dest.ID_ENTIDAD, entidad => entidad.MapFrom(ft => ft.IdEntidad))
        //        .ForMember(dest => dest.ID_MUNICIPIO, entidad => entidad.MapFrom(ft => ft.IdMunicipio))
        //        .ForMember(dest => dest.DESCR, entidad => entidad.MapFrom(ft => ft.Descripcion))
        //        .ForMember(dest => dest.CALLE, entidad => entidad.MapFrom(ft => ft.Calle))
        //        .ForMember(dest => dest.NUM_EXT, entidad => entidad.MapFrom(ft => ft.NumeroExterior))
        //        .ForMember(dest => dest.NUM_INT, entidad => entidad.MapFrom(ft => ft.NumeroInterior))
        //        .ForMember(dest => dest.COLONIA, entidad => entidad.MapFrom(ft => ft.Colonia))
        //        .ForMember(dest => dest.CP, entidad => entidad.MapFrom(ft => ft.CP))
        //        .ForMember(dest => dest.TELEFONO, entidad => entidad.MapFrom(ft => ft.Telefono))
        //        .ForMember(dest => dest.FAX, entidad => entidad.MapFrom(ft => ft.Fax))
        //        .ForMember(dest => dest.DIRECTOR, entidad => entidad.MapFrom(ft => ft.Director))
        //        .ForMember(dest => dest.ID_EMISOR, entidad => entidad.MapFrom(ft => ft.IdEmisor))
        //        .ForMember(dest => dest.CONS_ANUAL, entidad => entidad.MapFrom(ft => ft.ConsAnual))
        //        .ForMember(dest => dest.ESTATUS, entidad => entidad.MapFrom(ft => ft.Estatus))
        //        .ForMember(dest => dest.TIPO_CENTRO, entidad => entidad.Ignore())
        //        .ForMember(dest => dest.EDIFICIOs, entidad => entidad.Ignore())
        //        .ForMember(dest => dest.EMPLEADOes, entidad => entidad.Ignore())
        //        .ForMember(dest => dest.IMPUTADOes, entidad => entidad.Ignore())
        //        .ForMember(dest => dest.INGRESOes, entidad => entidad.Ignore())
        //        .ForMember(dest => dest.PL_PROGRAMADO, entidad => entidad.Ignore());
        //}
    }
}
