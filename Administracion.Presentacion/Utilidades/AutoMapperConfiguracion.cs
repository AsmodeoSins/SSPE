using Administracion.Utilidades.Mapeadores;

namespace Administracion.Presentacion.Utilidades
{
    public static class AutoMapperConfiguracion
    {
        public static void Configurar()
        {
            PersonaMapeador.Configuracion();
            PLIncidenciaCatalogoMapeador.Configuracion();
            IngresoMapeador.Configuracion();
            PLCatalogoMapeador.Configuracion();
            BiometricoMapeador.Configuracion();
            ParametroMapeador.Configuracion();
            ParametroClaveMapeador.Configuracion();
            PLAsignacionBitacoraMapeador.Configuracion();
            PLAsignacionResultadoMapeador.Configuracion();
            PLIncidenciaEstatusMapeador.Configuracion();
            TipoDeCeldaMapeador.Configuracion();
            TipoDeCentroMapeador.Configuracion();
            TipoDeEdificionMapeador.Configuracion();
            TipoDeEmpleadoMapeador.Configuracion();
            TipoDeIngresoMapeador.Configuracion();
            TipoDePersonaMapeador.Configuracion();
            UbicacionMapeador.Configuracion();
            PLProgramadoMapeador.Configuracion();
            PLProgramadoAsignacionMapeador.Configuracion();
            ReporteMapeador.Configuraction();
            PLIncidenciaBitacoraMapeador.Configuracion();
            LogFallaServicioMapeador.Configuracion();
            UsuarioMapeador.Configuracion();
        }
    }
}
