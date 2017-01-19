using Administracion.OTD;
using Administracion.Modelos.Entidades;
using AutoMapper;

namespace Administracion.Utilidades.Mapeadores
{
    public static class TipoDeEmpleadoMapeador
    {
        public static void Configuracion()
        {
            CrearMapeadorParaTipoDeEmpleado();
            CrearMapeadorParaTipoDeEmpleadoEntidad();
        }

        private static void CrearMapeadorParaTipoDeEmpleado()
        {
            Mapper.CreateMap<TIPO_EMPLEADO, TipoDeEmpleadoOtd>()
                .ForMember(dest => dest.Descripcion, entidad => entidad.MapFrom(ft => ft.DESCR))
                .ForMember(dest => dest.Empleados, entidad => entidad.MapFrom(ft => Mapper.Map<EmpleadoOtd>(ft.EMPLEADOes)))
                .ForMember(dest => dest.IdTipoDeEmpleado, entidad => entidad.MapFrom(ft => ft.ID_TIPO_EMPLEADO));
        }

        private static void CrearMapeadorParaTipoDeEmpleadoEntidad()
        {
            Mapper.CreateMap<TipoDeEmpleadoOtd, TIPO_EMPLEADO>()
                .ForMember(dest => dest.DESCR, entidad => entidad.MapFrom(ft => ft.Descripcion))
                .ForMember(dest => dest.EMPLEADOes, entidad => entidad.MapFrom(ft => Mapper.Map<EmpleadoOtd>(ft.Empleados)))
                .ForMember(dest => dest.ID_TIPO_EMPLEADO, entidad => entidad.MapFrom(ft => ft.IdTipoDeEmpleado));
        }
    }
}
