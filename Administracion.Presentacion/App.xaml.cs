using Administracion.OTD;
using Administracion.Presentacion.Autorizacion;
using Administracion.Presentacion.Properties;
using Administracion.Presentacion.Utilidades;
using Administracion.Servicio;
using Administracion.Utilidades.Autenticacion;
using Administracion.Utilidades.ClasesAuxiliares;
using Administracion.Utilidades.Constantes;
using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Threading;

namespace Administracion.Presentacion
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            AutoMapperConfiguracion.Configurar();
            // datos de configuracion almacenados en app.Config
            var datosDeConexionAppConfig = Settings.Default.DatosDeConfiguracion.Trim();
            var stringADeserializar = e.Args.Any() ? e.Args.First() : datosDeConexionAppConfig;
            // se asigna el centro recibido a la clase de sesion
            var sesion = new JavaScriptSerializer().Deserialize<SesionOtd>(CodificadorBase64.DecodificarDeBase64(stringADeserializar));

            Sesion.ObjetoDeSesion = sesion != null ? sesion : new SesionOtd { EsNueva = true };
            List<PermisosModulo> permisos = sesion != null ? sesion.PermisosModulos : null;
            DispatcherHelper.Initialize();
            AutorizacionProvider.Initialize<AutorizacionDefaultProvider>(permisos);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            base.OnStartup(e);
        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception excepcion = e.ExceptionObject as Exception;
            MessageBox.Show(string.Format(SSPConst.ErrorInesperadoMsg, excepcion.Message), "Error");
        }

        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Exception excepcion = e.Exception;
            MessageBox.Show(string.Format(SSPConst.ErrorInesperadoMsg, excepcion.Message), "Error");
        }
    }
}