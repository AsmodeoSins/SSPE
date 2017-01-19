using Administracion.Contratos;
using Administracion.Contratos.Servicios;
using Administracion.Servicio;
using Ninject.Modules;

namespace Administracion.Presentacion.Ninject
{
    public class ServicioModulo : NinjectModule
    {
        public override void Load()
        {
            Bind<IPaseListaServicio>().To<PaseListaServicio>();
            Bind<IPersonaServicio>().To<PersonaServicio>();
            Bind<IIncidenciaServicio>().To<IncidenciaServicio>();
            Bind<IPLCatalogoServicio>().To<PLCatalogoServicio>();
            Bind<IPLCatalogoEstatusServicio>().To<PLCatalogoEstatusRepositorio>();
            //Bind<IIrisServicio>().To<IrisServicio>();
            Bind<IImputadoServicio>().To<ImputadoServicio>();
            Bind<IParametroServicio>().To<ParametroServicio>();
            Bind<IReportesServicio>().To<ReportesServicio>();
            Bind<IUbicacionServicio>().To<UbicacionServicio>();
            Bind<IPLProgramadoServicio>().To<PLProgramadoServicio>();
            Bind<IPLProgramadoAsignacionServicio>().To<PLProgramadoAsignacionServicio>();
            Bind<ISectorServicio>().To<SectorServicio>();
            Bind<IPLIncidenciaBitacoraServicio>().To<PLIncidenciaBitacoraServicio>();
            Bind<IIngresoServicio>().To<IngresoServicio>();
            Bind<ICentroServicio>().To<CentroServicio>();
            Bind<IImputadoBiometricoServicio>().To<ImputadoBiometricoServicio>();
            Bind<IEmpleadoServicio>().To<EmpleadoServicio>();
            Bind<IUsuarioServicio>().To<UsuarioServicio>();
        }
    }
}