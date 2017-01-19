using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeadores
{
    public static class UsuarioMapeador
    {
        public static void Configuracion()
        {
            CrearMapeadorParaProceso();
            CrearMapeadorParaProcesoRol();
            CrearMapeadorParaProcesoUsuario();
            CrearMapeadorParaUsuario();
            CrearMapeadorParaUsuarioMensaje();
            CrearMapeadorParaUsuarioRol();
        }

        private static void CrearMapeadorParaUsuario()
        {
            Mapper.CreateMap<USUARIO, UsuarioOtd>()
                .ForMember(dest => dest.Estatus, entidad => entidad.MapFrom(ft => ft.ESTATUS))
                .ForMember(dest => dest.IdPersona, entidad => entidad.MapFrom(ft => ft.ID_PERSONA))
                .ForMember(dest => dest.IdUsuario, entidad => entidad.MapFrom(ft => ft.ID_USUARIO))
                .ForMember(dest => dest.Password, entidad => entidad.MapFrom(ft => ft.PASSWORD))
                .ForMember(dest => dest.Persona, entidad => entidad.MapFrom(ft => Mapper.Map<PersonaOtd>(ft.PERSONA)))
                .ForMember(dest => dest.ProcesosUsuario, entidad => entidad.MapFrom(ft => Mapper.Map<ICollection<ProcesoUsuarioOtd>>(ft.PROCESO_USUARIO)))
                .ForMember(dest => dest.UsuarioMensajes, entidad => entidad.MapFrom(ft => Mapper.Map<ICollection<UsuarioMensajeOtd>>(ft.USUARIO_MENSAJE)))
                .ForMember(dest => dest.UsuarioRoles, entidad => entidad.MapFrom(ft => Mapper.Map<ICollection<UsuarioRolOtd>>(ft.USUARIO_ROL)));
        }

        private static void CrearMapeadorParaProcesoUsuario()
        {
            Mapper.CreateMap<PROCESO_USUARIO, ProcesoUsuarioOtd>()
                .ForMember(dest => dest.Consultar, entidad => entidad.MapFrom(ft => ft.CONSULTAR))
                .ForMember(dest => dest.Digitalizar, entidad => entidad.MapFrom(ft => ft.DIGITALIZAR))
                .ForMember(dest => dest.Editar, entidad => entidad.MapFrom(ft => ft.EDITAR))
                .ForMember(dest => dest.IdProceso, entidad => entidad.MapFrom(ft => ft.ID_PROCESO))
                .ForMember(dest => dest.IdRol, entidad => entidad.MapFrom(ft => ft.ID_ROL))
                .ForMember(dest => dest.IdUsuario, entidad => entidad.MapFrom(ft => ft.ID_USUARIO))
                .ForMember(dest => dest.Imprimir, entidad => entidad.MapFrom(ft => ft.IMPRIMIR))
                .ForMember(dest => dest.Insertar, entidad => entidad.MapFrom(ft => ft.INSERTAR))
                .ForMember(dest => dest.Proceso, entidad => entidad.MapFrom(ft => Mapper.Map<ProcesoOtd>(ft.PROCESO)))
                .ForMember(dest => dest.Usuario, entidad => entidad.Ignore());
        }

        private static void CrearMapeadorParaProceso()
        {
            Mapper.CreateMap<PROCESO, ProcesoOtd>()
                .ForMember(dest => dest.IdProceso, entidad => entidad.MapFrom(ft => ft.ID_PROCESO))
                .ForMember(dest => dest.Descripcion, entidad => entidad.MapFrom(ft => ft.DESCR))                
                .ForMember(dest => dest.Ventana, entidad => entidad.MapFrom(ft => ft.VENTANA))
                .ForMember(dest => dest.ProcesoRoles, entidad => entidad.MapFrom(ft => Mapper.Map<ICollection<ProcesoRolOtd>>(ft.PROCESO_ROL)))
                .ForMember(dest => dest.ProcesoUsuarios, entidad => entidad.Ignore());
        }

        private static void CrearMapeadorParaProcesoRol()
        {
            Mapper.CreateMap<PROCESO_ROL, ProcesoRolOtd>()
                .ForMember(dest => dest.IdProceso, entidad => entidad.MapFrom(ft => ft.ID_PROCESO))
                .ForMember(dest => dest.IdRol, entidad => entidad.MapFrom(ft => ft.ID_ROL))
                .ForMember(dest => dest.Insertar, entidad => entidad.MapFrom(ft => ft.INSERTAR))
                .ForMember(dest => dest.Editar, entidad => entidad.MapFrom(ft => ft.EDITAR))                
                .ForMember(dest => dest.Consultar, entidad => entidad.MapFrom(ft => ft.CONSULTAR))
                .ForMember(dest => dest.Imprimir, entidad => entidad.MapFrom(ft => ft.IMPRIMIR))
                .ForMember(dest => dest.Digitalizar, entidad => entidad.MapFrom(ft => ft.DIGITALIZAR))
                .ForMember(dest => dest.Proceso, entidad => entidad.Ignore());
        }

        private static void CrearMapeadorParaUsuarioMensaje()
        {
            Mapper.CreateMap<USUARIO_MENSAJE, UsuarioMensajeOtd>()
                .ForMember(dest => dest.Estatus, entidad => entidad.MapFrom(ft => ft.ESTATUS))
                .ForMember(dest => dest.IdMensaje, entidad => entidad.MapFrom(ft => ft.ID_MENSAJE))
                .ForMember(dest => dest.IdUsuario, entidad => entidad.MapFrom(ft => ft.ID_USUARIO))
                .ForMember(dest => dest.LecturaFecha, entidad => entidad.MapFrom(ft => ft.LECTURA_FEC))
                .ForMember(dest => dest.Usuario, entidad => entidad.Ignore());
        }

        private static void CrearMapeadorParaUsuarioRol()
        {
            Mapper.CreateMap<USUARIO_ROL, UsuarioRolOtd>()
               .ForMember(dest => dest.Fecha, entidad => entidad.MapFrom(ft => ft.FECHA))
               .ForMember(dest => dest.IdRol, entidad => entidad.MapFrom(ft => ft.ID_ROL))
               .ForMember(dest => dest.IdUsuario, entidad => entidad.MapFrom(ft => ft.ID_USUARIO))
               .ForMember(dest => dest.Usuario, entidad => entidad.Ignore());
        }
    }
}
