namespace Administracion.Presentacion.Controles
{
    public class LoadingConfiguracion
    {
        public static LoadingConfiguracion ConTitulo = new LoadingConfiguracion(false, false, true);
        public static LoadingConfiguracion ConSubtitulo = new LoadingConfiguracion(true, false, true);
        public static LoadingConfiguracion ConCancelacion = new LoadingConfiguracion(true, true, true);

        public bool MostrarSubtitulo { get; set; }
        public bool MostrarBotonCancelar { get; set; }
        public bool MostrarBarraDeProgresoInfinita { get; set; }

        public LoadingConfiguracion()
        {
            MostrarSubtitulo = false;
            MostrarBotonCancelar = false;
            MostrarBarraDeProgresoInfinita = true;
        }

        public LoadingConfiguracion(bool mostrarSubtitulo, bool mostrarBotonCancelar, bool mostrarBarraDeProgresoInfinita)
        {
            MostrarSubtitulo = mostrarSubtitulo;
            MostrarBotonCancelar = mostrarBotonCancelar;
            MostrarBarraDeProgresoInfinita = mostrarBarraDeProgresoInfinita;
        }
    }
}