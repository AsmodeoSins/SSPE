using System;
using System.ComponentModel;

namespace Administracion.Presentacion.Controles
{
    public class LoadingContexto
    {
        public BackgroundWorker Worker { get; private set; }
        public DoWorkEventArgs Arguments { get; private set; }

        public LoadingContexto(BackgroundWorker worker, DoWorkEventArgs arguments)
        {
            if (worker == null)
            {
                throw new ArgumentNullException("worker");
            }

            if (arguments == null)
            {
                throw new ArgumentNullException("arguments");
            }

            Worker = worker;
            Arguments = arguments;
        }

        public bool VerificarCancelacionPendiente()
        {
            if (Worker.WorkerSupportsCancellation && Worker.CancellationPending)
            {
                Arguments.Cancel = true;
            }

            return Arguments.Cancel;
        }

        public void ActivarCancelacionPendiente()
        {
            if (VerificarCancelacionPendiente())
            {
                throw new LoadingCancelacion();
            }
        }

        public void Reportar(string mensaje)
        {
            if (Worker.WorkerReportsProgress)
                Worker.ReportProgress(0, mensaje);
        }

        public void Reportar(string formato, params object[] arg)
        {
            if (Worker.WorkerReportsProgress)
                Worker.ReportProgress(0, string.Format(formato, arg));
        }

        public void Reportar(int progreso, string mensaje)
        {
            if (Worker.WorkerReportsProgress)
                Worker.ReportProgress(progreso, mensaje);
        }

        public void Reportar(int progreso, string formato, params object[] arg)
        {
            if (Worker.WorkerReportsProgress)
                Worker.ReportProgress(progreso, string.Format(formato, arg));
        }

        public void ReportarCancelacion(string mensaje)
        {
            ActivarCancelacionPendiente();

            if (Worker.WorkerReportsProgress)
                Worker.ReportProgress(0, mensaje);
        }

        public void ReportarCancelacion(string formato, params object[] arg)
        {
            ActivarCancelacionPendiente();

            if (Worker.WorkerReportsProgress)
                Worker.ReportProgress(0, string.Format(formato, arg));
        }

        public void ReportarCancelacion(int progreso, string mensaje)
        {
            ActivarCancelacionPendiente();

            if (Worker.WorkerReportsProgress)
                Worker.ReportProgress(progreso, mensaje);
        }

        public void ReportarCancelacion(int progreso, string formato, params object[] arg)
        {
            ActivarCancelacionPendiente();

            if (Worker.WorkerReportsProgress)
                Worker.ReportProgress(progreso, string.Format(formato, arg));
        }
    }
}