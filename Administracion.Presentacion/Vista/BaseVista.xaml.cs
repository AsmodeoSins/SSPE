using Administracion.Utilidades.Autenticacion;
using System.Windows;

namespace Administracion.Presentacion
{
    /// <summary>
    /// Interaction logic for BaseVista.xaml
    /// </summary>
    public partial class BaseVista : Window
    {
        public BaseVista()
        {
            InitializeComponent();
            Sesion.PantallaPrincipal = this;

            if (!Sesion.ObjetoDeSesion.EsNueva)
            {
                this.WindowState = WindowState.Maximized;
                this.SizeToContent = SizeToContent.Manual;
            }
        }
    }
}