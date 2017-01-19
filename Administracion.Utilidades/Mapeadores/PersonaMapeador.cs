using Administracion.Enum;
using Administracion.Modelos.Entidades;
using Administracion.OTD;
using Administracion.Utilidades.Controles;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Administracion.Utilidades.Mapeadores
{
    public static class PersonaMapeador
    {
        public static void Configuracion()
        {
            CrearMapeadorDeImputadoAPersona();
            CrearMapeadorDeEmpleadoAPersona();
            CrearMapeadorDeEmpleadoAEmpleado();
            CrearMapeadorDePersonaAPersona();
            CrearMapeadorDeImputado();
        }

        private static void CrearMapeadorDeEmpleadoAPersona()
        {
            Mapper.CreateMap<EMPLEADO, PersonaOtd>()
                .ForMember(dest => dest.Id, entidad => entidad.MapFrom(ft => ft.ID_EMPLEADO))
                .ForMember(dest => dest.Nombre, entidad => entidad.MapFrom(ft => ft.PERSONA.NOMBRE.Trim()))
                .ForMember(dest => dest.Apellidos, entidad => entidad.MapFrom(ft => string.Format("{0} {1}", ft.PERSONA.PATERNO.Trim(), ft.PERSONA.MATERNO.Trim())))
                .ForMember(dest => dest.EsImputado, entidad => entidad.MapFrom(ft => false))
                .ForMember(dest => dest.NombreCentro, entidad => entidad.MapFrom(ft => ft.CENTRO.DESCR));
        }

        private static void CrearMapeadorDeEmpleadoAEmpleado()
        {
            Mapper.CreateMap<EMPLEADO, EmpleadoOtd>()
               .ForMember(dest => dest.IdEmpleado, entidad => entidad.MapFrom(ft => ft.ID_EMPLEADO))
               .ForMember(dest => dest.Persona, entidad => entidad.MapFrom(ft => Mapper.Map<PERSONA>(ft.PERSONA)));
        }

        private static void CrearMapeadorDePersonaAPersona()
        {
            Mapper.CreateMap<PERSONA, PersonaOtd>()
              .ForMember(dest => dest.Id, entidad => entidad.MapFrom(ft => ft.ID_PERSONA))
              .ForMember(dest => dest.Nombre, entidad => entidad.MapFrom(ft => ft.NOMBRE.Trim()))
              .ForMember(dest => dest.Apellidos, entidad => entidad.MapFrom(ft => string.Format("{0} {1}", ft.PATERNO.Trim(), ft.MATERNO.Trim())))
              .ForMember(dest => dest.EsImputado, entidad => entidad.MapFrom(ft => false));
        }

        private static void CrearMapeadorDeImputadoAPersona()
        {
            Mapper.CreateMap<IMPUTADO, PersonaOtd>()
               .ForMember(dest => dest.Id, entidad => entidad.MapFrom(ft => ft.ID_IMPUTADO))
               .ForMember(dest => dest.IdCentro, entidad => entidad.MapFrom(ft => ft.ID_CENTRO))
               .ForMember(dest => dest.IdAnio, entidad => entidad.MapFrom(ft => ft.ID_ANIO))
               .ForMember(dest => dest.IdIngreso, entidad => entidad.MapFrom(ft => ft.INGRESOes.LastOrDefault().ID_INGRESO))
               .ForMember(dest => dest.Nombre, entidad => entidad.MapFrom(ft => ft.NOMBRE.Trim()))
               .ForMember(dest => dest.Apellidos, entidad => entidad.MapFrom(ft => string.Format("{0} {1}", ft.PATERNO.Trim(), ft.MATERNO.Trim())))
               .ForMember(dest => dest.EsImputado, entidad => entidad.MapFrom(ft => true))
               .ForMember(dest => dest.Biometricos, entidad => entidad.MapFrom(ft => Mapper.Map<ICollection<BiometricoOtd>>(ft.IMPUTADO_BIOMETRICO)))
               .ForMember(dest => dest.Folio, entidad => entidad.MapFrom(ft => string.Format("{0} / {1}", ft.ID_ANIO, ft.ID_IMPUTADO)))
               .AfterMap((entidad, dest) =>
               {
                   if (dest.Biometricos != null && dest.Biometricos.Count > 0)
                   {
                       foreach (var biometrico in dest.Biometricos)
                       {
                           if (biometrico.Tipo == TipoBiometrico.FotoFrenteRegistro)
                           {
                               dest.Foto = Convertidor.ConvertirBinarioImagen(biometrico.Biometrico);
                           }

                           if (biometrico.Tipo == TipoBiometrico.OjoDerecho || biometrico.Tipo == TipoBiometrico.OjoIzquierdo)
                           {
                               dest.BiometriaRegistrada = true;
                           }
                       }
                   }

               });
        }

        private static void CrearMapeadorDeImputado()
        {
            Mapper.CreateMap<IMPUTADO, ImputadoOtd>()
                .ForMember(dest => dest.IdCentro, entidad => entidad.MapFrom(ft => ft.ID_CENTRO))
                .ForMember(dest => dest.IdAnio, entidad => entidad.MapFrom(ft => ft.ID_ANIO))
                .ForMember(dest => dest.IdImputado, entidad => entidad.MapFrom(ft => ft.ID_IMPUTADO))
                .ForMember(dest => dest.Paterno, entidad => entidad.MapFrom(ft => ft.PATERNO))
                .ForMember(dest => dest.Materno, entidad => entidad.MapFrom(ft => ft.MATERNO))
                .ForMember(dest => dest.Nombre, entidad => entidad.MapFrom(ft => ft.NOMBRE))
                .ForMember(dest => dest.Sexo, entidad => entidad.MapFrom(ft => ft.SEXO))
                .ForMember(dest => dest.IdEtnia, entidad => entidad.MapFrom(ft => ft.ID_ETNIA))
                .ForMember(dest => dest.IdNacionalidad, entidad => entidad.MapFrom(ft => ft.ID_NACIONALIDAD))
                .ForMember(dest => dest.NacimientoPais, entidad => entidad.MapFrom(ft => ft.NACIMIENTO_PAIS))
                .ForMember(dest => dest.NacimientoEstado, entidad => entidad.MapFrom(ft => ft.NACIMIENTO_ESTADO))
                .ForMember(dest => dest.NacimientoMunicipio, entidad => entidad.MapFrom(ft => ft.NACIMIENTO_MUNICIPIO))
                .ForMember(dest => dest.NacimientoFecha, entidad => entidad.MapFrom(ft => ft.NACIMIENTO_FECHA))
                .ForMember(dest => dest.NacimientoLugar, entidad => entidad.MapFrom(ft => ft.NACIMIENTO_LUGAR))
                .ForMember(dest => dest.PaternoMadre, entidad => entidad.MapFrom(ft => ft.PATERNO_MADRE))
                .ForMember(dest => dest.MaternoMadre, entidad => entidad.MapFrom(ft => ft.MATERNO_MADRE))
                .ForMember(dest => dest.NombreMadre, entidad => entidad.MapFrom(ft => ft.NOMBRE_MADRE))
                .ForMember(dest => dest.PaternoPadre, entidad => entidad.MapFrom(ft => ft.PATERNO_PADRE))
                .ForMember(dest => dest.MaternoPadre, entidad => entidad.MapFrom(ft => ft.MATERNO_PADRE))
                .ForMember(dest => dest.NombrePadre, entidad => entidad.MapFrom(ft => ft.NOMBRE_PADRE))
                .ForMember(dest => dest.TrabajadorCereso, entidad => entidad.MapFrom(ft => ft.TABAJADOR_CERESO))
                .ForMember(dest => dest.RFC, entidad => entidad.MapFrom(ft => ft.RFC))
                .ForMember(dest => dest.CURP, entidad => entidad.MapFrom(ft => ft.CURP))
                .ForMember(dest => dest.IFE, entidad => entidad.MapFrom(ft => ft.IFE))
                .ForMember(dest => dest.NIP, entidad => entidad.MapFrom(ft => ft.NIP))
                .ForMember(dest => dest.BIFechaAlta, entidad => entidad.MapFrom(ft => ft.BI_FECALTA))
                .ForMember(dest => dest.BIUser, entidad => entidad.MapFrom(ft => ft.BI_USER))
                .ForMember(dest => dest.TELOriginal, entidad => entidad.MapFrom(ft => ft.TELORIGINAL))
                .ForMember(dest => dest.SPaterno, entidad => entidad.MapFrom(ft => ft.SPATERNO))
                .ForMember(dest => dest.SMaterno, entidad => entidad.MapFrom(ft => ft.SMATERNO))
                .ForMember(dest => dest.SNombre, entidad => entidad.MapFrom(ft => ft.SNOMBRE))
                .ForMember(dest => dest.IdIdioma, entidad => entidad.MapFrom(ft => ft.ID_IDIOMA))
                .ForMember(dest => dest.IdDialecto, entidad => entidad.MapFrom(ft => ft.ID_DIALECTO))
                .ForMember(dest => dest.Traductor, entidad => entidad.MapFrom(ft => ft.TRADUCTOR))
                .ForMember(dest => dest.Centro, entidad => entidad.Ignore())
                .ForMember(dest => dest.ImputadoBiometrico, entidad => entidad.MapFrom(ft => Mapper.Map<IList<ImputadoBiometricoOtd>>(ft.IMPUTADO_BIOMETRICO)))
                .ForMember(dest => dest.Ingresos, entidad => entidad.MapFrom(ft => Mapper.Map<IList<IngresoOtd>>(ft.INGRESOes)));
        }
    }
}
