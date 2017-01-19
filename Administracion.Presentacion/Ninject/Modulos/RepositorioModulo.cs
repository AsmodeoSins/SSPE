using Administracion.Contratos;
using Administracion.Contratos.Repositorio;
using Administracion.Repositorio.Accesso;
using Ninject.Modules;

namespace Administracion.Presentacion.Ninject
{
    public class RepositorioModulo : NinjectModule
    {
        public override void Load()
        {
            Bind<IPaseListaRepositorio>().To<PaseListaRepositorio>();
            Bind<IPersonaRepositorio>().To<PersonaRepositorio>();
            Bind<IImputadoRepositorio>().To<ImputadoRepositorio>();
            Bind<IIncidenciaRepositorio>().To<IncidenciaRepositorio>();
            Bind<IPLCatalogoRepositorio>().To<PLCatalogoRepositorio>();
            Bind<IPLCatalogoEstatusRepositorio>().To<PLCatalogoEstatusRepositorio>();
            Bind<IImputadoBiometricoRepositorio>().To<ImputadoBiometricoRepositorio>();
            Bind<IPersonaBiometricoRepositorio>().To<PersonaBiometricoRepositorio>();
            Bind<IEdificioRepositorio>().To<EdificioRepositorio>();
            Bind<IParametroRepositorio>().To<ParametroRepositorio>();
            Bind<IPaseListaAsignacionRepositorio>().To<PaseListaAsignacionRepositorio>();
            Bind<IEmpleadoRepositorio>().To<EmpleadoRepositorio>();
            Bind<IPLProgramadoRepositorio>().To<PLProgramadoRepositorio>();
            Bind<IPLProgramadoAsignacionRepositorio>().To<PLProgramadoAsignacionRepositorio>();
            Bind<IPLProgramadoBitRepositorio>().To<PLProgramadoBitRepositorio>();
            Bind<IPLAsignacionResultRepositorio>().To<PLAsignacionResultRepositorio>();
            Bind<ICentroRepositorio>().To<CentroRepositorio>();
            Bind<ISectorRepositorio>().To<SectorRepositorio>();
            Bind<ICeldaRepositorio>().To<CeldaRepositorio>();
            Bind<IPLIncidenciaBitacoraRepositorio>().To<PLIncidenciaBitacoraRepositorio>();
            Bind<IIngresoRepositorio>().To<IngresoRepositorio>();
            Bind<IUsuarioRepositorio>().To<UsuarioRepositorio>();
        }
    }
}