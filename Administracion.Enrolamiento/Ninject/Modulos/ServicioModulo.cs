using Administracion.Contratos;
using Administracion.Contratos.Servicios;
using Administracion.Servicio;
using Ninject.Modules;

namespace Administracion.Enrolamiento.Ninject
{
    public class ServicioModulo : NinjectModule
    {
        public override void Load()
        {
            Bind<IPersonaServicio>().To<PersonaServicio>();
            Bind<IUsuarioServicio>().To<UsuarioServicio>();
        }
    }
}