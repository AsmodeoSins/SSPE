using Administracion.OTD;
using System;
using System.Security.Policy;
using System.Windows;

namespace Administracion.Utilidades.Autenticacion
{
    public static class Sesion
    {
        private static SesionOtd _sesion;
        public static SesionOtd ObjetoDeSesion 
        {
            get
            {
                return _sesion;
            }
            set
            {
                _sesion = value;
            }
        }

        public static AppDomain DominioiDeApplicaciones
        {
            get
            {
                return AppDomain.CurrentDomain;
            }
        }

        private static Window _pantallaPrincipal;
        public static Window PantallaPrincipal
        {
            get
            {
                return _pantallaPrincipal;
            }
            set
            {
                _pantallaPrincipal = value;
            }
        }
    }
}
