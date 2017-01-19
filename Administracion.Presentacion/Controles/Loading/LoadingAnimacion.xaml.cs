using System.Windows.Controls;

namespace Administracion.Presentacion.Controles
{
    /// <summary>
    /// Interaction logic for LoadingAnimacion.xaml
    /// </summary>
    public partial class LoadingAnimacion : UserControl
    {
        public LoadingAnimacion()
        {
            InitializeComponent();
            Mensaje = "Cargando...";
        }

        public string Mensaje {
            get
            {
                return TexBlockMensaje.Text;
            }
            set
            {
                TexBlockMensaje.Text = value;
            }
        }
    }
}