using Administracion.Utilidades.Mapeadores;

namespace Administracion.Enrolamiento.Utilidades
{
    public static class AutoMapperConfiguracion
    {
        public static void Configurar()
        {
            PersonaMapeador.Configuracion();
            IngresoMapeador.Configuracion();
            BiometricoMapeador.Configuracion();
            TipoDeCentroMapeador.Configuracion();
            TipoDeEmpleadoMapeador.Configuracion();
            UsuarioMapeador.Configuracion();
        }
    }
}
