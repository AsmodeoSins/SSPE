using Administracion.Contratos;
//using Administracion.Contratos.Presentacion.Controles;
using Administracion.Presentacion.VistaModelo;
//using Administracion.Presentacion.VistaModelo.Controles;
using Ninject.Modules;

namespace Administracion.Presentacion.Ninject
{
    public class VistaModeloModulo : NinjectModule
    {
        public override void Load()
        {
            Bind<IBaseVistaModelo>().To<BaseVistaModelo>();
            Bind<IBiometricoBaseVistaModelo>().To<BiometricoBaseVistaModelo>();
            Bind<IBusquedaPersonaVistaModelo>().To<BusquedaPersonaVistaModelo>();
            Bind<IIncidenciasVistaModelo>().To<IncidenciasVistaModelo>();
            Bind<IPaseListaVistaModelo>().To<PaseListaVistaModelo>();
            Bind<ICapturaBiometricoVistaModelo>().To<CapturaBiometricoVistaModelo>();
            Bind<ICapturaBiometricoVisitaVistaModelo>().To<CapturaBiometricoVisitaVistaModelo>();
            Bind<IProgramacionPaseListaVistaModelo>().To<ProgramacionPaseListaVistaModelo>();
            Bind<ITiempoPaseDeListaVistaModelo>().To<TiempoPaseDeListaVistaModelo>();
            Bind<IPaseListaReporteVistaModelo>().To<PaseListaReporteVistaModelo>();
            Bind<IIncidenciasReporteVistaModelo>().To<IncidenciasReporteVistaModelo>();
            Bind<IIncidenciasPorInternoVistaModelo>().To<IncidenciasPorInternoVistaModelo>();
            Bind<IConfiguracionVista>().To<ConfiguracionVistaModelo>();
        }
    }
}