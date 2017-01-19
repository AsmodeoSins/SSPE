using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace Administracion.Presentacion.Controles
{
    public partial class LoadingPantalla : Window
    {
        private BackgroundWorker _hiloPrincipal;
        private volatile bool _ocupado;

        public LoadingPantalla(LoadingConfiguracion configuraciones)
        {
            InitializeComponent();

            if (configuraciones == null)
            {
                configuraciones = LoadingConfiguracion.ConTitulo;
            }

            CancelButton.Visibility = configuraciones.MostrarBotonCancelar ? Visibility.Visible : Visibility.Collapsed;

            InicializarAnimacion();
        }

        public Loading Resultado { get; private set; }

        private static LoadingContexto LoadingActual { get; set; }

        private static string Mensaje { get; set; }

        private LoadingAnimacion Animacion { get; set; }

        public static Loading Ejecutar(Window ventana, string etiqueta, Action accion)
        {
            return EjecucionInterna(ventana, etiqueta, (object)accion, null);
        }

        public static Loading Ejecutar(Window ventana, string etiqueta, Action accion, LoadingConfiguracion configuraciones)
        {
            return EjecucionInterna(ventana, etiqueta, (object)accion, configuraciones);
        }

        public static Loading Ejecutar(Window ventana, string etiqueta, Func<object> ejecucionConResultado)
        {
            return EjecucionInterna(ventana, etiqueta, (object)ejecucionConResultado, null);
        }

        public static Loading Ejecutar(Window ventana, string etiqueta, Func<object> ejecucionConResultado, LoadingConfiguracion configuraciones)
        {
            return EjecucionInterna(ventana, etiqueta, (object)ejecucionConResultado, configuraciones);
        }

        public static void Ejecutar(Window ventana, string etiqueta, Action accion, Action<Loading> EjecucionExitosa, Action<Loading> falloEjecucion = null, Action<Loading> cancelarEjecucion = null)
        {
            Loading resultado = EjecucionInterna(ventana, etiqueta, accion, null);

            if (resultado.FueCancelado && cancelarEjecucion != null)
            {
                cancelarEjecucion(resultado);
            }
            else if (resultado.EjecucionFallo && falloEjecucion != null)
            {
                falloEjecucion(resultado);
            }
            else if (EjecucionExitosa != null)
            {
                EjecucionExitosa(resultado);
            }
        }

        private static Loading EjecucionInterna(Window ventana, string etiqueta, object accion, LoadingConfiguracion configuraciones)
        {
            LoadingPantalla pantalla = new LoadingPantalla(configuraciones);
            pantalla.Owner = ventana;

            if (!string.IsNullOrEmpty(etiqueta))
            {
                Mensaje = etiqueta;
            }

            return pantalla.Ejecutar(accion);
        }

        private Loading Ejecutar(object accion)
        {
            if (accion == null)
            {
                throw new ArgumentNullException("accion");
            }

            Loading resultado = null;

            _ocupado = true;
            Animacion.Mensaje = Mensaje;

            _hiloPrincipal = new BackgroundWorker();

            _hiloPrincipal.WorkerReportsProgress = true;
            _hiloPrincipal.WorkerSupportsCancellation = true;

            _hiloPrincipal.DoWork +=
                (s, e) =>
                {
                    try
                    {
                        LoadingPantalla.LoadingActual = new LoadingContexto(s as BackgroundWorker, e as DoWorkEventArgs);

                        if (accion is Action)
                        {
                            ((Action)accion)();
                        }
                        else if (accion is Func<object>)
                        {
                            e.Result = ((Func<object>)accion)();
                        }
                        else
                        {
                            throw new InvalidOperationException("El tipo de Operacion no es soportada");
                        }

                        LoadingPantalla.LoadingActual.VerificarCancelacionPendiente();
                    }
                    catch (LoadingCancelacion)
                    {
                    }
                    catch (Exception ex)
                    {
                        if (!LoadingPantalla.LoadingActual.VerificarCancelacionPendiente())
                        {
                            throw ex;
                        }
                    }
                    finally
                    {
                        LoadingPantalla.LoadingActual = null;
                    }
                };

            _hiloPrincipal.RunWorkerCompleted +=
                (s, e) =>
                {
                    resultado = new Loading(e);

                    Dispatcher.BeginInvoke(DispatcherPriority.Send, (SendOrPostCallback)delegate
                    {
                        _ocupado = false;
                        Close();
                    }, null);
                };

            _hiloPrincipal.ProgressChanged +=
                (s, e) =>
                {
                    if (!_hiloPrincipal.CancellationPending)
                    {
                        //Subtitulo = (e.UserState as string) ?? string.Empty;
                        //ProgressBar.Value = e.ProgressPercentage;
                    }
                };

            _hiloPrincipal.RunWorkerAsync();

            ShowDialog();

            return resultado;
        }

        private void InicializarAnimacion()
        {
            Animacion = new LoadingAnimacion();
            Animacion.HorizontalAlignment = HorizontalAlignment.Center;
            Animacion.VerticalAlignment = VerticalAlignment.Center;
            stackPanelLoading.Children.Add(Animacion);
        }

        private void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {
            if (_hiloPrincipal != null && _hiloPrincipal.WorkerSupportsCancellation)
            {
                //Subtitulo = "Estamos cancelando la operacion...";
                CancelButton.IsEnabled = false;
                _hiloPrincipal.CancelAsync();
            }
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            e.Cancel = _ocupado;
        }
    }
}