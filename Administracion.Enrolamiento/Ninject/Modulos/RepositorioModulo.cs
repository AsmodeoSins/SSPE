using Administracion.Contratos;
using Administracion.Contratos.Repositorio;
using Administracion.Repositorio.Accesso;
using Ninject.Modules;

namespace Administracion.Enrolamiento.Ninject
{
    public class RepositorioModulo : NinjectModule
    {
        public override void Load()
        {
            Bind<IPersonaRepositorio>().To<PersonaRepositorio>();
            Bind<IImputadoRepositorio>().To<ImputadoRepositorio>();
            Bind<IImputadoBiometricoRepositorio>().To<ImputadoBiometricoRepositorio>();
            Bind<IPersonaBiometricoRepositorio>().To<PersonaBiometricoRepositorio>();
            Bind<IEmpleadoRepositorio>().To<EmpleadoRepositorio>(); 
            Bind<ICentroRepositorio>().To<CentroRepositorio>();  
            Bind<IIngresoRepositorio>().To<IngresoRepositorio>();
            Bind<IUsuarioRepositorio>().To<UsuarioRepositorio>();
        }
    }
}