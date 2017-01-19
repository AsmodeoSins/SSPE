using Administracion.OTD;
using System;
using System.Collections.Generic;

namespace Administracion.Presentacion.Autorizacion
{
    public abstract class AutorizacionProvider
    {
        private static AutorizacionProvider _instance;

        /// <summary>
        /// Determina si el usuario tiene los permisos requeridos para acceder al modulo
        /// </summary>
        public abstract bool VerificiarAcceso(string operation);

        public static void Initialize<TProvider>() where TProvider : AutorizacionProvider, new()
        {
            _instance = new TProvider();
        }

        public static void Initialize<TProvider>(IList<PermisosModulo> permisos)
        {
            _instance = (AutorizacionProvider)typeof(TProvider).GetConstructor(new Type[] { typeof(IList<PermisosModulo>) }).Invoke(new object[] { permisos });
        }

        public static AutorizacionProvider Instancia
        {
            get { return _instance; }
        }
    }
}
