using System;
using System.ComponentModel;
using System.Windows;

namespace Administracion.Presentacion.Controles
{
    public class Loading
    {
        #region Miembros privados
        Exception _error;
        #endregion
        public object Resultado { get; private set; }
        public bool FueCancelado { get; private set; }
        public Exception Error 
        {
            get
            {
                return _error;
            }
            set
            {
                _error = value;
                MessageBox.Show(value.Message, "Error");
            }
        }

        public bool EjecucionFallo
        {
            get
            {
                return Error != null;
            }
        }

        public Loading(RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                FueCancelado = true;
            }
            else if (e.Error != null)
            {
                Error = e.Error;
            }
            else
            {
                Resultado = e.Result;
            }
        }
    }
}