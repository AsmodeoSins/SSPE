using Administracion.OTD.AtributosPersonalizados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Administracion.Utilidades.ClasesAuxiliares
{
    /// <summary>
    /// Clase generica de mapeo
    /// </summary>
    /// <typeparam name="TipoDestino">Destino de los datos mapear</typeparam>
    /// <typeparam name="TipoFuente">Fuente de los datos a mapear</typeparam>
    public class Mapeador
    {
        /// <summary>
        /// Mapea las propiedades especificadas por el atributo NombreDeColumna dado un objeto origen
        /// </summary>
        /// <typeparam name="TDestino">Tipo de objeto a regresar</typeparam>
        /// <typeparam name="TOrigen">Tipo de objeto del cual se obtendra la informacion</typeparam>
        /// <param name="destino">Objeto al que se le asignaran los valores</param>
        /// <param name="origen">Objeto de donde se obtendran los valores</param>
        /// <returns>Regresa una instancia mapeada de tipo TDestino</returns>
        public TDestino MapearPropiedades<TDestino, TOrigen>(TDestino destino, TOrigen origen)
        {
            var tipoDestino = destino.GetType();
            var tipoOrigen = origen.GetType();

            bool esModelo = tipoDestino.GetCustomAttributes(false).Any(ca => ca.GetType() == typeof(ClaseBase));

            if (esModelo)
            {
                ConvertirModelo<TDestino, TOrigen>(destino, origen);
            }
            else
            {
                ConvertirAEntidad<TOrigen, TDestino>(origen, destino);
            }

            return destino;
        }

        /// <summary>
        /// Obtiene una lista dados los tipos de origen destino y una lista de tipo origen
        /// </summary>
        /// <typeparam name="TDestino">Tipo del que sera la lista</typeparam>
        /// <typeparam name="TOrigen">Tipo de la lista donde se encuentran los datos</typeparam>
        /// <param name="listaOrigen">Lista que contiene los datos</param>
        /// <returns></returns>
        public IEnumerable<TDestino> MapearLista<TDestino, TOrigen>(IEnumerable<TOrigen> listaOrigen)
        {
            return listaOrigen.Select(o => MapearPropiedades<TDestino, TOrigen>((TDestino)Activator.CreateInstance(typeof(TDestino)), o)).ToList();
        }

        #region Metodos privados
        /// <summary>
        /// Convierte un TEntidad a TModelo
        /// </summary>
        /// <typeparam name="TDestino"></typeparam>
        /// <typeparam name="TOrigen"></typeparam>
        /// <param name="destino"></param>
        /// <param name="origen"></param>
        /// <returns></returns>
        private TDestino ConvertirModelo<TDestino, TOrigen>(TDestino destino, TOrigen origen)
        {
            var tipoDestino = destino.GetType();
            var tipoOrigen = origen.GetType();

            var propiedadesDestino = tipoDestino.GetProperties().ToList();
            propiedadesDestino = propiedadesDestino.Where(p => p.GetCustomAttributes(false).Any(ca => ca.GetType() == typeof(NombreDeColumna))).ToList();
            var propiedadesOrigen = tipoOrigen.GetProperties();
            foreach (var propiedad in propiedadesDestino)
            {

                var columna = propiedad.GetCustomAttributes(false).SingleOrDefault(p => p.GetType() == typeof(NombreDeColumna)) as NombreDeColumna;
                var propiedadOrigen = propiedadesOrigen.SingleOrDefault(p => p.Name == columna.Nombre);
                var esNavegacion = propiedad.GetCustomAttributes(false).Any(p => p.GetType() == typeof(Navegacion));

                if (esNavegacion)
                {
                    var tipoNavegacion = propiedad.GetCustomAttributes(false).Single(ca => ca.GetType() == typeof(Navegacion)) as Navegacion;
                    var tipoNavegacionOrigen = tipoNavegacion.Tipo;
                    var tipoNavegacionDestino = propiedad.PropertyType;

                    if (EsColeccion(propiedad))
                    {
                        var tipoDeColeccionOrigen = tipoNavegacionOrigen.GetGenericArguments()[0];
                        var tipoDeColeccionDestino = tipoNavegacionDestino.GetGenericArguments()[0];
                        var valorPropiedadNavegacion = typeof(Mapeador)
                        .GetMethod("MapearLista")
                        .MakeGenericMethod(tipoDeColeccionDestino, tipoDeColeccionOrigen)
                        .Invoke(this, new object[] { propiedadOrigen.GetValue(origen, null) });

                        propiedad.SetValue(destino, valorPropiedadNavegacion, null);
                    }
                    else
                    {
                        var valorPropiedadNavegacion = typeof(Mapeador)
                        .GetMethod("MapearPropiedades")
                        .MakeGenericMethod(propiedad.PropertyType, tipoNavegacion.Tipo)
                        .Invoke(this, new object[] { Activator.CreateInstance(tipoNavegacionDestino), propiedadOrigen.GetValue(origen, null) });

                        propiedad.SetValue(destino, valorPropiedadNavegacion, null);
                    }

                }
                else
                {

                    if (propiedadOrigen == null)
                    {
                        throw new Exception(string.Format("No existe una propiedad con el nombre {0} en el objeto origen", columna.Nombre));
                    }

                    Type tipo = Nullable.GetUnderlyingType(propiedad.PropertyType) ?? propiedad.PropertyType;

                    var valorPropiedad = Convertir(propiedadOrigen.GetValue(origen, null), tipo);

                    propiedad.SetValue(destino, valorPropiedad, null);
                }
            }

            return destino;
        }

        /// <summary>
        /// Convierte un TModelo a TEntidad
        /// </summary>
        /// <typeparam name="TDestino"></typeparam>
        /// <typeparam name="TOrigen"></typeparam>
        /// <param name="destino"></param>
        /// <param name="origen"></param>
        /// <returns></returns>
        private TOrigen ConvertirAEntidad<TDestino, TOrigen>(TDestino destino, TOrigen origen)
        {
            var tipoDestino = destino.GetType();
            var tipoOrigen = origen.GetType();

            var propiedadesDestino = tipoDestino.GetProperties().ToList();
            propiedadesDestino = propiedadesDestino.Where(p => p.GetCustomAttributes(false).Any(ca => ca.GetType() == typeof(NombreDeColumna))).ToList();
            var propiedadesOrigen = tipoOrigen.GetProperties();
            foreach (var propiedad in propiedadesDestino)
            {
                if (!propiedad.GetCustomAttributes(false).Any(p => p.GetType() == typeof(Navegacion)))
                {
                    var columna = propiedad.GetCustomAttributes(false).SingleOrDefault(p => p.GetType() == typeof(NombreDeColumna)) as NombreDeColumna;
                    var propiedadOrigen = propiedadesOrigen.SingleOrDefault(p => p.Name == columna.Nombre);

                    if (propiedadOrigen == null)
                    {
                        throw new Exception(string.Format("No existe una propiedad con el nombre {0} en el objeto destino", columna.Nombre));
                    }

                    Type tipo = Nullable.GetUnderlyingType(propiedadOrigen.PropertyType) ?? propiedadOrigen.PropertyType;

                    var valorPropiedad = Convertir(propiedad.GetValue(destino, null), tipo);
                    propiedadOrigen.SetValue(origen, valorPropiedad, null);
                }
            }

            return origen;
        }

        /// <summary>
        /// Convierte al tipo de dato 'destino' dado un valor de origen
        /// </summary>
        /// <param name="origen">El valor que se asignara</param>
        /// <param name="destino">El tipo del valor al que se convertira</param>
        /// <returns></returns>
        private dynamic Convertir(dynamic origen, Type destino)
        {
            return (origen == null) ? null : Convert.ChangeType(origen, destino); ;
        }

        public bool EsColeccion(PropertyInfo property)
        {
            return property.PropertyType.GetInterface(typeof(IEnumerable<>).FullName) != null;
        }
        #endregion
    }
}
