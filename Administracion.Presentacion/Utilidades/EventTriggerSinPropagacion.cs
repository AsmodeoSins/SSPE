using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Administracion.Presentacion.Utilidades
{
    public class EventTriggerSinPropagacion : System.Windows.Interactivity.EventTrigger
    {
        protected override void OnEvent(System.EventArgs eventArgs)
        {
            var routedEventArgs = eventArgs as RoutedEventArgs;
            if (routedEventArgs != null)
                routedEventArgs.Handled = true;

            base.OnEvent(eventArgs);
        }
    }
}
