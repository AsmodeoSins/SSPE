using Administracion.Utilidades.Mapeadores;

namespace Administracion.Utilidades.ClasesAuxiliares
{
    public static class Mapeadores
    {
        public static void InicializarMapeadores()
        {
            IngresoMapeador.Configuracion();
            ParametroClaveMapeador.Configuracion();
            ParametroMapeador.Configuracion();
            BiometricoMapeador.Configuracion();
            PersonaMapeador.Configuracion();
            PLAsignacionBitacoraMapeador.Configuracion();
            PLAsignacionResultadoMapeador.Configuracion();
            PLCatalogoMapeador.Configuracion();
            PLIncidenciaCatalogoMapeador.Configuracion();
            PLIncidenciaEstatusMapeador.Configuracion();
            PLProgramadoAsignacionMapeador.Configuracion();
            TipoDeCeldaMapeador.Configuracion();
            TipoDeCentroMapeador.Configuracion();
            TipoDeEdificionMapeador.Configuracion();
            TipoDeEmpleadoMapeador.Configuracion();
            TipoDeIngresoMapeador.Configuracion();
            TipoDePersonaMapeador.Configuracion();
            TipoDePersonaMapeador.Configuracion();
            UbicacionMapeador.Configuracion();
            ReporteMapeador.Configuraction();
            UsuarioMapeador.Configuracion();
        }
    }
}
