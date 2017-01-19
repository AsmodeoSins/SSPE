using System;
using System.Runtime.Serialization;

namespace Administracion.Presentacion.Controles
{
    [Serializable]
    internal class LoadingCancelacion : Exception
    {
        public LoadingCancelacion()
            : base()
        {
        }

        public LoadingCancelacion(string mensaje)
            : base(mensaje)
        {
        }

        public LoadingCancelacion(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
        }

        public LoadingCancelacion(string formato, params string[] arg)
            : base(string.Format(formato, arg))
        {
        }

        protected LoadingCancelacion(SerializationInfo info, StreamingContext contexto)
            : base(info, contexto)
        {
        }
    }
}