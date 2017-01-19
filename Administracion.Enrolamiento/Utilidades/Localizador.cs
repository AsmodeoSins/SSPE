using Administracion.Contratos.Enrolamiento;
using Administracion.Enrolamiento.Ninject;
using CommonServiceLocator.NinjectAdapter.Unofficial;
using GalaSoft.MvvmLight;
using Microsoft.Practices.ServiceLocation;

namespace Administracion.Enrolamiento.Utilidades
{
    public class Localizador
    {
        private readonly INinjectBootstrapper _ninjectBootstrapper;

        public Localizador()
        {
            if (ViewModelBase.IsInDesignModeStatic)
            {
                _ninjectBootstrapper = new DisenoNinjectBootstrapper();
            }
            else
            {
                _ninjectBootstrapper = new NinjectBootstrapper();
            }

            _ninjectBootstrapper.CargarModulos();

            var serviceLocator = new NinjectServiceLocator(_ninjectBootstrapper.Nucleo);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }

        public IPrincipalVistaModelo Principal
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IPrincipalVistaModelo>();
            }
        }

        public static void Cleanup()
        {
        }
    }
}