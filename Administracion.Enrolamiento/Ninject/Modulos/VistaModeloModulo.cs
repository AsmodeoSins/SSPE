using Administracion.Contratos.Enrolamiento;
using Administracion.Enrolamiento.VistaModelo;
using Ninject.Modules;

namespace Administracion.Enrolamiento.Ninject
{
    public class VistaModeloModulo : NinjectModule
    {
        public override void Load()
        {
            Bind<IPrincipalVistaModelo>().To<PrincipalVistaModelo>();
        }
    }
}