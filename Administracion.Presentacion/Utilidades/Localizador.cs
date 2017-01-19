using Administracion.Contratos;
//using Administracion.Contratos.Presentacion.Controles;
using Administracion.Presentacion.Ninject;
using CommonServiceLocator.NinjectAdapter.Unofficial;
using GalaSoft.MvvmLight;
using Microsoft.Practices.ServiceLocation;

namespace Administracion.Presentacion.Utilidades
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

        public IBiometricoBaseVistaModelo BiometricoBase
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IBiometricoBaseVistaModelo>();
            }
        }

        public IBusquedaPersonaVistaModelo BusquedaPersona
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IBusquedaPersonaVistaModelo>();
            }
        }

        public IIncidenciasVistaModelo IncidenciaBase
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IIncidenciasVistaModelo>();
            }
        }

        public IPaseListaVistaModelo PaseDeListaBase
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IPaseListaVistaModelo>();
            }
        }

        public ICapturaBiometricoVistaModelo CapturaBiometrico
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ICapturaBiometricoVistaModelo>();
            }
        }

        public IProgramacionPaseListaVistaModelo ProgramarPaseLista
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IProgramacionPaseListaVistaModelo>();
            }
        }

        public ITiempoPaseDeListaVistaModelo TiempoPaseListaBase
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ITiempoPaseDeListaVistaModelo>();
            }
        }

        public IPaseListaReporteVistaModelo PaseListaReporte
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IPaseListaReporteVistaModelo>();
            }
        }

        public IIncidenciasReporteVistaModelo IncidenciaReporte
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IIncidenciasReporteVistaModelo>();
            }
        }

        public IIncidenciasPorInternoVistaModelo IncidenciaPorInternoBase
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IIncidenciasPorInternoVistaModelo>();
            }
        }

        public IBaseVistaModelo BaseTabs
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IBaseVistaModelo>();
            }
        }

        public IConfiguracionVista ConfiguracionBase
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IConfiguracionVista>();
            }
        }

        public static void Cleanup()
        {
        }
    }
}