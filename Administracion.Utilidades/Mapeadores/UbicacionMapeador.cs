using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeadores
{
    public static class UbicacionMapeador
    {
        public static void Configuracion()
        {
            CrearMapeadorParaCentro();
            CrearMapeadorParaEdificio();
            CrearMapeadorParaSector();
            CrearMapeadorParaAsignacionDeSector();
            CrearMapeadorParaEdificioCatalogBase();
            CrearMapeadorParaCelda();
            CrearMapeadorParaCatalogBaseEdificioOdt();
        }

        private static void CrearMapeadorParaEdificio()
        {
            Mapper.CreateMap<EDIFICIO, EdificioOtd>()
                .ForMember(dest => dest.Descripcion, entidad => entidad.MapFrom(ft => ft.DESCR))
                .ForMember(dest => dest.IdCentro, entidad => entidad.MapFrom(ft => ft.ID_CENTRO))
                .ForMember(dest => dest.IdEdificio, entidad => entidad.MapFrom(ft => ft.ID_EDIFICIO))
                .ForMember(dest => dest.IdTipoEdificio, entidad => entidad.MapFrom(ft => ft.ID_TIPO_EDIFICIO))
                .ForMember(dest => dest.TipoDeEdificio, entidad => entidad.Ignore())
                .ForMember(dest => dest.Centro, entidad => entidad.Ignore())
                .ForMember(dest => dest.Sectores, entidad => entidad.Ignore())
                .ForMember(dest => dest.PLProgramadoAsignaciones, entidad => entidad.Ignore());
        }

        private static void CrearMapeadorParaSector()
        {
            Mapper.CreateMap<SECTOR, SectorOtd>()
                .ForMember(dest => dest.Descripcion, entidad => entidad.MapFrom(ft => ft.DESCR))
                .ForMember(dest => dest.IdCentro, entidad => entidad.MapFrom(ft => ft.ID_CENTRO))
                .ForMember(dest => dest.IdEdificio, entidad => entidad.MapFrom(ft => ft.ID_EDIFICIO))
                .ForMember(dest => dest.IdSector, entidad => entidad.MapFrom(ft => ft.ID_SECTOR))
                .ForMember(dest => dest.Plano, entidad => entidad.MapFrom(ft => ft.PLANO))
                .ForMember(dest => dest.Celdas, entidad => entidad.Ignore())
                .ForMember(dest => dest.PLProgramadoAsignaciones, entidad => entidad.Ignore())
                .ForMember(dest => dest.Edificio, entidad => entidad.MapFrom(ft => Mapper.Map<EdificioOtd>(ft.EDIFICIO)));
        }

        private static void CrearMapeadorParaAsignacionDeSector()
        {
            Mapper.CreateMap<SectorOtd, AsignacionOtd>()
                .ForMember(dest => dest.Edificio, entidad => entidad.MapFrom(ft => Mapper.Map<CatalogoBaseOdt>(ft.Edificio)))
                .ForMember(dest => dest.Nivel, entidad => entidad.MapFrom(ft => 1))
                .AfterMap((src, dest) =>
                {
                    dest.Sector = new CatalogoBaseOdt
                    {
                        Nombre = src.Descripcion,
                        Id = (int)src.IdSector
                    };

                    dest.Custodio = new PersonaOtd();
                });
        }

        private static void CrearMapeadorParaEdificioCatalogBase()
        {
            Mapper.CreateMap<EdificioOtd, CatalogoBaseOdt>()
              .ForMember(dest => dest.Nombre, entidad => entidad.MapFrom(ft => ft.Descripcion))
              .ForMember(dest => dest.Id, entidad => entidad.MapFrom(ft => (int)ft.IdEdificio));
        }


        public static void CrearMapeadorParaCelda()
        {
            Mapper.CreateMap<CELDA, CeldaOtd>()
                .ForMember(dest => dest.IdCelda, entidad => entidad.MapFrom(ft => ft.ID_CELDA))
                .ForMember(dest => dest.IdCentro, entidad => entidad.MapFrom(ft => ft.ID_CENTRO))
                .ForMember(dest => dest.IdEdificio, entidad => entidad.MapFrom(ft => ft.ID_EDIFICIO))
                .ForMember(dest => dest.IdSector, entidad => entidad.MapFrom(ft => ft.ID_SECTOR))
                .ForMember(dest => dest.IdTipoCelda, entidad => entidad.MapFrom(ft => ft.ID_TIPO_CELDA))
                .ForMember(dest => dest.IdTipoSeguridad, entidad => entidad.MapFrom(ft => ft.ID_TIPO_SEGURIDAD))
                .ForMember(dest => dest.NivelEdificio, entidad => entidad.MapFrom(ft => ft.NIVEL_EDIFICIO))
                .ForMember(dest => dest.Estatus, entidad => entidad.MapFrom(ft => ft.ESTATUS))
                .ForMember(dest => dest.Sector, entidad => entidad.MapFrom(ft => Mapper.Map<SectorOtd>(ft.SECTOR)));
                //.ForMember(dest => dest.PLAsignacionResultados, entidad => entidad.MapFrom(ft => Mapper.Map<PLAsignacionResultadoOtd>(ft.PL_ASIGNACION_RESULTADO)))
                //.ForMember(dest => dest.Sector, entidad => entidad.MapFrom(ft => Mapper.Map<SectorOtd>(ft.SECTOR)));
                //.ForMember(dest => dest.TipoCelda, entidad => entidad.Ignore());
        }


        private static void CrearMapeadorParaCatalogBaseEdificioOdt()
        {
            Mapper.CreateMap<CatalogoBaseOdt, EdificioOtd>()
              .ForMember(dest => dest.Descripcion, entidad => entidad.MapFrom(ft => ft.Nombre))
              .ForMember(dest => dest.IdEdificio, entidad => entidad.MapFrom(ft => (short)ft.Id));
        }

        private static void CrearMapeadorParaCentro()
        {
            Mapper.CreateMap<CENTRO, CentroOtd>()
               .ForMember(dest => dest.IdCentro, entidad => entidad.MapFrom(ft => ft.ID_CENTRO))
               .ForMember(dest => dest.IdTipoCentro, entidad => entidad.MapFrom(ft => ft.ID_TIPO_CENTRO))
               .ForMember(dest => dest.IdEntidad, entidad => entidad.MapFrom(ft => ft.ID_ENTIDAD))
               .ForMember(dest => dest.IdMunicipio, entidad => entidad.MapFrom(ft => ft.ID_MUNICIPIO))
               .ForMember(dest => dest.Descripcion, entidad => entidad.MapFrom(ft => ft.DESCR))
               .ForMember(dest => dest.Calle, entidad => entidad.MapFrom(ft => ft.CALLE))
               .ForMember(dest => dest.NumeroExterior, entidad => entidad.MapFrom(ft => ft.NUM_EXT))
               .ForMember(dest => dest.NumeroInterior, entidad => entidad.MapFrom(ft => ft.NUM_INT))
               .ForMember(dest => dest.Colonia, entidad => entidad.MapFrom(ft => ft.COLONIA))
               .ForMember(dest => dest.CP, entidad => entidad.MapFrom(ft => ft.CP))
               .ForMember(dest => dest.Telefono, entidad => entidad.MapFrom(ft => ft.TELEFONO))
               .ForMember(dest => dest.Fax, entidad => entidad.MapFrom(ft => ft.FAX))
               .ForMember(dest => dest.Director, entidad => entidad.MapFrom(ft => ft.DIRECTOR))
               .ForMember(dest => dest.IdEmisor, entidad => entidad.MapFrom(ft => ft.ID_EMISOR))
               .ForMember(dest => dest.ConsAnual, entidad => entidad.MapFrom(ft => ft.CONS_ANUAL))
               .ForMember(dest => dest.Estatus, entidad => entidad.MapFrom(ft => ft.ESTATUS))
               .ForMember(dest => dest.TipoDeCentro, entidad => entidad.Ignore())//)
               .ForMember(dest => dest.Edificios, entidad => entidad.MapFrom(ft => Mapper.Map<ICollection<EdificioOtd>>(ft.EDIFICIOs)))
               .ForMember(dest => dest.Empleados, entidad => entidad.Ignore())//.MapFrom(ft => Mapper.Map<ICollection<EmpleadoOtd>>(ft.EMPLEADOes)))
               .ForMember(dest => dest.Imputados, entidad => entidad.Ignore())//.MapFrom(ft => Mapper.Map<ICollection<ImputadoOtd>>(ft.IMPUTADOes)))
               .ForMember(dest => dest.Ingresos, entidad => entidad.Ignore())//.MapFrom(ft => Mapper.Map<ICollection<IngresoOtd>>(ft.INGRESOes)))
               .ForMember(dest => dest.PLProgramados, entidad => entidad.Ignore());//.MapFrom(ft => Mapper.Map<ICollection<PLProgramadoOtd>>(ft.PL_PROGRAMADO)));
        }
    }
}