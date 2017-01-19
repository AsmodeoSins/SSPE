using Administracion.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Administracion.Utilidades.ClasesAuxiliares
{
    public static class MetodosExtendidos
    {
        /// <summary>
        /// Clona un objeto y regresa el nuevo objeto.
        /// </summary>
        /// <typeparam name="T">Tipo del objeto.</typeparam>
        /// <param name="objetoOriginal">El objeto original.</param>
        /// <returns>El nuevo objeto generado.</returns>
        public static T Clonar<T>(this T objetoOriginal)
        {
            var dcs = new DataContractSerializer(typeof(T));
            using (var ms = new System.IO.MemoryStream())
            {
                dcs.WriteObject(ms, objetoOriginal);
                ms.Seek(0, System.IO.SeekOrigin.Begin);
                return (T)dcs.ReadObject(ms);
            }
        }

        public static string ObtenerStringMes(this DateTime fecha, bool enMayusculas = false)
        {
            var mes = (Enums.Meses)fecha.Month;
            return enMayusculas ? mes.ToString().ToUpper() : mes.ToString();
        }
    }
}
