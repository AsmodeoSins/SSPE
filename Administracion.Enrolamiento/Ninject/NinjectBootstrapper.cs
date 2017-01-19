using Ninject;
using System;

namespace Administracion.Enrolamiento.Ninject
{
    public class NinjectBootstrapper : INinjectBootstrapper
    {
        public NinjectBootstrapper()
        {
            Nucleo = new StandardKernel();
        }

        public IKernel Nucleo
        {
            get;
            set;
        }

        public void CargarModulos()
        {
            //Servicios
            Nucleo.Load(new ServicioModulo());

            //Repositorios
            Nucleo.Load(new RepositorioModulo());

            //Vistas Modelos
            Nucleo.Load(new VistaModeloModulo());
        }
    }
}