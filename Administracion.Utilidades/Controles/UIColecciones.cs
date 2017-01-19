using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Threading;

namespace Administracion.Utilidades.Controles
{
    public class UIColeccion<T> : ObservableCollection<T>
    {
        public UIColeccion(IEnumerable<T> collection)
            : base(collection)
        {
        }

        public UIColeccion()
            : base()
        {
        }

        public override event NotifyCollectionChangedEventHandler CollectionChanged;

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            NotifyCollectionChangedEventHandler listaCambiada = this.CollectionChanged;

            if (listaCambiada != null)
            {
                foreach (NotifyCollectionChangedEventHandler notificacion in listaCambiada.GetInvocationList())
                {
                    DispatcherObject dispatcherObject = notificacion.Target as DispatcherObject;
                    if (dispatcherObject != null)
                    {
                        Dispatcher dispatcher = dispatcherObject.Dispatcher;
                        if (dispatcher != null && !dispatcher.CheckAccess())
                        {
                            dispatcher.BeginInvoke(
                                (Action)(() => notificacion.Invoke(this,
                                    new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset))),
                                DispatcherPriority.DataBind);
                            continue;
                        }
                    }
                    notificacion.Invoke(this, e);
                }
            }
        }
    }
}