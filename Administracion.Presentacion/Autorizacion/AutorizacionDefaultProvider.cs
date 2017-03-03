using Administracion.OTD;
using Administracion.Utilidades.Autenticacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIAuthorization;

namespace Administracion.Presentacion.Autorizacion
{
    public class AutorizacionDefaultProvider : AutorizacionProvider
    {
        private static IList<PermisosModulo> _permisos;

        /// <summary>
        /// Carga la lista de permisos del usuario
        /// </summary>
        public AutorizacionDefaultProvider(IList<PermisosModulo> permisos)
        {
            _permisos = permisos;
        }

        /// <summary>
        /// Determina si el usuario tiene los permisos requeridos para acceder al modulo
        /// </summary>
        public override bool VerificiarAcceso(string operacion)
        {
            if (String.IsNullOrEmpty(operacion))
                return false;

            if ((operacion == Constantes.CONFIGURACION && Sesion.ObjetoDeSesion.Usuario == null) || operacion == Constantes.HORARIOS)
            {
                return true;
            }

            if (_permisos != null && _permisos.Count > 0)
            {
                var arreglo = operacion.Split(';');

                if (arreglo.Count() == 2)
                {
                    var permiso = _permisos.SingleOrDefault(p => p.NombreModulo.ToUpperInvariant() == arreglo.First().ToUpperInvariant());
                    return permiso != null && ObtenerValor(permiso, arreglo.Last());
                }
                else
                {
                    var permiso = _permisos.SingleOrDefault(p => p.NombreModulo.ToUpperInvariant() == arreglo.First().ToUpperInvariant());
                    return permiso != null && (permiso.Insertar || permiso.Consultar || permiso.Editar);
                }
            }
            return false;
        }

        #region Miembros privados
        public static bool ObtenerValor(object obj, string nombre)
        {
            return (bool)obj.GetType().GetProperty(nombre).GetValue(obj, null);
        }
        #endregion
    }
}
