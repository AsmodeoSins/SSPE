using Administracion.Enrolamiento.Utilidades;
using GalaSoft.MvvmLight.Threading;
using System.Windows;

namespace Administracion.Enrolamiento
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            AutoMapperConfiguracion.Configurar();
            DispatcherHelper.Initialize();
            base.OnStartup(e);
        }
    }
}