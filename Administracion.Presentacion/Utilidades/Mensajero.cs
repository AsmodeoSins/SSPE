using GalaSoft.MvvmLight.Messaging;
using System;

namespace Administracion.Presentacion.Utilidades
{
    public class Mensajero
    {
        public static void EnviarMensaje<T>(T mensaje)
        {
            Messenger.Default.Send(mensaje);
        }

        public static void RegistrarSuscripcion<T>(object beneficiado, Action<T> mensaje)
        {
            Messenger.Default.Register<T>(beneficiado, mensaje);
        }

        public static void RemoverSuscripcion<T>(object beneficiado, Action<T> mensaje)
        {
            Messenger.Default.Unregister<T>(beneficiado, mensaje);
        }

    }
}